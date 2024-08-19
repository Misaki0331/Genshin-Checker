using Genshin_Checker.App.General;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Window.Popup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window.Debug
{
    public partial class APIChecker : Form
    {
        public APIChecker()
        {
            InitializeComponent();
            AccountReload();
        }
        void AccountReload()
        {
            Accounts.Items.Clear();
            foreach (var account in Store.Accounts.Data)
            {
                Accounts.Items.Add($"{account.UID}");
            }
        }
        App.HoYoLab.Account? CheckAccount()
        {
            var name = Accounts.Text;
            AccountReload();
            Accounts.Text = name;
            if (int.TryParse(name, out int value))
                return Store.Accounts.Data.Find(a => a.UID == int.Parse(name));
            return null;
        }
        private async void ButtonGameRecord_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetGameRecords(account));

        }

        private async void ButtonCharacters_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetCharacters(account));
        }

        private async void ButtonRealTimeNote_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetRealTimeNote(account));
        }

        private async void ButtonEnkaNetwork_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetEnkaNetwork(account.UID));
        }

        private async void ButtonSpiralAbyssCurrent_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetSpiralAbyss(account, true));
        }

        private async void ButtonSpiralAbyssPreviously_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetSpiralAbyss(account, false));
        }

        private async void ButtonTravelersDiary_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetTravelersDiaryInfo(account, (int)NumTravelerDiaryMonth.Value));
        }

        private async void ButtonTravelersDiaryDetail_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetTravelersDiaryDetail(account, (int)NumTravelerDiaryDetailType.Value, (int)NumTravelerDiaryDetailPage.Value, (int)NumTravelerDiaryDetailMonth.Value));
        }
        private async void ButtonStellarJourney_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetActiveQuery(account, DateTimeStellarJourneySince.Value));
        }

        private async void ButtonCharacterDetail_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetCharacterDetail(account, (int)NumCharacterDetailCharacterID.Value));
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetHoYoLabMaterial(account));
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.ExchangeCode(account, textBox1.Text));
        }

        private async void ButtonTheater_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetRoleCombat(account, true));
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var account = CheckAccount();
            if (account == null) return;
            try
            {
                var a = textBox2.Text.Split(" ");
                var b = new List<int>();
                foreach (var c in a)
                {
                    b.Add(int.Parse(c));
                }
                OutputBox.Text = JsonChecker<dynamic>.format(await GetJson.GetCharactersDetail(account, b));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                new ErrorMessage("エラー！", ex.ToString()).ShowDialog();
            }
        }
    }
}
