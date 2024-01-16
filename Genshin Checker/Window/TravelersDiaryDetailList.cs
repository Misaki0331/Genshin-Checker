using Genshin_Checker.App;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.App.General;
using Genshin_Checker.Model.UserData.TravelersDiary.EventName;
using Genshin_Checker.Model.UserData.TravelersDiary.EventLists;
using Genshin_Checker.Model.UserData.GameDatabase;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using Genshin_Checker.Window.Popup;
using Genshin_Checker.App.General.Convert;
using Genshin_Checker.resource.Languages;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

namespace Genshin_Checker.Window
{
    public partial class TravelersDiaryDetailList : Form
    {
        class ListData
        {
            public string? CrystalPath;
            public string? PrimogemsPath;
            public string? ExPrimogemsPath;
            public string? StarDustPath;
            public string? StarGlitterPath;
            public string? ResinPath;
            public string? MoraPath;
            public int year = int.MinValue;
            public int month = int.MinValue;
        }
        enum Mode
        {
            Primogems = 1,
            Mora = 2,
            Crystal = 3,
            StarDust = 4,
            StarGlitter = 5,
            Resin = 6,
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
            CurrentView.Columns[0].ColumnName = Localize.WindowName_TravelersDiaryDetailList_Name_EventTime;
            CurrentView.Columns[1].ColumnName = Localize.WindowName_TravelersDiaryDetailList_Name_EventTypeID;
            CurrentView.Columns[2].ColumnName = Localize.WindowName_TravelersDiaryDetailList_Name_EventTypeName;
            CurrentView.Columns[3].ColumnName = Localize.WindowName_TravelersDiaryDetailList_Name_ObtainedCount;
            for (int i = 0; i < 4; i++)
            {
                CurrentView.Columns[i].ReadOnly = true;
            }

            InitializeComponent();
            dataGridView1.DataSource = CurrentView;
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].Width = 65; 
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[2].Width = 160;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dataGridView1.Columns[3].Width = 67;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            listtype.Items.Add(Genshin.Primogems);
            listtype.Items.Add(Genshin.Crystal);
            listtype.Items.Add(Genshin.Mora);
            listtype.Items.Add(Genshin.StarDust);
            listtype.Items.Add(Genshin.StarGlitter);
            listtype.Items.Add(Genshin.Resin);
            listtype.SelectedIndex = 0;
            UpdateDataMonth();
            if (monthlist.Items.Count > 0) monthlist.SelectedIndex = 0;
            Text = $"{Localize.WindowName_TravelersDiaryDetail} (UID:{account.UID})";
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
                        ExPrimogemsPath = Registry.GetValue(regPath, $"LatestExtraPrimogemsPath", true),
                        CrystalPath = Registry.GetValue(regPath, $"Latest{Mode.Crystal}Path", true),
                        MoraPath = Registry.GetValue(regPath, $"Latest{Mode.Mora}Path", true),
                        ResinPath = Registry.GetValue(regPath, $"Latest{Mode.Resin}Path", true),
                        StarDustPath = Registry.GetValue(regPath, $"Latest{Mode.StarDust}Path", true),
                        StarGlitterPath = Registry.GetValue(regPath, $"Latest{Mode.StarGlitter}Path", true),
                    };
                    if (data.PrimogemsPath != null || data.MoraPath != null)
                    {
                        PathList.Add(data);
                    }
                    if (data.PrimogemsPath != null && Path.IsPathRooted(data.PrimogemsPath)) Registry.SetValue(regPath, $"Latest{Mode.Primogems}Path", Path.GetFileName(data.PrimogemsPath), true);

                    if (data.MoraPath != null && Path.IsPathRooted(data.MoraPath)) Registry.SetValue(regPath, $"Latest{Mode.Mora}Path", Path.GetFileName(data.MoraPath), true);
                }
            }
            monthlist.Items.Clear();
            foreach (var a in PathList) monthlist.Items.Add(string.Format(Common.FormatYearMonth, a.year, App.General.LocalizeValue.Convert.MonthShort(a.month)));
            if (monthlist.Items.Count > 0) monthlist.SelectedIndex = 0;
        }

        private async void UpdateComboBox(object sender, EventArgs e)
        {
            if (monthlist.SelectedIndex < 0) return;
            if (listtype.SelectedIndex < 0 || listtype.SelectedIndex > 5) return;
            dataGridView1.Visible = false;
            try
            {
                //dataGridView1.Rows.Clear();
                string? path = null;
                string? expath = null;
                switch (listtype.SelectedIndex)
                {
                    case 0:
                        path = PathList[monthlist.SelectedIndex].PrimogemsPath;
                        expath = PathList[monthlist.SelectedIndex].ExPrimogemsPath;
                        break;
                    case 1:
                        expath = PathList[monthlist.SelectedIndex].CrystalPath;
                        break;
                    case 2:
                        expath = PathList[monthlist.SelectedIndex].MoraPath;
                        break;
                    case 3:
                        expath = PathList[monthlist.SelectedIndex].StarDustPath;
                        break;
                    case 4:
                        expath = PathList[monthlist.SelectedIndex].StarGlitterPath;
                        break;
                    case 5:
                        expath = PathList[monthlist.SelectedIndex].ResinPath;
                        break;
                }
                var localeEventPath = $"locale\\{account.Culture.Name.ToLower()}\\";
                var eventpath = Registry.GetValue(localeEventPath, $"EventName", true);

                var gameeventpath = Registry.GetValue("locale", $"GameDatabaseEventName", true);

                var eventlists = new EventName();
                var gameeventlists = new Model.UserData.GameDatabase.NameLocalize.Root();
                var lists = new EventLists();
                var gamelists = new Model.UserData.GameDatabase.ItemNum.Root();
                //カスタマーセンターの方のローカライズを取得
                try
                {
                    if (gameeventpath != null&&AppData.IsExistFile(gameeventpath))
                        gameeventlists = JsonChecker<Model.UserData.GameDatabase.NameLocalize.Root>.Check(await App.General.AppData.LoadUserData(gameeventpath) ?? "{}");
                }
                catch { }
                //HoYoLabの方のローカライズを取得
                try
                {
                    if (eventpath != null&&AppData.IsExistFile(eventpath))
                        eventlists = JsonChecker<EventName>.Check(await App.General.AppData.LoadUserData(eventpath)??"");
                }
                catch { }
                //カスタマーセンターのデータベースを取得
                try
                {
                    if (expath!=null&&AppData.IsExistFile(expath)) gamelists = JsonChecker<Model.UserData.GameDatabase.ItemNum.Root>.Check(await AppData.LoadUserData(expath) ?? "{}");
                }
                catch (Exception)
                {
                    throw;
                }
                //HoYoLabのデータベースを取得
                try
                {
                    if(path != null && AppData.IsExistFile(path))lists = JsonChecker<EventLists>.Check(await AppData.LoadUserData(path)??"{}");
                }
                catch (Exception)
                {
                    throw;
                }
                if (lists == null) throw new ArgumentException(Localize.Error_TravelersDiaryDetailList_InvalidData);
                lists.Details.Sort((a, b) => b.EventTime.CompareTo(a.EventTime));
                dataGridView1.SuspendLayout();
                CurrentView.Rows.Clear();
                //API元がサーバー時間で返しているのでUTCに変換する。
                foreach (var a in lists.Details)
                {
                    var typename = App.General.TravelersDiaryDatailEventConverter.GetEventName(a.EventType, eventlists);
                    CurrentView.Rows.Add(new object[] { Server.ConvertUTCTime(account.Server,a.EventTime), a.EventType, typename, a.Count });
                }
                bool IsEventIDChanged = false;
                foreach (var a in gamelists.Details)
                {
                    var id = a.EventTypeID == int.MinValue ? GameDataStringToEventID.GetIDFromString(a.EventType) : a.EventTypeID;
                    if (a.Count < 0 || id!=int.MinValue||lists.Details.Find(b=>b.EventTime==a.EventTime)==null)
                    {
                        if (id != a.EventTypeID)
                        {
                            IsEventIDChanged=true;
                            a.EventTypeID = id;
                        }
                        var typename = App.General.TravelersDiaryDatailEventConverter.GetEventName(a.EventTypeID, a.EventType, gameeventlists);
                        CurrentView.Rows.Add(new object[] { Server.ConvertUTCTime(account.Server, a.EventTime), a.EventTypeID, typename, a.Count });
                    }
                }
                lists.Details.Clear();
                if (IsEventIDChanged&&expath!=null)
                    await App.General.AppData.SaveUserData(expath, JsonConvert.SerializeObject(gamelists));
                gamelists.Details.Clear();
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
                dataGridView1.ResumeLayout(true); 
            }
            catch(Exception ex)
            {
                new ErrorMessage(Localize.Error_TravelersDiaryDetailList_FailedToLoadDatabase, $"{ex}").ShowDialog();
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
            toolStripStatusLabel1.Text = $"{p:0.0}% {string.Format(Localize.WindowName_TravelersDiaryDetailList_Downloading, e.month == 0 ? Localize.WindowName_TravelersDiaryDetailList_Downloading_ThisMonth : App.General.LocalizeValue.Convert.MonthShort(e.month),e.mode,e.CurrentPage)}";

        }
        private void TravelersDiaryDetail_ProgressCompreted(object? sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Common.Completed;
            toolStripProgressBar1.Value = 10000;
            UpdateComboBox("", EventArgs.Empty);
        }

        private void TravelersDiaryDetail_ProgressFailed(object? sender, Exception e)
        {
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = $"{Common.Failed} ({e.Message})";
        }
        private void TravelersDiaryDetailList_FormClosed(object sender, FormClosedEventArgs e)
        {

            account.TravelersDiaryDetail.ProgressChanged -= TravelersDiaryDetail_ProgressChanged;
            account.TravelersDiaryDetail.ProgressFailed -= TravelersDiaryDetail_ProgressFailed;
            account.TravelersDiaryDetail.ProgressCompreted -= TravelersDiaryDetail_ProgressCompreted;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
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
                    case 1:
                        var id = e.Value as int?;
                        if (id != null)
                        {
                            if (id == int.MinValue)
                            {
                                e.CellStyle.ForeColor = Color.Red;
                                e.Value = "不明";
                            }
                        }
                        break;
                    case 3:
                        e.Value = $"{e.Value:#,##0}";
                        e.FormattingApplied = true;
                        break;
                }
            }catch(Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        private void cSV出力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = Localize.WindowName_TravelersDiaryDetailList_SaveToCsv_Filter;
            saveFileDialog1.Title = Localize.WindowName_TravelersDiaryDetailList_SaveToCsv_Title;
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
                new ErrorMessage(Localize.Error_TravelersDiaryDetailList_FailedToCsvOutput, $"{ex}").ShowDialog();
            }
        }
    }
}
