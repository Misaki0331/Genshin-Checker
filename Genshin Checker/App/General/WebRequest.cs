using Genshin_Checker.App.General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static Genshin_Checker.Window.ExWindow.CharacterCalculator.CalculateResult;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Genshin_Checker.App
{
    public class WebRequest
    {
        const string WebUserAgent = "Mozilla/5.0 (X11; Linux x86_64; rv:100.0) Gecko/20100101 Firefox/100.0";
        static private string RandomString(int n)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string result = "";
            Random random = new((int)DateTime.UtcNow.Ticks);
            for (int i = 0; i < n; i++)
                result += chars[random.Next(0, chars.Length)];
            return result;
        }
        static private string MD5Hash(string input)
        {
            using var md5 = MD5.Create();
            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();
            foreach (var b in hashBytes)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
        public static string GetCachePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Genshin Checker", "CacheFiles", filename); //水咲原神チェッカー
        }
        static private string DS()
        {
            //Todo: saltはstatic APIに投げて動的に変更させる
            const string salt = "6s25p5ox5y14umn1p61aqyyvbvvl3lrt";
            string r = RandomString(6);

            var time = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            var input = $"salt={salt}&t={time}&r={r}";
            return $"{time},{r},{MD5Hash(input)}";
        }
        public static async Task<string> HoYoGetRequest(string url, string cookie, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentCulture;
            var uri = new Uri(url);
            var root = $"{uri.Scheme}://{uri.Host}";
            Dictionary<string, string> headers = new()
                {
                    { "Origin", root },
                    { "Referer", root },
                    { "Accept", "application/json, text/plain, */*" },
                    { "Accept-Encoding", "None" },
                    { "Accept-Language", $"{culture.Name};q=0.5" },
                    { "x-rpc-app_version", "1.5.0" },
                    { "x-rpc-client_type", "5" },
                    { "x-rpc-language", culture.Name.ToLower() },
                    { "User-Agent", WebUserAgent },
                    { "Cookie", cookie },
                    { "Ds", DS() }
                };
            HttpClient client = new();
            client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            HttpResponseMessage response = await client.GetAsync(url);
            Trace.WriteLine($"HoYoGet - {url}");
            if (!response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                try
                {
                    var json = JsonChecker<Model.HoYoLab.Root<object>>.Check(data);
                    return data;
                }
                catch
                {
                    return $"{{\"retcode\":{(int)response.StatusCode + 2000000000},\"message\":{Newtonsoft.Json.JsonConvert.SerializeObject($"This error is generated from Genshin Checker.\nHTTP status code is failure.\nStatus Code : {(int)response.StatusCode} - {response.StatusCode}\nMessage : {data}")}}}";
                }
            }
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> HoYoPostRequest(string url, string cookie, string data, CultureInfo? culture = null)
        {
            culture ??= CultureInfo.CurrentCulture;
            var uri = new Uri(url);
            var root = $"{uri.Scheme}://{uri.Host}";
            Dictionary<string, string> headers = new()
                {
                    { "Origin", root },
                    { "Referer", root },
                    { "Accept", "application/json, text/plain, */*" },
                    { "Accept-Encoding", "None" },
                    { "Accept-Language", $"{culture.Name};q=0.5" },
                    { "x-rpc-app_version", "1.5.0" },
                    { "x-rpc-client_type", "5" },
                    { "x-rpc-language", culture.Name.ToLower() },
                    { "User-Agent", WebUserAgent },
                    { "Cookie", cookie },
                    { "DS", DS() }
                };
            HttpClient client = new();
            client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            var content = new StringContent(data, Encoding.UTF8, @"application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            Trace.WriteLine($"HoYoPost - {url}");
            if (!response.IsSuccessStatusCode)
            {
                var data2 = await response.Content.ReadAsStringAsync();
                try
                {
                    var json = JsonChecker<Model.HoYoLab.Root<object>>.Check(data2);
                    return data2;
                }
                catch
                {
                    return $"{{\"retcode\":{(int)response.StatusCode + 2000000000},\"message\":{Newtonsoft.Json.JsonConvert.SerializeObject($"This error is generated from Genshin Checker.\nHTTP status code is failure.\nStatus Code : {(int)response.StatusCode} - {response.StatusCode}\nMessage : {data}")}}}";
                }
            }
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> GeneralGetRequest(string url,bool HideUserAgent=false)
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
                    { "User-Agent", HideUserAgent?WebUserAgent:$"Genshin Checker/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}" },
                };
            HttpClient client = new();
            client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            HttpResponseMessage response = await client.GetAsync(url);
            Trace.WriteLine($"GeneralGet - {response.StatusCode} {url}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<byte[]?> GetRequest(string? url, CancellationToken? token = null)
        {
            if(url==null)return null;
            var uri = new Uri(url);
            bool IsQuery = url.Contains('?');
            var filename = GetCachePath(MD5Hash(url));
            var directory = Path.GetDirectoryName(filename);
            if (directory != null && !Directory.Exists(directory)) Directory.CreateDirectory(directory);
            if (!IsQuery && File.Exists(filename))
            {
                try
                {
                    using FileStream fs = new(filename, FileMode.Open);
                    using GZipStream zipStream = new(fs, CompressionMode.Decompress);
                    using MemoryStream cacheout = new();
                    zipStream.CopyTo(cacheout);
                    Trace.WriteLine($"Cache ({fs.Length}->{cacheout.Length}) : {url}");
                    return cacheout.ToArray();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                }
            }
            Stopwatch stopwatch = new();
            stopwatch.Start();
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
                    { "User-Agent", $"Genshin Checker/{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}" },
                };
            HttpClient client = new();
            client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            HttpResponseMessage response = new();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    if (token == null) response = await client.GetAsync(url);
                    else response = await client.GetAsync(url, (CancellationToken)token);
                    if (!response.IsSuccessStatusCode)
                    {
                        Trace.WriteLine($"Error: {response.StatusCode} - {url}");
                        throw new ArgumentException($"Error: {response.StatusCode} - {url}");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.Message);
                    if (i == 9)
                    {
                        return null;
                    }
                    continue;
                }
            }
            var stream = await response.Content.ReadAsStreamAsync();
            if (!IsQuery)
            {
                using FileStream stream2 = new(filename, FileMode.Create);
                using GZipStream zipStream = new(stream2, CompressionMode.Compress);
                stream.CopyTo(zipStream);
                zipStream.Close();
            }
            Trace.WriteLine($"Downloaded ({stream.Length:#,##0} Bytes / {stopwatch.ElapsedMilliseconds / 1000.0:0.00} sec) : {url}");
            byte[] buffer = new byte[16 * 1024];
            using MemoryStream ms = new();
            stream.Position = 0;
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
        }
        public static async Task<Image> ImageGetRequest(string? url,CancellationToken? token=null)
        {
            if (url == null) return resource.icon.fail;
            var stream = await GetRequest(url, token);
            if (stream == null) return resource.icon.fail;
            MemoryStream ms = new(stream);
            var bitmap = new Bitmap(ms);
            return bitmap;
        }

    }
}
