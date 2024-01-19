﻿using Genshin_Checker.App.Game;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Window;

namespace Genshin_Checker.App.General
{
    public static class ManageWindow
    {
        static readonly List<Form> FormList = new();
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
        public static void OpenWindow(Account? account, string name)
        {
            string Name = $"{(account != null ? account.UID : "null")},{name}";
            var delete = FormList.Find(a => a.Name == Name && a.IsDisposed);
            if (delete != null) FormList.Remove(delete);
            var find = FormList.Find(a => a.Name == Name);
            bool IsAdd = find == null;
            if (account == null)
            {
                if (find == null || find.IsDisposed)
                    switch (name)
                    {
                        case nameof(GameLog):
                            find = new GameLog(GameLogWatcher.Instance.GameLog) { Name = Name };
                            break;
                        case nameof(TimerDisplay):
                            find = new TimerDisplay() { Name = Name };
                            break;
                        case nameof(TimeGraph):
                            find = new TimeGraph() { Name = Name };
                            break;
                        case nameof(SettingWindow):
                            find = new SettingWindow() { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.Debug.APIChecker):
                            find = new Genshin_Checker.Window.Debug.APIChecker() { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.Debug.Console):
                            find = new Genshin_Checker.Window.Debug.Console() { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.ProgressWindow.LoadGameDatabase):
                            find = new Genshin_Checker.Window.ProgressWindow.LoadGameDatabase() { Name = Name };
                            break;
                    }
            }
            else
            {
                if (find == null || find.IsDisposed)
                    switch (name)
                    {
                        case nameof(Genshin_Checker.Window.GameRecords):
                            find = new Genshin_Checker.Window.GameRecords(account) { Name = Name };
                            break;
                        case nameof(RealTimeData):
                            find = new RealTimeData(account) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.TravelersDiary):
                            find = new Genshin_Checker.Window.TravelersDiary(account) { Name = Name };
                            break;
                        case nameof(TravelersDiaryDetailList):
                            find = new TravelersDiaryDetailList(account) { Name = Name };
                            break;
                        case nameof(CharacterCalculator):
                            find = new CharacterCalculator(account) { Name = Name };
                            break;
                        case nameof(BrowserApp.WebGameAnnounce):
                            find = new BrowserApp.WebGameAnnounce(account) { Name = Name };
                            break;
                        case nameof(Genshin_Checker.Window.SpiralAbyss):
                            find = new Genshin_Checker.Window.SpiralAbyss(account) { Name = Name };
                            break;
                    }
            }
            if (find == null) return;
            if (IsAdd) FormList.Add(find);
            find.Show();
            if (find.WindowState == FormWindowState.Minimized) find.WindowState = FormWindowState.Normal;
            find.Activate();
        }
    }
}
