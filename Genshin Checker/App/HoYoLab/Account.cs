using Genshin_Checker.resource.Languages;
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
        public Characters Characters;
        public CharacterDetail CharacterDetail;
        public SpiralAbyss SpiralAbyss;
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
            Characters = new(this);
            CharacterDetail = new(this);
            SpiralAbyss = new(this);
            Culture = CultureInfo.CurrentCulture;
            Endpoint= new(this);
        }
        /// <summary>
        /// Cookieの上書き検証<br/>
        /// 新しいクッキーで認証できない場合は元のクッキーに戻して例外をスローする。
        /// </summary>
        /// <param name="cookie">設定するHoYoLabクッキー</param>
        /// <returns>なし</returns>
        public async Task Rewrite(string cookie)
        {
            string old = RawCookie;
            Cookie = cookie;
            try
            {
                await CheckUID(_uid);
                return;
            }
            catch
            {
                Cookie = old;
                throw;
            }
        }
        /// <summary>
        /// UIDからサーバー名取得
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        private static Servers GetServer(int uid)
        {
            return (uid / 100000000) switch
            {
                0 => throw new InvalidDataException($"UID({uid}) is not supported. (used within company of miHoYo)"),
                1 => throw new InvalidDataException($"This app is only supported international version. UID({uid}) is seems like 天空岛 (Celestia) Server."),
                2 => throw new InvalidDataException($"This app is only supported international version. UID({uid}) is seems like 天空岛 (Celestia) Server."),
                5 => throw new InvalidDataException($"This app is only supported international version. UID({uid}) is seems like 世界树 (Irminsul) Server."),
                6 => Servers.os_usa,
                7 => Servers.os_euro,
                8 => Servers.os_asia,
                9 => Servers.os_cht,
                18 => Servers.os_asia,
                _ => throw new InvalidDataException($"unknown uid({uid})"),
            }; ;
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
            private set { RawCookie = value; }
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
        public int UID { get => _uid; private set => _uid=value; }
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
        private async Task CheckUID(int uid)
        {
            var res = await Endpoint.GetServerAccounts(GetServer(uid));
            foreach (var user in res.list)
            {
                if (int.Parse(user.game_uid) == uid)
                {
                    Name = user.nickname;
                    Level = user.level;
                    _uid = uid;
                    IsAuthed = true;
                    return;
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
            Characters.Dispose();
            
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
            : base(string.Format(Localize.Error_HoYoLabAccount_UIDNotFound,uid))
            {
                this.uid = uid;
            }
            public readonly int uid;
        }
        public class UserNotAuthenticatedException : Exception
        {
            public UserNotAuthenticatedException(int uid) : base(string.Format(Localize.Error_HoYoLabAccount_NotAuthenticated,uid))
            {
                this.uid = uid;
            }
            public readonly int uid;
        }

        public readonly ApiEndpoint Endpoint;
    }
}
