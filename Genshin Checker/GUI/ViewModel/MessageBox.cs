// InfoMessageViewModel.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Genshin_Checker.ViewModel
{
    public class MessageBoxViewModel : INotifyPropertyChanged
    {
        private string _messageTitle = "メッセージタイトル";
        private string _messageDetail = "詳細なメッセージ";
        private string _windowTitle = "ウィンドウタイトル";
        private string _button1Text = "OK";
        private string _button2Text = "ボタン2";
        private string _button3Text = "";
        private string _button4Text = "";
        private string _button5Text = "";

        public string MessageTitle
        {
            get => _messageTitle;
            set
            {
                _messageTitle = value;
                OnPropertyChanged();
            }
        }

        public string MessageDetail
        {
            get => _messageDetail;
            set
            {
                _messageDetail = value;
                OnPropertyChanged();
            }
        }
        public string WindowTitle
        {
            get => _windowTitle;
            set
            {
                _windowTitle = value;
                OnPropertyChanged();
            }
        }

        public string Button1Text
        {
            get => _button1Text;
            set
            {
                _button1Text = value;
                OnPropertyChanged();
            }
        }

        public string Button2Text
        {
            get => _button2Text;
            set
            {
                _button2Text = value;
                OnPropertyChanged();
            }
        }

        public string Button3Text
        {
            get => _button3Text;
            set
            {
                _button3Text = value;
                OnPropertyChanged();
            }
        }

        public string Button4Text
        {
            get => _button4Text;
            set
            {
                _button4Text = value;
                OnPropertyChanged();
            }
        }

        public string Button5Text
        {
            get => _button5Text;
            set
            {
                _button5Text = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
