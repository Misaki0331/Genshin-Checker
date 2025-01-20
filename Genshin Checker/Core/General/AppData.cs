using System.IO;
using System.IO.Compression;
using System.Text;

namespace Genshin_Checker.Core.General
{
    internal class AppData
    {
        /// <summary>
        /// アプリディレクトリ
        /// </summary>
        public static string AppDataDirectry { get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Genshin Checker"); }
        /// <summary>
        /// ユーザーデータディレクトリ
        /// </summary>
        public static string UserDataPath { get => Path.Combine(AppDataDirectry, UserDataDirectry); }
#if DEBUG
        const string UserDataDirectry = "UserData.DEBUG";
#else
        const string UserDataDirectry = "UserData";
#endif
        /// <summary>
        /// ランダムなファイル名を取得
        /// </summary>
        /// <returns></returns>
        public static string GetRandomPath()
        {
            return $"{Path.GetRandomFileName().Replace(".", "")}.misaki_gsc"; //水咲原神チェッカー
        }
        /// <summary>
        /// ユーザーデータにファイルが存在するか
        /// </summary>
        /// <param name="path">ランダム化されたファイル名</param>
        /// <returns>存在するか</returns>
        public static bool IsExistFile(string path)
        {
            return File.Exists(Path.Combine(UserDataPath, path));
        }
        /// <summary>
        /// データをロードする
        /// </summary>
        /// <param name="path">ランダム化されたファイル名</param>
        /// <param name="compress">圧縮済みの場合はチェック必須</param>
        /// <param name="ReturnException">例外が発生した場合は処理を停止するか</param>
        /// <returns>データ</returns>
        public static async Task<string?> LoadUserData(string path, bool compress = true, bool ReturnException = true)
        {
#if DEBUG
            compress = false;
#endif
            try
            {
                if (!Path.IsPathRooted(path)) path = Path.Combine(UserDataPath, path);
                if (!File.Exists(path)) throw new FileNotFoundException(path);
                if (compress)
                {
                    using FileStream stream = new(path, FileMode.Open);
                    using GZipStream zipStream = new(stream, CompressionMode.Decompress);
                    using StreamReader reader = new(zipStream);
                    return reader.ReadToEnd();
                }
                else
                {
                    var sr = new StreamReader(path);
                    var data = await sr.ReadToEndAsync();
                    sr.Close();
                    if (compress) data = StringFromBase64Comp(data);
                    return data;
                }
            }
            catch (Exception ex)
            {
                if (ReturnException) throw;
                Log.Error(ex);
                return null;
            }
        }
        /// <summary>
        /// データをセーブする
        /// </summary>
        /// <param name="path">ランダム化されたファイル名</param>
        /// <param name="data">データ</param>
        /// <param name="compress">圧縮するかどうか</param>
        /// <returns>成功したかどうか</returns>
        public static async Task<bool> SaveUserData(string path, string data, bool compress = true)
        {
#if DEBUG
            compress = false;
#endif
            try
            {
                Log.Debug($"SAVEFILE : {path}");
                if (!Path.IsPathRooted(path)) path = Path.Combine(UserDataPath, path);
                if (!Path.IsPathRooted(path)) Path.Combine(UserDataPath, path);
                var directory = Path.GetDirectoryName(path);
                if (directory != null && !Directory.Exists(directory)) Directory.CreateDirectory(directory);
                if (compress)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(data);
                    using FileStream stream = new(path, FileMode.Create);
                    using GZipStream zipStream = new(stream, CompressionMode.Compress);
                    zipStream.Write(buffer, 0, buffer.Length);
                    zipStream.Close();
                }
                else
                {
                    var sr = new StreamWriter(path);
                    if (compress) data = Base64FromStringComp(data);
                    await sr.WriteAsync(data);
                    sr.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return false;
            }
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
