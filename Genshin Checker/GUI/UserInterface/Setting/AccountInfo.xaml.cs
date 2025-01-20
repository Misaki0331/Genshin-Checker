using Genshin_Checker.Core.HoYoLab;
using Genshin_Checker.GUI.Window.PopupWindow;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Store;
using System.Windows;
using UserControl = System.Windows.Controls.UserControl;

namespace Genshin_Checker.GUI.UserInterface.Setting
{
    /// <summary>
    /// AccountInfo.xaml の相互作用ロジック
    /// </summary>
    public partial class AccountInfo : UserControl
    {
        Account account;
        public AccountInfo(Account account)
        {
            InitializeComponent();
            this.account = account;
            AdventureRank.Text = $"{account.Level}";
            UserName.Text = account.Name;
            UID.Text = $"{account.UID}";
            var data = account.GameRecords.Data;
            if (data != null)
                Infomation.Text = string.Format(Localize.UIName_AccountInfo_Infomation, data.stats.ActiveDay, data.stats.Achievement, data.stats.SpiralAbyss);
            else Infomation.Text = Localize.UIName_AccountInfo_Infomation_Failed;
        }
        public event EventHandler<EventArgs>? AccountRemoveRequest = null;

        private async void ControlLoaded(object sender, RoutedEventArgs e)
        {
            var url = EnkaData.Convert.Namecard.GetNameCardURL(account.EnkaNetwork.Data.playerInfo.nameCardId);
            url ??= "https://enka.network/ui/UI_NameCardPic_0_P.png";
            BackgroundImage.ImageSource = await Core.WebRequest.ImageSourceGetRequest(url);
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {

            var choose = new ChooseMessage(Localize.Message_AccountDisconnect_Title,
                string.Format(Localize.Message_AccountDisconnect_Message, account.Name, account.UID),
                Localize.Message_AccountDisconnect_WindowTitle);
            choose.ShowDialog();
            if (choose.Result == 1)
            {
                account.Dispose();
                Store.Accounts.Data.Remove(account);
                AccountRemoveRequest?.Invoke(account, EventArgs.Empty);
            }
        }
    }
}
