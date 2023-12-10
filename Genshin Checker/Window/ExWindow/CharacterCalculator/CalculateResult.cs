using Genshin_Checker.App.HoYoLab;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genshin_Checker.App.General.Convert;
using Genshin_Checker.Window.Popup;

namespace Genshin_Checker.Window.ExWindow.CharacterCalculator
{
    
    public partial class CalculateResult : Form
    {
        Account Account;
        List<Input> Inputs;
        public CalculateResult(Account account,List<Input> inputs)
        {
            InitializeComponent();
            Inputs = inputs;
            Account = account;
        }
        public class Input
        {
            public int characterID { get; set; }
            public Range Level { get; set; } = new(1,90);
            public List<Range> Talent { get; set; } = new();
        }
        public class Range
        {
            public Range(int current, int to)
            {
                Current = current;
                To = to;
            }
            public int Current { get; set;}
            public int To { get; set; }
        }

        private async void CalculateResult_Load(object sender, EventArgs e)
        {
            int CharacterMora = 0;
            int CharacterExp = 0;
            int TalentMora = 0;
            int TalentCrown = 0;
            try
            {
                var characters = await Account.Characters.GetData();
                foreach(Input input in Inputs)
                {
                    var detail = await Account.CharacterDetail.GetData(input.characterID);
                    //キャラクターのスキルを取得
                    var skill = detail.skill_list.FindAll(a => a.max_level != 1);
                    if (skill.Count != 3) throw new ArgumentException($"天賦は3つしか対応していません。キャラクターの天賦は {skill.Count} つあります");
                    var character = characters.avatars.Find(a => a.id == input.characterID);
                    if (character == null) throw new ArgumentNullException(nameof(character), $"{input.characterID}が見つかりません。");
                    var skilllist = new List<Model.HoYoLab.CalculatorComputePost.SkillList>();
                    for (int i=0;i<skill.Count;i++)
                    {
                        skilllist.Add(new() { id = skill[i].group_id, level_current = input.Talent[i].Current, level_target = input.Talent[i].To });
                    }
                    foreach(var data in detail.skill_list.FindAll(a => a.max_level == 1))
                    {
                        skilllist.Add(new() { id = data.group_id, level_current = 1, level_target = 1 });
                    }
                    var post = new Model.HoYoLab.CalculatorComputePost.Root()
                    {
                        avatar_id = input.characterID,
                        avatar_level_current = input.Level.Current,
                        avatar_level_target = input.Level.To,
                        element_attr_id = (int)Element.GetElementEnum(character.element),
                        skill_list= skilllist
                    };
                    var result = await Account.Endpoint.ComputeCalculate(post);

                    foreach(var data in result.avatar_consume)
                    {
                        if (data.id == 202) //モラ
                        {
                            CharacterMora += data.num;
                            CharacterMoraResult.Text = $"{CharacterMora:#,##0}";
                            TotalMoraResult.Text = $"{(TalentMora + CharacterMora):#,##0}";
                        }
                        else if (data.id == 104003) //大英雄の経験
                        {
                            CharacterExp += data.num;
                            CharacterExpResult.Text = $"{CharacterExp:#,##0}";
                        }
                        else if (data.id > 104100 && data.id < 104200)
                        {
                            int id = (data.id - 104100) / 10; 
                            string str = "";
                            string type = "";
                            //Todo:ローカライズ忘れないように
                            switch (id) //アイテムidの10の位
                            {
                                case 0: str = "輝くダイヤ"; break;
                                case 1: str = "炎願のアゲート"; break;
                                case 2: str = "澄明なラピスラズリ"; break;
                                case 3: str = "成長のエメラルド"; break;
                                case 4: str = "最勝のアメシスト"; break;
                                case 5: str = "自由のターコイズ"; break;
                                case 6: str = "哀切なアイスクリスタル"; break;
                                case 7: str = "堅牢なトパーズ"; break;
                            }
                            switch (data.id % 10) //アイテムIDの1の位
                            {
                                case 1: type = nameof(AscensionNumSliver); break;
                                case 2: type = nameof(AscensionNumFragment); break;
                                case 3: type = nameof(AscensionNumChunk); break;
                                case 4: type = nameof(AscensionNumGemstone); break;
                                default: throw new ArgumentException($"{data.id} - {data.name} は不正な値です。");
                            }
                            var row = ViewAscensionMaterial.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(AscensionTypeID)].Value == id);
                            if (row == null)
                            {
                                ViewAscensionMaterial.Rows.Add(id, str, 0, 0, 0, 0);
                                row = ViewAscensionMaterial.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(AscensionTypeID)].Value == id);
                            }
                            if (row != null) row.Cells[type].Value = (int)row.Cells[type].Value + data.num;
                        }
                        else if (data.id > 113000 && data.id < 114000)
                        {
                            var row = ViewBossItem.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(BossItemID)].Value == data.id);
                            if (row == null)
                            {
                                ViewBossItem.Rows.Add(data.id, await App.WebRequest.ImageGetRequest(data.icon_url), data.name, data.num);
                            }
                            else row.Cells[nameof(BossItemNum)].Value = (int)row.Cells[nameof(BossItemNum)].Value + data.num;
                        }
                        else if ((data.id > 100000 && data.id <= 100099) || (data.id > 101200 && data.id <= 101299))
                        {
                            var row = ViewLocalSpecialtyItem.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(LocalSpecialtyID)].Value == data.id);
                            if (row == null)
                            {
                                ViewLocalSpecialtyItem.Rows.Add(data.id, await App.WebRequest.ImageGetRequest(data.icon_url), data.name, data.num);
                            }
                            else row.Cells[nameof(LocalSpecialtyItemNum)].Value = (int)row.Cells[nameof(LocalSpecialtyItemNum)].Value + data.num;
                        }else if ((data.id >= 112002 && data.id < 113000))
                        {
                            var row = ViewEnemyItems.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(EnemyItemID)].Value == data.id);
                            if (row == null)
                            {
                                ViewEnemyItems.Rows.Add(data.id, await App.WebRequest.ImageGetRequest(data.icon_url), data.name, data.num, 0, data.num);
                            }
                            else
                            {
                                row.Cells[nameof(EnemyItemCharacterNum)].Value = (int)row.Cells[nameof(EnemyItemCharacterNum)].Value + data.num;
                                row.Cells[nameof(EnemyItemTotalNum)].Value = (int)row.Cells[nameof(EnemyItemCharacterNum)].Value + (int)row.Cells[nameof(EnemyItemTalentNum)].Value;
                            }
                        }
                    }

                    foreach (var data in result.avatar_skill_consume)
                    {
                        if (data.id == 202)
                        {
                            TalentMora += data.num;
                            TalentMoraResult.Text = $"{TalentMora:#,##0}";
                            TotalMoraResult.Text = $"{(TalentMora + CharacterMora):#,##0}";
                        }
                        else if (data.id == 104319)
                        {
                            TalentCrown += data.num;
                            TalentCrownResult.Text = $"{TalentCrown:#,##0}";
                        }
                        else if (data.id > 104300 && data.id < 104400)
                        {
                            var id = data.id - 104301;
                            if (id >= 19) id -= 1;
                            //Todo:ここをAPI使うなり可変にする
                            string name = (id / 3) switch
                            {
                                0 => "自由",
                                1 => "抗争",
                                2 => "詩文",
                                3 => "繁栄",
                                4 => "勤労",
                                5 => "黄金",
                                6 => "浮世",
                                7 => "風雅",
                                8 => "天光",
                                9 => "忠言",
                                10 => "創意",
                                11 => "篤行",
                                12 => "公平",
                                13 => "正義",
                                14 => "秩序",
                                15 => "ナタ1",
                                16 => "ナタ2",
                                17 => "ナタ3",
                                18 => "スネージナヤ1",
                                19 => "スネージナヤ2",
                                20 => "スネージナヤ3",
                                _ => $"？？{id % 3 + 1}",
                            };
                            string day = (id / 3 % 3) switch
                            {
                                0 => "月・木",
                                1 => "火・金",
                                2 => "水・土",
                                _ => "？"
                            };
                            string pos = (id % 3) switch
                            {
                                0 => nameof(TalentItemNumTeachings),
                                1 => nameof(TalentItemNumGuide),
                                2 => nameof(TalentItemNumPhilosophies),
                                _ => throw new ArgumentException("idが不正です")
                            };
                            var row = ViewTalentItems.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(TalentItemID)].Value == id/3);
                            if (row == null)
                            {
                                ViewTalentItems.Rows.Add((int)id/3, name,day, 0, 0, 0);
                                row = ViewTalentItems.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(TalentItemID)].Value == id/3);
                            }
                            if (row != null) row.Cells[pos].Value = (int)row.Cells[pos].Value + data.num;
                        }
                        else if (data.id > 113000 && data.id < 114000)
                        {
                            var row = ViewWeeklyBossItems.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(WeeklyBossItemID)].Value == data.id);
                            if (row == null)
                            {
                                ViewWeeklyBossItems.Rows.Add(data.id, await App.WebRequest.ImageGetRequest(data.icon_url), data.name, data.num);
                            }
                            else row.Cells[nameof(WeeklyBossItemNum)].Value = (int)row.Cells[nameof(WeeklyBossItemNum)].Value + data.num;
                        }
                        else if ((data.id >= 112002 && data.id < 113000))
                        {
                            var row = ViewEnemyItems.Rows.Cast<DataGridViewRow>().ToList().Find(a => (int)a.Cells[nameof(EnemyItemID)].Value == data.id);
                            if (row == null)
                            {
                                ViewEnemyItems.Rows.Add(data.id, await App.WebRequest.ImageGetRequest(data.icon_url), data.name, 0, data.num, data.num);
                            }
                            else
                            {
                                row.Cells[nameof(EnemyItemTalentNum)].Value = (int)row.Cells[nameof(EnemyItemTalentNum)].Value + data.num;
                                row.Cells[nameof(EnemyItemTotalNum)].Value = (int)row.Cells[nameof(EnemyItemCharacterNum)].Value + (int)row.Cells[nameof(EnemyItemTalentNum)].Value;
                            }
                        }
                    }
                }

                ViewAscensionMaterial.Sort(ViewAscensionMaterial.Columns[nameof(AscensionTypeID)], ListSortDirection.Ascending);
                ViewBossItem.Sort(ViewBossItem.Columns[nameof(BossItemID)], ListSortDirection.Ascending);
                ViewLocalSpecialtyItem.Sort(ViewLocalSpecialtyItem.Columns[nameof(LocalSpecialtyID)], ListSortDirection.Ascending);
                ViewTalentItems.Sort(ViewTalentItems.Columns[nameof(TalentItemID)], ListSortDirection.Ascending);
                ViewWeeklyBossItems.Sort(ViewWeeklyBossItems.Columns[nameof(WeeklyBossItemID)], ListSortDirection.Ascending);
                ViewEnemyItems.Sort(ViewEnemyItems.Columns[nameof(EnemyItemID)], ListSortDirection.Ascending);
            }
            catch(Exception ex)
            {
                new ErrorMessage("データの読み込みに失敗しました。", ex.ToString()).ShowDialog();
            }
        }
    }
}
