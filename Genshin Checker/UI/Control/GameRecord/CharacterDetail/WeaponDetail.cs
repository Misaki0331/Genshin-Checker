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
            label2.Text = $"Lv.{level}";
            label3.Text = $"精錬ランク : {refinement}";
            pictureBox2.BackgroundImage = new Bitmap(await App.WebRequest.ImageGetRequest($"https://static-api.misaki-chan.world/genshin-checker/asset/weapon-base/rarity-{star}.png"),pictureBox2.Width,pictureBox2.Height);
            pictureBox2.Image = await App.WebRequest.ImageGetRequest(weaponImageUrl);
        }
    }
}
