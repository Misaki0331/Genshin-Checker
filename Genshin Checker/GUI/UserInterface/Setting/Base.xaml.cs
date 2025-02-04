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
using TabControl = System.Windows.Controls.TabControl;

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
            CategoryGeneral.ErrorHandle += new EventHandler<string>((sender, e) => ChildErrorHandle(sender, e));
            CategoryAuthApp.ChangedAccountList += ChangedAccountList;
            //PageFrame.Navigate(next);
        }


        private void CategoryClick(object sender, EventArgs e)
        {

        }

        private void ChangedAccountList(object? sender, EventArgs e)
        {
            CategoryNotification.LoadConfig();
            CategoryHoYoLabConfig.LoadConfig();
        }
        private void ChildErrorHandle(object? sender, string e)
        {
            ErrorMessage.MessageQueue?.Clear();
            ErrorMessage.MessageQueue?.Enqueue(e);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
