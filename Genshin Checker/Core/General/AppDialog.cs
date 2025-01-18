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
        public static void Error(string title,string message)
        {
            var dialog = new ErrorMessage(title, message);
            dialog.ShowDialog();
        }
    }
}
