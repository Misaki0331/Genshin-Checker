using Genshin_Checker.App.General.Music;
using Genshin_Checker.Window.Popup;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window
{
    public partial class MusicPlayer : Form
    {
        public MusicPlayer()
        {
            InitializeComponent();
            volumebar.Value = (int)(Player.Instance.Volume*100.0);
            volumelabel.Text = $"Vol.\n{volumebar.Value}";
            update.Start();
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            if (Player.Instance.IsPlaying) Player.Instance.Pause();
            else Player.Instance.Play();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Player.Instance.Stop();
        }

        private void update_Tick(object sender, EventArgs e)
        {
            var total = Player.Instance.TotalTile;
            if (total == null)
            {
                SongTitle.Text = "";
                progressBar1.Value = 0;
                label1.Text = $"-:--.-- / -:--.--";
            }
            else
            {
                var current = Player.Instance.CurrentTime;
                int per = (int)((double)current.TotalMilliseconds / (double)total.Value.TotalMilliseconds * 10000.0);
                if (per > 10000) per = 10000;
                progressBar1.Value = per;
                label1.Text = $"{current:m\\:ss\\:ff} / {total:m\\:ss\\:ff}";
                SongTitle.Text = Player.Instance.CurrentTitle;
            }

            if (Player.Instance.IsPlaying)
            {
                ButtonPlay.Text = "❘❘";
            }
            else
            {
                ButtonPlay.Text = "▶";
            }
        }

        private void MusicPlayer_Load(object sender, EventArgs e)
        {
        }

        private void volumebar_Scroll(object sender, EventArgs e)
        {
            Player.Instance.Volume= volumebar.Value/100.0f;
            volumelabel.Text = $"Vol.\n{volumebar.Value}";
        }
    }
}
