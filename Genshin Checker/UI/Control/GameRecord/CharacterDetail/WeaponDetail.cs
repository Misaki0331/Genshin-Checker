using Genshin_Checker.App.General.UI;
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

namespace Genshin_Checker.UI.Control.GameRecord.CharacterDetail
{
    public partial class WeaponDetail : UserControl
    {
        public WeaponDetail()
        {
            InitializeComponent();
            pictureBox3.Parent = pictureBox2;
        }
        public async void UpdateData(int star,string weaponImageUrl,string Name,int level,int refinement, string description="")
        {
            label1.Text = Name;
            label2.Text = string.Format(Localize.UI_Weapons_Level, level);
            label3.Text = string.Format(Localize.UI_Weapons_RefinementRank,refinement);
            pictureBox2.BackgroundImage = DrawControl.BitmapInterpolation(await App.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/rarelity-frame/rarity-{star}.png"),pictureBox2.Width,pictureBox2.Height);
            pictureBox2.Image = DrawControl.BitmapInterpolation(await App.WebRequest.ImageGetRequest(weaponImageUrl),pictureBox2.Width,pictureBox2.Height);
            pictureBox3.Image = await App.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/star/{star}.png");
        }
    }
}
