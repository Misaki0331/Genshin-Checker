using Genshin_Checker.App;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.HoYoLab.CharacterDetail;
using Genshin_Checker.Window.ExWindow.CharacterCalculator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
                ElementType.Anemo => Color.FromArgb(0xDD, 0xFF, 0xDD),
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
            var userdata = DataLoad();
            for(int i=0; i<characters.Count; i++)
            {
                Text = $"{i}/{characters.Count}";
                var character = characters[i];
                var charainfo = await account.CharacterDetail.GetData(character.id);
                var talent = charainfo.skill_list.FindAll(a=>a.max_level!=1);
                var set = userdata.Datas.FirstOrDefault(a=>a.Key==character.id);
                var setdata = set.Value;
                if (setdata == null) setdata = new();
                if(talent.Count!=3)throw new InvalidDataException("天賦レベルが不整合です。");
                CharacterView.Rows.Add(setdata.Enabled, character.id, character.rarity, character.element, character.name, character.weapon.type_name, character.fetter, character.level,
                    talent[0].level_current, talent[1].level_current, talent[2].level_current, "",
                    character.level > setdata.SetLevel ? character.level : setdata.SetLevel,
                    talent[0].level_current > setdata.SetTalent1 ? talent[0].level_current : setdata.SetTalent1,
                    talent[1].level_current > setdata.SetTalent2 ? talent[1].level_current : setdata.SetTalent2,
                    talent[2].level_current > setdata.SetTalent3 ? talent[2].level_current : setdata.SetTalent3);
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
                Exceptions.Reverse();
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
                case "ToArrow":
                case "ToLevel":
                case "ToTalentLevel1":
                case "ToTalentLevel2":
                case "ToTalentLevel3":
                    if ((bool)CharacterView[CharacterView.Columns["CalculateStatus"].Index, e.RowIndex].Value)
                    {
                        switch (CharacterView.Columns[e.ColumnIndex].Name)
                        {
                            case "ToArrow":
                                e.Value = "⇒";
                                break;
                        }
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.LightGray;
                        e.Value = "";
                    }
                    break;
            }
        }

        private async void ButtonBatch_Click(object sender, EventArgs e)
        {
            var select = CharacterView.SelectedRows;
            if (select.Count == 1)
            {
                var info = await account.CharacterDetail.GetData((int)select[0].Cells["ID"].Value);
                var skills = info.skill_list.FindAll(a => a.max_level != 1);
                if (skills.Count != 3) return;
                var form = new BatchWindow(new()
                {
                    IsMultiSelect = false,
                    CharacterName = (string)select[0].Cells["CharacterName"].Value,
                    Talent1Name = skills[0].name,
                    Talent2Name = skills[1].name,
                    Talent3Name = skills[2].name,
                    MinLevel = (int)select[0].Cells["CurrentLevel"].Value,
                    MinTalent1 = (int)select[0].Cells["CurrentTalentLevel1"].Value,
                    MinTalent2 = (int)select[0].Cells["CurrentTalentLevel2"].Value,
                    MinTalent3 = (int)select[0].Cells["CurrentTalentLevel3"].Value,
                    CurrentLevel = (int)select[0].Cells["ToLevel"].Value,
                    CurrentTalent1 = (int)select[0].Cells["ToTalentLevel1"].Value,
                    CurrentTalent2 = (int)select[0].Cells["ToTalentLevel2"].Value,
                    CurrentTalent3 = (int)select[0].Cells["ToTalentLevel3"].Value,
                    StatusEnabled = (bool)select[0].Cells["CalculateStatus"].Value,
                });
                form.ShowDialog();
                var change = form.Output;
                if (change.IsApplied)
                {
                    select[0].Cells["ToLevel"].Value = change.Level;
                    select[0].Cells["ToTalentLevel1"].Value = change.Talent1;
                    select[0].Cells["ToTalentLevel2"].Value = change.Talent2;
                    select[0].Cells["ToTalentLevel3"].Value = change.Talent3;
                    if (change.StatusEnabled != null) 
                        select[0].Cells["CalculateStatus"].Value = change.StatusEnabled;
                    DataSave();
                }
            }else if(CharacterView.SelectedRows.Count > 1) {
                var form = new BatchWindow(new()
                {
                    IsMultiSelect = true,
                });
                form.ShowDialog();
                var change = form.Output;
                if(change.IsApplied)
                {
                    foreach(DataGridViewRow row in select)
                    {
                        if (change.Level >= (int)row.Cells["CurrentLevel"].Value)
                            row.Cells["ToLevel"].Value = change.Level;
                        else row.Cells["ToLevel"].Value = (int)row.Cells["CurrentLevel"].Value;
                        if (change.Talent1 >= (int)row.Cells["CurrentTalentLevel1"].Value)
                            row.Cells["ToTalentLevel1"].Value = change.Talent1;
                        else row.Cells["ToTalentLevel1"].Value = (int)row.Cells["CurrentTalentLevel1"].Value;
                        if (change.Talent2 >= (int)row.Cells["CurrentTalentLevel2"].Value)
                            row.Cells["ToTalentLevel2"].Value = change.Talent2;
                        else row.Cells["ToTalentLevel2"].Value = (int)row.Cells["CurrentTalentLevel2"].Value;
                        if (change.Talent3 >= (int)row.Cells["CurrentTalentLevel3"].Value)
                            row.Cells["ToTalentLevel3"].Value = change.Talent3;
                        else row.Cells["ToTalentLevel3"].Value = (int)row.Cells["CurrentTalentLevel3"].Value;
                        if (change.StatusEnabled != null) 
                            row.Cells["CalculateStatus"].Value = change.StatusEnabled;
                    }
                    DataSave();
                }
            }
        }

        private void ButtonSelectAll_Click(object sender, EventArgs e)
        {
            CharacterView.SelectAll();
        }

        private void CharacterView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == CharacterView.Columns["CalculateStatus"].Index)
            {
                CharacterView.InvalidateRow(e.RowIndex);
                DataSave();
            }
        }

        private void CharacterView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (CharacterView.IsCurrentCellDirty)
            {
                CharacterView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DataSave()
        {
            Model.UserData.CharacterCalculator.CharacterObjective.Root data = new();
            foreach(DataGridViewRow row in CharacterView.Rows)
            {
                data.Datas.Add((int)row.Cells["ID"].Value, new()
                {
                    Enabled = (bool)row.Cells["CalculateStatus"].Value,
                    SetLevel = (int)row.Cells["ToLevel"].Value,
                    SetTalent1 = (int)row.Cells["ToTalentLevel1"].Value,
                    SetTalent2 = (int)row.Cells["ToTalentLevel2"].Value,
                    SetTalent3 = (int)row.Cells["ToTalentLevel3"].Value,
                });
            }
            var regPath = $"UserData\\{account.UID}\\Character\\";
            Registry.SetValue(regPath, "Objective", JsonConvert.SerializeObject(data), true);
        }
        private Model.UserData.CharacterCalculator.CharacterObjective.Root DataLoad()
        {
            try
            {
                var regPath = $"UserData\\{account.UID}\\Character\\";
                string? str = Registry.GetValue(regPath, "Objective", true);
                if (str == null) return new();
                var data = JsonConvert.DeserializeObject<Model.UserData.CharacterCalculator.CharacterObjective.Root>(str);
                if(data == null) return new();
                return data;
            }
            catch(Exception ex)
            {
                new ErrorMessage("アカウントセーブデータに異常があります。", ex.ToString());
                return new();
            }

        }
    }
}
