using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Genshin_Checker.Core.Game
{
    internal class LauncherLogWatcher
    {
        static LauncherLogWatcher? instance = null;
        public static LauncherLogWatcher Instance { get => instance ??= new LauncherLogWatcher(); }
        readonly System.Windows.Forms.Timer Delay;
        string PATH = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}/AppData/Roaming/Cognosphere/HYP/1_0/logs";
        const string FILENAME = "HYP.log";
        public DateTime LatestUpdate = DateTime.MinValue;
        readonly SemaphoreSlim Semaphore = new(1, 1);
        /// <summary>
        /// ログファイルの最終ポジション
        /// </summary>
        long LogPosition = 0;
        public int WatchDogInterval { get => Delay.Interval; set => Delay.Interval = value; }
        private LauncherLogWatcher()
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
            Delay.Enabled = true;
        }
        public List<string> GameLog
        {
            get
            {
                var output = new List<string>();
                foreach (var item in GameLogTemp)
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
                        /*var a = Regex.Matches(res+"\r\n", @"^\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\].*$",RegexOptions.Multiline);
                        string[] s = new string[a.Count];
                        for (int i=0;i<a.Count;i++)
                        {
                            s[i] = a[i].Value;
                        }
                        LatestUpdate = DateTime.UtcNow;*/
                        LogUpdated?.Invoke(null, res.Replace("\r\n", "\n").Split("\n"));
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"Launcher Log Error! {ex.Message}");
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
