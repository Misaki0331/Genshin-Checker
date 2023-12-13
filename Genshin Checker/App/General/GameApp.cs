using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General
{
    public static class GameApp
    {
        public static async Task<string?> WhereGameDir()
        {
            string PATH = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\\AppData\\LocalLow\\miHoYo\\Genshin Impact";
            const string FILENAME = "output_log.txt";
            FileStream fs = new($"{PATH}/{FILENAME}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try
            {
                byte[] bytes = new byte[65536];
                await fs.ReadAsync(bytes, 0, bytes.Length);
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
                Trace.WriteLine($"Error! {ex.Message}");
            }
            finally
            {
                fs.Close();
            }
            return null;
        }
        public static async Task<string?> WhereScreenShotPath()
        {
            var str = await WhereGameDir();
            if (str == null) return null;
            var path = Path.Combine(str, "..", "ScreenShot");
            path = Path.GetFullPath(path);
            if (Directory.Exists(path)) return path;
            else return null;
        }
    }
}
