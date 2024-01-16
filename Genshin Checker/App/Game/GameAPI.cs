using Genshin_Checker.App.General;
using Genshin_Checker.UI.Control.SettingWindow;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Security.Policy;
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
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.AccountInfo.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        public static async Task<Model.Game.MonthlyCardLog.Data> GetMonthlyCardLog(string authkey, int size = 20, long end_id = 0, MonthlyFilter filter = MonthlyFilter.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
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
                    { "end_id", $"{(end_id==0?"":$"{end_id}")}" },
                    { "cardtype", filter==MonthlyFilter.All?"":$"{(int)filter}"},
                    { "begin_time", $"{(begin==null?"":$"{begin:yyyy-MM-dd}")}" },
                    { "end_time", $"{(end==null?"":$"{end:yyyy-MM-dd}")}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetMonthlyCardLog?{parms}";
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.MonthlyCardLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.ItemLog.Data> GetCrystalLog(string authkey, int size = 20, long end_id = 0, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
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
                    { "end_id", $"{(end_id==0?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetCrystalLog?{parms}";
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.ItemLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.ItemLog.Data> GetPrimogemLog(string authkey, int size = 20, long end_id = 0, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
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
                    { "end_id", $"{(end_id==0?"":$"{end_id}")}" },
                    { "add_type", filter == AddType.All ? "" : filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetPrimogemLog?{parms}";
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.ItemLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        public static async Task<Model.Game.ItemLog.Data> GetResinLog(string authkey, int size = 20, long end_id = 0, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
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
                    { "end_id", $"{(end_id==0?"":$"{end_id}")}" },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetResinLog?{parms}";
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.ItemLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.StarItems.Data> GetStarglitterLog(string authkey, int size = 20, long end_id = 0, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
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
                    { "end_id", $"{(end_id==0?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetStarglitter?{parms}";
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.StarItems.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.StarItems.Data> GetStardustLog(string authkey, int size = 20, long end_id = 0, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
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
                    { "end_id", $"{(end_id==0?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetStardustLog?{parms}";
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.StarItems.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.EquipmentLog.Data> GetArtifactLog(string authkey, int size = 20, long end_id = 0, int rarity = -1, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
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
                    { "end_id", $"{(end_id==0?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },
                    { "quality", rarity==-1?"":$"{rarity}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetArtifactLog?{parms}";
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.EquipmentLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }

        public static async Task<Model.Game.EquipmentLog.Data> GetWeaponLog(string authkey, int size = 20, long end_id = 0, int rarity = -1, AddType filter = AddType.All, DateTime? begin = null, DateTime? end = null, CultureInfo? culture = null)
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
                    { "end_id", $"{(end_id==0?"":$"{end_id}")}" },
                    { "add_type", filter==AddType.All?"":filter.ToString().ToLower() },
                    { "begin_time", begin==null?"":$"{begin:yyyy-MM-dd HH:mm:ss}" },
                    { "end_time", end==null?"":$"{end:yyyy-MM-dd HH:mm:ss}" },
                    { "quality", rarity==-1?"":$"{rarity}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetWeaponLog?{parms}";
            string json = await GetWebString(url);
            var root = JsonChecker<Model.Game.EquipmentLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        private static async Task<string> GetWebString(string url)
        {
            const int maxRetryCount = 20;
            for (int retry = 0; retry < maxRetryCount; retry++)
            {
                try
                {
                    var json = await App.WebRequest.GeneralGetRequest(url, true);
                    return json;
                }
                catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    if (retry == maxRetryCount - 1) throw;
                    Trace.WriteLine($"Received 429 error. Retrying in 5 seconds...");
                    await Task.Delay(5000);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"{ex.Message}");
                    if (retry == maxRetryCount - 1) throw;
                }
            }
            throw new Exception();
        }
    }
}
