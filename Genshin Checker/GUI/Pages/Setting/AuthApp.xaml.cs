using Genshin_Checker.GUI.UserInterface.Setting;
using Genshin_Checker.GUI.Window.WebApp;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Genshin_Checker.GUI.Pages.Setting
{
    /// <summary>
    /// General.xaml の相互作用ロジック
    /// </summary>
    public partial class AuthApp : Page
    {
        public EventHandler<string>? ErrorHandle;
        public AuthApp()
        {
            InitializeComponent();
        }
        private void ReloadAccountList()
        {
            AccountListPanel.Children.Clear();
            NoAccountTextBlock.Visibility = Store.Accounts.Data.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
            foreach (var account in Store.Accounts.Data)
            {
                var a = new AccountInfo(account);
                a.AccountRemoveRequest += AccountRemoveRequest;
                AccountListPanel.Children.Add(a);
            }
        }

        private void AccountRemoveRequest(object? sender, EventArgs e)
        {
            ReloadAccountList();
        }

        private void ContentLoaded(object sender, RoutedEventArgs e)
        {
            ReloadAccountList();
        }

        private async void Auth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new BattleAuth(isAutoAuth: false); 
                System.Windows.Window parentWindow = System.Windows.Window.GetWindow(this);

                if (parentWindow != null)
                {
                    dialog.ShowDialog(new Wpf32Window(parentWindow));
                }

            }
            catch (Exception)
            {

            }
            await Task.Delay(1000);
            ReloadAccountList();
        }
    }
    public class Wpf32Window : System.Windows.Forms.IWin32Window
    {
        public IntPtr Handle { get; private set; }

        public Wpf32Window(System.Windows.Window window)
        {
            this.Handle = new WindowInteropHelper(window).Handle;
        }
    }
}
