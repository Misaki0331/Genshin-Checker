using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Genshin_Checker.App.HoYoLab
{
    public class Account
    {
        public bool IsDisposed { get; set; } = false;
        public RealTimeNote RealTimeNote;
        public TravelersDiary TravelersDiary;
        public EnkaNetwork.EnkaNetwork EnkaNetwork;
        public TravelersDiaryDetail TravelersDiaryDetail;
        public GameRecords GameRecords;
        public static async Task<Account> GetInstance(string cookie, int UID)
        {
            var account = new Account();
            try
            {
                account.Server = GetServer(UID);
                account.RawCookie = cookie;
                account._uid = UID;
                await account.CheckUID(UID);
                return account;
            }
            catch (Exception)
            {
                account.Dispose();
                throw;
            }
        }
        private Account()
        {

            RealTimeNote = new(this);
            TravelersDiary = new(this);
            EnkaNetwork = new(this);
            TravelersDiaryDetail = new(this);
            GameRecords = new(this);
            Culture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// UIDからサーバー名取得
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private static Servers GetServer(int uid)
        {
            return uid.ToString()[..1] switch
            {
                "6" => Servers.os_usa,
                "7" => Servers.os_euro,
                "8" => Servers.os_asia,
                "9" => Servers.os_cht,
                _ => throw new InvalidDataException("unknown uid"),
            };
        }
        /// <summary>
        /// サーバー所在名称
        /// </summary>
        public enum Servers
        {
            /// <summary> America Server </summary>
            os_usa,
            /// <summary> Europe Server </summary>
            os_euro,
            /// <summary> Asia Server </summary>
            os_asia,
            /// <summary> TW, HK, MO Server </summary>
            os_cht
        }
        /// <summary>
        /// HoYoLab APIタイプ
        /// </summary>
        public enum API
        {
            /// <summary>
            /// サーバー毎のアカウント情報<br/>
            /// 仕様 : <c>Model.HoYoLab.Account.cs</c>
            /// </summary>
            Account,
            /// <summary>
            /// 探索情報、累計ログイン日数等<br/>
            /// 仕様 : <c>Model.HoYoLab.GameRecords.cs</c>
            /// </summary>
            GameRecords,
            /// <summary>
            /// キャラクター育成状況<br/>
            /// 仕様 : <c>Model.HoYoLab.Characters.cs</c>
            /// </summary>
            Characters,
            /// <summary>
            /// 深境螺旋進捗状況<br/>
            /// 仕様 : <c>Model.HoYoLab.SpiralAbyss.cs</c>
            /// </summary>
            SpiralAbyss,
            /// <summary>
            /// 現在の樹脂状況等が含まれたリアルタイムノート<br/>
            /// 仕様 : <c>Model.HoYoLab.RealTimeNote.cs</c>
            /// </summary>
            RealTimeNotes,
            /// <summary>
            /// 旅人手帳の詳細な入手履歴<br/>
            /// 仕様 : <c>Model.HoYoLab.TravelersDiaryDetail.cs</c>
            /// </summary>
            TravelersDiaryDetail,
            /// <summary>
            /// 旅人手帳の概要<br/>
            /// 仕様 : <c>Model.HoYoLab.TravelersDiaryInfo.cs</c>
            /// </summary>
            TravelersDiaryInfo
        }
        private string RawCookie { get; set; } = "";
        /// <summary>
        /// HoYoLabログイン済のクッキー
        /// </summary>
        public string Cookie
        {
            get { var split = RawCookie.Split(';');
                for (int i = 0; i < split.Length; i++)
                {
                    split[i] = split[i].Trim();
                    if (split[i].StartsWith("mi18nLang=")) split[i] = $"mi18nLang={Culture.Name.ToLower()}";
                }
                return String.Join("; ", split);
            }
            set { RawCookie = value; }
        }
        /// <summary>
        /// サーバー名
        /// </summary>
        public Servers Server { get; set; }
        public CultureInfo Culture { get; set; }
        /// <summary>
        /// 【内部関数】直接編集しない事。
        /// ゲームアカウント
        /// </summary>
        private int _uid = int.MinValue;
        ///
        public bool IsAuthed { get; private set; } = false;

        /// <summary>
        /// ユーザーのゲーム内アカウントID(UID)
        /// </summary>
        public int UID { get => _uid; set => CheckUID(value); }
        /// <summary>
        /// ユーザーのゲーム内アカウント名
        /// </summary>
        public string Name { get; private set; } = string.Empty;
        /// <summary>
        /// ユーザーのゲーム内冒険ランク
        /// </summary>
        public int Level { get; private set; } = -1;
        /// <summary>
        /// アカウント整合性の確認
        /// </summary>
        /// <param name="uid"></param>
        private async Task<bool> CheckUID(int uid)
        {
            var res = await GetServerAccounts(GetServer(uid));
            foreach (var user in res.list)
            {
                if (int.Parse(user.game_uid) == uid)
                {
                    Name = user.nickname;
                    Level = user.level;
                    _uid = uid;
                    IsAuthed = true;
                    return true;
                }
            }
            throw new UserNotFoundException(uid);
        }
        public void Dispose()
        {
            IsDisposed = true;
            RealTimeNote.Dispose();
            TravelersDiary.Dispose();
            EnkaNetwork.Dispose();
            TravelersDiaryDetail.Dispose();
            GameRecords.Dispose();
        }
        public class HoYoLabAPIException : Exception
        {
            public HoYoLabAPIException(int retcode, string message)
            : base($"Error code:{retcode} - {message}")
            {
                Retcode = retcode;
                APIMessage = message;
                Retcode = retcode;
            }
            public readonly int Retcode;
            public readonly string APIMessage;
        }
        public class UserNotFoundException : Exception
        {
            public UserNotFoundException(int uid)
            : base($"お使いのHoYoLabアカウントでは「UID {uid}」を所持していません。")
            {
                this.uid = uid;
            }
            public readonly int uid;
        }
        public class UserNotAuthenticatedException : Exception
        {
            public UserNotAuthenticatedException(int uid) : base($"該当のユーザーアカウント(UID:{uid})は認証されていない為、利用できません。")
            {
                this.uid = uid;
            }
            public readonly int uid;
        }
        #region APIリクエスト関数
        /// <summary>
        /// アカウント情報を取得
        /// </summary>
        /// <param name="server">ゲームアカウントが所在しているサーバー</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Model.HoYoLab.Account.Data> GetServerAccounts(Servers server)
        {
            var url = $"https://api-account-os.hoyolab.com/binding/api/getUserGameRolesByLtoken?game_biz=hk4e_global&region={server}";
            var json = await WebRequest.HoYoGetRequest(url, Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.Account.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 戦績情報
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.GameRecords.Data> GetGameRecords()
        {
            if (!IsAuthed) throw new UserNotAuthenticatedException(UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/api/index?server={Server}&role_id={UID}";
            var json = await WebRequest.HoYoGetRequest(url, Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.GameRecords.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// キャラクター情報
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.Characters.Data> GetCharacters()
        {
            if (!IsAuthed) throw new UserNotAuthenticatedException(UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/api/character";
            string content = $"{{\"server\":\"{Server}\",\"role_id\":\"{UID}\"}}";
            var json = await WebRequest.HoYoPostRequest(url, Cookie, content);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.Characters.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 深境螺旋情報
        /// </summary>
        /// <param name="current"><c>true</c> : 今月<br/><c>false</c> : 先月</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.SpiralAbyss.Data> GetSpiralAbyss(bool current)
        {
            if (!IsAuthed) throw new UserNotAuthenticatedException(UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/api/spiralAbyss?server={Server}&role_id={UID}&lang={Culture.Name.ToLower()}&schedule_type={(current ? 1 : 2)}";
            var json = await WebRequest.HoYoGetRequest(url, Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.SpiralAbyss.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// リアルタイムノート
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.RealTimeNote.Data> GetRealTimeNote()
        {
            if (!IsAuthed) throw new UserNotAuthenticatedException(UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/api/dailyNote?server={Server}&role_id={UID}";
            var json = await WebRequest.HoYoGetRequest(url, Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.RealTimeNote.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 旅人手帳概要
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.TravelersDiary.Infomation.Data> GetTravelersDiaryInfo(int month = 0, CultureInfo? culture = null)
        {
            if (!IsAuthed) throw new UserNotAuthenticatedException(UID);
            var cul = Culture.Name.ToLower();
            if (culture != null) cul = culture.Name.ToLower();
            var url = $"https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_info?region={Server}&uid={UID}&lang={cul}&month={month}";
            var json = await WebRequest.HoYoGetRequest(url, Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.TravelersDiary.Infomation.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 旅人手帳詳細
        /// </summary>
        /// <param name="type"><c>1</c> : 原石<br/><c>2</c> : モラ</param>
        /// <param name="month">既定値 : <c>当月</c><br/>直近3か月内のデータが取得可能</param>
        /// <param name="page">既定値 : <c>1</c><br/>1から始まる全てのページ<br/>1ページ当たり20件まで取得可能</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.TravelersDiary.Detail.Data> GetTravelersDiaryDetail(int type, int page = 1, int month = 0)
        {
            if (!IsAuthed) throw new UserNotAuthenticatedException(UID);
            var url = $"https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_detail?region={Server}&uid={UID}&lang={Culture.Name.ToLower()}&month={month}&type={type}&current_page={page}";
            var json = await WebRequest.HoYoGetRequest(url, Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.TravelersDiary.Detail.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// キャラクター詳細情報
        /// </summary>
        /// <param name="characterID">キャラクター番号<br/>例 :10000089 = フリーナ</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Model.HoYoLab.CharacterDetail.Root> GetCharacterDetail(int characterID)
        {
            var url = $"https://sg-public-api.hoyolab.com/event/calculateos/sync/avatar/detail?avatar_id={characterID}&uid={UID}&region={Server}&lang={Culture.Name.ToLower()}";
            var json = await WebRequest.HoYoGetRequest(url,Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.CharacterDetail.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root;
        }
        /// <summary>
        /// 旅の振り返りAPI
        /// </summary>
        /// <param name="since">該当DateTimeから今日までの差分を取得<br/>最大90日前まで利用可能</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Model.HoYoLab.StellarJourney.Root> GetActiveQuery(DateTime since)
        {
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/wapi/query_tool?server={Server}&role_id={UID}&year={since.Year}&month={since.Month:00}&day={since.Day:00}";
            var json = await WebRequest.HoYoGetRequest(url, Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.StellarJourney.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root;
        }
        /// <summary>
        /// EnkaNetwork
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Model.EnkaNetwork.ShowCase.Root> GetEnkaNetwork()
        {
            var url = $"https://enka.network/api/uid/{UID}";
            var json = await WebRequest.GeneralGetRequest(url);
            var root = JsonConvert.DeserializeObject<Model.EnkaNetwork.ShowCase.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            return root;
        }
        #endregion
    }
}
