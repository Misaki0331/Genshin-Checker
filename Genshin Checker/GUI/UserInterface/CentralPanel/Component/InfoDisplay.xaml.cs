using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using UserControl = System.Windows.Controls.UserControl;
using System.ComponentModel;

namespace Genshin_Checker.GUI.UserInterface.CentralPanel.Component
{
    /// <summary>
    /// InfoDisplay.xaml の相互作用ロジック
    /// </summary>
    public partial class InfoDisplay : UserControl
    {
        public InfoDisplay()
        {
            InitializeComponent();

        }

        // アイコン関連のDependencyProperty
        public static readonly DependencyProperty IconKindProperty =
            DependencyProperty.Register("IconKind", typeof(PackIconKind), typeof(InfoDisplay), new PropertyMetadata(PackIconKind.None));

        public PackIconKind IconKind
        {
            get { return (PackIconKind)GetValue(IconKindProperty); }
            set { SetValue(IconKindProperty, value); }
        }

        public static readonly DependencyProperty IconImageSourceProperty =
            DependencyProperty.Register("IconImageSource", typeof(ImageSource), typeof(InfoDisplay), new PropertyMetadata(null));

        public ImageSource IconImageSource
        {
            get { return (ImageSource)GetValue(IconImageSourceProperty); }
            set { SetValue(IconImageSourceProperty, value); }
        }

        // その他のプロパティ
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(InfoDisplay), new PropertyMetadata(""));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(InfoDisplay), new PropertyMetadata(""));

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty UnitProperty =
            DependencyProperty.Register("Unit", typeof(string), typeof(InfoDisplay), new PropertyMetadata(""));

        public string Unit
        {
            get { return (string)GetValue(UnitProperty); }
            set { SetValue(UnitProperty, value); }
        }


        public static readonly DependencyProperty LeftUnitProperty =
            DependencyProperty.Register("LeftUnit", typeof(string), typeof(InfoDisplay), new PropertyMetadata(""));

        public string LeftUnit
        {
            get { return (string)GetValue(LeftUnitProperty); }
            set { SetValue(LeftUnitProperty, value); }
        }

        public static readonly DependencyProperty SmallInfoProperty =
            DependencyProperty.Register("SmallInfo", typeof(string), typeof(InfoDisplay), new PropertyMetadata(""));

        public string SmallInfo
        {
            get { return (string)GetValue(SmallInfoProperty); }
            set { SetValue(SmallInfoProperty, value);
                OnPropertyChanged("SmallInfo");
            }
        }

        public bool IsSmallInfoVisible
        {
            get { return SmallInfo.Length>0; }
        }

        public static readonly DependencyProperty ToolTipProperty =
            DependencyProperty.Register("ToolTip", typeof(string), typeof(InfoDisplay), new PropertyMetadata(""));

        public string ToolTip
        {
            get { return (string)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Nullチェック用のコンバーター
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    // アイコンと画像の表示を制御するコンバーター
    public class IconVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var iconKind = values[0] as PackIconKind?;
            var iconImageSource = values[1] as ImageSource;
            string? target = parameter as string;

            if (target == "PackIcon")
            {
                if (iconImageSource != null)
                {
                    return Visibility.Collapsed;
                }
                else if (iconKind != null && iconKind != PackIconKind.None)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            else if (target == "Image")
            {
                return iconImageSource != null ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // テキストが空かどうかを判定
            if (string.IsNullOrEmpty(value as string))
            {
                return Visibility.Collapsed; // テキストが空なら非表示
            }
            return Visibility.Visible; // テキストがあれば表示
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}