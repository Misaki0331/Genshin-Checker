using Genshin_Checker.GUI.Window.PopupWindow;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Popup;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Genshin_Checker.Core.General
{
    public class CommandLineFunction
    {
        /// <summary>
        /// 全てのトースト通知を削除
        /// </summary>
        public static void AllToastClear()
        {
            ToastNotificationManagerCompat.History.Clear();
            Environment.Exit(0);
        }
        /// <summary>
        /// セーブデータの上書き
        /// </summary>
        /// <param name="path">上書きする圧縮データのパス</param>
        public static void Override(string path)
        {
            var a = Core.General.MovingData.WriteToApp(path).Result;
            if (a != null)
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath, new List<string>()
                { $"Style:Error", $"Title:{ManageUserData.Error_Overwrite_Title}", $"Message:{a}" });
                Environment.Exit(0);
            }
            else
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath, new List<string>()
                { $"Style:Info", $"Title:{ManageUserData.Complete_Overwrite_Title}", $"Message:{ManageUserData.Complete_Overwrite_Message}" });
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// セーブデータの削除
        /// </summary>
        public static void AllDelete()
        {
            var a = new GUI.Window.PopupWindow.ChooseMessage(ManageUserData.FinalConfirm_Title, ManageUserData.FinalConfirm_Message, selectcount: 2, select1: Common.No, select2: Common.Yes);
            a.ShowDialog();
            if (a.Result == 1)
            {
                try
                {
                    Core.General.MovingData.AllClear();
                    new InfoMessage(ManageUserData.Complete_DeletedData_Title, ManageUserData.Complete_DeletedData_Message).ShowDialog();
                }
                catch (Exception e)
                {
                    new GUI.Window.PopupWindow.ErrorMessage(ManageUserData.Error_DeletedData_Title, e.ToString()).ShowDialog();
                }
            }
            else
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath, new List<string>() { $"Style:Error", $"Title:{ManageUserData.Cancelled_DeleteData_Title}", $"Message:{ManageUserData.Cancelled_DeleteData_Message}" });
                Environment.Exit(0);
            }
        }
    }
}
