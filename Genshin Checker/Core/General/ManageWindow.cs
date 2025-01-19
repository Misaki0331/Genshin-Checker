using Genshin_Checker.Core.Game;
using Genshin_Checker.Core.HoYoLab;
using Genshin_Checker.GUI.BrowserApp;
using Genshin_Checker.Window;
using System.Windows;

namespace Genshin_Checker.Core.General
{
    public static class ManageWindow
    {
        public class WindowData
        {
            private Form? _form { get; set; }
            private System.Windows.Window? _window { get; set; }
            public bool IsWPF { get; private set; }
            public WindowData(Form form)
            {
                _form = form;
                IsWPF = false;
            }
            public WindowData(System.Windows.Window window)
            {
                _window = window;
                IsWPF = true;
            }
            public void Show()
            {
                _form?.Show();
                _window?.Show();
            }
            public void Activate()
            {
                _form?.Activate();
                _window?.Activate();
            }
            public void Close()
            {
                _form?.Close();
                _window?.Close();
            }
            public string Name { get; set; } = "";
            public WindowState WindowState
            {
                get
                {
                    if (IsWPF) return _window?.WindowState ?? WindowState.Normal;
                    return (WindowState)(_form?.WindowState ?? FormWindowState.Normal);
                }
                set
                {
                    if (_window != null) _window.WindowState = value;
                    else if (_form != null) _form.WindowState = (FormWindowState)value;
                }
            }
            public bool IsDisposed
            {
                get
                {
                    return ((!_window?.IsLoaded) ?? true) && (_form?.IsDisposed ?? true);
                }
            }

        }
        static readonly List<WindowData> FormList = new();
        /// <summary>
        /// 該当アカウントのウィンドウを削除する
        /// </summary>
        /// <param name="account"></param>
        public static void CloseDiposedAccount(Account account)
        {
            var find = FormList.FindAll(a => a.Name.StartsWith($"{account.UID}"));
            foreach (var window in find)
            {
                try
                {
                    if (!window.IsDisposed) window.Close();
                    FormList.Remove(window);
                }
                catch { }
            }
        }
        /// <summary>
        /// ウィンドウを表示、あるいはアクティベートする
        /// </summary>
        /// <param name="account">アカウント</param>
        /// <param name="name">種類</param>
        public static WindowData OpenWindow(Account? account, string name)
        {
            string Name = $"{(account != null ? account.UID : "null")},{name}";
            FormList.RemoveAll(a=> a.IsDisposed);
            var find = FormList.Find(a => a.Name == Name);
            bool IsAdd = find == null;
            if (account == null)
            {
                if (find == null || find.IsDisposed)
                    switch (name)
                    {
                        case nameof(GameLog):
                            find = new(new GameLog(GameLogWatcher.Instance.GameLog)) { Name = Name };
                            break;
                        case nameof(TimerDisplay):
                            find = new(new TimerDisplay()) { Name = Name };
                            break;
                        case nameof(TimeGraph):
                            find = new(new TimeGraph()) { Name = Name };
                            break;
                        case nameof(GUI.Window.SettingWindow):
                            find = new(new GUI.Window.SettingWindow()) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.Debug.APIChecker):
                            find = new(new Genshin_Checker.Window.Debug.APIChecker()) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.Debug.Console):
                            find = new(new Genshin_Checker.Window.Debug.Console()) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.ProgressWindow.LoadGameDatabase):
                            find = new(new Genshin_Checker.Window.ProgressWindow.LoadGameDatabase()) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.CodeExchange):
                            find = new(new Genshin_Checker.Window.CodeExchange()) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.MusicPlayer):
                            find = new(new Genshin_Checker.Window.MusicPlayer()) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.GUI.Window.HoYoContentViewer):
                            find = new(new Genshin_Checker.GUI.Window.HoYoContentViewer()) { Name = Name };
                            break;
                    }
            }
            else
            {
                if (find == null || find.IsDisposed)
                    switch (name)
                    {
                        case nameof(Genshin_Checker.Window.GameRecords):
                            find = new(new Genshin_Checker.Window.GameRecords(account)) { Name = Name };
                            break;
                        case nameof(RealTimeData):
                            find = new(new RealTimeData(account)) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.TravelersDiary):
                            find = new(new Genshin_Checker.Window.TravelersDiary(account)) { Name = Name };
                            break;
                        case nameof(TravelersDiaryDetailList):
                            find = new(new TravelersDiaryDetailList(account)) { Name = Name };
                            break;
                        case nameof(CharacterCalculator):
                            find = new(new CharacterCalculator(account)) { Name = Name };
                            break;
                        case nameof(WebGameAnnounce):
                            find = new(new GUI.BrowserApp.WebGameAnnounce(account)) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.SpiralAbyss):
                            find = new(new Genshin_Checker.Window.SpiralAbyss(account)) { Name = Name };
                            break;
                    }
            }
            if (find == null) throw new ArgumentException($"{Name} is no window names.");
            if (IsAdd) FormList.Add(find);
            if (find.WindowState == WindowState.Minimized) find.WindowState = WindowState.Normal;
            find.Show();
            find.Activate();
            return find;
        }
    }
}
