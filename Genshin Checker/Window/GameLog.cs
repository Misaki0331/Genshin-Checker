using Genshin_Checker.App.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Genshin_Checker.Window
{
    public partial class GameLog : Form
    {
        public GameLog(List<string> old)
        {
            InitializeComponent();
            Log.Font = new Font("ＭＳ ゴシック", (float)numericUpDown2.Value);
            foreach (var item in old)
            {
                Log.AppendText(item.Replace("\r\n","\n").Replace("\n", Environment.NewLine)+Environment.NewLine);
            }
            App.Game.GameLogWatcher.Instance.LogUpdated += LogUpdated;

            ProcessTime.Instance.ChangedState += Instance_ChangedState;

        }

        private void Instance_ChangedState(object? sender, ProcessTime.Result e)
        {
            this.Invoke(() =>
            {
                switch (e.State)
                {
                    case ProcessTime.ProcessState.Foreground:
                        if (checkBox2.Checked)
                        {
                            FormBorderStyle = FormBorderStyle.None;
                            Log.ScrollBars = ScrollBars.None;
                            panel1.Visible = false;
                            TransparencyKey = Color.Black;
                            Log.ForeColor = Color.Lime;
                            Log.BorderStyle = BorderStyle.None;
                            TopMost = true;
                        }
                        break;
                    default:
                        Opacity = 1;
                        FormBorderStyle = FormBorderStyle.Sizable;
                        Log.ScrollBars = ScrollBars.Vertical;
                        TransparencyKey = Color.Empty;
                        Log.ForeColor = Color.White;
                        panel1.Visible = true;
                        Log.BorderStyle = BorderStyle.Fixed3D;
                        TopMost = CheckBoxTopMost.Checked;
                        break;
                }
                Log.SelectionStart = Log.Text.Length;
                Log.Focus();
                Log.ScrollToCaret();
            });
        }

        private void LogUpdated(object? sender, string[] e)
        {
            foreach (var item in e)
            {
                Log.AppendText(item.Replace("\r\n", "\n").Replace("\n", Environment.NewLine) + Environment.NewLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log.Clear();
        }

        private void GameLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            App.Game.GameLogWatcher.Instance.LogUpdated -= LogUpdated;
            ProcessTime.Instance.ChangedState -= Instance_ChangedState;
        }

        private void CheckBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = CheckBoxTopMost.Checked;
        }

        private void GameLog_Load(object sender, EventArgs e)
        {
            Log.SelectionStart = Log.Text.Length;
            Log.Focus();
            Log.ScrollToCaret();
        }

        private void GameLog_Activated(object sender, EventArgs e)
        {
        }

        private void GameLog_Leave(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Log.Font = new Font("ＭＳ ゴシック", (float)numericUpDown2.Value);
        }

        private void GameLog_Deactivate(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxTopMost.Enabled=!checkBox2.Checked;
        }
    }
}
