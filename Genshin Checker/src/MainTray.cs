using System.Diagnostics;
using Genshin_Checker.App;
using Genshin_Checker.Window;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.App.Game;
using Genshin_Checker.App.General;
using Genshin_Checker.Store;
using Genshin_Checker.Window.Popup;
using Genshin_Checker.App.General.Convert;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Drawing.Imaging;
using System.Security.Policy;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Debug;
using System.Reflection.Metadata.Ecma335;
namespace Genshin_Checker
{
    public partial class MainTray : Form
    {
        List<string> GameLogTemp;
        App.WebServer.WebServer WebServer;
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
            testToolStripMenuItem.Visible = false;      
#endif
            consoleToolStripMenuItem.Visible = isdebug;
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
            App.SessionCheck.Instance.Load();
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

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessTime.Instance.EmergencyReset();
            Close();
        }


        private async void MainTray_Load(object sender, EventArgs e)
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
                        new InfoMessage(startup.Title, startup.Message, startup.Title).ShowDialog();
                        break;
                    case "error":
                        new ErrorMessage(startup.Title, startup.Message, startup.Title).ShowDialog();
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
            App.Game.GameLogWatcher.Instance.Init();
            App.Game.ScreenshotWatcher.Instance.NewImageEvent += ScreenshotEvent;

        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            Hide();
        }

        private void 詳細プレイデータToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(null, nameof(TimeGraph));
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(null, nameof(SettingWindow));
        }

        private void notification_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                OpenWindow(null, nameof(TimerDisplay));
        }
        //ここはテスト用
        private void testToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            OpenWindow(null, nameof(APIChecker));
        }


        private void ゲームログ開発者向けToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(null, nameof(GameLog));
        }

        private async void ScreenshotEvent(object? s, string e)
        {
            try
            {
                var path = await App.General.ScreenShot.SaveToLocation(e);
                if (Option.Instance.ScreenShot.IsNotify)
                {
                    var toastContent = new ToastContentBuilder()
                        .AddText(Localize.App_Notify_Screenshot_Saved)
                        .AddAttributionText($"UID: {await App.General.GameApp.CurrentUID()}")
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
                new ErrorMessage(Localize.App_Error_FailedSaveScreenshot, $"{ex}").ShowDialog();
            }
        }

        void AccountRemoved(object? sender, Account account)
        {
            ManageWindow.CloseDiposedAccount(account);
        }
        private void OpenWindow(Account? account, string name)
        {
            ManageWindow.OpenWindow(account, name);
        }
        private void ToolStripGenerate()
        {
            AccountToolStrip.DropDownItems.Clear();
            if (Accounts.Data.Count > 0)
            {
                foreach (var account in Accounts.Data)
                {
                    var GameRecord = new ToolStripMenuItem() { Text = Localize.WindowName_GameRecord };
                    GameRecord.Click += (s, e) => { OpenWindow(account, nameof(Window.GameRecords)); };
                    var SpiralAbyss = new ToolStripMenuItem() { Text = Localize.WindowName_SpiralAbyss };
                    SpiralAbyss.Click += (s, e) => { OpenWindow(account, nameof(Window.SpiralAbyss)); };
                    var RealTimeNote = new ToolStripMenuItem() { Text = Localize.WindowName_RealTimeNote };
                    RealTimeNote.Click += (s, e) => { OpenWindow(account, nameof(Window.RealTimeData)); };
                    var TravelersDiary = new ToolStripMenuItem() { Text = Localize.WindowName_TravelersDiary };
                    TravelersDiary.Click += (s, e) => { OpenWindow(account, nameof(Window.TravelersDiary)); };
                    var TravelersDiaryDetailList = new ToolStripMenuItem() { Text = Localize.WindowName_TravelersDiaryDetail };
                    TravelersDiaryDetailList.Click += (s, e) => { OpenWindow(account, nameof(Window.TravelersDiaryDetailList)); };
                    var CharacterCalculator = new ToolStripMenuItem() { Text = Localize.WindowName_EnhancementCalculator };
                    CharacterCalculator.Click += (s, e) => { OpenWindow(account, nameof(Window.CharacterCalculator)); };
                    var OfficialAnnounce = new ToolStripMenuItem() { Text = Localize.WindowName_GameAnnouncement };
                    OfficialAnnounce.Click += (s, e) => { OpenWindow(account, nameof(BrowserApp.WebGameAnnounce)); };
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

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(null, nameof(Window.Debug.Console));
        }

        private void 現在のアカウント情報を取得ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWindow(null, nameof(Window.ProgressWindow.LoadGameDatabase));
        }

        private void toolStripCodeExchange_Click(object sender, EventArgs e)
        {
            OpenWindow(null, nameof(Window.CodeExchange));
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void func_musicplayer_Click(object sender, EventArgs e)
        {
            OpenWindow(null, nameof(Window.MusicPlayer));
        }
    }

}