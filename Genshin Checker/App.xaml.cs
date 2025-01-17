using Genshin_Checker.Core.Game;
using Genshin_Checker.Core.General;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Store;
using Genshin_Checker.Window.Popup;
using System.Windows;
using System.Windows.Forms;
using static Genshin_Checker.Core.HoYoLab.Account;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Genshin_Checker.Core
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class AppMain : System.Windows.Application
    {
        static System.Threading.Mutex? mutex = null;
        static bool HasHandle = false;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
#if !DEBUG
            //ThreadExceptionイベントハンドラを追加
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(
                    Application_ThreadException);
#endif
            LocalizeManager.SetLanguage();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            bool ToastActivated = false;
            bool Override = false;
            bool Alldelete = false;
            string path = "";
            //トースト通知の引数が含まれる場合は通知を削除
            foreach (string cmd in Environment.GetCommandLineArgs())
            {
                switch (cmd)
                {
                    case "-ToastActivated":
                        ToastActivated = true;
                        break;
                    case "-Override":
                        Override = true;
                        break;
                    case "-ALLDELETE":
                        Alldelete = true;
                        break;
                }
                if (cmd.StartsWith("Path:"))
                {
                    path = cmd[5..];
                }
            }
            if (ToastActivated)
            {
                Core.General.CommandLineFunction.AllToastClear();
                return;
            }
            if (Override)
            {
                Core.General.CommandLineFunction.Override(path);
                return;
            }
            if (Alldelete)
            {
                Core.General.CommandLineFunction.AllDelete();
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

            /*
            Log.Debug("スタートアップしました。");
            var icon = ResourceManager.GetStream("icon.ico");
            _notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Visible = true,
                Icon = new System.Drawing.Icon(icon),
                Text = "タスクトレイ常駐アプリのテストです"
            };

            _notifyIcon.ShowBalloonTip(3000,"test","This is test",ToolTipIcon.Info);*/
        }
        private static void Application_ThreadException(object sender,
            ThreadExceptionEventArgs e)
        {
            Log.Fatal("Oops! Application was crashed...");
            Log.Fatal(e.Exception);
            try
            {
                if (HasHandle) mutex?.ReleaseMutex();
                mutex?.Close();
            }
            catch { }
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
