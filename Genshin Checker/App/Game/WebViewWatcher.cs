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
        static List<string> ExpiredAuthKeys = new();
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
            return links;
        }
        public static async Task<string?> GetServiceCenterAuthKey()
        {
            //ToDo:期限切れの認証キーは追加リクエストしないようにしたい。
            //リストから無くなったら削除したい。
            //先頭682文字はユーザー固有文字列っぽい。
            //可能ならアカウントリスト取れるかも？
            var links = await GetLinks();
            if(links == null) return null;
            var urls = links.FindAll(a => a.StartsWith("https://webstatic-sea.hoyoverse.com/csc-service-center-fe/index.html"));
            urls.Reverse();
            Trace.WriteLine($"{urls.Count} Expaired:{ExpiredAuthKeys.Count}");
            if (urls.Count==0) return null;
            foreach( var url in urls)
            {
                NameValueCollection querys = HttpUtility.ParseQueryString(new Uri(url).Query);
                var authkey=querys["authkey"];
                if (authkey == null||ExpiredAuthKeys.Find(a=>a==authkey)!=null) continue;
                try
                {
                    var a = await GameAPI.GetAccountInfo(authkey);
                    Trace.WriteLine($"{a.aid} OK");
                    return authkey;
                }
                catch(GameAPI.GameAPIException)
                {
                    ExpiredAuthKeys.Add(authkey);
                }
                finally
                {
                }
            }
            return null;
        } 
    }
}
