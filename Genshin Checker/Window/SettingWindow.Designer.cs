namespace Genshin_Checker.Window
{
    partial class SettingWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingWindow));
            tabControl1 = new TabControl();
            page_general = new TabPage();
            groupBox7 = new GroupBox();
            label8 = new Label();
            IsScreenShotNotify = new CheckBox();
            IsScreenShotAfterDelete = new CheckBox();
            panel6 = new Panel();
            ScreenShotTransferFileFormat = new TextBox();
            ScreenShotTransferImageType = new ComboBox();
            label5 = new Label();
            panel5 = new Panel();
            ScreenShotTransferDirectry = new TextBox();
            button1 = new Button();
            label2 = new Label();
            panel4 = new Panel();
            ScreenshotPath = new TextBox();
            ButtonScreenShotPathAuto = new Button();
            IsScreenShotRaise = new CheckBox();
            groupBox6 = new GroupBox();
            IsCountBackground = new CheckBox();
            page_notification = new TabPage();
            groupBox3 = new GroupBox();
            TabAccountNotify = new TabControl();
            groupBox2 = new GroupBox();
            IsNotificationGameClosed = new CheckBox();
            IsNotificationGameStart = new CheckBox();
            page_auth = new TabPage();
            groupBox8 = new GroupBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            panel1 = new Panel();
            Open_HoYoLabAuth = new Button();
            page_about = new TabPage();
            groupBox5 = new GroupBox();
            panel3 = new Panel();
            OpenAuthorGitHub = new Button();
            OpenAuthorMisskey = new Button();
            label6 = new Label();
            groupBox4 = new GroupBox();
            panel2 = new Panel();
            OpenGitHubReleases = new Button();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            tabControl1.SuspendLayout();
            page_general.SuspendLayout();
            groupBox7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            groupBox6.SuspendLayout();
            page_notification.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            page_auth.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            page_about.SuspendLayout();
            groupBox5.SuspendLayout();
            panel3.SuspendLayout();
            groupBox4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(page_general);
            tabControl1.Controls.Add(page_notification);
            tabControl1.Controls.Add(page_auth);
            tabControl1.Controls.Add(page_about);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // page_general
            // 
            resources.ApplyResources(page_general, "page_general");
            page_general.Controls.Add(groupBox7);
            page_general.Controls.Add(groupBox6);
            page_general.Name = "page_general";
            page_general.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            resources.ApplyResources(groupBox7, "groupBox7");
            groupBox7.Controls.Add(label8);
            groupBox7.Controls.Add(IsScreenShotNotify);
            groupBox7.Controls.Add(IsScreenShotAfterDelete);
            groupBox7.Controls.Add(panel6);
            groupBox7.Controls.Add(label5);
            groupBox7.Controls.Add(panel5);
            groupBox7.Controls.Add(label2);
            groupBox7.Controls.Add(panel4);
            groupBox7.Name = "groupBox7";
            groupBox7.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // IsScreenShotNotify
            // 
            resources.ApplyResources(IsScreenShotNotify, "IsScreenShotNotify");
            IsScreenShotNotify.Name = "IsScreenShotNotify";
            IsScreenShotNotify.UseVisualStyleBackColor = true;
            IsScreenShotNotify.CheckedChanged += CheckedChanged;
            // 
            // IsScreenShotAfterDelete
            // 
            resources.ApplyResources(IsScreenShotAfterDelete, "IsScreenShotAfterDelete");
            IsScreenShotAfterDelete.Name = "IsScreenShotAfterDelete";
            IsScreenShotAfterDelete.UseVisualStyleBackColor = true;
            IsScreenShotAfterDelete.CheckedChanged += CheckedChanged;
            // 
            // panel6
            // 
            panel6.Controls.Add(ScreenShotTransferFileFormat);
            panel6.Controls.Add(ScreenShotTransferImageType);
            resources.ApplyResources(panel6, "panel6");
            panel6.Name = "panel6";
            // 
            // ScreenShotTransferFileFormat
            // 
            resources.ApplyResources(ScreenShotTransferFileFormat, "ScreenShotTransferFileFormat");
            ScreenShotTransferFileFormat.Name = "ScreenShotTransferFileFormat";
            ScreenShotTransferFileFormat.TextChanged += ScreenShotTransferFileFormat_TextChanged;
            // 
            // ScreenShotTransferImageType
            // 
            resources.ApplyResources(ScreenShotTransferImageType, "ScreenShotTransferImageType");
            ScreenShotTransferImageType.DropDownStyle = ComboBoxStyle.DropDownList;
            ScreenShotTransferImageType.FormattingEnabled = true;
            ScreenShotTransferImageType.Items.AddRange(new object[] { resources.GetString("ScreenShotTransferImageType.Items"), resources.GetString("ScreenShotTransferImageType.Items1"), resources.GetString("ScreenShotTransferImageType.Items2") });
            ScreenShotTransferImageType.Name = "ScreenShotTransferImageType";
            ScreenShotTransferImageType.SelectedIndexChanged += ScreenShotTransferImageType_SelectedIndexChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // panel5
            // 
            panel5.Controls.Add(ScreenShotTransferDirectry);
            panel5.Controls.Add(button1);
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // ScreenShotTransferDirectry
            // 
            resources.ApplyResources(ScreenShotTransferDirectry, "ScreenShotTransferDirectry");
            ScreenShotTransferDirectry.Name = "ScreenShotTransferDirectry";
            ScreenShotTransferDirectry.ReadOnly = true;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // panel4
            // 
            panel4.Controls.Add(ScreenshotPath);
            panel4.Controls.Add(ButtonScreenShotPathAuto);
            panel4.Controls.Add(IsScreenShotRaise);
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // ScreenshotPath
            // 
            resources.ApplyResources(ScreenshotPath, "ScreenshotPath");
            ScreenshotPath.Name = "ScreenshotPath";
            ScreenshotPath.ReadOnly = true;
            // 
            // ButtonScreenShotPathAuto
            // 
            resources.ApplyResources(ButtonScreenShotPathAuto, "ButtonScreenShotPathAuto");
            ButtonScreenShotPathAuto.Name = "ButtonScreenShotPathAuto";
            ButtonScreenShotPathAuto.UseVisualStyleBackColor = true;
            ButtonScreenShotPathAuto.Click += ButtonScreenShotPathAuto_Click;
            // 
            // IsScreenShotRaise
            // 
            resources.ApplyResources(IsScreenShotRaise, "IsScreenShotRaise");
            IsScreenShotRaise.Name = "IsScreenShotRaise";
            IsScreenShotRaise.UseVisualStyleBackColor = true;
            IsScreenShotRaise.CheckedChanged += CheckedChanged;
            // 
            // groupBox6
            // 
            resources.ApplyResources(groupBox6, "groupBox6");
            groupBox6.Controls.Add(IsCountBackground);
            groupBox6.Name = "groupBox6";
            groupBox6.TabStop = false;
            // 
            // IsCountBackground
            // 
            resources.ApplyResources(IsCountBackground, "IsCountBackground");
            IsCountBackground.Name = "IsCountBackground";
            IsCountBackground.UseVisualStyleBackColor = true;
            IsCountBackground.CheckedChanged += CheckedChanged;
            // 
            // page_notification
            // 
            page_notification.Controls.Add(groupBox3);
            page_notification.Controls.Add(groupBox2);
            resources.ApplyResources(page_notification, "page_notification");
            page_notification.Name = "page_notification";
            page_notification.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(TabAccountNotify);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            // 
            // TabAccountNotify
            // 
            resources.ApplyResources(TabAccountNotify, "TabAccountNotify");
            TabAccountNotify.Multiline = true;
            TabAccountNotify.Name = "TabAccountNotify";
            TabAccountNotify.SelectedIndex = 0;
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(IsNotificationGameClosed);
            groupBox2.Controls.Add(IsNotificationGameStart);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // IsNotificationGameClosed
            // 
            resources.ApplyResources(IsNotificationGameClosed, "IsNotificationGameClosed");
            IsNotificationGameClosed.Name = "IsNotificationGameClosed";
            IsNotificationGameClosed.UseVisualStyleBackColor = true;
            IsNotificationGameClosed.CheckedChanged += CheckedChanged;
            // 
            // IsNotificationGameStart
            // 
            resources.ApplyResources(IsNotificationGameStart, "IsNotificationGameStart");
            IsNotificationGameStart.Name = "IsNotificationGameStart";
            IsNotificationGameStart.UseVisualStyleBackColor = true;
            IsNotificationGameStart.CheckedChanged += CheckedChanged;
            // 
            // page_auth
            // 
            page_auth.Controls.Add(groupBox8);
            page_auth.Controls.Add(groupBox1);
            resources.ApplyResources(page_auth, "page_auth");
            page_auth.Name = "page_auth";
            page_auth.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            resources.ApplyResources(groupBox8, "groupBox8");
            groupBox8.Name = "groupBox8";
            groupBox8.TabStop = false;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(panel1);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // panel1
            // 
            panel1.Controls.Add(Open_HoYoLabAuth);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // Open_HoYoLabAuth
            // 
            resources.ApplyResources(Open_HoYoLabAuth, "Open_HoYoLabAuth");
            Open_HoYoLabAuth.Name = "Open_HoYoLabAuth";
            Open_HoYoLabAuth.UseVisualStyleBackColor = true;
            Open_HoYoLabAuth.Click += Open_HoYoLabAuth_Click;
            // 
            // page_about
            // 
            page_about.Controls.Add(groupBox5);
            page_about.Controls.Add(groupBox4);
            resources.ApplyResources(page_about, "page_about");
            page_about.Name = "page_about";
            page_about.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            resources.ApplyResources(groupBox5, "groupBox5");
            groupBox5.Controls.Add(panel3);
            groupBox5.Controls.Add(label6);
            groupBox5.Name = "groupBox5";
            groupBox5.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(OpenAuthorGitHub);
            panel3.Controls.Add(OpenAuthorMisskey);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // OpenAuthorGitHub
            // 
            resources.ApplyResources(OpenAuthorGitHub, "OpenAuthorGitHub");
            OpenAuthorGitHub.Name = "OpenAuthorGitHub";
            OpenAuthorGitHub.Tag = "https://github.com/Misaki0331/";
            OpenAuthorGitHub.UseVisualStyleBackColor = true;
            OpenAuthorGitHub.Click += OpenLink;
            // 
            // OpenAuthorMisskey
            // 
            resources.ApplyResources(OpenAuthorMisskey, "OpenAuthorMisskey");
            OpenAuthorMisskey.Name = "OpenAuthorMisskey";
            OpenAuthorMisskey.Tag = "https://misskey.io/@ms";
            OpenAuthorMisskey.UseVisualStyleBackColor = true;
            OpenAuthorMisskey.Click += OpenLink;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // groupBox4
            // 
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Controls.Add(panel2);
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label3);
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(OpenGitHubReleases);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // OpenGitHubReleases
            // 
            resources.ApplyResources(OpenGitHubReleases, "OpenGitHubReleases");
            OpenGitHubReleases.Name = "OpenGitHubReleases";
            OpenGitHubReleases.Tag = "https://github.com/Misaki0331/Genshin-Checker/releases/latest";
            OpenGitHubReleases.UseVisualStyleBackColor = true;
            OpenGitHubReleases.Click += OpenLink;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // SettingWindow
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(tabControl1);
            Name = "SettingWindow";
            Load += SettingWindow_Load;
            ResizeEnd += SettingResizeEnd;
            SizeChanged += SettingSizeChanged;
            tabControl1.ResumeLayout(false);
            page_general.ResumeLayout(false);
            page_general.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            page_notification.ResumeLayout(false);
            page_notification.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            page_auth.ResumeLayout(false);
            page_auth.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            page_about.ResumeLayout(false);
            page_about.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage page_general;
        private TabPage page_auth;
        private TabPage page_about;
        private TabPage page_notification;
        private GroupBox groupBox1;
        private Label label1;
        private Panel panel1;
        private Button Open_HoYoLabAuth;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private CheckBox IsNotificationGameClosed;
        private CheckBox IsNotificationGameStart;
        private GroupBox groupBox5;
        private Panel panel3;
        private Button OpenAuthorGitHub;
        private Button OpenAuthorMisskey;
        private Label label6;
        private GroupBox groupBox4;
        private Panel panel2;
        private Button OpenGitHubReleases;
        private Label label7;
        private Label label4;
        private Label label3;
        private GroupBox groupBox6;
        private CheckBox IsCountBackground;
        private GroupBox groupBox7;
        private Panel panel4;
        private CheckBox IsScreenShotRaise;
        private TextBox ScreenshotPath;
        private Button ButtonScreenShotPathAuto;
        private CheckBox IsScreenShotAfterDelete;
        private Panel panel6;
        private TextBox ScreenShotTransferFileFormat;
        private ComboBox ScreenShotTransferImageType;
        private Label label5;
        private Panel panel5;
        private TextBox ScreenShotTransferDirectry;
        private Button button1;
        private Label label2;
        private Label label8;
        private CheckBox IsScreenShotNotify;
        private GroupBox groupBox8;
        private TabControl TabAccountNotify;
    }
}