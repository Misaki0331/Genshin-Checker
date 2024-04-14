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
        public class MusicEvent
        {
            public string type = "";
            public double beat;
            public double value;
        }
        public BeatTimeConverter beat = new(new());
        public class BeatTimeConverter
        {
            class MusicDetailEvent : MusicEvent
            {
                public TimeSpan TriggerStart;
            };
            private List<MusicDetailEvent> events;
            private List<MusicEvent> bpm;

            public BeatTimeConverter(List<MusicEvent> bpmEvents)
            {
                // BPMイベントだけをフィルタリングして、拍子に沿ってソートする
                bpm = bpmEvents.Where(e => e.type == "BPM").OrderBy(e => e.beat).ToList();
                events = new();
                foreach (var a in bpmEvents) events.Add(new() { type = a.type, beat = a.beat, value = a.value, TriggerStart = TimeSpan.FromSeconds(BeatsToTime(a.beat)) });
            }
            public class Result
            {
                public double second;
                public double bpm;
            }
            // 時間からビート数を計算する
            public Result TimeToBeats(double timeInSeconds)
            {
                lock (events)
                {
                    double currentBeat = 0.0;
                    double currentTime = 0.0;
                    double lastBPM = 120.0; // 初期BPMを120とする（指定がない場合のデフォルト）

                    foreach (var evt in events)
                    {
                        // 次のBPMイベントまでの時間を計算
                        double nextTime = currentTime + (60.0 / lastBPM) * (evt.beat - currentBeat);
                        if (timeInSeconds < nextTime)
                        {
                            // 指定された時間がこのイベントの前にある場合、中断して計算
                            return new() { bpm = lastBPM, second = currentBeat + (timeInSeconds - currentTime) * lastBPM / 60.0 };
                        }

                        // 更新
                        currentBeat = evt.beat;
                        currentTime = nextTime;
                        lastBPM = evt.value;
                    }
                    // 最後のBPMイベントから時間の終わりまで
                    return new() { bpm = lastBPM, second = currentBeat + (timeInSeconds - currentTime) * lastBPM / 60.0 };
                }
            }

            // ビート数から時間を計算する
            public double BeatsToTime(double beats)
            {
                double currentBeat = 0.0;
                double currentTime = 0.0;
                double lastBPM = 120.0; // 初期BPMを120とする（指定がない場合のデフォルト）

                foreach (var evt in events)
                {
                    if (beats < evt.beat)
                    {
                        // 指定されたビート数がこのイベントの前にある場合、中断して計算
                        return currentTime + (60.0 / lastBPM) * (beats - currentBeat);
                    }

                    // 次のBPMイベントまでの時間を更新
                    currentTime += (60.0 / lastBPM) * (evt.beat - currentBeat);
                    currentBeat = evt.beat;
                    lastBPM = evt.value;
                }

                // 最後のBPMイベントからビートの終わりまで
                return currentTime + (60.0 / lastBPM) * (beats - currentBeat);
            }
        }
        MemoryStream? MusicStream;
        WaveStream? WaveStream;
        WaveOut waveOut;
        Stopwatch stopwatch;
        TimeSpan CurrentTime;
        public MusicInfoSetter()
        {
            InitializeComponent();
            waveOut = new WaveOut() {DesiredLatency = 10, NumberOfBuffers =500 };
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
            if (WaveStream != null && WaveStream.CanRead) await WaveStream.DisposeAsync();
            WaveStream = new Mp3FileReader(url);
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
                var cr = waveOut.PlaybackState==PlaybackState.Playing?WaveStream.CurrentTime-System.TimeSpan.FromSeconds(0.5):WaveStream.CurrentTime;
                if (SongPosition.Maximum < (int)cr.TotalMilliseconds) SongPosition.Value = SongPosition.Maximum;
                label4.Text = $"{WaveStream.CurrentTime:m\\:ss\\:fff}({cr:m\\:ss\\:fff}) / {WaveStream.TotalTime:m\\:ss\\:fff}";
                var res = beat.TimeToBeats(cr.TotalSeconds - (double)offset.Value / 1000.0);
                label5.Text = $"{res.second:0.000}  {res.bpm} BPM";
            }
        }

        private void SongPosition_ValueChanged(object sender, EventArgs e)
        {
            if (SongPosition.Enabled) if (WaveStream != null)
                {
                    WaveStream.CurrentTime = TimeSpan.FromSeconds((double)SongPosition.Value / 1000.0);
                    stopwatch.Stop();
                    stopwatch.Reset();
                    if (waveOut.PlaybackState == PlaybackState.Playing) stopwatch.Start();
                    CurrentTime = TimeSpan.FromSeconds((double)SongPosition.Value / 1000.0);
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
        List<MusicEvent> timelist=new();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lock (timelist)
            {
                timelist.Clear();
                foreach (var text in textBox1.Lines)
                {
                    var spl = text.Split(",");
                    if (spl.Length == 3)
                    {
                        if (double.TryParse(spl[0], out var measure) && double.TryParse(spl[2],out var value))
                        {
                            timelist.Add(new MusicEvent() { beat = measure, type = spl[1], value = value == 0 ? 0.000001 : value });
                        }
                    }
                }
                beat = new(timelist);
            }
        }
    }
}
