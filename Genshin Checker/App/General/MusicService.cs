using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General.Music
{
    public class Player
    {
        MemoryStream? MusicStream;
        WaveStream? WaveStream;
        WaveOut waveOut;
        List<QueueInfo> Queues;
        Stopwatch Stopwatch;
        System.TimeSpan LatestPosition;
        private static Player? _instance;
        private Player()
        {
            Queues = new();
            waveOut = new WaveOut();
            LatestPosition = new();
            Stopwatch = new();
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
        }

        private async void WaveOut_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            Stop();
            while (Queues.Count > 0)
            {
                try
                {
                    await Next();
                    Play();
                    break;

                }catch(Exception)
                {
                    continue;
                }
            }
        }
        public bool IsPlaying { get=>waveOut.PlaybackState== PlaybackState.Playing; }
        public static Player Instance { get => _instance ??= new(); }
        public System.TimeSpan CurrentTime { get => LatestPosition + Stopwatch.Elapsed; set => Seek(CurrentTime); }
        public async Task Next()
        {

            while (Queues.Count > 0)
            {
                try
                {
                    await FileInit($"{Queues[0].Uri}");
                    Play();
                    break;

                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
        public async void Play()
        {
            if (WaveStream == null) await Next();
            if (WaveStream == null) return;
            LatestPosition = WaveStream.CurrentTime;
            waveOut.Play();
        }
        public void Seek(TimeSpan time)
        {
            if(WaveStream == null) return;
            if (WaveStream.CanSeek)
            {
                WaveStream.CurrentTime = time;
            }
        }
        public void Pause()
        {
            if (WaveStream == null) return;
            LatestPosition += Stopwatch.Elapsed;
            Stopwatch.Stop();
            Stopwatch.Reset();
            waveOut.Pause();
            WaveStream.CurrentTime = LatestPosition;
            
        }
        public void Stop()
        {
            if (WaveStream == null) return;
            Stopwatch.Stop();
            Stopwatch.Reset();
            LatestPosition = new(0);
            WaveStream.CurrentTime = LatestPosition;
            waveOut.Stop();
            WaveStream.Position = 0;
        }
        private async Task FileInit(string url)
        {
            var data = await App.WebRequest.GetRequest(url);
            if (data == null) return;
            Trace.WriteLine($"Size:{data.Length / 1024.0 / 1024.0:0.00}MB");
            MusicStream = new(data);
            if (WaveStream != null && WaveStream.CanRead) await WaveStream.DisposeAsync();
            WaveStream = new Mp3FileReader(MusicStream);
            waveOut.Init(WaveStream);
            LatestPosition = new(0);
            Stopwatch.Reset();
        }
        /// <summary>
        /// 楽曲をキューに追加
        /// </summary>
        /// <param name="url"></param>
        /// <returns>キューの数</returns>
        public int AddQueue(string url)
        {
            lock (Queues)
            {
                Queues.Add(new() { Title = url, Uri = new(url) });
                return Queues.Count;
            }
        }
        /// <summary>
        /// キューの削除
        /// </summary>
        /// <param name="QueuePos"></param>
        /// <returns></returns>
        public bool RemoveQueue(int QueuePos)
        {
            if (Queues.Count <= QueuePos || 0 > QueuePos) return false;
            lock (Queues)
            {
                Queues.RemoveAt(QueuePos);
                return true;
            }
        }
        /// <summary>
        /// サウンドデバイスの取得
        /// </summary>
        /// <returns></returns>
        public List<SoundOutDevice> GetDevices()
        {
            List<SoundOutDevice> devices = new();
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                WaveOutCapabilities WOC = WaveOut.GetCapabilities(i);
                devices.Add(new() { DeviceName = WOC.ProductName, GUID = WOC.ProductGuid }) ;
            }
            return devices;
        }
        /// <summary>
        /// 出力サウンドデバイスの指定
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>成功はtrue</returns>
        public bool SetDevice(Guid guid)
        {
            var devices = GetDevices();
            var device = devices.FindIndex(x => x.GUID == guid);
            if (device!=-1)
            {
                waveOut.DeviceNumber = device;
                return true;
            }
            return false;
        }
    }
    public class QueueInfo
    {
        public int ID { get; set; } = 0;
        public string Title { get; set; } = "";
        public System.Uri? Uri { get; set; } = null;
    }
    public class SoundOutDevice
    {
        public string DeviceName { get; set; } = "";
        public Guid GUID { get; set; } = new();
    }
}
