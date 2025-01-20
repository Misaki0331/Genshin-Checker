using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
using Color = System.Windows.Media.Color;

namespace Genshin_Checker.GUI.UserInterface.Component
{
    /// <summary>
    /// CategoryLabel.xaml の相互作用ロジック
    /// </summary>
    public partial class CategoryLabel : System.Windows.Controls.UserControl
    {
        public string Text
        {
            get { return LabelText.Text; }
            set { LabelText.Text=value; }
        }
        private bool _isHover = false;
        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SelectChanged(value); }
        }
        public event EventHandler? Click;
        public bool IsHover
        {
            get { return _isHover; }
            private set { HoverChanged(value); }
        }
        public CategoryLabel()
        {
            InitializeComponent(); 
        }
        private void SelectChanged(bool IsSelect)
        {
            Border1.Background = new SolidColorBrush(Color.FromArgb((byte)(IsSelect ? 0xFF : 0x00), 0x4E, 0x7C, 0xFF));
            LabelText.Foreground = new SolidColorBrush((IsSelect ? Colors.White : (IsHover ? Colors.White : Colors.Gray)));
            _isSelected = IsSelect;
        }
        private void HoverChanged(bool IsHover)
        {
            LabelText.Foreground = new SolidColorBrush((IsSelected ? Colors.White : (IsHover ? Colors.White : Colors.Gray)));
            _isHover = IsHover;
        }



        private void CursorEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsHover = true;
        }

        private void CursorLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            IsHover = false;
        }
        private void Clicked(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Click?.Invoke(this, e);
        }
    }
}
