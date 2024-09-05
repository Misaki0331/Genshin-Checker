using Genshin_Checker.Store;
using System.Collections.Specialized;
using System.Net;

namespace Genshin_Checker.App.WebServer.Endpoint
{
    public class Profile : APIEndpoint
    {
        public override string Path => "profile";
        public override string Description => "ユーザーのプロフィール情報を取得します。";

        public override async Task Execute(HttpListenerResponse response, NameValueCollection parameters)
        {
            var uidstr = parameters.Get("UID");
            if (uidstr == null)
            {
                await SimpleResponse.Error(response, $"UIDが不足しています。", 400);
                return;
            }
            if (!int.TryParse(uidstr, out int uid))
            {
                await SimpleResponse.Error(response, "UIDの形式が違います。", 400);
                return;
            }
            var user = Genshin_Checker.Store.Accounts.Data.Find(a => a.UID == uid);
            if (user == null)
            {
                await SimpleResponse.Error(response, $"該当アカウント(UID: {uid})の情報を見るには、まずアプリ側でログインしてください。", 401);
                return;
            }

            await SimpleResponse.Result(response, GetProfile(uid), 200);
        }

        public static Model.API.Profile GetProfile(int uid)
        {
            var user = Genshin_Checker.Store.Accounts.Data.Find(a => a.UID == uid);
            if (user == null) throw new ArgumentNullException("User not found.");
            var result = new Model.API.Profile();
            result.uid = user.UID;
            result.name = user.Name;
            result.message = user.EnkaNetwork.Data.playerInfo.signature;
            result.icon = user.GameRecords.Data?.role.game_head_icon ?? "";
            result.namecard = EnkaData.Convert.Namecard.GetNameCardURL(user.EnkaNetwork.Data.playerInfo.nameCardId) ?? "";
            #region バッジ情報
            #region ・サーバー
            result.badges.Add(new()
            {
                name = user.Server.ToString(),
                color = new() { bg = "#FFFFAF", fg = "#202020" },
                tooltip = new()
                {
                    title = "サーバー情報",
                    description = "ユーザーが所属しているサーバーです。"
                }
            });
            #endregion
            #region ・冒険ランク
            result.badges.Add(new()
            {
                name = $"AR.{user.GameRecords.Data?.role.Level ?? user.Level}",
                color = new() { bg = "#AAFFAA", fg = "#202020" },
                tooltip = new()
                {
                    title = $"冒険ランク {user.GameRecords.Data?.role.Level ?? user.Level}",
                    description = "冒険ランク情報です。"
                },
                icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/aep.png"
            });
            #endregion
            #endregion
            return result;
        }
    }
}
