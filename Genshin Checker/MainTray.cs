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

namespace Genshin_Checker
{
    public partial class MainTray : Form
    {
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
            Store.Accounts.Data.AccountChanges += (s, e) => { ToolStripGenerate(); };
            Store.Accounts.Data.AccountAdded += AccountAdded;
            Store.Accounts.Data.Load();
            var name = System.Reflection.Assembly.GetExecutingAssembly().GetName();

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
            App.Game.ScreenshotWatcher.Instance.NewImageEvent += ScreenshotEvent;
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
        private async void ScreenshotEvent(object? s, string e)
        {
            try
            {
                var path = await App.General.ScreenShot.SaveToLocation(e);
                if (Option.Instance.ScreenShot.IsNotify)
                {
                    var toastContent = new ToastContentBuilder()
            .AddText("新しいスクリーンショットが保存されました！")
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
            catch(Exception ex)
            {
                new ErrorMessage("スクリーンショット保存中にエラー", $"{ex}").ShowDialog();
            }
        }
        List<Form> FormList = new();
        private void OpenWindow(Account? account,string name)
        {
            string Name = $"{(account != null ? account.UID : "null")},{name}";
            var delete = FormList.Find(a => a.Name == Name&&a.IsDisposed);
            if(delete!=null)FormList.Remove(delete);
            var find = FormList.Find(a => a.Name == Name);
            bool IsAdd = find == null;
            if (account == null)
            {
                switch (name)
                {
                    case nameof(Window.GameLog):
                        if (find == null || find.IsDisposed) find = new Window.GameLog(GameLogTemp) { Name = Name };
                        break;
                    case nameof(Window.TimerDisplay):
                        if (find == null || find.IsDisposed) find = new Window.TimerDisplay() { Name = Name };
                        break;
                    case nameof(Window.TimeGraph):
                        if (find == null || find.IsDisposed) find = new Window.TimeGraph() { Name = Name };
                        break;
                    case nameof(Window.SettingWindow):
                        if(find==null || find.IsDisposed) find= new Window.SettingWindow() { Name = Name };
                        break;
                }
            }
            else
            {
                switch (name)
                {
                    case nameof(Window.GameRecords):
                        if (find == null || find.IsDisposed) find = new Window.GameRecords(account) { Name = Name };
                        break;
                    case nameof(Window.RealTimeData):
                        if (find == null || find.IsDisposed) find = new Window.RealTimeData(account) { Name = Name };
                        break;
                    case nameof(Window.TravelersDiary):
                        if (find == null || find.IsDisposed) find = new Window.TravelersDiary(account) { Name = Name };
                        break;
                    case nameof(Window.TravelersDiaryDetailList):
                        if (find == null || find.IsDisposed) find = new Window.TravelersDiaryDetailList(account) { Name = Name };
                        break;
                    case nameof(Window.CharacterCalculator):
                        if (find == null || find.IsDisposed) find = new Window.CharacterCalculator(account) { Name = Name };
                        break;
                    case nameof(BrowserApp.WebGameAnnounce):
                        if (find == null || find.IsDisposed) find = new BrowserApp.WebGameAnnounce(account) { Name = Name };
                        break;
                }
            }
            if (find == null) return;
            if (IsAdd) FormList.Add(find);
            find.Show();
            if (find.WindowState == FormWindowState.Minimized) find.WindowState = FormWindowState.Normal;
            find.Activate();
        }
        private void ToolStripGenerate()
        {
            AccountToolStrip.DropDownItems.Clear();
            if (Accounts.Data.Count > 0)
            {
                foreach(var account in Accounts.Data)
                {
                    var GameRecord = new ToolStripMenuItem() { Text = "戦績情報" };
                    GameRecord.Click += (s, e) => { OpenWindow(account, nameof(Window.GameRecords)); };
                    var RealTimeNote = new ToolStripMenuItem() { Text = "リアルタイムノート" };
                    RealTimeNote.Click += (s, e) => { OpenWindow(account, nameof(Window.RealTimeData)); };
                    var TravelersDiary = new ToolStripMenuItem() { Text = "旅人手帳" };
                    TravelersDiary.Click += (s, e) => { OpenWindow(account, nameof(Window.TravelersDiary)); };
                    var TravelersDiaryDetailList = new ToolStripMenuItem() { Text = "旅人通帳" };
                    TravelersDiaryDetailList.Click += (s, e) => { OpenWindow(account, nameof(Window.TravelersDiaryDetailList)); };
                    var CharacterCalculator = new ToolStripMenuItem() { Text = "育成計算機＋" };
                    CharacterCalculator.Click += (s, e) => { OpenWindow(account, nameof(Window.CharacterCalculator)); };
                    var OfficialAnnounce = new ToolStripMenuItem() { Text = "ゲームアナウンス" };
                    OfficialAnnounce.Click += (s, e) => { OpenWindow(account, nameof(BrowserApp.WebGameAnnounce)); };
                    var tools = new ToolStripMenuItem() { Text = $"{account.Name} (AR.{account.Level})" };
                    tools.DropDownItems.AddRange(new ToolStripItem[]
                    {
                        GameRecord,RealTimeNote,TravelersDiary,TravelersDiaryDetailList,CharacterCalculator,OfficialAnnounce,
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