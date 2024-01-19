using Genshin_Checker.resource.Languages;
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
                instance = JsonChecker<Option>.Check(json);
            }　　　　　　　　　　　　　　　
            catch (Exception ex)
            {
                new ErrorMessage(Localize.Error_Config_FailToLoad, $"{ex}").ShowDialog();
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
        public Dictionary<int,OptionClass.AccountConfig> Accounts { get; set; } = new();
    }
    
}
namespace Genshin_Checker.App.General.OptionClass
{
    public class Notification
    {
        public bool IsGameStart { get; set; } = false;
        public bool IsGameEnd { get; set; } = false;
        

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
    public class AccountConfig
    {
        /// <summary>
        /// 通知関係
        /// </summary>
        public Notification Notify = new();
        public class Notification
        {
            /// <summary>
            /// リアルタイムノート
            /// </summary>
            public RealTime RealTimeNotes = new();
            public class RealTime
            {
                /// <summary>
                /// 樹脂の通知閾値
                /// </summary>
                public List<Threshold> ResinThreshold { get; set; } = new();
                /// <summary>
                /// 樹脂最大時の通知
                /// </summary>
                public bool ResinMax { get; set; } = false;
                public List<Threshold> RealmCoinThreshold { get; set; } = new();
                public bool RealmCoinMax { get; set; } = false;
                public bool ExpeditionAllCompleted { get; set; } = false;
                public bool TransformerReached { get; set; } = false;
                public class Threshold
                {
                    public int Value { get; set; } = 0;
                    public bool Enabled { get; set; } = false;
                }
            }
        }
    }
}