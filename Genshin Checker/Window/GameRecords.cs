using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Store;
using Genshin_Checker.Model.UI.GameRecords.Exploration;
using Genshin_Checker.Window.Popup;
using Genshin_Checker.resource.Languages;

namespace Genshin_Checker.Window
{
    public partial class GameRecords : Form
    {
        Account account;
        public GameRecords(Account account)
        {
            InitializeComponent();
            Icon = Icon.FromHandle(resource.icon.Battle_Chronicle.GetHicon());
            if (account.UID != 0) Text = $"{Localize.WindowName_GameRecord} (UID:{account.UID})";
            else Text = Localize.WindowName_GameRecord;
            this.account = account;
        }
        List<Window.Contains.Exploration> ExplorationControls = new();
        List<UI.Control.GameRecord.CharacterInfo> characterInfos= new();
        private async void GameRecords_Load(object sender, EventArgs e)
        {
            try
            {
                #region ヘッダー部分
                var spiralAbyssProgress = "-";
                if (account.GameRecords.Data != null) spiralAbyssProgress = account.GameRecords.Data.stats.SpiralAbyss;
                int ar = account.Level;
                int? achieve = null;
                if (!account.EnkaNetwork.HasError)
                {
                    ar = account.EnkaNetwork.Data.playerInfo.level;
                    achieve = account.EnkaNetwork.Data.playerInfo.finishAchievementNum;
                }
                else if (account.GameRecords.Data != null)
                    achieve = account.GameRecords.Data.stats.Achievement;
                label2.Text = string.Format(Localize.WindowName_GameRecord_HeaderText,account.Name,ar,(achieve!=null?achieve:"-"),(spiralAbyssProgress == "-" ? Localize.WindowName_GameRecord_HeaderText_NoSpiralAbyss : spiralAbyssProgress));
                label1.Text = $"UID : {account.UID}";
                #endregion
                #region 概要
                if (account.EnkaNetwork.HasError)
                {
                    Summary_UserName.Text = account.Name;
                    if (account.GameRecords.Data != null) {
                        Summary_AdventureRank.Text = $"{account.GameRecords.Data.role.Level}";
                        Summary_UserIcon.Image = await App.WebRequest.ImageGetRequest(account.GameRecords.Data.role.game_head_icon);
                    }
                    else
                    {
                        Summary_AdventureRank.Text = $"{account.Level}";
                    }
                    Summary_StatusMessage.Text = account.EnkaNetwork.LatestErrorMessage;
                    Summary_StatusMessage.ForeColor = Color.Red;
                    Summary_AdventureRankState.Text = string.Format(Localize.WindowName_GameRecord_WorldRankText, Common.Unknown);
                }
                else
                {
                    Summary_UserIcon.Image = await App.WebRequest.ImageGetRequest(EnkaData.Convert.AvaterIcon.GetIconURL(account.EnkaNetwork.Data.playerInfo.profilePicture.avatarId));
                    Summary_UserName.Text = account.EnkaNetwork.Data.playerInfo.nickname;
                    if (string.IsNullOrEmpty(account.EnkaNetwork.Data.playerInfo.signature))
                    {
                        Summary_StatusMessage.Text = Genshin.Account_NoStatusMessage;
                        Summary_StatusMessage.ForeColor = Color.Gray;
                    }
                    else Summary_StatusMessage.Text = account.EnkaNetwork.Data.playerInfo.signature;
                    Summary_AdventureRank.Text = $"{account.EnkaNetwork.Data.playerInfo.level}";
                    Summary_AdventureRankState.Text = string.Format(Localize.WindowName_GameRecord_WorldRankText, account.EnkaNetwork.Data.playerInfo.worldLevel);
                }
                
                if (account.GameRecords.Data != null)
                {
                    var data = account.GameRecords.Data.stats;
                    Summary_NumLoginDays.Text = $"{data.ActiveDay:#,##0}";
                    Summary_NumAchievement.Text = $"{data.Achievement:#,##0}";
                    var cnt = data.ChestLuxurious + data.ChestCommon + data.ChestExquisite + data.ChestMagic + data.ChestPrecious;
                    Summary_NumUnlockChest.Text = $"{cnt:#,##0}";
                    cnt = data.OculusAnemo + data.OculusGeo + data.OculusElectro + data.OculusDendro + data.OculusHydro + data.OculusPyro + data.OculusCryo;
                    Summary_NumOculus.Text = $"{cnt:#,##0}";
                    Summary_NumCharacters.Text = $"{data.Characters:#,##0}";
                    NumWaypoints.Text = $"{data.WayPoint:#,##0}";
                    Summary_NumDomains.Text = $"{data.Domains:#,##0}";
                    double per = 0;
                    cnt = 0;
                    foreach (var item in account.GameRecords.Data.world_explorations)
                    {
                        per += item.Exploration_percentage / 10.0;
                        cnt++;
                    }
                    Summary_NumExpanding.Text = $"{(per / cnt):0.00}%";
                }
                #endregion
                #region 探索
                if (account.GameRecords.Data != null)
                {
                    var data = account.GameRecords.Data;
                    List<Root> Area = new();
                    foreach (var ex in data.world_explorations.FindAll(a => a.Parent_id == 0))
                    {
                        Root areas = new();
                        areas.ID = ex.Id;
                        areas.Name = ex.Name;
                        areas.Images.Icon = ex.Icon;
                        if (ex.Type == "Reputation" && ex.Level != null)
                        {
                            areas.Oculus = new();
                            areas.Levels.Add(new() { Icon = "https://static-api.misaki-chan.world/genshin-checker/asset/game-records/ys_world_level.png", Name = Genshin.City_ReputationLevel, Level = (int)ex.Level });
                        }
                        foreach (var level in ex.Offerings)
                        {
                            areas.Levels.Add(new() { Icon = level.icon, Name = level.name, Level = level.level });
                        }
                        areas.Progress.Add(new() { Value = ex.Exploration_percentage / 10.0 });
                        Area.Add(areas);
                    }
                    foreach (var ex in data.world_explorations.FindAll(a => a.Parent_id != 0))
                    {
                        Root? areas = Area.Find(a => a.ID == ex.Parent_id);
                        if (areas == null) continue;
                        if (areas.Progress.Count == 1) areas.Progress[0].Name = areas.Name;
                        areas.Progress.Add(new() { Name = ex.Name, Value = ex.Exploration_percentage / 10.0 });
                    }
                    var OculusName = new string[] { Genshin.Oculus_Anemo, Genshin.Oculus_Geo, Genshin.Oculus_Electro, Genshin.Oculus_Dendro, Genshin.Oculus_Hydro, Genshin.Oculus_Pyro, Genshin.Oculus_Cryo };
                    var OculusValue = new int[] { data.stats.OculusAnemo, data.stats.OculusGeo, data.stats.OculusElectro, data.stats.OculusDendro, data.stats.OculusHydro, data.stats.OculusPyro, data.stats.OculusCryo };
                    int OculusAreaCount = 0;
                    Area.Sort((a, b) => b.ID - a.ID);
                    for (int i = Area.Count - 1; i >= 0; i--)
                    {
                        var ex = Area[i];
                        if (ex.Oculus != null && OculusAreaCount < OculusName.Length)
                        {
                            ex.Oculus.Name = OculusName[OculusAreaCount];
                            ex.Oculus.Count = OculusValue[OculusAreaCount];
                            OculusAreaCount++;
                        }
                        var control = new Window.Contains.Exploration(ex);
                        control.Dock = DockStyle.Top;
                        control.BorderStyle = BorderStyle.FixedSingle;
                        tabPage2.Controls.Add(control);
                        ExplorationControls.Add(control);
                    }
                }
                #endregion
                #region キャラクター
                if (account.GameRecords.Data != null)
                {
                    var data = account.GameRecords.Data;
                    foreach (var character in data.avatars)
                    {
                        var control = new UI.Control.GameRecord.CharacterInfo(character.rarity, character.image, $"Lv.{character.level}", character.actived_constellation_num == 0 ? "": $"{character.actived_constellation_num}",character.id);
                        control.Margin=new(2,2,2,2);
                        control.ClickHandler += GameRecords_Character_Click;
                        CharactersCollection.Controls.Add(control);
                        characterInfos.Add(control);
                    }
                }
                #endregion

                }
            catch (Exception ex)
            {
                new ErrorMessage(Localize.Error_GameRecord_FailedToLoad, $"{ex}").ShowDialog();
                Close();
            }
        }
        ExWindow.GameRecords.CharacterDetail? CharacterForm=null;
        private void GameRecords_Character_Click(int id)
        {
            if (CharacterForm == null || CharacterForm.IsDisposed)
            {
                CharacterForm = new();
            }
            var Data = account.GameRecords.Data;
            if (Data == null) return;
            var character = Data.avatars.Find(a => a.id == id);
            if(character == null) return;
            CharacterForm.DataUpdate(account,id, character.name);
            CharacterForm.Show();
            CharacterForm.Activate();
            if(WindowState!=FormWindowState.Maximized) Activate();
            
        }
        private void GameRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach(var ex in ExplorationControls)
            {
                ex.Release();
            }
            CharactersCollection.SuspendLayout();
            foreach (var ex in characterInfos)
            {
                ex.Dispose();
            }
            CharactersCollection.ResumeLayout(true);
            if (CharacterForm != null && !CharacterForm.IsDisposed) CharacterForm.Close();
        }
        protected override void OnResize(EventArgs e)
        {
        }

        private void GameRecords_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
            this.PerformLayout();
        }

        private void GameRecords_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState==FormWindowState.Maximized)
            {
                this.Invalidate();
                this.PerformLayout();
            }
        }
    }
}
