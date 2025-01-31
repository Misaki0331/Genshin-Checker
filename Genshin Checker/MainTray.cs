using System.Diagnostics;
using Genshin_Checker.Core;
using Genshin_Checker.Window;
using Genshin_Checker.Core.HoYoLab;
using Genshin_Checker.Core.Game;
using Genshin_Checker.Core.General;
using Genshin_Checker.Store;
using Genshin_Checker.GUI.Window.PopupWindow;
using Microsoft.Toolkit.Uwp.Notifications;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Debug;
using Genshin_Checker.GUI.BrowserApp;
using Genshin_Checker.GUI.Window.PopupWindow;
using ErrorMessage = Genshin_Checker.GUI.Window.PopupWindow.ErrorMessage;
namespace Genshin_Checker
{
    public partial class MainTray : Form
    {
        List<string> GameLogTemp;
        Core.WebServer.WebServer WebServer;
        class StartUpData
        {
            internal string Message = "";
            internal string Title = "";
            internal string Style = "";
        }
        StartUpData? startup;
        public MainTray(bool safemode = false)
        {
            InitializeComponent();
            GameLogTemp = new();
            WebServer = new();
            WebServer.IsServerRun = true;
            notification.Icon = resource.icon.nahida;
            bool isdebug = false;
            var cmds = System.Environment.GetCommandLineArgs();
            //コマンドライン引数を列挙する
            foreach (string cmd in cmds)
            {
                switch (cmd)
                {
                    case "-debug":
                        isdebug = true;
                        break;
                }
                if (cmd.StartsWith("Title:"))
                {
                    startup ??= new();
                    startup.Title = cmd[6..];
                }
                if (cmd.StartsWith("Style:"))
                {
                    startup ??= new();
                    startup.Style = cmd[6..];
                }
                if (cmd.StartsWith("Message:"))
                {
                    startup ??= new();
                    startup.Message = cmd[8..];
                }
            }

            //アプリの初期化&UIの初期化
            ProcessTime.WatchDog = true;
            ProcessTime.Instance.SessionStart += TargetStart;
            ProcessTime.Instance.SessionEnd += TargetEnd;
            ProcessTime.Instance.ChangedState += ChangeState;
            notification.Icon = resource.icon.nahida;
            notification.Visible = true;
            Store.Accounts.Data.AccountChanges += (s, e) => { ToolStripGenerate(); };
            Store.Accounts.Data.AccountAdded += AccountAdded;
            Store.Accounts.Data.AccountRemoved += AccountRemoved;
            Store.Accounts.Data.Load();
            var name = System.Reflection.Assembly.GetExecutingAssembly().GetName();

            versionNameToolStripMenuItem.Text = $"{name.Name} {name.Version}";
#if DEBUG
            versionNameToolStripMenuItem.Text += "(DEBUG)";
            isdebug = true;
#else
            FuncTestFunction.Visible = false;      
#endif
            FuncConsole.Visible = isdebug;
            if (safemode)
            {
                Log.Warn(Localize.Warning_SafeMode);

                versionNameToolStripMenuItem.Text += "[Readonly]";
                Registry.IsReadOnly = true;
            }
        }

        void AccountAdded(object? sender, Account e)
        {
            e.RealTimeNote.Notification += Notification;
        }
        void TargetStart(object? sender, EventArgs e)
        {
            Core.SessionCheck.Instance.Load();
            if (Option.Instance.Notification.IsGameStart)
            {
                notification.BalloonTipTitle = Localize.AppName;
                notification.BalloonTipText = Localize.GameApp_Notify_WakeUp;
                notification.ShowBalloonTip(30000);
            }
        }
        void ChangeState(object? sender, ProcessTime.Result e)
        {
        }
        void TargetEnd(object? sender, ProcessTime.Result e)
        {
            if (Option.Instance.Notification.IsGameEnd)
            {
                notification.BalloonTipTitle = Localize.AppName;
                notification.BalloonTipText = string.Format(Localize.GameApp_Notify_PlayTime_Result, (int)e.SessionTime.TotalHours, $"{e.SessionTime.Minutes:00}");
                notification.ShowBalloonTip(30000);
            }

        }


        void Notification(object? sender, string e)
        {
            Log.Debug($"{sender}");
            notification.BalloonTipTitle = $"{sender}";
            notification.BalloonTipText = $"{e}";
            notification.ShowBalloonTip(30000);

        }

        private void MainTray_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MainTray_Load(object sender, EventArgs e)
        {
            notification.Visible = true;
            notification.BalloonTipTitle = Localize.AppName;
            notification.BalloonTipText = Localize.App_Notify_WakeUp;
            notification.ShowBalloonTip(30000);

            if (startup != null)
            {
                switch (startup.Style.ToLower())
                {
                    case "info":
                        Dialog.Info(startup.Title, startup.Message, startup.Title);
                        break;
                    case "error":
                        Dialog.Error(startup.Title, startup.Message, startup.Title);
                        break;
                }
            }
            Task.WaitAll(
                Task.Run(async () => await EnkaData.Data.GetStoreData()),
                Task.Run(async () => await Misaki_chan.Data.GetStoreData()),
                Task.Run(async () =>
                {
                    if (await AppUpdater.CheckVersion())
                        Invoke(() => new Window.PopupWindow.UpdateNotice().ShowDialog());
                }),
                        Task.Run(async () => await WebViewWatcher.Init())
                );
            Core.Game.GameLogWatcher.Instance.Init();
            Core.Game.LauncherLogWatcher.Instance.Init();
            Core.Game.ScreenshotWatcher.Instance.NewImageEvent += ScreenshotEvent;

        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            Hide();
        }
        private void UIFunction(object sender, EventArgs e)
        {
            switch (sender)
            {
                case ToolStripMenuItem func when func.Equals(FuncDetailTime):
                    //詳細プレイデータ
                    ManageWindow.OpenWindow(null, nameof(TimeGraph));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncSetting):
                    //設定
                    ManageWindow.OpenWindow(null, nameof(GUI.Window.SettingWindow));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncTestFunction):
                    //テスト用
                    ManageWindow.OpenWindow(null, nameof(GUI.Window.HoYoContentViewer));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncGameLog):
                    ManageWindow.OpenWindow(null, nameof(GameLog));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncConsole):
                    ManageWindow.OpenWindow(null, nameof(Window.Debug.Console));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncCodeExchange):
                    ManageWindow.OpenWindow(null, nameof(Window.CodeExchange));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncCodeExchange):
                    ManageWindow.OpenWindow(null, nameof(Window.CodeExchange));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncMusicPlayer):
                    ManageWindow.OpenWindow(null, nameof(Window.MusicPlayer));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncAnalyzeItem):
                    ManageWindow.OpenWindow(null, nameof(Window.ProgressWindow.LoadGameDatabase));
                    break;

                case ToolStripMenuItem func when func.Equals(FuncOfficialInfo):
                    ManageWindow.OpenWindow(null, nameof(GUI.Window.HoYoContentViewer));
                    break;
                case ToolStripMenuItem func when func.Equals(FuncExit):
                    ProcessTime.Instance.EmergencyReset();
                    Close();
                    break;

                default:
                    // その他の場合の処理（必要であれば）
                    break;
            }
        }

        private void notification_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ManageWindow.OpenWindow(null, nameof(TimerDisplay));
        }

        private async void ScreenshotEvent(object? s, string e)
        {
            try
            {
                var path = await Core.General.ScreenShot.SaveToLocation(e);
                if (Option.Instance.ScreenShot.IsNotify)
                {
                    var toastContent = new ToastContentBuilder()
                        .AddText(Localize.App_Notify_Screenshot_Saved)
                        .AddAttributionText($"UID: {await Core.General.GameApp.CurrentUID()}")
                        .AddHeroImage(new Uri(path));
                    toastContent.Show(toast =>
                    {
                        toast.Activated += (s, e) =>
                        {
                            try
                            {
                                var process = new ProcessStartInfo()
                                {
                                    Arguments = $"/select,{path}",
                                    FileName = "EXPLORER.EXE",
                                };
                                Process.Start(process);
                            }
                            catch (Exception) { }
                        };
                        toast.ExpirationTime = DateTime.Now.AddDays(1);
                    });
                }
            }
            catch (Exception ex)
            {
                Dialog.Error(Localize.App_Error_FailedSaveScreenshot, $"{ex}");
            }
        }

        void AccountRemoved(object? sender, Account account)
        {
            ManageWindow.CloseDiposedAccount(account);
        }
        private void ToolStripGenerate()
        {
            AccountToolStrip.DropDownItems.Clear();
            if (Accounts.Data.Count > 0)
            {
                foreach (var account in Accounts.Data)
                {
                    var GameRecord = new ToolStripMenuItem() { Text = Localize.WindowName_GameRecord };
                    GameRecord.Click += (s, e) => { ManageWindow.OpenWindow(account, nameof(Window.GameRecords)); };
                    var SpiralAbyss = new ToolStripMenuItem() { Text = Localize.WindowName_SpiralAbyss };
                    SpiralAbyss.Click += (s, e) => { ManageWindow.OpenWindow(account, nameof(Window.SpiralAbyss)); };
                    var RealTimeNote = new ToolStripMenuItem() { Text = Localize.WindowName_RealTimeNote };
                    RealTimeNote.Click += (s, e) => { ManageWindow.OpenWindow(account, nameof(Window.RealTimeData)); };
                    var TravelersDiary = new ToolStripMenuItem() { Text = Localize.WindowName_TravelersDiary };
                    TravelersDiary.Click += (s, e) => { ManageWindow.OpenWindow(account, nameof(Window.TravelersDiary)); };
                    var TravelersDiaryDetailList = new ToolStripMenuItem() { Text = Localize.WindowName_TravelersDiaryDetail };
                    TravelersDiaryDetailList.Click += (s, e) => { ManageWindow.OpenWindow(account, nameof(Window.TravelersDiaryDetailList)); };
                    var CharacterCalculator = new ToolStripMenuItem() { Text = Localize.WindowName_EnhancementCalculator };
                    CharacterCalculator.Click += (s, e) => { ManageWindow.OpenWindow(account, nameof(Window.CharacterCalculator)); };
                    var OfficialAnnounce = new ToolStripMenuItem() { Text = Localize.WindowName_GameAnnouncement };
                    OfficialAnnounce.Click += (s, e) => { ManageWindow.OpenWindow(account, nameof(WebGameAnnounce)); };
                    var tools = new ToolStripMenuItem() { Text = $"{account.Name} (AR.{account.Level})" };
                    tools.DropDownItems.AddRange(new ToolStripItem[]
                    {
                        GameRecord,SpiralAbyss,RealTimeNote,TravelersDiary,TravelersDiaryDetailList,CharacterCalculator,OfficialAnnounce,
                        new ToolStripSeparator(),new ToolStripMenuItem(){Enabled=false,Text=$"UID: {account.UID}"}
                    });
                    AccountToolStrip.DropDownItems.Add(tools);
                }
            }
            else
            {
                AccountToolStrip.DropDownItems.AddRange(new ToolStripItem[] {
            emptyToolStripMenuItem});
            }
        }
    }

}