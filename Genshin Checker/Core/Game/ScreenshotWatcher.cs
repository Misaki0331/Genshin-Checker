﻿using Genshin_Checker.Core.General;
using Genshin_Checker.resource.Languages;
using System.IO;

namespace Genshin_Checker.Core.Game
{
    internal class ScreenshotWatcher
    {
        static ScreenshotWatcher? instance = null;
        public static ScreenshotWatcher Instance { get => instance ??= new ScreenshotWatcher(); }
        public string Path { get => watcher.Path; set => watcher.Path = value; }
        public bool IsRaise { get => watcher.EnableRaisingEvents; 
            set
            {
                if (value&&string.IsNullOrEmpty(watcher.Path)) throw new ArgumentException(Localize.Error_Config_Screenshot_IsRaise); 
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
            Log.Debug($"新しいファイルが生成されました: {e.Name}");
            NewImageEvent?.Invoke(null, e.FullPath);
        }
    }
}
