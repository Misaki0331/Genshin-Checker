﻿using Genshin_Checker.resource.Languages;
using System.IO;
using System.IO.Compression;

namespace Genshin_Checker.Core.General
{
    public class MovingData
    {
        /// <summary>
        /// バックアップ用のファイルを生成する。
        /// </summary>
        /// <param name="path">出力先パス</param>
        /// <param name="IsWithCredential">認証情報を含めるか</param>
        /// <returns>例外エラーが発生したかどうか</returns>
        public static async Task<Exception?> BackupToZip(string path, bool IsWithCredential = false)
        {
            string name = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName().Replace(".", ""));
            try
            {
                if (!Directory.Exists(name)) Directory.CreateDirectory(name);
                Directory.CreateDirectory(Path.Combine(name, "UserData"));
                if (Directory.Exists(Path.Combine(AppData.UserDataPath)))
                {
                    foreach (var info in Directory.GetFiles(AppData.UserDataPath))
                    {
                        File.Copy(info, Path.Combine(name, "UserData", Path.GetFileName(info)));
                    }
                }
                var sr = new StreamWriter(Path.Combine(name, "Settings"));
                await sr.WriteAsync(Registry.GetJson(IsWithCredential));
                sr.Close();
                var dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir) && dir != null) Directory.CreateDirectory(dir);
                if (File.Exists(path)) File.Delete(path);
                ZipFile.CreateFromDirectory(name + "\\", path);
                Directory.Delete(name, true);
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                if (Directory.Exists(name)) Directory.Delete(name, true);
                return ex;
            }
        }
        public static async Task<Exception?> WriteToApp(string path, bool Recovery = false)
        {

            string name = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName().Replace(".", ""));
            bool IsNeedRecovery = false;
            try
            {
                if (!File.Exists(path)) throw new FileNotFoundException("The file is not found.");
                if (!Recovery)
                {
                    var ex = await BackupToZip(Path.Combine(AppData.AppDataDirectry, "Buckup.old_zip"), IsWithCredential: true);
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

                if (!JsonChecker<List<Registry.RegistryJson>>.IsValid(json)) throw new InvalidDataException("json is invalid");
                IsNeedRecovery = true;

                if (Directory.Exists(AppData.UserDataPath)) Directory.Delete(AppData.UserDataPath, true);
                Registry.AllClear();
                Directory.CreateDirectory(AppData.UserDataPath);
                foreach (var info in Directory.GetFiles(Path.Combine(name, "UserData")))
                {
                    File.Copy(info, Path.Combine(AppData.UserDataPath, Path.GetFileName(info)));
                }
                Registry.SetJson(json);
                Directory.Delete(name, true);
                try { File.Delete(Path.Combine(AppData.AppDataDirectry, "Buckup.old_zip")); } catch { }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                if (!Recovery)
                {
                    if (IsNeedRecovery)
                    {
                        Log.Warn("ロールバックします。");
                        var ex2 = await WriteToApp(Path.Combine(AppData.AppDataDirectry, "Buckup.old_zip"), true);
                        if (ex2 != null)
                        {
                            ex = new InvalidDataException($"{ManageUserData.FailedToRecovery}{ex2.GetType()}{ex2.Message}", ex);
                        }
                        try { File.Delete(Path.Combine(AppData.AppDataDirectry, "Buckup.old_zip")); }
                        catch (Exception ex3)
                        {
                            Log.Warn($"バックアップファイルの削除に失敗しました。 {ex3.Message}");
                        }
                    }
                }

                if (Directory.Exists(name)) Directory.Delete(name, true);
                return ex;
            }

        }
        public static bool AllClear()
        {
            if (Directory.Exists(AppData.UserDataPath)) Directory.Delete(AppData.UserDataPath, true);
            Registry.AllClear();
            return true;
        }
    }
}
