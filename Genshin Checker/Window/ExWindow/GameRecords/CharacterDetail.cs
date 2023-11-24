using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window.ExWindow.GameRecords
{
    public partial class CharacterDetail : Form
    {
        PictureBox picture;
        public CharacterDetail()
        {
            InitializeComponent();
            picture = new();
            panel1.Resize += pictureBox1_Resize;
            panel1.Controls.Add(picture);
            picture.Location = new(0, 0);
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        Image CharacterBanner;
        public async void DataUpdate(int characterID)
        {
            if (Store.EnkaData.Data.Characters == null) return;
            var character = Store.EnkaData.Data.Characters[$"{characterID}"];
            var gacha = character.SideIconName.Replace("UI_AvatarIcon_Side_", "UI_Gacha_AvatarImg_");
            CharacterBanner = await App.WebRequest.ImageGetRequest($"https://enka.network/ui/{gacha}.png");
            ImageReload(true);
        }

        private void pictureBox1_Resize(object? sender, EventArgs e)
        {
            ImageReload();
        }
        void ImageReload(bool reload = false)
        {
            if (panel1.Height != picture.Height||reload)
            {
                var old = picture.Image;
                double zoom = (double) panel1.Height/ CharacterBanner.Height;
                picture.Image = new Bitmap(CharacterBanner,new((int)(CharacterBanner.Width * zoom), (int)(CharacterBanner.Height * zoom)));
                if(old!=null)old.Dispose();
            }
            picture.Location=new(-picture.Width /2 + panel1.Width / 2,0);
        }
    }
}
