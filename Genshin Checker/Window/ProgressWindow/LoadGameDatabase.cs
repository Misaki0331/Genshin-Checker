using Genshin_Checker.App.Game;
using Genshin_Checker.Window.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Genshin_Checker.Window.ProgressWindow
{
    public partial class LoadGameDatabase : Form
    {
        public LoadGameDatabase()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(HandleRef hWnd,
    uint Msg, uint wParam, IntPtr lParam);

        private const uint WM_USER = 0x400;
        private const uint PBM_SETSTATE = WM_USER + 16;
        private const uint PBST_NORMAL = 0x0001;
        private const uint PBST_ERROR = 0x0002;
        private const uint PBST_PAUSED = 0x0003;

        bool WillClose = false;
        private async void LoadGameDatabase_Load(object sender, EventArgs e)
        {
            var authkey = await WebViewWatcher.GetServiceCenterAuthKey();
            if (authkey == null)
            {
                new ErrorMessage("ゲームの認証キーを取得できませんでした。", "この機能を使用するにはゲーム内でログインし、パイモンのメニューから報告ボタンをクリックしてください。\n報告ボタンをクリックした後新しくブラウザが立ち上がりますが閉じても問題ありません。").ShowDialog();
                WillClose = true;
                Close();
                return;
            }
            var database = new GetGameDatabase(authkey);
            try
            {
                var res = await database.Init();
                LabelUserInfo.Text = $"UID:{database.uid} ({database.server})\n{database.username}";
            }
            catch (GameAPI.GameAPIException ex)
            {
                new ErrorMessage($"アカウント認証に失敗しました。", $"この機能を使用するにはゲーム内でログインし、パイモンのメニューから報告ボタンをクリックしてください。\n報告ボタンをクリックした後新しくブラウザが立ち上がりますが閉じても問題ありません。\n{ex.Message}").ShowDialog();
                WillClose = true;
                Close();
                return;
            }
            catch (Exception ex)
            {
                new ErrorMessage("エラーが発生しました。", $"{ex}").ShowDialog();
                WillClose = true;
                Close();
                return;
            }
            Trace.WriteLine("解析実行開始");
            await AnalysisExecution(database);
        }
        int CurrentTask = 0;
        int MaxTask = 0;
        Stopwatch Stopwatch = new();
        private async Task AnalysisExecution(GetGameDatabase database)
        {
            database.ProgressChanged += Database_ProgressChanged;
            database.ProgressCompreted += Database_ProgressCompreted;
            database.ProgressFailed += Database_ProgressFailed;
            List<Func<Task>> tasks = new();
            var snapshot = DateTime.Now;
            int cnt = 0;
            for (DateTime now = snapshot; snapshot.AddMonths(-7) < now; now = now.AddMonths(-1))
            {
                int year = now.Year;
                int month = now.Month;
                tasks.Add(async()=>await database.GetQueryFromDatabase(GetGameDatabase.DataType.MonthlyCard, year, month));
                tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.Crystal, year, month));
                tasks.Add(async()=>await database.GetQueryFromDatabase(GetGameDatabase.DataType.ExtraPrimogems, year, month));
                tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.Resin, year, month));
                if (cnt <= 3)
                {
                    tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.StarDust, year, month));
                    tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.StarGlitter, year, month));
                }
                tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.Weapon, year, month));
                tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.Artifact, year, month));
                cnt++;
            }
            CurrentTask = 0;
            MaxTask = tasks.Count;
            Stopwatch.Start();
            bool NoError = false;
            try
            {
                foreach (var task in tasks)
                {
                    await task();
                    CurrentTask++;
                }
                NoError = true;
            }
            catch (Exception ex)
            {
                if (progressBar1.IsHandleCreated)
                {
                    SendMessage(new HandleRef(progressBar1, progressBar1.Handle),
                        PBM_SETSTATE, PBST_ERROR, IntPtr.Zero);
                }
                if (progressBar2.IsHandleCreated)
                {
                    SendMessage(new HandleRef(progressBar2, progressBar2.Handle),
                        PBM_SETSTATE, PBST_ERROR, IntPtr.Zero);
                }
                LabelProgressGeneral.Text = $"失敗";
                LabelProgressDetail.Text = $"";
                new ErrorMessage("データベース取得中にエラーが発生しました。", $"{ex}").ShowDialog();
            }
            if (NoError)
            {
                progressBar1.Value = 10000;
                progressBar2.Value = 10000;
                LabelProgressGeneral.Text = $"100.00% 完了";
                LabelProgressDetail.Text = $"";

                label1.Text = "データの取得が完了しました。";
            }
            else
            {
                label1.Text = "正常に取得できませんでした。";
            }
            Stopwatch.Stop();
            database.ProgressChanged -= Database_ProgressChanged;
            database.ProgressCompreted -= Database_ProgressCompreted;
            database.ProgressFailed -= Database_ProgressFailed;
            WillClose = true;
        }

        private void Database_ProgressFailed(object? sender, Exception e)
        {
            new ErrorMessage("取得エラー", $"{e}").ShowDialog();
        }

        private void Database_ProgressCompreted(object? sender, EventArgs e)
        {
        }

        private void Database_ProgressChanged(object? sender, GetGameDatabase.ProgressState e)
        {
            LabelProgressDetail.Text = $"Step{e.CompletedTask + 1}/{e.MaxTask} {e.Progress * 100:0.00}%";
            double progress2 = (double)(e.CompletedTask + e.Progress) / (e.MaxTask);
            LabelProgressGeneral.Text = $"{(double)(CurrentTask + progress2) / MaxTask * 100.0:0.00}% {e.year}/{e.month}({e.mode})";
            double progress = (double)(CurrentTask + (double.IsNaN(progress2)?0:progress2)) / MaxTask;
            if (progress < 0) progress = 0;
            if (progress > 1) progress = 1;
            if (progress2 < 0) progress2 = 0;
            if (progress2 > 1) progress2 = 1;
            if(double.IsNaN(progress)) progress = 0;
            if(double.IsNaN(progress2)) progress2 = 0;
            progressBar1.Value = (int)(progress * 10000.0);
            progressBar2.Value = (int)(progress2 * 10000.0);
        }

        private void LoadGameDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!WillClose) e.Cancel = true;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            LabelTimer.Text = $"{Stopwatch.Elapsed:h\\:mm\\:ss\\.fff}";
        }
    }
}
