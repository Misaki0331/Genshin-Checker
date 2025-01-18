using Genshin_Checker.GUI.Window.PopupWindow;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker
{
    public static class Dialog
    {
        public static void Error(string title,string message, string? windowName = null)
        {
            var dialog = new ErrorMessage(title, message, windowName);
            dialog.ShowDialog();
        }
        public static void Info(string title,string message,string? windowName = null)
        {
            var dialog = new InfoMessage(title, message, windowName);
            dialog.ShowDialog();
        }
        public static int Choose(string title, string message, List<string> choose)
        {
            if (choose.Count < 2)
            {
                throw new ArgumentException("The argments needs 2+ args.");
            }
            List<string?> selectedChoices = new(5);
            for (int i = 0; i < 5; i++)
            {
                selectedChoices[i] = i < choose.Count ? choose[i] : null;
            }
            var dialog = new ChooseMessage(title, message, selectcount:choose.Count, 
                select1:selectedChoices[0],
                select2:selectedChoices[1],
                select3:selectedChoices[2],
                select4:selectedChoices[3],
                select5:selectedChoices[4]
                );
            dialog.ShowDialog();
            return dialog.Result;
        }
    }
}
