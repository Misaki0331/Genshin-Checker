using Genshin_Checker.resource.Languages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Genshin_Checker.GUI.Window.PopupWindow;

/// <summary>
/// ErrorMessage.xaml の相互作用ロジック
/// </summary>
public partial class ChooseMessage : System.Windows.Window
{
    public ChooseMessage(string title, string message, string? windowtitle = null, int selectcount = 2, string? select1 = null, string? select2 = null, string? select3 = null, string? select4 = null, string? select5 = null)
    {
        InitializeComponent();
        windowtitle ??= Common.Confirm;
        Title = windowtitle;
        MessageTitle.Text = title;
        MessageDetail.Text = message.Replace("\r\n", "\n").Replace("\n", Environment.NewLine); 
        Button1.Content = select1 ?? Common.No;
        Button2.Content = select2 ?? Common.Yes;
        Button3.Content = select3 ?? Common.Cancel;
        Button4.Content = select4;
        Button5.Content = select5;
        var buttons = new List<System.Windows.Controls.Button>() { Button1, Button2, Button3, Button4, Button5};
        for (int i = 0; i < buttons.Count; i++)
        {
            if (selectcount > i) buttons[i].Visibility = Visibility.Visible;
            else buttons[i].Visibility = Visibility.Collapsed;
        }
    }
    public int Result = -1;
    private void ButtonClicked1(object sender, RoutedEventArgs e)
    {
        Result = 0;
        Close();
    }
    private void ButtonClicked2(object sender, RoutedEventArgs e)
    {
        Result = 1;
        Close();
    }
    private void ButtonClicked3(object sender, RoutedEventArgs e)
    {
        Result = 2;
        Close();
    }
    private void ButtonClicked4(object sender, RoutedEventArgs e)
    {
        Result = 3;
        Close();
    }
    private void ButtonClicked5(object sender, RoutedEventArgs e)
    {
        Result = 4;
        Close();
    }
}
