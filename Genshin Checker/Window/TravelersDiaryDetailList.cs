using Genshin_Checker.App;
using Genshin_Checker.App.HoYoLab;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Genshin_Checker.Window.ProgressWindow.LoadTravelersDiaryDetail;

namespace Genshin_Checker.Window
{
    public partial class TravelersDiaryDetailList : Form
    {
        class ListData
        {
            public string? PrimogemsPath;
            public string? MoraPath;
            public int year = int.MinValue;
            public int month = int.MinValue;
        }
        enum Mode
        {
            Primogems = 1,
            Mora = 2,
        }
        List<ListData> PathList;
        public TravelersDiaryDetailList(Account account)
        {
            InitializeComponent();
            this.account = account;
            listtype.Items.Add("原石");
            listtype.Items.Add("モラ");
            listtype.SelectedIndex = 0;
            PathList = new();
            UpdateDataMonth();
            if (monthlist.Items.Count > 0) monthlist.SelectedIndex = 0;
            Text = $"旅人通帳 (UID:{account.UID})";
            Icon = Icon.FromHandle(resource.icon.Icon_TravelerDirty.GetHicon());
            account.TravelersDiaryDetail.ProgressChanged += TravelersDiaryDetail_ProgressChanged;
            account.TravelersDiaryDetail.ProgressFailed += TravelersDiaryDetail_ProgressFailed;
            account.TravelersDiaryDetail.ProgressCompreted += TravelersDiaryDetail_ProgressCompreted;

        }

        Account account;
        private void UpdateDataMonth()
        {
            for(int year = DateTime.Now.Year; year >= 2023; year--)
            {
                for (int month = 12; month >= 1; month--)
                {
                    var regPath = $"UserData\\{account.UID}\\Date\\{year}\\{month:00}\\";
                    var data = new ListData()
                    {
                        year = year,
                        month = month,
                        PrimogemsPath = Registry.GetValue(regPath, $"Latest{Mode.Primogems}Path", true),
                        MoraPath = Registry.GetValue(regPath, $"Latest{Mode.Mora}Path", true)
                    };
                    if (data.PrimogemsPath != null || data.MoraPath != null)
                    {
                        PathList.Add(data);
                    }
                }
            }
            monthlist.Items.Clear();
            foreach (var a in PathList) monthlist.Items.Add($"{a.year}年{a.month:00}月");
        }

        private async void UpdateComboBox(object sender, EventArgs e)
        {
            if (monthlist.SelectedIndex < 0) return;
            if (listtype.SelectedIndex < 0 || listtype.SelectedIndex > 1) return;
            dataGridView1.Visible = false;
            try
            {
                dataGridView1.Rows.Clear();
                string? path = null;
                switch (listtype.SelectedIndex)
                {
                    case 0:
                        path = PathList[monthlist.SelectedIndex].PrimogemsPath;
                        break;
                    case 1:
                        path = PathList[monthlist.SelectedIndex].MoraPath;
                        break;
                }
                var localeEventPath = $"locale\\{account.Culture.Name.ToLower()}\\";
                var eventpath = Registry.GetValue(localeEventPath, $"EventName", true);
                var eventlists = new Model.UserData.TravelersDiary.EventName.Root();
                var lists = new Model.UserData.TravelersDiary.Lists.Root();
                if (path == null) throw new ArgumentException($"{monthlist.SelectedText}に対応する{(listtype.SelectedIndex==0?"原石":"モラ")}データが見つかりませんでした。");
                try
                {
                    if(eventpath!=null)eventlists = JsonConvert.DeserializeObject<Model.UserData.TravelersDiary.EventName.Root>(await App.General.AppData.LoadFileData(eventpath));
                }
                catch {}
                try
                {
                    lists = JsonConvert.DeserializeObject<Model.UserData.TravelersDiary.Lists.Root>(await App.General.AppData.LoadFileData(path));
                }
                catch (Exception)
                {
                    throw;
                }
                if (lists == null) throw new ArgumentException("データが不整合です。");
                lists.Details.Sort((a, b) => b.EventTime.CompareTo(a.EventTime));
                dataGridView1.SuspendLayout();
                foreach(var a in lists.Details)
                {
                    var typename = App.General.TravelersDiaryDatailEventConverter.GetEventName(a.EventType, eventlists);
                    dataGridView1.Rows.Add($"{a.EventTime:yyyy/MM/dd(ddd) HH:mm:ss}", $"{a.EventType}",typename,$"{a.Count}");
                }
                lists.Details.Clear();
                dataGridView1.ResumeLayout(true);
            }
            catch(Exception ex)
            {
                new ErrorMessage("データベースを読み込めませんでした。", $"{ex.Message}\n{ex.GetType()}").ShowDialog();
            }
            finally
            {
                dataGridView1.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new Window.ProgressWindow.LoadTravelersDiaryDetail(account, Window.ProgressWindow.LoadTravelersDiaryDetail.Mode.All, account.TravelersDiary.Data.Data?.optional_month);
            a.ShowDialog();
        }

        private void TravelersDiaryDetail_ProgressChanged(object? sender, TravelersDiaryDetail.ProgressState e)
        {
            double p = e.Progress;
            if (p < 0) p = 0;
            if (p > 100) p = 100;
            toolStripProgressBar1.Value = (int)p * 100;
            toolStripStatusLabel1.Text = $"{p:0.0}% {(e.month == 0 ? "今" : $"{e.month}")}月分の{e.mode}({e.CurrentPage}ページ目)取得中...";

        }
        private void TravelersDiaryDetail_ProgressCompreted(object? sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "完了";
            toolStripProgressBar1.Value = 10000;
            UpdateComboBox("", EventArgs.Empty);
        }

        private void TravelersDiaryDetail_ProgressFailed(object? sender, Exception e)
        {
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = $"失敗 ({e.Message})";
        }
        private void TravelersDiaryDetailList_FormClosed(object sender, FormClosedEventArgs e)
        {

            account.TravelersDiaryDetail.ProgressChanged -= TravelersDiaryDetail_ProgressChanged;
            account.TravelersDiaryDetail.ProgressFailed -= TravelersDiaryDetail_ProgressFailed;
            account.TravelersDiaryDetail.ProgressCompreted -= TravelersDiaryDetail_ProgressCompreted;
        }
    }
}
