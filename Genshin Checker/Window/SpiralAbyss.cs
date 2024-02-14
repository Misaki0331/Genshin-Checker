using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.UserData.SpiralAbyss.v1;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Popup;
using OpenTK.Graphics.ES20;
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
            public string name = "";
        }
        public SpiralAbyss(Account account)
        {
            InitializeComponent();
            Text = $"{Localize.WindowName_SpiralAbyss} (UID:{account.UID})";
            Icon = Icon.FromHandle(resource.icon.Battle_Chronicle.GetHicon());
            this.account = account;
            GeneralList = new();
            FloorList = new();
            LevelInfo = new();
            ComboData = new();
            var data = account.SpiralAbyss.GetList();
            data.Reverse();
            foreach (var i in data)
                ComboData.Add(new() { id = i, name = string.Format(Localize.UIName_SpiralAbyss_SeasonName, i) });
            foreach (var i in ComboData)
                comboBox1.Items.Add(i.name);
            if (ComboData.Count > 0) comboBox1.SelectedIndex = 0;
            else comboBox1.Enabled = false;
        }

        private void SpiralAbyss_Load(object sender, EventArgs e)
        {
            LoadDataCurrent();
        }
        void PanelReset()
        {
            Trace.WriteLine("PanelReset");
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
            PanelReset();
            Trace.WriteLine("PanelLoad");
            CurrentDisplayData = v1;
            var data = v1.Data;
            LabelScheduleName.Text = string.Format(Localize.UIName_SpiralAbyss_ResultTitle, data.schedule_id);
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
            CharacterCount = new(account, Localize.WindowName_SpiralAbyss_MostPlayedCharacters, characters);
            CharacterCount.ClickHandler += a => GameRecords_Character_Click(a);
            PanelCharacterCount.Controls.Add(CharacterCount);
            ///最多撃破数
            characters = new();
            foreach (var character in data.Ranks.Defeat) characters.Add(new(character.id, $"{character.value:#,##0}"));
            var con = new UI.Control.SpiralAbyss.CharacterFrame(account, Localize.WindowName_SpiralAbyss_MostDefeats, characters);
            con.ClickHandler += a => GameRecords_Character_Click(a);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            ///最大ダメージ
            characters = new();
            foreach (var character in data.Ranks.Damage) characters.Add(new(character.id, $"{character.value:#,##0}"));
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, Localize.WindowName_SpiralAbyss_StrongestSingleStrike, characters);
            con.ClickHandler += a => GameRecords_Character_Click(a);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            ///受けた最大ダメージ
            characters = new();
            foreach (var character in data.Ranks.TakeDamage) characters.Add(new(character.id, $"{character.value:#,##0}"));
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, Localize.WindowName_SpiralAbyss_MostDamageTaken, characters);
            con.ClickHandler += a => GameRecords_Character_Click(a);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            ///元素爆発使用回数
            characters = new();
            foreach (var character in data.Ranks.EnergySkill) characters.Add(new(character.id, $"{character.value:#,##0}"));
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, Localize.WindowName_SpiralAbyss_ElementalBurstsUnleashed, characters);
            con.ClickHandler += a => GameRecords_Character_Click(a);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            ///元素スキル使用回数
            characters = new();
            foreach (var character in data.Ranks.NormalSkill) characters.Add(new(character.id, $"{character.value:#,##0}"));
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, Localize.WindowName_SpiralAbyss_ElementalSkillsCast, characters);
            con.ClickHandler += a => GameRecords_Character_Click(a);
            FlowGeneralData.Controls.Add(con);
            GeneralList.Add(con);
            Trace.WriteLine($"GeneralList:{GeneralList.Count}");

            var floor = data.floors.FindAll(a => true);
            foreach (var f in floor)
            {
                var str = f.is_unlock ? $"{f.star} / {f.max_star}" : Localize.WindowName_SpiralAbyss_Locked;
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
            //PanelFloorsInfo.Visible = false;
            PanelFloorsInfo.SuspendLayout();
            foreach (var f in LevelInfo)
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
            LabelFloorName.Text = string.Format(Localize.UIName_SpiralAbyss_Floor, floors.index);
            LabelFloorStars.Text = $"{floors.star} / {floors.max_star}";
            LabelFloorInfomation.Text = string.Join("\n", floors.ley_line_disorder);
            if (string.IsNullOrEmpty(LabelFloorInfomation.Text)) LabelFloorInfomation.Visible = false;
            else LabelFloorInfomation.Visible = true;
            PanelFloor.Visible = true;
            var levels = floors.levels.FindAll(A => true);
            levels.Reverse();
            foreach (var level in levels)
            {
                var control = new UI.Control.SpiralAbyss.LevelInfo(account, level, !CheckSummarize.Checked) { Dock = DockStyle.Top, BorderStyle = BorderStyle.FixedSingle };
                control.CharacterClickHandler += a => GameRecords_Character_Click(a);
                PanelFloorsInfo.Controls.Add(control);
                LevelInfo.Add(control);
            }
            PanelFloorsInfo.ResumeLayout(true);
        }


        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var find = ComboData.Find(a => a.name == comboBox1.Text);
            if (find == null) return;
            try
            {
                var GameData = await account.SpiralAbyss.Load(find.id);
                this.SuspendLayout();
                PanelLoad(GameData);
                this.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                new ErrorMessage(Common.CommonErrorOccurred, ex.ToString()).ShowDialog();
            }

        }

        ExWindow.GameRecords.CharacterDetail? CharacterForm = null;
        private void GameRecords_Character_Click(int id)
        {
            if (CharacterForm == null || CharacterForm.IsDisposed)
            {
                CharacterForm = new();
            }
            var Data = account.GameRecords.Data;
            if (Data == null) return;
            var character = Data.avatars.Find(a => a.id == id);
            if (character == null) return;
            CharacterForm.DataUpdate(account, id, character.name);
            CharacterForm.Show();
            CharacterForm.Activate();

        }
        bool FirstResize = false;
        protected override void OnResize(EventArgs e)
        {
            if (!FirstResize)
            {
                this.Invalidate();
                this.PerformLayout();
                FirstResize = true;
            }
        }
        private void SpiralAbyss_ResizeEnd(object sender, EventArgs e)
        {
            PanelFloorsInfo.Visible = false;
            this.Invalidate();
            this.PerformLayout();
            PanelFloorsInfo.Visible = true;
            FirstResize = false;
        }

        private void SpiralAbyss_Resize(object sender, EventArgs e)
        {
        }

        private void SpiralAbyss_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CharacterForm != null && !CharacterForm.IsDisposed) CharacterForm.Dispose();
        }

        private void CheckSummarize_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            PanelFloorsInfo.SuspendLayout();
            foreach (var l in LevelInfo) {
                l.SuspendLayout();
                l.ShowInline = !CheckSummarize.Checked;
                l.ResumeLayout(true);
            }
            PanelFloorsInfo.ResumeLayout(true);
            ResumeLayout(true);
        }
    }
}
