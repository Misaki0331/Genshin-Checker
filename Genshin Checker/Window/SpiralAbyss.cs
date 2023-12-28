﻿using Genshin_Checker.App.HoYoLab;
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
        UI.Control.SpiralAbyss.CharacterFrame? CharacterCount;
        List<UI.Control.SpiralAbyss.CharacterFrame> GeneralList;
        public SpiralAbyss(Account account)
        {
            InitializeComponent();
            this.account = account;
            GeneralList = new();
            LoadDataCurrent();
        }

        private void SpiralAbyss_Load(object sender, EventArgs e)
        {

        }
        async void LoadDataCurrent()
        {
            var GameData = await account.SpiralAbyss.GetCurrent();
            var data = GameData.Data;
            LabelScheduleName.Text = $"第 {data.schedule_id} 回 深境螺旋結果";
            LabelTimestamp.Text = $"{DateTimeOffset.FromUnixTimeSeconds(data.ScheduleTime.start).ToLocalTime():yyyy/MM/dd HH:mm:ss} ～ {DateTimeOffset.FromUnixTimeSeconds(data.ScheduleTime.end).ToLocalTime():yyyy/MM/dd HH:mm:ss}";

            LabelLatestArea.Text = data.max_floor;
            LabelStarCount.Text = $"★{data.total_star}";
            LabelPlayCount.Text = $"{data.total_battle_times:#,##0}";
            LabelWinCount.Text = $"{data.total_win_times:#,##0}";

            if (CharacterCount != null && !CharacterCount.IsDisposed)
            {
                PanelCharacterCount.Controls.Remove(CharacterCount);
                CharacterCount.Dispose();
            }
            var characters = new List<UI.Control.SpiralAbyss.CharacterFrame.CharacterArgment>();
            foreach(var character in data.Ranks.Reveal) {
                characters.Add(new(character.id,$"{character.value:#,##0}"));
            }
            CharacterCount = new(account, "出撃回数",characters);
            PanelCharacterCount.Controls.Add(CharacterCount);
            foreach(var control in GeneralList)
            {
                if (control.IsDisposed) continue;
                FlowGeneralData.Dispose();
                FlowGeneralData.Controls.Remove(control);
            }
            GeneralList.Clear();
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
            con = new UI.Control.SpiralAbyss.CharacterFrame(account, "受けた最大ダメージ", characters);
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


        }
    }
}
