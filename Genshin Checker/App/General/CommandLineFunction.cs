using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Popup;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General
{
    public class CommandLineFunction
    {
        public static void AllToastClear()
        {
            ToastNotificationManagerCompat.History.Clear(); 
            Environment.Exit(0);
        }
        public static void Override(string path)
        {
            var a = App.General.MovingData.WriteToApp(path).Result;
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
        public static void AllDelete()
        {
            var a = new ChooseMessage(ManageUserData.FinalConfirm_Title, ManageUserData.FinalConfirm_Message, selectcount: 2, select1: Common.No, select2: Common.Yes);
            a.ShowDialog();
            if (a.Result == 1)
            {
                try
                {
                    App.General.MovingData.AllClear();
                    new InfoMessage(ManageUserData.Complete_DeletedData_Title, ManageUserData.Complete_DeletedData_Message).ShowDialog();
                }
                catch (Exception e)
                {
                    new ErrorMessage(ManageUserData.Error_DeletedData_Title, e.ToString()).ShowDialog();
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
