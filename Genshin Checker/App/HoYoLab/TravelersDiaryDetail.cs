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
        int searchcount;
        public async Task Correct(List<int>? months=null, CorrectMode mode = CorrectMode.All)
        {
            totalcount = 0;
            searchcount = 0;
            months ??= new() { 0 }; //空だった場合は当月を取得
            int cnt = 0;
            foreach (var month in months)
            {
                if (mode == CorrectMode.All || mode == CorrectMode.Primogems)
                    await CorrectData(month, Mode.Primogems,100.0*cnt/months.Count);
                if (mode == CorrectMode.All || mode == CorrectMode.Mora)
                    await CorrectData(month, Mode.Mora,100.0*(cnt+(mode==CorrectMode.All?0.5:0))/months.Count);
                cnt++;
            }
            ProgressCompreted?.Invoke("", EventArgs.Empty);
        }
        /// <summary>
        /// 【内部関数】APIから詳細データの取得
        /// </summary>
        /// <param name="month">月のデータ(0であれば当月)</param>
        /// <param name="mode">取得モード</param>
        /// <returns></returns>
        private async Task CorrectData(int month, Mode mode, double progress=double.NaN)
        {
            DateTime Latest = DateTime.MinValue;
            bool IsEnd = false;
            var lists = new Model.UserData.TravelersDiary.Lists.Root();
            var eventlists = new Model.UserData.TravelersDiary.EventName.Root();
            var localeEventPath = $"locale\\{account.Culture.Name.ToLower()}\\";
            var eventpath = Registry.GetValue(localeEventPath, $"EventName", true);
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
                        }
                    }
                }
                if (data.List.Count == 0) IsEnd = true;
                foreach (var d in data.List)
                {
                    var time = DateTime.Parse(d.Time);
                    if (Latest < time)
                    {
                        lists.Details.Add(new() { EventTime = time, EventType = d.Action_id, Count = d.Num });
                        if (eventlists.Events.Find(a => a.ID == d.Action_id) == null) eventlists.Events.Add(new() { ID = d.Action_id, Name = d.Action });
                    }
                    else IsEnd = true;
                }
                totalcount++;
                ProgressChanged?.Invoke(null, new(progress,i,totalcount,$"{mode}",month));
                if (IsEnd || i == MAXPAGE)
                {
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
