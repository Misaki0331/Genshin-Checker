using Genshin_Checker.App.General.UI;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Genshin_Checker.Window
{
    public partial class RealTimeData : Form
    {
        Account account;
        public RealTimeData(Account account)
        {
            this.account = account;
            InitializeComponent();
            Icon = resource.icon.nahida;
            UiUpdate.Tick+= UiUpdate_Tick;
        }

        private async void UiUpdate_Tick(object? sender, EventArgs e)
        {
            if (account.IsDisposed) Close();
            UiUpdate.Stop();
            var Note = account.RealTimeNote.Data;
            if (account.UID != 0) Text = $"{Localize.WindowName_RealTimeNote} (UID:{account.UID})";
            else Text = Localize.WindowName_RealTimeNote;
            button_Auth.Visible = false;
            if (Note.Meta.Message == "OK")
            {
                var r = Note.RealTime;
                panel_main.Visible = true;
                panel_Error.Visible = false;
                label1.Text = $"{r.Resin.Current}";
                label2.Text = $"/{r.Resin.Max}";
                if (DateTime.Now > r.Resin.RecoveryTime) label3.Text = Localize.WindowName_RealTimeNote_MaxOut;
                else
                {
                    var time = (int)(r.Resin.RecoveryTime - DateTime.Now).TotalSeconds;
                    label3.Text = string.Format(Localize.WindowName_RealTimeNote_TimeLeft,$"{(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}");
                }
                if (r.Commission.IsClaimed) label4.Text = Localize.WindowName_RealTimeNote_Daily_Completed;
                else if (r.Commission.Current == r.Commission.Max) label4.Text = Localize.WindowName_RealTimeNote_Daily_NotExtraClaimed;
                else label4.Text = $"{r.Commission.Current} / {r.Commission.Max}";

                if (r.RealmCoin.Max == 0)
                {
                    label5.Text = $"----";
                    label6.Text = $"/----";
                }
                else
                {
                    label5.Text = $"{r.RealmCoin.Current}";
                    label6.Text = $"/{r.RealmCoin.Max}";
                }
                if (r.RealmCoin.Max==0) label7.Text = Localize.WindowName_RealTimeNote_Locked;
                else if (DateTime.Now > r.RealmCoin.RecoveryTime) label7.Text = Localize.WindowName_RealTimeNote_MaxOut;
                else
                {
                    var time = (int)(r.RealmCoin.RecoveryTime - DateTime.Now).TotalSeconds;
                    label7.Text = string.Format(Localize.WindowName_RealTimeNote_TimeLeft,$"{(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}");
                }
                label8.Text = string.Format(Localize.WindowName_RealTimeNote_DiscountWeeklyBossText, r.DiscountResin.Current, r.DiscountResin.Max);
                if (r.Transform.IsReached) label9.Text = Localize.WindowName_RealTimeNote_TransformAvailable;
                else
                {
                    string data = "";
                    if (r.Transform.TransformTime.Day > 0) data += $" {string.Format(Localize.WindowName_RealTimeNote_TransformOngoingDay, r.Transform.TransformTime.Day)}";
                    if (r.Transform.TransformTime.Hour > 0) data += $" {string.Format(Localize.WindowName_RealTimeNote_TransformOngoingHour, r.Transform.TransformTime.Hour)}";
                    if (r.Transform.TransformTime.Minute > 0) data += $" {string.Format(Localize.WindowName_RealTimeNote_TransformOngoingMinute, r.Transform.TransformTime.Minute)}";
                    if (r.Transform.TransformTime.Second > 0) data += $" {string.Format(Localize.WindowName_RealTimeNote_TransformOngoingSecond, r.Transform.TransformTime.Second)}";
                    label9.Text = string.Format(Localize.WindowName_RealTimeNote_TransformOngoingText, data.Trim());
                }
                label_expendition_num.Text = $"{r.Expedition.Dispatched.Current} / {r.Expedition.Dispatched.Max}";
                var ex_panel = new List<Panel>() { panel_expendition_1, panel_expendition_2, panel_expendition_3, panel_expendition_4, panel_expendition_5 };
                var ex_icon = new List<PictureBox>() { icon_expendition_1, icon_expendition_2, icon_expendition_3, icon_expendition_4, icon_expendition_5 };
                var ex_label = new List<Label>() { label_expendition_1, label_expendition_2, label_expendition_3, label_expendition_4, label_expendition_5 };
                for (int i = 0; i < 5; i++)
                {
                    if (r.Expedition.Expeditions.Count > i)
                    {
                        var data = r.Expedition.Expeditions[i];
                        ex_panel[i].Visible = true;
                        if (data.ImageURL != ex_icon[i].Name) ex_icon[i].Image = await App.WebRequest.ImageGetRequest(data.ImageURL);
                        ex_icon[i].Name = data.ImageURL;
                        if (DateTime.Now > data.EstimatedTime) ex_label[i].Text = Localize.WindowName_RealTimeNote_ExpeditionCompleted;
                        else
                        {
                            var time = (int)(data.EstimatedTime - DateTime.Now).TotalSeconds;
                            ex_label[i].Text = $"{(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}";
                        }
                    }
                    else ex_panel[i].Visible = false;
                }
            }
            else
            {
                panel_main.Visible = false;
                panel_Error.Visible = true;
                if (Note.Meta.Retcode != 0)
                {
                    if (Note.Meta.IsAPIError) label10.Text = Localize.WindowName_RealTimeNote_APIError;
                    else label10.Text = Localize.WindowName_RealTimeNote_ExceptionError;
                    label_ErrorMessage.Text = string.Format(Localize.WindowName_RealTimeNote_ExceptionErrorDetail, Note.Meta.Retcode, Note.Meta.Message);
                }
            }
            UiUpdate.Interval = 1000 - (DateTime.Now - TruncateToSeconds(DateTime.Now)).Milliseconds;
            UiUpdate.Start();
            //this.BackgroundImage.
        }

        static DateTime TruncateToSeconds(DateTime dateTime)
        {
            return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_Auth_Click(object sender, EventArgs e)
        {
            var browser = new BrowserApp.BattleAuth(account: account);
            browser.ShowDialog(this);
        }

        private async void WindowLoad(object sender, EventArgs e)
        {
            var url = EnkaData.Convert.Namecard.GetNameCardURL(account.EnkaNetwork.Data.playerInfo.nameCardId);
            var image = url == null ? null : await App.WebRequest.ImageGetRequest(url);
            if (image != null) BackgroundImage = DrawControl.BitmapInterpolation(image, ClientSize.Width, ClientSize.Height);
        }
        private void Label_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Label label)
            {
                App.General.UI.DrawControl.DrawBackground(e.Graphics, BackgroundImage, this, label);
                App.General.UI.DrawControl.DrawOutlineString(e.Graphics, label, Color.White, Color.Black, label.Font.Size < 18 ? 2 : 3);
            }
        }
        private void ReloadNote(object sender, EventArgs e)
        {
            account.RealTimeNote.Reload();
        }
    }
}
