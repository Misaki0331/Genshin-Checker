using Genshin_Checker.resource.Languages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App
{
    public class Registry
    {
        public static bool IsReadOnly { get; set; } = false;
        public static string? GetValue(string Subkey, string key, bool compress = false)
        {
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($"Software\\Genshin_Checker\\{Subkey}");
            if (regkey == null) throw new IOException(Localize.Error_Registry_FailedToOpen);
            var val = regkey.GetValue(key);
            regkey.Close();
            if(val == null) return null;
            string res = $"{val}";
            if (compress)
                res = StringFromBase64Comp(res);
            return res;
        }

        public static string? GetAppReg(string AppName ,string Subkey, string key)
        {
            var regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey($"Software\\{AppName}\\{Subkey}");
            if (regkey == null) throw new IOException(Localize.Error_Registry_FailedToOpen);
            var val = regkey.GetValue(key);
            regkey.Close();
            if (val == null) return null;
            if (val.GetType() == typeof(System.Byte[]))
            {
                return Encoding.UTF8.GetString((Byte[])val);
            }
            return val.ToString();
        }

        public static void SetValue(string Subkey, string key, string value, bool compress=false,bool force=false)
        {
#if DEBUG
            var data = value;
            if (value.Length > 100) data = value[..100]+$"...({value.Length})";
            Trace.WriteLine($"{Subkey}:{key} (Compress:{compress}) Value:\"{data}\"");
#endif
            if(IsReadOnly&&!force) return;
            if (compress) value = Base64FromStringComp(value);
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($"Software\\Genshin_Checker\\{Subkey}");
            if (regkey == null) throw new IOException(Localize.Error_Registry_FailedToOpen);
            regkey.SetValue(key,value);
            regkey.Close();
        }

        public static List<string> GetKeyNames(string Subkey)
        {
            var reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($"Software\\Genshin_Checker\\{Subkey}");

            if (reg == null) throw new IOException(Localize.Error_Registry_FailedToOpen);
            string[] arySubKeyNames = reg.GetValueNames();
            reg.Close();
            return new(arySubKeyNames);
        }

        /// <summary>
        /// 文字列からBASE64に圧縮する
        /// </summary>
        /// <param name="raw">変換したい文字列</param>
        /// <returns>圧縮済みのBASE64文字列</returns>
        static string Base64FromStringComp(string raw)
        {
            byte[] source = Encoding.UTF8.GetBytes(raw);
            MemoryStream ms = new();
            DeflateStream CompressedStream = new(ms, CompressionMode.Compress, true);
            CompressedStream.Write(source, 0, source.Length);
            CompressedStream.Close();
            return System.Convert.ToBase64String(ms.ToArray(), Base64FormattingOptions.InsertLineBreaks);
        }
        /// <summary>
        /// Base64から元の文字列に復元する
        /// </summary>
        /// <param name="compressed">圧縮済みのBASE64文字列</param>
        /// <returns>解凍済みの文字列</returns>
        static string StringFromBase64Comp(string compressed)
        {
            using MemoryStream ms = new();
            using DeflateStream CompressedStream = new(new MemoryStream(System.Convert.FromBase64String(compressed)), CompressionMode.Decompress);
            byte[] buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = CompressedStream.Read(buffer, 0, buffer.Length)) > 0)
                ms.Write(buffer, 0, bytesRead);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }
}
