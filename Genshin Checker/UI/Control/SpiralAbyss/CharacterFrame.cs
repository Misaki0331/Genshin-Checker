using Genshin_Checker.App.General.Convert;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.UI.Control.GameRecord;
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
    public partial class CharacterFrame : UserControl
    {
        List<CharacterInfo> characters = new();
        public CharacterFrame(Account account,string groupname, List<CharacterArgment> values)
        {
            InitializeComponent();
            values.Reverse();

            var records = account.GameRecords.Data;
            groupBox1.Text = $"{groupname}";
            if (records == null) {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "戦績情報を読み込むことができませんでした。";
                return;
            }
            if(values.Count == 0)
            {
                ErrorMessage.Visible = true;
                ErrorMessage.Text = "キャラクターはありません。";
                return;
            }
            foreach (var argment in values)
            {
                var character = records.avatars.Find(a => a.id == argment.CharacterID);
                var icon = character==null?"":character.image;
                var control = new CharacterInfo(character==null?-1:character.rarity, icon, argment.Value, "", argment.CharacterID) { Dock = DockStyle.Left, Padding=new(2,0,2,0) };
                groupBox1.Controls.Add(control);
                characters.Add(control);
            }
            Disposed += (s, e) =>
            {
                foreach (var argment in characters)
                {
                    groupBox1.Controls.Remove(argment);
                    argment.Dispose();
                }
            };
        }
        public class CharacterArgment {
            public int CharacterID;
            public string Value;
            public CharacterArgment(int characterID, string value)
            {
                CharacterID = characterID;
                Value = value;
            }
        }

        private void CharacterFrame_ControlRemoved(object sender, ControlEventArgs e)
        {
        }
    }
}
