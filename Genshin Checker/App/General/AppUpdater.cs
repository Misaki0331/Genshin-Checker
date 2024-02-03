using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General
{
    public static class AppUpdater
    {
        public static string NewVersion { get; private set; } = "";
        public static string NewVersionName { get; private set; } = "";
        public static DateTime LatestReleaseTime { get; private set; } = DateTime.MinValue;
        public static int DownloadCount { get; private set; } = 0;
        public static int ApplicationSize { get; private set; } = 0;
        public static string UpdateBody { get; private set; } = "";

        public static string CurrentVersion
        {
            get
            {
                return $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
            }
        }
        public static async Task<bool> CheckVersion()
        {
            var root = JsonChecker<Model.GitHub.Latest.Root>.Check(await WebRequest.GeneralGetRequest("https://api.github.com/repos/misaki0331/genshin-checker/releases/latest"));
            NewVersion = root.tag_name;
            NewVersionName = root.name;
            LatestReleaseTime = root.published_at;
            UpdateBody = root.body;
            if(root.assets.Count > 0)
            {
                DownloadCount = root.assets[0].download_count;
                ApplicationSize = root.assets[0].size;
            }

            //バージョンチェック
            var current = CurrentVersion.Split(".");
            var latest = NewVersion.Split(".");
            bool IsNewRelease = false;
            for(int i = 0; i < Math.Min(current.Length, latest.Length); i++)
            {
                if (int.TryParse(current[i],out int c) && int.TryParse(latest[i],out int l)) {
                    if (c > l) break;
                    if (c < l)
                    {
                        IsNewRelease = true; 
                        break;
                    }
                }
            }
            return IsNewRelease;
        }
    }
}
