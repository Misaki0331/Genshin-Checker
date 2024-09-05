using Genshin_Checker.App.General;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;

namespace Genshin_Checker.App.Game
{
    public static class WebViewWatcher
    {
        static List<string>? TempLinks = null;
        static string? LatestServiceCenterAuthKey = null;
        public static async Task<List<string>?> GetLinks()
        {
            var path = await GameApp.WhereWebCacheFilePath();
            if (path == null) return null;
            string temp = Path.GetTempFileName();
            File.Copy(path, temp, true);
            List<string> links = new();

            using (FileStream fs = new($"{temp}", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new(fs))
                {
                    var raw = sr.ReadToEnd();
                    var splited = raw.Split("1/0/");
                    foreach(var s in splited)
                    {
                        var regex = Regex.Match(s, "https.+?[^\x00]+");
                        if (regex.Success)
                        {
                            links.Add(regex.Value.Trim());
                        }
                    }
                }
                fs.Close();
            }
            File.Delete(temp);
            if (TempLinks == null)
            {
                TempLinks = new();
                foreach (var l in links) TempLinks.Add(l);
                Log.Debug("リンク未初期化の為初期化しました。");
                return new();
            }
            var result = links.Except(TempLinks).ToList();
            Log.Debug($"データ内のリンクは {result.Count} 件確認しました。");
            TempLinks.Clear();
            TempLinks = links;
            return result;
        }
        public static async Task<bool> Init()
        {
            try
            {
                return await GetLinks()!=null;
            }
            catch (InvalidDataException ex)
            {
                Log.Warn($"WebLinkの初期化に失敗しました。 {ex.Message}");
                return true;
            }
        }
        public static async Task<string?> GetServiceCenterAuthKey()
        {
            //先頭682文字はユーザー固有文字列っぽい。
            //可能ならアカウントリスト取れるかも？
            var links = await GetLinks();
            if(links == null) return null;
            var urls = links.FindAll(a => a.StartsWith("https://cs.hoyoverse.com/csc-service-center-fe/index.html"));
            urls.Reverse();
            if (urls.Count == 0) return LatestServiceCenterAuthKey;
            foreach (var url in urls)
            {
                NameValueCollection querys = HttpUtility.ParseQueryString(new Uri(url).Query);
                var authkey = querys["authkey"];
                if (authkey == null) continue;
                try
                {
                    var a = await GameAPI.GetAccountInfo(authkey);
                    Log.Info($"Success! HoYoverse Account ID : {a.aid}");
                    LatestServiceCenterAuthKey = authkey;
                    return authkey;
                }
                catch (GameAPI.GameAPIException ex)
                {
                    Log.Warn($"Failed! {ex.Message}");
                }
            }
            return LatestServiceCenterAuthKey;
        } 
    }
}
