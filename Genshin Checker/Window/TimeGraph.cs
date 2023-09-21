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

namespace Genshin_Checker.Window
{
    public partial class TimeGraph : Form
    {
        readonly System.Windows.Forms.Timer DailyGraphDrawingDelay;
        private readonly ObservableCollection<ObservableValue> ObservableDayFore= new();
        private readonly ObservableCollection<ObservableValue> ObservableDayBack= new();
        List<Label> Labels = new();
        object DrawingObject = new();
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
        private readonly CartesianChart DayChart;
        public TimeGraph()
        {
            InitializeComponent();
            DailyGraphDrawingDelay = new();
            //DailyGraphDrawingDelay.Tick += DailyGraph_Drawing;
            DailyGraphDrawingDelay.Interval = 10;

            DailyGraphDrawingDelay.Start();
            
            DayChart = new CartesianChart
            {
                
                XAxes = new Axis[]
{
    new Axis
    {
        Name = "Hours",
        NamePaint = new SolidColorPaint(SKColors.Black),
        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 },
        MinLimit=-0.5,
        MaxLimit=23.5,
    }
},
                YAxes = new Axis[]
{
    new Axis
    {
        Name = "Playing Time (mins)",
        NamePaint = new SolidColorPaint(SKColors.Black),
        MinLimit= 0,
        MaxLimit=60,
        SeparatorsPaint = new SolidColorPaint(SKColors.LightSlateGray) { StrokeThickness = 1 }
    }
},
                Series = new List<ISeries>{
        new StackedColumnSeries<ObservableValue>
        {
            Values = ObservableDayFore,
            Stroke = null,
            DataLabelsPaint = new SolidColorPaint(new SKColor(45, 0, 0)),
            DataLabelsSize= 0,
            Name = "Active"
        },
        new StackedColumnSeries<ObservableValue>
        {
            Values = ObservableDayBack,
            Stroke = null,
            DataLabelsPaint = new SolidColorPaint(new SKColor(0, 0, 45)),
            DataLabelsSize= 0,
            Name = "Background"
        } },
                // out of livecharts properties...
                Dock = DockStyle.Fill,
                Size = new(Day.Width, Day.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };
            Day.SuspendLayout();
            Day.Controls.Add(DayChart);
            Day.ResumeLayout(true);
            DailyGraph_Drawing();

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
        private Brush GetStateColor(App.ProcessTime.ProcessState State)
        {
            return State switch
            {
                App.ProcessTime.ProcessState.NotRunning => Brushes.Gray,
                App.ProcessTime.ProcessState.Background => Brushes.Orange,
                App.ProcessTime.ProcessState.Foreground => Brushes.Green,
                _ => Brushes.Black,
            };
        }
        private async void DailyGraph_Drawing()
        {
            Trace.WriteLine(DateTime.Now);
            DailyGraphDrawingDelay.Stop();
            if (!dayCache.IsDateEqual(dateTimePicker1.Value))
            {
                dayCache.date = dateTimePicker1.Value;
                dayCache.raw = await App.TimeTable.LoadDateLocal(dateTimePicker1.Value);
            }
            var rawdata = dayCache.raw;

            Trace.WriteLine(DateTime.Now);
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
                double a = 0.5;
                foreach (var s in stateDatas)
                {
                    ObservableDayBack.Add(new(s.BackGround / 60.0));
                    ObservableDayFore.Add(new(s.ForeGround / 60.0));
                    a += 1;
                }
            }
            else {
                for (int i = 0; i < stateDatas.Count; i++)
                {
                    ObservableDayBack[i].Value = stateDatas[i].BackGround / 60.0;
                    ObservableDayFore[i].Value = stateDatas[i].ForeGround / 60.0;
                }
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DailyGraph_Drawing();
        }
    }
}
