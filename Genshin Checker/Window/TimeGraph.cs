using LiveChartsCore.SkiaSharpView.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using LiveChartsCore;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LiveChartsCore.Defaults;
using System.Collections.ObjectModel;
using LiveChartsCore.Drawing;

namespace Genshin_Checker.Window
{
    public partial class TimeGraph : Form
    {
        readonly System.Windows.Forms.Timer DailyGraphDrawingDelay;
        private readonly ObservableCollection<ObservableValue> ObservableDayFore = new();
        private readonly ObservableCollection<ObservableValue> ObservableDayBack = new();
        private readonly ObservableCollection<ObservablePoint> ObservableWeekDawn = new();
        private readonly ObservableCollection<ObservablePoint> ObservableWeekMorning = new();
        private readonly ObservableCollection<ObservablePoint> ObservableWeekAfternoon = new();
        private readonly ObservableCollection<ObservablePoint> ObservableWeekNight = new();

        private readonly CartesianChart DayChart;
        private readonly CartesianChart WeekChart;
        private class DateModel
        {
            public DateTime DateTime { get; set; }
            public double Value { get; set; }
        }
        List<Label> Labels = new();
        object DrawingObject = new();
        List<DayCache> DictionaryCache = new();
        DayCache dayCache = new DayCache();
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
                return await App.TimeTable.LoadDateLocal(date);
            var cache = DictionaryCache.Find(a => a.IsDateEqual(date));
            if(cache!=null)return cache.raw;
            else
            {
                var data = await App.TimeTable.LoadDateLocal(date);
                var append = new DayCache();
                append.raw = data;
                append.date = date;
                DictionaryCache.Add(append);
                return data;
            }

                
            
        }
        public TimeGraph()
        {
            InitializeComponent();
            DailyGraphDrawingDelay = new();
            //DailyGraphDrawingDelay.Tick += DailyGraph_Drawing;
            DailyGraphDrawingDelay.Interval = 10;

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
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
                        DataLabelsSize= 0,
                        Name = "Active",
                        Fill = new SolidColorPaint(SKColors.Green),
        },
                    new StackedColumnSeries<ObservableValue>
                    {
                        Values = ObservableDayBack,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
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
                        Labeler = d1 => string.Format(" {0:M/dd}", System.DateTime.FromOADate(d1)),
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
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
                        DataLabelsSize= 0,
                        Name = "0:00 - 5:59",
                        Fill = new SolidColorPaint(new SKColor(0xFF000066)),
                    },
                    new StackedColumnSeries<ObservablePoint>
                    {
                        Values = ObservableWeekMorning,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
                        DataLabelsSize= 0,
                        Name = "6:00 - 11:59",
                        Fill = new SolidColorPaint(new SKColor(0xFF99CCFF)),
                    },
                    new StackedColumnSeries<ObservablePoint>
                    {
                        Values = ObservableWeekAfternoon,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
                        DataLabelsSize= 0,
                        Name = "12:00 - 17:59",
                        Fill = new SolidColorPaint(new SKColor(0xFFFF9933)),
                    },
                    new StackedColumnSeries<ObservablePoint>
                    {
                        Values = ObservableWeekNight,
                        Stroke = null,
                        DataLabelsPaint = new SolidColorPaint(new SKColor(45, 45, 45)),
                        DataLabelsSize= 0,
                        Name = "18:00 - 23:59",
                        Fill = new SolidColorPaint(new SKColor(0xFFFF99CC)),
                    },
                },
                Dock = DockStyle.Fill,
                Size = new(Day.Width, Day.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            Week.SuspendLayout();
            Week.Controls.Add(WeekChart);
            Week.ResumeLayout(true);
            #endregion
            DailyGraph_Drawing();

            WeekGraph_Drawing();

        }
        class StateData
        {
            public int EmptyState = 0;
            public int NotRunning = 0;
            public int BackGround = 0;
            public int ForeGround = 0;
        }
        private void DailyGraph_Resize(object sender, EventArgs e)
        {
        }
        private async void DailyGraph_Drawing()
        {
            DailyGraphDrawingDelay.Stop();
            if (!dayCache.IsDateEqual(dateTimePicker1.Value))
            {
                dayCache.date = dateTimePicker1.Value;
                dayCache.raw = await GetDayPointCacheData(dayCache.date);
            }
            var rawdata = dayCache.raw;
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
                            break;
                    }

                }
                stateDatas.Add(state);
            }
            if (ObservableDayBack.Count != stateDatas.Count)
            {
                ObservableDayBack.Clear();
                ObservableDayFore.Clear();
                double a = 0.5;
                foreach (var s in stateDatas)
                {
                    ObservableDayBack.Add(new(s.BackGround / 60.0));
                    ObservableDayFore.Add(new(s.ForeGround / 60.0));
                    a += 1;
                }
            }
            else
            {
                for (int i = 0; i < stateDatas.Count; i++)
                {
                    ObservableDayBack[i].Value = stateDatas[i].BackGround / 60.0;
                    ObservableDayFore[i].Value = stateDatas[i].ForeGround / 60.0;
                }
            }

        }
        private async void WeekGraph_Drawing()
        {
            List<string> weekraw = new();
            var enddate = dateTimePicker1.Value;
            for (int i = -6; i <= 0; i++) 
                weekraw.Add(await GetDayPointCacheData(enddate.AddDays(i)));
            List<List<int>> state = new() { new List<int>(), new List<int>(), new List<int>(), new List<int>()};
            for (int d = 0; d < 7; d++)
            {
                for (int i = 0; i < 4; i++) state[i].Add(new());
                for (int h = 0; h < 86400; h++)
                {
                    switch (weekraw[d][h])
                    {
                        case 'F':
                            state[h / (86400 / 4)][d]++;
                            break;
                    }
                }
            }

            if (ObservableWeekDawn.Count != state[0].Count)
            {
                ObservableDayBack.Clear();
                ObservableDayFore.Clear();
                double a = 0.5;
                for (int i = 0; i < state[0].Count;i++)
                {
                    ObservableWeekDawn.Add(new(enddate.AddDays(i - 6).ToOADate(),state[0][i] / 3600.0));
                    ObservableWeekMorning.Add(new(enddate.AddDays(i - 6).ToOADate(), state[1][i] / 3600.0));
                    ObservableWeekAfternoon.Add(new(enddate.AddDays(i - 6).ToOADate(), state[2][i] / 3600.0));
                    ObservableWeekNight.Add(new(enddate.AddDays(i - 6).ToOADate(), state[3][i] / 3600.0));
                }
            }
            else
            {
                for (int i = 0; i < state[0].Count; i++)
                {
                    ObservableWeekDawn[i]=new(enddate.AddDays(i - 6).ToOADate(), state[0][i] / 3600.0);
                    ObservableWeekMorning[i]=new(enddate.AddDays(i - 6).ToOADate(), state[1][i] / 3600.0);
                    ObservableWeekAfternoon[i]=new(enddate.AddDays(i - 6).ToOADate(), state[2][i] / 3600.0);
                    ObservableWeekNight[i]=new(enddate.AddDays(i - 6).ToOADate(), state[3][i] / 3600.0);
                }
            }

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DailyGraph_Drawing();
            WeekGraph_Drawing();
        }
    }
}
