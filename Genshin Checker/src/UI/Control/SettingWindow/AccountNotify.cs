using Genshin_Checker.App.General;
using Genshin_Checker.App.HoYoLab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.UI.Control.SettingWindow
{
    public partial class AccountNotify : UserControl
    {
        Account account;
        public AccountNotify(Account account)
        {
            InitializeComponent();
            this.account = account;
            LoadConfig();
            AccountInfomation.Text = $"{account.Name} AR.{account.Level} (UID: {account.UID})";
        }
        private void LoadConfig()
        {

            if (Option.Instance.Accounts.TryGetValue(account.UID, out var config))
            {
                var realtime = config.Notify.RealTimeNotes;
                CheckResinMax.Checked = realtime.ResinMax;
                if (realtime.ResinThreshold.Count > 0)
                {
                    CheckResinThreshold.Checked = realtime.ResinThreshold[0].Enabled;
                    NumResinThreshold.Value = realtime.ResinThreshold[0].Value;
                }
                CheckRealmCoinMax.Checked = realtime.RealmCoinMax;
                if (realtime.RealmCoinThreshold.Count > 0)
                {
                    CheckRealmCoinThreshold.Checked = realtime.RealmCoinThreshold[0].Enabled;
                    NumRealmCoinThreshold.Value = realtime.RealmCoinThreshold[0].Value;
                }
                CheckTransformerReached.Checked = realtime.TransformerReached;
                CheckExpeditionAllCompleted.Checked = realtime.ExpeditionAllCompleted;

            }
        }
        private void StateChanged(object sender, EventArgs e)
        {
            bool IsExist = Option.Instance.Accounts.TryGetValue(account.UID,out var config);
            config ??= new();
            var realtime = config.Notify.RealTimeNotes;
            if(sender is CheckBox check)
            {
                switch (check.Name)
                {
                    case nameof(CheckResinMax):
                        realtime.ResinMax = CheckResinMax.Checked;
                        break;
                    case nameof(CheckResinThreshold):
                        if (realtime.ResinThreshold.Count < 1) realtime.ResinThreshold.Add(new() { Value = (int)NumResinThreshold.Value });
                        realtime.ResinThreshold[0].Enabled=CheckResinThreshold.Checked;
                        break;
                    case nameof(CheckRealmCoinMax):
                        realtime.RealmCoinMax = CheckRealmCoinMax.Checked;
                        break;
                    case nameof(CheckRealmCoinThreshold):
                        if (realtime.RealmCoinThreshold.Count < 1) realtime.RealmCoinThreshold.Add(new() { Value = (int)NumRealmCoinThreshold.Value });
                        realtime.RealmCoinThreshold[0].Enabled = CheckRealmCoinThreshold.Checked;
                        break;
                    case nameof(CheckExpeditionAllCompleted):
                        realtime.ExpeditionAllCompleted = CheckExpeditionAllCompleted.Checked;
                        break;
                    case nameof(CheckTransformerReached):
                        realtime.TransformerReached = CheckTransformerReached.Checked;
                        break;
                }
            }else if(sender is NumericUpDown ud)
            {
                switch (ud.Name)
                {
                    case nameof(NumResinThreshold):
                        if (realtime.ResinThreshold.Count < 1) realtime.ResinThreshold.Add(new() { Enabled = CheckResinThreshold.Checked });
                        realtime.ResinThreshold[0].Value = (int)NumResinThreshold.Value;
                        break;
                    case nameof(NumRealmCoinThreshold):
                        if (realtime.RealmCoinThreshold.Count < 1) realtime.RealmCoinThreshold.Add(new() { Enabled = CheckRealmCoinThreshold.Checked });
                        realtime.RealmCoinThreshold[0].Value = (int)NumRealmCoinThreshold.Value;
                        break;
                }
            }
            if (!IsExist) Option.Instance.Accounts.Add(account.UID,config);
            Option.Save();
        }
    }
}
