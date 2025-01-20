using Genshin_Checker.Core.General;
using Genshin_Checker.GUI.Window.PopupWindow;
using Genshin_Checker.resource.Languages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Application = System.Windows.Forms.Application;

namespace Genshin_Checker.GUI.Pages.Setting
{
    /// <summary>
    /// General.xaml の相互作用ロジック
    /// </summary>
    public partial class AppData : Page
    {
        public EventHandler<string>? ErrorHandle;
        public AppData()
        {
            InitializeComponent();
        }

        private async void ClickBackup(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} Backup File(*.gscbu)|*.gscbu";
            sfd.FilterIndex = 1;
            sfd.Title = ManageUserData.SaveBackup_SaveTo_Title;
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = false;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var result = await MovingData.BackupToZip(sfd.FileName);
                if (result == null)
                    Dialog.Info(ManageUserData.SaveBackup_Success_Title, ManageUserData.SaveBackup_Success_Message);
                else
                    Dialog.Error(ManageUserData.SaveBackup_Failed_Title, result.ToString());
            }
        }
        private void ClickOverwrite(object sender, RoutedEventArgs e)
        {
            var message = new ChooseMessage(ManageUserData.LoadBackup_Notice_Title, ManageUserData.LoadBackup_Notice_Message, selectcount: 2);
            message.ShowDialog();
            if (message.Result != 1) return;
            OpenFileDialog sfd = new();
            sfd.Filter = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} Backup File(*.gscbu)|*.gscbu";
            sfd.FilterIndex = 1;
            sfd.Title = ManageUserData.LoadBackup_LoadTo_Title;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                message = new ChooseMessage(ManageUserData.LoadBackup_FinalConfirm_Title, ManageUserData.LoadBackup_FinalConfirm_Message, selectcount: 2);
                message.ShowDialog();
                if (message.Result != 1) return;
                Process.Start(Application.ExecutablePath, new List<string>() { $"-Override", $"Path:{sfd.FileName}" });
                Application.Exit();
            }
        }
        private void ClickClear(object sender, RoutedEventArgs e)
        {
            var message = new ChooseMessage(ManageUserData.Delete_Notice_Title, ManageUserData.Delete_Notice_Message, selectcount: 2);
            message.ShowDialog();
            if (message.Result != 1) return;
            message = new ChooseMessage(ManageUserData.Delete_Confirm_Title, ManageUserData.Delete_Confirm_Message, selectcount: 2);
            message.ShowDialog();
            if (message.Result != 1) return;

            Process.Start(Application.ExecutablePath, new List<string>() { $"-ALLDELETE" });
            Application.Exit();
        }
    }
}
