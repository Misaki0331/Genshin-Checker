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
using System.Windows.Shapes;

namespace Genshin_Checker.GUI.Window
{
    /// <summary>
    /// SettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : System.Windows.Window
    {
        public SettingWindow()
        {
            InitializeComponent();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(this);
        }
    }
}
