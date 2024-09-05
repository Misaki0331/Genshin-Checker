using Genshin_Checker.App.General;
using Genshin_Checker.resource.Languages;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Text;

namespace Genshin_Checker.App
{
    public class Registry
    {
#if DEBUG
        const string PathName = $"Software\\Genshin_Checker.DEBUG";
#else
        const string PathName = $"Software\\Genshin_Checker";
#endif
        /// <summary>
        /// 書き込みを禁止するか
        /// </summary>
        public static bool IsReadOnly { get; set; } = false;
        /// <summary>
        /// レジストリから値を取得
        /// </summary>
        /// <param name="Subkey">サブキー</param>
        /// <param name="key">キー</param>
        /// <param name="compress">圧縮されているか</param>
        /// <returns>値</returns>
        /// <exception cref="IOException">レジストリを開くことに失敗</exception>
        public static string? GetValue(string Subkey, string key, bool compress = false)
        {
#if DEBUG 
            compress = false;
#endif
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($"{PathName}\\{Subkey}");
            if (regkey == null) throw new IOException(Localize.Error_Registry_FailedToOpen);
            var val = regkey.GetValue(key);
            regkey.Close();
            if (val == null) return null;
            string res = $"{val}";
            if (compress)
                res = StringFromBase64Comp(res);
            return res;
        }
        /// <summary>
        /// その他のアプリからレジストリを取得
        /// </summary>
        /// <param name="AppName">アプリ名</param>
        /// <param name="Subkey">サブキー</param>
        /// <param name="key">キー</param>
        /// <returns>値</returns>
        /// <exception cref="IOException">レジストリを開くことに失敗</exception>
        public static string? GetAppReg(string AppName, string Subkey, string key)
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
        /// <summary>
        /// レジストリの設定
        /// </summary>
        /// <param name="Subkey">サブキー</param>
        /// <param name="key">キー</param>
        /// <param name="value">設定する値</param>
        /// <param name="compress">圧縮するかどうか</param>
        /// <param name="force">書き込み禁止に関わらず強制的に上書きする</param>
        /// <exception cref="IOException">レジストリを開くことに失敗</exception>
        public static void SetValue(string Subkey, string key, string value, bool compress = false, bool force = false)
        {
#if DEBUG
            var data = value;
            if (value.Length > 100) data = value[..100] + $"...({value.Length})";
            Log.Debug($"{Subkey}:{key} (Compress:{compress}) Value:\"{data}\"");
            compress = false;
#endif
            //if(IsReadOnly&&!force) return;
            if (compress) value = Base64FromStringComp(value);
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($"{PathName}\\{Subkey}");
            if (regkey == null) throw new IOException(Localize.Error_Registry_FailedToOpen);
            regkey.SetValue(key, value);
            regkey.Close();
        }
        /// <summary>
        /// キーの名前一覧を取得
        /// </summary>
        /// <param name="Subkey">サブキー</param>
        /// <returns>キー名のList型</returns>
        /// <exception cref="IOException">レジストリを開くことに失敗</exception>
        public static List<string> GetKeyNames(string Subkey)
        {
            var reg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($"{PathName}\\{Subkey}");

            if (reg == null) throw new IOException(Localize.Error_Registry_FailedToOpen);
            string[] arySubKeyNames = reg.GetValueNames();
            reg.Close();
            return new(arySubKeyNames);
        }
        /// <summary>
        /// レジストリの情報をJson化
        /// </summary>
        /// <param name="IsWithCredential">認証情報を含めるか</param>
        /// <returns>jsonデータ</returns>
        public static string GetJson(bool IsWithCredential = false)
        {
            List<RegistryJson> data = new();
            GetPath(PathName, data, IsWithCredential);
            return JsonConvert.SerializeObject(data);
        }
        /// <summary>
        /// レジストリをJsonで一括上書き
        /// </summary>
        /// <param name="str">Json</param>
        /// <returns>成功したかどうか</returns>
        public static bool SetJson(string str)
        {
            try
            {
                var data = JsonChecker<List<RegistryJson>>.Check(str);
                var path = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(PathName);
                foreach (var item in data)
                {
                    var sub = path.CreateSubKey(item.Path);
                    sub.SetValue(item.Key, item.Value);
                    Log.Debug($"{item.Path} - {item.Key}:{item.Value}");
                    sub.Close();
                }
                path.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// アプリ内レジストリデータを一括削除
        /// </summary>
        public static void AllClear()
        {
            var sub = Microsoft.Win32.Registry.CurrentUser;
            if (sub.OpenSubKey(PathName) != null)
                sub.DeleteSubKeyTree(PathName);
            sub.Close();
        }
        static void GetPath(string path, List<RegistryJson> data, bool IsWithCredential = false)
        {
            var sub = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(path);
            if (sub == null) return;
            foreach (string valueName in sub.GetValueNames())
            {
                var jsonpath = path.Replace($"{PathName}\\", "");
                if (!IsWithCredential && jsonpath.StartsWith("Config\\UserData")) continue;
                data.Add(new() { Path = jsonpath, Key = valueName, Value = $"{sub.GetValue(valueName)}" });
            }
            foreach (string subkey in sub.GetSubKeyNames())
            {
                GetPath(path + "\\" + subkey, data);
            }
            sub.Close();
        }
        internal class RegistryJson
        {
            public string Path { get; set; } = "";
            public string Key { get; set; } = "";
            public string Value { get; set; } = "";
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
