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
            現在のアカウント情報を取得ToolStripMenuItem = new ToolStripMenuItem();
            toolStripCodeExchange = new ToolStripMenuItem();
            func_musicplayer = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            設定ToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ShortcutFunction1 = new ToolStripMenuItem();
            ShortcutFunction2 = new ToolStripMenuItem();
            ShortcutFunction3 = new ToolStripMenuItem();
            ShortcutFunction4 = new ToolStripMenuItem();
            ShortcutFunction5 = new ToolStripMenuItem();
            ShortcutFunction6 = new ToolStripMenuItem();
            ShortcutFunction7 = new ToolStripMenuItem();
            ShortcutFunction8 = new ToolStripMenuItem();
            ShortcutSeparator = new ToolStripSeparator();
            終了ToolStripMenuItem = new ToolStripMenuItem();
            consoleToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            Delay = new System.Windows.Forms.Timer(components);
            NotificationMenu.SuspendLayout();
            SuspendLayout();
            // 
            // notification
            // 
            notification.ContextMenuStrip = NotificationMenu;
            resources.ApplyResources(notification, "notification");
            notification.MouseUp += notification_Click;
            // 
            // NotificationMenu
            // 
            NotificationMenu.Items.AddRange(new ToolStripItem[] { versionNameToolStripMenuItem, toolStripSeparator3, 詳細プレイデータToolStripMenuItem, AccountToolStrip, ゲームログ開発者向けToolStripMenuItem, 現在のアカウント情報を取得ToolStripMenuItem, toolStripCodeExchange, func_musicplayer, toolStripSeparator2, 設定ToolStripMenuItem, toolStripSeparator1, ShortcutFunction1, ShortcutFunction2, ShortcutFunction3, ShortcutFunction4, ShortcutFunction5, ShortcutFunction6, ShortcutFunction7, ShortcutFunction8, ShortcutSeparator, 終了ToolStripMenuItem, consoleToolStripMenuItem, testToolStripMenuItem });
            NotificationMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(NotificationMenu, "NotificationMenu");
            // 
            // versionNameToolStripMenuItem
            // 
            resources.ApplyResources(versionNameToolStripMenuItem, "versionNameToolStripMenuItem");
            versionNameToolStripMenuItem.Name = "versionNameToolStripMenuItem";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            // 
            // 詳細プレイデータToolStripMenuItem
            // 
            詳細プレイデータToolStripMenuItem.Name = "詳細プレイデータToolStripMenuItem";
            resources.ApplyResources(詳細プレイデータToolStripMenuItem, "詳細プレイデータToolStripMenuItem");
            詳細プレイデータToolStripMenuItem.Click += 詳細プレイデータToolStripMenuItem_Click;
            // 
            // AccountToolStrip
            // 
            AccountToolStrip.DropDownItems.AddRange(new ToolStripItem[] { emptyToolStripMenuItem });
            AccountToolStrip.Name = "AccountToolStrip";
            resources.ApplyResources(AccountToolStrip, "AccountToolStrip");
            // 
            // emptyToolStripMenuItem
            // 
            resources.ApplyResources(emptyToolStripMenuItem, "emptyToolStripMenuItem");
            emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            // 
            // ゲームログ開発者向けToolStripMenuItem
            // 
            ゲームログ開発者向けToolStripMenuItem.Name = "ゲームログ開発者向けToolStripMenuItem";
            resources.ApplyResources(ゲームログ開発者向けToolStripMenuItem, "ゲームログ開発者向けToolStripMenuItem");
            ゲームログ開発者向けToolStripMenuItem.Click += ゲームログ開発者向けToolStripMenuItem_Click;
            // 
            // 現在のアカウント情報を取得ToolStripMenuItem
            // 
            現在のアカウント情報を取得ToolStripMenuItem.Name = "現在のアカウント情報を取得ToolStripMenuItem";
            resources.ApplyResources(現在のアカウント情報を取得ToolStripMenuItem, "現在のアカウント情報を取得ToolStripMenuItem");
            現在のアカウント情報を取得ToolStripMenuItem.Click += 現在のアカウント情報を取得ToolStripMenuItem_Click;
            // 
            // toolStripCodeExchange
            // 
            toolStripCodeExchange.Name = "toolStripCodeExchange";
            resources.ApplyResources(toolStripCodeExchange, "toolStripCodeExchange");
            toolStripCodeExchange.Click += toolStripCodeExchange_Click;
            // 
            // func_musicplayer
            // 
            func_musicplayer.Name = "func_musicplayer";
            resources.ApplyResources(func_musicplayer, "func_musicplayer");
            func_musicplayer.Click += func_musicplayer_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            toolStripSeparator2.Click += toolStripSeparator2_Click;
            // 
            // 設定ToolStripMenuItem
            // 
            設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            resources.ApplyResources(設定ToolStripMenuItem, "設定ToolStripMenuItem");
            設定ToolStripMenuItem.Click += 設定ToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // ShortcutFunction1
            // 
            ShortcutFunction1.Name = "ShortcutFunction1";
            resources.ApplyResources(ShortcutFunction1, "ShortcutFunction1");
            // 
            // ShortcutFunction2
            // 
            ShortcutFunction2.Name = "ShortcutFunction2";
            resources.ApplyResources(ShortcutFunction2, "ShortcutFunction2");
            // 
            // ShortcutFunction3
            // 
            ShortcutFunction3.Name = "ShortcutFunction3";
            resources.ApplyResources(ShortcutFunction3, "ShortcutFunction3");
            // 
            // ShortcutFunction4
            // 
            ShortcutFunction4.Name = "ShortcutFunction4";
            resources.ApplyResources(ShortcutFunction4, "ShortcutFunction4");
            // 
            // ShortcutFunction5
            // 
            ShortcutFunction5.Name = "ShortcutFunction5";
            resources.ApplyResources(ShortcutFunction5, "ShortcutFunction5");
            // 
            // ShortcutFunction6
            // 
            ShortcutFunction6.Name = "ShortcutFunction6";
            resources.ApplyResources(ShortcutFunction6, "ShortcutFunction6");
            // 
            // ShortcutFunction7
            // 
            ShortcutFunction7.Name = "ShortcutFunction7";
            resources.ApplyResources(ShortcutFunction7, "ShortcutFunction7");
            // 
            // ShortcutFunction8
            // 
            ShortcutFunction8.Name = "ShortcutFunction8";
            resources.ApplyResources(ShortcutFunction8, "ShortcutFunction8");
            // 
            // ShortcutSeparator
            // 
            ShortcutSeparator.Name = "ShortcutSeparator";
            resources.ApplyResources(ShortcutSeparator, "ShortcutSeparator");
            // 
            // 終了ToolStripMenuItem
            // 
            終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            resources.ApplyResources(終了ToolStripMenuItem, "終了ToolStripMenuItem");
            終了ToolStripMenuItem.Click += 終了ToolStripMenuItem_Click;
            // 
            // consoleToolStripMenuItem
            // 
            consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            resources.ApplyResources(consoleToolStripMenuItem, "consoleToolStripMenuItem");
            consoleToolStripMenuItem.Click += consoleToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            resources.ApplyResources(testToolStripMenuItem, "testToolStripMenuItem");
            testToolStripMenuItem.Click += testToolStripMenuItem_ClickAsync;
            // 
            // Delay
            // 
            Delay.Enabled = true;
            Delay.Tick += Delay_Tick;
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
        private ToolStripMenuItem ShortcutFunction1;
        private ToolStripMenuItem ShortcutFunction2;
        private ToolStripMenuItem ShortcutFunction3;
        private ToolStripMenuItem ShortcutFunction4;
        private ToolStripMenuItem ShortcutFunction5;
        private ToolStripMenuItem ShortcutFunction6;
        private ToolStripMenuItem ShortcutFunction7;
        private ToolStripMenuItem ShortcutFunction8;
        private ToolStripSeparator ShortcutSeparator;
        private ToolStripMenuItem toolStripCodeExchange;
        private ToolStripMenuItem func_musicplayer;
    }
}