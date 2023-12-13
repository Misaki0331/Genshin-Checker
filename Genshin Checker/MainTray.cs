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

namespace Genshin_Checker
{
    public partial class MainTray : Form
    {
        long sessionTime = 0;
        Window.TimerDisplay? TimerDisplay= null;
        Window.TimeGraph? TimeGraph= null;
        Window.RealTimeData? RealTimeData = null;
        Window.SettingWindow? SettingWindow= null;
        Window.TravelersDiary? TravelersDiary = null;
        Window.TravelersDiaryDetailList? DetailList = null; 
        Window.GameRecords? GameRecords = null;
        Window.GameLog? GameLog = null;
        Window.CharacterCalculator? CharacterCalculator = null;
        BrowserApp.WebGameAnnounce? WebGameAnnounce = null;
        List<string> GameLogTemp;
        public MainTray(bool safemode=false)
        {
            InitializeComponent();
            GameLogTemp = new();
            notification.Icon = resource.icon.nahida;
            var cmds = System.Environment.GetCommandLineArgs();
            //コマンドライン引数を列挙する
            foreach (string cmd in cmds)
            {
                switch (cmd)
                {
                    case "-hide":
                        //IsHide = true;
                        break;
                }
            }
            EnkaData.Data.GetStoreData();
            
            //アプリの初期化&UIの初期化
            ProcessTime.Instance.option.OnlyActiveWindow = true;
            if (Registry.GetValue("Config\\Setting", "IsCountBackground") == "True") ProcessTime.Instance.option.OnlyActiveWindow = false;
            ProcessTime.WatchDog = true;
            ProcessTime.Instance.SessionStart += TargetStart;
            ProcessTime.Instance.SessionEnd += TargetEnd;
            ProcessTime.Instance.ChangedState += ChangeState;
            notification.Icon = resource.icon.nahida;
            notification.Visible = true;
            //new Window.WebMiniBrowser(new("https://google.com"));
            //new BrowserApp.HoYoApp();
            Store.Accounts.Data.AccountAdded += AccountAdded;
            Store.Accounts.Data.Load();
            var name = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            Console.WriteLine("{0} {1}", name.Name, name.Version);

            versionNameToolStripMenuItem.Text = $"{name.Name} {name.Version}";
#if DEBUG
            versionNameToolStripMenuItem.Text += "(DEBUG)";
#else
            testToolStripMenuItem.Visible = false;      
#endif
            if (safemode)
            {
                Trace.WriteLine("【警告】現在セーフモードです。アプリは読み取り専用になっています。");

                versionNameToolStripMenuItem.Text += "[Readonly]";
                Registry.IsReadOnly = true;
            }
            App.Game.GameLogWatcher.Instance.LogUpdated += LogUpdated;
            App.Game.GameLogWatcher.Instance.Init();
            App.Game.ScreenshotWacher.Instance.NewImageEvent += ScreenshotEvent;
        }

        void AccountAdded(object? sender, Account e)
        {
            e.RealTimeNote.Notification += Notification;
        }
        void TargetStart(object? sender, EventArgs e)
        {
            sessionTime = App.SessionCheck.Instance.Load();
            if (Option.Instance.Notification.IsGameStart)
            {
                notification.BalloonTipTitle = "原神チェッカー";
                notification.BalloonTipText = $"原神の起動を検知しました。";
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
                notification.BalloonTipTitle = "原神チェッカー";
                notification.BalloonTipText = $"遊んだ時間 : {(int)e.SessionTime.TotalHours} 時間 {e.SessionTime.Minutes:00} 分";
                notification.ShowBalloonTip(30000);
            }

        }


        void Notification(object? sender, string e)
        {
            Trace.WriteLine(sender);
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


        private void MainTray_Load(object sender, EventArgs e)
        {
            notification.Visible = true;
            notification.BalloonTipTitle = $"原神チェッカー";
            notification.BalloonTipText = $"起動しました。\nタスクトレイから開くことができます。";
            notification.ShowBalloonTip(30000);
        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            Hide();
        }

        private void 詳細プレイデータToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            if (TimeGraph == null || TimeGraph.IsDisposed)
            {
                TimeGraph = new();
                TimeGraph.WindowState = FormWindowState.Normal;
                TimeGraph.Show();
                TimeGraph.Activate();
            }
            else
            {
                TimeGraph.Show();
                if (TimeGraph.WindowState == FormWindowState.Minimized) TimeGraph.WindowState = FormWindowState.Normal;
                TimeGraph.Activate();
            }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }

        private void リアルタイムデータToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            if (RealTimeData == null || RealTimeData.IsDisposed)
            {
                    if (Store.Accounts.Data.Count == 0)
                    {
                        var n = new ErrorMessage("連携しているアカウントはまだ無いようです。", "お手数ですが、以下の操作を行って認証してください。\n設定⇒アプリ連携⇒HoYoLabとの連携");
                        n.ShowDialog(this);
                        return;
                    }
                    RealTimeData = new(Store.Accounts.Data[0]);
                RealTimeData.WindowState = FormWindowState.Normal;
                RealTimeData.Show();
                RealTimeData.Activate();
            }
            else
            {
                RealTimeData.Show();
                if (RealTimeData.WindowState == FormWindowState.Minimized) RealTimeData.WindowState = FormWindowState.Normal;
                RealTimeData.Activate();
            }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }

        private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            if (SettingWindow == null || SettingWindow.IsDisposed)
            {
                SettingWindow = new();
                SettingWindow.WindowState = FormWindowState.Normal;
                SettingWindow.Show();
                SettingWindow.Activate();
            }
            else
            {
                SettingWindow.Show();
                if (SettingWindow.WindowState == FormWindowState.Minimized) SettingWindow.WindowState = FormWindowState.Normal;
                SettingWindow.Activate();
            }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }

        private void notification_Click(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (TimerDisplay == null || TimerDisplay.IsDisposed)
                    {
                        TimerDisplay = new()
                        {
                            WindowState = FormWindowState.Normal
                        };
                        TimerDisplay.Show();
                        TimerDisplay.Activate();
                    }
                    else
                    {
                        TimerDisplay.Show();
                        if (TimerDisplay.WindowState == FormWindowState.Minimized) TimerDisplay.WindowState = FormWindowState.Normal;
                        TimerDisplay.Activate();
                    }
                }
            }catch(Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }
        //ここはテスト用
        private async void testToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            Trace.WriteLine(await App.General.GameApp.WhereScreenShotPath());
        }

        private void 旅人手帳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (TravelersDiary == null || TravelersDiary.IsDisposed)
                {
                    if (Accounts.Data.Count == 0)
                    {
                        var n = new ErrorMessage("連携しているアカウントはまだ無いようです。", "お手数ですが、以下の操作を行って認証してください。\n設定⇒アプリ連携⇒HoYoLabとの連携");
                        n.ShowDialog(this);
                        return;
                    }
                    TravelersDiary = new(Accounts.Data[0])
                    {
                        WindowState = FormWindowState.Normal
                    };
                    TravelersDiary.Show();
                    TravelersDiary.Activate();
                }
                else
                {
                    TravelersDiary.Show();
                    if (TravelersDiary.WindowState == FormWindowState.Minimized) TravelersDiary.WindowState = FormWindowState.Normal;
                    TravelersDiary.Activate();
                }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }

        private void 旅人通帳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (DetailList == null || DetailList.IsDisposed)
                {
                    if (Accounts.Data.Count == 0)
                    {
                        var n = new ErrorMessage("連携しているアカウントはまだ無いようです。", "お手数ですが、以下の操作を行って認証してください。\n設定⇒アプリ連携⇒HoYoLabとの連携");
                        n.ShowDialog(this);
                        return;
                    }
                    DetailList = new(Accounts.Data[0])
                    {
                        WindowState = FormWindowState.Normal
                    };
                    DetailList.Show();
                    DetailList.Activate();
                }
                else
                {
                    DetailList.Show();
                    if (DetailList.WindowState == FormWindowState.Minimized) DetailList.WindowState = FormWindowState.Normal;
                    DetailList.Activate();
                }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }
        private void LogUpdated(object? sender, string[] e)
        {
            foreach (var item in e)
            {
                GameLogTemp.Add(item);
                if (GameLogTemp.Count > 200) GameLogTemp.RemoveAt(0);
                //Trace.Write(item);
            }
        }

        private void ゲームログ開発者向けToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (GameLog == null || GameLog.IsDisposed)
                {
                    GameLog = new(GameLogTemp);
                    GameLog.WindowState = FormWindowState.Normal;
                    GameLog.Show();
                    GameLog.Activate();
                }
                else
                {
                    GameLog.Show();
                    if (GameLog.WindowState == FormWindowState.Minimized) GameLog.WindowState = FormWindowState.Normal;
                    GameLog.Activate();
                }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }

        private void 公式アナウンスToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (WebGameAnnounce == null || WebGameAnnounce.IsDisposed)
                {
                    if (Accounts.Data.Count == 0)
                    {
                        var n = new ErrorMessage("連携しているアカウントはまだ無いようです。", "お手数ですが、以下の操作を行って認証してください。\n設定⇒アプリ連携⇒HoYoLabとの連携");
                        n.ShowDialog(this);
                        return;
                    }
                    WebGameAnnounce = new(Accounts.Data[0]);
                    WebGameAnnounce.WindowState = FormWindowState.Normal;
                    WebGameAnnounce.Show();
                    WebGameAnnounce.Activate();
                }
                else
                {
                    WebGameAnnounce.Show();
                    if (WebGameAnnounce.WindowState == FormWindowState.Minimized) WebGameAnnounce.WindowState = FormWindowState.Normal;
                    WebGameAnnounce.Activate();
                }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }

        private void 戦績情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (GameRecords == null || GameRecords.IsDisposed)
                {
                    if (Accounts.Data.Count == 0)
                    {
                        var n = new ErrorMessage("連携しているアカウントはまだ無いようです。", "お手数ですが、以下の操作を行って認証してください。\n設定⇒アプリ連携⇒HoYoLabとの連携");
                        n.ShowDialog(this);
                        return;
                    }
                    GameRecords = new(Accounts.Data[0]);
                    GameRecords.WindowState = FormWindowState.Normal;
                    GameRecords.Show();
                    GameRecords.Activate();
                }
                else
                {
                    GameRecords.Show();
                    if (GameRecords.WindowState == FormWindowState.Minimized) GameRecords.WindowState = FormWindowState.Normal;
                    GameRecords.Activate();
                }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }

        private void 育成計算機ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CharacterCalculator == null || CharacterCalculator.IsDisposed)
                {
                    if (Accounts.Data.Count == 0)
                    {
                        var n = new ErrorMessage("連携しているアカウントはまだ無いようです。", "お手数ですが、以下の操作を行って認証してください。\n設定⇒アプリ連携⇒HoYoLabとの連携");
                        n.ShowDialog(this);
                        return;
                    }
                    CharacterCalculator = new(Accounts.Data[0])
                    {
                        WindowState = FormWindowState.Normal
                    };
                    CharacterCalculator.Show();
                    CharacterCalculator.Activate();
                }
                else
                {
                    CharacterCalculator.Show();
                    if (CharacterCalculator.WindowState == FormWindowState.Minimized) CharacterCalculator.WindowState = FormWindowState.Normal;
                    CharacterCalculator.Activate();
                }

            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }
        private void ScreenshotEvent(object? s, string e)
        {
            var toast = new ToastContentBuilder()
    .AddText("新しいスクリーンショットが保存されました！")
    .AddHeroImage(new Uri(e));
            toast.Show();
        }
    }
}