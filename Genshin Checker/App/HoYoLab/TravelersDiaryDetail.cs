using Genshin_Checker.App.General;
using Genshin_Checker.Model.UserData.TravelersDiary.EventName;
using Genshin_Checker.Model.UserData.TravelersDiary.EventLists;
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
        const int MAXPAGE = 10000; //取得ページ数上限
        public class ProgressState
        {
            internal ProgressState(double progress, int current, int total, string mode, int month)
            {
                Progress = progress;
                CurrentPage = current;
                TotalPage = total;
                this.mode = mode;
                this.month = month;
            }
            public readonly double Progress;
            public readonly int CurrentPage;
            public readonly int TotalPage;
            public readonly string mode;
            public readonly int month;

        }
        /// <summary>進捗更新イベント</summary>
        public event EventHandler<ProgressState>? ProgressChanged;
        /// <summary>完了イベント</summary>
        public event EventHandler? ProgressCompreted;
        /// <summary>失敗イベント</summary>
        public event EventHandler<Exception>? ProgressFailed;
        /// <summary>取得モード</summary>
        public enum CorrectMode
        {
            /// <summary>原石</summary>
            Primogems,
            /// <summary>モラ</summary>
            Mora,
            /// <summary>全部</summary>
            All
        }
        /// <summary>
        /// API用
        /// </summary>
        enum Mode
        {
            Primogems = 1,
            Mora = 2,
        }


        int totalcount;
        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="months">月</param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public async Task Correct(List<int>? months = null, CorrectMode mode = CorrectMode.All)
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
            }
            catch (Exception ex)
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
        private async Task CorrectData(int month, Mode mode, int position = 0, int total = int.MaxValue)
        {
            DateTime Latest = DateTime.MinValue;    //最後の更新日
            int LatestCount = 0;                    //最後の更新の同時刻イベント数
            bool IsEnd = false;                     //取得終了フラグ
            EventLists? eventLists = null;          //イベント(通帳)のリスト
            EventName? eventNames = null;           //イベントの名前リスト  
            string localeEventPath = $"locale\\{account.Culture.Name.ToLower()}\\"; //レジストリに保存するローカライズテキスト保存場所
            var eventpath = Registry.GetValue(localeEventPath, $"EventName", true); //ローカライズデータのパス
            var FirstData = DateTime.MaxValue;      //最初のイベントの日時
            if (eventpath == null) //ローカライズデータが無い場合はパスの設定をする。
            {
                eventpath = AppData.GetRandomPath();
                Registry.SetValue(localeEventPath, $"EventName", eventpath, true);
            }
            try
            {
                eventNames = JsonConvert.DeserializeObject<EventName>(await AppData.LoadFileData(eventpath));
            }
            catch (FileNotFoundException) { } //ファイルが無い場合は放置
            catch (Exception)
            {
                throw;
            }
            eventNames ??= new(); //データがnullならインスタンス作成
            string? path = null; //通帳データが保存されている場所
            bool IsFirst = false;
            for (int i = 1; i <= MAXPAGE; i++)
            {
                //HoYoLab API呼び出し
                var data = await account.GetTravelersDiaryDetail((int)mode, i, month);
                if (i == 1) //最初の場合のみの処理、ここで詳細な日付の解析をする。
                {
                    if (data.List.Count != 0)
                    {
                        var date = DateTime.Parse(data.List[0].Time); //一番最初の日付の解析
                        var regPath = $"UserData\\{uid}\\Date\\{date.Year}\\{date.Month:00}\\"; //レジストリのパスの設定
                        path = Registry.GetValue(regPath, $"Latest{mode}Path", true); //レジストリからデータの所在地の呼び出し
                        if (path == null) //無いなら新しく作成
                        {
                            path = AppData.GetRandomPath();
                            Registry.SetValue(regPath, $"Latest{mode}Path", path, true);
                        }
                        try
                        {
                            eventLists = JsonConvert.DeserializeObject<EventLists>(await App.General.AppData.LoadFileData(path));
                        }
                        catch (FileNotFoundException) { }
                        catch (Exception)
                        {
                            throw;
                        }
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        IsFirst = true;
                    }
                }
                eventLists ??= new();
                if (data.List.Count == 0) IsEnd = true; //データが空の場合は終了

                //リストの追加処理
                foreach (var d in data.List)
                {
                    var time = DateTime.Parse(d.Time);
                    if (Latest <= time)
                    {
                        if (FirstData == DateTime.MaxValue) FirstData = time;
                        if (eventLists.Details.Count > 0 && eventLists.Details[^1].EventTime < time && !IsFirst) // 最初のみはリストの都合上除外する。
                            throw new InvalidDataException("前後データのイベント時刻が対立しています。API側データが更新された可能性があります。");
                        else IsFirst = false;
                        eventLists.Details.Add(new() { EventTime = time, EventType = d.Action_id, Count = d.Num });
                        if (eventNames.Events.Find(a => a.ID == d.Action_id) == null) eventNames.Events.Add(new() { ID = d.Action_id, Name = d.Action });
                    }
                    else IsEnd = true;
                }

                //進捗状況計算
                totalcount++;
                double progress = 0;
                if (data.List.Count > 0 || eventLists.Details.Count > 0)
                {
                    DateTime current;
                    if (data.List.Count > 0) current = DateTime.Parse(data.List[^1].Time);
                    else current = eventLists.Details[^1].EventTime;
                    var start = FirstData;//Dateは最後、データベースは最初
                    var end = Latest == DateTime.MinValue ? new DateTime(current.Year, current.Month, 1) : Latest;//Dateは最初、データベースは最後

                    double progress2 = 1.00 - ((current - end) / (start - end));
                    if (progress2 < 0) progress2 = 0;
                    if (progress2 > 1) progress2 = 1;
                    progress = (progress2 / total + (double)position / total) * 100.0;
                }
                else
                {
                    progress = ((double)position / total) * 100.0;
                }
                ProgressChanged?.Invoke(null, new(progress, i, totalcount, $"{mode}", month));

                //終了処理
                if (IsEnd || i == MAXPAGE)
                {
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) App.General.AppData.SaveFileData(path, JsonConvert.SerializeObject(eventLists));
                    eventNames.Events.Sort((a, b) => a.ID.CompareTo(b.ID));
                    if (eventpath != null) AppData.SaveFileData(eventpath, JsonConvert.SerializeObject(eventNames));
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
