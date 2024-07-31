using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using Genshin_Checker.App.General;
using System.Reflection;

namespace Genshin_Checker
{
    partial class Log
    {
        LogLevel LOG_LEVEL = 0;

        /// <summary>ログ機能の有効化</summary>
        const bool IS_LOGFILE = true;
        /// <summary>保存先のディレクトリ</summary>
        string LOGDIR_PATH = Path.Combine(AppData.AppDataDirectry, "Logs");
        /// <summary>書き込むログファイル</summary>
        const string LOGFILE_NAME = "console";
        /// <summary>ログファイルの最大容量</summary>
        const long LOGFILE_MAXSIZE = 1024 * 1024 * 1;
        /// <summary>ログ保存期間</summary>
        const int LOGFILE_PERIOD = 90;
        /// <summary>関数名の長さ</summary>
        const int STACKLEN = 24;
        /// <summary>ログの関数の長さ</summary>
        const int METHODNAMELEN = 256;
        List<string> Logdata = new();

        /// <summary>
        /// コンソール画面を表示
        /// </summary>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("kernel32.dll")] // この行を追加
        private static extern bool AllocConsole();                 // この行を追加  
        /// <summary>
        /// コンソール画面を非表示
        /// </summary>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("kernel32.dll")] // この行を追加
        private static extern bool FreeConsole();                 // この行を追加  

        public event EventHandler<LogEventArg>? LogUpdateHandler;

        /// <summary>
        /// 出力ログの変更
        /// </summary>
        /// <param name="level">ログの種類</param>
        public void SetLogLevel(LogLevel level)
        {
            LOG_LEVEL = level;
            Info("Logger", $"ログの出力レベルを{LOG_LEVEL}に変更しました。");
        }

        /// <summary>
        /// 現在の出力ログを取得
        /// </summary>
        public LogLevel GetLogLevel()
        {
            return LOG_LEVEL;
        }



        /// <summary>
        /// ログレベル
        /// </summary>
        public enum LogLevel
        {
            DEBUG,
            INFO,
            WARN,
            ERROR,
            FATAL
        }

        private static Log? singleton = null;
        private readonly string? logFilePath = null;
        private readonly object lockObj = new();
        private readonly object lockListObj = new();
        private StreamWriter? stream = null;

        /// <summary>
        /// インスタンスを生成する
        /// </summary>
        private static Log GetInstance()
        {
            singleton ??= new Log();
            return singleton;
        }
        public static Log Instance { get { return GetInstance(); } }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private Log()
        {
#if DEBUG
            LOGDIR_PATH = Path.Combine(AppData.AppDataDirectry, "Logs.Debug");
            AllocConsole(); 
            var name = Assembly.GetExecutingAssembly().GetName();
            Console.Title = $"Debug Console - {name.Name} {name.Version}";
#endif
            logFilePath = LOGDIR_PATH + LOGFILE_NAME + ".log";
            // ログファイルを生成する
            CreateLogfile(new FileInfo(logFilePath));
        }


        /// <summary>
        /// ERRORレベルのスタックトレースログを出力する
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        public static void Error(Exception ex,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = -1)
        {
            if (LogLevel.ERROR >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.ERROR, ex.Message + Environment.NewLine
                    + $"{callerFilePath} - {callerLineNumber}行目" + Environment.NewLine
                    + $"[{ex.Source}] {ex.GetType()} : {ex.Message}" + Environment.NewLine
                    + ex.StackTrace);
            }
        }

        /// <summary>
        /// ERRORレベルのスタックトレースログを出力する
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        /// <param name="funcName">関数名</param>
        public static void Error(string funcName, Exception ex,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = -1)
        {
            if (LogLevel.ERROR >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.ERROR, ex.Message + Environment.NewLine
                    + $"{callerFilePath} - {callerLineNumber}行目" + Environment.NewLine
                    + $"[{ex.Source}] {ex.GetType()} : {ex.Message}" + Environment.NewLine
                    + ex.StackTrace, $"{funcName}");
            }
        }

        /// <summary>
        /// FATALレベルのスタックトレースログを出力する
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        public static void Fatal(Exception ex,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = -1)
        {
            if (LogLevel.FATAL >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.FATAL, ex.Message + Environment.NewLine
                    + $"{callerFilePath} - {callerLineNumber}行目" + Environment.NewLine
                    + $"[{ex.Source}] {ex.GetType()} : {ex.Message}" + Environment.NewLine
                    + ex.StackTrace);
            }
        }


        /// <summary>
        /// FATALレベルのスタックトレースログを出力する
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        /// <param name="funcName">関数名</param>
        public static void Fatal(string funcName, Exception ex,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = -1)
        {
            if (LogLevel.FATAL >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.FATAL, ex.Message + Environment.NewLine
                    + $"{callerFilePath} - {callerLineNumber}行目" + Environment.NewLine
                    + $"[{ex.Source}] {ex.GetType()} : {ex.Message}" + Environment.NewLine
                    + ex.StackTrace, $"{funcName}");
            }
        }

        /// <summary>
        /// FATALレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>

        public static void Fatal(string msg)
        {
            if (LogLevel.FATAL >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.FATAL, msg);
            }
        }

        /// <summary>
        /// FATALレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="funcName">関数名</param>
        public static void Fatal(string funcName, string msg)
        {
            if (LogLevel.FATAL >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.FATAL, msg, $"{funcName}");
            }
        }


        /// <summary>
        /// ERRORレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public static void Error(string msg)
        {

            if (LogLevel.ERROR >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.ERROR, msg);
            }
        }

        /// <summary>
        /// ERRORレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public static void Error(string funcName, string msg)
        {
            if (LogLevel.ERROR >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.ERROR, msg, $"{funcName}");
            }
        }

        /// <summary>
        /// WARNレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public static void Warn(string msg)
        {
            if (LogLevel.WARN >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.WARN, msg);
            }
        }

        /// <summary>
        /// WARNレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="funcName">関数名</param>
        public static void Warn(string funcName, string msg)
        {
            if (LogLevel.WARN >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.WARN, msg, $"{funcName}");
            }
        }

        /// <summary>
        /// INFOレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public static void Info(string msg)
        {
            if (LogLevel.INFO >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.INFO, msg);
            }
        }
        /// <summary>
        /// INFOレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="funcName">関数名</param>
        public static void Info(string funcName, string msg)
        {
            if (LogLevel.INFO >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.INFO, msg, $"{funcName}");
            }
        }

        /// <summary>
        /// DEBUGレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public static void Debug(string msg)
        {
            if (LogLevel.DEBUG >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.DEBUG, msg);
            }
        }
        /// <summary>
        /// DEBUGレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="funcName">関数名</param>
        public static void Debug(string funcName, string msg)
        {
            if (LogLevel.DEBUG >= Instance.LOG_LEVEL)
            {
                Instance.Out(LogLevel.DEBUG, msg, $"{funcName}");
            }
        }

        private static string FormatFunctionString(string? input)
        {
            if (input == null) return "";
            // 正規表現パターンを定義
            string pattern = @"^(.+?)\+\<(.+?)\>d__\d+$";
            // 正規表現オブジェクトを作成
            Regex regex = new Regex(pattern);

            // マッチオブジェクトを取得
            Match match = regex.Match(input);
            if (match.Success)
            {
                // マッチした場合、新しい形式に変換
                string className = match.Groups[1].Value;
                string methodName = match.Groups[2].Value;
                return $"{className}.{methodName}";
            }

            // マッチしなかった場合はそのまま返す
            return input;
        }


        /// <summary>
        /// ログを出力する
        /// </summary>
        /// <param name="level">ログレベル</param>
        /// <param name="msg">メッセージ</param>
        private void Out(LogLevel level, string msg, string? from = null)
        {
            string strMethodName = "";
            bool IsFunction = false;
            if (!string.IsNullOrEmpty(from)) strMethodName = from;
            else
            {
                for (int nFrame = 2; ; nFrame++)
                {
#pragma warning disable CS8602 // null 参照の可能性があるものの逆参照です。
                    StackFrame? objStackFrame = new(nFrame);
                    if (objStackFrame == null) break;
                    if (objStackFrame.GetMethod() == null) break;
                    if (string.IsNullOrWhiteSpace(strMethodName))
                    {
                        IsFunction = true;
                        switch (objStackFrame.GetMethod().Name)
                        {
                            case "MoveNext": strMethodName = "()"; break;
                            case ".ctor": strMethodName = "<constructor>"; break;
                        }
                    }
                    if (objStackFrame.GetMethod().ReflectedType == null) break;
                    strMethodName = $"{FormatFunctionString(objStackFrame.GetMethod().ReflectedType.FullName)}{(IsFunction?"":".")}{strMethodName}";
                    IsFunction = false;
                    if (objStackFrame.GetMethod().ReflectedType.FullName.Contains("Genshin_Checker")) break;
                    if (objStackFrame.GetMethod().ReflectedType.FullName.Contains("System")) break;
#pragma warning restore CS8602 // null 参照の可能性があるものの逆参照です。

                }
                // 呼び出し元のメソッド名を取得する
                if (string.IsNullOrEmpty(strMethodName)) strMethodName = "Undefined";
            }
            int tid = Environment.CurrentManagedThreadId;
            string para = strMethodName;
            if (para.Length > STACKLEN)
            {
                para = para.Substring(para.Length - (STACKLEN - 2), STACKLEN - 2);
                para = ".." + para;
            }
            else
            {
                para = para.PadLeft(STACKLEN);
            }
            string logs = $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}][{tid,5}][{level,-5}] [{para}]:";
            string trace = msg.Replace("\n", "\n" + "".PadLeft(logs.Length, ' '));
            logs += trace;
            if (level == LogLevel.DEBUG) System.Diagnostics.Debug.WriteLine(logs);
            else Trace.WriteLine(logs);
            var strings = logs.Replace("\r", "");
            var splitstrings = strings.Split('\n');
            switch (level)
            {
                case LogLevel.DEBUG:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.INFO:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.WARN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case LogLevel.FATAL:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
            }
            logs = $"[{DateTime.Now:HH:mm:ss.fff}][{tid,5}][{level,-5}] [{para}]:";
            trace = msg.Replace("\n", "\n" + "".PadLeft(logs.Length, ' '));
            logs += trace;
            Console.WriteLine(logs);
            string addtext = "";
            lock (lockListObj)
            {
                for (int i = 0; i < splitstrings.Length; i++)
                {
                    if (i != 0) addtext += "\n";
                    addtext += splitstrings[i];
                    Logdata.Add(splitstrings[i]);
                }
                while (Logdata.Count > 100)
                {
                    Logdata.RemoveAt(0);
                }
            }
            if (IS_LOGFILE)
            {
                msg = msg.Replace("\n", "\n\t");
                var method = strMethodName;
                string fullMsg = $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}][{tid,5}][{level,-5}] [{strMethodName}]: {msg}";
                /*if (METHODNAMELEN < strMethodName.Length && METHODNAMELEN > 0)
                {
                    fullMsg = $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}][{tid,5}][{level,-5}] [..{strMethodName.Substring(strMethodName.Length-1-METHODNAMELEN)}]: {msg}";
                }*/


                lock (lockObj)
                {

                    stream?.WriteLine(fullMsg);
                    if (string.IsNullOrEmpty(logFilePath)) return;

                    FileInfo logFile = new(logFilePath);
                    if (LOGFILE_MAXSIZE < logFile.Length)
                    {
                        // ログファイルを圧縮する
                        CompressLogFile();

                        // 古いログファイルを削除する
                        DeleteOldLogFile();
                    }
                }
            }
            try
            {
                //イベントの発生
                LogUpdateHandler?.Invoke(null, new(level, msg, addtext));
            }
            catch { }
        }

        /// <summary>
        /// ログのString出力
        /// </summary>
        public string GetLogData()
        {
            lock (lockListObj)
            {
                return string.Join("\n", Logdata);
            }
        }
        /// <summary>
        /// ログファイルを生成する
        /// </summary>
        /// <param name="logFile">ファイル情報</param>
        private void CreateLogfile(FileInfo logFile)
        {
            if (!Directory.Exists(logFile.DirectoryName) && logFile.DirectoryName != null)
            {
                Directory.CreateDirectory(logFile.DirectoryName);
            }

            stream = new StreamWriter(logFile.FullName, true, Encoding.UTF8)
            {
                AutoFlush = true
            };
        }

        /// <summary>
        /// ログファイルを圧縮する
        /// </summary>
        private void CompressLogFile()
        {
            if (stream != null) stream.Close();
            string oldFilePath = LOGDIR_PATH + LOGFILE_NAME + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (logFilePath != null) File.Move(logFilePath, oldFilePath + ".log");

            FileStream inStream = new(oldFilePath + ".log", FileMode.Open, FileAccess.Read);
            FileStream outStream = new(oldFilePath + ".gz", FileMode.Create, FileAccess.Write);
            GZipStream gzStream = new(outStream, CompressionMode.Compress);

            int size;
            byte[] buffer = new byte[LOGFILE_MAXSIZE + 1000];
            while (0 < (size = inStream.Read(buffer, 0, buffer.Length)))
            {
                gzStream.Write(buffer, 0, size);
            }

            inStream.Close();
            gzStream.Close();
            outStream.Close();

            File.Delete(oldFilePath + ".log");
            if (logFilePath != null) CreateLogfile(new FileInfo(logFilePath));
        }

        /// <summary>
        /// 古いログファイルを削除する
        /// </summary>
        private static void DeleteOldLogFile()
        {
            Regex regex = new(LOGFILE_NAME + @"_(\d{14}).*\.gz");
            DateTime retentionDate = DateTime.Today.AddDays(-LOGFILE_PERIOD);
            string[] filePathList = Directory.GetFiles(GetInstance().LOGDIR_PATH, LOGFILE_NAME + "_*.gz", SearchOption.TopDirectoryOnly);
            foreach (string filePath in filePathList)
            {
                Match match = regex.Match(filePath);
                if (match.Success)
                {
                    DateTime logCreatedDate = DateTime.ParseExact(match.Groups[1].Value.ToString(), "yyyyMMddHHmmss", null);
                    if (logCreatedDate < retentionDate)
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }
        public class LogEventArg
        {
            public LogEventArg(LogLevel lv, string raw, string viewlog)
            {
                LogLevel = lv;
                RawLogData = raw;
                ViewLogData = viewlog;
            }
            public LogLevel LogLevel;
            public string RawLogData;
            public string ViewLogData;
        }
    }
}