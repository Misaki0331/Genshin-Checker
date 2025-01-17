using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genshin_Checker.Core.General.UI;

namespace Genshin_Checker.UI.Control.GameRecord
{
    public partial class CharacterInfo : UserControl
    {
        int Rare = 4;
        string CharacterIcon = "";
        public readonly int characterID;

        public delegate void CharacterEventHandler<T>(T args);
        public event CharacterEventHandler<int>? ClickHandler;
        public CharacterInfo(int rarity,string characterIcon,string label,string alphalabel,int id)
        {
            InitializeComponent();
            panel2.Parent = pictureBox1;
            label2.Parent = panel2;
            label1.Text = label;
            label2.Text = alphalabel;
            if (string.IsNullOrEmpty(alphalabel)) label2.Visible = false;
            Rare = rarity;
            CharacterIcon= characterIcon;
            characterID = id;

            pictureBox1.Click += ClickEvent;
            label1.Click += ClickEvent;
            label2.Click+= ClickEvent;
            panel2.Click += ClickEvent;
            Disposed += CharacterInfo_Disposed;
        }

        private void CharacterInfo_Disposed(object? sender, EventArgs e)
        {
            pictureBox1.Dispose();
        }

        private void ClickEvent(object? obj, object send)
        {
            ClickHandler?.Invoke(characterID);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void CharacterInfo_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            switch (Rare)
            {
                case -1:
                    pictureBox1.BackgroundImage = DrawControl.BitmapInterpolation(await Core.WebRequest.ImageGetRequest("https://static-api.misaki-chan.world/genshin-checker/asset/enemy-base/base.png"), pictureBox1.Width, pictureBox1.Height);
                    break;
                case 4:
                    pictureBox1.BackgroundImage = DrawControl.BitmapInterpolation(await Core.WebRequest.ImageGetRequest("https://static-api.misaki-chan.world/genshin-checker/asset/character-base/roleStarBg4.png"), pictureBox1.Width, pictureBox1.Height);
                    break;
                case 5:
                    pictureBox1.BackgroundImage = DrawControl.BitmapInterpolation(await Core.WebRequest.ImageGetRequest("https://static-api.misaki-chan.world/genshin-checker/asset/character-base/roleStarBg5.png"), pictureBox1.Width, pictureBox1.Height);
                    break;
            }
            pictureBox1.Image = DrawControl.BitmapInterpolation(await Core.WebRequest.ImageGetRequest(CharacterIcon), pictureBox1.Width, pictureBox1.Height);
            this.ResumeLayout(false);
        }
    }
}
