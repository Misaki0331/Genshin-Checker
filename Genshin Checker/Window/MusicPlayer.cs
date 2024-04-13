using Genshin_Checker.App.General.Music;
using Genshin_Checker.Window.Popup;
using NAudio.Wave;
using OpenTK.Input;
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
            Player.Instance.QueueListChanged += OnQueueListChanged;
            volumebar.Value = (int)(Player.Instance.Volume * 100.0);
            volumelabel.Text = $"Vol.\n{volumebar.Value}";
            update.Start();
            ButtonStop.Image = App.General.UI.DrawControl.BitmapInterpolation(resource.fluentui_emoji.stop_button, ButtonStop.Width, ButtonStop.Height);
            ButtonNext.Image = App.General.UI.DrawControl.BitmapInterpolation(resource.fluentui_emoji.next_track_button, ButtonNext.Width, ButtonNext.Height);
            SetCurrentLoopButton();
            Icon = resource.icon.nahida;
        }
        private void OnQueueListChanged(object? sender, EventArgs e)
        {
            this.Invoke(() =>
            {
                var data = Player.Instance.GetQueue();
                dataGridView1.Rows.Clear();
                int i = 1;
                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(i, item.Title, "-:--.--");
                    i++;
                }
            });
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
                if (ButtonPlay.Name != "Pause")
                {
                    ButtonPlay.Name = "Pause";
                    ButtonPlay.Image = App.General.UI.DrawControl.BitmapInterpolation(resource.fluentui_emoji.pause_button, ButtonPlay.Width, ButtonPlay.Height);
                }
            }
            else
            {
                if (ButtonPlay.Name != "Play")
                {
                    ButtonPlay.Name = "Play";
                    ButtonPlay.Image = App.General.UI.DrawControl.BitmapInterpolation(resource.fluentui_emoji.play_button, ButtonPlay.Width, ButtonPlay.Height);
                }
            }
        }

        private void MusicPlayer_Load(object sender, EventArgs e)
        {
            OnQueueListChanged(null, EventArgs.Empty);
        }

        private void volumebar_Scroll(object sender, EventArgs e)
        {
            Player.Instance.Volume = volumebar.Value / 100.0f;
            volumelabel.Text = $"Vol.\n{volumebar.Value}";
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            Player.Instance.RemoveQueue(int.Parse($"{e.Row.Cells[0].Value}") - 1);
        }

        private void MusicPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MusicPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Player.Instance.QueueListChanged -= OnQueueListChanged;
        }

        private async void ButtonNext_Click(object sender, EventArgs e)
        {
            await Player.Instance.Next(Player.Instance.IsPlaying);
        }

        private void ButtonLoop_Click(object sender, EventArgs e)
        {
            switch (Player.Instance.LoopStyle)
            {
                case Player.LoopMode.Normal:
                    Player.Instance.LoopStyle = Player.LoopMode.Repeat;
                    break;
                case Player.LoopMode.Repeat:
                    Player.Instance.LoopStyle = Player.LoopMode.SingleRepeat;
                    break;
                case Player.LoopMode.SingleRepeat:
                    Player.Instance.LoopStyle = Player.LoopMode.Normal;
                    break;
            }
            SetCurrentLoopButton();
        }
        private void SetCurrentLoopButton()
        {
            switch (Player.Instance.LoopStyle)
            {
                case Player.LoopMode.Normal:
                    ButtonLoop.Image = App.General.UI.DrawControl.BitmapInterpolation(resource.fluentui_emoji.right_arrow, ButtonLoop.Width, ButtonLoop.Height);
                    break;
                case Player.LoopMode.Repeat:
                    ButtonLoop.Image = App.General.UI.DrawControl.BitmapInterpolation(resource.fluentui_emoji.repeat_button, ButtonLoop.Width, ButtonLoop.Height);
                    break;
                case Player.LoopMode.SingleRepeat:
                    ButtonLoop.Image = App.General.UI.DrawControl.BitmapInterpolation(resource.fluentui_emoji.repeat_single_button, ButtonLoop.Width, ButtonLoop.Height);
                    break;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void progressBar1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //Trace.WriteLine($"{e.X},{e.Y}");
            if (e.Button == MouseButtons.Left)
            {
                if (Player.Instance.TotalTile != null)
                {
                    var pos = (double)e.X / progressBar1.Width;
                    Player.Instance.Seek(((TimeSpan)Player.Instance.TotalTile * pos));
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Player.Instance.RemoveQueue((int)dataGridView1.SelectedRows[0].Cells[0].Value - 1);
                }
            }
        }
    }
}
