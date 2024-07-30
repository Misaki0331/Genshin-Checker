using Genshin_Checker.App.Command.CommandList;
using Genshin_Checker.App.General;
using Genshin_Checker.App.General.Convert;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.UI.GameRecords.Exploration;
using Genshin_Checker.Model.UserData.TravelersDiary.EventLists;
using Genshin_Checker.Model.UserData.TravelersDiary.EventName;
using Genshin_Checker.resource.Languages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Genshin_Checker.Window.ProgressWindow.LoadTravelersDiaryDetail;

namespace Genshin_Checker.App.Game
{
    public class GetGameDatabase
    {
        const int MAXPAGE = 5000000; //取得ページ数上限
        public class ProgressState
        {
            internal ProgressState() { }
            public double Progress=0.0;
            public int CompletedTask=0;
            public int MaxTask=0;
            public string mode="";
            public int year=0;
            public int month=0;

        }
        /// <summary>進捗更新イベント</summary>
        public event EventHandler<ProgressState>? ProgressChanged;
        /// <summary>完了イベント</summary>
        public event EventHandler? ProgressCompreted;
        /// <summary>失敗イベント</summary>
        public event EventHandler<Exception>? ProgressFailed;

        string authkey = "";
        public int uid { get; private set; }
        public Account.Servers? server { get; private set; }
        public string username { get; private set; } = "";
        public bool IsAuthed { get; private set; } = false;
        public GetGameDatabase(string authkey)
        {
            this.authkey = authkey;
        }
        public enum DataType
        {
            MonthlyCard,
            Crystal,
            ExtraPrimogems,
            Resin,
            StarDust,
            StarGlitter,
            Artifact,
            Weapon
        };
        public async Task<bool> Init()
        {
            try
            {
                var data = await App.Game.GameAPI.GetAccountInfo(authkey);
                uid = data.uid;
                username = data.nickname;
                if (Enum.TryParse(typeof(Account.Servers), data.region, out var server) && server != null)
                    this.server = (Account.Servers)server;
                else throw new InvalidDataException($"Invalid server name. {data.region}");
                IsAuthed = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
            return true;
        }

        #region 武器・聖遺物
        private async Task GetEquipmentList(DataType type, int year, int month)
        {
            DateTime begin = new(year, month, 1, 0, 0, 0);
            DateTime end = new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1);
            string? path = null;
            string localizePath = GetLocalizePath("GameDatabaseEventName");
            string localizePathEnquipment = GetLocalizePath("GameDatabaseEnquipment");
            long latest = 0;
            DateTime Latest = begin;
            DateTime Start = end;
            int LatestCount = 0;
            bool IsFirst = false;
            bool IsEnd = false;
            DateTime FirstData = DateTime.MaxValue;
            Model.UserData.GameDatabase.Enquipment.Root? eventLists = null;
            Model.UserData.GameDatabase.NameLocalize.Root? localize = null;
            Model.UserData.GameDatabase.NameLocalize.Root? Enquipmentlocalize = null;
            Dictionary<string, long> LocaleQueue = new();//注:longの値は実行する用のend_idです。
            Dictionary<string, long> LocaleQueueEnquipment = new();//注:longの値は実行する用のend_idです。
            if (AppData.IsExistFile(localizePath))
                localize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePath) ?? "{}");
            else Log.Debug($"データベースは見つかりませんでした。");

            if (AppData.IsExistFile(localizePathEnquipment))
                Enquipmentlocalize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePathEnquipment) ?? "{}");
            else Log.Debug($"データベースは見つかりませんでした。");
            localize ??= new();
            Enquipmentlocalize ??= new();
            for (int i = 1; i <= MAXPAGE; i++)
            {
                var data = type switch
                {
                    DataType.Artifact => await GameAPI.GetArtifactLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US")),
                    DataType.Weapon => await GameAPI.GetWeaponLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US")),
                    _ => throw new InvalidDataException()
                };
                if (i == 1)
                {
                    if (data.list.Count != 0)
                    {
                        path = GetPath($"{type}", year, month);
                        Log.Debug($"データベースのパスを取得しました。{year}/{month}({type}) : {path}");
                        if (AppData.IsExistFile(path))
                            eventLists = JsonChecker<Model.UserData.GameDatabase.Enquipment.Root>.Check(await App.General.AppData.LoadUserData(path) ?? "{}");
                        else Log.Debug($"データベースは見つかりませんでした。");
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        Log.Debug($"現在のレコード : {eventLists?.Details.Count} Latest:{Latest} LatestCount:{LatestCount}");
                        IsFirst = true;
                        Start = DateTime.Parse(data.list[0].EventTime);
                    }
                }
                eventLists ??= new();
                if (data.list.Count == 0) IsEnd = true; //データが空の場合は終了
                else ReportProgress(0, 3, GetProgressValue(Start, Latest, DateTime.Parse(data.list[^1].EventTime)), type, year, month);
                foreach (var d in data.list)
                {
                    var time = DateTime.Parse(d.EventTime);
                    if (Latest <= time)
                    {
                        if (FirstData == DateTime.MaxValue) FirstData = time;
                        //ロード中データに更新が入ったかチェック
                        if (eventLists.Details.Count > 0 && eventLists.Details[^1].EventTime < time && !IsFirst) // 最初のみはリストの都合上除外する。
                            throw new InvalidDataException(Localize.Error_TravelersDiaryDetail_Conflict);
                        else IsFirst = false;

                        //ここにローカライズ処理(データに無かったらキューに追加)
                        if (!localize.Locale.ContainsKey(d.EventName))
                        {//ここの条件をfalse固定にすることによって強制的にローカライズを再取得できる。
                            if (!LocaleQueue.ContainsKey(d.EventName))
                            {
                                Log.Debug($"ローカライズのキューに追加しました。[{d.EventName},{latest}]");
                                LocaleQueue.Add(d.EventName, latest);
                            }
                        }

                        //ここにローカライズ処理(データに無かったらキューに追加)
                        if (!Enquipmentlocalize.Locale.ContainsKey(d.ItemName))
                        {//ここの条件をfalse固定にすることによって強制的にローカライズを再取得できる。
                            if (!LocaleQueueEnquipment.ContainsKey(d.ItemName))
                            {
                                Log.Debug($"ローカライズのキューに追加しました。[{d.ItemName},{latest}]");
                                LocaleQueueEnquipment.Add(d.ItemName, latest);
                            }
                        }
                        eventLists.Details.Add(new() { EventTime = time, EventType = d.EventName, Count = int.Parse(d.NumItems.Replace("+", "")), ID = d.ID, EventTypeID = GameDataStringToEventID.GetIDFromString(d.EventName), Level = d.Level, Rarity = d.Rarity, Name = d.ItemName });
                    }
                    else IsEnd = true;
                    latest = long.Parse(d.ID);
                }
                //ToDo: ここに何か進捗を書く

                //終了処理
                if (IsEnd || i == MAXPAGE)
                {
                    Log.Debug($"終了処理");
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) await App.General.AppData.SaveUserData(path, JsonConvert.SerializeObject(eventLists));
                    Log.Debug($"セーブ完了 レコード数:{eventLists.Details.Count}");
                    break;
                }
                Log.Debug($"ページ:{i} 取得完了。 レコード数:{eventLists.Details.Count}");
            }

            if (LocaleQueue.Count > 0)
            {
                Log.Debug($"ローカライズのキューが残っている為調査します(対象 : {LocaleQueue.Count})");
                var langs = await HoYoLab.Static.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                int cnt = 0;
                foreach (var l in LocaleQueue)
                {
                    Dictionary<string, string> lang = new();
                    Log.Debug($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = type switch
                        {
                            DataType.Artifact => await GameAPI.GetArtifactLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.Weapon => await GameAPI.GetWeaponLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            _ => throw new InvalidDataException()
                        };
                        if (data.list.Count >= 1) lang.Add(d.value, data.list[0].EventName);
                        else throw new InvalidDataException("No such data.");
                        Log.Debug($"{d.value} : {data.list[0].EventName}");
                        //ここに進捗
                        ReportProgress(1, 3, (double)(cnt * langs.Data.langs.Count + lang.Count) / (LocaleQueue.Count * langs.Data.langs.Count), type, year, month);
                    }
                    Log.Debug($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                    cnt++;
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                Log.Debug($"ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            if (LocaleQueueEnquipment.Count > 0)
            {
                Log.Debug($"装備のローカライズのキューが残っている為調査します(対象 : {LocaleQueueEnquipment.Count})");
                var langs = await HoYoLab.Static.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                int cnt = 0;
                foreach (var l in LocaleQueueEnquipment)
                {
                    Dictionary<string, string> lang = new();
                    Log.Debug($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = type switch
                        {
                            DataType.Artifact => await GameAPI.GetArtifactLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.Weapon => await GameAPI.GetWeaponLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            _ => throw new InvalidDataException()
                        };
                        if (data.list.Count >= 1) lang.Add(d.value, data.list[0].ItemName);
                        else throw new InvalidDataException("No such data.");
                        Log.Debug($"{d.value} : {data.list[0].ItemName}");
                        //ここに進捗
                        ReportProgress(2, 3, (double)(cnt * langs.Data.langs.Count + lang.Count) / (LocaleQueueEnquipment.Count * langs.Data.langs.Count), type, year, month);
                    }
                    Log.Debug($"--------------------------------------------");
                    Enquipmentlocalize.Locale.Add(l.Key, lang);
                    cnt++;
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePathEnquipment, JsonConvert.SerializeObject(Enquipmentlocalize));
                Log.Debug($"装備ローカライズセーブ完了 合計:{Enquipmentlocalize.Locale.Count}件");
            }
            Log.Debug($"Done!");
            return;
        }
        #endregion
        #region 星空の祝福
        private async Task GetMonthCardList(DataType type, int year, int month)
        {
            DateTime begin = new(year, month, 1, 0, 0, 0);
            DateTime end = new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1);
            string? path = null;
            string localizePath = GetLocalizePath("GameDatabaseEventName");
            long latest = 0;
            DateTime Latest = begin;
            DateTime Start = end;
            int LatestCount = 0;
            bool IsFirst = false;
            bool IsEnd = false;
            DateTime FirstData = DateTime.MaxValue;
            Model.UserData.GameDatabase.MonthlyCard.Root? eventLists = null;

            Model.UserData.GameDatabase.NameLocalize.Root? localize = null;
            Dictionary<string, long> LocaleQueue = new();//注:longの値は実行する用のend_idです。
            if (AppData.IsExistFile(localizePath))
                localize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePath) ?? "{}");
            else Log.Debug($"データベースは見つかりませんでした。");
            localize ??= new();
            for (int i = 1; i <= MAXPAGE; i++)
            {
                var data = await GameAPI.GetMonthlyCardLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US"));

                if (i == 1)
                {
                    if (data.list.Count != 0)
                    {
                        path = GetPath($"{type}", year, month);
                        Log.Debug($"データベースのパスを取得しました。{year}/{month}({type}) : {path}");
                        if (AppData.IsExistFile(path))
                            eventLists = JsonChecker<Model.UserData.GameDatabase.MonthlyCard.Root>.Check(await App.General.AppData.LoadUserData(path) ?? "{}");
                        else Log.Debug($"データベースは見つかりませんでした。");
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        Log.Debug($"現在のレコード : {eventLists?.Details.Count} Latest:{Latest} LatestCount:{LatestCount}");
                        IsFirst = true;
                        Start = DateTime.Parse(data.list[0].EventTime);
                    }
                }
                eventLists ??= new();
                if (data.list.Count == 0) IsEnd = true; //データが空の場合は終了
                else ReportProgress(0, 2, GetProgressValue(Start, Latest, DateTime.Parse(data.list[^1].EventTime)), type, year, month);
                foreach (var d in data.list)
                {
                    var time = DateTime.Parse(d.EventTime);
                    if (Latest <= time)
                    {
                        if (FirstData == DateTime.MaxValue) FirstData = time;
                        //ロード中データに更新が入ったかチェック
                        if (eventLists.Details.Count > 0 && eventLists.Details[^1].EventTime < time && !IsFirst) // 最初のみはリストの都合上除外する。
                            throw new InvalidDataException(Localize.Error_TravelersDiaryDetail_Conflict);
                        else IsFirst = false;

                        //ここにローカライズ処理(データに無かったらキューに追加)
                        if (!localize.Locale.ContainsKey(d.EventName))//ここの条件をfalse固定にすることによって強制的にローカライズを再取得できる。
                            if (!LocaleQueue.ContainsKey(d.EventName))
                            {
                                Log.Debug($"ローカライズのキューに追加しました。[{d.EventName}]");
                                LocaleQueue.Add(d.EventName, latest);
                            }
                        eventLists.Details.Add(new() { EventTime = time, EventType = d.EventName, ID = d.ID, EventTypeID = d.EventType });
                        latest = long.Parse(d.ID);
                    }
                    else IsEnd = true;
                }
                //ToDo: ここに何か進捗を書く

                //終了処理
                if (IsEnd || i == MAXPAGE)
                {
                    Log.Debug($"終了処理");
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) await App.General.AppData.SaveUserData(path, JsonConvert.SerializeObject(eventLists));
                    Log.Debug($"セーブ完了 レコード数:{eventLists.Details.Count}");
                    break;
                }
                Log.Debug($"ページ:{i} 取得完了。 レコード数:{eventLists.Details.Count}");
            }

            if (LocaleQueue.Count > 0)
            {
                Log.Debug($"ローカライズのキューが残っている為調査します(対象 : {LocaleQueue.Count})");
                var langs = await HoYoLab.Static.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                int cnt = 0;
                foreach (var l in LocaleQueue)
                {
                    Dictionary<string, string> lang = new();
                    Log.Debug($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = await GameAPI.GetMonthlyCardLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value));
                        if (data.list.Count >= 1) lang.Add(d.value, data.list[0].EventName);
                        else throw new InvalidDataException("No such data.");
                        Log.Debug($"{d.value} : {data.list[0].EventName}");
                        //ここに進捗
                        ReportProgress(1, 2, (double)(cnt * langs.Data.langs.Count + lang.Count) / (LocaleQueue.Count * langs.Data.langs.Count), type, year, month);
                    }
                    Log.Debug($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                    cnt++;
                }
                if (path != null)
                {
                    await AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                }
                Log.Debug($"ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            Log.Debug($"Done!");
            return;
        }
        #endregion
        #region スターライト・スターダスト
        private async Task GetStarList(DataType type, int year, int month)
        {
            DateTime begin = new(year, month, 1, 0, 0, 0);
            DateTime end = new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1);
            string? path = null;
            string localizePath = GetLocalizePath("GameDatabaseEventName");
            long latest = 0;
            DateTime Latest = begin;
            DateTime Start = end;
            int LatestCount = 0;
            bool IsFirst = false;
            bool IsEnd = false;
            DateTime FirstData = DateTime.MaxValue;
            Model.UserData.GameDatabase.ItemNum.Root? eventLists = null;

            Model.UserData.GameDatabase.NameLocalize.Root? localize = null;
            Dictionary<string, long> LocaleQueue = new();//注:longの値は実行する用のend_idです。
            if (AppData.IsExistFile(localizePath))
                localize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePath) ?? "{}");
            else Log.Debug($"データベースは見つかりませんでした。");
            localize ??= new();
            for (int i = 1; i <= MAXPAGE; i++)
            {
                var data = type switch
                {
                    DataType.StarDust => await GameAPI.GetStardustLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US")),
                    DataType.StarGlitter => await GameAPI.GetStarglitterLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US")),
                    _ => throw new InvalidDataException()
                };
                if (i == 1)
                {
                    if (data.list.Count != 0)
                    {
                        path = GetPath($"{type}", year, month);
                        Log.Debug($"データベースのパスを取得しました。{year}/{month}({type}) : {path}");
                        if (AppData.IsExistFile(path))
                            eventLists = JsonChecker<Model.UserData.GameDatabase.ItemNum.Root>.Check(await App.General.AppData.LoadUserData(path) ?? "{}");
                        else Log.Debug($"データベースは見つかりませんでした。");
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        Log.Debug($"現在のレコード : {eventLists?.Details.Count} Latest:{Latest} LatestCount:{LatestCount}");
                        IsFirst = true;
                        Start = DateTime.Parse(data.list[0].EventTime);
                    }
                }
                eventLists ??= new();
                if (data.list.Count == 0) IsEnd = true; //データが空の場合は終了
                else ReportProgress(0, 2, GetProgressValue(Start, Latest, DateTime.Parse(data.list[^1].EventTime)), type, year, month);
                foreach (var d in data.list)
                {
                    var time = DateTime.Parse(d.EventTime);
                    if (Latest <= time)
                    {
                        if (FirstData == DateTime.MaxValue) FirstData = time;
                        //ロード中データに更新が入ったかチェック
                        if (eventLists.Details.Count > 0 && eventLists.Details[^1].EventTime < time && !IsFirst) // 最初のみはリストの都合上除外する。
                            throw new InvalidDataException(Localize.Error_TravelersDiaryDetail_Conflict);
                        else IsFirst = false;

                        //ここにローカライズ処理(データに無かったらキューに追加)
                        if (!localize.Locale.ContainsKey(d.EventName))//ここの条件をfalse固定にすることによって強制的にローカライズを再取得できる。
                            if (!LocaleQueue.ContainsKey(d.EventName))
                            {
                                Log.Debug($"ローカライズのキューに追加しました。[{d.EventName}]");
                                LocaleQueue.Add(d.EventName, latest);
                            }
                        eventLists.Details.Add(new() { EventTime = time, EventType = d.EventName, Count = int.Parse(d.NumItems.Replace("+", "")), ID = d.ID, EventTypeID = GameDataStringToEventID.GetIDFromString(d.EventName) });
                        latest = long.Parse(d.ID);
                    }
                    else IsEnd = true;
                }
                //ToDo: ここに何か進捗を書く

                //終了処理
                if (IsEnd || i == MAXPAGE)
                {
                    Log.Debug($"終了処理");
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) await App.General.AppData.SaveUserData(path, JsonConvert.SerializeObject(eventLists));
                    Log.Debug($"セーブ完了 レコード数:{eventLists.Details.Count}");
                    break;
                }
                Log.Debug($"ページ:{i} 取得完了。 レコード数:{eventLists.Details.Count}");
            }

            if (LocaleQueue.Count > 0)
            {
                Log.Debug($"ローカライズのキューが残っている為調査します(対象 : {LocaleQueue.Count})");
                var langs = await HoYoLab.Static.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                int cnt = 0;
                foreach (var l in LocaleQueue)
                {
                    Dictionary<string, string> lang = new();
                    Log.Debug($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = type switch
                        {
                            DataType.StarDust => await GameAPI.GetStardustLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.StarGlitter => await GameAPI.GetStarglitterLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            _ => throw new InvalidDataException()
                        };
                        if (data.list.Count >= 1) lang.Add(d.value, data.list[0].EventName);
                        else throw new InvalidDataException("No such data.");
                        Log.Debug($"{d.value} : {data.list[0].EventName}");
                        //ここに進捗
                        ReportProgress(1, 2, (double)(cnt * langs.Data.langs.Count + lang.Count) / (LocaleQueue.Count * langs.Data.langs.Count), type, year, month);
                    }
                    if (lang.TryGetValue("en-us",out var locale))
                    {
                        if (locale != l.Key)
                        {
                            Log.Debug($"<!>Warning<!> 翻訳先が違います！！！\n{l.Key} => {locale}");
                        }
                    }
                    else
                    {
                        Log.Debug($"<!>Warning<!> 翻訳がありません！！！\n{l.Key} => null");
                    }
                    Log.Debug($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                    cnt++;
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                Log.Debug($"ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            Log.Debug($"Done!");
            return;
        }
        #endregion
        #region 原石・創生結晶・消費樹脂
        private async Task GetItemList(DataType type, int year, int month)
        {
            DateTime begin = new(year, month, 1, 0, 0, 0);
            DateTime end = new DateTime(year, month, 1).AddMonths(1).AddSeconds(-1);
            string? path = null;
            string localizePath = GetLocalizePath("GameDatabaseEventName");
            long latest = 0;
            DateTime Latest = begin;
            DateTime Start = end;
            int LatestCount = 0;
            bool IsFirst = false;
            bool IsEnd = false;
            DateTime FirstData = DateTime.MaxValue;
            Model.UserData.GameDatabase.ItemNum.Root? eventLists = null;

            Model.UserData.GameDatabase.NameLocalize.Root? localize = null;
            Dictionary<string, long> LocaleQueue = new();//注:longの値は実行する用のend_idです。
            if (AppData.IsExistFile(localizePath))
                localize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePath) ?? "{}");
            else Log.Debug($"データベースは見つかりませんでした。");
            localize ??= new();
            for (int i = 1; i <= MAXPAGE; i++)
            {
                var data = type switch
                {
                    DataType.Crystal => await GameAPI.GetCrystalLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US")),
                    DataType.ExtraPrimogems => await GameAPI.GetPrimogemLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US")),
                    DataType.Resin => await GameAPI.GetResinLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US")),
                    _ => throw new InvalidDataException()
                };
                if (i == 1)
                {
                    if (data.list.Count != 0)
                    {
                        path = GetPath($"{type}", year, month);
                        Log.Debug($"データベースのパスを取得しました。{year}/{month}({type}) : {path}");
                        if (AppData.IsExistFile(path))
                            eventLists = JsonChecker<Model.UserData.GameDatabase.ItemNum.Root>.Check(await App.General.AppData.LoadUserData(path) ?? "{}");
                        else Log.Debug($"データベースは見つかりませんでした。");
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        Log.Debug($"現在のレコード : {eventLists?.Details.Count} Latest:{Latest} LatestCount:{LatestCount}");
                        IsFirst = true;
                        Start = DateTime.Parse(data.list[0].EventTime);
                    }
                }
                eventLists ??= new();
                if (data.list.Count == 0) IsEnd = true; //データが空の場合は終了
                else ReportProgress(0, 2, GetProgressValue(Start, Latest, DateTime.Parse(data.list[^1].EventTime)), type, year, month);
                foreach (var d in data.list)
                {
                    var time = DateTime.Parse(d.EventTime);
                    if (Latest <= time)
                    {
                        if (FirstData == DateTime.MaxValue) FirstData = time;
                        //ロード中データに更新が入ったかチェック
                        if (eventLists.Details.Count > 0 && eventLists.Details[^1].EventTime < time && !IsFirst) // 最初のみはリストの都合上除外する。
                            throw new InvalidDataException(Localize.Error_TravelersDiaryDetail_Conflict);
                        else IsFirst = false;

                        //ここにローカライズ処理(データに無かったらキューに追加)
                        if (!localize.Locale.ContainsKey(d.EventName))//ここの条件をfalse固定にすることによって強制的にローカライズを再取得できる。
                            if (!LocaleQueue.ContainsKey(d.EventName))
                            {
                                Log.Debug($"ローカライズのキューに追加しました。[{d.EventName}]");
                                LocaleQueue.Add(d.EventName, latest);
                            }
                        eventLists.Details.Add(new() { EventTime = time, EventType = d.EventName, Count = int.Parse(d.NumItems.Replace("+", "")), ID = d.ID, EventTypeID = GameDataStringToEventID.GetIDFromString(d.EventName) });
                        latest = long.Parse(d.ID);
                    }
                    else IsEnd = true;
                }
                //ToDo: ここに何か進捗を書く

                //終了処理
                if (IsEnd || i == MAXPAGE)
                {
                    Log.Debug($"終了処理");
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) await App.General.AppData.SaveUserData(path, JsonConvert.SerializeObject(eventLists));
                    Log.Debug($"セーブ完了 レコード数:{eventLists.Details.Count}");
                    break;
                }
                Log.Debug($"ページ:{i} 取得完了。 レコード数:{eventLists.Details.Count}");
            }

            if (LocaleQueue.Count > 0)
            {
                Log.Debug($"ローカライズのキューが残っている為調査します(対象 : {LocaleQueue.Count})");
                var langs = await HoYoLab.Static.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                int cnt = 0;
                foreach (var l in LocaleQueue)
                {
                    Dictionary<string, string> lang = new();
                    Log.Debug($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = type switch
                        {
                            DataType.Crystal => await GameAPI.GetCrystalLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.ExtraPrimogems => await GameAPI.GetPrimogemLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.Resin => await GameAPI.GetResinLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            _ => throw new InvalidDataException()
                        };
                        if (data.list.Count >= 1) lang.Add(d.value, data.list[0].EventName);
                        else throw new InvalidDataException("No such data.");
                        Log.Debug($"{d.value} : {data.list[0].EventName}");
                        //ここに進捗
                        ReportProgress(1, 2, (double)(cnt*langs.Data.langs.Count+lang.Count)/(LocaleQueue.Count*langs.Data.langs.Count) , type, year, month);
                    }
                    Log.Debug($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                    cnt++;
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                Log.Debug($"ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            Log.Debug($"Done!");
            return;
        }
        #endregion
        private string GetPath(string mode, int year, int month)
        {
            var regPath = $"UserData\\{uid}\\Date\\{year}\\{month:00}\\"; //レジストリのパスの設定
            var path = Registry.GetValue(regPath, $"Latest{mode}Path", true); //レジストリからデータの所在地の呼び出し
            if (path == null) //無いなら新しく作成
            {
                path = Path.GetFileName(AppData.GetRandomPath());
                Registry.SetValue(regPath, $"Latest{mode}Path", path, true);
            }
            else if (Path.IsPathRooted(path)) Registry.SetValue(regPath, $"Latest{mode}Path", Path.GetFileName(path), true);
            return path;
        }
        private string GetLocalizePath(string key)
        {
            var path = Registry.GetValue("locale\\", key, true); //レジストリからデータの所在地の呼び出し
            if (path == null) //無いなら新しく作成
            {
                path = Path.GetFileName(AppData.GetRandomPath());
                Registry.SetValue("locale\\", key, path, true);
            }
            else if (Path.IsPathRooted(path)) Registry.SetValue("locale\\", key, Path.GetFileName(path), true);
            return path;
        }
        private double GetProgressValue(DateTime start, DateTime end,DateTime current)
        {
            double progress2 = 1.00 - ((current - end) / (start - end));
            if (progress2 < 0) progress2 = 0;
            if (progress2 > 1) progress2 = 1;
            return progress2;
        }
        private void ReportProgress(int CompletedStep, int MaxStep, double Current,DataType type, int year, int month)
        {
            ProgressChanged?.Invoke(null, new() { Progress = Current, mode = $"{type}", CompletedTask = CompletedStep, MaxTask = MaxStep, year = year, month = month });
        }
        public async Task GetQueryFromDatabase(DataType type, int year, int month)
        {
            if (!IsAuthed) return;
            try
            {
                switch (type)
                {
                    case DataType.MonthlyCard:
                        await GetMonthCardList(type, year, month);
                        break;
                    case DataType.Crystal:
                    case DataType.ExtraPrimogems:
                    case DataType.Resin:
                        await GetItemList(type, year, month);
                        break;
                    case DataType.StarDust:
                    case DataType.StarGlitter:
                        await GetStarList(type, year, month);
                        break;
                    case DataType.Artifact:
                    case DataType.Weapon:
                        await GetEquipmentList(type, year, month);
                        break;
                }
            }catch(Exception ex)
            {
                ProgressFailed?.Invoke(null, ex);
                return;
            }

            ProgressCompreted?.Invoke(null,EventArgs.Empty);
            return;
        }

    }
}
