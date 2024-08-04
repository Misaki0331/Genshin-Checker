using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Genshin_Checker.App.General
{
    public static class GameApp
    {
        /// <summary>
        /// ゲーム本体のディレクトリの取得
        /// </summary>
        /// <returns>成功した場合はパスが返ってくる</returns>
        public static async Task<string?> WhereGameDir()
        {
            string PATH = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\AppData\\LocalLow\\miHoYo\\Genshin Impact";
            const string FILENAME = "output_log.txt";
            FileStream? fs = null;
            try
            {
                fs = new($"{PATH}/{FILENAME}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                byte[] bytes = new byte[65536];
                await fs.ReadAsync(bytes);
                var res = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                if (res != null)
                {
                    var a = Regex.Matches(res + "\r\n", @"(?m).:/.+(GenshinImpact_Data|YuanShen_Data)", RegexOptions.Multiline);
                    var result = Regex.Match(a[0].Value, @"(.:/.+(GenshinImpact_Data|YuanShen_Data))", RegexOptions.Multiline);
                    return result.ToString();
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Log.Error($"Error! {ex.Message}");
            }
            finally
            {
                fs?.Dispose();
            }
            return null;
        }
        /// <summary>
        /// ゲーム内Webキャッシュファイルの取得
        /// </summary>
        /// <returns>成功した場合はパスが返ってくる</returns>
        public static async Task<string?> WhereWebCacheFilePath()
        {
            var gamedir = await WhereGameDir();
            if (gamedir == null) return null;
            var webcaches = Path.Combine(gamedir, "webCaches");
            var folders = new DirectoryInfo(webcaches).GetDirectories().OrderBy(f => f.LastWriteTime).Last();
            var path = Path.Combine(folders.FullName, "Cache", "Cache_Data", "data_2");
            if (!File.Exists(path)) return null;
            return path;
        }
        /// <summary>
        /// スクリーンショットのディレクトリを取得
        /// </summary>
        /// <returns>成功した場合はパスが返ってくる</returns>
        public static async Task<string?> WhereScreenShotPath()
        {
            var str = await WhereGameDir();
            if (str == null) return null;
            var path = Path.Combine(str, "..", "ScreenShot");
            path = Path.GetFullPath(path);
            if (Directory.Exists(path)) return path;
            else return null;
        }
        /// <summary>
        /// ゲーム内のUIDを取得(再起動するまで値は変わらない)
        /// </summary>
        /// <returns>UID</returns>
        public static async Task<string?> CurrentUID()
        {
            string PATH = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\AppData\\LocalLow\\miHoYo\\Genshin Impact";
            const string FILENAME = "UidInfo.txt";
            StreamReader? fs = null;
            try
            {
                fs = new($"{PATH}/{FILENAME}", new FileStreamOptions() { Mode = FileMode.Open, Access = FileAccess.Read, Share = FileShare.ReadWrite });
                var uid = await fs.ReadToEndAsync();
                uid = uid.Trim();
                return uid;
            }
            catch (Exception ex)
            {
                Log.Error($"Error! {ex.Message}");
            }
            finally
            {
                fs?.Dispose();
            }
            return null;
        }
    }
}
