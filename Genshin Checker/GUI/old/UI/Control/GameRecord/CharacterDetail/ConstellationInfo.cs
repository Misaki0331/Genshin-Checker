using Genshin_Checker.Core.General.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.UI.Control.GameRecord.CharacterDetail
{
    public partial class ConstellationInfo : UserControl
    {
        string iconurl;
        public ConstellationInfo(string name,string iconUrl, bool IsActivated)
        {
            InitializeComponent();
            LockUI.Parent = pictureBox1;
            label1.Text = name;
            if(!IsActivated)label1.ForeColor = Color.DarkGray;
            else label1.ForeColor = Color.Black;
            iconurl= iconUrl;
            LockUI.Visible= !IsActivated;
        }


        private async void ConstellationInfo_Load(object sender, EventArgs e)
        {
            pictureBox1.Image= DrawControl.BitmapInterpolation(await Core.WebRequest.ImageGetRequest(iconurl),pictureBox1.Width,pictureBox1.Height);
        }
    }
}
