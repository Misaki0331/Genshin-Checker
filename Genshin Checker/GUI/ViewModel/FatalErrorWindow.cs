// InfoMessageViewModel.cs
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Genshin_Checker.ViewModel
{
    public class FatalErrorViewModel : INotifyPropertyChanged
    {
        private string _errorTitle = "Oops! Application was crashed...";
        private string _messageTitle = "ぬるぽ";
        private string _messageDetail = "詳細なメッセージ";
        private string _windowTitle = "Error!";
        private string _buttonExit = "Exit";
        private string _buttonRestart = "Restart";
        private string _buttonOpenCrashReport = "Open crash report";
        private string _buttonUpdate = "Update Application";

        public string ErrorTitle
        {
            get => _errorTitle;
            set
            {
                _errorTitle = value;
                OnPropertyChanged();
            }
        }
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

        public string ButtonExit
        {
            get => _buttonExit;
            set
            {
                _buttonExit = value;
                OnPropertyChanged();
            }
        }

        public string ButtonRestart
        {
            get => _buttonRestart;
            set
            {
                _buttonRestart = value;
                OnPropertyChanged();
            }
        }

        public string ButtonOpenCrashReport
        {
            get => _buttonOpenCrashReport;
            set
            {
                _buttonOpenCrashReport = value;
                OnPropertyChanged();
            }
        }

        public string ButtonUpdate
        {
            get => _buttonUpdate;
            set
            {
                _buttonUpdate = value;
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
