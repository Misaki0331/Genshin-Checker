using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Genshin_Checker.App.General
{
    public class MovingData
    {
        public static async Task<bool> BackupToZip(string path)
        {
            string name = Path.Combine(Path.GetTempPath(),Path.GetRandomFileName());
            try
            {
                if (!Directory.Exists(name)) Directory.CreateDirectory(name);
                Directory.CreateDirectory(Path.Combine(name, "UserData"));
                foreach (var info in Directory.GetFiles(AppData.UserDataPath))
                {
                    File.Copy(info, Path.Combine(name, "UserData", Path.GetFileName(info)));
                }
                var sr = new StreamWriter(Path.Combine(name,"Settings"));
                await sr.WriteAsync(Registry.GetJson());
                sr.Close();
                if(File.Exists(path)) File.Delete(path);
                ZipFile.CreateFromDirectory(name+"\\", path);
                Directory.Delete(name, true);
                return true;
            }
            catch
            {
                if (Directory.Exists(name)) Directory.Delete(name,true);
                return false;
            }
        }
    }
}
