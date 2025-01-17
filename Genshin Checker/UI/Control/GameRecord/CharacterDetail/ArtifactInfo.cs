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
    public partial class ArtifactInfo : UserControl
    {
        string IconURL = "";
        int star = 0;
        int position = 0;
        public ArtifactInfo(int position, string? url, int star,string label)
        {
            InitializeComponent();
            pictureBox2.Parent = pictureBox1;
            label1.Text = label;
            if (url == null)
            {
                IconURL = position switch
                {
                    1 or 2 or 3 or 4 or 5 => $"https://static-api.misaki-chan.world/genshin-checker/asset/artifact/none_type{position}.png",
                    _ => $"https://static-api.misaki-chan.world/genshin-checker/asset/unknown.png",
                };
                star = 0;
            }
            else
            {
                this.star= star;
                IconURL = url;
            }
            this.position = position;
        }

        private async void ArtifactInfo_Load(object sender, EventArgs e)
        {
            int star = this.star;
            if (star <= 0 || star > 5)
            {
                star = 1;
            }
            else pictureBox2.Image = await Core.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/star/{star}.png");
            pictureBox1.BackgroundImage = DrawControl.BitmapInterpolation(await Core.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/rarelity-frame/rarity-{star}.png"), pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = DrawControl.BitmapInterpolation(await Core.WebRequest.ImageGetRequest(IconURL), pictureBox1.Width, pictureBox1.Height);
        }
    }
}
