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
            var json = await App.WebRequest.GeneralGetRequest(url);
            var root = JsonChecker<Model.Game.AccountInfo.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        public static async Task<Model.Game.MonthlyCardLog.Data> GetMonthlyCardLog(string authkey, int size=20, long end_id = -1, int cardtype = -1, DateTime? begin = null, DateTime? end = null,CultureInfo? culture=null)
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
                    { "cardtype", $"{(cardtype==-1?"":$"{cardtype}")}" },
                    { "begin_time", $"{(begin==null?"":$"{begin:yyyy-MM-dd}")}" },
                    { "end_time", $"{(end==null?"":$"{end:yyyy-MM-dd}")}" },

                }).ReadAsStringAsync();
            string url = $"https://hk4e-api-os.hoyoverse.com/common/hk4e_self_help_query/User/GetMonthlyCardLog?{parms}";
            var json = await App.WebRequest.GeneralGetRequest(url);
            var root = JsonChecker<Model.Game.MonthlyCardLog.Root>.Check(json);
            if (root.Data == null) throw new GameAPIException(root.Retcode, root.Message);
            return root.Data;
        }
    }
}
