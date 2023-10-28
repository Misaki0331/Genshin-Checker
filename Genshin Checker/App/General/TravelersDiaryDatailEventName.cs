using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General
{
    internal class TravelersDiaryDatailEventConverter
    {
        public static string GetEventName(int id, Model.UserData.TravelersDiary.EventName.Root? events = null)
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
                        case 81: return "評判任務";
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
