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
    public partial class EnemyInfo : UserControl
    {
        string iconurl;
        public EnemyInfo(string icon, string name, string level)
        {
            InitializeComponent();
            LabelName.Text = name;
            LabelLevel.Text = level;
            iconurl = icon;
        }

        private async void EnemyInfo_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(await App.WebRequest.ImageGetRequest(iconurl),pictureBox1.Width,pictureBox1.Height);
        }
    }
}
