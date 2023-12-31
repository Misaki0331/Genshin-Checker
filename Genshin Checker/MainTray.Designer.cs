﻿namespace Genshin_Checker
{
    partial class MainTray
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notification = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotificationMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.versionNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.詳細プレイデータToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ゲームログ開発者向けToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delay = new System.Windows.Forms.Timer(this.components);
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NotificationMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notification
            // 
            this.notification.ContextMenuStrip = this.NotificationMenu;
            this.notification.Text = "原神チェッカー";
            this.notification.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notification_Click);
            // 
            // NotificationMenu
            // 
            this.NotificationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionNameToolStripMenuItem,
            this.toolStripSeparator3,
            this.詳細プレイデータToolStripMenuItem,
            this.AccountToolStrip,
            this.ゲームログ開発者向けToolStripMenuItem,
            this.toolStripSeparator2,
            this.設定ToolStripMenuItem,
            this.toolStripSeparator1,
            this.終了ToolStripMenuItem,
            this.consoleToolStripMenuItem,
            this.testToolStripMenuItem});
            this.NotificationMenu.Name = "contextMenuStrip1";
            this.NotificationMenu.Size = new System.Drawing.Size(185, 220);
            // 
            // versionNameToolStripMenuItem
            // 
            this.versionNameToolStripMenuItem.Enabled = false;
            this.versionNameToolStripMenuItem.Name = "versionNameToolStripMenuItem";
            this.versionNameToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.versionNameToolStripMenuItem.Text = "VersionName";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // 詳細プレイデータToolStripMenuItem
            // 
            this.詳細プレイデータToolStripMenuItem.Name = "詳細プレイデータToolStripMenuItem";
            this.詳細プレイデータToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.詳細プレイデータToolStripMenuItem.Text = "詳細プレイデータ";
            this.詳細プレイデータToolStripMenuItem.Click += new System.EventHandler(this.詳細プレイデータToolStripMenuItem_Click);
            // 
            // AccountToolStrip
            // 
            this.AccountToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyToolStripMenuItem});
            this.AccountToolStrip.Name = "AccountToolStrip";
            this.AccountToolStrip.Size = new System.Drawing.Size(184, 22);
            this.AccountToolStrip.Text = "アカウント";
            // 
            // emptyToolStripMenuItem
            // 
            this.emptyToolStripMenuItem.Enabled = false;
            this.emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            this.emptyToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.emptyToolStripMenuItem.Text = "(Empty)";
            // 
            // ゲームログ開発者向けToolStripMenuItem
            // 
            this.ゲームログ開発者向けToolStripMenuItem.Name = "ゲームログ開発者向けToolStripMenuItem";
            this.ゲームログ開発者向けToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.ゲームログ開発者向けToolStripMenuItem.Text = "ゲームログ(開発者向け)";
            this.ゲームログ開発者向けToolStripMenuItem.Click += new System.EventHandler(this.ゲームログ開発者向けToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.設定ToolStripMenuItem.Text = "設定";
            this.設定ToolStripMenuItem.Click += new System.EventHandler(this.設定ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.testToolStripMenuItem.Text = "TestFunction";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_ClickAsync);
            // 
            // Delay
            // 
            this.Delay.Enabled = true;
            this.Delay.Tick += new System.EventHandler(this.Delay_Tick);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // MainTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Genshin_Checker.resource.namecard.Genshin_Impact_A_New_World;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(407, 194);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainTray";
            this.ShowInTaskbar = false;
            this.Text = "MainTray";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainTray_FormClosing);
            this.Load += new System.EventHandler(this.MainTray_Load);
            this.NotificationMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private NotifyIcon notification;
        private ContextMenuStrip NotificationMenu;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.Timer Delay;
        private ToolStripMenuItem 詳細プレイデータToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem versionNameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem ゲームログ開発者向けToolStripMenuItem;
        private ToolStripMenuItem AccountToolStrip;
        private ToolStripMenuItem emptyToolStripMenuItem;
        private ToolStripMenuItem consoleToolStripMenuItem;
    }
}