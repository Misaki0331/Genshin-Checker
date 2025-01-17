using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LiveChartsCore.Defaults;
using System.Collections.ObjectModel;
using Genshin_Checker.resource;
using Genshin_Checker.Window.Popup;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Resource;

namespace Genshin_Checker.Window
{
    public partial class TimeGraph : Form
    {
        readonly System.Windows.Forms.Timer DailyGraphDrawingDelay;

        #region 現在のグラフ指定日
        DateTime TempGraphDay;
        DateTime TempGraphWeek;
        DateTime TempGraphMonth;
        int TempGraphSeason;
        #endregion
        #region 現在のページの累計時間
        TimeSpan TempTotalDay;
        TimeSpan TempTotalWeek;
        TimeSpan TempTotalMonth;
        TimeSpan TempTotalVersion;
        #endregion
        #region グラフ変数ポイント
        private readonly ObservableCollection<ObservableValue> ObservableDayFore = new();
        private readonly ObservableCollection<ObservableValue> ObservableDayBack = new();
        private readonly ObservableCollection<ObservablePoint> ObservableWeekDawn = new();
        private readonly ObservableCollection<ObservablePoint> ObservableWeekMorning = new();
        private readonly ObservableCollection<ObservablePoint> ObservableWeekAfternoon = new();
        private readonly ObservableCollection<ObservablePoint> ObservableWeekNight = new();
        private readonly ObservableCollection<ObservablePoint> ObservableMonth = new();
        private readonly ObservableCollection<ObservablePoint> ObservableVersion = new();
        #endregion
        #region グラフ本体
        private readonly CartesianChart DayChart;
        private readonly CartesianChart WeekChart;
        private readonly CartesianChart MonthChart;
        private readonly CartesianChart VersionChart;
        #endregion
        #region 関連ツール関数
        List<DayCache> DictionaryCache = new();
        DayCache dayCache = new DayCache();
        object CollectionLockObject=new();
        class DayCache
        {
            public DateTime date = DateTime.MinValue;
            public bool IsDateEqual(DateTime diff)
            {
                if (date.Year == diff.Year && date.Month == diff.Month && date.Day == diff.Day) return true;
                return false;
            }
            public string raw = "";
        }
        private async Task<string> GetDayPointCacheData(DateTime date) {
            var now = DateTime.Now;
            if (new DateTime(now.Year, now.Month, now.Day) == new DateTime(date.Year, date.Month, date.Day))
                return await Core.TimeTable.LoadDateLocal(date);
            DayCache? cache = null;
            lock (CollectionLockObject) 
                cache = DictionaryCache.Find(a => a.IsDateEqual(date));
            
            if (cache != null) return cache.raw;
            else
            {
                var data = await Core.TimeTable.LoadDateLocal(date);
                var append = new DayCache();
                append.raw = data;
                append.date = date;
                lock (CollectionLockObject)
                    DictionaryCache.Add(append);
                return data;
            }
        }
        class StateData
        {
            public int EmptyState = 0;
            public int NotRunning = 0;
            public int BackGround = 0;
            public int ForeGround = 0;
        }
        #endregion
        public TimeGraph()
        {
            InitializeComponent();
            Icon = resource.icon.nahida;
            DailyGraphDrawingDelay = new();
            //DailyGraphDrawingDelay.Tick += DailyGraph_Drawing;
            DailyGraphDrawingDelay.Interval = 10;
            dateTimePicker1.MaxDate=DateTime.Now;
            DailyGraphDrawingDelay.Start();
            #region 24時間のデータ
            DayChart = new CartesianChart
            {
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Hours",
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 },
                        SeparatorsAtCenter = false,
                        MinLimit = -0.5,
                        MaxLimit = 23.5,
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Playing Time",
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        MinLimit = 0,
                        MaxLimit = 60,

                        Labeler= d1 => string.Format("{0}:{1:00}",(int)(d1),(int)(d1*60)%60),
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 }
                    }
                },
                Series = new List<ISeries>
                {
                    new StackedColumnSeries<ObservableValue>
                    {
                        Values = ObservableDayFore,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45,0)),
                        DataLabelsSize= 0,
                        Name = "Active",
                        Fill = new SolidColorPaint(SKColors.Green),
        },
                    new StackedColumnSeries<ObservableValue>
                    {
                        Values = ObservableDayBack,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45,0)),
                        DataLabelsSize= 0,
                        Name = "Background",
                        Fill= new SolidColorPaint(SKColors.Orange),
                    } 
                },
                Dock = DockStyle.Fill,
                Size = new(Day.Width, Day.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            Day.SuspendLayout();
            Day.Controls.Add(DayChart);
            Day.ResumeLayout(true);
            #endregion
            #region 1週間のデータ
            WeekChart = new CartesianChart
            {
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Day",
                        MinStep = 1,
                        Labeler = d1 => string.Format(" {0:M/d}", System.DateTime.FromOADate(d1)),
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 },
                        SeparatorsAtCenter = false,
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Playing Time (hours)",
                        Labeler= d1 => string.Format("{0}:{1:00}",(int)(d1),(int)(d1*60)%60),
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        MinLimit = 0,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 }
                    }
                },
                Series = new List<ISeries>
                {
                    new StackedColumnSeries<ObservablePoint>
                    {
                        Values = ObservableWeekDawn,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45,0)),
                        DataLabelsSize= 0,
                        Name = "0:00 - 5:59",
                        Fill = new SolidColorPaint(new SKColor(0xFF000066)),
                    },
                    new StackedColumnSeries<ObservablePoint>
                    {
                        Values = ObservableWeekMorning,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45,0)),
                        DataLabelsSize= 0,
                        Name = "6:00 - 11:59",
                        Fill = new SolidColorPaint(new SKColor(0xFF99CCFF)),
                    },
                    new StackedColumnSeries<ObservablePoint>
                    {
                        Values = ObservableWeekAfternoon,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45,0)),
                        DataLabelsSize= 0,
                        Name = "12:00 - 17:59",
                        Fill = new SolidColorPaint(new SKColor(0xFFFF9933)),
                    },
                    new StackedColumnSeries<ObservablePoint>
                    {
                        Values = ObservableWeekNight,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45,0)),
                        DataLabelsSize= 0,
                        Name = "18:00 - 23:59",
                        Fill = new SolidColorPaint(new SKColor(0xFFFF99CC)),
                    },
                },
                Dock = DockStyle.Fill,
                Size = new(Week.Width, Week.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            Week.SuspendLayout();
            Week.Controls.Add(WeekChart);
            Week.ResumeLayout(true);
            #endregion
            #region 1か月のデータ
            MonthChart = new CartesianChart
            {
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Day",
                        MinStep = 1,
                        Labeler = d1 => string.Format(" {0:M/d}", System.DateTime.FromOADate(d1)),
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 },
                        SeparatorsAtCenter = true,
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Playing Time (hours)",
                        Labeler= d1 => string.Format("{0}:{1:00}",(int)(d1),(int)(d1*60)%60),
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        MinLimit = 0,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 }
                    }
                },
                Series = new List<ISeries>
                {
                    new LineSeries<ObservablePoint>
                    {
                        Values = ObservableMonth,
                        //Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45, 0)),
                        DataLabelsSize= 0,
                        Name = "Active Time",
                        //Fill = new SolidColorPaint(new SKColor(0xFFFF99CC)),
                    },
                },
                Dock = DockStyle.Fill,
                Size = new(Day.Width, Day.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            Month.SuspendLayout();
            Month.Controls.Add(MonthChart);
            Month.ResumeLayout(true);
            #endregion
            #region 1バージョンのデータ
            VersionChart = new CartesianChart
            {
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Day",
                        MinStep = 1,
                        Labeler = d1 => string.Format(" {0:M/d}", System.DateTime.FromOADate(d1)),
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 },
                        SeparatorsAtCenter = true,
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Playing Time (hours)",
                        Labeler= d1 => string.Format("{0}:{1:00}",(int)(d1),(int)(d1*60)%60),
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        MinLimit = 0,
                        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 }
                    }
                },
                Series = new List<ISeries>
                {
                    new LineSeries<ObservablePoint>
                    {
                        Values = ObservableVersion,
                        //Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(0x00000000),
                        DataLabelsSize= 0,
                        Name = "Active Time",
                        //Fill = new SolidColorPaint(new SKColor(0xFFFF99CC)),
                    },
                },
                Dock = DockStyle.Fill,
                Size = new(Day.Width, Day.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            Version.SuspendLayout();
            Version.Controls.Add(VersionChart);
            Version.ResumeLayout(true);
            #endregion

            dateTimePicker1.Value = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    }
        private void DailyGraph_Resize(object sender, EventArgs e)
        {
        }
        private async void DailyGraph_Drawing()
        {
            var day = dateTimePicker1.Value;
            if (new DateTime(day.Year, day.Month, day.Day) != TempGraphDay)
            {
                TempGraphDay = new DateTime(day.Year, day.Month, day.Day);
            }
            else if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) != new DateTime(day.Year, day.Month, day.Day))
            {
                var value = TempTotalDay;
                TotalLabel.Text = $"Total : {(int)value.TotalHours}:{value.Minutes:00}:{value.Seconds:00}";
                return;
            }
            if (!dayCache.IsDateEqual(dateTimePicker1.Value))
            {
                dayCache.date = dateTimePicker1.Value;
                dayCache.raw = await GetDayPointCacheData(dayCache.date);
            }
            var rawdata = dayCache.raw;
            int total = 0;
            List<StateData> stateDatas = new();
            for (int h = 0; h < 24; h++)
            {
                var state = new StateData();
                for (int w = 0; w < 3600; w++)
                {
                    switch (rawdata[h * 3600 + w])
                    {
                        case ' ':
                            state.EmptyState++;
                            break;
                        case '_':
                            state.NotRunning++;
                            break;
                        case 'B':
                            state.BackGround++;
                            break;
                        case 'F':
                            state.ForeGround++;
                            total++;
                            break;
                    }

                }
                stateDatas.Add(state);
            }
            ObservableDayBack.Clear();
            ObservableDayFore.Clear();
            foreach (var s in stateDatas)
            {
                ObservableDayBack.Add(new(s.BackGround / 60.0));
                ObservableDayFore.Add(new(s.ForeGround / 60.0));
            }
            TempTotalDay = new TimeSpan(0, 0, total);

            if (GraphTab.SelectedIndex == 0) TotalLabel.Text = $"Total : {total / 3600}:{(total / 60 % 60):00}:{(total % 60):00}";
        }
        private async void WeekGraph_Drawing()
        {
            var day = dateTimePicker1.Value;
            if (new DateTime(day.Year, day.Month, day.Day) != TempGraphWeek)
            {
                TempGraphWeek = new DateTime(day.Year, day.Month, day.Day);
            }
            else if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) != new DateTime(day.Year, day.Month, day.Day))
            {
                var value = TempTotalWeek;
                TotalLabel.Text = $"Total : {(int)value.TotalHours}:{value.Minutes:00}:{value.Seconds:00}";
                return;
            }
            List<string> weekraw = new();
            var enddate = dateTimePicker1.Value;
            for (int i = -6; i <= 0; i++) 
                weekraw.Add(await GetDayPointCacheData(enddate.AddDays(i)));
            List<List<int>> state = new() { new List<int>(), new List<int>(), new List<int>(), new List<int>()};

            int total = 0;
            for (int d = 0; d < 7; d++)
            {
                for (int i = 0; i < 4; i++) state[i].Add(new());
                for (int h = 0; h < 86400; h++)
                {
                    switch (weekraw[d][h])
                    {
                        case 'F':
                            total++;
                            state[h / (86400 / 4)][d]++;
                            break;
                    }
                }
            }
            ObservableWeekDawn.Clear();
            ObservableWeekMorning.Clear();
            ObservableWeekAfternoon.Clear();
            ObservableWeekNight.Clear();
            for (int i = 0; i < state[0].Count; i++)
            {
                ObservableWeekDawn.Add(new((int)enddate.AddDays(i - 6).ToOADate(), state[0][i] / 3600.0));
                ObservableWeekMorning.Add(new((int)enddate.AddDays(i - 6).ToOADate(), state[1][i] / 3600.0));
                ObservableWeekAfternoon.Add(new((int)enddate.AddDays(i - 6).ToOADate(), state[2][i] / 3600.0));
                ObservableWeekNight.Add(new((int)enddate.AddDays(i - 6).ToOADate(), state[3][i] / 3600.0));
            }
            weekraw.Clear();

            TempTotalWeek = new TimeSpan(0, 0, total);

            if (GraphTab.SelectedIndex == 1) TotalLabel.Text = $"Total : {total / 3600}:{(total / 60 % 60):00}:{(total % 60):00}";
        }
        private async void MonthGraph_Drawing()
        {
            var monthdate = dateTimePicker1.Value;
            if (new DateTime(monthdate.Year, monthdate.Month, 1) != TempGraphMonth)
            {
                TempGraphMonth = new DateTime(monthdate.Year, monthdate.Month, 1);
            }
            else if (new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1) != new DateTime(monthdate.Year, monthdate.Month, 1))
            {
                var value = TempTotalMonth;
                TotalLabel.Text = $"Total : {(int)value.TotalHours}:{value.Minutes:00}:{value.Seconds:00}";
                return;
            }
            List<string> monthraw = new();
            var date = dateTimePicker1.Value;
            var month = new DateTime(date.Year,date.Month,1);
            for (int i = 0; i <= 40; i++)
            {
                if (month.AddDays(i).Month != month.Month) break;
                if (month.AddDays(i)>DateTime.Now) break;
                monthraw.Add(await GetDayPointCacheData(month.AddDays(i)));
            }
            List<int> state = new();
            int total = 0;
            for (int d = 0; d < monthraw.Count; d++)
            {
                int cnt = 0;
                for (int h = 0; h < 86400; h++)
                {
                    if(monthraw[d][h]=='F') cnt++;
                }
                total += cnt;
                state.Add(cnt);
            }
            ObservableMonth.Clear();
            for (int i = 0; i < state.Count; i++)
                ObservableMonth.Add(new((int)month.AddDays(i).ToOADate(), state[i] / 3600.0));
            state.Clear();
            monthraw.Clear();

            TempTotalMonth = new TimeSpan(0, 0, total);

            if (GraphTab.SelectedIndex == 2) TotalLabel.Text = $"Total : {total / 3600}:{(total / 60 % 60):00}:{(total % 60):00}";
        }
        private async void VersionGraph_Drawing()
        {
            var from = new DateTime(2020, 9, 30);
            if (TimeZoneInfo.Local.GetUtcOffset(DateTime.Now) < TimeSpan.Zero) from.AddDays(-1);
            double timezone = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalHours;
            timezone = (24 + timezone) % 24;
            var to = dateTimePicker1.Value;
            int season = ((int)to.ToOADate() - (int)from.ToOADate()) / 42 + 1; //26=4.0
            int currentseason = ((int)DateTime.Now.ToOADate() - (int)from.ToOADate()) / 42 + 1; //26=4.0
            var source = GenshinAsset.SeasonName.Replace("\r","").Split('\n');
            string seasonName = $"Season {season}";
            if (source.Length > season - 1) seasonName= source[season - 1];

            if (season != TempGraphSeason)
            {
                TempGraphSeason = season;
            }
            else if(currentseason!=season)
            {
                var value = TempTotalVersion;
                TotalLabel.Text = $"Total : {(int)value.TotalHours}:{value.Minutes:00}:{value.Seconds:00}";
                return;
            }
            List<string> versionraw = new();
            for (int i = 0; i <= 42; i++)
            {
                if (from.AddDays(42*(season-1)+i) > DateTime.Now) break;
                versionraw.Add(await GetDayPointCacheData(from.AddDays(42 * (season - 1) + i)));
            }
            List<int> state = new();
            int total = 0;
            for (int d = 0; d < versionraw.Count; d++)
            {
                int cnt = 0;
                int start = 0;
                int end = 86400;
                if (d == 0) start = (int)(3600 * timezone);
                if (d == 42) end = (int)(3600 * timezone);
                for (int h = start; h < end; h++)
                {
                    if (versionraw[d][h] == 'F') cnt++;
                }
                total += cnt;
                state.Add(cnt);
            }
            ObservableVersion.Clear();
            for (int i = 0; i < state.Count; i++)
                ObservableVersion.Add(new((int)from.AddDays(42 * (season - 1) + i).ToOADate(), state[i] / 3600.0));
            state.Clear();
            versionraw.Clear();

            TempTotalVersion = new TimeSpan(0, 0, total);

            if (GraphTab.SelectedIndex == 3) TotalLabel.Text = $"Total : {total / 3600}:{(total / 60 % 60):00}:{(total % 60):00}";
        }
        private void Graph_Reload(object sender, EventArgs e)
        {
            try
            {
                switch (GraphTab.SelectedIndex)
                {
                    case 0:
                        DailyGraph_Drawing();
                        Prev.Enabled = dateTimePicker1.MinDate <= dateTimePicker1.Value.AddDays(-1);
                        Next.Enabled = dateTimePicker1.MaxDate >= dateTimePicker1.Value.AddDays(1);
                        FromLabel.Text = Localize.WindowName_TimeGraph_DayName;
                        break;
                    case 1:
                        WeekGraph_Drawing();
                        Prev.Enabled = dateTimePicker1.MinDate <= dateTimePicker1.Value.AddDays(-7);
                        Next.Enabled = dateTimePicker1.MaxDate >= dateTimePicker1.Value.AddDays(7);

                        FromLabel.Text = string.Format(Localize.WindowName_TimeGraph_WeekName,$"{dateTimePicker1.Value.AddDays(-6):yyyy/MM/dd}");
                        break;
                    case 2:
                        MonthGraph_Drawing();
                        Prev.Enabled = dateTimePicker1.MinDate <= dateTimePicker1.Value.AddMonths(-1);
                        Next.Enabled = dateTimePicker1.MaxDate >= dateTimePicker1.Value.AddMonths(1);
                        FromLabel.Text = string.Format(Localize.WindowName_TimeGraph_MonthName, dateTimePicker1.Value.Year,Core.General.LocalizeValue.Convert.MonthShort(dateTimePicker1.Value.Month));
                        break;
                    case 3:
                        VersionGraph_Drawing();
                        var from = new DateTime(2020, 9, 30);
                        if (TimeZoneInfo.Local.GetUtcOffset(DateTime.Now) < TimeSpan.Zero) from.AddDays(-1);
                        double timezone = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalHours;
                        timezone = (24 + timezone) % 24;
                        var to = dateTimePicker1.Value;
                        int season = ((int)to.ToOADate() - (int)from.ToOADate()) / 42 + 1; //26=4.0
                        Prev.Enabled = dateTimePicker1.MinDate <= from.AddDays((season - 1) * 42);
                        Next.Enabled = dateTimePicker1.MaxDate >= from.AddDays((season) * 42);

                        var source = GenshinAsset.SeasonName.Replace("\r", "").Split('\n');
                        string seasonName = $"Season {season}";
                        if (source.Length > season - 1) seasonName = source[season - 1];

                        FromLabel.Text = string.Format(Localize.WindowName_TimeGraph_VersionName, seasonName);
                        break;
                }
            }
            catch (Exception ex)
            {
                var window = new ErrorMessage(Localize.Error_TimeGraph_FailedToDrawGraph, $"{ex.GetType()}\n{ex.Message}");
                window.ShowDialog(this);
            }
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            try {
            switch (GraphTab.SelectedIndex)
            {
                case 0:
                    dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
                    break;
                case 1:
                    dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-7);
                    break;
                case 2:
                    dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(-1);
                    break;
                case 3:
                    var from = new DateTime(2020, 9, 30);
                    if (TimeZoneInfo.Local.GetUtcOffset(DateTime.Now) < TimeSpan.Zero) from.AddDays(-1);
                    double timezone = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalHours;
                    timezone = (24 + timezone) % 24;
                    var to = dateTimePicker1.Value;
                    int season = ((int)to.ToOADate() - (int)from.ToOADate()) / 42 + 1; //26=4.0
                    dateTimePicker1.Value = from.AddDays((season - 1) * 42-1);
                    break;
            }

            }
            catch (Exception ex)
            {
                var window = new ErrorMessage(Localize.Error_TimeGraph_FailedToDrawGraph, $"{ex.GetType()}\n{ex.Message}");
                window.ShowDialog(this);
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            try { 
            switch (GraphTab.SelectedIndex)
            {
                case 0:
                    dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                    break;
                case 1:
                    dateTimePicker1.Value = dateTimePicker1.Value.AddDays(7);
                    break;
                case 2:
                    dateTimePicker1.Value = dateTimePicker1.Value.AddMonths(1);
                    break;
                case 3:
                    var from = new DateTime(2020, 9, 30);
                    if (TimeZoneInfo.Local.GetUtcOffset(DateTime.Now) < TimeSpan.Zero) from.AddDays(-1);
                    double timezone = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalHours;
                    timezone = (24 + timezone) % 24;
                    var to = dateTimePicker1.Value;
                    int season = ((int)to.ToOADate() - (int)from.ToOADate()) / 42 + 1; //26=4.0
                    dateTimePicker1.Value = from.AddDays((season) * 42);
                    break;
            }

            }
            catch (Exception ex)
            {
                var window = new ErrorMessage(Localize.Error_TimeGraph_FailedToDrawGraph, $"{ex.GetType()}\n{ex.Message}");
                window.ShowDialog(this);
            }
        }

        private void Now_Click(object sender, EventArgs e)
        {
            try { 
            if (DateTime.Now > dateTimePicker1.MaxDate) dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            }
            catch (Exception ex)
            {
                var window = new ErrorMessage(Localize.Error_TimeGraph_FailedToDrawGraph, $"{ex.GetType()}\n{ex.Message}");
                window.ShowDialog(this);
            }
        }
    }
}
