using Genshin_Checker.App.General;
using Genshin_Checker.UI.Control.SettingWindow;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Genshin_Checker.App.HoYoLab.Account;

namespace Genshin_Checker.App.Game
{
    public class GameAPI
    {
        /// <summary>
        /// 入手フィルター
        /// </summary>
        public enum AddType
        {
            /// <summary>
            /// 全て
            /// </summary>
            All,
            /// <summary>
            /// 獲得
            /// </summary>
            Produce,
            /// <summary>
            /// 消費
            /// </summary>
            Consume
        }
        /// <summary>
        /// 祝福のフィルター
        /// </summary>
        public enum MonthlyFilter
        {
            /// <summary>
            /// 全ての情報
            /// </summary>
            All = 0,
            /// <summary>
            /// 購入
            /// </summary>
            Purchase = 1,
            /// <summary>
            /// アイテムの使用
            /// </summary>
            ItemUsage = 2,
            /// <summary>
            /// 毎日の受取
            /// </summary>
            Claimed = 3,
            /// <summary>
            /// 受け取らなかった日
            /// </summary>
            Unclaimed = 4,

        }
        public class GameAPIException : Exception
        {
            public GameAPIException(int retcode, string message)
            : base($"Error code:{retcode} - {message}")
            {
                Retcode = retcode;
                APIMessage = message;
                Retcode = retcode;
            }
            public readonly int Retcode;
            public readonly string APIMessage;
        }
        public static async Task<Model.Game.AccountInfo.Data> GetAccountInfo(string authkey)
        {
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                }).ReadAsStringAsync();
            string url = $"https://sg-public-api.hoyoverse.com/common/csc_qna/public/getUserInfo?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.AccountInfo.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        public static async Task<Model.Game.MonthlyCardLog.Data> GetMonthlyCardLog(string authkey, int size = 20, long end_id = -1, MonthlyFilter filter = MonthlyFilter.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentUICulture;
            string lang = culture.TwoLetterISOLanguageName;
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                    { "lang", lang },
                    { "size",$"{size}" },
                    { "end_id", $"{(end_id==-1?"":$"{end_id}")}" },
                    { "cardtype", filter==MonthlyFilter.All?"":$"{(int)filter}"},
                    { "begin_time", $"{(begin==null?"":$"{begin:yyyy-MM-dd}")}" },
                    { "end_time", $"{(end==null?"":$"{end:yyyy-MM-dd}")}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetMonthlyCardLog?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.MonthlyCardLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.ItemLog.Data> GetCrystalLog(string authkey, int size = 20, long end_id = -1, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentUICulture;
            string lang = culture.TwoLetterISOLanguageName;
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                    { "lang", lang },
                    { "size",$"{size}" },
                    { "end_id", $"{(end_id==-1?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetCrystalLog?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.ItemLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.ItemLog.Data> GetPrimogemLog(string authkey, int size = 20, long end_id = -1, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentUICulture;
            string lang = culture.TwoLetterISOLanguageName;
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                    { "lang", lang },
                    { "size",$"{size}" },
                    { "end_id", $"{(end_id==-1?"":$"{end_id}")}" },
                    { "add_type", filter == AddType.All ? "" : filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetPrimogemLog?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.ItemLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        public static async Task<Model.Game.ItemLog.Data> GetResinLog(string authkey, int size = 20, long end_id = -1, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentUICulture;
            string lang = culture.TwoLetterISOLanguageName;
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                    { "lang", lang },
                    { "size",$"{size}" },
                    { "end_id", $"{(end_id==-1?"":$"{end_id}")}" },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetResinLog?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.ItemLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.StarItems.Data> GetStarglitterLog(string authkey, int size = 20, long end_id = -1, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentUICulture;
            string lang = culture.TwoLetterISOLanguageName;
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                    { "lang", lang },
                    { "size",$"{size}" },
                    { "end_id", $"{(end_id==-1?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetStarglitter?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.StarItems.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.StarItems.Data> GetStardustLog(string authkey, int size = 20, long end_id = -1, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentUICulture;
            string lang = culture.TwoLetterISOLanguageName;
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                    { "lang", lang },
                    { "size",$"{size}" },
                    { "end_id", $"{(end_id==-1?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetStardustLog?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.StarItems.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.EquipmentLog.Data> GetArtifactLog(string authkey, int size = 20, long end_id = -1, int rarity = -1, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentUICulture;
            string lang = culture.TwoLetterISOLanguageName;
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                    { "lang", lang },
                    { "size",$"{size}" },
                    { "end_id", $"{(end_id==-1?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },
                    { "quality", rarity==-1?"":$"{rarity}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetArtifactLog?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.EquipmentLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.EquipmentLog.Data> GetWeaponLog(string authkey, int size = 20, long end_id = -1, int rarity = -1, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentUICulture;
            string lang = culture.TwoLetterISOLanguageName;
            var parms =
                await new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "sign_type", "2" },
                    { "authkey_ver", "1" },
                    { "authkey", authkey },
                    { "game_biz", "hk4e_global" },
                    { "lang", lang },
                    { "size",$"{size}" },
                    { "end_id", $"{(end_id==-1?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },
                    { "quality", rarity==-1?"":$"{rarity}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetWeaponLog?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url, true);
            var root = JsonChecker<Model.Game.EquipmentLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

    }
}
