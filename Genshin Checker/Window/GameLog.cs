using Genshin_Checker.App;
using Genshin_Checker.App.Game;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Genshin_Checker.Window
{
    public partial class GameLog : Form
    {
        List<string> LogData = new();
        int LogCount = 0;
        public GameLog(List<string> old)
        {
            InitializeComponent();
            Log.Font = new Font("ＭＳ ゴシック", (float)numeric_FontSize.Value);
            foreach (var item in old)
            {
                LogData.Add(item.ToString());
                Log.AppendText(item.Replace("\r\n", "\n").Replace("\n", Environment.NewLine) + Environment.NewLine);
                LogCount++;
            }
            App.Game.GameLogWatcher.Instance.LogUpdated += LogUpdated;

            ProcessTime.Instance.ChangedState += Instance_ChangedState;

        }
        const string RegistryPath = @"Config\GameLog\";
        enum ConfigName
        {
            WindowPositionX,
            WindowPositionY,
            WindowSizeWidth,
            WindowSizeHeight,
            WindowIsMaximized,
            WindowIsTopMost,
            ModeGameFullScreenSpecialized,
            TextLogFontSize
        }



        void LoadSetting()
        {
            try
            {
                //前回のウィンドウ位置を呼び出し
                var winPosX = Registry.GetValue(RegistryPath, $"{ConfigName.WindowPositionX}");
                var winPosY = Registry.GetValue(RegistryPath, $"{ConfigName.WindowPositionY}");
                if(winPosX!= null && winPosY != null) this.Location = new(int.Parse(winPosX),int.Parse(winPosY));
                //前回のウィンドウサイズの呼び出し
                var winSizeW = Registry.GetValue(RegistryPath, $"{ConfigName.WindowSizeWidth}");
                var winSizeH = Registry.GetValue(RegistryPath, $"{ConfigName.WindowSizeHeight}");
                if (winSizeW != null && winSizeH != null) this.Size = new(int.Parse(winSizeW), int.Parse(winSizeH));
                //前回のウィンドウモードの呼び出し
                var winSizeMode = Registry.GetValue(RegistryPath, $"{ConfigName.WindowIsMaximized}");
                if (winSizeMode == "True") WindowState = FormWindowState.Maximized;
                //最前面に表示する
                var checkstatus = Registry.GetValue(RegistryPath, $"{ConfigName.WindowIsTopMost}");
                if(checkstatus=="True")CheckBoxTopMost.Checked = true;
                //フルスクリーン特化モード
                checkstatus = Registry.GetValue(RegistryPath, $"{ConfigName.ModeGameFullScreenSpecialized}");
                if (checkstatus == "True") CheckBox_GameFullScreenSpecialized.Checked = true;
                //ログのフォントサイズ
                checkstatus = Registry.GetValue(RegistryPath, $"{ConfigName.TextLogFontSize}");
                if (checkstatus != null) numeric_FontSize.Value = int.Parse(checkstatus);
            }
            catch(Exception ex)
            {
                new ErrorMessage("設定を読み込めませんでした。",$"{ex}").ShowDialog();
            }
        }



        private void Instance_ChangedState(object? sender, ProcessTime.Result e)
        {
            this.Invoke(() =>
            {
                switch (e.State)
                {
                    case ProcessTime.ProcessState.Foreground:
                        if (CheckBox_GameFullScreenSpecialized.Checked)
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
                LogData.Add(item);
                if (LogData.Count > 500) LogData.RemoveAt(0);
                Log.AppendText(item.Replace("\r\n", "\n").Replace("\n", Environment.NewLine) + Environment.NewLine);
                LogCount++;
                if (LogCount > 2000)
                {
                    Log.Clear();
                    LogCount = 0;
                    StringBuilder str = new();
                    foreach (var item2 in LogData)
                    {
                        str.Append(item2.Replace("\r\n", "\n").Replace("\n", Environment.NewLine) + Environment.NewLine);
                        LogCount++;
                    }
                    Log.AppendText(str.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            LogCount = 0;
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
            Registry.SetValue(RegistryPath, $"{ConfigName.WindowIsTopMost}", $"{(CheckBoxTopMost.Checked ? "True" : "False")}");
        }

        private void GameLog_Load(object sender, EventArgs e)
        {
            Log.SelectionStart = Log.Text.Length;
            Log.Focus();
            Log.ScrollToCaret();

            LoadSetting();
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
            Log.Font = new Font("ＭＳ ゴシック", (float)numeric_FontSize.Value);
            Registry.SetValue(RegistryPath, $"{ConfigName.TextLogFontSize}",$"{(int)numeric_FontSize.Value}");
        }

        private void GameLog_Deactivate(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) 
        {
            CheckBoxTopMost.Enabled=!CheckBox_GameFullScreenSpecialized.Checked;
            Registry.SetValue(RegistryPath, $"{ConfigName.ModeGameFullScreenSpecialized}", $"{(CheckBox_GameFullScreenSpecialized.Checked?"True":"False")}");
        }

        private void GameLog_LocationChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                Registry.SetValue(RegistryPath, $"{ConfigName.WindowPositionX}", $"{Location.X}");
                Registry.SetValue(RegistryPath, $"{ConfigName.WindowPositionY}", $"{Location.Y}");
            }
        }

        private void GameLog_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
            {
                Registry.SetValue(RegistryPath, $"{ConfigName.WindowSizeWidth}", $"{Size.Width}");
                Registry.SetValue(RegistryPath, $"{ConfigName.WindowSizeHeight}", $"{Size.Height}");
                Registry.SetValue(RegistryPath, $"{ConfigName.WindowIsMaximized}", $"{(WindowState == FormWindowState.Maximized ? "True" : "False")}");
            }
        }
    }
}
