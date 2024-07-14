using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.resource.Languages;
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

namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    public partial class LevelInfo : UserControl
    {
        List<BattleInfo> Battles;
        List<PictureBox> StarPictures;
        Model.UserData.SpiralAbyss.v2.Level level;
        int Page = 0;
        Account account;
        public delegate void CharacterEventHandler<T>(T args);
        public event CharacterEventHandler<int>? CharacterClickHandler;
        public LevelInfo(Account account, Model.UserData.SpiralAbyss.v2.Level level, bool showInline = false)
        {
            InitializeComponent();
            this.level = level;
            this.account = account;
            _showinline = showInline;
            label1.Text = string.Format(Localize.UIName_SpiralAbyss_Level, level.index);
            Battles = new();
            StarPictures = new();
            Page = level.history.Count - 1;
            if (level.history.Count <= 1)
            {
                LeftButton.Visible = false;
                RightButton.Visible = false;
                label3.Visible = false;
            }
            HistoryChanged(Page);
            this.Disposed += (s, e) =>
            {
                this.SuspendLayout();
                foreach (var b in Battles)
                {
                    PanelBattleInfo.Controls.Remove(b);
                    b.Dispose();
                }
                foreach (var p in StarPictures)
                {
                    PanelStar.Controls.Remove(p);
                    p.Dispose();
                }
                this.ResumeLayout(true);
            };
        }
        void HistoryChanged(int historyIndex)
        {
            if (historyIndex < 0 || historyIndex >= level.history.Count) return;
            this.SuspendLayout();
            foreach (var b in Battles)
            {
                PanelBattleInfo.Controls.Remove(b);
                b.Dispose();
            }
            foreach (var p in StarPictures)
            {
                PanelStar.Controls.Remove(p);
                p.Dispose();
            }



            StarPictures.Clear();
            label3.Text = $"{historyIndex+1} / {level.history.Count}";
            label2.Text = string.Format(Localize.UIName_SpiralAbyss_Timestamp, $"{level.history[historyIndex].timestamp.ToLocalTime():yyyy/MM/dd HH:mm:ss}");
            RightButton.Enabled = historyIndex+1 <level.history.Count;
            LeftButton.Enabled = historyIndex-1 >= 0;
            for (int i = level.history[historyIndex].max_star; i > 0; i--)
            {
                var picture = new PictureBox() { SizeMode = PictureBoxSizeMode.Zoom, Size = new(PanelStar.Height, PanelStar.Height), Dock = DockStyle.Left };
                picture.Image = level.history[historyIndex].star >= i ? resource.icon.UI_Icon_Tower_Star : resource.icon.UI_Icon_Tower_Star_Disabled;
                StarPictures.Add(picture);
                PanelStar.Controls.Add(picture);
            }
            Battles.Clear();
            var battles = level.history[historyIndex].battles.FindAll(a => true);
            battles.Reverse();
            foreach (var battle in battles)
            {
                var name = "";
                if (battles.Count == 2)
                {
                    switch (battle.index)
                    {
                        case 1:
                            name = Localize.UIName_SpiralAbyss_Battle2_1;
                            break;
                        case 2:
                            name = Localize.UIName_SpiralAbyss_Battle2_2;
                            break;
                    }
                }
                else if (battles.Count > 2) name = string.Format(Localize.UIName_SpiralAbyss_Battle_Common, battle.index);
                var control = new BattleInfo(account, battle, name, battles.Count > 1) { Dock = DockStyle.Top, BorderStyle = BorderStyle.FixedSingle };
                control.CharacterClickHandler += a => CharacterClickHandler?.Invoke(a);
                Battles.Add(control);
            }
            ReloadContent();
            this.ResumeLayout(true);
        }
        private void LevelInfo_Load(object sender, EventArgs e)
        {
            ReloadContent();
        }
        private bool _showinline = false;
        public bool ShowInline { get => _showinline; set { if (_showinline != value) { _showinline = value; ReloadContent(); } } }
        private void ReloadContent()
        {
            tableLayoutPanel1.ColumnCount = Battles.Count;
            foreach (ColumnStyle column in tableLayoutPanel1.ColumnStyles)
            {
                column.SizeType = SizeType.Percent;
                column.Width = (float)100.0 / Battles.Count;
            }
            var controls = Battles.FindAll(a => true);
            if (ShowInline) controls.Reverse();
            foreach (var b in controls)
            {
                if (PanelBattleInfo.Controls.IndexOf(b) > 0) PanelBattleInfo.Controls.Remove(b);
                if (tableLayoutPanel1.Controls.IndexOf(b) > 0) tableLayoutPanel1.Controls.Remove(b);
                if (ShowInline) tableLayoutPanel1.Controls.Add(b);
                else PanelBattleInfo.Controls.Add(b);
            }
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            Page--;
            HistoryChanged(Page);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            Page++;
            HistoryChanged(Page);
        }
    }
}
