using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Genshin_Checker.Model.UI.GameRecords.Exploration;
using System.Runtime.InteropServices;
using Genshin_Checker.UI.Control.GameRecord;

namespace Genshin_Checker.Window
{
    public partial class GameRecords : Form
    {
        Account account;
        public GameRecords(Account account)
        {
            InitializeComponent();
            Icon = Icon.FromHandle(resource.icon.Battle_Chronicle.GetHicon());
            if (account.UID != 0) Text = $"戦績情報 (UID:{account.UID})";
            else Text = $"戦績情報";
            this.account = account;
        }
        List<Window.Contains.Exploration> ExplorationControls = new();
        List<UI.Control.GameRecord.CharacterInfo> characterInfos= new();
        private void GameRecords_Load(object sender, EventArgs e)
        {
            try
            {
                #region ヘッダー部分
                var str = "-";
                if (account.GameRecords.Data != null) str = account.GameRecords.Data.stats.SpiralAbyss;
                label2.Text = $"{account.Name} AR.{account.EnkaNetwork.Data.playerInfo.level} | 解放済実績 : {account.EnkaNetwork.Data.playerInfo.finishAchievementNum}件 | 深境螺旋 : {(str == "-" ? "未踏破" : str)}";
                label1.Text = $"UID : {account.UID}";
                #endregion
                #region 概要
                Summary_UserIcon.ImageLocation = EnkaData.Convert.AvaterIcon.GetIconURL(account.EnkaNetwork.Data.playerInfo.profilePicture.avatarId);
                Summary_UserName.Text = account.EnkaNetwork.Data.playerInfo.nickname;
                if (string.IsNullOrEmpty(account.EnkaNetwork.Data.playerInfo.signature))
                {
                    Summary_StatusMessage.Text = "ステータスメッセージが設定されていません。";
                    Summary_StatusMessage.ForeColor = Color.Gray;
                }
                else Summary_StatusMessage.Text = account.EnkaNetwork.Data.playerInfo.signature;
                Summary_AdventureRank.Text = $"{account.EnkaNetwork.Data.playerInfo.level}";
                Summary_AdventureRankState.Text = $"世界ランク : {account.EnkaNetwork.Data.playerInfo.worldLevel}";
                if (account.GameRecords.Data != null)
                {
                    var data = account.GameRecords.Data.stats;
                    Summary_NumLoginDays.Text = $"{data.ActiveDay}";
                    Summary_NumAchievement.Text = $"{data.Achievement}";
                    var cnt = data.ChestLuxurious + data.ChestCommon + data.ChestExquisite + data.ChestMagic + data.ChestPrecious;
                    Summary_NumUnlockChest.Text = $"{cnt}";
                    cnt = data.OculusAnemo + data.OculusGeo + data.OculusElectro + data.OculusDendro + data.OculusHydro + data.OculusPyro + data.OculusCryo;
                    Summary_NumOculus.Text = $"{cnt}";
                    Summary_NumCharacters.Text = $"{data.Characters}";
                    NumWaypoints.Text = $"{data.WayPoint}";
                    Summary_NumDomains.Text = $"{data.Domains}";
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
                            areas.Levels.Add(new() { Icon = "https://static-api.misaki-chan.world/genshin-checker/asset/game-records/ys_world_level.png", Name = "評判レベル", Level = (int)ex.Level });
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
                    var OculusName = new string[] { "風神の瞳", "岩神の瞳", "雷神の瞳", "草神の瞳", "水神の瞳", "炎神の瞳", "氷神の瞳" };
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
                new ErrorMessage("データ読込中にエラーが発生しました。", $"{ex}").ShowDialog();
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
