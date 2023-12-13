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
    internal class ScreenshotWacher
    {
        static ScreenshotWacher? instance = null;
        public static ScreenshotWacher Instance { get => instance ??= new ScreenshotWacher(); }
        public string Path { get => watcher.Path; set => watcher.Path = value; }
        public bool IsRaise { get => watcher.EnableRaisingEvents; 
            set
            {
                if (value&&string.IsNullOrEmpty(watcher.Path)) throw new ArgumentException("監視を開始する前にPathを設定してください。"); 
                watcher.EnableRaisingEvents = value; 
            } 
        }
        FileSystemWatcher watcher;

        private ScreenshotWacher()
        {
            watcher = new();
            watcher.Created += new FileSystemEventHandler(OnCreated);
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
