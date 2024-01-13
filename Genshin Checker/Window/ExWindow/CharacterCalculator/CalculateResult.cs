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
using Genshin_Checker.resource.Languages;

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
            Icon = Icon.FromHandle(resource.icon.calculator_new.GetHicon());
            Text = Localize.WindowName_CalculateResult;
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
        DataGridViewRow? GetRow(DataGridView data, Predicate<DataGridViewRow> predicate)
        {
            return data.Rows.Cast<DataGridViewRow>().ToList().Find(predicate);
        }
        void CalcurateResin(int CharaExp, int CharaMora,int BossItem,int TalentMora, int TalentBooks)
        {
            int world = Account.EnkaNetwork.Data.playerInfo.worldLevel;
            bool reached = Account.EnkaNetwork.Data.playerInfo.level == 60;
            double Drop = world switch
            {
                0 => 1.6185,
                1 => 1.6185,
                2 => 1.7037,
                3 => 1.8741,
                4 => 2.0445,
                5 => 2.2149,
                6 => 2.3852,
                7 => 2.5556,
                _ => 2.5556
            };
            double bossresin = BossItem / Drop * 40.0;
            double talentresin = TalentBooks / 9.0 * 20.0;
            int per = world switch
            {
                0 => 12000,
                1 => 20000,
                2 => 28000,
                3 => 36000,
                4 => 44000,
                5 => 52000,
                _ => 60000
            };
            per += reached ? 100 : 0;
            double chararesin = CharaMora / per * 20;
            double talentmoraresin = TalentMora / per * 20;

            per = world switch
            {
                0 => 25000,
                1 => 38500,
                2 => 52500,
                3 => 67500,
                4 => 82500,
                5 => 102500,
                _ => 122500
            };
            double charaexpresin = CharaExp / per * 20;
            ResinCharaExp.Text = $"{charaexpresin:#,##0.00}";
            ResinBossItem.Text = $"{bossresin:#,##0.00}";
            ResinCharacterMora.Text = $"{chararesin:#,##0.00}";
            ResinTalentBooks.Text = $"{talentresin:#,##0.00}";
            ResinTalentMora.Text = $"{talentmoraresin:#,##0.00}";
            double total = bossresin + talentresin + chararesin + talentmoraresin + charaexpresin;
            ResinTotal.Text = $"{total:#,##0.00}";


        }
        private async void CalculateResult_Load(object sender, EventArgs e)
        {
            int CharacterMora = 0;
            int CharacterExp = 0;
            int TalentMora = 0;
            int TalentCrown = 0;
            int BossItemCount = 0;
            int TalentBooksCount = 0;
            int cnt = 0;
            try
            {
                var characters = await Account.Characters.GetData();
                foreach(Input input in Inputs)
                {
                    cnt++;
                    ProgressState.Text = string.Format(Localize.WindowName_CalculateResult_Loading, cnt, Inputs.Count);
                    progressBar.Value = 10000*cnt/Inputs.Count;
                    var detail = await Account.CharacterDetail.GetData(input.characterID);
                    //キャラクターのスキルを取得
                    var skill = detail.skill_list.FindAll(a => a.max_level != 1);
                    if (skill.Count != 3) throw new ArgumentException(string.Format(Localize.Error_CalculateResult_InvalidTalentCount,skill.Count));
                    var character = characters.avatars.Find(a => a.id == input.characterID);
                    if (character == null) throw new ArgumentNullException(nameof(character), string.Format(Localize.Error_CalculateResult_CharacterNotFound, input.characterID));
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
                            string type = "";
                            switch (data.id % 10) //アイテムIDの1の位
                            {
                                case 1: type = nameof(AscensionNumSliver); break;
                                case 2: type = nameof(AscensionNumFragment); break;
                                case 3: type = nameof(AscensionNumChunk); break;
                                case 4: type = nameof(AscensionNumGemstone); break;
                                default: throw new ArgumentException(string.Format(Localize.Error_CalculateResult_InvalidItemID, data.id, data.name));
                            }
                            var row = GetRow(ViewAscensionMaterial, a => (int)a.Cells[nameof(AscensionTypeID)].Value == id);
                            if (row == null)
                            {
                                ViewAscensionMaterial.Rows.Add(id, id, 0, 0, 0, 0);
                                row = GetRow(ViewAscensionMaterial, a => (int)a.Cells[nameof(AscensionTypeID)].Value == id);
                            }
                            if (row != null) row.Cells[type].Value = (int)row.Cells[type].Value + data.num;
                        }
                        else if (data.id > 113000 && data.id < 114000)
                        {
                            var row = GetRow(ViewBossItem, a => (int)a.Cells[nameof(BossItemID)].Value == data.id);
                            if (row == null)
                            {
                                ViewBossItem.Rows.Add(data.id, await App.WebRequest.ImageGetRequest(data.icon_url), data.name, data.num);
                            }
                            else row.Cells[nameof(BossItemNum)].Value = (int)row.Cells[nameof(BossItemNum)].Value + data.num;
                            BossItemCount += data.num;
                        }
                        else if ((data.id > 100000 && data.id <= 100099) || (data.id > 101200 && data.id <= 101299))
                        {
                            var row = GetRow(ViewLocalSpecialtyItem, a => (int)a.Cells[nameof(LocalSpecialtyID)].Value == data.id);
                            if (row == null)
                            {
                                ViewLocalSpecialtyItem.Rows.Add(data.id, await App.WebRequest.ImageGetRequest(data.icon_url), data.name, data.num);
                            }
                            else row.Cells[nameof(LocalSpecialtyItemNum)].Value = (int)row.Cells[nameof(LocalSpecialtyItemNum)].Value + data.num;
                        }else if ((data.id >= 112002 && data.id < 113000))
                        {
                            var row = GetRow(ViewEnemyItems, a => (int)a.Cells[nameof(EnemyItemID)].Value == data.id);
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
                            string pos = (id % 3) switch
                            {
                                0 => nameof(TalentItemNumTeachings),
                                1 => nameof(TalentItemNumGuide),
                                2 => nameof(TalentItemNumPhilosophies),
                                _ => throw new ArgumentException(string.Format(Localize.Error_CalculateResult_InvalidItemID, data.id, data.name))
                            };
                            var row = GetRow(ViewTalentItems, a => (int)a.Cells[nameof(TalentItemID)].Value == id / 3);
                            if (row == null)
                            {
                                ViewTalentItems.Rows.Add((int)id / 3, (int)id / 3, (int)id / 3 % 3, 0, 0, 0);
                                row = GetRow(ViewTalentItems, a => (int)a.Cells[nameof(TalentItemID)].Value == id / 3);
                            }
                            if (row != null) row.Cells[pos].Value = (int)row.Cells[pos].Value + data.num;
                            int x = 1;
                            if (id % 3 == 1) x = 3;
                            if (id % 3 == 2) x = 9;
                            TalentBooksCount += data.num * x;
                        }
                        else if (data.id > 113000 && data.id < 114000)
                        {
                            var row = GetRow(ViewWeeklyBossItems, a => (int)a.Cells[nameof(WeeklyBossItemID)].Value == data.id);
                            if (row == null)
                            {
                                ViewWeeklyBossItems.Rows.Add(data.id, await App.WebRequest.ImageGetRequest(data.icon_url), data.name, data.num);
                            }
                            else row.Cells[nameof(WeeklyBossItemNum)].Value = (int)row.Cells[nameof(WeeklyBossItemNum)].Value + data.num;
                        }
                        else if ((data.id >= 112002 && data.id < 113000))
                        {
                            var row = GetRow(ViewEnemyItems, a => (int)a.Cells[nameof(EnemyItemID)].Value == data.id);
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
                    CalcurateResin(CharacterExp*20000,CharacterMora, BossItemCount, TalentMora, TalentBooksCount);
                }

                ViewAscensionMaterial.Sort(ViewAscensionMaterial.Columns[nameof(AscensionTypeID)], ListSortDirection.Ascending);
                ViewAscensionMaterial.ClearSelection();
                ViewBossItem.Sort(ViewBossItem.Columns[nameof(BossItemID)], ListSortDirection.Ascending);
                ViewBossItem.ClearSelection();
                ViewLocalSpecialtyItem.Sort(ViewLocalSpecialtyItem.Columns[nameof(LocalSpecialtyID)], ListSortDirection.Ascending);
                ViewLocalSpecialtyItem.ClearSelection();
                ViewTalentItems.Sort(ViewTalentItems.Columns[nameof(TalentItemID)], ListSortDirection.Ascending);
                ViewTalentItems.ClearSelection();
                ViewWeeklyBossItems.Sort(ViewWeeklyBossItems.Columns[nameof(WeeklyBossItemID)], ListSortDirection.Ascending);   
                ViewWeeklyBossItems.ClearSelection();
                ViewEnemyItems.Sort(ViewEnemyItems.Columns[nameof(EnemyItemID)], ListSortDirection.Ascending);
                ViewEnemyItems.ClearSelection();
                ProgressPanel.Visible = false;
            }
            catch(Exception ex)
            {
                new ErrorMessage(Localize.Error_CharacterResult_FailedToLoad, ex.ToString()).ShowDialog();
            }
        }

        private void TableFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is not DataGridView) return;
            var Table = (DataGridView)sender;
            var row = Table.Rows[e.RowIndex];
            switch (Table.Name)
            {
                // 元素宝石
                case nameof(ViewAscensionMaterial):
                    switch (Table.Columns[e.ColumnIndex].Name)
                    {
                        case nameof(AscensionType):
                            e.Value = (int)row.Cells[nameof(AscensionTypeID)].Value switch
                            {
                                0 => Genshin.Ascension_BrilliantDiamond,
                                1 => Genshin.Ascension_AgnidusAgate,
                                2 => Genshin.Ascension_VarunadaLazurite,
                                3 => Genshin.Ascension_NagadusEmerald,
                                4 => Genshin.Ascension_VajradaAmethyst,
                                5 => Genshin.Ascension_VayudaTurquoise,
                                6 => Genshin.Ascension_ShivadaJade,
                                7 => Genshin.Ascension_PrithivaTopaz,
                                _ => Common.Unknown
                            };
                            break;
                    }
                    e.CellStyle.BackColor = (int)row.Cells[nameof(AscensionTypeID)].Value switch
                    {
                        1 => Element.GetBackgroundColor(Element.ElementType.Pyro),
                        2 => Element.GetBackgroundColor(Element.ElementType.Hydro),
                        3 => Element.GetBackgroundColor(Element.ElementType.Dendro),
                        4 => Element.GetBackgroundColor(Element.ElementType.Electro),
                        5 => Element.GetBackgroundColor(Element.ElementType.Anemo),
                        6 => Element.GetBackgroundColor(Element.ElementType.Cryo),
                        7 => Element.GetBackgroundColor(Element.ElementType.Geo),
                        _ => Element.GetBackgroundColor(Element.ElementType.Unknown)
                    };
                    break;
                // 精鋭ボス
                case nameof(ViewBossItem):
                    break;
                // 精鋭ドロップ素材
                case nameof(ViewEnemyItems):
                    switch (Table.Columns[e.ColumnIndex].Name)
                    {
                        case nameof(EnemyItemCharacterNum):
                        case nameof(EnemyItemTalentNum):
                            if (e.Value == null || (int)e.Value == 0) e.Value = "";
                            break;
                    }
                    var id = (int)row.Cells[nameof(EnemyItemID)].Value - 112002;
                    e.CellStyle.BackColor = (id % 3) switch
                    {
                        0 => Rarity.GetBackgroundColor(Rarity.RarityType.Common),
                        1 => Rarity.GetBackgroundColor(Rarity.RarityType.Uncommon),
                        2 => Rarity.GetBackgroundColor(Rarity.RarityType.Rare),
                        _ => Rarity.GetBackgroundColor(Rarity.RarityType.Unknown)
                    };
                    break;
                // 特産素材
                case nameof(ViewLocalSpecialtyItem):
                    break;
                // 天賦素材
                case nameof(ViewTalentItems):
                    switch (Table.Columns[e.ColumnIndex].Name)
                    {
                        case nameof(TalentItemName):
                            e.CellStyle.BackColor = ((int)row.Cells[nameof(TalentItemID)].Value / 3) switch
                            {
                                0 => World.GetBackgroundColor(World.Country.Mondstadt),
                                1 => World.GetBackgroundColor(World.Country.Liyue),
                                2 => World.GetBackgroundColor(World.Country.Inazuma),
                                3 => World.GetBackgroundColor(World.Country.Sumeru),
                                4 => World.GetBackgroundColor(World.Country.Fontaine),
                                5 => World.GetBackgroundColor(World.Country.Natlan),
                                6 => World.GetBackgroundColor(World.Country.Snezhnaya),
                                _ => World.GetBackgroundColor(World.Country.Unknown)
                            };
                            e.Value = (int)row.Cells[nameof(TalentItemID)].Value switch
                            {
                                0 => Genshin.TalentBook_1_1,
                                1 => Genshin.TalentBook_1_2,
                                2 => Genshin.TalentBook_1_3,
                                3 => Genshin.TalentBook_2_1,
                                4 => Genshin.TalentBook_2_2,
                                5 => Genshin.TalentBook_2_3,
                                6 => Genshin.TalentBook_3_1,
                                7 => Genshin.TalentBook_3_2,
                                8 => Genshin.TalentBook_3_3,
                                9 => Genshin.TalentBook_4_1,
                                10 => Genshin.TalentBook_4_2,
                                11 => Genshin.TalentBook_4_3,
                                12 => Genshin.TalentBook_5_1,
                                13 => Genshin.TalentBook_5_2,
                                14 => Genshin.TalentBook_5_3,
                                15 => Genshin.TalentBook_6_1,
                                16 => Genshin.TalentBook_6_2,
                                17 => Genshin.TalentBook_6_3,
                                18 => Genshin.TalentBook_7_1,
                                19 => Genshin.TalentBook_7_2,
                                20 => Genshin.TalentBook_7_3,
                                _ => Common.Unknown,
                            };
                            break;
                        case nameof(TalentItemOpenDays):
                            if (e.Value == null) return;
                            var color = Color.FromArgb(0xFF, 0xFF, 0xCC, 0xCC);
                            var today = -1;
                            switch (Server.GameServerDate(Account.Server).DayOfWeek)
                            {
                                case DayOfWeek.Monday:
                                case DayOfWeek.Thursday:
                                    today = 0;
                                    break;
                                case DayOfWeek.Tuesday:
                                case DayOfWeek.Friday:
                                    today = 1;
                                    break;
                                case DayOfWeek.Wednesday:
                                case DayOfWeek.Saturday:
                                    today = 2;
                                    break;
                            }
                            if ((int)e.Value == today || today < 0) e.CellStyle.BackColor = color;
                            e.Value = (int)e.Value switch
                            {
                                0 => Common.Week_Mon_Thu,
                                1 => Common.Week_Tue_Fri,
                                2 => Common.Week_Wed_Sat,
                                _ => Common.Unknown
                            };
                            break;
                    }
                    break;
                // 週ボスドロップ素材
                case nameof(ViewWeeklyBossItems):
                    break;
            }
        }

        private void ViewLeave(object sender, EventArgs e)
        {
            if (sender is DataGridView view)
            {
                view.ClearSelection();
            }
        }
    }
}
