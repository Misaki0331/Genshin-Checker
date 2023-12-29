using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.UserData.SpiralAbyss.v1;
using OpenTK.Graphics.ES20;
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
    public partial class SpiralAbyss : Form
    {
        Account account;
        V1? CurrentDisplayData = null;
        List<UI.Control.SpiralAbyss.LevelInfo> LevelInfo;
        UI.Control.SpiralAbyss.CharacterFrame? CharacterCount;
        List<UI.Control.SpiralAbyss.CharacterFrame> GeneralList;
        List<UI.Control.SpiralAbyss.FloorInfo> FloorList;
        List<ComboBoxData> ComboData;
        class ComboBoxData
        {
            public int id;
            public string name="";
        }
        public SpiralAbyss(Account account)
        {
            InitializeComponent();
            Text = $"深境螺旋 (UID:{account.UID})";
            Icon = Icon.FromHandle(resource.icon.Battle_Chronicle.GetHicon());
            this.account = account;
            GeneralList = new();
            FloorList = new();
            LevelInfo = new();
            ComboData = new();
            var data = account.SpiralAbyss.GetList();
            data.Reverse();
            foreach (var i in data)
                ComboData.Add(new() { id = i, name = $"螺旋 {i} 期" });
            foreach (var i in ComboData)
                comboBox1.Items.Add(i.name);
            if (ComboData.Count > 0) comboBox1.SelectedIndex = 0;
            else comboBox1.Enabled = false;
            LoadDataCurrent();
        }

        private void SpiralAbyss_Load(object sender, EventArgs e)
        {
        }
        void PanelReset()
        {
            if (CharacterCount != null && !CharacterCount.IsDisposed)
            {
                PanelCharacterCount.Controls.Remove(CharacterCount);
                CharacterCount.Dispose();
            }
            foreach (var control in GeneralList)
            {
                if (control.IsDisposed) continue;
                control.Dispose();
                FlowGeneralData.Controls.Remove(control);
            }
            GeneralList.Clear();
            foreach (var control in FloorList)
            {
                if (control.IsDisposed) continue;
                control.Dispose();
                panel1.Controls.Remove(control);
            }
            FloorList.Clear();

            LoadFloorData(-1);
        }
        void PanelLoad(V1 v1)
        {
            CurrentDisplayData = v1;
            var data = v1.Data;
            LabelScheduleName.Text = $"第 {data.schedule_id} 回 深境螺旋結果";
            LabelTimestamp.Text = $"{DateTimeOffset.FromUnixTimeSeconds(data.ScheduleTime.start).ToLocalTime():yyyy/MM/dd HH:mm:ss} ～ {DateTimeOffset.FromUnixTimeSeconds(data.ScheduleTime.end).ToLocalTime():yyyy/MM/dd HH:mm:ss}";

            LabelLatestArea.Text = data.max_floor;
            LabelStarCount.Text = $"★{data.total_star}";
            LabelPlayCount.Text = $"{data.total_battle_times:#,##0}";
            LabelWinCount.Text = $"{data.total_win_times:#,##0}";

            var characters = new List<UI.Control.SpiralAbyss.CharacterFrame.CharacterArgment>();
            foreach (var character in data.Ranks.Reveal)
            {
                characters.Add(new(character.id, $"{character.value:#,##0}"));
            }
            CharacterCount = new(account, "出撃回数", characters);
            PanelCharacterCount.Controls.Add(CharacterCount);
            ///最多撃破数
            characters = new();
            foreach (var character in data.Ranks.Defeat) characters.Add(new(character.id, $"{character.value:#,##0}"));
            var con = new UI.Control.SpiralAbyss.CharacterFrame(account, "最多撃破数", characters);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            ///最大ダメージ
            characters = new();
            foreach (var character in data.Ranks.Damage) characters.Add(new(character.id, $"{character.value:#,##0}"));
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, "最大ダメージ", characters);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            ///受けた最大ダメージ
            characters = new();
            foreach (var character in data.Ranks.TakeDamage) characters.Add(new(character.id, $"{character.value:#,##0}"));
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, "最大被ダメージ", characters);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            ///元素爆発使用回数
            characters = new();
            foreach (var character in data.Ranks.EnergySkill) characters.Add(new(character.id, $"{character.value:#,##0}"));
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, "元素爆発回数", characters);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            ///元素スキル使用回数
            characters = new();
            foreach (var character in data.Ranks.NormalSkill) characters.Add(new(character.id, $"{character.value:#,##0}"));
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, "元素スキル回数", characters);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);


            var floor = data.floors.FindAll(a => true);
            foreach (var f in floor)
            {
                var str = f.is_unlock ? $"{f.star} / {f.max_star}" : "未開放";
                DateTime latest = DateTime.MinValue;
                foreach (var a in f.levels)
                {
                    var t = DateTimeOffset.FromUnixTimeSeconds(a.timestamp).ToLocalTime();
                    if (latest < t.DateTime) latest = t.DateTime;
                }
                var controls = new UI.Control.SpiralAbyss.FloorInfo(f.index, str, !f.is_unlock, string.Join("\n", f.ley_line_disorder), f.levels.Count > 0 ? latest : null) { Dock = DockStyle.Top };
                controls.ClickHandler += Floors_ClickHandler;
                panel1.Controls.Add(controls);
                FloorList.Add(controls);
            }
        }
        async void LoadDataCurrent()
        {
            PanelReset();
            var GameData = await account.SpiralAbyss.GetCurrent();
            PanelLoad(GameData);
            
        }

        private void Floors_ClickHandler(int args)
        {
            LoadFloorData(args);
        }
        int CurrentFloorIndex;
        void LoadFloorData(int index)
        {
            if (CurrentFloorIndex == index) return;
            else CurrentFloorIndex = index;
            PanelFloorsInfo.Visible = false;
            PanelFloorsInfo.SuspendLayout();
            foreach(var f in LevelInfo)
            {
                PanelFloorsInfo.Controls.Remove(f);
                f.Dispose();
            }
            PanelFloor.Visible = false;
            LevelInfo.Clear();

            PanelFloorsInfo.ResumeLayout(true);
            if (CurrentDisplayData == null) return;
            var floors = CurrentDisplayData.Data.floors.Find(a => a.index == index);
            if (floors == null) return;
            if (CurrentDisplayData == null) return;

            PanelFloorsInfo.SuspendLayout();
            LabelFloorName.Text = $"第 {floors.index} 層";
            LabelFloorStars.Text = $"{floors.star} / {floors.max_star}";
            LabelFloorInfomation.Text = string.Join("\n", floors.ley_line_disorder);
            if (string.IsNullOrEmpty(LabelFloorInfomation.Text)) LabelFloorInfomation.Visible = false;
            else LabelFloorInfomation.Visible = true;
            PanelFloor.Visible = true;
            var levels = floors.levels.FindAll(A => true);
            levels.Reverse();
            foreach(var level in levels)
            {
                var control = new UI.Control.SpiralAbyss.LevelInfo(account, level) { Dock=DockStyle.Top,BorderStyle=BorderStyle.FixedSingle};
                PanelFloorsInfo.Controls.Add(control);
                LevelInfo.Add(control);
            }
            PanelFloorsInfo.ResumeLayout(true);

            PanelFloorsInfo.Visible = true;
        }
        
        protected override void OnResize(EventArgs e)
        {
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var find = ComboData.Find(a => a.name == comboBox1.Text);
            this.SuspendLayout();
            PanelReset();
            this.ResumeLayout(true);
            if (find == null) return;
            var GameData = await account.SpiralAbyss.Load(find.id);

            this.SuspendLayout();
            PanelLoad(GameData);
            this.ResumeLayout(true);

        }
    }
}
