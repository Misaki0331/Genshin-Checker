using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.HoYoLab.SpiralAbyss;
using Genshin_Checker.Model.UserData.SpiralAbyss.v1;
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
        public BattleInfo(Account account, Model.UserData.SpiralAbyss.v1.Battle battle, string battleName, bool IsVisibleDateTime = true)
        {
            InitializeComponent();
            if (!IsVisibleDateTime) LabelTimestamp.Visible = false;
            LabelTimestamp.Text = $"踏破時間 : {DateTimeOffset.FromUnixTimeSeconds(battle.timestamp).ToLocalTime():yyyy/MM/dd HH:mm:ss}";
            LabelBattleName.Text = battleName;
            if (string.IsNullOrEmpty(battleName)) panel1.Visible = false;
            List<CharacterFrame.CharacterArgment> argment = new();
            foreach (var character in battle.avatars)
            {
                argment.Add(new(character.id, $"Lv.{character.level}"));
            }
            frame = new(account, string.Empty, argment, false) { Dock = DockStyle.Left, AutoSize = true, AutoSizeMode = AutoSizeMode.GrowAndShrink};
            frame.ClickHandler += (a) => CharacterClickHandler?.Invoke(a);
            PanelCharactersInfo.Controls.Add(frame);
            var enemy = battle.enemies.FindAll(a => true);
            enemy.Reverse();
            EnemyControls = new();
            foreach (var e in enemy)
            {
                var control = new EnemyInfo(e.RemoteIconPath, e.name, $"Lv.{e.level}") { Dock = DockStyle.Top, };
                EnemyControls.Add(control);
                PanelEnemyInfo.Controls.Add(control);
            }

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
