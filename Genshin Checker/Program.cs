using Genshin_Checker.Window;
using System.Linq.Expressions;
using Genshin_Checker.Window.Popup;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Globalization;
using Genshin_Checker.resource.Languages;

namespace Genshin_Checker
{
    internal static class Program
    {
        static System.Threading.Mutex? mutex = null;
        static bool HasHandle = false;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if !DEBUG
            //ThreadExceptionイベントハンドラを追加
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(
                    Application_ThreadException);
#endif
            //言語設定
            if (CultureInfo.CurrentCulture.Name == "ja-JP"|| CultureInfo.CurrentCulture.Name == "ja")
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja-JP");
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ja-JP");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            bool ToastActivated = false;
            bool Override = false;
            string path = "";
            //トースト通知の引数が含まれる場合は通知を削除
            foreach (string cmd in Environment.GetCommandLineArgs())
            {
                switch (cmd)
                {
                    case "-ToastActivated":
                        ToastActivated= true;
                        break;
                    case "-Override":
                        Override = true; 
                        break;
                }
                if (cmd.StartsWith("Path:")){
                    path = cmd[5..];
                }
            }
            if (ToastActivated)
            {
                ToastNotificationManagerCompat.History.Clear();
                return;
            }
            if (Override)
            {
                var a = App.General.MovingData.WriteToApp(path).Result;
                string result;
                if (a != null) result = $"{a.GetType()} - {a.Message}\n{a}";
                else result = $"引継ぎが完了しました。";
                System.Diagnostics.Process.Start(Application.ExecutablePath,new List<string>() {$"Result:{result}"});
                return;
            }

            //Mutex名を決める（必ずアプリケーション固有の文字列に変更すること！）
            string mutexName = "Genshin Checker";
            //Mutexオブジェクトを作成する
            mutex = new System.Threading.Mutex(false, mutexName);
            HasHandle = false;
            try
            {
                try
                {
                    //ミューテックスの所有権を要求する
                    HasHandle = mutex.WaitOne(0, false);
                }
                //.NET Framework 2.0以降の場合
                catch (System.Threading.AbandonedMutexException)
                {
                    //別のアプリケーションがミューテックスを解放しないで終了した時
                    HasHandle = true;
                }
#if !DEBUG
                //ミューテックスを得られたか調べる
                if (!HasHandle)
                {
                    //得られなかった場合は、すでに起動していると判断して終了
                    var args = "";
                    foreach (var a in System.Environment.GetCommandLineArgs()) args += $"{a} ";
                    MessageBox.Show(string.Format(Localize.Error_Program_MultipleLaunched,args), "Genshin Checker", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
#endif

                //はじめからMainメソッドにあったコードを実行
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new MainTray(safemode: !HasHandle));
            }
            finally
            {
                try
                {
                    if (HasHandle)
                    {
                        //ミューテックスを解放する
                        mutex.ReleaseMutex();
                    }
                    mutex.Close();
                }
                catch { }
            }
        }
        //ThreadExceptionイベントハンドラ
        private static void Application_ThreadException(object sender,
            ThreadExceptionEventArgs e)
        {
            try
            {
                if (HasHandle) mutex?.ReleaseMutex();
                mutex?.Close();
            }
            catch{}
            try
            {
                new FatalError(e.Exception).ShowDialog();
            }
            catch
            {
                //エラーメッセージを表示する
                var res = MessageBox.Show(string.Format(Common.ApplicationErrorTrace, e.Exception.GetType(), e.Exception.Message, e), Common.ApplicationError, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (res == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
            finally
            {
                //アプリケーションを終了する
                Application.Exit();
            }
        }
    }
}