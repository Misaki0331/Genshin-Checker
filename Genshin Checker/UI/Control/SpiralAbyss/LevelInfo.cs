using Genshin_Checker.App.HoYoLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public LevelInfo(Account account, Model.UserData.SpiralAbyss.v1.Level level)
        {
            InitializeComponent();
            label1.Text = $"第 {level.index} 間";
            label2.Text = $"踏破時間 : {DateTimeOffset.FromUnixTimeSeconds(level.timestamp).ToLocalTime():yyyy/MM/dd HH:mm:ss}";
            StarPictures = new();
            for(int i = level.max_star; i > 0; i--)
            {
                var picture = new PictureBox() { SizeMode = PictureBoxSizeMode.Zoom, Size = new(PanelStar.Height, PanelStar.Height), Dock = DockStyle.Left };
                picture.Image = level.star >= i ? resource.icon.UI_Icon_Tower_Star : resource.icon.UI_Icon_Tower_Star_Disabled;
                StarPictures.Add(picture);
                PanelStar.Controls.Add(picture);
            }
            Battles = new();
            var battles = level.battles.FindAll(a => true);
            battles.Reverse();
            foreach(var battle in battles)
            {
                var name = "";
                if (battles.Count == 2)
                {
                    switch (battle.index)
                    {
                        case 1:
                            name = "前半";
                            break;
                        case 2:
                            name = "後半";
                            break;
                    }
                } else if (battles.Count > 2) name = $"第 {battle.index} 戦";
                var control = new BattleInfo(account, battle, name, battles.Count > 1) { Dock = DockStyle.Top, BorderStyle = BorderStyle.FixedSingle };
                control.CharacterClickHandler += a => CharacterClickHandler?.Invoke(a);
                Battles.Add(control);
                PanelBattleInfo.Controls.Add(control);
            }
            this.Disposed += (s, e) =>
            {
                this.SuspendLayout();
                foreach (var b in Battles)
                {
                    PanelBattleInfo.Controls.Remove(b);
                    b.Dispose();
                }
                foreach(var p in StarPictures)
                {
                    PanelStar.Controls.Remove(p);
                    p.Dispose();
                }
                this.ResumeLayout(true);
            };
        }
    }
}
