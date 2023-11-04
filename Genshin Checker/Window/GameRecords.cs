using Genshin_Checker.App.HoYoLab;
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

            label2.Text = $"{account.Name} AR.{account.EnkaNetwork.Data.playerInfo.level} | 解放済実績 : {account.EnkaNetwork.Data.playerInfo.finishAchievementNum}件 | 深境螺旋 : 12-3";
            label1.Text = $"UID : {account.UID}";
            if (account.GameRecords.Data != null)
            {
                Summary_UserIcon.ImageLocation = account.GameRecords.Data.role.game_head_icon;
            }
            Summary_UserName.Text = account.EnkaNetwork.Data.playerInfo.nickname;
            Summary_StatusMessage.Text = account.EnkaNetwork.Data.playerInfo.signature;
            Summary_AdventureRank.Text = $"{account.EnkaNetwork.Data.playerInfo.level}";
            Summary_AdventureRankState.Text = $"世界ランク : {account.EnkaNetwork.Data.playerInfo.worldLevel}";
        }
    }
}
