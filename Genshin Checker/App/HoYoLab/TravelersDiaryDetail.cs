using Genshin_Checker.App.General;
using Genshin_Checker.Model.UserData.TravelersDiary.Lists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public class TravelersDiaryDetail : Base
    {
        const int MAXPAGE = 10000;
        public class ProgressState
        {
            internal ProgressState(double progress,int current,int total,string mode,int month)
            {
                Progress= progress;
                CurrentPage= current;
                TotalPage= total;
                this.mode = mode;
                this.month = month;
            }
            public readonly double Progress;
            public readonly int CurrentPage;
            public readonly int TotalPage;
            public readonly string mode;
            public readonly int month;

        }
        public event EventHandler<ProgressState>? ProgressChanged;
        public event EventHandler? ProgressCompreted;
        public event EventHandler<Exception>? ProgressFailed;
        public enum CorrectMode
        {
            Primogems,
            Mora,
            All
        }
        //API用
        enum Mode
        {
            Primogems = 1,
            Mora = 2,
        }


        int totalcount;
        public async Task Correct(List<int>? months=null, CorrectMode mode = CorrectMode.All)
        {
            try
            {
                totalcount = 0;
                months ??= new() { 0 }; //空だった場合は当月を取得
                int cnt = 0;
                foreach (var month in months)
                {
                    if (mode == CorrectMode.All || mode == CorrectMode.Primogems)
                        await CorrectData(month, Mode.Primogems, cnt * (mode == CorrectMode.All ? 2 : 1), months.Count * (mode == CorrectMode.All ? 2 : 1));
                    if (mode == CorrectMode.All || mode == CorrectMode.Mora)
                        await CorrectData(month, Mode.Mora, cnt * (mode == CorrectMode.All ? 2 : 1) + (mode == CorrectMode.All ? 1 : 0), months.Count * (mode == CorrectMode.All ? 2 : 1));
                    cnt++;
                }
                ProgressCompreted?.Invoke("", EventArgs.Empty);
            }catch(Exception ex)
            {
                ProgressFailed?.Invoke("", ex);
                throw;
            }
        }
        /// <summary>
        /// 【内部関数】APIから詳細データの取得
        /// </summary>
        /// <param name="month">月のデータ(0であれば当月)</param>
        /// <param name="mode">取得モード</param>
        /// <returns></returns>
        private async Task CorrectData(int month, Mode mode, int position=0,int total=2147483647)
        {
            DateTime Latest = DateTime.MinValue;
            int LatestCount = 0;
            bool IsEnd = false;
            var lists = new Model.UserData.TravelersDiary.Lists.Root();
            var eventlists = new Model.UserData.TravelersDiary.EventName.Root();
            var localeEventPath = $"locale\\{account.Culture.Name.ToLower()}\\";
            var eventpath = Registry.GetValue(localeEventPath, $"EventName", true);
            var FirstData = DateTime.MaxValue;
            if (eventpath == null)
            {
                eventpath = AppData.GetRandomPath();
                Registry.SetValue(localeEventPath, $"EventName", eventpath, true);
            }
            try
            {
                eventlists = JsonConvert.DeserializeObject<Model.UserData.TravelersDiary.EventName.Root>(await App.General.AppData.LoadFileData(eventpath));
            }
            catch (FileNotFoundException) { }
            catch (Exception)
            {
                throw;
            }
            eventlists??= new();
            string? path = null;
            for (int i = 1; i <= MAXPAGE; i++)
            {
                var data = await account.GetTravelersDiaryDetail((int)mode, i, month);
                if (i == 1)
                {
                    if (data.List.Count != 0)
                    {
                        var date = DateTime.Parse(data.List[0].Time);
                        var regPath = $"UserData\\{uid}\\Date\\{date.Year}\\{date.Month:00}\\";
                        path = Registry.GetValue(regPath, $"Latest{mode}Path", true);
                        if (path == null)
                        {
                            path = AppData.GetRandomPath();
                            Registry.SetValue(regPath, $"Latest{mode}Path", path, true);
                        }
                        try
                        {
                            lists = JsonConvert.DeserializeObject<Model.UserData.TravelersDiary.Lists.Root>(await App.General.AppData.LoadFileData(path));
                        }
                        catch (FileNotFoundException) { }
                        catch (Exception)
                        {
                            throw;
                        }
                        lists ??= new();
                        if (lists.Details.Count > 0)
                        {
                            lists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                            Latest = lists.Details[^1].EventTime;
                            LatestCount = lists.Details.FindAll(a => a.EventTime == Latest).Count;
                        }
                    }
                }
                if (data.List.Count == 0) IsEnd = true;
                foreach (var d in data.List)
                {
                    var time = DateTime.Parse(d.Time);
                    if (Latest <= time)
                    {
                        if (FirstData == DateTime.MaxValue) FirstData = time;
                        lists.Details.Add(new() { EventTime = time, EventType = d.Action_id, Count = d.Num });
                        if (eventlists.Events.Find(a => a.ID == d.Action_id) == null) eventlists.Events.Add(new() { ID = d.Action_id, Name = d.Action });
                    }
                    else IsEnd = true;
                }
                totalcount++;
                double progress = 0;
                if (data.List.Count > 0||lists.Details.Count>0)
                {
                    DateTime current;
                    if (data.List.Count > 0) current = DateTime.Parse(data.List[^1].Time);
                    else current = lists.Details[^1].EventTime;
                    var start = FirstData;//Dateは最後、データベースは最初
                    var end = Latest == DateTime.MinValue ? new DateTime(current.Year, current.Month, 1) : Latest;//Dateは最初、データベースは最後

                    double progress2 = 1.00 - ((current - end) / (start - end)) ;
                    if(progress2<0) progress2 = 0;
                    if (progress2 > 1) progress2 = 1;
                    progress = (progress2 / total + (double)position / total) * 100.0;
                }
                else
                {
                    progress = ((double)position / total) * 100.0;
                }
                ProgressChanged?.Invoke(null, new(progress,i,totalcount,$"{mode}",month));
                if (IsEnd || i == MAXPAGE)
                {
                    for (int r = 0; r < LatestCount && lists.Details.Count > 0; r++) lists.Details.RemoveAt(lists.Details.Count - 1);
                    lists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) App.General.AppData.SaveFileData(path, JsonConvert.SerializeObject(lists));
                    eventlists.Events.Sort((a,b)=>a.ID.CompareTo(b.ID));
                    if (eventpath != null) AppData.SaveFileData(eventpath, JsonConvert.SerializeObject(eventlists));
                    break;
                }
            }
        }



        public TravelersDiaryDetail(Account account) : base(account, 300000)
        {
            ServerUpdate.Tick += ServerUpdate_Tick;
        }

        private void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
            ServerUpdate.Start();
        }

    }
}
