using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window
{
    public partial class TimerDisplay : Form
    {
        System.Drawing.Text.PrivateFontCollection pfc = new();
        public TimerDisplay()
        {
            InitializeComponent();


            try
            {
                //resource内のフォントの呼び出し
                byte[] fontBuf = resource.font.DSEG7Classic_BoldItalic;
                IntPtr fontBufPtr = Marshal.AllocCoTaskMem(fontBuf.Length);
                Marshal.Copy(fontBuf, 0, fontBufPtr, fontBuf.Length);
                pfc.AddMemoryFont(fontBufPtr, fontBuf.Length);
                Marshal.FreeCoTaskMem(fontBufPtr);
                SessionTime.Font = new(pfc.Families[0], 36, FontStyle.Bold | FontStyle.Italic);
                TotalSessionTime.Font = new(pfc.Families[0], 28, FontStyle.Bold | FontStyle.Italic);
            }
            catch (Exception ex)
            {
                var n = new ErrorMessage(ex.GetType().ToString(), ex.Message);
                n.ShowDialog(this);
                Close();
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            var time = App.ProcessTime.Instance.Session;
            SessionTime.Text = $"{((int)time.TotalHours)}:{time:mm\\:ss\\.ff}";
            var totaltime = App.ProcessTime.Instance.TotalSession;
            TotalSessionTime.Text = $"{((int)totaltime.TotalHours)}:{totaltime:mm\\:ss\\.ff}";
        }
        void TargetStart(object? sender, EventArgs e)
        {
        }
        void DisplayChangeState(App.ProcessTime.ProcessState state)
        {
            switch (state)
            {
                case App.ProcessTime.ProcessState.NotRunning:
                    CurrentStatus.ForeColor = Color.Red;
                    CurrentStatus.Text = "未起動";
                    break;
                case App.ProcessTime.ProcessState.Background:
                    CurrentStatus.ForeColor = Color.Orange;
                    CurrentStatus.Text = "バックグラウンド";
                    break;
                case App.ProcessTime.ProcessState.Foreground:
                    CurrentStatus.ForeColor = Color.Lime;
                    CurrentStatus.Text = "アクティブ";
                    break;
            }
        }
        void ChangeState(object? sender, App.ProcessTime.Result e)
        {
            this.Invoke(() =>
            {
                DisplayChangeState(e.State);
            });
        }
        void TargetEnd(object? sender, App.ProcessTime.Result e)
        {

        }

        private void Time_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void TimerDisplay_Load(object sender, EventArgs e)
        {
            DisplayChangeState(App.ProcessTime.Instance.CurrentProcessState);
            App.ProcessTime.Instance.SessionStart += TargetStart;
            App.ProcessTime.Instance.SessionEnd += TargetEnd;
            App.ProcessTime.Instance.ChangedState += ChangeState;
        }

        private void TimerDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            App.ProcessTime.Instance.SessionStart -= TargetStart;
            App.ProcessTime.Instance.SessionEnd -= TargetEnd;
            App.ProcessTime.Instance.ChangedState -= ChangeState;
        }
    }

}
