using Genshin_Checker.App.General.Convert;
using Genshin_Checker.resource.Languages;
using System.Collections.Specialized;
using System.Net;

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
            result.profile = Endpoint.Profile.GetProfile(uid);
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
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/level.png",
                    tooltip = new()
                    {
                        title = "最大レベルのキャラクター数",
                        description = "レベルが最大になったキャラクタ―数と全体の平均レベルです。"
                    },
                    value = user.GameRecords.Data?.avatars.FindAll(a=>a.level==90).Count.ToString("#,##0")??"-",
                    max_value = "/ "+user.GameRecords.Data?.avatars.Count.ToString("#,##0")??"-",
                    bottom_value = new Func<string>(()=>{
                            if(user.GameRecords.Data==null)return "--.-- %";
                            var chara = user.GameRecords.Data.avatars;
                            int current = 0;
                            foreach(var e in chara){
                                current+=e.level;
                            }
                            return $"Avg. Level {((double)current/chara.Count):0.00}";
                        })()
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/talent.png",
                    tooltip = new()
                    {
                        title = "天賦育成済みのキャラクター数",
                        description = "全ての天賦レベルが9以上になったキャラクタ―数と\n全てのキャラクターの全天賦レベル9を100%とした育成率です。"
                    },
                    value = user.CharacterDetail.CachedCharacters().Count==(user.GameRecords.Data?.avatars.Count??-1)?new Func<string>(() =>
                    {
                        int cnt=0;
                        foreach(var e in user.CharacterDetail.CachedCharacters()){
                            bool IsOK=true;
                            foreach(var c in e.Data.skill_list)
                            {
                                if(c.level_current==c.max_level)continue;
                                if (c.level_current<c.max_level-1){
                                    IsOK = false;
                                    break;
                                }
                            }
                            if(IsOK)cnt++;
                        }
                        return $"{cnt:#,##0}";
                    })():"-",
                    max_value = "/ "+user.GameRecords.Data?.avatars.Count.ToString("#,##0")??"-",
                    bottom_value = new Func<string>(()=>{
                        if(user.CharacterDetail.CachedCharacters().Count==(user.GameRecords.Data?.avatars.Count??-1)){
                        int cnt=0;
                        int max=0;
                        foreach(var e in user.CharacterDetail.CachedCharacters()){
                            foreach(var c in e.Data.skill_list)
                            {
                                if(c.max_level==1)continue;
                                max+=c.max_level-2;
                                cnt+=c.level_current-1;
                            }
                        }
                        return $"{((double)cnt/max*100.0):0.00} %";
                        }else return "--.-- %";
                    })()
                    }
                }
            });
            #endregion
            #region 探索
            result.components.Add(new()
            {
                clickto = "",
                title = "探索",
                rows = new()
                {
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/map.png",
                    tooltip = new()
                    {
                        title = "全体の探索率",
                        description = "全てのマップの平均探索率です。"
                    },
                    value = new Func<string>(()=> {
                        double per = 0;
                        int cnt = 0;
                    foreach (var item in user.GameRecords.Data?.world_explorations??new())
                    {
                        if (item.Type == "Offering" && item.Exploration_percentage <= 0) continue;
                        per += item.Exploration_percentage / 10.0;
                        cnt++;
                    }
                    return $"{(per / cnt):0.00}";
                    })(),
                    max_value = "%"
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/oculus.png",
                    tooltip = new()
                    {
                        title = "収集した神の瞳",
                        description = "収集した神の瞳です。"+
                        new Func<string>(()=>
                        {
                            var text = "";
                            var data = user.GameRecords.Data;
                            if(data==null)return "";
                            var OculusName = new List<string>() { Genshin.Oculus_Anemo, Genshin.Oculus_Geo, Genshin.Oculus_Electro, Genshin.Oculus_Dendro, Genshin.Oculus_Hydro, Genshin.Oculus_Pyro, Genshin.Oculus_Cryo };
                            var OculusValue = new List<int>() { data.stats.OculusAnemo, data.stats.OculusGeo, data.stats.OculusElectro, data.stats.OculusDendro, data.stats.OculusHydro, data.stats.OculusPyro, data.stats.OculusCryo };
                            for(int i = 0; i < OculusValue.Count; i++)
                            {
                                if(OculusValue[i]!=0)
                                text+=$"\n{OculusName[i]} x {OculusValue[i]}";
                            }
                            return text;
                        })()
                    },
                    value = new Func<string>(()=>{

                    var data = user.GameRecords.Data?.stats;
                    if(data==null)return "-";
                    return (data.OculusAnemo + data.OculusGeo + data.OculusElectro + data.OculusDendro + data.OculusHydro + data.OculusPyro + data.OculusCryo).ToString("#,##0");

                    })()
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/waypoint.png",
                    tooltip = new()
                    {
                        title = "開放したワープポイントの数",
                        description = $"解放済みのワープポイント x {user.GameRecords.Data?.stats.WayPoint.ToString("#,##0")??"-"}\n"+
                        $"解放済みの秘境 x {user.GameRecords.Data?.stats.Domains.ToString("#,##0")??"-"}\n"
                    },
                    value = new Func<string>(()=>{

                    var data = user.GameRecords.Data?.stats;
                    if(data==null)return "-";
                    return (data.WayPoint+data.Domains).ToString("#,##0");
                    })()
                    },

                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/chest.png",
                    tooltip = new()
                    {
                        title = "開封した宝箱の数",
                        description = $"普通の宝箱 x {user.GameRecords.Data?.stats.ChestCommon.ToString("#,##0")??"-"}\n"+
                        $"精巧な宝箱 x {user.GameRecords.Data?.stats.ChestExquisite.ToString("#,##0")??"-"}\n"+
                        $"貴重な宝箱 x {user.GameRecords.Data?.stats.ChestPrecious.ToString("#,##0")??"-"}\n"+
                        $"豪華な宝箱 x {user.GameRecords.Data?.stats.ChestLuxurious.ToString("#,##0")??"-"}\n"+
                        $"珍奇な宝箱 x {user.GameRecords.Data?.stats.ChestMagic.ToString("#,##0")??"-"}\n"
                    },
                    value = new Func<string>(()=>{

                    var data = user.GameRecords.Data?.stats;
                    if(data==null)return "-";
                    return (data.ChestCommon+data.ChestExquisite+data.ChestPrecious+data.ChestLuxurious+data.ChestMagic).ToString("#,##0");
                    })()
                    }
                }
            });
            #endregion
            #region 深境螺旋
            result.components.Add(new()
            {
                clickto = "",
                title = "深境螺旋",
                endtime = Time.GetUnixTimeFromDateTime(user.SpiralAbyss.GetCurrent?.Data.ScheduleTime.end) ?? null,
                rows = new()
                {
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/check.png",
                    tooltip = new()
                    {
                        title = "深境螺旋のプレイ情報です",
                        description = "クリア回数/挑戦回数"
                    },
                    value = user.SpiralAbyss.GetCurrent?.Data.total_win_times.ToString("#,##0")??"-",
                    max_value = "/ "+user.SpiralAbyss.GetCurrent?.Data.total_battle_times.ToString("#,##0")??"-"
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/tower.png",
                    tooltip = new()
                    {
                        title = "最高記録",
                        description = "今期で最高記録の情報です"
                    },
                    value = user.SpiralAbyss.GetCurrent?.Data.max_floor??"-"
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/tower_star.png",
                    tooltip = new()
                    {
                        title = "獲得した淵星の数",
                        description = "今期で獲得した淵星の数です。"
                    },
                    value = user.SpiralAbyss.GetCurrent?.Data.total_star.ToString("#,##0")??"-"
                    }
                }
            });
            #endregion
            #region 幻想シアター
            var diff = new List<string>() { "なし", "イージー", "ノーマル", "ハード", "マスター", "エクストラ" };
            result.components.Add(new()
            {
                clickto = "",
                title = "幻想シアター",
                endtime = Time.GetUnixTimeFromDateTime(user.ImaginariumTheater.Current?.Data.ScheduleTime.end) ?? null,
                rows = new()
                {
                    new(){
                    icon = $"https://static-api.misaki-chan.world/genshin-checker/webtools/dynamic/heraldry-icon-{user.ImaginariumTheater.Current?.Data.CurrentStats.heraldry??0}.png",
                    tooltip = new()
                    {
                        title = "最高記録",
                        description = string.Join("", (user.ImaginariumTheater.Current?.Data.CurrentStats.get_medal_round_list ?? new()).Select(x => x == 0 ? "<color=#AAAAAA>☆</color>" : "<color=#D28FD6>★</color>"))
                    },
                    value = user.ImaginariumTheater.Current?.Data.CurrentStats.max_round_id.ToString("#,##0")??"-",
                    max_value = "幕",
                    bottom_value = $"難易度 : {diff[user.ImaginariumTheater.Current?.Data.CurrentStats.difficulty_id??0]}"
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/fantasia_flower.png",
                    tooltip = new()
                    {
                        title = "消費した「幻戯の花」",
                        description = "今期シアターで消費した「幻戯の花」の数です"
                    },
                    value = user.ImaginariumTheater.Current?.Data.CurrentStats.coin_num.ToString("#,##0")??"-"
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/charas.png",
                    tooltip = new()
                    {
                        title = "観客の応援を引き起こした回数",
                        description = "今期シアターで観客の応援を引き起こした回数です。"
                    },
                    value = user.ImaginariumTheater.Current?.Data.CurrentStats.avatar_bonus_num.ToString("#,##0")??"-",
                    max_value = "回"
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/friend.png",
                    tooltip = new()
                    {
                        title = "サポートキャスト支援回数",
                        description = "サポートキャストが他のプレイヤーを支援した回数です。"
                    },
                    value = user.ImaginariumTheater.Current?.Data.CurrentStats.rent_cnt.ToString("#,##0")??"-",
                    max_value="回"
                    }
                }
            });
            #endregion
            #region リアルタイムノート
            result.components.Add(new()
            {
                clickto = "",
                title = "リアルタイムノート",
                rows = new()
                {
                    new() {
                        icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/resin.png",
                        tooltip = new()
                        {
                            title = "樹脂",
                            description = "現在の貯蓄中の樹脂の数です。"
                        + (user.RealTimeNote.Data.RealTime == null ? $"\n<color=#ff0000>{(user.RealTimeNote.Data.Meta.IsAPIError ? "API Error" : "Error")} : Code {user.RealTimeNote.Data.Meta.Retcode}</color>\n<color=#ff0000>{user.RealTimeNote.Data.Meta.Message}</color>" : "")
                        },
                        value = user.RealTimeNote.Data.RealTime?.Resin.Current.ToString("#,##0") ?? "-",
                        max_value = "/ " + (user.RealTimeNote.Data.RealTime?.Resin.Max.ToString("#,##0") ?? "-"),
                        bottom_value = new Func<string>(() => {
                            var r = user.RealTimeNote.Data.RealTime;
                            if (r == null) return Common.Unknown;
                            if (DateTime.Now > r.Resin.RecoveryTime) return Localize.WindowName_RealTimeNote_MaxOut;
                            else
                            {
                                var time = (int)(r.Resin.RecoveryTime - DateTime.Now).TotalSeconds;
                                return string.Format(Localize.WindowName_RealTimeNote_TimeLeft, $"{(time / 3600)}:{(time / 60 % 60):00}");
                            }
                        })()
                    },
                    new() {
                        icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/homecoin.png",
                        tooltip = new()
                        {
                            title = "壺コイン",
                            description = "現在の貯蓄中の壺コインの数です。"
                        + (user.RealTimeNote.Data.RealTime == null ? $"\n<color=#ff0000>{(user.RealTimeNote.Data.Meta.IsAPIError ? "API Error" : "Error")} : Code {user.RealTimeNote.Data.Meta.Retcode}</color>\n<color=#ff0000>{user.RealTimeNote.Data.Meta.Message}</color>" : "")
                        },
                        value = user.RealTimeNote.Data.RealTime?.RealmCoin.Current.ToString("#,##0") ?? "-",
                        max_value = "/ " + (user.RealTimeNote.Data.RealTime?.RealmCoin.Max.ToString("#,##0") ?? "-"),
                        bottom_value = new Func<string>(() => {
                            var r = user.RealTimeNote.Data.RealTime;
                            if (r == null) return Common.Unknown;
                            if (DateTime.Now > r.RealmCoin.RecoveryTime) return Localize.WindowName_RealTimeNote_MaxOut;
                            else
                            {
                                var time = (int)(r.RealmCoin.RecoveryTime - DateTime.Now).TotalSeconds;
                                return string.Format(Localize.WindowName_RealTimeNote_TimeLeft, $"{(time / 3600)}:{(time / 60 % 60):00}");
                            }
                        })()
                    },
                    new() {
                        icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/quest.png",
                        tooltip = new()
                        {
                            title = "デイリークエスト進捗",
                            description = new Func<string>(() => {
                            string result = "デイリークエストの進行状況です。\n";
                            if (user.RealTimeNote.Data.RealTime == null)
                            {
                                result += $"\n<color=#ff0000>{(user.RealTimeNote.Data.Meta.IsAPIError ? "API Error" : "Error")} : Code {user.RealTimeNote.Data.Meta.Retcode}</color>\n" +
                                $"<color=#ff0000>{user.RealTimeNote.Data.Meta.Message}</color>";
                            }
                            else
                            {
                                result += $"長期冒険修練 : ";
                                if (user.RealTimeNote.Data.RealTime?.AttendanceInfo.IsUnlocked == false)
                                {
                                    result += "未開放";
                                }
                                else
                                {
                                    result += $"x <color=#D28FD6>{(user.RealTimeNote.Data.RealTime?.AttendanceInfo.Stored ?? double.NaN):0.0}</color>\n";
                                    var left = (user.RealTimeNote.Data.RealTime?.AttendanceInfo.StoredRefreshEstimatedTime ?? DateTime.Now) - DateTime.Now;
                                    if (left.Ticks < 0) left = TimeSpan.Zero;
                                    var format = $"{left.Days} 日 {left.Hours} 時間 {left.Minutes} 分";
                                    result += $"リセットまで : {format}";
                                    }
                                }
                                return result;
                            })()

                    },
                    value = user.RealTimeNote.Data.RealTime?.Commission.Current.ToString("#,##0")??"-",
                    max_value = "/ " +(user.RealTimeNote.Data.RealTime ?.Commission.Max.ToString("#,##0") ?? "-"),
                    bottom_value = new Func<string?>(()=>{
                        var r = user.RealTimeNote.Data.RealTime;
                        if(r == null) return Common.Unknown;
                        if (r.Commission.IsClaimed) return Localize.WindowName_RealTimeNote_Daily_Completed;
                        else if (r.Commission.Current == r.Commission.Max) return Localize.WindowName_RealTimeNote_Daily_NotExtraClaimed;
                        return null;
                    })()
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/explore.png",
                    tooltip = new()
                    {
                        title = "探索派遣進捗",
                        description = new Func<string?>(() =>
                        {
                            var str = "探索派遣の進捗情報です。"
                        +(user.RealTimeNote.Data.RealTime==null?$"\n<color=#ff0000>{(user.RealTimeNote.Data.Meta.IsAPIError?"API Error":"Error")} : Code {user.RealTimeNote.Data.Meta.Retcode}</color>\n<color=#ff0000>{user.RealTimeNote.Data.Meta.Message}</color>":"");
                            int cnt=1;
                            foreach(var e in user.RealTimeNote.Data.RealTime?.Expedition.Expeditions??new())
                            {
                                str+=$"\nNo.{cnt} : ";
                        if (DateTime.Now > e.EstimatedTime) str += Localize.WindowName_RealTimeNote_ExpeditionCompleted;
                        else
                        {
                            var time = (int)(e.EstimatedTime - DateTime.Now).TotalSeconds;
                            str += string.Format(Localize.WindowName_RealTimeNote_TimeLeft,$"{(time / 3600)}:{(time / 60 % 60):00}");
                        }

                        cnt++;
                            }
                            return str;
                        })()
                    },
                    value = user.RealTimeNote.Data.RealTime?.Expedition.Expeditions.FindAll(a=>DateTime.Now>a.EstimatedTime).Count.ToString("#,##0")??"-",
                    max_value = "/ "+(user.RealTimeNote.Data.RealTime?.Expedition.Dispatched.Max.ToString("#,##0")??"-"),
                    bottom_value = new Func<string?>(()=>{
                        int max =0;
                        int completed=0;
                         foreach(var e in user.RealTimeNote.Data.RealTime?.Expedition.Expeditions??new())
                            {
                        if (DateTime.Now <= e.EstimatedTime) 
                        {
                            var time = (int)(e.EstimatedTime - DateTime.Now).TotalSeconds;
                                if(max<time)max=time;
                            }
                            else
                            {
                                completed++;
                            }
                            }
                        if (max > 0)
                        {
                            return string.Format(Localize.WindowName_RealTimeNote_TimeLeft,$"{(max / 3600)}:{(max / 60 % 60):00}");
                        }
                        if (completed == user.RealTimeNote.Data.RealTime?.Expedition.Dispatched.Current)
                        {
                            return Localize.WindowName_RealTimeNote_ExpeditionCompleted;
                        }
                        return null;
                    })()
                    }
                }
            });
            #endregion
            #region 旅人手帳
            result.components.Add(new()
            {
                clickto = "",
                title = "旅人手帳",
                rows = new()
                {
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/primogems.png",
                    icon_overlay = "https://static-api.misaki-chan.world/genshin-checker/webtools/svg/day.svg",
                    tooltip = new()
                    {
                        title = "本日獲得した原石の数",
                        description = "祝福や紀行報酬を除く本日原石を獲得した数です。"
                        + (user.TravelersDiary.Data?.Data==null?
                        $"\n<color=#ff0000>{user.TravelersDiary.Data?.Message.Replace("\n","</color>\n<color=#f00>")}</color>":"")
                    },
                    value = user.TravelersDiary.Data?.Data?.day_data.current_primogems.ToString("#,##0")??"-",
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/mora.png",
                    icon_overlay = "https://static-api.misaki-chan.world/genshin-checker/webtools/svg/day.svg",
                    tooltip = new()
                    {
                        title = "本日獲得したモラの数",
                        description = "紀行報酬を除く本日モラを獲得した数です。"
                        + (user.TravelersDiary.Data?.Data==null?
                        $"\n<color=#ff0000>{user.TravelersDiary.Data?.Message.Replace("\n","</color>\n<color=#f00>")}</color>":"")
                    },
                    value = user.TravelersDiary.Data?.Data?.day_data.current_mora.ToString("#,##0")??"-"
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/primogems.png",
                    icon_overlay = "https://static-api.misaki-chan.world/genshin-checker/webtools/svg/month.svg",
                    tooltip = new()
                    {
                        title = "今月獲得した原石の数",
                        description = "課金による報酬を除く今月原石を獲得した数です。"
                        + (user.TravelersDiary.Data?.Data==null?
                        $"\n<color=#ff0000>{user.TravelersDiary.Data?.Message.Replace("\n","</color>\n<color=#f00>")}</color>":"")
                    },
                    value = user.TravelersDiary.Data?.Data?.month_data.current_primogems.ToString("#,##0")??"-",
                    },
                    new(){
                    icon = "https://static-api.misaki-chan.world/genshin-checker/webtools/img/mora.png",
                    icon_overlay = "https://static-api.misaki-chan.world/genshin-checker/webtools/svg/month.svg",
                    tooltip = new()
                    {
                        title = "今月獲得したモラの数",
                        description = "課金による報酬を除く今月モラを獲得した数です。"
                        + (user.TravelersDiary.Data?.Data==null?
                        $"\n<color=#ff0000>{user.TravelersDiary.Data?.Message.Replace("\n","</color>\n<color=#f00>")}</color>":"")
                    },
                    value = user.TravelersDiary.Data?.Data?.month_data.current_mora.ToString("#,##0")??"-"
                    }
                }
            }) ;
            #endregion
            #endregion







            await SimpleResponse.Result(response, result, 200);
        }
    }
}
