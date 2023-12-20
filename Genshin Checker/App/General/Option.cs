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
            //Todo: json化する
            Notification.IsGameStart = Registry.GetValue("Config\\Setting", "IsNotificationGameStart") == "True";
            Notification.IsGameEnd = Registry.GetValue("Config\\Setting", "IsNotificationGameClosed") == "True";
            Notification.RealTimeNote.Resin120 = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteResin120") == "True";
            Notification.RealTimeNote.ResinMax = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteResinMax") == "True";
            Notification.RealTimeNote.RealmCoin1800 = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteRealmCoin1800") == "True";
            Notification.RealTimeNote.RealmCoinMax = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteRealmCoinMax") == "True";
            Notification.RealTimeNote.ExpeditionAllCompleted = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteExpeditionAllCompleted") == "True";
            Notification.RealTimeNote.TransformerReached = Registry.GetValue("Config\\Setting", "IsNotificationRealTimeNoteTransformerReached") == "True";
            ScreenShot.IsRaise = Registry.GetValue("Config\\Setting", "IsScreenShotRaise") == "True";
            ScreenShot.IsSaveAfterDelete = Registry.GetValue("Config\\Setting", "IsScreenShotAfterDelete") == "True";
            ScreenShot.RaisePath = Registry.GetValue("Config\\Setting", "ScreenShotRaisePath") ?? "";
            ScreenShot.SaveFileFormat = Registry.GetValue("Config\\Setting", "ScreenShotSaveFileFormat") ?? "<UID>\\<DATE>-<TIME>";
            ScreenShot.SaveFileFormatType = Registry.GetValue("Config\\Setting", "ScreenShotSaveFileFormatType") ?? ".png";
            ScreenShot.SaveFilePath = Registry.GetValue("Config\\Setting", "ScreenShotSaveFilePath") ?? $"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\\Genshin Checker";
            ScreenShot.IsNotify = Registry.GetValue("Config\\Setting", "IsScreenShotNotify") == "True";
        }
        static Option? instance = null;
        public static Option Instance { get => instance ??= new Option(); }
        public OptionClass.Notification Notification { get; set; } = new();
        public OptionClass.ScreenShot ScreenShot { get; set; } = new();
    }
    
}
namespace Genshin_Checker.App.General.OptionClass
{
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
        public string SaveFileFormat = "<UID>\\<DATE>-<TIME>";
        public string SaveFileFormatType = ".png";
        public string SaveFilePath = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\\Genshin Checker";
        public bool IsSaveAfterDelete = false;
        public bool IsNotify = false;
    }
}