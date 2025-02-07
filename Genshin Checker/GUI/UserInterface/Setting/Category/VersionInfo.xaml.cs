using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using UserControl = System.Windows.Controls.UserControl;

namespace Genshin_Checker.GUI.UserInterface.Setting.Category
{
    /// <summary>
    /// General.xaml の相互作用ロジック
    /// </summary>
    public partial class VersionInfo : UserControl
    {
        public EventHandler<string>? ErrorHandle;
        public VersionInfo()
        {
            InitializeComponent();
            VersionName.Text = $"Version {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            ProcessStartInfo pi = new()
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true,
            };
            Process.Start(pi);
            e.Handled = true;
        }
    }
}
