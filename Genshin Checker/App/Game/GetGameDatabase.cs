using Genshin_Checker.App.Command.CommandList;
using Genshin_Checker.App.General;
using Genshin_Checker.App.General.Convert;
using Genshin_Checker.App.HoYoLab;
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
                Trace.WriteLine(ex);
                return false;
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
            DateTime Latest = DateTime.MinValue;
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
                localize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePath) ?? "");
            else Trace.WriteLine($"データベースは見つかりませんでした。");

            if (AppData.IsExistFile(localizePath))
                Enquipmentlocalize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePathEnquipment) ?? "");
            else Trace.WriteLine($"データベースは見つかりませんでした。");
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
                        Trace.WriteLine($"データベースのパスを取得しました。{year}/{month}({type}) : {path}");
                        if (AppData.IsExistFile(path))
                            eventLists = JsonChecker<Model.UserData.GameDatabase.Enquipment.Root>.Check(await App.General.AppData.LoadUserData(path) ?? "");
                        else Trace.WriteLine($"データベースは見つかりませんでした。");
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        Trace.WriteLine($"現在のレコード : {eventLists?.Details.Count} Latest:{Latest} LatestCount:{LatestCount}");
                        IsFirst = true;
                    }
                }
                eventLists ??= new();
                if (data.list.Count == 0) IsEnd = true; //データが空の場合は終了
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
                                Trace.WriteLine($"ローカライズのキューに追加しました。[{d.EventName},{latest}]");
                                LocaleQueue.Add(d.EventName, latest);
                            }
                        }

                        //ここにローカライズ処理(データに無かったらキューに追加)
                        if (!Enquipmentlocalize.Locale.ContainsKey(d.ItemName))
                        {//ここの条件をfalse固定にすることによって強制的にローカライズを再取得できる。
                            if (!LocaleQueueEnquipment.ContainsKey(d.ItemName))
                            {
                                Trace.WriteLine($"ローカライズのキューに追加しました。[{d.ItemName},{latest}]");
                                LocaleQueueEnquipment.Add(d.ItemName, latest);
                            }
                        }
                        eventLists.Details.Add(new() { EventTime = time, EventType = d.EventName, Count = int.Parse(d.NumItems.Replace("+", "")), ID = d.ID, EventTypeID = int.MinValue, Level = d.Level, Rarity = d.Rarity, Name = d.ItemName });
                    }
                    else IsEnd = true;
                    latest = long.Parse(d.ID);
                }
                //ToDo: ここに何か進捗を書く

                //終了処理
                if (IsEnd || i == MAXPAGE)
                {
                    Trace.WriteLine($"終了処理");
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) await App.General.AppData.SaveUserData(path, JsonConvert.SerializeObject(eventLists));
                    Trace.WriteLine($"セーブ完了 レコード数:{eventLists.Details.Count}");
                    break;
                }
                Trace.WriteLine($"ページ:{i} 取得完了。 レコード数:{eventLists.Details.Count}");
            }

            if (LocaleQueue.Count > 0)
            {
                Trace.WriteLine($"ローカライズのキューが残っている為調査します(対象 : {LocaleQueue.Count})");
                var langs = await HoYoLab.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                foreach (var l in LocaleQueue)
                {
                    Dictionary<string, string> lang = new();
                    Trace.WriteLine($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = type switch
                        {
                            DataType.Artifact => await GameAPI.GetArtifactLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.Weapon => await GameAPI.GetWeaponLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            _ => throw new InvalidDataException()
                        };
                        if (data.list.Count == 1) lang.Add(d.value, data.list[0].EventName);
                        else throw new InvalidDataException("No such data.");
                        Trace.WriteLine($"{d.value} : {data.list[0].EventName}");
                        //ここに進捗
                    }
                    Trace.WriteLine($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                Trace.WriteLine($"ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            if (LocaleQueueEnquipment.Count > 0)
            {
                Trace.WriteLine($"装備のローカライズのキューが残っている為調査します(対象 : {LocaleQueueEnquipment.Count})");
                var langs = await HoYoLab.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                foreach (var l in LocaleQueueEnquipment)
                {
                    Dictionary<string, string> lang = new();
                    Trace.WriteLine($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = type switch
                        {
                            DataType.Artifact => await GameAPI.GetArtifactLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.Weapon => await GameAPI.GetWeaponLog(authkey, size: 1, end_id: l.Value, begin: begin, end: end, culture: CultureInfo.GetCultureInfo(d.value)),
                            _ => throw new InvalidDataException()
                        };
                        if (data.list.Count == 1) lang.Add(d.value, data.list[0].ItemName);
                        else throw new InvalidDataException("No such data.");
                        Trace.WriteLine($"{d.value} : {data.list[0].ItemName}");
                        //ここに進捗
                    }
                    Trace.WriteLine($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                Trace.WriteLine($"装備ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            Trace.WriteLine($"Done!");
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
            DateTime Latest = DateTime.MinValue;
            int LatestCount = 0;
            bool IsFirst = false;
            bool IsEnd = false;
            DateTime FirstData = DateTime.MaxValue;
            Model.UserData.GameDatabase.MonthlyCard.Root? eventLists = null;

            Model.UserData.GameDatabase.NameLocalize.Root? localize = null;
            Dictionary<string, long> LocaleQueue = new();//注:longの値は実行する用のend_idです。
            if (AppData.IsExistFile(localizePath))
                localize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePath) ?? "");
            else Trace.WriteLine($"データベースは見つかりませんでした。");
            localize ??= new();
            for (int i = 1; i <= MAXPAGE; i++)
            {
                var data = await GameAPI.GetMonthlyCardLog(authkey, end_id: latest, begin: begin, end: end, culture: CultureInfo.GetCultureInfo("en-US"));

                if (i == 1)
                {
                    if (data.list.Count != 0)
                    {
                        path = GetPath($"{type}", year, month);
                        Trace.WriteLine($"データベースのパスを取得しました。{year}/{month}({type}) : {path}");
                        if (AppData.IsExistFile(path))
                            eventLists = JsonChecker<Model.UserData.GameDatabase.MonthlyCard.Root>.Check(await App.General.AppData.LoadUserData(path) ?? "");
                        else Trace.WriteLine($"データベースは見つかりませんでした。");
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        Trace.WriteLine($"現在のレコード : {eventLists?.Details.Count} Latest:{Latest} LatestCount:{LatestCount}");
                        IsFirst = true;
                    }
                }
                eventLists ??= new();
                if (data.list.Count == 0) IsEnd = true; //データが空の場合は終了
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
                                Trace.WriteLine($"ローカライズのキューに追加しました。[{d.EventName}]");
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
                    Trace.WriteLine($"終了処理");
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) await App.General.AppData.SaveUserData(path, JsonConvert.SerializeObject(eventLists));
                    Trace.WriteLine($"セーブ完了 レコード数:{eventLists.Details.Count}");
                    break;
                }
                Trace.WriteLine($"ページ:{i} 取得完了。 レコード数:{eventLists.Details.Count}");
            }

            if (LocaleQueue.Count > 0)
            {
                Trace.WriteLine($"ローカライズのキューが残っている為調査します(対象 : {LocaleQueue.Count})");
                var langs = await HoYoLab.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                foreach (var l in LocaleQueue)
                {
                    Dictionary<string, string> lang = new();
                    Trace.WriteLine($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = await GameAPI.GetMonthlyCardLog(authkey, size: 1, end_id: l.Value, culture: CultureInfo.GetCultureInfo(d.value));
                        if (data.list.Count == 1) lang.Add(d.value, data.list[0].EventName);
                        else throw new InvalidDataException("No such data.");
                        Trace.WriteLine($"{d.value} : {data.list[0].EventName}");
                        //ここに進捗
                    }
                    Trace.WriteLine($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                Trace.WriteLine($"ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            Trace.WriteLine($"Done!");
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
            DateTime Latest = DateTime.MinValue;
            int LatestCount = 0;
            bool IsFirst = false;
            bool IsEnd = false;
            DateTime FirstData = DateTime.MaxValue;
            Model.UserData.GameDatabase.ItemNum.Root? eventLists = null;

            Model.UserData.GameDatabase.NameLocalize.Root? localize = null;
            Dictionary<string, long> LocaleQueue = new();//注:longの値は実行する用のend_idです。
            if (AppData.IsExistFile(localizePath))
                localize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePath) ?? "");
            else Trace.WriteLine($"データベースは見つかりませんでした。");
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
                        Trace.WriteLine($"データベースのパスを取得しました。{year}/{month}({type}) : {path}");
                        if (AppData.IsExistFile(path))
                            eventLists = JsonChecker<Model.UserData.GameDatabase.ItemNum.Root>.Check(await App.General.AppData.LoadUserData(path) ?? "");
                        else Trace.WriteLine($"データベースは見つかりませんでした。");
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        Trace.WriteLine($"現在のレコード : {eventLists?.Details.Count} Latest:{Latest} LatestCount:{LatestCount}");
                        IsFirst = true;
                    }
                }
                eventLists ??= new();
                if (data.list.Count == 0) IsEnd = true; //データが空の場合は終了
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
                                Trace.WriteLine($"ローカライズのキューに追加しました。[{d.EventName}]");
                                LocaleQueue.Add(d.EventName, latest);
                            }
                        eventLists.Details.Add(new() { EventTime = time, EventType = d.EventName, Count = int.Parse(d.NumItems.Replace("+", "")), ID = d.ID, EventTypeID = int.MinValue });
                        latest = long.Parse(d.ID);
                    }
                    else IsEnd = true;
                }
                //ToDo: ここに何か進捗を書く

                //終了処理
                if (IsEnd || i == MAXPAGE)
                {
                    Trace.WriteLine($"終了処理");
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) await App.General.AppData.SaveUserData(path, JsonConvert.SerializeObject(eventLists));
                    Trace.WriteLine($"セーブ完了 レコード数:{eventLists.Details.Count}");
                    break;
                }
                Trace.WriteLine($"ページ:{i} 取得完了。 レコード数:{eventLists.Details.Count}");
            }

            if (LocaleQueue.Count > 0)
            {
                Trace.WriteLine($"ローカライズのキューが残っている為調査します(対象 : {LocaleQueue.Count})");
                var langs = await HoYoLab.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                foreach (var l in LocaleQueue)
                {
                    Dictionary<string, string> lang = new();
                    Trace.WriteLine($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = type switch
                        {
                            DataType.StarDust => await GameAPI.GetStardustLog(authkey, size: 1, end_id: l.Value, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.StarGlitter => await GameAPI.GetStarglitterLog(authkey, size: 1, end_id: l.Value, culture: CultureInfo.GetCultureInfo(d.value)),
                            _ => throw new InvalidDataException()
                        };
                        if (data.list.Count == 1) lang.Add(d.value, data.list[0].EventName);
                        else throw new InvalidDataException("No such data.");
                        Trace.WriteLine($"{d.value} : {data.list[0].EventName}");
                        //ここに進捗
                    }
                    Trace.WriteLine($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                Trace.WriteLine($"ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            Trace.WriteLine($"Done!");
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
            DateTime Latest = DateTime.MinValue;
            int LatestCount = 0;
            bool IsFirst = false;
            bool IsEnd = false;
            DateTime FirstData = DateTime.MaxValue;
            Model.UserData.GameDatabase.ItemNum.Root? eventLists = null;

            Model.UserData.GameDatabase.NameLocalize.Root? localize = null;
            Dictionary<string, long> LocaleQueue = new();//注:longの値は実行する用のend_idです。
            if (AppData.IsExistFile(localizePath))
                localize = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(localizePath) ?? "");
            else Trace.WriteLine($"データベースは見つかりませんでした。");
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
                        Trace.WriteLine($"データベースのパスを取得しました。{year}/{month}({type}) : {path}");
                        if (AppData.IsExistFile(path))
                            eventLists = JsonChecker<Model.UserData.GameDatabase.ItemNum.Root>.Check(await App.General.AppData.LoadUserData(path) ?? "");
                        else Trace.WriteLine($"データベースは見つかりませんでした。");
                        if (eventLists != null && eventLists.Details.Count > 0) //イベントリストの下準備
                        {
                            eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));      //リストを獲得時刻昇順に並び替え
                            Latest = eventLists.Details[^1].EventTime;                                  //最終の獲得時刻
                            LatestCount = eventLists.Details.FindAll(a => a.EventTime == Latest).Count; //同じ最終獲得時刻のイベント数
                        }
                        Trace.WriteLine($"現在のレコード : {eventLists?.Details.Count} Latest:{Latest} LatestCount:{LatestCount}");
                        IsFirst = true;
                    }
                }
                eventLists ??= new();
                if (data.list.Count == 0) IsEnd = true; //データが空の場合は終了
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
                                Trace.WriteLine($"ローカライズのキューに追加しました。[{d.EventName}]");
                                LocaleQueue.Add(d.EventName, latest);
                            }
                        eventLists.Details.Add(new() { EventTime = time, EventType = d.EventName, Count = int.Parse(d.NumItems.Replace("+", "")), ID = d.ID, EventTypeID = int.MinValue });
                        latest = long.Parse(d.ID);
                    }
                    else IsEnd = true;
                }
                //ToDo: ここに何か進捗を書く

                //終了処理
                if (IsEnd || i == MAXPAGE)
                {
                    Trace.WriteLine($"終了処理");
                    //重複があったものを削除
                    for (int r = 0; r < LatestCount && eventLists.Details.Count > 0; r++) eventLists.Details.RemoveAt(eventLists.Details.Count - 1);
                    eventLists.Details.Sort((a, b) => a.EventTime.CompareTo(b.EventTime));
                    if (path != null) await App.General.AppData.SaveUserData(path, JsonConvert.SerializeObject(eventLists));
                    Trace.WriteLine($"セーブ完了 レコード数:{eventLists.Details.Count}");
                    break;
                }
                Trace.WriteLine($"ページ:{i} 取得完了。 レコード数:{eventLists.Details.Count}");
            }

            if (LocaleQueue.Count > 0)
            {
                Trace.WriteLine($"ローカライズのキューが残っている為調査します(対象 : {LocaleQueue.Count})");
                var langs = await HoYoLab.LocalizeInfo.GetLanguages();
                if (langs.Data == null) throw new ArgumentNullException(nameof(langs.Data), "languages data is null");
                foreach (var l in LocaleQueue)
                {
                    Dictionary<string, string> lang = new();
                    Trace.WriteLine($"[{l.Key}] の調査");
                    foreach (var d in langs.Data.langs)
                    {
                        var data = type switch
                        {
                            DataType.Crystal => await GameAPI.GetCrystalLog(authkey, size: 1, end_id: l.Value, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.ExtraPrimogems => await GameAPI.GetPrimogemLog(authkey, size: 1, end_id: l.Value, culture: CultureInfo.GetCultureInfo(d.value)),
                            DataType.Resin => await GameAPI.GetResinLog(authkey, size: 1, end_id: l.Value, culture: CultureInfo.GetCultureInfo(d.value)),
                            _ => throw new InvalidDataException()
                        };
                        if (data.list.Count == 1) lang.Add(d.value, data.list[0].EventName);
                        else throw new InvalidDataException("No such data.");
                        Trace.WriteLine($"{d.value} : {data.list[0].EventName}");
                        //ここに進捗
                    }
                    Trace.WriteLine($"--------------------------------------------");
                    localize.Locale.Add(l.Key, lang);
                }
                if (path != null) await App.General.AppData.SaveUserData(localizePath, JsonConvert.SerializeObject(localize));
                Trace.WriteLine($"ローカライズセーブ完了 合計:{localize.Locale.Count}件");
            }
            Trace.WriteLine($"Done!");
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
        public async Task GetQueryFromDatabase(DataType type, int year, int month)
        {
            if (!IsAuthed) return;
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
            return;
            /*
              * 
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
            */
        }

    }
}
