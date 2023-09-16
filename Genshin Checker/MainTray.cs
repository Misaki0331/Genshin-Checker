using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Genshin_Checker
{
    public partial class MainTray : Form
    {
        long sessionTime = 0;
        bool IsHide = false;
        Window.TimerDisplay? TimerDisplay= null;
        public MainTray()
        {
            InitializeComponent();
            var cmds = System.Environment.GetCommandLineArgs();
            //コマンドライン引数を列挙する
            foreach (string cmd in cmds)
            {
                switch (cmd)
                {
                    case "-hide":
                        IsHide = true;
                        break;
                }
            }
            //アプリの初期化&UIの初期化
            sessionTime = App.SessionCheck.Instance.Load();
            App.ProcessTime.Instance.option.OnlyActiveWindow = true;
            App.ProcessTime.WatchDog = true;
            App.ProcessTime.Instance.SessionStart += TargetStart;
            App.ProcessTime.Instance.SessionEnd += TargetEnd;
            App.ProcessTime.Instance.ChangedState += ChangeState;
            notification.Icon = resource.icon.nahida;
            notification.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        void TargetStart(object? sender, EventArgs e)
        {
            sessionTime = App.SessionCheck.Instance.Load();
        }
        void ChangeState(object? sender, App.ProcessTime.Result e)
        {
        }
        void TargetEnd(object? sender, App.ProcessTime.Result e)
        {
            notification.BalloonTipTitle = "原神チェッカー";
            notification.BalloonTipText = $"遊んだ時間 : {(int)e.SessionTime.TotalHours} 時間 {e.SessionTime.Minutes:00} 分";
            notification.ShowBalloonTip(30000);
            App.SessionCheck.Instance.Append(e.SessionTime.Ticks);

        }

        private void MainTray_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.ProcessTime.Instance.CurrentProcessState != App.ProcessTime.ProcessState.NotRunning)
            {
                App.SessionCheck.Instance.Append(App.ProcessTime.Instance.Session.Ticks);
            }
            Close();
        }

        private void notification_Click(object sender, EventArgs e)
        {
            if (TimerDisplay == null || TimerDisplay.IsDisposed)
            {
                TimerDisplay = new();
                TimerDisplay.WindowState = FormWindowState.Normal;
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

        private void MainTray_Load(object sender, EventArgs e)
        {

        }
    }
}