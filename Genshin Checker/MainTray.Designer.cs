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
            FuncDetailTime = new ToolStripMenuItem();
            AccountToolStrip = new ToolStripMenuItem();
            emptyToolStripMenuItem = new ToolStripMenuItem();
            FuncGameLog = new ToolStripMenuItem();
            FuncAnalyzeItem = new ToolStripMenuItem();
            FuncCodeExchange = new ToolStripMenuItem();
            FuncMusicPlayer = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            FuncSetting = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            FuncShortcut1 = new ToolStripMenuItem();
            FuncShortcut2 = new ToolStripMenuItem();
            FuncShortcut3 = new ToolStripMenuItem();
            FuncShortcut4 = new ToolStripMenuItem();
            FuncShortcut5 = new ToolStripMenuItem();
            FuncShortcut6 = new ToolStripMenuItem();
            FuncShortcut7 = new ToolStripMenuItem();
            FuncShortcut8 = new ToolStripMenuItem();
            ShortcutSeparator = new ToolStripSeparator();
            FuncExit = new ToolStripMenuItem();
            FuncConsole = new ToolStripMenuItem();
            FuncTestFunction = new ToolStripMenuItem();
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
            NotificationMenu.Items.AddRange(new ToolStripItem[] { versionNameToolStripMenuItem, toolStripSeparator3, FuncDetailTime, AccountToolStrip, FuncGameLog, FuncAnalyzeItem, FuncCodeExchange, FuncMusicPlayer, toolStripSeparator2, FuncSetting, toolStripSeparator1, FuncShortcut1, FuncShortcut2, FuncShortcut3, FuncShortcut4, FuncShortcut5, FuncShortcut6, FuncShortcut7, FuncShortcut8, ShortcutSeparator, FuncExit, FuncConsole, FuncTestFunction });
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
            // FuncDetailTime
            // 
            FuncDetailTime.Name = "FuncDetailTime";
            resources.ApplyResources(FuncDetailTime, "FuncDetailTime");
            FuncDetailTime.Click += UIFunction;
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
            // FuncGameLog
            // 
            FuncGameLog.Name = "FuncGameLog";
            resources.ApplyResources(FuncGameLog, "FuncGameLog");
            FuncGameLog.Click += UIFunction;
            // 
            // FuncAnalyzeItem
            // 
            FuncAnalyzeItem.Name = "FuncAnalyzeItem";
            resources.ApplyResources(FuncAnalyzeItem, "FuncAnalyzeItem");
            FuncAnalyzeItem.Click += UIFunction;
            // 
            // FuncCodeExchange
            // 
            FuncCodeExchange.Name = "FuncCodeExchange";
            resources.ApplyResources(FuncCodeExchange, "FuncCodeExchange");
            FuncCodeExchange.Click += UIFunction;
            // 
            // FuncMusicPlayer
            // 
            FuncMusicPlayer.Name = "FuncMusicPlayer";
            resources.ApplyResources(FuncMusicPlayer, "FuncMusicPlayer");
            FuncMusicPlayer.Click += UIFunction;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // FuncSetting
            // 
            FuncSetting.Name = "FuncSetting";
            resources.ApplyResources(FuncSetting, "FuncSetting");
            FuncSetting.Click += UIFunction;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // FuncShortcut1
            // 
            FuncShortcut1.Name = "FuncShortcut1";
            resources.ApplyResources(FuncShortcut1, "FuncShortcut1");
            // 
            // FuncShortcut2
            // 
            FuncShortcut2.Name = "FuncShortcut2";
            resources.ApplyResources(FuncShortcut2, "FuncShortcut2");
            // 
            // FuncShortcut3
            // 
            FuncShortcut3.Name = "FuncShortcut3";
            resources.ApplyResources(FuncShortcut3, "FuncShortcut3");
            // 
            // FuncShortcut4
            // 
            FuncShortcut4.Name = "FuncShortcut4";
            resources.ApplyResources(FuncShortcut4, "FuncShortcut4");
            // 
            // FuncShortcut5
            // 
            FuncShortcut5.Name = "FuncShortcut5";
            resources.ApplyResources(FuncShortcut5, "FuncShortcut5");
            // 
            // FuncShortcut6
            // 
            FuncShortcut6.Name = "FuncShortcut6";
            resources.ApplyResources(FuncShortcut6, "FuncShortcut6");
            // 
            // FuncShortcut7
            // 
            FuncShortcut7.Name = "FuncShortcut7";
            resources.ApplyResources(FuncShortcut7, "FuncShortcut7");
            // 
            // FuncShortcut8
            // 
            FuncShortcut8.Name = "FuncShortcut8";
            resources.ApplyResources(FuncShortcut8, "FuncShortcut8");
            // 
            // ShortcutSeparator
            // 
            ShortcutSeparator.Name = "ShortcutSeparator";
            resources.ApplyResources(ShortcutSeparator, "ShortcutSeparator");
            // 
            // FuncExit
            // 
            FuncExit.Name = "FuncExit";
            resources.ApplyResources(FuncExit, "FuncExit");
            FuncExit.Click += UIFunction;
            // 
            // FuncConsole
            // 
            FuncConsole.Name = "FuncConsole";
            resources.ApplyResources(FuncConsole, "FuncConsole");
            FuncConsole.Click += UIFunction;
            // 
            // FuncTestFunction
            // 
            FuncTestFunction.Name = "FuncTestFunction";
            resources.ApplyResources(FuncTestFunction, "FuncTestFunction");
            FuncTestFunction.Click += UIFunction;
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
        private ToolStripMenuItem FuncSetting;
        private ToolStripMenuItem FuncExit;
        private System.Windows.Forms.Timer Delay;
        private ToolStripMenuItem FuncDetailTime;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem FuncTestFunction;
        private ToolStripMenuItem versionNameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem FuncGameLog;
        private ToolStripMenuItem AccountToolStrip;
        private ToolStripMenuItem emptyToolStripMenuItem;
        private ToolStripMenuItem FuncConsole;
        private ToolStripMenuItem FuncAnalyzeItem;
        private ToolStripMenuItem FuncShortcut1;
        private ToolStripMenuItem FuncShortcut2;
        private ToolStripMenuItem FuncShortcut3;
        private ToolStripMenuItem FuncShortcut4;
        private ToolStripMenuItem FuncShortcut5;
        private ToolStripMenuItem FuncShortcut6;
        private ToolStripMenuItem FuncShortcut7;
        private ToolStripMenuItem FuncShortcut8;
        private ToolStripSeparator ShortcutSeparator;
        private ToolStripMenuItem FuncCodeExchange;
        private ToolStripMenuItem FuncMusicPlayer;
    }
}