using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Genshin_Checker.App;
using Genshin_Checker.Window;
using Newtonsoft.Json;
using Genshin_Checker.Model.HoYoLab;
namespace Genshin_Checker
{
    public partial class MainTray : Form
    {
        long sessionTime = 0;
        Window.TimerDisplay? TimerDisplay= null;
        Window.TimeGraph? TimeGraph= null;
        Window.RealTimeData? RealTimeData = null;
        Window.SettingWindow? SettingWindow= null;
        public MainTray(bool safemode=false)
        {
            InitializeComponent();
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

            
            //アプリの初期化&UIの初期化
            App.ProcessTime.Instance.option.OnlyActiveWindow = true;
            if (Registry.GetValue("Config\\Setting", "IsCountBackground") == "True") App.ProcessTime.Instance.option.OnlyActiveWindow = false;
            App.ProcessTime.WatchDog = true;
            App.ProcessTime.Instance.SessionStart += TargetStart;
            App.ProcessTime.Instance.SessionEnd += TargetEnd;
            App.ProcessTime.Instance.ChangedState += ChangeState;
            notification.Icon = resource.icon.nahida;
            notification.Visible = true;
            //new Window.WebMiniBrowser(new("https://google.com"));
            //new BrowserApp.HoYoApp();
            var realTime = App.RealTimeNote.Instance;
            RealTimeNote.Instance.Notification += Notification;
            var name = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            Console.WriteLine("{0} {1}", name.Name, name.Version);

            versionNameToolStripMenuItem.Text = $"{name.Name} {name.Version}";
#if DEBUG
            versionNameToolStripMenuItem.Text += "(DEBUG)";
#endif
            if (safemode)
            {
                Trace.WriteLine("【警告】現在セーフモードです。アプリは読み取り専用になっています。");

                versionNameToolStripMenuItem.Text += "[Readonly]";
                Registry.IsReadOnly = true;
            }
            account = new(Registry.GetValue("Config\\UserData", "Cookie"), int.Parse(Registry.GetValue("Config\\UserData", "UID")));
        }
        App.Account account;
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
        void ChangeState(object? sender, App.ProcessTime.Result e)
        {
        }
        void TargetEnd(object? sender, App.ProcessTime.Result e)
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
            App.ProcessTime.Instance.EmergencyReset();
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
                RealTimeData = new();
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
            }catch(Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
            }
        }

        private async void testToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //Trace.WriteLine(await RealTimeNote.Instance.getraw("https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_info", "month=7&region=os_asia&uid=807810806&lang=ja-jp"));
            // var info = JsonConvert.DeserializeObject<Root<Model.HoYoLab.TravelersDiary.Infomation.Data>>(await RealTimeNote.Instance.getraw("https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_info", "month=7&region=os_asia&uid=807810806&lang=ja-jp"));

            //List<Model.HoYoLab.TravelersDiary.Detail.List> list = new();
            /*for (int i = 1; i < 9999; i++)
            {
                var detail = JsonConvert.DeserializeObject<Root<Model.HoYoLab.TravelersDiary.Detail.Data>>(await RealTimeNote.Instance.getraw(" https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_detail", $"month=7&current_page={i}&type=2&region=os_asia&uid=807810806&lang=ja-jp"));
                if(detail==null)throw new ArgumentNullException(nameof(detail));
                if (detail.Data == null) throw new InvalidDataException($"API Error - {detail.Message}({detail.Retcode})");
                if (detail.Data.Current_page != i) throw new InvalidDataException($"Current Page is {i} but api was returned {detail.Data.Current_page}");
                if (detail.Data.List.Count == 0) break;
                foreach(var a in detail.Data.List)
                {
                    list.Add(a);
                    //Trace.WriteLine($"[{list.Count}] {a.Time} : {a.Action}({a.Action_id}) x{a.Num}");
                }
                Trace.WriteLine($"Page {i} 取得完了");
            }*/

            //Trace.WriteLine(JsonConvert.SerializeObject(list));

            var user = await account.GetServerAccounts(Account.Servers.os_asia);
            var nowabyss = await account.GetSpiralAbyss(true);
            var oldabyss = await account.GetSpiralAbyss(false);
            var index = await account.GetGameRecords();
            var realtime = await account.GetRealTimeNote();
            var character = await account.GetCharacters();
            var diaryinfo = await account.GetTravelersDiaryInfo();

            //Trace.WriteLine(await RealTimeNote.Instance.getraw("https://bbs-api-os.hoyolab.com/game_record/genshin/api/spiralAbyss", "server=os_asia&role_id=807810806&schedule_type=2&lang=ja-jp"));
            //Trace.WriteLine(Registry.GetAppReg("miHoYo", "Genshin Impact", "GENERAL_DATA_h2389025596"));
        }
    }
}