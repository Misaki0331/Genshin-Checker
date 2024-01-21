using Genshin_Checker.App.General;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

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
                throw new InvalidDataException("起動時にデータが取得できていなかったため、この操作は取り消されました。\nもう一度やり直してください。");
            }
            var result = links.Except(TempLinks).ToList();
            Trace.WriteLine(result);
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
            catch (InvalidDataException)
            {
                return true;
            }
        }
        public static async Task<string?> GetServiceCenterAuthKey()
        {
            //先頭682文字はユーザー固有文字列っぽい。
            //可能ならアカウントリスト取れるかも？
            var links = await GetLinks();
            if(links == null) return null;
            var urls = links.FindAll(a => a.StartsWith("https://webstatic-sea.hoyoverse.com/csc-service-center-fe/index.html"));
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
                    Trace.WriteLine($"{a.aid} OK");
                    LatestServiceCenterAuthKey = authkey;
                    return authkey;
                }
                catch (GameAPI.GameAPIException)
                {
                }
            }
            return LatestServiceCenterAuthKey;
        } 
    }
}
