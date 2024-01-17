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
        MemoryStream? MusicStream;
        WaveStream? WaveStream;
        WaveOut waveOut;
        public MusicPlayer()
        {
            InitializeComponent();
            waveOut = new WaveOut();
        }
        public async void LoadSong(string url)
        {
            try
            {
                await FileInit(url);
            }
            catch (Exception ex) {
                Trace.WriteLine(ex);
            }
        }
        public async Task FileInit(string url)
        {
            var data = await App.WebRequest.GetRequest(url);
            if (data == null) return;
            MusicStream = new(data);
            if (WaveStream != null && WaveStream.CanRead) await WaveStream.DisposeAsync();
            WaveStream = new Mp3FileReader(MusicStream);
            waveOut.Init(WaveStream);
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            if (waveOut.PlaybackState == PlaybackState.Playing) waveOut.Pause();
            else waveOut.Play();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            waveOut.Stop();
        }

        private void update_Tick(object sender, EventArgs e)
        {
            if (WaveStream == null)
            {
                progressBar1.Value = 0;
                label1.Text = $"-:-- / -:--";
            }
            else
            {
                progressBar1.Value = (int)((double)WaveStream.Position/(double)WaveStream.Length*10000.0);
                label1.Text = $"{WaveStream.CurrentTime:m\\:ss} / {WaveStream.TotalTime:m\\:ss}";
            }
        }
    }
}
