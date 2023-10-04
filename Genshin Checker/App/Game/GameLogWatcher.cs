using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Genshin_Checker.App.Game
{
    internal class GameLogWatcher
    {
        static GameLogWatcher? instance = null;
        public static GameLogWatcher Instance { get => instance ??= new GameLogWatcher(); }

        //FileSystemWatcher LogWatcher;
        readonly System.Windows.Forms.Timer Delay;
        string PATH = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).ToString()}\\AppData\\LocalLow\\miHoYo\\Genshin Impact";
        const string FILENAME = "output_log.txt";
        readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);
        long LogPosition = 0;
        public int WatchDogInterval { get=>Delay.Interval; set => Delay.Interval = value; }
        private GameLogWatcher()
        {

            /*LogWatcher = new();
            LogWatcher.Path = PATH;
            LogWatcher.Filter = FILENAME;
            LogWatcher.NotifyFilter = NotifyFilters.LastWrite;
            LogWatcher.IncludeSubdirectories = false;
            //イベントハンドラの追加*/
            Delay = new();
            Delay.Interval = 10;
            Delay.Tick += LogChanged;
        }
        public void Init()
        {
            //watcher.InternalBufferSize = 4096
            //LogWatcher.SynchronizingObject = synchronize;

            //監視を開始する
           // LogWatcher.EnableRaisingEvents = true;
           Delay.Enabled= true;
        }
        public event EventHandler<string[]>? LogUpdated = null;
        private async void LogChanged(object? source, EventArgs e)
        {
            await Semaphore.WaitAsync();
            //Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                FileStream fs = new($"{PATH}/{FILENAME}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                try
                {
                    //Stopwatch sw = Stopwatch.StartNew();
                    long size = fs.Length;
                    if (LogPosition == size)
                    {
                        fs.Close();

                        return;
                    }
                    if (size < LogPosition)
                        LogPosition = 0;
                    fs.Seek(LogPosition, SeekOrigin.Begin);
                    byte[] bytes = new byte[size - LogPosition];
                    await fs.ReadAsync(bytes);
                    LogPosition = size;
                    var res = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    if (res != null)
                    {
                        var a = Regex.Matches(res+"\r\n", @"^\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\].*$",RegexOptions.Multiline);
                            string[] s = new string[a.Count];
                        //Trace.WriteLine(a.Count);
                        for (int i=0;i<a.Count;i++)
                        {
                            s[i] = a[i].Value;
                        }
                        LogUpdated?.Invoke(null, s);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine($"Error! {ex.Message}");
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                Semaphore.Release();
            }
        }
    }
}
