using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genshin_Checker.Model.UserData.TravelersDiary.EventName;

namespace Genshin_Checker.App.General
{
    internal class TravelersDiaryDatailEventConverter
    {
        public enum EventType
        {
            Purchase,       //購入
            PurchasePrimogems,       //購入
            Consumption,    //消費
            Wish,    //祈願
            Quest,          //通常任務 2
            Mail,           //メール 12
            Adventure,      //冒険 17,19
            Daily,          //デイリー 26,27,116
            RandomQuest,    //ランダムクエスト 28
            Enemy,          //敵討伐 37,52
            SpirialAbyss,   //螺旋 48,49
            ImaginariumTheater, //幻想シアター
            Event,          //イベント
            Domains,        //秘境報酬(初回含む)
            Achievement,    //アチーブメント
            AdventureExperience, //溢れた分の冒険経験
            Reputation, //評判任務
            Others
        }
        public static EventType GetEventType(int id)
        {
            switch (id)
            {
                case -1:
                case -2:
                    return EventType.Purchase;
                case -11:        
                case -12:        
                case -13:        
                    return EventType.PurchasePrimogems;
                case -201:
                case -21:
                case -22:
                case -99:
                    return EventType.Consumption;
                case -1000:
                    return EventType.Wish;
                case 2:
                    return EventType.Quest;
                case 4:
                case 12:
                case 101:
                case 102:
                    return EventType.Mail;
                case 17:
                case 19:
                case 39:
                case 82:
                    return EventType.Adventure;
                case 26:
                case 27:
                case 33:
                case 116:
                    return EventType.Daily;
                case 28:
                case 32:
                    return EventType.RandomQuest;
                case 37:
                case 52:
                    return EventType.Enemy;
                case 48:
                case 49:
                    return EventType.SpirialAbyss;
                case 54:
                case 67:
                case 1046:
                case 1071:
                case 1073:
                case 1074:
                case 1082:
                case 1084:
                case 1143:
                case 1159:
                    return EventType.Event;
                case 1049:
                    return EventType.Achievement;
                case 93:
                    return EventType.AdventureExperience;
                case 20:
                case 1016:
                    return EventType.Domains;
                case 80:
                case 81:
                case 1054:
                    return EventType.Reputation;
                case 117:
                case 118:
                    return EventType.ImaginariumTheater;
                default:
                    return EventType.Others;
            }
        }
        public static string GetEventName(int id, string usname, Model.UserData.GameDatabase.NameLocalize.Root? events = null)
        {
            //ToDo: IDと名前はjson化して外部サーバーから取得するようにしたい
            switch (CultureInfo.CurrentCulture.Name.ToLower())
            {
                case "ja-jp":
                    switch (id)
                    {
                        case -1: return "創世結晶を購入";
                        case -2: return "空月の祝福を購入";
                        case -11: return "創世結晶から原石に変換";
                        case -12: return "空月の祝福ログイン報酬";
                        case -13: return "紀行報酬";
                        case -21: return "ショップでの購入";
                        case -22: return "紀行レベルの購入";
                        case -99: return "樹脂やその他の購入";
                        case -101: return "合成素材に使用";
                        case -102: return "秘境での報酬";
                        case -103: return "ボス討伐";
                        case -104: return "地脈の花報酬";
                        case -201: return "ショップ交換";
                        case -1000: return "祈願獲得";
                        case 2: return "通常・イベント任務";
                        case 4: return "アイテム購入・交換報酬";
                        case 5: return "冒険ランク報酬";
                        case 12: return "メール";
                        case 17: return "七天神像LvUP";
                        case 19: return "ワープポイント解放";
                        case 20: return "秘境初回クリア";
                        case 26: return "デイリー(冒険者協会)";
                        case 27: return "デイリー(任務)";
                        case 28: return "ランダムクエスト";
                        case 29: return "探索派遣";
                        case 32: return "ランダムクエスト(マルチ任務)";
                        case 33: return "デイリー(マルチ任務)";
                        case 37: return "魔物討伐";
                        case 39: return "宝箱獲得報酬";
                        case 43: return "チュートリアル閲覧";
                        case 48: return "深境螺旋(星の秘宝)";
                        case 49: return "深境螺旋(初回クリア)";
                        case 52: return "ボス討伐";
                        case 55: return "地脈の花挑戦報酬";
                        case 67: return "期間限定イベント報酬";
                        case 80: return "評判任務(住民リクエスト)";
                        case 81: return "評判任務(探索度)";
                        case 93: return "冒険Exp変換";
                        case 101: return "イベント終了告知メール";
                        case 102: return "紀行終了告知メール";
                        case 116: return "デイリー(冒険修練)";
                        case 117: return "幻想シアター(再演報酬)";
                        case 118: return "幻想シアター(初演報酬)";
                        case 1016: return "秘境クリア";
                        case 1032: return "冒険の証・見聞(章制覇報酬)";
                        case 1033: return "冒険の証・見聞(単体報酬)";
                        case 1046: return "キャラクターお試し報酬";
                        case 1049: return "アチーブメント";
                        case 1052: return "低ランク聖遺物処理";
                        case 1054: return "評判任務(討伐懸賞)";
                        case 1069: return "星の返還 歳月の累計";
                        case 1070: return "星の返還 帰還の道";
                        case 1071: return "百貨珍品報酬";
                        case 1073: return "写真イベント(フレンド協力可)";
                        case 1074: return "参量物質変化器変換報酬";
                        case 1082: return "デートイベント報酬";
                        case 1084: return "イベントマルチミニゲーム報酬";
                        case 1100: return "塵歌壺ギフトセット報酬";
                        case 1180: return "期間限定マップ探索段階報酬";
                        case 1191: return "紀行任務報酬";

                        default:
                            if (events != null)
                            {
                                if(events.Locale.TryGetValue(usname,out var localename))
                                {
                                    if (localename.TryGetValue(CultureInfo.CurrentCulture.Name.ToLower(),out var name)){
                                        return name;
                                    }
                                }
                            }
                            return "不明";
                    }
                default:
                    if (events != null)
                    {
                        if (events.Locale.TryGetValue(usname, out var localename))
                        {
                            if (localename.TryGetValue(CultureInfo.CurrentCulture.Name.ToLower(), out var name))
                            {
                                return name;
                            }
                        }
                    }
                    return "不明";
            }
        }
        public static string GetEventName(int id, EventName? events = null)
        {
            //ToDo: IDと名前はjson化して外部サーバーから取得するようにしたい
            switch (CultureInfo.CurrentCulture.Name.ToLower())
            {
                case "ja-jp":
                    switch (id)
                    {
                        case -1: return "創世結晶を購入";
                        case -2: return "空月の祝福を購入";
                        case -11: return "創世結晶から原石に変換";
                        case -12: return "空月の祝福ログイン報酬";
                        case -13: return "紀行報酬";
                        case -21: return "ショップでの購入";
                        case -22: return "紀行レベルの購入";
                        case -99: return "樹脂やその他の購入";
                        case -101: return "合成素材に使用";
                        case -102: return "秘境での報酬";
                        case -103: return "ボス討伐";
                        case -104: return "地脈の花報酬";
                        case -201: return "ショップ交換";
                        case -1000: return "祈願獲得";
                        case 2: return "通常・イベント任務";
                        case 4: return "アイテム購入・交換報酬";
                        case 5: return "冒険ランク報酬";
                        case 12: return "メール";
                        case 17: return "七天神像LvUP";
                        case 19: return "ワープポイント解放";
                        case 20: return "秘境初回クリア";
                        case 26: return "デイリー(冒険者協会)";
                        case 27: return "デイリー(任務)";
                        case 28: return "ランダムクエスト";
                        case 29: return "探索派遣";
                        case 32: return "ランダムクエスト(マルチ任務)";
                        case 33: return "デイリー(マルチ任務)";
                        case 37: return "魔物討伐";
                        case 39: return "宝箱獲得報酬";
                        case 43: return "チュートリアル閲覧";
                        case 48: return "深境螺旋(星の秘宝)";
                        case 49: return "深境螺旋(初回クリア)";
                        case 52: return "ボス討伐";
                        case 55: return "地脈の花挑戦報酬";
                        case 67: return "期間限定イベント報酬";
                        case 80: return "評判任務(住民リクエスト)";
                        case 81: return "評判任務(探索度)";
                        case 93: return "冒険Exp変換";
                        case 101: return "イベント終了告知メール";
                        case 102: return "紀行終了告知メール";
                        case 116: return "デイリー(冒険修練)";
                        case 117: return "幻想シアター(再演報酬)";
                        case 118: return "幻想シアター(初演報酬)";
                        case 1016: return "秘境クリア";
                        case 1032: return "冒険の証・見聞(章制覇報酬)";
                        case 1033: return "冒険の証・見聞(単体報酬)";
                        case 1046: return "キャラクターお試し報酬";
                        case 1049: return "アチーブメント";
                        case 1052: return "低ランク聖遺物処理";
                        case 1054: return "評判任務(討伐懸賞)";
                        case 1069: return "星の返還 歳月の累計";
                        case 1070: return "星の返還 帰還の道";
                        case 1071: return "百貨珍品報酬";
                        case 1073: return "写真イベント(フレンド協力可)";
                        case 1074: return "参量物質変化器変換報酬";
                        case 1084: return "イベントマルチミニゲーム報酬";
                        case 1100: return "塵歌壺ギフトセット報酬";
                        case 1180: return "期間限定マップ探索段階報酬";
                        case 1191: return "紀行任務報酬";

                        default:
                            if (events != null)
                            {
                                var name = events.Events.Find(a => a.ID == id);
                                if (name != null) return name.Name;
                                else return "不明";
                            }
                            else return "不明";
                    }
                default:
                    if (events != null)
                    {
                        var name = events.Events.Find(a => a.ID == id);
                        if (name != null) return name.Name;
                        else return "unknown";
                    }
                    else return "unknown";
            }
        }
    }
}
