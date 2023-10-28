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
            Quest,          //通常任務 2
            Mail,           //メール 12
            Adventure,      //冒険 17,19
            Daily,          //デイリー 26,27,116
            RandomQuest,    //ランダムクエスト 28
            Enemy,          //敵討伐 37,52
            SpirialAbyss,   //螺旋 48,49
            Event,          //イベント
            Domains,        //秘境報酬(初回含む)
            Achievement,    //アチーブメント
            Others
        }
        public static EventType GetEventType(int id)
        {
            switch (id)
            {
                case 2:
                    return EventType.Quest;
                case 12: 
                    return EventType.Mail;
                case 17:
                case 19:
                case 39:
                case 82:
                    return EventType.Adventure;
                case 26:
                case 27:
                case 116:
                    return EventType.Daily;
                case 28:
                    return EventType.RandomQuest;
                case 37:
                case 52:
                    return EventType.Enemy;
                case 48:
                case 49:
                    return EventType.SpirialAbyss;
                case 54:
                case 67:
                case 101:
                case 1046:
                case 1074:
                case 1082:
                case 1143:
                case 1159:
                    return EventType.Event;
                case 1049:
                    return EventType.Achievement;
                default:
                    return EventType.Others;
            }
        }
        public static string GetEventName(int id, EventName? events = null)
        {
            switch (CultureInfo.CurrentCulture.Name.ToLower())
            {
                case "ja-jp":
                    switch (id)
                    {
                        case 12: return "メール";
                        case 17: return "七天神像LvUP";
                        case 19: return "ワープポイント解放";
                        case 20: return "秘境初回クリア";
                        case 26: return "デイリー(冒険者協会)";
                        case 27: return "デイリー(任務)";
                        case 28: return "ランダムクエスト";
                        case 29: return "探索派遣";
                        case 37: return "魔物討伐";
                        case 39: return "宝箱";
                        case 43: return "チュートリアル閲覧";
                        case 48: return "深境螺旋(星の秘宝)";
                        case 49: return "深境螺旋(初回クリア)";
                        case 52: return "ボス討伐";
                        case 80: return "評判任務(住民リクエスト)";
                        case 81: return "評判任務(討伐懸賞)";
                        case 93: return "冒険Exp変換";
                        case 116: return "デイリー(冒険修練)";
                        case 1049: return "アチーブメント";

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
