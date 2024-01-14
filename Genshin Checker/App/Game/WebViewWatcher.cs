using Genshin_Checker.App.General;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public class WebViewWatcher
    {
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
            var links = await GetLinks();
            if(links == null) return null;
            var link = links.FindLast(a => a.StartsWith("https://webstatic-sea.hoyoverse.com/csc-service-center-fe/index.html"));
            if (link == null) return null;
            NameValueCollection querys = HttpUtility.ParseQueryString(new Uri(link).Query);
            return querys["authkey"];
        } 
    }
}
