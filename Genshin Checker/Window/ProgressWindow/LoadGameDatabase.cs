using Genshin_Checker.Core.Game;
using Genshin_Checker.Core.HoYoLab;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Store;
using Genshin_Checker.Window.Popup;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Genshin_Checker.Window.ProgressWindow
{
    public partial class LoadGameDatabase : Form
    {
        public LoadGameDatabase()
        {
            InitializeComponent();
            PanelProgress.Visible = false;
            PanelSelect.Visible = true;
            foreach (var account in Accounts.Data)
            {
                var name = $"UID:{account.UID}({account.Server}) {account.Name}";
                AccountTemp.Add(name, account);
                ComboHoYoLabAccounts.Items.Add(name);
            }
            if (AccountTemp.Count == 0)
            {
                ExecuteHoYoLab.Enabled = false;
                ComboHoYoLabAccounts.Items.Add(Common.NoAccount);
                ComboHoYoLabAccounts.SelectedIndex = 0;
                ComboHoYoLabAccounts.Enabled = false;
            }
            else ComboHoYoLabAccounts.SelectedIndex = 0;
        }
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(HandleRef hWnd,
    uint Msg, uint wParam, IntPtr lParam);

        private const uint WM_USER = 0x400;
        private const uint PBM_SETSTATE = WM_USER + 16;
        private const uint PBST_NORMAL = 0x0001;
        private const uint PBST_ERROR = 0x0002;
        private const uint PBST_PAUSED = 0x0003;

        bool WillClose = true;
        Dictionary<string,Account> AccountTemp = new();
        private async void LoadGameDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                var authkey = await WebViewWatcher.GetServiceCenterAuthKey();
                if (authkey == null)
                {
                    SessionInfo.Text = Localize.Windowname_LoadGameDatabase_FailedToSessionName;
                    return;
                }
                var database = new GetGameDatabase(authkey);
                var res = await database.Init();
                SessionInfo.Text = $"UID:{database.uid}({database.server}) {database.username}";
            }
            catch(GameAPI.GameAPIException ex)
            {
                SessionInfo.Text = $"{Localize.Windowname_LoadGameDatabase_FailedToSessionName}\n{ex.Retcode} - {ex.APIMessage}";
                return;
            }catch(InvalidDataException)
            {
                SessionInfo.Text = $"{Localize.Windowname_LoadGameDatabase_FailedButInit}";
            }
        }
        int CurrentTask = 0;
        int MaxTask = 0;
        readonly Stopwatch Stopwatch = new();
        private async Task AnalysisExecution(GetGameDatabase database)
        {
            database.ProgressChanged += Database_ProgressChanged;
            database.ProgressCompreted += Database_ProgressCompreted;
            database.ProgressFailed += ProgressFailed;
            List<Func<Task>> tasks = new();
            var snapshot = DateTime.Now;
            int cnt = 0;
            for (DateTime now = snapshot; snapshot.AddMonths(-7) < now; now = now.AddMonths(-1))
            {
                int year = now.Year;
                int month = now.Month;
                tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.MonthlyCard, year, month));
                tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.Crystal, year, month));
                tasks.Add(async () => await database.GetQueryFromDatabase(GetGameDatabase.DataType.ExtraPrimogems, year, month));
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
                    if (IsCancelled) break;
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
                LabelProgressGeneral.Text = Common.Failed;
                LabelProgressDetail.Text = $"";
                new ErrorMessage(Common.CommonErrorOccurred, $"{ex}").ShowDialog();
            }
            if (NoError)
            {
                progressBar1.Value = 10000;
                progressBar2.Value = 10000;
                LabelProgressGeneral.Text = $"{100:0.00}% {Common.Completed}";
                LabelProgressDetail.Text = $"";

                label1.Text = Localize.Windowname_LoadGameDatabase_Complete;
            }
            else
            {
                label1.Text = Localize.Windowname_LoadGameDatabase_Failed;
            }
            Stopwatch.Stop();
            database.ProgressChanged -= Database_ProgressChanged;
            database.ProgressCompreted -= Database_ProgressCompreted;
            database.ProgressFailed -= ProgressFailed;
            WillClose = true;
            Cancel.Text = Common.Close;
            if (IsCancelled)
                Close();
        }

        private async Task AnalysisExecution(Account account)
        {
            List<Func<Task>> tasks = new();
            var snapshot = DateTime.Now;
            account.TravelersDiaryDetail.ProgressChanged += TravelersDiaryDetail_ProgressChanged;
            account.TravelersDiaryDetail.ProgressFailed += ProgressFailed;
            foreach (var month in account.TravelersDiary.Data.Data == null?new List<int> { 0 } :account.TravelersDiary.Data.Data.optional_month)
            {
                tasks.Add(async () => await account.TravelersDiaryDetail.Correct(new List<int> { month }, TravelersDiaryDetail.CorrectMode.Primogems));
                tasks.Add(async () => await account.TravelersDiaryDetail.Correct(new List<int> { month }, TravelersDiaryDetail.CorrectMode.Mora));
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
                    if (IsCancelled) break;
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
                LabelProgressGeneral.Text = Common.Failed;
                LabelProgressDetail.Text = $"";
                new ErrorMessage(Common.CommonErrorOccurred, $"{ex}").ShowDialog();
            }
            if (NoError)
            {
                progressBar1.Value = 10000;
                progressBar2.Value = 10000;
                LabelProgressGeneral.Text = $"{100:0.00}% {Common.Completed}";
                LabelProgressDetail.Text = $"";

                label1.Text = Localize.Windowname_LoadGameDatabase_Complete;
            }
            else
            {
                label1.Text = Localize.Windowname_LoadGameDatabase_Failed;
            }
            Stopwatch.Stop();
            WillClose = true;
            Cancel.Text = Common.Close;
            account.TravelersDiaryDetail.ProgressChanged -= TravelersDiaryDetail_ProgressChanged;
            account.TravelersDiaryDetail.ProgressFailed -= ProgressFailed;
            if (IsCancelled)
                Close();
        }

        private void TravelersDiaryDetail_ProgressChanged(object? sender, TravelersDiaryDetail.ProgressState e)
        {
            LabelProgressDetail.Text = $"{e.Progress * 100:0.00}% Pages:{e.CurrentPage} ";
            double progress2 = e.Progress;
            double progress = (double)(CurrentTask + (double.IsNaN(progress2) ? 0 : progress2)) / MaxTask;
            LabelProgressGeneral.Text = $"{progress * 100.0:0.00}% {e.year}/{e.month}({e.mode})";
            if (progress < 0) progress = 0;
            if (progress > 1) progress = 1;
            if (progress2 < 0) progress2 = 0;
            if (progress2 > 1) progress2 = 1;
            if (double.IsNaN(progress)) progress = 0;
            if (double.IsNaN(progress2)) progress2 = 0;
            progressBar1.Value = (int)(progress * 10000.0);
            progressBar2.Value = (int)(progress2 * 10000.0);
        }

        private void ProgressFailed(object? sender, Exception e)
        {
            new ErrorMessage(Common.CommonErrorOccurred, $"{e}").ShowDialog();
        }

        private void Database_ProgressCompreted(object? sender, EventArgs e)
        {
        }

        private void Database_ProgressChanged(object? sender, GetGameDatabase.ProgressState e)
        {
            LabelProgressDetail.Text = $"Step{e.CompletedTask + 1}/{e.MaxTask} {e.Progress * 100:0.00}%";
            double progress2 = (double)(e.CompletedTask + e.Progress) / (e.MaxTask);
            double progress = (double)(CurrentTask + (double.IsNaN(progress2) ? 0 : progress2)) / MaxTask;
            LabelProgressGeneral.Text = $"{progress * 100.0:0.00}% {e.year}/{e.month}({e.mode})";
            if (progress < 0) progress = 0;
            if (progress > 1) progress = 1;
            if (progress2 < 0) progress2 = 0;
            if (progress2 > 1) progress2 = 1;
            if (double.IsNaN(progress)) progress = 0;
            if (double.IsNaN(progress2)) progress2 = 0;
            progressBar1.Value = (int)(progress * 10000.0);
            progressBar2.Value = (int)(progress2 * 10000.0);
        }

        private void LoadGameDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!WillClose)
            {
                e.Cancel = true;
                Cancel_Click(sender, e);
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            LabelTimer.Text = $"{Stopwatch.Elapsed:h\\:mm\\:ss\\.fff}";
        }
        bool IsCancelled = false;
        private void Cancel_Click(object sender, EventArgs e)
        {
            if (WillClose)
            {
                Close();
                return;
            }

            IsCancelled = true;
            label1.Text = Localize.Windowname_LoadGameDatabase_Cancelled;
        }

        private async void ExecuteGameSession_Click(object sender, EventArgs e)
        {
            WillClose = false;
            var authkey = await WebViewWatcher.GetServiceCenterAuthKey();
            if (authkey == null)
            {
                new ErrorMessage(Localize.Error_LoadGameDatabase_FailedToReadAuth, Localize.Windowname_LoadGameDatabase_AuthkeyTip).ShowDialog();
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
                new ErrorMessage(Localize.Error_LoadGameDatabase_FailedToAuth, $"{Localize.Windowname_LoadGameDatabase_AuthkeyTip}\n{ex.Message}").ShowDialog();
                WillClose = true;
                Close();
                return;
            }
            catch (Exception ex)
            {
                new ErrorMessage(Common.CommonErrorOccurred, $"{ex}").ShowDialog();
                WillClose = true;
                Close();
                return;
            }
            Log.Debug("解析実行開始");
            PanelProgress.Visible = true;
            PanelSelect.Visible = false;
            await AnalysisExecution(database);
        }

        private async void ExecuteHoYoLab_Click(object sender, EventArgs e)
        {
            WillClose = false;
            if (AccountTemp.TryGetValue(ComboHoYoLabAccounts.Text, out var account))
            {
                if (account.IsDisposed)
                {
                    new ErrorMessage(Localize.Error_LoadGameDatabase_AccountDisposed, Localize.Error_LoadGameDatabase_AccountDisposed_Message).ShowDialog();
                    WillClose = true;
                    Close();
                    return;
                }
                PanelProgress.Visible = true;
                PanelSelect.Visible = false;
                LabelUserInfo.Text = $"UID:{account.UID} ({account.Server})\n{account.Name}";
                await AnalysisExecution(account);
            }
        }
    }
}
