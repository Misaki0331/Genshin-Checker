using Genshin_Checker.Core;
using Genshin_Checker.Core.General;
using Genshin_Checker.resource.Languages;
using System.Windows;
using System.Windows.Controls;
using Brushes = System.Windows.Media.Brushes;
using CheckBox = System.Windows.Controls.CheckBox;

namespace Genshin_Checker.GUI.Pages.Setting
{
    /// <summary>
    /// General.xaml の相互作用ロジック
    /// </summary>
    public partial class General : Page
    {
        public EventHandler<string>? ErrorHandle;
        private List<string> ScreenshotFileExtension;
        private readonly bool IsLoadedConfig = false;

        public General()
        {
            InitializeComponent();
            ScreenshotFileExtension = [".png", ".jpg", ".tiff"];
            foreach (var file in ScreenshotFileExtension)
                ComboBoxScreenshotExtension.Items.Add(file);
            LoadConfig();
            IsLoadedConfig = true;
        }

        private void LoadConfig()
        {
            CheckBoxTimerWithBackGround.IsChecked = !Option.Instance.Application.TimerOnlyActiveWindow;
            TextBoxAppScreenshotPath.Text = Option.Instance.ScreenShot.RaisePath;
            CheckBoxScreenshotRaise.IsChecked = Option.Instance.ScreenShot.IsRaise;
            TextBoxOutScreenshotPath.Text = Option.Instance.ScreenShot.SaveFilePath;
            TextBoxScreenshotFormat.Text = Option.Instance.ScreenShot.SaveFileFormat;
            CheckBoxScreenshotNotify.IsChecked = Option.Instance.ScreenShot.IsNotify;
            CheckBoxScreenshotAfterDelete.IsChecked = Option.Instance.ScreenShot.IsSaveAfterDelete;
            ComboBoxScreenshotExtension.SelectedIndex = ScreenshotFileExtension.FindIndex(a => a == Option.Instance.ScreenShot.SaveFileFormatType);
        }


        private void ChangedCheckState(object sender, RoutedEventArgs e)
        {
            if (sender is not CheckBox check) return;
            ValidCheck(check);
            ChangeState(check);
            if(IsLoadedConfig) Option.Save();
        }

        private void ValidCheck(CheckBox check)
        {
            check.IsChecked ??= false;
            try
            {
                if (check == CheckBoxScreenshotRaise) 
                    Core.Game.ScreenshotWatcher.Instance.IsRaise = (bool)check.IsChecked;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                check.IsChecked = !check.IsChecked;
                ErrorHandle?.Invoke(this,ex.Message);
                //new ErrorMessage(Localize.WindowName_SettingWindow_FailedToChangeConfig, $"{ex.Message}").ShowDialog();
            }
        }
        private void ChangeState(CheckBox check)
        {
            bool state = check.IsChecked ?? false;
            if (check == CheckBoxTimerWithBackGround)
                Option.Instance.Application.TimerOnlyActiveWindow = !state;
            if (check == CheckBoxScreenshotRaise)
                Option.Instance.ScreenShot.IsRaise = state;
            if (check == CheckBoxScreenshotAfterDelete)
                Option.Instance.ScreenShot.IsSaveAfterDelete = state;
            if (check == CheckBoxScreenshotNotify)
                Option.Instance.ScreenShot.IsNotify = state;
        }

        /// <summary>
        /// スクリーンショット「自動設定」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonAutoScreenshotPath(object sender, EventArgs e)
        {
            var str = await GameApp.WhereScreenShotPath();
            if (str == null)
            {
                ErrorHandle?.Invoke(this, Localize.WindowName_SettingWindow_FailedToGetScreenshotPath_Message);
                return;
            }
            TextBoxAppScreenshotPath.Text = str;
            Core.Game.ScreenshotWatcher.Instance.Path = str;
            Option.Instance.ScreenShot.RaisePath = str;
            Option.Save();
        }
        /// <summary>
        /// 保存先のファイルパス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonScreenshotOutPathChooseDirectry(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog()
            {
                Description = Localize.WindowName_SettingWindow_Transfer_Description,
            };
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Option.Instance.ScreenShot.SaveFilePath = fbd.SelectedPath;
            TextBoxOutScreenshotPath.Text = fbd.SelectedPath;
            Option.Save();
        }
        /// <summary>
        /// スクリーンショットのフォーマット
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ScreenShotTransferFileFormat_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!IsLoadedConfig) return;
            var format = TextBoxScreenshotFormat.Text;
            var result = await Core.General.ScreenShot.SetFileFormat(format);
            if (!string.IsNullOrEmpty(result))
            {
                ErrorHandle?.Invoke(this, result);
                TextBoxScreenshotFormat.Background = Brushes.LightPink;
            }
            else
            {
                TextBoxScreenshotFormat.Background = Brushes.White;
                Option.Save();
            }
        }

        private void ComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsLoadedConfig)
            {
                Option.Instance.ScreenShot.SaveFileFormatType = $"{ComboBoxScreenshotExtension.SelectedItem}";
                Option.Save();
            }
        }
    }
}
