using Genshin_Checker.App.HoYoLab;
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
            if (account.UID != 0) Text = $"リアルタイムノート (UID:{account.UID})";
            else Text = $"リアルタイムノート";
            button_Auth.Visible = false;
            if (Note.Meta.Message == "OK")
            {
                var r = Note.RealTime;
                panel_main.Visible = true;
                panel_Error.Visible = false;
                label1.Text = $"{r.Resin.Current}";
                label2.Text = $"/{r.Resin.Max}";
                if (DateTime.Now > r.Resin.RecoveryTime) label3.Text = "最大まで回復済";
                else
                {
                    var time = (int)(r.Resin.RecoveryTime - DateTime.Now).TotalSeconds;
                    label3.Text = $"残り {(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}";
                }
                if (r.Commission.IsClaimed) label4.Text = $"{r.Commission.Current} / {r.Commission.Max} 完了";
                else if (r.Commission.Current == r.Commission.Max) label4.Text = $"{r.Commission.Current} / {r.Commission.Max} 未受取";
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
                if (r.RealmCoin.Max==0) label7.Text = "開放後利用可能";
                else if (DateTime.Now > r.RealmCoin.RecoveryTime) label7.Text = "最大まで回復済";
                else
                {
                    var time = (int)(r.RealmCoin.RecoveryTime - DateTime.Now).TotalSeconds;
                    label7.Text = $"残り {(time / 3600)}:{(time / 60 % 60):00}:{(time % 60):00}";
                }
                label8.Text = $"残り {r.DiscountResin.Current} 回 / {r.DiscountResin.Max} 回";
                if (r.Transform.IsReached) label9.Text = "利用可能";
                else
                {
                    string data = "残り 約";
                    if (r.Transform.TransformTime.Day > 0) data += $" {r.Transform.TransformTime.Day} 日";
                    if (r.Transform.TransformTime.Hour > 0) data += $" {r.Transform.TransformTime.Hour} 時間";
                    if (r.Transform.TransformTime.Minute > 0) data += $" {r.Transform.TransformTime.Minute} 分";
                    if (r.Transform.TransformTime.Second > 0) data += $" {r.Transform.TransformTime.Second} 秒";
                    label9.Text = data;
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
                        if (DateTime.Now > data.EstimatedTime) ex_label[i].Text = "探索完了";
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
                    if (Note.Meta.IsAPIError) label10.Text = "APIエラー";
                    else label10.Text = "内部エラー";
                    label_ErrorMessage.Text = $"エラーコード : {Note.Meta.Retcode}\n{Note.Meta.Message}";
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

        private async void RealTimeData_Load(object sender, EventArgs e)
        {
            var url = EnkaData.Convert.Namecard.GetNameCardURL(account.EnkaNetwork.Data.playerInfo.nameCardId);
            var image = url == null ? null : await App.WebRequest.ImageGetRequest(url);
            if (image != null) BackgroundImage = new Bitmap(image,ClientSize);
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
