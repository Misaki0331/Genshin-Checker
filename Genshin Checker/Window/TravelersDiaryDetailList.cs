using Genshin_Checker.App;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.App.General;
using Genshin_Checker.Model.UserData.TravelersDiary.EventName;
using Genshin_Checker.Model.UserData.TravelersDiary.EventLists;
using HarfBuzzSharp;
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
        DataTable CurrentView;
        public TravelersDiaryDetailList(Account account)
        {
            this.account = account;
            PathList = new();
            CurrentView= new DataTable();
            CurrentView.Columns.Add("EventTime",typeof(DateTime));
            CurrentView.Columns.Add("EventTypeID",typeof(int));
            CurrentView.Columns.Add("EventTypeName",typeof(string));
            CurrentView.Columns.Add("ObtainedCount",typeof(int));
            CurrentView.Columns[0].ColumnName = "取得時刻";
            CurrentView.Columns[1].ColumnName = "分類ID";
            CurrentView.Columns[2].ColumnName = "分類名";
            CurrentView.Columns[3].ColumnName = "取得数";
            for (int i = 0; i < 4; i++)
            {
                CurrentView.Columns[i].ReadOnly = true;
            }

            InitializeComponent();
            dataGridView1.DataSource = CurrentView;
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 65; 
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 67;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            listtype.Items.Add("原石");
            listtype.Items.Add("モラ");
            listtype.SelectedIndex = 0;
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
            PathList.Clear();
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
            if (monthlist.Items.Count > 0) monthlist.SelectedIndex = 0;
        }

        private async void UpdateComboBox(object sender, EventArgs e)
        {
            if (monthlist.SelectedIndex < 0) return;
            if (listtype.SelectedIndex < 0 || listtype.SelectedIndex > 1) return;
            dataGridView1.Visible = false;
            try
            {
                //dataGridView1.Rows.Clear();
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
                var eventlists = new EventName();
                var lists = new EventLists();
                if (path == null) throw new ArgumentException($"{monthlist.SelectedText}に対応する{(listtype.SelectedIndex==0?"原石":"モラ")}データが見つかりませんでした。");
                try
                {
                    if(eventpath!=null)eventlists = JsonConvert.DeserializeObject<EventName>(await App.General.AppData.LoadFileData(eventpath));
                }
                catch {}
                try
                {
                    lists = JsonConvert.DeserializeObject<EventLists>(await App.General.AppData.LoadFileData(path));
                }
                catch (FileNotFoundException) { }
                catch (Exception)
                {
                    throw;
                }
                if (lists == null) throw new ArgumentException("データが不整合です。");
                lists.Details.Sort((a, b) => b.EventTime.CompareTo(a.EventTime));
                dataGridView1.SuspendLayout();
                CurrentView.Rows.Clear();
                //API元がCSTで返しているのでUTCに変換する。
                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");
                foreach (var a in lists.Details)
                {
                    var typename = App.General.TravelersDiaryDatailEventConverter.GetEventName(a.EventType, eventlists);
                    CurrentView.Rows.Add(new object[] { TimeZoneInfo.ConvertTimeToUtc(a.EventTime, cstZone), a.EventType, typename, a.Count });
                    //dataGridView1.Rows.Add($"{a.EventTime:yyyy/MM/dd(ddd) HH:mm:ss}", $"{a.EventType}",typename,$"{a.Count}");
                }
                lists.Details.Clear();
                dataGridView1.ResumeLayout(true);
            }
            catch(Exception ex)
            {
                new ErrorMessage("データベースを読み込めませんでした。", $"{ex}").ShowDialog();
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
            UpdateDataMonth();
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Color col = Color.White;
            var type = dataGridView1.Rows[e.RowIndex].Cells[1];
            if (type != null)
            {
                switch (App.General.TravelersDiaryDatailEventConverter.GetEventType((int)type.Value))
                {
                    case TravelersDiaryDatailEventConverter.EventType.Mail:
                        col = Color.FromArgb(0xCC, 0xAA, 0xFF);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.Adventure:
                        col = Color.FromArgb(0xFF, 0xBB, 0xBB);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.Daily:
                        col = Color.FromArgb(0xFF, 0xEE, 0xBB);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.SpirialAbyss:
                        col = Color.FromArgb(0xBB, 0xFF, 0xBB);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.Quest:
                        col = Color.FromArgb(0xBB, 0xDD, 0xFF);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.Event:
                        col = Color.FromArgb(0xBB, 0xBB, 0xEE);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.Achievement:
                        col = Color.FromArgb(0xFF, 0xDD, 0xBB);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.Enemy:
                        col = Color.FromArgb(0xFF, 0xDD, 0xDD);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.AdventureExperience:
                        col = Color.FromArgb(0xAA, 0xFF, 0xAA);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.Reputation:
                        col = Color.FromArgb(0xFF, 0xFF, 0xCC);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.RandomQuest:
                        col = Color.FromArgb(0xBB, 0xFF, 0xFF);
                        break;
                    case TravelersDiaryDatailEventConverter.EventType.Domains:
                        col = Color.FromArgb(0xDD, 0xEE, 0xFF);
                        break;


                }
            }
            e.CellStyle.BackColor = col;
            switch (e.ColumnIndex)
            {
                case 0:
                    var time = e.Value as DateTime?;
                    if (time != null)
                        e.Value = $"{TimeZoneInfo.ConvertTimeFromUtc((DateTime)time, TimeZoneInfo.Local):yyyy/MM/dd(ddd) HH:mm:ss}";
                    else e.Value = "----/--/--(---) --:--:--";
                    e.FormattingApplied = true;
                    break;
                case 3:
                    e.Value = $"{e.Value:#,##0}";
                    e.FormattingApplied = true;
                    break;
            }
        }

        private void cSV出力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Comma Separated Values (*.csv)|*.csv|すべてのファイル (*.*)|*.*";
            saveFileDialog1.Title = "保存先を選択してください。";
            saveFileDialog1.CheckPathExists = false;
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); 
                    using StreamWriter sw = new(saveFileDialog1.FileName, false, Encoding.GetEncoding("Shift_JIS"));
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        if (i != 0) sw.Write(",");
                        sw.Write(dataGridView1.Columns[i].Name);
                    }
                    sw.Write(Environment.NewLine);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (j != 0) sw.Write(",");
                            var data = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            sw.Write(data == null ? "null" : data.Contains(',') ? $"\"{data}\"" : data);
                        }
                        sw.Write(Environment.NewLine);
                    }
                    sw.Close();
                }
            }catch(Exception ex)
            {
                new ErrorMessage("出力に失敗しました。",$"{ex}").ShowDialog();
            }
        }
    }
}
