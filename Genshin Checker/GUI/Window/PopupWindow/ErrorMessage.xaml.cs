using Genshin_Checker.resource.Languages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Genshin_Checker.GUI.Window.PopupWindow;

/// <summary>
/// ErrorMessage.xaml の相互作用ロジック
/// </summary>
public partial class ErrorMessage : System.Windows.Window
{
    public ErrorMessage(string title, string message, string? windowtitle = null)
    {
        InitializeComponent();
        windowtitle ??= Common.ErrorMessage;
        DataContext = new ViewModel.MessageBoxViewModel()
        {
            MessageTitle = title,
            MessageDetail = message.Replace("\r\n", "\n").Replace("\n", Environment.NewLine),
            WindowTitle = windowtitle
        };
        //Picture.Source = ResourceManager.GetBitmapImage("Paimon's Paint/Furina 2.png");
    }

    private void ButtonClicked(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
