using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    public partial class FloorInfo : UserControl
    {
        int index = 0;
        public FloorInfo(int index,string starinfo, bool isLocked,string infomation,DateTime? LatestUpdate)
        {
            InitializeComponent();
            this.index = index;
            LabelArea.Text = $"第 {index} 層";
            LabelStars.Text = starinfo;
            if (isLocked)
            {
                LabelStars.Text = "未開放";
                pictureBox1.Visible = false;
            }
            if(LatestUpdate!= null)
            {
                LabelLatestUpdate.Text = $"最終更新 : {LatestUpdate:yyyy/MM/dd HH:mm:ss}";
            }
            else
            {
                LabelLatestUpdate.Text = "";
            }
            LabelInfomation.Text = infomation;
        }

        private void LabelPaint(object sender, PaintEventArgs e)
        {
            if (sender is Label label)
            {
                App.General.UI.DrawControl.DrawBackground(e.Graphics, BackgroundImage, this, label);
                App.General.UI.DrawControl.DrawOutlineString(e.Graphics, label, Color.White, Color.Black, label.Font.Size < 18 ? 2 : 3);
            }
        }

        private async void FloorInfo_Load(object sender, EventArgs e)
        {
            BackgroundImage = new Bitmap(await App.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/background/spiral-abyss/floor{index}.png"),Width,Height);
        }
    }
}
