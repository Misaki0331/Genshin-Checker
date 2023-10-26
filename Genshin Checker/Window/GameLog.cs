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
            Log.Font = new Font("Terminal", 10);
            foreach (var item in old)
            {
                Log.AppendText(item.Replace("\r\n","\n").Replace("\n", Environment.NewLine)+Environment.NewLine);
            }
            App.Game.GameLogWatcher.Instance.LogUpdated += LogUpdated;

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
    }
}
