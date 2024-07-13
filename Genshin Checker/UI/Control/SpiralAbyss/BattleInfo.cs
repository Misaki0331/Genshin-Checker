using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.HoYoLab.SpiralAbyss;
using Genshin_Checker.Model.UserData.SpiralAbyss.v1;
using Genshin_Checker.resource.Languages;
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
    public partial class BattleInfo : UserControl
    {
        CharacterFrame frame;
        List<EnemyInfo> EnemyControls;
        public delegate void CharacterEventHandler<T>(T args);
        public event CharacterEventHandler<int>? CharacterClickHandler;
        public BattleInfo(Account account, Model.UserData.SpiralAbyss.v2.Battle battle, string battleName, bool IsVisibleDateTime = true)
        {
            InitializeComponent();
            if (!IsVisibleDateTime) LabelTimestamp.Visible = false;
            LabelTimestamp.Text = string.Format(Localize.UIName_SpiralAbyss_Timestamp,$"{battle.timestamp.ToLocalTime():yyyy/MM/dd HH:mm:ss}");
            LabelBattleName.Text = battleName;
            if (string.IsNullOrEmpty(battleName)) panel1.Visible = false;
            List<CharacterFrame.CharacterArgment> argment = new();
            foreach (var character in battle.avatars)
            {
                argment.Add(new(character.id, string.Format(Localize.UI_Character_Level, character.level)));
            }
            frame = new(account, string.Empty, argment, false) { Dock = DockStyle.Left, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink};
            frame.ClickHandler += (a) => CharacterClickHandler?.Invoke(a);
            PanelCharactersInfo.Controls.Add(frame);
            EnemyControls = new();
            /* 敵情報は削除された為別の物を代用予定
            battle.enemies.FindAll(a => true);
            enemy.Reverse();
            foreach (var e in enemy)
            {
                var control = new EnemyInfo(e.RemoteIconPath, e.name, string.Format(Localize.UI_Character_Level, e.level)) { Dock = DockStyle.Top, };
                EnemyControls.Add(control);
                PanelEnemyInfo.Controls.Add(control);
            }*/

            this.Disposed += (s, e) =>
            {
                this.SuspendLayout();
                foreach (var b in EnemyControls)
                {
                    PanelEnemyInfo.Controls.Remove(b);
                    b.Dispose();
                }
                PanelCharactersInfo.Controls.Remove(frame);
                frame.Dispose();
                this.ResumeLayout(true);
            };
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            if (PanelEnemyInfoBackground.Width < 350) PanelEnemyInfo.Visible = false;
            else PanelEnemyInfo.Visible = true;
        }
    }
}
