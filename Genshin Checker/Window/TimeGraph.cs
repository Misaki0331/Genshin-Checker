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

namespace Genshin_Checker.Window
{
    public partial class TimeGraph : Form
    {
        readonly System.Windows.Forms.Timer DailyGraphDrawingDelay;
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
        public TimeGraph()
        {
            InitializeComponent();
            DailyGraphDrawingDelay = new();
            DailyGraphDrawingDelay.Tick += DailyGraph_Drawing;
            DailyGraphDrawingDelay.Interval = 10;

            DailyGraphDrawingDelay.Start();
            comboBox1.SelectedIndex = 0;
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
            DailyGraphDrawingDelay.Stop();
            DailyGraphDrawingDelay.Start();
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
        private async void DailyGraph_Drawing(object? sender, EventArgs e)
        {
            Trace.WriteLine(DateTime.Now);
            DailyGraphDrawingDelay.Stop();
            if (!dayCache.IsDateEqual(dateTimePicker1.Value))
            {
                dayCache.date = dateTimePicker1.Value;
                dayCache.raw = await App.TimeTable.LoadDateLocal(dateTimePicker1.Value);
            }
            var rawdata = dayCache.raw;
            lock (DrawingObject)
            {
                if (DailyGraph.Width == 0 || DailyGraph.Height == 0) return;
                Trace.WriteLine(DateTime.Now);
                var image = new Bitmap(DailyGraph.Width, DailyGraph.Height);
                Graphics g = Graphics.FromImage(image);
                Rectangle Graph = new(40, 40, image.Width - 50, image.Height - 60);
                Day.SuspendLayout();
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        List<StateData> stateDatas = new();
                        for (int h = 0; h < 24; h++)
                        {
                            var state = new StateData();
                            for (int w = 0; w < 3600; w++)
                            {
                                switch (rawdata[h*3600+w])
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
                        for (int h = 0; h < 24; h++)
                        {
                            double thickWidth = Graph.Width / 24.0;
                            double thickOffset = Graph.X + thickWidth * h;
                            Rectangle thick = new( (int)(thickOffset),Graph.Top, (int)(thickOffset + thickWidth - ((int)thickOffset) - 2),Graph.Height);
                            //g.FillRectangle(GetStateColor(App.ProcessTime.ProcessState.EmptyState), (int)thickOffset, Graph.Top, thick.Width, Graph.Height);

                            int fill = thick.Height * (stateDatas[h].BackGround + stateDatas[h].ForeGround + stateDatas[h].NotRunning) / 3600;
                            g.FillRectangle(GetStateColor(App.ProcessTime.ProcessState.NotRunning), (int)thickOffset, Graph.Bottom - fill, thick.Width, fill);
                            fill = thick.Height * (stateDatas[h].BackGround + stateDatas[h].ForeGround) / 3600;
                            g.FillRectangle(GetStateColor(App.ProcessTime.ProcessState.Background), (int)thickOffset,Graph.Bottom-fill,thick.Width,fill);
                            fill = thick.Height * (stateDatas[h].ForeGround) / 3600; 
                            g.FillRectangle(GetStateColor(App.ProcessTime.ProcessState.Foreground), (int)thickOffset, Graph.Bottom - fill, thick.Width, fill);


                        }
                        g.Dispose();

                        Trace.WriteLine(DateTime.Now);
                        var old = DailyGraph.Image;
                        DailyGraph.Image = image;
                        if (old != null) old.Dispose();

                        foreach (var l in Labels) l.Dispose();
                        Labels.Clear();
                        break;
                    case 1:
                        List<List<App.ProcessTime.ProcessState>> states = new();
                        for (int h = 0; h < 24; h++)
                        {
                            List<App.ProcessTime.ProcessState> state = new();
                            for (int w = 0; w < Graph.Width; w++)
                            {
                                double slice = 3600.0 / Graph.Width;
                                double startpos = slice * w;
                                int since = h * 3600 + (int)startpos;
                                int until = h * 3600 + (int)(startpos + slice);
                                if (until >= 86400) until = 86399;
                                StateData data = new();
                                for (int tick = since; tick < until || tick == since; tick++)
                                {
                                    switch (rawdata[tick])
                                    {
                                        case ' ':
                                            data.EmptyState++;
                                            break;
                                        case '_':
                                            data.NotRunning++;
                                            break;
                                        case 'B':
                                            data.BackGround++;
                                            break;
                                        case 'F':
                                            data.ForeGround++;
                                            break;
                                    }
                                }
                                if (data.EmptyState >= Math.Max(data.NotRunning, Math.Max(data.BackGround, data.ForeGround)))
                                    state.Add(App.ProcessTime.ProcessState.EmptyState);
                                else if (data.NotRunning >= Math.Max(data.EmptyState, Math.Max(data.BackGround, data.ForeGround)))
                                    state.Add(App.ProcessTime.ProcessState.NotRunning);
                                else if (data.BackGround >= Math.Max(data.EmptyState, Math.Max(data.NotRunning, data.ForeGround)))
                                    state.Add(App.ProcessTime.ProcessState.Background);
                                else if (data.ForeGround >= Math.Max(data.EmptyState, Math.Max(data.NotRunning, data.BackGround)))
                                    state.Add(App.ProcessTime.ProcessState.Foreground);
                            }
                            states.Add(state);
                        }
                        for (int h = 0; h < 24; h++)
                        {
                            double thickHeight = Graph.Height / 24.0;
                            double thickOffset = Graph.Y + thickHeight * h;
                            Rectangle thick = new(Graph.X, (int)(thickOffset), Graph.Width, (int)(thickOffset + thickHeight - ((int)thickOffset) - 2));
                            App.ProcessTime.ProcessState laststate = (App.ProcessTime.ProcessState)int.MinValue;
                            int chainCount = 0;
                            for (int i = 0; i < Graph.Width; i++)
                            {
                                if (laststate != states[h][i])
                                {
                                    if (chainCount > 0) g.FillRectangle(GetStateColor(laststate), Graph.X + i - chainCount - 1, thick.Top, chainCount, thick.Height);
                                    chainCount = 0;
                                    laststate = states[h][i];
                                }
                                chainCount++;
                            }
                            if (chainCount > 0) g.FillRectangle(GetStateColor(laststate), Graph.X + Graph.Width - chainCount - 1, thick.Top, chainCount, thick.Height);
                        }
                        for (int m = 0; m <= 60; m += 5)
                        {
                            Pen b = new Pen(Color.FromArgb(64, Color.Blue), 1);
                            if (m % 15 == 0) b = new Pen(Color.FromArgb(64, Color.Red), 1);
                            double pos = Graph.Left + (Graph.Width / 60.0 * m);
                            g.DrawLine(b, (float)pos - 1, Graph.Top - 5, (float)pos - 1, Graph.Bottom + 5);
                        }
                        g.Dispose();

                        Trace.WriteLine(DateTime.Now);
                        old = DailyGraph.Image;
                        DailyGraph.Image = image;
                        if (old != null) old.Dispose();

                        foreach (var l in Labels) l.Dispose();
                        Labels.Clear();
                        double invertalHeight = 0;
                        int passed = 0;
                        for (int i = 23; i >= 0; i--)
                        {
                            double thickHeight = Graph.Height / 24.0;
                            invertalHeight += thickHeight;
                            if (invertalHeight < 16)
                            {
                                passed++;
                                continue;
                            }
                            invertalHeight = 0;
                            var l = new Label();
                            double thickOffset = Graph.Y + thickHeight * i;
                            Rectangle thick = new(0, (int)thickOffset, Graph.X, (int)((passed + 1) * thickHeight + 0.5) - 1);
                            passed = 0;
                            l.Location = thick.Location;
                            l.Size = thick.Size;
                            l.TextAlign = passed == 0 ? ContentAlignment.MiddleRight : ContentAlignment.TopRight;
                            l.Text = $"{i:00}";
                            l.ForeColor = Color.Black;
                            Day.Controls.Add(l);
                            l.BringToFront();
                            Labels.Add(l);
                        }

                        invertalHeight = 0;
                        passed = 0;
                        for (int i = 0; i <= 60; i += 15)
                        {
                            double thickWidth = Graph.Width / 60.0;
                            invertalHeight += thickWidth;
                            invertalHeight = 0;
                            var l = new Label();
                            double thickOffset = Graph.X + thickWidth * i;
                            Rectangle thick = new((int)thickOffset - 12, Graph.Bottom + 5, 30, 20);
                            passed = 0;
                            l.Location = thick.Location;
                            l.Size = thick.Size;
                            l.TextAlign = ContentAlignment.TopCenter;
                            l.Text = $"{i:00}";
                            l.ForeColor = Color.Black;
                            Day.Controls.Add(l);
                            l.BringToFront();
                            Labels.Add(l);
                        }

                        break;
                }
                Day.ResumeLayout(false);
            }
            Trace.WriteLine(DateTime.Now);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DailyGraphDrawingDelay.Stop();
            DailyGraphDrawingDelay.Start();
        }
    }
}
