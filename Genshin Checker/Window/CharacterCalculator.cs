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

namespace Genshin_Checker.Window
{
    public partial class CharacterCalculator : Form
    {
        Account account;
        public CharacterCalculator(Account account)
        {
            InitializeComponent();
            this.account = account;
            CharacterView.Columns.Add("ID", "Character ID");
            CharacterView.Columns.Add("Rarelity", "レアリティ");
            CharacterView.Columns.Add("Element", "元素");
            CharacterView.Columns.Add("Name", "名前");
            CharacterView.Columns.Add("Weapon", "武器種");
            CharacterView.Columns.Add("Fetter", "好感度");
            CharacterView.Columns.Add("CurrentLevel", "レベル");
            CharacterView.Columns.Add("CurrentTalentLevel1", "天賦1");
            CharacterView.Columns.Add("CurrentTalentLevel2", "天賦2");
            CharacterView.Columns.Add("CurrentTalentLevel3", "天賦3");
            CharacterView.Columns.Add("ToArrow", "⇒");
            CharacterView.Columns.Add("ToLevel", "レベル");
            CharacterView.Columns.Add("ToTalentLevel1", "天賦1");
            CharacterView.Columns.Add("ToTalentLevel2", "天賦2");
            CharacterView.Columns.Add("ToTalentLevel3", "天賦3");
        }

        private async void CharacterCalculator_Load(object sender, EventArgs e)
        {
            if (!await account.CharacterDetail.IsReadyCacheData())
            {
                new ErrorMessage("キャラクターの天賦情報を取得中です。", "しばらく経ってからもう一度開いてください。").ShowDialog(); ;
                Close();
                return;
            }
            Text = "取得中...";
            var Data= await account.Characters.GetData();
            var characters = Data.avatars.FindAll(a=>true);
            for(int i=0; i<characters.Count; i++)
            {
                Text = $"{i}/{characters.Count}";
                var character = characters[i];
                var charainfo = await account.CharacterDetail.GetData(character.id);
                var talent = charainfo.skill_list.FindAll(a=>a.max_level!=1);
                if(talent.Count!=3)throw new InvalidDataException("天賦レベルが不整合です。");
                CharacterView.Rows.Add(character.id, character.rarity, character.element, character.name, character.weapon.type_name, character.fetter, character.level,
                    talent[0].level_current, talent[1].level_current, talent[2].level_current, "⇒", 90, 9, 9, 9);
            }
            Text = "育成計算機＋";
        }
    }
}
