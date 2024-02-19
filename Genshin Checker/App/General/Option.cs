using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Popup;
using Newtonsoft.Json;

namespace Genshin_Checker.App.General
{
    public class Option
    {
        public Option()
        {
        }
        static Option? instance = null;
        /// <summary>
        /// 設定ファイルの保存
        /// </summary>
        public static void Save()
        {
#if DEBUG
            Registry.SetValue("Config\\Setting", "DataDebug", JsonConvert.SerializeObject(Instance), false, true);
#else
            Registry.SetValue("Config\\Setting", "Data", JsonConvert.SerializeObject(Instance), true);
#endif
        }
        /// <summary>
        /// 設定ファイルの読み込み
        /// </summary>
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
        /// <summary>
        /// 設定情報のインスタンス
        /// </summary>
        public static Option Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Option();
                    Load();
                }
                return instance;
            }
        }
        /// <summary>
        /// 設定：通知
        /// </summary>
        public OptionClass.Notification Notification { get; set; } = new();
        /// <summary>
        /// 設定：スクリーンショット
        /// </summary>
        public OptionClass.ScreenShot ScreenShot { get; set; } = new();
        /// <summary>
        /// 設定：アカウント
        /// </summary>
        public Dictionary<int, OptionClass.AccountConfig> Accounts { get; set; } = new();
    }

}
namespace Genshin_Checker.App.General.OptionClass
{
    public class Notification
    {
        /// <summary>
        /// 設定：ゲーム開始時の通知
        /// </summary>
        public bool IsGameStart { get; set; } = false;
        /// <summary>
        /// 設定：ゲーム終了時の通知
        /// </summary>
        public bool IsGameEnd { get; set; } = false;


    }
    public class ScreenShot
    {
        /// <summary>
        /// 設定：監視モードの有効
        /// </summary>
        public bool IsRaise { get; set; } = false;
        /// <summary>
        /// 設定：監視元のディレクトリ
        /// </summary>
        public string RaisePath { get; set; } = "";
        /// <summary>
        /// 設定：保存先のファイルフォーマット
        /// </summary>
        public string SaveFileFormat { get; set; } = "<UID>\\<DATE>-<TIME>";
        /// <summary>
        /// 設定：出力時の画像ファイルフォーマット
        /// </summary>
        public string SaveFileFormatType { get; set; } = ".png";
        /// <summary>
        /// 設定：画像の転送先
        /// </summary>
        public string SaveFilePath { get; set; } = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)}\\Genshin Checker";
        /// <summary>
        /// 設定：転送後削除するかどうか
        /// </summary>
        public bool IsSaveAfterDelete { get; set; } = false;
        /// <summary>
        /// 設定：転送時に通知を出すかどうか
        /// </summary>
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
            /// 設定：リアルタイムノート
            /// </summary>
            public RealTime RealTimeNotes = new();
            public class RealTime
            {
                /// <summary>
                /// 設定：樹脂の通知閾値の通知
                /// </summary>
                public List<Threshold> ResinThreshold { get; set; } = new();
                /// <summary>
                /// 設定：樹脂最大時の通知
                /// </summary>
                public bool ResinMax { get; set; } = false;
                /// <summary>
                /// 設定：壺コインの閾値の通知
                /// </summary>
                public List<Threshold> RealmCoinThreshold { get; set; } = new();
                /// <summary>
                /// 設定：壺コイン最大時の通知
                /// </summary>
                public bool RealmCoinMax { get; set; } = false;
                /// <summary>
                /// 設定：探索派遣の完了時の通知
                /// </summary>
                public bool ExpeditionAllCompleted { get; set; } = false;
                /// <summary>
                /// 設定：変換器のクールタイム終了の通知
                /// </summary>
                public bool TransformerReached { get; set; } = false;
                public class Threshold
                {
                    /// <summary>
                    /// 設定：閾値
                    /// </summary>
                    public int Value { get; set; } = 0;
                    /// <summary>
                    /// 設定：トリガー状態
                    /// </summary>
                    public bool Enabled { get; set; } = false;
                }
            }
        }
    }
}