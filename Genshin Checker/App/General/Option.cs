using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General
{
    public class Option
    {
        public Option()
        {
            Notification.IsGameStart = Registry.GetValue("Config\\Setting", "IsNotificationGameStart") == "True";
            Notification.IsGameEnd = Registry.GetValue("Config\\Setting", "IsNotificationGameClosed") == "True";
            Notification.RealTimeNote.Resin120 = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteResin120") == "True";
            Notification.RealTimeNote.ResinMax = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteResinMax") == "True";
            Notification.RealTimeNote.RealmCoin1800 = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteRealmCoin1800") == "True";
            Notification.RealTimeNote.RealmCoinMax = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteRealmCoinMax") == "True";
            Notification.RealTimeNote.ExpeditionAllCompleted = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteExpeditionAllCompleted") == "True";
            Notification.RealTimeNote.TransformerReached = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteTransformerReached") == "True";
            ScreenShot.IsRaise = Registry.GetValue("Config\\Setting", "IsScreenShotRaise") == "True";
            ScreenShot.RaisePath = Registry.GetValue("Config\\Setting", "ScreenShotRaisePath") ?? "";
        }
        static Option? instance = null;
        public static Option Instance { get => instance ??= new Option(); }
        public Notification Notification { get; set; } = new();
        public ScreenShot ScreenShot { get; set; } = new();
    }
    public class Notification
    {
        public bool IsGameStart = false;
        public bool IsGameEnd = false;
        public RealTime RealTimeNote = new();
        public class RealTime
        {
            public bool Resin120 = false;
            public bool ResinMax = false;
            public bool RealmCoin1800 = false;
            public bool RealmCoinMax = false;
            public bool ExpeditionAllCompleted = false;
            public bool TransformerReached = false;
        }

    }
    public class ScreenShot
    {
        public bool IsRaise = false;
        public string RaisePath = "";
    }
}
