using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.InternalTools
{
    public partial class MusicInfoSetter : Form
    {
        MemoryStream? MusicStream;
        WaveStream? WaveStream;
        WaveOut waveOut;
        Stopwatch stopwatch;
        TimeSpan CurrentTime;
        public MusicInfoSetter()
        {
            InitializeComponent();
            waveOut = new WaveOut();
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            stopwatch = new();
        }

        private void WaveOut_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            SongPosition.Enabled = true;
            if (WaveStream != null) WaveStream.Position = 0;
            ButtonPlay.Text = "Play";
            CurrentTime = new(0);
            stopwatch.Reset();
        }

        public async Task LoadSong(string url)
        {
            try
            {
                await FileInit(url);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }
        public async Task FileInit(string url)
        {
            var data = await App.WebRequest.GetRequest(url);
            if (data == null) return;
            Trace.WriteLine($"Size:{data.Length / 1024.0 / 1024.0:0.00}MB");
            MusicStream = new(data);
            if (WaveStream != null && WaveStream.CanRead) await WaveStream.DisposeAsync();
            WaveStream = new Mp3FileReader(MusicStream);
            waveOut.Init(WaveStream);
            SongPosition.Maximum = (int)WaveStream.TotalTime.TotalMilliseconds;
            progressBar1.Maximum = (int)WaveStream.Length;
        }


        private void update_Tick(object sender, EventArgs e)
        {
            if (WaveStream == null)
            {
                progressBar1.Value = 0;
                label4.Text = $"-:--.--- / -:--.---";
            }
            else
            {
                if (progressBar1.Maximum < (int)WaveStream.Position) progressBar1.Value = progressBar1.Maximum;
                else progressBar1.Value = (int)WaveStream.Position;
                var cr = CurrentTime + stopwatch.Elapsed;
                if (SongPosition.Maximum < (int)cr.TotalMilliseconds) SongPosition.Value = SongPosition.Maximum;
                else SongPosition.Value = (int)cr.TotalMilliseconds;
                label4.Text = $"{WaveStream.CurrentTime:m\\:ss\\:fff}({cr:m\\:ss\\:fff}) / {WaveStream.TotalTime:m\\:ss\\:fff}";
                var beat = (cr.TotalMilliseconds - (double)numericUpDown1.Value) / (60000.0 / (double)numericUpDown2.Value);
                int measure = (int)(beat / (double)numericUpDown3.Value);
                double left = beat-measure*(int)numericUpDown3.Value+1;
                label5.Text = $"{measure} {left:0.000}";
            }
        }

        private void SongPosition_ValueChanged(object sender, EventArgs e)
        {
            if (SongPosition.Enabled) if (WaveStream != null)
                {
                    WaveStream.CurrentTime = new((int)SongPosition.Value * 10000);
                    stopwatch.Stop();
                    stopwatch.Reset();
                    if (waveOut.PlaybackState == PlaybackState.Playing) stopwatch.Start();
                    CurrentTime = new((int)SongPosition.Value * 10000);
                }
        }

        private void ButtonPlay_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (WaveStream == null) return;
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {

                    ButtonPlay.Text = "Play";
                    timer2.Start();
                    stopwatch.Stop();
                    waveOut.Pause();
                    WaveStream.CurrentTime = CurrentTime + stopwatch.Elapsed;
                    stopwatch.Reset();
                    CurrentTime = new((int)SongPosition.Value * 10000);
                }
                else if (WaveStream.CanRead)
                {
                    ButtonPlay.Text = "Pause";
                    timer2.Stop();
                    SongPosition.Enabled = false;
                    waveOut.Play();
                    stopwatch.Start();
                }
            }
            catch { }
        }

        private void ButtonStop_Click_1(object sender, EventArgs e)
        {

            if (WaveStream != null)
            {
                waveOut.Stop();
                WaveStream.Position = 0;
                SongPosition.Enabled = true;
                CurrentTime = new(0);
                stopwatch.Stop();
                stopwatch.Reset();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timer2.Interval = 100;
            SongPosition.Enabled = true;
        }
    }
}
