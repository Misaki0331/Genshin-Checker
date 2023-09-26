﻿using Genshin_Checker.App;
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

namespace Genshin_Checker.Window
{
    public partial class SettingWindow : Form
    {
        public SettingWindow()
        {
            InitializeComponent();
            tabControl1.Alignment = TabAlignment.Left;
            //タブのサイズを固定する
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(25, 80);

            //TabControlをオーナードローする
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //DrawItemイベントハンドラを追加
            tabControl1.DrawItem += Tab_DrawItem;
            if (App.RealTimeNote.Instance.uid != 0) LabelConnectedUID.Text = "連携済みのUID : " + App.RealTimeNote.Instance.uid.ToString();

            IsCountBackground.Checked = !ProcessTime.Instance.option.OnlyActiveWindow;
            IsNotificationGameStart.Checked = Option.Instance.Notification.IsGameStart;
            IsNotificationGameClosed.Checked = Option.Instance.Notification.IsGameEnd;
            IsNotificationRealTimeNoteResin120.Checked = Option.Instance.Notification.RealTimeNote.Resin120;
            IsNotificationRealTimeNoteResinMax.Checked = Option.Instance.Notification.RealTimeNote.ResinMax;
            IsNotificationRealTimeNoteRealmCoin1800.Checked = Option.Instance.Notification.RealTimeNote.RealmCoin1800;
            IsNotificationRealTimeNoteRealmCoinMax.Checked = Option.Instance.Notification.RealTimeNote.RealmCoinMax;
            IsNotificationRealTimeNoteExpeditionAllCompleted.Checked = Option.Instance.Notification.RealTimeNote.ExpeditionAllCompleted;
            IsNotificationRealTimeNoteTransformerReached.Checked = Option.Instance.Notification.RealTimeNote.TransformerReached;
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
            Registry.SetValue("Config\\Setting", obj.Name, $"{obj.Checked}");
            changeValue(obj);
        }
        void changeValue(CheckBox name)
        {
            if (name == IsCountBackground) ProcessTime.Instance.option.OnlyActiveWindow = !name.Checked;
            else if(name == IsNotificationGameStart) Option.Instance.Notification.IsGameStart = name.Checked;
            else if(name == IsNotificationGameClosed) Option.Instance.Notification.IsGameEnd = name.Checked;
            else if(name == IsNotificationRealTimeNoteResin120) Option.Instance.Notification.RealTimeNote.Resin120 = name.Checked;
            else if(name == IsNotificationRealTimeNoteResinMax) Option.Instance.Notification.RealTimeNote.ResinMax = name.Checked;
            else if(name == IsNotificationRealTimeNoteRealmCoin1800) Option.Instance.Notification.RealTimeNote.RealmCoin1800 = name.Checked;
            else if(name == IsNotificationRealTimeNoteRealmCoinMax) Option.Instance.Notification.RealTimeNote.RealmCoinMax = name.Checked;
            else if(name == IsNotificationRealTimeNoteExpeditionAllCompleted) Option.Instance.Notification.RealTimeNote.ExpeditionAllCompleted = name.Checked;
            else if(name == IsNotificationRealTimeNoteTransformerReached) Option.Instance.Notification.RealTimeNote.TransformerReached = name.Checked;
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

        private void Open_HoYoLabAuth_Click(object sender, EventArgs e)
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
            if (App.RealTimeNote.Instance.uid != 0) LabelConnectedUID.Text = "連携済みのUID : " + App.RealTimeNote.Instance.uid.ToString();
            Open_HoYoLabAuth.Enabled = true;
        }
    }
}