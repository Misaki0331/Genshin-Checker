using System.Runtime.InteropServices;
using Genshin_Checker.App.Game;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Popup;

namespace Genshin_Checker.Window
{
    public partial class TimerDisplay : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll",
    ExactSpelling = true)]
        private static extern IntPtr AddFontMemResourceEx(
    byte[] pbFont, int cbFont, IntPtr pdv, out uint pcFonts);
        System.Drawing.Text.PrivateFontCollection pfc = new();
        public TimerDisplay()
        {
            InitializeComponent();
            Icon = resource.icon.nahida;

            try
            {
                //resource内のフォントの呼び出し
                byte[] fontBuf = resource.font.DSEG7Classic_BoldItalic;
                IntPtr fontBufPtr = Marshal.AllocCoTaskMem(fontBuf.Length);
                Marshal.Copy(fontBuf, 0, fontBufPtr, fontBuf.Length);
                uint cFonts;
                AddFontMemResourceEx(fontBuf, fontBuf.Length, IntPtr.Zero, out cFonts);

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
            var time = ProcessTime.Instance.Session;
            SessionTime.Text = $"{((int)time.TotalHours)}:{time:mm\\:ss\\.ff}";
            var totaltime = ProcessTime.Instance.TotalSession;
            TotalSessionTime.Text = $"{((int)totaltime.TotalHours)}:{totaltime:mm\\:ss\\.ff}";
        }
        void TargetStart(object? sender, EventArgs e)
        {
        }
        void DisplayChangeState(ProcessTime.ProcessState state)
        {
            switch (state)
            {
                case ProcessTime.ProcessState.NotRunning:
                    CurrentStatus.ForeColor = Color.Red;
                    CurrentStatus.Text = Localize.WindowName_TimerDisplay_State_NotRunning;
                    break;
                case ProcessTime.ProcessState.Background:
                    CurrentStatus.ForeColor = Color.Orange;
                    CurrentStatus.Text = Localize.WindowName_TimerDisplay_State_Background;
                    break;
                case ProcessTime.ProcessState.Foreground:
                    CurrentStatus.ForeColor = Color.Lime;
                    CurrentStatus.Text = Localize.WindowName_TimerDisplay_State_Active;
                    break;
            }
        }
        void ChangeState(object? sender, ProcessTime.Result e)
        {
            this.Invoke(() =>
            {
                DisplayChangeState(e.State);
            });
        }
        void TargetEnd(object? sender, ProcessTime.Result e)
        {

        }

        private void Time_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void TimerDisplay_Load(object sender, EventArgs e)
        {
            DisplayChangeState(ProcessTime.Instance.CurrentProcessState);
            ProcessTime.Instance.SessionStart += TargetStart;
            ProcessTime.Instance.SessionEnd += TargetEnd;
            ProcessTime.Instance.ChangedState += ChangeState;
        }

        private void TimerDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessTime.Instance.SessionStart -= TargetStart;
            ProcessTime.Instance.SessionEnd -= TargetEnd;
            ProcessTime.Instance.ChangedState -= ChangeState;
        }
    }

}
