using Genshin_Checker.App.HoYoLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
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
        }
        string ElementLocalize(string? str)
        {
            if (str == null) return "？";
            return str.ToLower() switch
            {
                "anemo" => "風",
                "geo" => "岩",
                "electro" => "雷",
                "dendro" => "草",
                "hydro" => "水",
                "pyro" => "炎",
                "cryo" => "氷",
                _ => "？",
            };
        }
        enum ElementType
        {
            Anemo,
            Geo,
            Electro,
            Dendro,
            Hydro,
            Pyro,
            Cryo,
            Unknown,
        }
        ElementType GetElementEnum(string? str)
        {
            if (str == null) return ElementType.Unknown; return 
                str.ToLower() switch
            {
                "anemo" => ElementType.Anemo,
                "geo" => ElementType.Geo,
                "electro" => ElementType.Electro,
                "dendro" => ElementType.Dendro,
                "hydro" => ElementType.Hydro,
                "pyro" => ElementType.Pyro,
                "cryo" => ElementType.Cryo,
                _ => ElementType.Unknown,
            };
        }
        string ElementLocalize(ElementType type)
        {
            return type switch
            {
                ElementType.Anemo => "風",
                ElementType.Geo => "岩",
                ElementType.Electro => "雷",
                ElementType.Dendro => "草",
                ElementType.Hydro => "水",
                ElementType.Pyro => "炎",
                ElementType.Cryo => "氷",
                _ => "？",
            };
        }
        Color GetElementBackgroundColor(ElementType type)
        {

            return type switch
            {
                ElementType.Anemo => Color.FromArgb(0xBB, 0xFF, 0xCC),
                ElementType.Geo => Color.FromArgb(0xFF, 0xDD, 0xAA),
                ElementType.Electro => Color.FromArgb(0xCC, 0xAA, 0xFF),
                ElementType.Dendro => Color.FromArgb(0xAA, 0xFF, 0xAA),
                ElementType.Hydro => Color.FromArgb(0xAA, 0xCC, 0xFF),
                ElementType.Pyro => Color.FromArgb(0xFF, 0xAA, 0xAA),
                ElementType.Cryo => Color.FromArgb(0xBB,0xFF,0xFF),
                _ => Color.White,
            };
        }
        private async void CharacterCalculator_Load(object sender, EventArgs e)
        {
            if (!await account.CharacterDetail.IsReadyCacheData())
            {
                new ErrorMessage("キャラクターの天賦情報を取得中です。", "しばらく経ってからもう一度開いてください。").ShowDialog() ;
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
                CharacterView.Rows.Add(true,character.id, character.rarity, character.element, character.name, character.weapon.type_name, character.fetter, character.level,
                    talent[0].level_current, talent[1].level_current, talent[2].level_current, "⇒", "90","9","9","9");
            }
            Text = "育成計算機＋";
        }

        private void CharacterView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            lock (LockObject)
            {
                Exceptions.Add(e.Exception);
                if (Exceptions.Count > 100) Exceptions.RemoveAt(0);
                ExceptionCount++;
                ErrorHandling.Stop();
                ErrorHandling.Start();
            }

            e.Cancel = true;
        }

        readonly List<Exception> Exceptions = new();
        int ExceptionCount = 0;
        object LockObject = new();
        private void ErrorHandling_Tick(object sender, EventArgs e)
        {
            ErrorHandling.Stop();
            lock (LockObject)
            {
                StringBuilder ErrorDetail = new();
                string ErrorTitle = $"データエラーが {ExceptionCount:#,##0} 件発生しました。";
                foreach (var ex in Exceptions)
                {
                    ErrorDetail.Append($"{ex}\n--------------------\n");
                }
                if (ExceptionCount > 100) ErrorDetail.Append($"... 他 {ExceptionCount - Exceptions.Count:#,##0} 件");
                ExceptionCount = 0;
                Exceptions.Clear();
                new ErrorMessage(ErrorTitle, ErrorDetail.ToString()).ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewColumn column in CharacterView.Columns)
            {
                Trace.WriteLine($"{column.Name} - {column.Width}px");
            }
        }

        private void CharacterView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void CharacterView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (CharacterView.Columns[e.ColumnIndex].Name)
            {
                case "Element":
                    e.Value = ElementLocalize(GetElementEnum((string?)e.Value));
                    e.CellStyle.BackColor = GetElementBackgroundColor(GetElementEnum((string?)CharacterView[e.ColumnIndex,e.RowIndex].Value));
                    break;
                case "CharacterName":
                    var element = GetElementEnum((string?)CharacterView[CharacterView.Columns["CharacterName"].Index-1,e.RowIndex].Value);
                    e.CellStyle.BackColor = GetElementBackgroundColor(element);
                    break;
                case "Rarelity":
                    if($"{e.Value}"=="5") e.CellStyle.BackColor = Color.FromArgb(0xFF,0xEE,0xAA);
                    else if ($"{e.Value}" == "4") e.CellStyle.BackColor = Color.FromArgb(0xCC, 0xAA, 0xFF);
                    break;
            }
        }
    }
}
