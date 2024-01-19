using Genshin_Checker.App;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Model.HoYoLab.CharacterDetail;
using Genshin_Checker.Window.ExWindow.CharacterCalculator;
using Newtonsoft.Json;
using System.Text;
using Genshin_Checker.App.General.Convert;
using Genshin_Checker.Window.Popup;
using System.Security.Policy;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.App.General;

namespace Genshin_Checker.Window
{
    public partial class CharacterCalculator : Form
    {
        Account account;
        public CharacterCalculator(Account account)
        {
            InitializeComponent();
            Icon = Icon.FromHandle(resource.icon.calculator_new.GetHicon());
            this.account = account;
        }
        private async void CharacterCalculator_Load(object sender, EventArgs e)
        {
            if (!await account.CharacterDetail.IsReadyCacheData())
            {
                if (!account.CharacterDetail.IsAvailableUpdate)
                {
                    new ErrorMessage(Localize.Error_CharacterCalculator_WaitForTalentInfomation, Localize.Error_CharacterCalculator_WaitForTalentInfomation_Message).ShowDialog();
                    Close();
                    return;
                }else
                {

                    var dialog = new ChooseMessage(Localize.WindowName_CharacterCalculator_NewCharacterFound, Localize.WindowName_CharacterCalculator_Confirm_UpdateTalentsInfomation, Common.Confirm, 2,Common.Yes,Common.Latter);
                    dialog.ShowDialog();
                    if (dialog.Result == 0)
                    {
                        if (account.CharacterDetail.IsAvailableUpdate)
                        {
                            Close();
                            var a=await account.CharacterDetail.UpdateGameData(false);
                            if (!a)
                            {
                                new ErrorMessage(Localize.Error_CharacterCalculator_FailedToLoadTalentsInfomation, string.Format(Localize.Error_CharacterCalculator_FailedToLoadTalentInfomation, account.CharacterDetail.LatestException)).ShowDialog();
                            }
                        }
                        else
                        {
                            new ErrorMessage(Localize.Error_CharacterCalculator_FailedToLoadTalentsInfomation, Localize.Error_CharacterCalculator_WorkingOtherThread).ShowDialog();
                            Close();
                        }
                    }
                    Close();
                }
            }
            var Data= await account.Characters.GetData();
            var characters = Data.avatars.FindAll(a=>true);
            var userdata = DataLoad();
            for(int i=0; i<characters.Count; i++)
            {
                var character = characters[i];
                var charainfo = await account.CharacterDetail.GetData(character.id);
                var talent = charainfo.skill_list.FindAll(a=>a.max_level!=1);
                var set = userdata.Datas.FirstOrDefault(a=>a.Key==character.id);
                var setdata = set.Value ?? new();
                if (talent.Count!=3)throw new InvalidDataException(Localize.Error_CharacterCalculator_InvalidTalentCount);
                CharacterView.Rows.Add(setdata.Enabled, character.id, character.rarity, Element.GetElementEnum(character.element), character.name, character.weapon.type_name, character.fetter, character.level,
                    talent[0].level_current, talent[1].level_current, talent[2].level_current, "",
                    character.level > setdata.SetLevel ? character.level : setdata.SetLevel,
                    talent[0].level_current > setdata.SetTalent1 ? talent[0].level_current : setdata.SetTalent1,
                    talent[1].level_current > setdata.SetTalent2 ? talent[1].level_current : setdata.SetTalent2,
                    talent[2].level_current > setdata.SetTalent3 ? talent[2].level_current : setdata.SetTalent3);
            }
            Text = $"{Localize.WindowName_CharacterCalculator} (UID:{account.UID})";
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
                string ErrorTitle = string.Format(Localize.Error_CharacterCalculator_MultipleError, $"{ExceptionCount:#,##0}");
                Exceptions.Reverse();
                foreach (var ex in Exceptions)
                {
                    ErrorDetail.Append($"{ex}\n--------------------\n");
                }
                if (ExceptionCount > 100) ErrorDetail.Append(string.Format(Common.Error_WithCount,$"{ExceptionCount - Exceptions.Count:#,##0}"));
                ExceptionCount = 0;
                Exceptions.Clear();
                new ErrorMessage(ErrorTitle, ErrorDetail.ToString()).ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CalculateResult.Input> inputs = new();
            foreach(DataGridViewRow row in CharacterView.Rows)
            {
                if (!(bool)row.Cells[nameof(CalculateStatus)].Value) continue;
                if ((int)row.Cells[nameof(CurrentLevel)].Value == (int)row.Cells[nameof(ToLevel)].Value &&
                    (int)row.Cells[nameof(CurrentTalentLevel1)].Value == (int)row.Cells[nameof(ToTalentLevel1)].Value &&
                    (int)row.Cells[nameof(CurrentTalentLevel2)].Value == (int)row.Cells[nameof(ToTalentLevel2)].Value &&
                    (int)row.Cells[nameof(CurrentTalentLevel3)].Value == (int)row.Cells[nameof(ToTalentLevel3)].Value) continue;
                inputs.Add(new() { 
                    characterID = (int)row.Cells[nameof(ID)].Value,
                    Level = new((int)row.Cells[nameof(CurrentLevel)].Value, (int)row.Cells[nameof(ToLevel)].Value),
                    Talent = new(){
                        new((int)row.Cells[nameof(CurrentTalentLevel1)].Value, (int)row.Cells[nameof(ToTalentLevel1)].Value),
                        new((int)row.Cells[nameof(CurrentTalentLevel2)].Value, (int)row.Cells[nameof(ToTalentLevel2)].Value),
                        new((int)row.Cells[nameof(CurrentTalentLevel3)].Value, (int)row.Cells[nameof(ToTalentLevel3)].Value),
                    }
                });
            }

            new CalculateResult(account, inputs).ShowDialog();
        }

        private void CharacterView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void CharacterView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (CharacterView.Columns[e.ColumnIndex].Name)
            {
                case nameof(ElementType):
                    if (e.Value == null) return;
                    e.Value = Element.GetLocalizeName(Element.GetElementEnum(e.Value.ToString()));
                    e.CellStyle.BackColor = Element.GetBackgroundColor(Element.GetElementEnum((string?)CharacterView[e.ColumnIndex,e.RowIndex].Value.ToString()));
                    break;
                case nameof(CharacterName):
                    var element = Element.GetElementEnum((string?)CharacterView[CharacterView.Columns[nameof(CharacterName)].Index-1,e.RowIndex].Value.ToString());
                    e.CellStyle.BackColor = Element.GetBackgroundColor(element);
                    break;
                case nameof(Rarelity):
                    if($"{e.Value}"=="5") e.CellStyle.BackColor = Color.FromArgb(0xFF,0xEE,0xAA);
                    else if ($"{e.Value}" == "4") e.CellStyle.BackColor = Color.FromArgb(0xCC, 0xAA, 0xFF);
                    break;
                case nameof(ToArrow):
                case nameof(ToLevel):
                case nameof(ToTalentLevel1):
                case nameof(ToTalentLevel2):
                case nameof(ToTalentLevel3):
                    if ((bool)CharacterView[CharacterView.Columns[nameof(CalculateStatus)].Index, e.RowIndex].Value)
                    {
                        switch (CharacterView.Columns[e.ColumnIndex].Name)
                        {
                            case nameof(ToArrow):
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
                    CharacterName = (string)select[0].Cells[nameof(CharacterName)].Value,
                    Talent1Name = skills[0].name,
                    Talent2Name = skills[1].name,
                    Talent3Name = skills[2].name,
                    MinLevel = (int)select[0].Cells[nameof(CurrentLevel)].Value,
                    MinTalent1 = (int)select[0].Cells[nameof(CurrentTalentLevel1)].Value,
                    MinTalent2 = (int)select[0].Cells[nameof(CurrentTalentLevel2)].Value,
                    MinTalent3 = (int)select[0].Cells[nameof(CurrentTalentLevel3)].Value,
                    CurrentLevel = (int)select[0].Cells[nameof(ToLevel)].Value,
                    CurrentTalent1 = (int)select[0].Cells[nameof(ToTalentLevel1)].Value,
                    CurrentTalent2 = (int)select[0].Cells[nameof(ToTalentLevel2)].Value,
                    CurrentTalent3 = (int)select[0].Cells[nameof(ToTalentLevel3)].Value,
                    StatusEnabled = (bool)select[0].Cells[nameof(CalculateStatus)].Value,
                });
                form.ShowDialog();
                var change = form.Output;
                if (change.IsApplied)
                {
                    select[0].Cells[nameof(ToLevel)].Value = change.Level;
                    select[0].Cells[nameof(ToTalentLevel1)].Value = change.Talent1;
                    select[0].Cells[nameof(ToTalentLevel2)].Value = change.Talent2;
                    select[0].Cells[nameof(ToTalentLevel3)].Value = change.Talent3;
                    if (change.StatusEnabled != null) 
                        select[0].Cells[nameof(CalculateStatus)].Value = change.StatusEnabled;
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
                        if (change.Level >= (int)row.Cells[nameof(CurrentLevel)].Value)
                            row.Cells[nameof(ToLevel)].Value = change.Level;
                        else row.Cells[nameof(ToLevel)].Value = (int)row.Cells[nameof(CurrentLevel)].Value;
                        if (change.Talent1 >= (int)row.Cells[nameof(CurrentTalentLevel1)].Value)
                            row.Cells[nameof(ToTalentLevel1)].Value = change.Talent1;
                        else row.Cells[nameof(ToTalentLevel1)].Value = (int)row.Cells[nameof(CurrentTalentLevel1)].Value;
                        if (change.Talent2 >= (int)row.Cells[nameof(CurrentTalentLevel2)].Value)
                            row.Cells[nameof(ToTalentLevel2)].Value = change.Talent2;
                        else row.Cells[nameof(ToTalentLevel2)].Value = (int)row.Cells[nameof(CurrentTalentLevel2)].Value;
                        if (change.Talent3 >= (int)row.Cells[nameof(CurrentTalentLevel3)].Value)
                            row.Cells[nameof(ToTalentLevel3)].Value = change.Talent3;
                        else row.Cells[nameof(ToTalentLevel3)].Value = (int)row.Cells[nameof(CurrentTalentLevel3)].Value;
                        if (change.StatusEnabled != null) 
                            row.Cells[nameof(CalculateStatus)].Value = change.StatusEnabled;
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
            if(e.ColumnIndex == CharacterView.Columns[nameof(CalculateStatus)].Index)
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
                data.Datas.Add((int)row.Cells[nameof(ID)].Value, new()
                {
                    Enabled = (bool)row.Cells[nameof(CalculateStatus)].Value,
                    SetLevel = (int)row.Cells[nameof(ToLevel)].Value,
                    SetTalent1 = (int)row.Cells[nameof(ToTalentLevel1)].Value,
                    SetTalent2 = (int)row.Cells[nameof(ToTalentLevel2)].Value,
                    SetTalent3 = (int)row.Cells[nameof(ToTalentLevel3)].Value,
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
                var data = JsonChecker<Model.UserData.CharacterCalculator.CharacterObjective.Root>.Check(str);
                if(data == null) return new();
                return data;
            }
            catch(Exception ex)
            {
                new ErrorMessage(Localize.Error_CharacterCalculator_InvalidSaveData, ex.ToString()).ShowDialog();
                return new();
            }

        }

        private void CharacterView_SelectionChanged(object sender, EventArgs e)
        {
            switch (CharacterView.SelectedRows.Count)
            {
                case 0:
                    ButtonBatch.Enabled = false;
                    ButtonBatch.Text = Localize.WindowName_CharacterCalculator_Button_Edit;
                    break;
                case 1:
                    ButtonBatch.Enabled = true;
                    ButtonBatch.Text = Localize.WindowName_CharacterCalculator_Button_Edit;
                    break;
                default:
                    ButtonBatch.Enabled = true;
                    ButtonBatch.Text = Localize.WindowName_CharacterCalculator_Button_AllEdit;
                    break;
            }
        }

        private void CharacterView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ButtonBatch_Click(CharacterView, EventArgs.Empty);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var dialog = new ChooseMessage(Localize.WindowName_CharacterCalculator_UpdateTalentsInfomation_Title, Localize.WindowName_CharacterCalculator_UpdateTalentsInfomation_Description, Common.Confirm);
            dialog.ShowDialog();
            if (dialog.Result == 1)
            {
                if (account.CharacterDetail.IsAvailableUpdate)
                {
                    Close();
                    await account.CharacterDetail.UpdateGameData(true);
                }
                else
                {
                    new ErrorMessage(Localize.Error_CharacterCalculator_FailedToLoadTalentsInfomation, Localize.Error_CharacterCalculator_WorkingOtherThread).ShowDialog();
                }
            }
        }
    }
}
