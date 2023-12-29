using Genshin_Checker.App;
using Genshin_Checker.App.Game;
using Genshin_Checker.App.General;
using Genshin_Checker.Window.Popup;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;

namespace Genshin_Checker.Window
{
    public partial class SettingWindow : Form
    {
        List<TabPage> AccountNotify=new();
        List<UI.Control.SettingWindow.AccountInfo> AccountBannar = new();
        public SettingWindow()
        {
            InitializeComponent();
            Icon = resource.icon.nahida;
            tabControl1.Alignment = TabAlignment.Left;
            //タブのサイズを固定する
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(25, 80);

            //TabControlをオーナードローする
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //DrawItemイベントハンドラを追加
            tabControl1.DrawItem += Tab_DrawItem;
            label4.Text = $"Version : {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}";
            IsCountBackground.Checked = !ProcessTime.Instance.option.OnlyActiveWindow;
            IsNotificationGameStart.Checked = Option.Instance.Notification.IsGameStart;
            IsNotificationGameClosed.Checked = Option.Instance.Notification.IsGameEnd;
            IsScreenShotRaise.Checked = Option.Instance.ScreenShot.IsRaise;
            IsScreenShotNotify.Checked = Option.Instance.ScreenShot.IsNotify;
            ScreenshotPath.Text = Option.Instance.ScreenShot.RaisePath;
            ScreenShotTransferFileFormat.Text = Option.Instance.ScreenShot.SaveFileFormat;
            ScreenShotTransferDirectry.Text = Option.Instance.ScreenShot.SaveFilePath;
            IsScreenShotAfterDelete.Checked = Option.Instance.ScreenShot.IsSaveAfterDelete;
            ScreenShotTransferImageType.Text = Option.Instance.ScreenShot.SaveFileFormatType;
            if (ScreenShotTransferImageType.SelectedIndex < 0) ScreenShotTransferImageType.SelectedIndex = 0;
            AccountReload();

        }
        private void AccountReload()
        {
            lock (Store.Accounts.Data)
            {
                groupBox8.SuspendLayout();
                TabAccountNotify.SuspendLayout();
                for (int i = AccountBannar.Count - 1; i >= 0; i--)
                {
                    var bannar = AccountBannar[i];
                    groupBox8.Controls.Remove(bannar);
                    AccountBannar.Remove(bannar);
                    bannar.Dispose();
                }
                for (int i = AccountNotify.Count - 1; i >= 0; i--)
                {
                    var notify = AccountNotify[i];
                    TabAccountNotify.Controls.Remove(notify);
                    AccountNotify.Remove(notify);
                    notify.Dispose();
                }
                foreach (var account in Store.Accounts.Data)
                {
                    var bannar = new UI.Control.SettingWindow.AccountInfo(account) { Dock = DockStyle.Top };
                    bannar.AccountRemoveRequest += (s, e) => { AccountReload(); };
                    AccountBannar.Add(bannar);
                    groupBox8.Controls.Add(bannar);
                    var notify = new TabPage() { UseVisualStyleBackColor = true, Text = $"{account.Name} (AR.{account.Level})", Name = $"{account.UID}" };
                    notify.Controls.Add(new UI.Control.SettingWindow.AccountNotify(account) { Dock = DockStyle.Top });
                    AccountNotify.Add(notify);
                    TabAccountNotify.Controls.Add(notify);
                }
                groupBox8.ResumeLayout(true);
                TabAccountNotify.ResumeLayout(true);
            }
        }
        private void Tab_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (sender == null) return;
            TabControl tab = (TabControl)sender;
            TabPage page = tab.TabPages[e.Index];
            //タブページのテキストを取得
            string txt = page.Text;

            //StringFormatを作成
            StringFormat sf = new();
            //水平垂直方向の中央に、行が完全に表示されるようにする
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            sf.FormatFlags |= StringFormatFlags.LineLimit;

            //背景の描画
            Brush backBrush = new SolidBrush(page.BackColor);
            e.Graphics.FillRectangle(backBrush, e.Bounds);
            backBrush.Dispose();

            //Textの描画
            Brush foreBrush = new SolidBrush(page.ForeColor);
            e.Graphics.DrawString(txt, page.Font, foreBrush, e.Bounds, sf);
            foreBrush.Dispose();
        }

        private void SettingWindow_Load(object sender, EventArgs e)
        {

        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            var obj = (CheckBox)sender;
            if(obj == null) return;
            try
            {
                switch (obj.Name)
                {
                    case nameof(IsScreenShotRaise):
                        App.Game.ScreenshotWatcher.Instance.IsRaise = obj.Checked;
                        break;
                }
            }catch(Exception ex)
            {
                obj.Checked = !obj.Checked;
                new ErrorMessage("設定の変更に失敗しました。", $"{ex.Message}").ShowDialog();
            }
            Option.Save();
            changeValue(obj);
        }
        void changeValue(CheckBox name)
        {
            if (name == IsCountBackground) ProcessTime.Instance.option.OnlyActiveWindow = !name.Checked;
            else if(name == IsNotificationGameStart) Option.Instance.Notification.IsGameStart = name.Checked;
            else if(name == IsNotificationGameClosed) Option.Instance.Notification.IsGameEnd = name.Checked;
            else if (name == IsScreenShotRaise) Option.Instance.ScreenShot.IsRaise = name.Checked;
            else if (name == IsScreenShotAfterDelete) Option.Instance.ScreenShot.IsSaveAfterDelete = name.Checked;
            else if (name == IsScreenShotNotify) Option.Instance.ScreenShot.IsNotify = name.Checked;
        }

        private void OpenLink(object sender, EventArgs e)
        {
            var link = ((Button)sender).Tag.ToString();
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = link,
                UseShellExecute = true,
            };
            if (link!=null)Process.Start(pi);
    }

        private async void Open_HoYoLabAuth_Click(object sender, EventArgs e)
        {
            Open_HoYoLabAuth.Enabled = false;
            try
            {
                var dialog=new BrowserApp.BattleAuth(isAutoAuth:false);
                dialog.ShowDialog(this);
            }
            catch (Exception)
            {

            }
            await Task.Delay(1000);
            Open_HoYoLabAuth.Enabled = true;
            AccountReload();
        }

        private async void ButtonScreenShotPathAuto_Click(object sender, EventArgs e)
        {
            var str = await GameApp.WhereScreenShotPath();
            if(str == null)
            {
                new ErrorMessage("スクリーンショットのパスの取得に失敗", "ゲームを起動してもう一度お試しください。").ShowDialog();
                return;
            }
            ScreenshotPath.Text = str;
            App.Game.ScreenshotWatcher.Instance.Path = str;
            Option.Instance.ScreenShot.RaisePath = str;
            Option.Save();
        }

        private async void ScreenShotTransferFileFormat_TextChanged(object sender, EventArgs e)
        {
            var format = ScreenShotTransferFileFormat.Text;
            var result = await App.General.ScreenShot.SetFileFormat(format);
            if (string.IsNullOrEmpty(result))
            {
                ScreenShotTransferFileFormat.BackColor = Color.White;
            }
            else
            {
                ScreenShotTransferFileFormat.BackColor = Color.Pink;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog()
            {
                Description = "スクリーンショットを転送するフォルダを選択してください",
            };
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            Option.Instance.ScreenShot.SaveFilePath = fbd.SelectedPath;
            ScreenShotTransferDirectry.Text = fbd.SelectedPath;
            Option.Save();
        }

        private void ScreenShotTransferImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Option.Instance.ScreenShot.SaveFileFormatType = ScreenShotTransferImageType.Text;
            Option.Save();
        }

        private void SettingSizeChanged(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Maximized)
            {
                this.Invalidate();
                this.PerformLayout();
            }
        }

        private void SettingResizeEnd(object sender, EventArgs e)
        {

            this.Invalidate();
            this.PerformLayout();
        }

        protected override void OnResize(EventArgs e)
        {
        }
    }
}
