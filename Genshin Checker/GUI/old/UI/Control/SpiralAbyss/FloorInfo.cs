using Genshin_Checker.resource.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Genshin_Checker.UI.Control.GameRecord.CharacterInfo;

namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    public partial class FloorInfo : UserControl
    {
        int index = 0;

        public event CharacterEventHandler<int>? ClickHandler;
        public FloorInfo(int index,string starinfo, bool isLocked,string infomation,DateTime? LatestUpdate)
        {
            InitializeComponent();
            this.index = index;
            LabelArea.Text = string.Format(Localize.UIName_SpiralAbyss_Floor, index);
            LabelStars.Text = starinfo;
            if (isLocked)
            {
                LabelStars.Text = Localize.UIName_SpiralAbyss_Locked;
                pictureBox1.Visible = false;
            }
            if(LatestUpdate!= null)
            {
                LabelLatestUpdate.Text = string.Format(Localize.UIName_SpiralAbyss_LatestUpdate, $"{LatestUpdate:yyyy/MM/dd HH:mm:ss}");
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
                Core.General.UI.DrawControl.DrawBackground(e.Graphics, BackgroundImage, this, label);
                Core.General.UI.DrawControl.DrawOutlineString(e.Graphics, label, Color.White, Color.Black, label.Font.Size < 18 ? 2 : 3);
            }
        }

        private async void FloorInfo_Load(object sender, EventArgs e)
        {
            BackgroundImage = new Bitmap(await Core.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/background/spiral-abyss/floor{index}.png"),Width,Height);
        }

        private void ClickEvent(object sender, EventArgs e)
        {
            ClickHandler?.Invoke(index);
        }
    }
}
