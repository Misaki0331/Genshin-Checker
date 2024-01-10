using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Store;
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

namespace Genshin_Checker.UI.Control.SettingWindow
{
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
        Image? RawImage = null;

        private void DrawPaint(object sender, PaintEventArgs e)
        {
            if(sender is Label label)
            {

                if (BackgroundImage != null) App.General.UI.DrawControl.DrawBackground(e.Graphics, BackgroundImage, this, label);
                App.General.UI.DrawControl.DrawOutlineString(e.Graphics, label, label.ForeColor, Color.Black, 2);
            }
        }

        private async void ControlLoad(object sender, EventArgs e)
        {
            var url = EnkaData.Convert.Namecard.GetNameCardURL(account.EnkaNetwork.Data.playerInfo.nameCardId);
            RawImage = url == null ? null : await App.WebRequest.ImageGetRequest(url);
            DrawBackground();
        }
        private void DrawBackground()
        {
            if(RawImage != null)
            {
                var old = BackgroundImage;
                var Raw = RawImage.Size;
                var form = this;
                double w = (double)form.Width / Raw.Width;
                double h = (double)form.Height / Raw.Height;
                Bitmap img = new(form.Width, form.Height);
                var g = Graphics.FromImage(img);
                if (Raw.Height * w >= form.Height)
                    g.DrawImage(RawImage, 0, -(int)(Raw.Height * w - form.Height) / 2, (int)(Raw.Width * w), (int)(Raw.Height * w));
                else g.DrawImage(RawImage, -(int)(Raw.Width * h - form.Width) / 2, 0, (int)(Raw.Width * h), (int)(Raw.Height * h));
                g.Dispose();
                BackgroundImage = img;
                old?.Dispose();
                this.Refresh();
            }
        }

        private void AccountInfo_SizeChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            DrawBackground();
            this.ResumeLayout(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var choose = new ChooseMessage(Localize.Message_AccountDisconnect_Title, 
                string.Format(Localize.Message_AccountDisconnect_Message,account.Name,account.UID), 
                Localize.Message_AccountDisconnect_WindowTitle);
            choose.ShowDialog();
            if (choose.Result == 1)
            {
                account.Dispose(); 
                Store.Accounts.Data.Remove(account);
                AccountRemoveRequest?.Invoke(account, EventArgs.Empty);
            }
        }

        private void AccountInfo_Resize(object sender, EventArgs e)
        {

        }
    }
}
