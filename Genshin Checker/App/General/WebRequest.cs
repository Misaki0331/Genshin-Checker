using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App
{
    public class WebRequest
    {
        static private string DS()
        {
            const string salt = "6s25p5ox5y14umn1p61aqyyvbvvl3lrt";
            const string r = "Noelle";

            var time = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            var input = $"salt={salt}&t={time}&r={r}";
            using var md5 = MD5.Create();
            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();
            foreach (var b in hashBytes)
                builder.Append(b.ToString("x2"));
            return $"{time},Noelle,{builder}";
        }
        public static async Task<string> HoYoGetRequest(string url, string cookie)
        {
            var uri = new Uri(url);
            var root = $"{uri.Scheme}://{uri.Host}";
            Dictionary<string, string> headers = new()
                {
                    { "Origin", root },
                    { "Referer", root },
                    { "Accept", "application/json, text/plain, */*" },
                    { "Accept-Encoding", "None" },
                    { "Accept-Language", "en-US;q=0.5" },
                    { "x-rpc-app_version", "1.5.0" },
                    { "x-rpc-client_type", "5" },
                    { "x-rpc-language", "en-us" },
                    { "User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:100.0) Gecko/20100101 Firefox/100.0" },
                    { "Cookie", cookie },
                    { "DS", DS() }
                };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> HoYoPostRequest(string url, string cookie, string data)
        {
            var uri = new Uri(url);
            var root = $"{uri.Scheme}://{uri.Host}";
            Dictionary<string, string> headers = new()
                {
                    { "Origin", root },
                    { "Referer", root },
                    { "Accept", "application/json, text/plain, */*" },
                    { "Accept-Encoding", "None" },
                    { "Accept-Language", "en-US;q=0.5" },
                    { "x-rpc-app_version", "1.5.0" },
                    { "x-rpc-client_type", "5" },
                    { "x-rpc-language", "en-us" },
                    { "User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:100.0) Gecko/20100101 Firefox/100.0" },
                    { "Cookie", cookie },
                    { "DS", DS() }
                };
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            var content = new StringContent(data, Encoding.UTF8, @"application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            Trace.WriteLine($"{url}\n{response.StatusCode}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }
}
