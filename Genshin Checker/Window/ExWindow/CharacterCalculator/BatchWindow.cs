using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window.ExWindow.CharacterCalculator
{
    public partial class BatchWindow : Form
    {
        readonly Dictionary<NumericUpDown, TrackBar> ValuePairs;
        public OutData Output { get; private set; }
        public BatchWindow(InData data)
        {
            InitializeComponent();
            ValuePairs = new()
            {
                {NumericLevel,TrackLevel },
                {NumericTalent1,TrackTalent1 },
                {NumericTalent2,TrackTalent2 },
                {NumericTalent3,TrackTalent3 }
            };
            if (!data.IsMultiSelect)
            {
                Text = $"{data.CharacterName} の目標育成設定";
                //キャラクターの名前
                LabelCharacterName.Text = data.CharacterName;
                //グループでのスキル名
                GroupTalent1.Text = $"天賦 : {data.Talent1Name}";
                GroupTalent2.Text = $"天賦 : {data.Talent2Name}";
                GroupTalent3.Text = $"天賦 : {data.Talent3Name}";
                //現在のレベルのテキスト
                CurrentLevel.Text = $"Lv.{data.MinLevel}";
                CurrentTalent1.Text = $"Lv.{data.MinTalent1}";
                CurrentTalent2.Text = $"Lv.{data.MinTalent2}";
                CurrentTalent3.Text = $"Lv.{data.MinTalent3}";
            }
            else
            {
                Text = $"一括設定";
                //キャラクターの名前
                LabelCharacterName.Text = "複数のキャラクター";
                //グループでのスキル名
                GroupTalent1.Text = "通常攻撃";
                GroupTalent2.Text = "スキル";
                GroupTalent3.Text = "元素爆発";
                //現在のレベルのテキスト
                CurrentLevel.Visible = false;
                CurrentTalent1.Visible = false;
                CurrentTalent2.Visible = false;
                CurrentTalent3.Visible = false;
                ArrowLevel.Visible = false;
                ArrowTalent1.Visible = false;
                ArrowTalent2.Visible = false;
                ArrowTalent3.Visible = false;
            }
            //値の下限設定
            NumericLevel.Minimum = data.MinLevel;
            TrackLevel.Minimum = data.MinLevel;
            NumericTalent1.Minimum = data.MinTalent1;
            TrackTalent1.Minimum = data.MinTalent1;
            NumericTalent2.Minimum = data.MinTalent2;
            TrackTalent2.Minimum = data.MinTalent2;
            NumericTalent3.Minimum = data.MinTalent3;
            TrackTalent3.Minimum = data.MinTalent3;
            //値の現在設定
            NumericLevel.Value = data.CurrentLevel;
            TrackLevel.Value = data.CurrentLevel;
            NumericTalent1.Value = data.CurrentTalent1;
            TrackTalent1.Value = data.CurrentTalent1;
            NumericTalent2.Value = data.CurrentTalent2;
            TrackTalent2.Value = data.CurrentTalent2;
            NumericTalent3.Value = data.CurrentTalent3;
            TrackTalent3.Value = data.CurrentTalent3;
            Output = new() { IsApplied = false };
        }
        private void Track_ValueChanged(object sender, EventArgs e)
        {
            if(sender is TrackBar bar)
            {
                NumericUpDown pair = ValuePairs.First(a => a.Value == bar).Key;
                pair.Value = bar.Value;
            }
        }

        private void Numeric_ValueChanged(object sender, EventArgs e)
        {
            if (sender is NumericUpDown num)
            {
                TrackBar pair = ValuePairs.First(a => a.Key == num).Value;
                pair.Value = (int)num.Value;
            }
        }

        public class InData
        {
            public bool IsMultiSelect { get; set; } = false;
            public string CharacterName { get; set; } = "";
            public string Talent1Name { get; set; } = "";
            public string Talent2Name { get; set; } = "";
            public string Talent3Name { get; set; } = "";
            public int CurrentLevel { get; set; } = 1;
            public int CurrentTalent1 { get; set; } = 1;
            public int CurrentTalent2 { get; set; } = 1;
            public int CurrentTalent3 { get; set; } = 1;
            public int MinLevel { get; set; } = 1;
            public int MinTalent1 { get; set; } = 1;
            public int MinTalent2 { get; set; } = 1;
            public int MinTalent3 { get; set; } = 1;
        }
        public class OutData
        {
            public bool IsApplied { get; set; } = false;
            public int Level { get; set; } = 1;
            public int Talent1 { get; set; } = 1;
            public int Talent2 { get; set; } = 1;
            public int Talent3 { get; set; } = 1;
        }

        private void ButtonAppry_Click(object sender, EventArgs e)
        {
            Output = new()
            {
                IsApplied = true,
                Level = (int)NumericLevel.Value,
                Talent1 = (int)NumericTalent1.Value,
                Talent2 = (int)NumericTalent2.Value,
                Talent3 = (int)NumericTalent3.Value,
            };
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSetToLv90_Click(object sender, EventArgs e)
        {
            if (NumericLevel.Minimum <= 90) NumericLevel.Value = 90;
        }

        private void ButtonSetToTalent9_Click(object sender, EventArgs e)
        {
            if (NumericTalent1.Minimum <= 9) NumericTalent1.Value = 9;
            if (NumericTalent2.Minimum <= 9) NumericTalent2.Value = 9;
            if (NumericTalent3.Minimum <= 9) NumericTalent3.Value = 9;
        }

        private void ButtonSetToTalent10_Click(object sender, EventArgs e)
        {
            if (NumericTalent1.Minimum <= 10) NumericTalent1.Value = 10;
            if (NumericTalent2.Minimum <= 10) NumericTalent2.Value = 10;
            if (NumericTalent3.Minimum <= 10) NumericTalent3.Value = 10;
        }
    }
}
