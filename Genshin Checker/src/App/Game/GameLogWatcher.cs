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
        readonly System.Windows.Forms.Timer Delay;
        string PATH = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\AppData\\LocalLow\\miHoYo\\Genshin Impact";
        const string FILENAME = "output_log.txt";
        public DateTime LatestUpdate = DateTime.MinValue;
        readonly SemaphoreSlim Semaphore = new(1, 1);
        /// <summary>
        /// ログファイルの最終ポジション
        /// </summary>
        long LogPosition = 0;
        public int WatchDogInterval { get=>Delay.Interval; set => Delay.Interval = value; }
        private GameLogWatcher()
        {
            Delay = new()
            {
                Interval = 10
            };
            GameLogTemp = new();
            Delay.Tick += LogChanged;
            LogUpdated += LogUpdatedList;
        }
        public void Init()
        {
           Delay.Enabled= true;
        }
        public List<string> GameLog 
        { 
            get { 
                var output = new List<string>(); 
                foreach(var item in GameLogTemp) 
                    output.Add(item); 
                return output; 
            } 
        }
        List<string> GameLogTemp;
        private void LogUpdatedList(object? sender, string[] e)
        {

            foreach (var item in e)
            {
                GameLogTemp.Add(item);
                if (GameLogTemp.Count > 200) GameLogTemp.RemoveAt(0);
                //Trace.Write(item);
            }
        }
        public event EventHandler<string[]>? LogUpdated = null;
        private async void LogChanged(object? source, EventArgs e)
        {
            await Semaphore.WaitAsync();
            try
            {
                FileStream fs = new($"{PATH}/{FILENAME}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                try
                {
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
                        for (int i=0;i<a.Count;i++)
                        {
                            s[i] = a[i].Value;
                        }
                        LatestUpdate = DateTime.UtcNow;
                        LogUpdated?.Invoke(null, s);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Genshin Log Error! {ex.Message}");
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (FileNotFoundException)
            {
                LogPosition = 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            finally
            {
                Semaphore.Release();
            }
        }
    }
}
