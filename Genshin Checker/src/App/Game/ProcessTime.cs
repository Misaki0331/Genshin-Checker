using Genshin_Checker.App.General;
using Genshin_Checker.App.Window;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Genshin_Checker.App.Game
{
    public class ProcessTime
    {
        /// <summary>定期的に実行するタイマー</summary>
        readonly System.Timers.Timer checker;
        /// <summary>合計起動時間</summary>
        TimeSpan LatestTotalSessionTime;
        /// <summary>セッション中のストップウォッチ</summary>
        readonly Stopwatch SessionTime;
        long LatestCheckedDateTime = 0;
        public readonly ProcessTimeOption option;
        /// <summary>該当プロセスが実行中であるかどうか</summary>
        Process? TargetProcess;

        private readonly object lockObject = new(); //ロック処理に必要
        public event EventHandler<Result>? SessionEnd;
        public event EventHandler<Result>? ChangedState;
        public event EventHandler? SessionStart;
        WindowInfo? WindowInfo;
        public ProcessState CurrentProcessState { get; private set; }
        public TimeSpan Session { get => SessionTime.Elapsed; }
        public TimeSpan TotalSession { get => SessionTime.Elapsed + LatestTotalSessionTime; }
        private ProcessTime()
        {
            checker = new System.Timers.Timer
            {
                Interval = 500
            };
            checker.Elapsed += (s, e) => { WatchDogElapsed(e.SignalTime); };
            SessionTime = new();
            CurrentProcessState = ProcessState.NotRunning;
            TargetProcess = null;
            option = new ProcessTimeOption();

            LatestTotalSessionTime = new(SessionCheck.Instance.Load());
        }
        static ProcessTime? instance = null;
        public static ProcessTime Instance { get => instance ??= new ProcessTime(); }
        /// <summary>プロセスをチェックするフラグ</summary>
        public static bool WatchDog { get => Instance.checker.Enabled; set => Instance.checker.Enabled = value; }
        /// <summary>プロセスをチェックする頻度 (単位 ms)</summary>
        public static double WatchDogInterval { get => Instance.checker.Interval; set => Instance.checker.Interval = value; }
        /// <summary> 【内部関数】プロセスチェック用の関数</summary>
        /// <param name="SignalTime"></param>
        void WatchDogElapsed(DateTime signalTime)
        {
            var state = ProcessSearch();
            if (state != CurrentProcessState)
            {
                if (CurrentProcessState == ProcessState.NotRunning)
                {
                    LatestTotalSessionTime += SessionTime.Elapsed;
                    SessionTime.Reset();
                    SessionStart?.Invoke(null, EventArgs.Empty);
                }
                switch (state)
                {
                    case ProcessState.NotRunning:
                        SessionTime.Stop();
                        SessionCheck.Instance.Append(SessionTime.Elapsed.Ticks);
                        SessionEnd?.Invoke(null, new(SessionTime.Elapsed, state));
                        break;
                    case ProcessState.Foreground:
                        SessionTime.Start();
                        break;
                    case ProcessState.Background:
                        if (Option.Instance.Application.TimerOnlyActiveWindow)
                            SessionTime.Stop();
                        else SessionTime.Start();
                        break;

                }
                CurrentProcessState = state;
                ChangedState?.Invoke(null, new(SessionTime.Elapsed, state));
            }
            lock (lockObject)
            {
                var a = new DateTimeOffset(DateTime.UtcNow.Ticks, TimeSpan.Zero).ToUnixTimeSeconds();
                if (LatestCheckedDateTime != a)
                {
                    string ps = " ";
                    switch (CurrentProcessState)
                    {
                        case ProcessState.EmptyState:
                            ps = " ";
                            break;
                        case ProcessState.NotRunning:
                            ps = "_";
                            break;
                        case ProcessState.Background:
                            ps = "B";
                            break;
                        case ProcessState.Foreground:
                            ps = "F";
                            break;

                    }
                    TimeTable.SavePoint(DateTime.UtcNow, ps);
                    LatestCheckedDateTime = a;
                }
            }
        }
        /// <summary>
        /// 緊急シャットダウン用関数。進捗を保存しリセットする
        /// </summary>
        public void EmergencyReset()
        {
            if (CurrentProcessState != ProcessState.NotRunning)
            {
                SessionCheck.Instance.Append(Session.Ticks);
                SessionTime.Reset();
                if (CurrentProcessState == ProcessState.Foreground)
                    SessionTime.Start();
            }
        }
        /// <summary>【内部関数】特定プロセスの起動チェック</summary>
        /// <returns>特定プロセスが起動済みか</returns>
        public ProcessState ProcessSearch()
        {
            if (WindowInfo != null)
            {
                if (WindowInfo.Reload())
                {
                    if (WindowInfo.IsCurrentWindow) return ProcessState.Foreground;
                    else return ProcessState.Background;
                }
                else
                {
                    WindowInfo = null;

                    WatchDogInterval = option.ProcessDetectInterval;
                }
            }
            var processes = Process.GetProcesses();
            foreach (var p in processes)
                if (p.ProcessName == "GenshinImpact")
                {
                    Instance.TargetProcess = p;
                    WindowInfo window = new(p.MainWindowHandle);
                    if (!window.Reload()) continue;
                    if (window.WindowClassName != "UnityWndClass") continue;
                    WindowInfo = window;
                    WatchDogInterval = option.WindowDetectInterval;
                    if (window.IsCurrentWindow) return ProcessState.Foreground;
                    else return ProcessState.Background;
                }
            return ProcessState.NotRunning;
        }
        public enum ProcessState
        {
            /// <summary>本アプリ自体が起動していない状態</summary>
            EmptyState,
            /// <summary>未起動</summary>
            NotRunning,
            /// <summary>ユーザーが作業中</summary>
            Foreground,
            /// <summary>バックグラウンドで起動中</summary>
            Background,
        }
        public class Result : EventArgs
        {
            public Result(TimeSpan span, ProcessState state)
            {
                SessionTime = span;
                State = state;
            }
            public TimeSpan SessionTime { get; }
            public ProcessState State { get; }
        }
    }
    public class ProcessTimeOption
    {
        /// <summary>
        /// プロセス検索頻度
        /// </summary>
        public int ProcessDetectInterval = 500;
        /// <summary>
        /// ウィンドウ検出時の検出頻度
        /// </summary>
        public int WindowDetectInterval = 10;
    }

}
namespace Genshin_Checker.App.Window
{
    public class WindowInfo
    {
        IntPtr Hwnd;
        public WindowInfo(IntPtr hwnd)
        {
            WindowTitle = "";
            WindowClassName = "";
            titlebar = null;
            Hwnd = hwnd;
        }
        //Rect取得用
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public override string ToString()
            {
                return $"横:{right - left:0000}, 縦:{bottom - top:0000}  ({left}, {top}, {right}, {bottom})";
            }
        }

        public delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);

        [DllImport("user32.dll")]
        internal static extern bool GetTitleBarInfo(IntPtr hWnd, ref TITLEBARINFO pti);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool EnumWindows(EnumWindowsDelegate lpEnumFunc,
        IntPtr lparam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd,
            StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetClassName(IntPtr hWnd,
            StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        public struct TITLEBARINFO
        {
            public int cbSize;
            public RECT rcTitleBar;
            public TitleBarButtonStates rgState;
        }
        public enum TitleState
        {
            STATE_SYSTEM_UNAVAILABLE = 1,
            STATE_SYSTEM_PRESSED = 8,
            STATE_SYSTEM_INVISIBLE = 32768,
            STATE_SYSTEM_OFFSCREEN = 65536,
            STATE_SYSTEM_FOCUSABLE = 1048576,
            STATE_SYSTEM_INVISIBLE_AND_FOCUSABLE = 0x00108000,
        }
        public struct TitleBarButtonStates
        {
            public TitleState TitleBarState;
            public TitleState Reseved;
            public TitleState MinState;
            public TitleState MaxState;
            public TitleState HelpState;
            public TitleState CloseState;
        }

        TITLEBARINFO? titlebar;
        public string WindowTitle { get; private set; }
        public string WindowClassName { get; private set; }
        public Point? WindowPos { get => titlebar != null ? new(titlebar.Value.rcTitleBar.left, titlebar.Value.rcTitleBar.top) : null; }
        public Size? WindowSize { get => titlebar != null ? new(titlebar.Value.rcTitleBar.right - titlebar.Value.rcTitleBar.left, titlebar.Value.rcTitleBar.bottom - titlebar.Value.rcTitleBar.top) : null; }
        public bool IsCurrentWindow { get => GetForegroundWindow() == Hwnd; }
        public bool Reload()
        {
            return GetWindow(Hwnd);
        }
        public bool GetWindow(IntPtr hwnd)
        {
            Hwnd = hwnd;
            var info = new TITLEBARINFO();
            info.cbSize = Marshal.SizeOf(info);
            var isSuccess = GetTitleBarInfo(hwnd, ref info);
            if (!isSuccess)
            {
                titlebar = null;
                return false;
            }
            titlebar = info;
            int textLen = GetWindowTextLength(hwnd);
            if (0 < textLen)
            {
                //ウィンドウのタイトルを取得する
                StringBuilder tsb = new(textLen + 1);
                GetWindowText(hwnd, tsb, tsb.Capacity);

                //ウィンドウのクラス名を取得する
                StringBuilder csb = new(256);
                GetClassName(hwnd, csb, csb.Capacity);

                WindowClassName = csb.ToString();
                WindowTitle = tsb.ToString();
            }
            return true;
        }
    }
}