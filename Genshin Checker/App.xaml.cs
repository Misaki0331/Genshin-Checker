using Genshin_Checker.Core.Game;
using Genshin_Checker.Core.General;
using Genshin_Checker.Store;
using System.Windows;
using System.Windows.Forms;
using static Genshin_Checker.Core.HoYoLab.Account;

namespace Genshin_Checker.Core
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class AppMain : System.Windows.Application
    {
        private NotifyIcon? _notifyIcon;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            /*Task.WaitAll(
               Task.Run(async () => await EnkaData.Data.GetStoreData()),
               Task.Run(async () => await Misaki_chan.Data.GetStoreData())
               );*/
            Core.Game.GameLogWatcher.Instance.Init();
            //Core.Game.LauncherLogWatcher.Instance.Init();
            //Core.Game.ScreenshotWatcher.Instance.NewImageEvent += ScreenshotEvent;


            new GUI.Window.CentralPanel().ShowDialog();
            /*
            Log.Debug("スタートアップしました。");
            var icon = ResourceManager.GetStream("icon.ico");
            _notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                Visible = true,
                Icon = new System.Drawing.Icon(icon),
                Text = "タスクトレイ常駐アプリのテストです"
            };

            _notifyIcon.ShowBalloonTip(3000,"test","This is test",ToolTipIcon.Info);*/
        }

    }

}
