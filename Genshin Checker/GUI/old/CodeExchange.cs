using Genshin_Checker.Core.HoYoLab;
using Genshin_Checker.GUI.Window.PopupWindow;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Store;
using Genshin_Checker.UI.Control.CodeExchange;
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
using ErrorMessage = Genshin_Checker.GUI.Window.PopupWindow.ErrorMessage;

namespace Genshin_Checker.Window
{
    public partial class CodeExchange : Form
    {
        Dictionary<string, Account> AccountTemp = new();
        List<UICode> Codes = new();
        public CodeExchange()
        {
            InitializeComponent();
            Icon = resource.icon.nahida;
        }

        private void CodeExchange_Load(object sender, EventArgs e)
        {
            foreach (var account in Accounts.Data)
            {
                var name = $"UID:{account.UID}({account.Server}) {account.Name}";
                AccountTemp.Add(name, account);
                ComboHoYoLabAccounts.Items.Add(name);
            }
            if (AccountTemp.Count == 0)
            {
                ComboHoYoLabAccounts.Items.Add(Common.NoAccount);
                ComboHoYoLabAccounts.SelectedIndex = 0;
                ComboHoYoLabAccounts.Enabled = false;
                new ErrorMessage(Localize.Error_RedeemCode_MissingAccount_Title, Localize.Error_RedeemCode_MissingAccount_Message).ShowDialog();
                Close();
                return;
            }
            else ComboHoYoLabAccounts.SelectedIndex = 0;
            CodeInput.Focus();
            var codes = AccountTemp[$"{ComboHoYoLabAccounts.Items[0]}"].HoYoLabInfomation.GetCodeList();
            foreach( var code in codes.Codes) {
                var ui = new UICode(code.Code, code.ExpairUtc.ToLocalTime()) { Dock = DockStyle.Top };
                ui.UiCodeClicked += ClickedUICode;
                Codes.Add(ui);
            }
            Codes.Reverse();
            foreach(var ui in Codes) panel1.Controls.Add(ui);
        }

        private void ClickedUICode(object? sender, string e)
        {
            CodeInput.Text = e;
            CodeInput.Focus();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (AccountTemp.TryGetValue(ComboHoYoLabAccounts.Text, out var account))
            {
                if (account.IsDisposed)
                {
                    new ErrorMessage(Localize.Error_LoadGameDatabase_AccountDisposed, Localize.Error_LoadGameDatabase_AccountDisposed_Message).ShowDialog();
                    Close();
                    return;
                }
                if (string.IsNullOrWhiteSpace(CodeInput.Text)) return;
                try
                {
                    var result = await account.Endpoint.CodeExchange(CodeInput.Text);
                    new InfoMessage(result.msg, Localize.Message_RedeemCode_Success).ShowDialog();
                }
                catch (Account.HoYoLabAPIException ex)
                {
                    new ErrorMessage(Localize.Error_RedeemCode_FailedToRedeem, $"{ex.APIMessage}\nCode : {ex.Retcode}").ShowDialog();
                }
                catch (Exception ex)
                {
                    new ErrorMessage(Common.ErrorMessage, $"{ex}").ShowDialog();
                }
            }
        }

        private void CodeInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button1_Click(sender, e);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}
