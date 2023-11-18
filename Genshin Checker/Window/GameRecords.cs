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

namespace Genshin_Checker.Window
{
    public partial class GameRecords : Form
    {
        Account account;
        public GameRecords(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void GameRecords_Load(object sender, EventArgs e)
        {
            var str = "-";
            if (account.GameRecords.Data != null) str = account.GameRecords.Data.stats.SpiralAbyss;
                label2.Text = $"{account.Name} AR.{account.EnkaNetwork.Data.playerInfo.level} | 解放済実績 : {account.EnkaNetwork.Data.playerInfo.finishAchievementNum}件 | 深境螺旋 : {(str=="-"?"未踏破":str)}";
            label1.Text = $"UID : {account.UID}";
                Summary_UserIcon.ImageLocation = EnkaData.Convert.AvaterIcon.GetIconURL(account.EnkaNetwork.Data.playerInfo.profilePicture.avatarId);
            Summary_UserName.Text = account.EnkaNetwork.Data.playerInfo.nickname;
            if (string.IsNullOrEmpty(account.EnkaNetwork.Data.playerInfo.signature))
            {
                Summary_StatusMessage.Text = "ステータスメッセージが設定されていません。";
                Summary_StatusMessage.ForeColor = Color.Gray;
            }
            else
            Summary_StatusMessage.Text = account.EnkaNetwork.Data.playerInfo.signature;

            Summary_AdventureRank.Text = $"{account.EnkaNetwork.Data.playerInfo.level}";
            Summary_AdventureRankState.Text = $"世界ランク : {account.EnkaNetwork.Data.playerInfo.worldLevel}";
            if (account.GameRecords.Data != null)
            {
                var data = account.GameRecords.Data.stats;
                NumLoginDays.Text = $"{data.ActiveDay}";
                NumAchievement.Text = $"{data.Achievement}";
                var cnt = data.ChestLuxurious + data.ChestCommon + data.ChestExquisite + data.ChestMagic + data.ChestPrecious;
                NumUnlockChest.Text = $"{cnt}";
                cnt = data.OculusAnemo + data.OculusGeo + data.OculusElectro + data.OculusDendro + data.OculusHydro + data.OculusPyro + data.OculusCryo;
                NumOculus.Text = $"{cnt}";
                NumCharacters.Text = $"{data.Characters}";
                NumWaypoints.Text = $"{data.WayPoint}";
                NumDomains.Text = $"{data.Domains}";
                double per = 0;
                cnt = 0;
                foreach (var item in account.GameRecords.Data.world_explorations)
                {
                        per += item.Exploration_percentage / 10.0;
                        cnt++;
                }
                NumExpanding.Text = $"{(per / cnt):0.00}%";
            }
        }
    }
}
