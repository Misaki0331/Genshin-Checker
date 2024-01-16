namespace Genshin_Checker
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTray));
            notification = new NotifyIcon(components);
            NotificationMenu = new ContextMenuStrip(components);
            versionNameToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            詳細プレイデータToolStripMenuItem = new ToolStripMenuItem();
            AccountToolStrip = new ToolStripMenuItem();
            emptyToolStripMenuItem = new ToolStripMenuItem();
            ゲームログ開発者向けToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            設定ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            終了ToolStripMenuItem = new ToolStripMenuItem();
            consoleToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            Delay = new System.Windows.Forms.Timer(components);
            現在のアカウント情報を取得ToolStripMenuItem = new ToolStripMenuItem();
            NotificationMenu.SuspendLayout();
            SuspendLayout();
            // 
            // notification
            // 
            resources.ApplyResources(notification, "notification");
            notification.ContextMenuStrip = NotificationMenu;
            notification.MouseUp += notification_Click;
            // 
            // NotificationMenu
            // 
            resources.ApplyResources(NotificationMenu, "NotificationMenu");
            NotificationMenu.Items.AddRange(new ToolStripItem[] { versionNameToolStripMenuItem, toolStripSeparator3, 詳細プレイデータToolStripMenuItem, AccountToolStrip, ゲームログ開発者向けToolStripMenuItem, 現在のアカウント情報を取得ToolStripMenuItem, toolStripSeparator2, 設定ToolStripMenuItem, toolStripSeparator1, 終了ToolStripMenuItem, consoleToolStripMenuItem, testToolStripMenuItem });
            NotificationMenu.Name = "contextMenuStrip1";
            // 
            // versionNameToolStripMenuItem
            // 
            resources.ApplyResources(versionNameToolStripMenuItem, "versionNameToolStripMenuItem");
            versionNameToolStripMenuItem.Name = "versionNameToolStripMenuItem";
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // 詳細プレイデータToolStripMenuItem
            // 
            resources.ApplyResources(詳細プレイデータToolStripMenuItem, "詳細プレイデータToolStripMenuItem");
            詳細プレイデータToolStripMenuItem.Name = "詳細プレイデータToolStripMenuItem";
            詳細プレイデータToolStripMenuItem.Click += 詳細プレイデータToolStripMenuItem_Click;
            // 
            // AccountToolStrip
            // 
            resources.ApplyResources(AccountToolStrip, "AccountToolStrip");
            AccountToolStrip.DropDownItems.AddRange(new ToolStripItem[] { emptyToolStripMenuItem });
            AccountToolStrip.Name = "AccountToolStrip";
            // 
            // emptyToolStripMenuItem
            // 
            resources.ApplyResources(emptyToolStripMenuItem, "emptyToolStripMenuItem");
            emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            // 
            // ゲームログ開発者向けToolStripMenuItem
            // 
            resources.ApplyResources(ゲームログ開発者向けToolStripMenuItem, "ゲームログ開発者向けToolStripMenuItem");
            ゲームログ開発者向けToolStripMenuItem.Name = "ゲームログ開発者向けToolStripMenuItem";
            ゲームログ開発者向けToolStripMenuItem.Click += ゲームログ開発者向けToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // 設定ToolStripMenuItem
            // 
            resources.ApplyResources(設定ToolStripMenuItem, "設定ToolStripMenuItem");
            設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            設定ToolStripMenuItem.Click += 設定ToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // 終了ToolStripMenuItem
            // 
            resources.ApplyResources(終了ToolStripMenuItem, "終了ToolStripMenuItem");
            終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            終了ToolStripMenuItem.Click += 終了ToolStripMenuItem_Click;
            // 
            // consoleToolStripMenuItem
            // 
            resources.ApplyResources(consoleToolStripMenuItem, "consoleToolStripMenuItem");
            consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            consoleToolStripMenuItem.Click += consoleToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            resources.ApplyResources(testToolStripMenuItem, "testToolStripMenuItem");
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Click += testToolStripMenuItem_ClickAsync;
            // 
            // Delay
            // 
            Delay.Enabled = true;
            Delay.Tick += Delay_Tick;
            // 
            // 現在のアカウント情報を取得ToolStripMenuItem
            // 
            resources.ApplyResources(現在のアカウント情報を取得ToolStripMenuItem, "現在のアカウント情報を取得ToolStripMenuItem");
            現在のアカウント情報を取得ToolStripMenuItem.Name = "現在のアカウント情報を取得ToolStripMenuItem";
            現在のアカウント情報を取得ToolStripMenuItem.Click += 現在のアカウント情報を取得ToolStripMenuItem_Click;
            // 
            // MainTray
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = resource.namecard.Genshin_Impact_A_New_World;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainTray";
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            FormClosing += MainTray_FormClosing;
            Load += MainTray_Load;
            NotificationMenu.ResumeLayout(false);
            ResumeLayout(false);
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
        private ToolStripMenuItem 現在のアカウント情報を取得ToolStripMenuItem;
    }
}