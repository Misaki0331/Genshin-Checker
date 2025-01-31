using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using Genshin_Checker.GUI.UserInterface.Component;

namespace Genshin_Checker.GUI.UserInterface.Setting
{
    /// <summary>
    /// Base.xaml の相互作用ロジック
    /// </summary>
    public partial class Base : System.Windows.Controls.UserControl
    {
        public Base()
        {
            InitializeComponent();

            //var next = new Pages.Setting.General();
            //next.ErrorHandle += new EventHandler<string>((sender, e) => ChildErrorHandle(sender, e));
            //PageFrame.Navigate(next);
        }


        private void CategoryClick(object sender, EventArgs e)
        {
            /*var Categories = new Dictionary<CategoryLabel, Type>() {
                { Category_General, typeof(Pages.Setting.General) },
                {Category_Notification,typeof(Pages.Setting.Notification)},
                {Category_AuthApp,typeof(Pages.Setting.AuthApp)},
                {Category_HoYoLabConfig,typeof(Pages.Setting.HoYoLabConfig)},
                {Category_AppData,typeof(Pages.Setting.AppData)},
                { Category_VersionInfo,typeof(Pages.Setting.VersionInfo) }
            if (sender is not CategoryLabel category) return;
            var pagetype = Categories[category];
            if (pagetype == null) return;
            category.IsSelected = true;
            foreach(var label in Categories)
                label.Key.IsSelected = label.Key == category;
            var next = (dynamic?)Activator.CreateInstance(pagetype);
            if (next != null)
            {
                next.ErrorHandle += new EventHandler<string>((sender, e) => ChildErrorHandle(sender,e));
                PageFrame.Navigate(next);
            }
            if (!(!PageFrame.CanGoBack && !PageFrame.CanGoForward))
            {
                var entry = PageFrame.RemoveBackEntry();
                while (entry != null)
                    entry = PageFrame.RemoveBackEntry();
            }
            };*/
        }

        private void ChildErrorHandle(object? sender, string e)
        {
            //ErrorMessage.MessageQueue?.Clear();
            //ErrorMessage.MessageQueue?.Enqueue(e);
        }
    }
}
