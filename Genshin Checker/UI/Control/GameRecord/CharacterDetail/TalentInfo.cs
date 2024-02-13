using Genshin_Checker.App.General.UI;
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
    public partial class TalentInfo : UserControl
    {
        string iconlink = "";
        public TalentInfo(string talentIcon,string talentName, string talentLevel,string talentDescription)
        {
            InitializeComponent();
            label1.Text = talentName;
            label2.Text = talentLevel; 
            //label3.Text=talentDescription;
            iconlink = talentIcon;
        }

        private async void TalentInfo_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = DrawControl.BitmapInterpolation(await App.WebRequest.ImageGetRequest(iconlink), pictureBox1.Width, pictureBox1.Height);
        }
    }
}
