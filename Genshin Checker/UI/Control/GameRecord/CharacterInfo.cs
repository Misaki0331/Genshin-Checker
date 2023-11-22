﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.UI.Control.GameRecord
{
    public partial class CharacterInfo : UserControl
    {
        int Rare = 4;
        string CharacterIcon = "";
        public CharacterInfo(int rarity,string characterIcon,string label,string alphalabel)
        {
            InitializeComponent();
            panel2.Parent = pictureBox1;
            label2.Parent = panel2;
            label1.Text = label;
            label2.Text = alphalabel;
            if (string.IsNullOrEmpty(alphalabel)) label2.Visible = false;
            Rare = rarity;
            CharacterIcon= characterIcon;
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void CharacterInfo_Load(object sender, EventArgs e)
        {
            switch (Rare)
            {
                case 4:
                    pictureBox1.BackgroundImage = new Bitmap(await App.WebRequest.ImageGetRequest("https://static-api.misaki-chan.world/genshin-checker/asset/character-base/roleStarBg4.png"), pictureBox1.Width, pictureBox1.Height);
                    break;
                case 5:
                    pictureBox1.BackgroundImage = new Bitmap(await App.WebRequest.ImageGetRequest("https://static-api.misaki-chan.world/genshin-checker/asset/character-base/roleStarBg5.png"), pictureBox1.Width, pictureBox1.Height);
                    break;
            }
            pictureBox1.Image = new Bitmap(await App.WebRequest.ImageGetRequest(CharacterIcon),pictureBox1.Width,pictureBox1.Height);
        }
    }
}
