using NAudio.Wave;
using System.IO;

namespace Genshin_Checker.Core.General.Music
{
    public class Player
    {
        MemoryStream? MusicStream;
        WaveStream? WaveStream;
        WaveOut waveOut;
        List<QueueInfo> Queues;
        QueueInfo Current;
        bool UserStopped = false;
        private static Player? _instance;
        const int Buffer = 500; //バッファー値(ms)
        public enum LoopMode
        {
            Normal,
            Repeat,
            SingleRepeat
        };

        public event EventHandler? QueueListChanged;

        private Player()
        {
            Queues = new();
            waveOut = new WaveOut() { 
                DesiredLatency = 10, //イベント更新時間(CurrentTimeの更新に直結するので出来れば小さい値に)
                NumberOfBuffers= Buffer //バッファ数(少ないと処理落ちするので多めに)
            };
            Current = new();
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
        }

        private async void WaveOut_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (UserStopped)
            {
                UserStopped = false;
                return;
            }
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
        public string CurrentTitle { get => Current.Title; }
        public System.TimeSpan CurrentTime
        {
            get => WaveStream != null ?
                (waveOut.PlaybackState != PlaybackState.Stopped ?
                WaveStream.CurrentTime - TimeSpan.FromMilliseconds(waveOut.NumberOfBuffers) :
                WaveStream.CurrentTime) :
                TimeSpan.Zero;
            set => Seek(CurrentTime);
        }
        public System.TimeSpan? TotalTile { get => WaveStream?.TotalTime-TimeSpan.FromMilliseconds(waveOut.NumberOfBuffers); }
        public double Volume { get => waveOut.Volume; set => waveOut.Volume = (float)value; }

        LoopMode _looptype;
        public LoopMode LoopStyle { get => _looptype; set => _looptype = value; }
        /// <summary>
        /// 次のプレイリストを再生します。
        /// </summary>
        /// <param name="play">次に進んだ後再生するか</param>
        /// <param name="force">強制的にプレイリストの次の楽曲を選択するか</param>
        /// <returns></returns>
        public async Task Next(bool play = false, bool force = false)
        {
            while (Queues.Count > 0)
            {
                try
                {
                    if (force)
                    {
                        lock (Queues)
                        {
                            Current = Queues[0];
                            Queues.Remove(Queues[0]);
                        }
                    }
                    else
                    {
                        var index = 0;//ToDo: ランダマイズ用に
                        lock (Queues)
                        {
                            switch (LoopStyle)
                            {
                                case LoopMode.Normal:
                                    Current = Queues[index];
                                    Queues.Remove(Queues[index]);
                                    break;
                                case LoopMode.Repeat:
                                    Queues.Add(Current);
                                    Current = Queues[index];
                                    Queues.Remove(Queues[index]);
                                    break;
                                case LoopMode.SingleRepeat:
                                    break;
                            }
                        }
                    }
                        QueueListChanged?.Invoke(this, EventArgs.Empty);
                    await FileInit($"{Current.Uri}");
                    if(play)Play();
                    break;

                }
                catch (Exception ex)
                {
                    Log.Error($"再生エラー : {ex}");
                    continue;
                }
            }
        }
        /// <summary>
        /// 再生する。
        /// </summary>
        public async void Play()
        {
            if (WaveStream == null) await Next();
            if (WaveStream == null)
            {
                Log.Warn("再生できませんでした。");
                return;
            }
            UserStopped = false;
            waveOut.Play();
        }
        /// <summary>
        /// 再生中の楽曲をシークする
        /// </summary>
        /// <param name="time">シークする時間</param>
        public void Seek(TimeSpan time)
        {
            if(WaveStream == null) return;
            if (WaveStream.CanSeek)
            {
                WaveStream.CurrentTime = time;
            }
        }
        /// <summary>
        /// 再生中の楽曲を一時停止する
        /// </summary>
        public void Pause()
        {
            if (WaveStream == null) return;
            waveOut.Pause();
            
        }
        /// <summary>
        /// 再生中の楽曲を停止する
        /// </summary>
        public void Stop()
        {
            if (WaveStream == null) return;
            WaveStream.CurrentTime = new(0);
            UserStopped = true;
            waveOut.Stop();
        }
        /// <summary>
        /// URLからファイルを取得して再生。<br/>
        /// キャッシュ機能付き
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task FileInit(string url)
        {
            var data = await Core.WebRequest.GetRequest(url);
            if (data == null) return;
            Log.Debug($"Size:{data.Length / 1024.0 / 1024.0:0.00}MB");
            MusicStream = new(data);
            if (WaveStream != null && WaveStream.CanRead) await WaveStream.DisposeAsync();
            WaveStream = new Mp3FileReader(MusicStream);
            waveOut.Init(WaveStream);
        }
        /// <summary>
        /// 楽曲をキューに追加
        /// </summary>
        /// <param name="url"></param>
        /// <returns>キューの数</returns>
        public int AddQueue(string url, string title = "")
        {
            Log.Debug($"音楽キュー追加しました。 - {title}");
            lock (Queues)
            {
                Queues.Add(new() { Title = title, Uri = new(url) });
                if (Queues.Count == 1&&!IsPlaying) Task.Run(async () => { await Next(true); });
            }
            QueueListChanged?.Invoke(this, EventArgs.Empty);
            return Queues.Count;
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
            }
            QueueListChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }
        public int QueueCount { get { return Queues.Count; } }
        public List<QueueInfo> GetQueue()
        {
            var list = new List<QueueInfo>();
            foreach(var item in Queues)
            list.Add(new() { ID = item.ID, Title = item.Title, Uri = item.Uri });
            return list;
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
