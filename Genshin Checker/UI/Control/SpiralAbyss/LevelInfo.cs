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
        public delegate void CharacterEventHandler<T>(T args);
        public event CharacterEventHandler<int>? CharacterClickHandler;
        public LevelInfo(Account account, Model.UserData.SpiralAbyss.v1.Level level,bool showInline=false)
        {
            InitializeComponent();
            _showinline = showInline;
            label1.Text = string.Format(Localize.UIName_SpiralAbyss_Level, level.index);
            label2.Text = string.Format(Localize.UIName_SpiralAbyss_Timestamp, $"{DateTimeOffset.FromUnixTimeSeconds(level.timestamp).ToLocalTime():yyyy/MM/dd HH:mm:ss}");
            StarPictures = new();
            for (int i = level.max_star; i > 0; i--)
            {
                var picture = new PictureBox() { SizeMode = PictureBoxSizeMode.Zoom, Size = new(PanelStar.Height, PanelStar.Height), Dock = DockStyle.Left };
                picture.Image = level.star >= i ? resource.icon.UI_Icon_Tower_Star : resource.icon.UI_Icon_Tower_Star_Disabled;
                StarPictures.Add(picture);
                PanelStar.Controls.Add(picture);
            }
            Battles = new();
            var battles = level.battles.FindAll(a => true);
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

        private void LevelInfo_Load(object sender, EventArgs e)
        {
            ReloadContent();
        }
        private bool _showinline = false;
        public bool ShowInline { get=>_showinline; set { if (_showinline != value) { _showinline = value; ReloadContent(); } } }
        private void ReloadContent()
        {
            tableLayoutPanel1.ColumnCount = Battles.Count;
            foreach(ColumnStyle column in tableLayoutPanel1.ColumnStyles)
            {
                column.SizeType = SizeType.Percent;
                column.Width = (float)100.0 / Battles.Count;
            }
            var controls = Battles.FindAll(a=>true);
            if (ShowInline) controls.Reverse();
            foreach (var b in controls)
            {
                if (PanelBattleInfo.Controls.IndexOf(b) > 0) PanelBattleInfo.Controls.Remove(b);
                if (tableLayoutPanel1.Controls.IndexOf(b) > 0) tableLayoutPanel1.Controls.Remove(b);
                if(ShowInline)tableLayoutPanel1.Controls.Add(b);
                else PanelBattleInfo.Controls.Add(b);
            }
        }
    }
}
