using Genshin_Checker.Core.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using Windows.ApplicationModel.Contacts;
using Windows.Media.Protection.PlayReady;
using CheckBox = System.Windows.Controls.CheckBox;

using UserControl = System.Windows.Controls.UserControl;
namespace Genshin_Checker.GUI.UserInterface.Setting.Category
{
    /// <summary>
    /// General.xaml の相互作用ロジック
    /// </summary>
    public partial class Notification : UserControl
    {
        public EventHandler<string>? ErrorHandle;
        bool IsAccountLoaded;
        public Notification()
        {
            InitializeComponent();
            IsAccountLoaded = false;
            LoadConfig();

        }
        private void LoadConfig()
        {
            CheckBoxGameStart.IsChecked = Option.Instance.Notification.IsGameStart;
            CheckBoxGameExit.IsChecked = Option.Instance.Notification.IsGameEnd;

            if (Store.Accounts.Data.Count == 0)
            {
                TextAccountInfo.Text = "連携しているアカウントがありません。";
                ComboBoxAccount.IsEnabled = false;

                CheckBoxNoteCoinMax.IsEnabled = false;
                CheckBoxNoteCoinThreshold.IsEnabled = false;
                CheckBoxNoteExpedition.IsEnabled = false;
                CheckBoxNoteResinMax.IsEnabled = false;
                CheckBoxNoteResinThreshold.IsEnabled = false;
                CheckBoxNoteTransform.IsEnabled = false;
                SliderNoteCoinThreshold.IsEnabled = false;
                SliderNoteResinThreshold.IsEnabled = false;
                TextNoteCoinThreshold.Text = "---";
                TextNoteResinThreshold.Text = "---";
            }
            else
            {
                foreach (var account in Store.Accounts.Data)
                    ComboBoxAccount.Items.Add(account.UID);
                ComboBoxAccount.SelectedIndex = 0;
                TextAccountInfo.Text = $"AR.{Store.Accounts.Data[0].Level} {Store.Accounts.Data[0].Name}";
                AccountChanged(this, null);
                IsAccountLoaded = true;
            }
        }

       

        private void AccountChanged(object sender, SelectionChangedEventArgs? e)
        {
            if(!int.TryParse(ComboBoxAccount.Text,out int uid))
            {
                return;
            }
            if(!Option.Instance.Accounts.TryGetValue(uid,out var account)){
                ErrorHandle?.Invoke(this, $"存在しないアカウント (UID : {ComboBoxAccount.Text}) です。");
                return;
            }
            IsAccountLoaded = false;

            CheckBoxNoteCoinMax.IsChecked = account.Notify.RealTimeNotes.RealmCoinMax;
            if (account.Notify.RealTimeNotes.RealmCoinThreshold.Count > 0)
            {
                CheckBoxNoteCoinThreshold.IsChecked = account.Notify.RealTimeNotes.RealmCoinThreshold[0].Enabled;
                SliderNoteCoinThreshold.Value = account.Notify.RealTimeNotes.RealmCoinThreshold[0].Value;
            }
            else
            {
                CheckBoxNoteCoinThreshold.IsChecked = false;
                SliderNoteCoinThreshold.Value = 1800;
            }
            SliderNoteCoinThreshold.IsEnabled = CheckBoxNoteCoinThreshold.IsChecked??false;
            CheckBoxNoteResinMax.IsChecked = account.Notify.RealTimeNotes.ResinMax;
            if (account.Notify.RealTimeNotes.ResinThreshold.Count > 0)
            {
                CheckBoxNoteResinThreshold.IsChecked = account.Notify.RealTimeNotes.ResinThreshold[0].Enabled;
                SliderNoteResinThreshold.Value = account.Notify.RealTimeNotes.ResinThreshold[0].Value;
            }
            else
            {
                CheckBoxNoteResinThreshold.IsChecked = false;
                SliderNoteResinThreshold.Value = 160;
            }
            SliderNoteResinThreshold.IsEnabled = CheckBoxNoteResinThreshold.IsChecked??false;
            CheckBoxNoteTransform.IsChecked = account.Notify.RealTimeNotes.TransformerReached;
            CheckBoxNoteExpedition.IsChecked = account.Notify.RealTimeNotes.ExpeditionAllCompleted;

            TextNoteCoinThreshold.Text = $"{SliderNoteCoinThreshold?.Value:0}";
            TextNoteResinThreshold.Text = $"{SliderNoteResinThreshold?.Value:0}";
            IsAccountLoaded = true;
        }
        private void ChangedCheckState(object sender, RoutedEventArgs e)
        {
            if (!IsAccountLoaded) return;
            if (sender is not CheckBox check) return;
            ChangeState(check);
            Option.Save();
        }
        private void ChangeState(CheckBox check)
        {
            if (!IsAccountLoaded) return;
            bool state = check.IsChecked ?? false;
            if (check == CheckBoxGameStart)
                Option.Instance.Notification.IsGameStart = state;
            else if (check == CheckBoxGameExit)
                Option.Instance.Notification.IsGameEnd = state;
            else
            {
                int uid = int.Parse(ComboBoxAccount.Text);
                if (!Option.Instance.Accounts.TryGetValue(uid, out var config))
                {
                    config = new Core.General.OptionClass.AccountConfig();
                    Option.Instance.Accounts.Add(uid, config);
                }
                var note = config.Notify.RealTimeNotes;
                if (check == CheckBoxNoteCoinMax)
                    note.RealmCoinMax = state;
                else if(check == CheckBoxNoteResinMax)
                    note.ResinMax = state;
                else if(check == CheckBoxNoteExpedition)
                    note.ExpeditionAllCompleted = state;
                else if(check == CheckBoxNoteTransform)
                    note.TransformerReached = state;
                else if(check == CheckBoxNoteCoinThreshold)
                {
                    if (note.RealmCoinThreshold.Count == 0)
                        note.RealmCoinThreshold.Add(new());
                    note.RealmCoinThreshold[0].Enabled = state;
                    SliderNoteCoinThreshold.IsEnabled = state;
                }
                else if (check == CheckBoxNoteResinThreshold)
                {
                    if (note.ResinThreshold.Count == 0)
                        note.ResinThreshold.Add(new());
                    note.ResinThreshold[0].Enabled = state;
                    SliderNoteResinThreshold.IsEnabled = state;
                }

            }

        }
        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!this.IsLoaded) return;
            TextNoteCoinThreshold.Text = $"{SliderNoteCoinThreshold?.Value:0}";
            TextNoteResinThreshold.Text = $"{SliderNoteResinThreshold?.Value:0}";
            if (!IsAccountLoaded) return;
            int uid = int.Parse(ComboBoxAccount.Text);
            if (!Option.Instance.Accounts.TryGetValue(uid, out var config))
            {
                config = new Core.General.OptionClass.AccountConfig();
                Option.Instance.Accounts.Add(uid, config);
            }
            var note = config.Notify.RealTimeNotes;
            if (sender == SliderNoteCoinThreshold)
            {
                if (note.RealmCoinThreshold.Count == 0)
                    note.RealmCoinThreshold.Add(new());
                note.RealmCoinThreshold[0].Value = (int)SliderNoteCoinThreshold.Value;
            }else if  (sender == SliderNoteResinThreshold)
            {
                if (note.ResinThreshold.Count == 0)
                    note.ResinThreshold.Add(new());
                note.ResinThreshold[0].Value = (int)SliderNoteResinThreshold.Value;
            }
            Option.Save();
        }
    }
}
