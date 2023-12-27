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
    public partial class SpiralAbyss : Form
    {
        Account account;
        public SpiralAbyss(Account account)
        {
            InitializeComponent();
            this.account = account;
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
        }
    }
}
