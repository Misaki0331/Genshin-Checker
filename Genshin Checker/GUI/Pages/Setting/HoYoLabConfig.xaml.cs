using Genshin_Checker.Core.General;
using System;
using System.Collections.Generic;
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
using CheckBox = System.Windows.Controls.CheckBox;

namespace Genshin_Checker.GUI.Pages.Setting
{
    /// <summary>
    /// General.xaml の相互作用ロジック
    /// </summary>
    public partial class HoYoLabConfig : Page
    {
        public EventHandler<string>? ErrorHandle;
        bool IsAccountLoaded;
        public HoYoLabConfig()
        {
            InitializeComponent();
            IsAccountLoaded = false;
            LoadConfig();
        }
        private void LoadConfig()
        {
            if (Store.Accounts.Data.Count == 0)
            {
                TextAccountInfo.Text = "連携しているアカウントがありません。";
                ComboBoxAccount.IsEnabled = false;

                CheckBoxConfigAutoCheckIn.IsEnabled = false;
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
            if (!int.TryParse(ComboBoxAccount.Text, out int uid))
            {
                return;
            }
            if (!Option.Instance.Accounts.TryGetValue(uid, out var account))
            {
                ErrorHandle?.Invoke(this, $"存在しないアカウント (UID : {ComboBoxAccount.Text}) です。");
                return;
            }
            IsAccountLoaded = false;
            CheckBoxConfigAutoCheckIn.IsChecked = account.IsHoYoLabAutoSignIn;
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
            int uid = int.Parse(ComboBoxAccount.Text);
            if (!Option.Instance.Accounts.TryGetValue(uid, out var config))
            {
                config = new Core.General.OptionClass.AccountConfig();
                Option.Instance.Accounts.Add(uid, config);
            }
            if (check == CheckBoxConfigAutoCheckIn)
                config.IsHoYoLabAutoSignIn = state;

        }
    }
}