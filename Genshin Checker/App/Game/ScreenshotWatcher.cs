using Genshin_Checker.App.General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Genshin_Checker.App.Game
{
    internal class ScreenshotWatcher
    {
        static ScreenshotWatcher? instance = null;
        public static ScreenshotWatcher Instance { get => instance ??= new ScreenshotWatcher(); }
        public string Path { get => watcher.Path; set => watcher.Path = value; }
        public bool IsRaise { get => watcher.EnableRaisingEvents; 
            set
            {
                if (value&&string.IsNullOrEmpty(watcher.Path)) throw new ArgumentException("監視を開始する前にPathを設定してください。"); 
                watcher.EnableRaisingEvents = value; 
            } 
        }
        FileSystemWatcher watcher;

        private ScreenshotWatcher()
        {
            watcher = new();
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Filter = "*.png";
            var path = Option.Instance.ScreenShot.RaisePath;
            if (Directory.Exists(path))
            {
                watcher.Path = path;
                watcher.EnableRaisingEvents = Option.Instance.ScreenShot.IsRaise;
            }
        }
        public void Start()
        {
            IsRaise= true;
        }
        public void Stop()
        {
            IsRaise = false;
        }
        public event EventHandler<string>? NewImageEvent = null;
        private void OnCreated(object? sender, FileSystemEventArgs e)
        {
            Trace.WriteLine($"新しいファイルが生成されました: {e.Name}");
            NewImageEvent?.Invoke(null, e.FullPath);
        }
    }
}
