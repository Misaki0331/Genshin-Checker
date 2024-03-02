using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genshin_Checker.DirectX.DLL;

namespace Genshin_Checker.DirectX
{
    /// <summary>
    /// メッセージループ処理クラス
    /// </summary>
    internal class ClarityLoop
    {
        private ClarityLoop()
        {

        }

        /// <summary>
        /// 実行関数
        /// </summary>
        /// <param name="con">管理Control</param>
        /// <param name="ac">コールバックアクション</param>
        public static void Run(Control con, Action ac)
        {
            bool loopflag = true;

            //削除時の終了通知
            con.Disposed += (con, sender) => {
                loopflag = false;
            };

            con.Show();

            //メッセージループ処理
            while (loopflag)
            {
                //溜まっている全てのメッセージを処理
                tagMSG msg;
                while (User32.PeekMessage(out msg, IntPtr.Zero, 0, 0, User32.PM_REMOVE) == WinDef.TRUE)
                {
                    User32.TranslateMessage(ref msg);
                    User32.DispatchMessage(ref msg);

                    //WM_QUITはvortice WM_NCDESTROYはSharpDXで受けている
                    //ひとまず両方で受けることに
                    if (msg.message == WindowsMessageCode.WM_QUIT || msg.message == WindowsMessageCode.WM_NCDESTROY)
                    {
                        loopflag = false;
                        break;
                    }
                }

                //処理
                ac();
            }
        }

    }
}
