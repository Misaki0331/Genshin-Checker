using System.Diagnostics;
using System.IO.Compression;

namespace Genshin_Checker.App.General
{
    public class MovingData
    {
        public static async Task<Exception?> BackupToZip(string path)
        {
            string name = Path.Combine(Path.GetTempPath(),Path.GetRandomFileName().Replace(".",""));
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
                return null;
            }
            catch (Exception ex) 
            {
                Trace.WriteLine(ex);
                if (Directory.Exists(name)) Directory.Delete(name,true);
                return ex;
            }
        }
        public static async Task<Exception?> WriteToApp(string path,bool Recovery=false)
        {
            string name = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName().Replace(".", ""));
            bool IsNeedRecovery = false;
            try
            {
                if (!Recovery)
                {
                    var ex = await BackupToZip(Path.Combine(AppData.AppDataDirectry, "Buckup.old_zip"));
                    if (ex != null)
                    {
                        throw new ArgumentException("Could not create buckup files.", ex);
                    }
                }
                if (!Directory.Exists(name)) Directory.CreateDirectory(name);
                ZipFile.ExtractToDirectory(path, name);
                if (!File.Exists(Path.Combine(name, "Settings"))) throw new FileNotFoundException("Registry data could not be loaded.");
                if (!Directory.Exists(Path.Combine(name, "UserData"))) throw new FileNotFoundException("User data could not be loaded.");
                var sr = new StreamReader(Path.Combine(name, "Settings"));
                var json = await sr.ReadToEndAsync();
                sr.Close();

                if(!JsonChecker<List<Registry.RegistryJson>>.IsValid(json))throw new InvalidDataException("json is invalid");
                IsNeedRecovery = true;

                if(Directory.Exists(AppData.UserDataPath))Directory.Delete(AppData.UserDataPath, true);
                Registry.AllClear();
                Directory.CreateDirectory(AppData.UserDataPath);
                foreach (var info in Directory.GetFiles(Path.Combine(name, "UserData")))
                {
                    File.Copy(info, Path.Combine(AppData.UserDataPath, Path.GetFileName(info)));
                }
                Registry.SetJson(json);
                Directory.Delete(name, true);
                return null;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
                if (!Recovery)
                {
                    if (IsNeedRecovery)
                    {
                        Trace.WriteLine("ロールバックします。");
                        var ex2 = await WriteToApp(Path.Combine(AppData.AppDataDirectry, "Buckup.old_zip"), true);
                        if(ex2 != null)
                        {
                            ex = new InvalidDataException($"リカバリに失敗しました。{ex2.GetType()}{ex2.Message}", ex);
                        }
                    }
                }

                if (Directory.Exists(name)) Directory.Delete(name, true);
                return ex;
            }
            
        }
    }
}
