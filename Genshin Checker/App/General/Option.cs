using Genshin_Checker.Window.Popup;
using Newtonsoft.Json;
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
        }
        static Option? instance = null;
        public static void Save()
        {
#if DEBUG
            Registry.SetValue("Config\\Setting", "DataDebug", JsonConvert.SerializeObject(Instance), false, true);
#else
            Registry.SetValue("Config\\Setting", "Data", JsonConvert.SerializeObject(Instance), true);
#endif
        }
        public static void Load()
        {
            try
            {
#if DEBUG
                var json = Registry.GetValue("Config\\Setting", "DataDebug", false);
#else
                var json = Registry.GetValue("Config\\Setting", "Data", true);
#endif
                if (json == null) return;
                instance = JsonConvert.DeserializeObject<Option>(json);
            }
            catch (Exception ex)
            {
                new ErrorMessage("設定ファイルロード時にエラーが発生しました。", $"{ex}").ShowDialog();
            }
        }
        public static Option Instance { get { if (instance == null)
                {
                    instance = new Option();
                    Load();
                }
                return instance;
            }
        }
        public OptionClass.Notification Notification { get; set; } = new();
        public OptionClass.ScreenShot ScreenShot { get; set; } = new();
    }
    
}
namespace Genshin_Checker.App.General.OptionClass
{
    public class Notification
    {
        public bool IsGameStart { get; set; } = false;
        public bool IsGameEnd { get; set; } = false;
        public RealTime RealTimeNote = new();
        public class RealTime
        {
            public bool Resin120 { get; set; } = false;
            public bool ResinMax { get; set; } = false;
            public bool RealmCoin1800 { get; set; } = false;
            public bool RealmCoinMax { get; set; } = false;
            public bool ExpeditionAllCompleted { get; set; } = false;
            public bool TransformerReached { get; set; } = false;
        }

    }
    public class ScreenShot
    {
        public bool IsRaise { get; set; } = false;
        public string RaisePath { get; set; } = "";
        public string SaveFileFormat { get; set; } = "<UID>\\<DATE>-<TIME>";
        public string SaveFileFormatType { get; set; } = ".png";
        public string SaveFilePath { get; set; } = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\\Genshin Checker";
        public bool IsSaveAfterDelete { get; set; } = false;
        public bool IsNotify { get; set; } = false;
    }
}