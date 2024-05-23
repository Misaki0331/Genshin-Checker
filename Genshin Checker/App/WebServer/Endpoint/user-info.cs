using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Store;
using Genshin_Checker.Window;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.WebServer.Endpoint
{
    public class UserInfo : APIEndpoint
    {
        public override string Path => "user-info";
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
            var result = new Model.API.UserInfo.Root();
            result.profile.uid = user.UID;
            result.profile.name = user.Name;
            result.profile.message = user.EnkaNetwork.Data.playerInfo.signature;
            result.profile.icon = user.GameRecords.Data?.role.game_head_icon ?? "";
            result.profile.namecard = EnkaData.Convert.Namecard.GetNameCardURL(user.EnkaNetwork.Data.playerInfo.nameCardId) ?? "";
            #region バッジ情報
            #region ・サーバー
            result.profile.badges.Add(new()
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
            result.profile.badges.Add(new()
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
            #region コンポーネント
            #region 概要
            result.components.Add(new()
            {
                clickto = "",
                title = "概要",
                rows = new()
                {
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/svg/month.svg",
                    tooltip = new()
                    {
                        title = "活動日数",
                        description = "ゲームにログインした日数です。"
                    },
                    value = user.GameRecords.Data?.stats.ActiveDay.ToString("#,##0")??"-",
                    max_value = "日"
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/achievement.png",
                    tooltip = new()
                    {
                        title = "アチーブメント",
                        description = "実績を獲得した数です。"
                    },
                    value = user.GameRecords.Data?.stats.Achievement.ToString("#,##0")??"-"
                    }
                }
            });
            #endregion

            #region キャラクター
            result.components.Add(new()
            {
                clickto = "",
                title = "キャラクター",
                rows = new()
                {
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/charas.png",
                    tooltip = new()
                    {
                        title = "キャラクター所持数",
                        description = "キャラクターを獲得した数です。\n" +
                        $"<color=#FFB13F>★5 x {user.GameRecords.Data?.avatars.FindAll(a=>a.rarity==5).Count.ToString()??"-"}</color>\n" +
                        $"<color=#D28FD6>★4 x {user.GameRecords.Data?.avatars.FindAll(a=>a.rarity==4).Count.ToString()??"-"}</color>"
                    },
                    value = user.GameRecords.Data?.avatars.Count.ToString("#,##0")??"-",
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/fetter.png",
                    tooltip = new()
                    {
                        title = "好感度最大のキャラクター数",
                        description = "好感度が最大になったキャラクタ―数と全体の育成率です。"
                    },
                    value = user.GameRecords.Data?.avatars.FindAll(a=>a.fetter==10).Count.ToString("#,##0")??"-",
                    max_value = "/ "+user.GameRecords.Data?.avatars.FindAll(a=>a.fetter!=0).Count.ToString("#,##0")??"-",
                    bottom_value = new Func<string>(()=>{
                            if(user.GameRecords.Data==null)return "--.-- %";
                            var chara = user.GameRecords.Data.avatars.FindAll(a=>a.fetter!=0);
                            int current = 0;
                            foreach(var e in chara){
                                current+=e.fetter-1;
                            }
                            return $"{(double)current/(chara.Count*9)*100.0:0.0} %";
                        })()
                    }
                }
            });
            #endregion
            #endregion







            await SimpleResponse.Result(response, result, 200);
        }
    }
}
