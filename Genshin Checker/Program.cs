namespace Genshin_Checker
{
    internal static class Program
    {
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Mutex名を決める（必ずアプリケーション固有の文字列に変更すること！）
            string mutexName = "Genshin Checker";
            //Mutexオブジェクトを作成する
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, mutexName);
            bool hasHandle = false;
            try
            {
                try
                {
                    //ミューテックスの所有権を要求する
                    hasHandle = mutex.WaitOne(0, false);
                }
                //.NET Framework 2.0以降の場合
                catch (System.Threading.AbandonedMutexException)
                {
                    //別のアプリケーションがミューテックスを解放しないで終了した時
                    hasHandle = true;
                }
                //ミューテックスを得られたか調べる
                if (hasHandle == false)
                {
                    //得られなかった場合は、すでに起動していると判断して終了
                    MessageBox.Show("多重起動はできません。","Genshin Checker",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                //はじめからMainメソッドにあったコードを実行
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                Application.Run(new MainTray());
            }
            finally
            {
                if (hasHandle)
                {
                    //ミューテックスを解放する
                    mutex.ReleaseMutex();
                }
                mutex.Close();
            }
        }
        //ThreadExceptionイベントハンドラ
        private static void Application_ThreadException(object sender,
            System.Threading.ThreadExceptionEventArgs e)
        {
            try
            {
                //エラーメッセージを表示する
                var res=MessageBox.Show($"アプリケーションエラーが発生しました。\n再起動しますか？\n\n--- デバッグ情報 ---\n{e.Exception.GetType()}\n{e.Exception.Message}\n--- StackTrace ---\n{e.Exception.StackTrace}\n--- StackTrace 終わり ---", "Genshin Checker アプリケーションエラー",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
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