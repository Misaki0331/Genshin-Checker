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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.page_general = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.IsScreenShotRaise = new System.Windows.Forms.CheckBox();
            this.ScreenshotPath = new System.Windows.Forms.TextBox();
            this.ButtonScreenShotPathAuto = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.IsCountBackground = new System.Windows.Forms.CheckBox();
            this.page_notification = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IsNotificationRealTimeNoteTransformerReached = new System.Windows.Forms.CheckBox();
            this.IsNotificationRealTimeNoteExpeditionAllCompleted = new System.Windows.Forms.CheckBox();
            this.IsNotificationRealTimeNoteRealmCoinMax = new System.Windows.Forms.CheckBox();
            this.IsNotificationRealTimeNoteRealmCoin1800 = new System.Windows.Forms.CheckBox();
            this.IsNotificationRealTimeNoteResinMax = new System.Windows.Forms.CheckBox();
            this.IsNotificationRealTimeNoteResin120 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IsNotificationGameClosed = new System.Windows.Forms.CheckBox();
            this.IsNotificationGameStart = new System.Windows.Forms.CheckBox();
            this.page_auth = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelConnectedUID = new System.Windows.Forms.Label();
            this.Open_HoYoLabAuth = new System.Windows.Forms.Button();
            this.page_about = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OpenAuthorGitHub = new System.Windows.Forms.Button();
            this.OpenAuthorMisskey = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OpenGitHubReleases = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.page_general.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.page_notification.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.page_auth.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.page_about.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.page_general);
            this.tabControl1.Controls.Add(this.page_notification);
            this.tabControl1.Controls.Add(this.page_auth);
            this.tabControl1.Controls.Add(this.page_about);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 441);
            this.tabControl1.TabIndex = 0;
            // 
            // page_general
            // 
            this.page_general.Controls.Add(this.groupBox7);
            this.page_general.Controls.Add(this.groupBox6);
            this.page_general.Location = new System.Drawing.Point(27, 4);
            this.page_general.Name = "page_general";
            this.page_general.Padding = new System.Windows.Forms.Padding(3);
            this.page_general.Size = new System.Drawing.Size(593, 433);
            this.page_general.TabIndex = 0;
            this.page_general.Text = "全般";
            this.page_general.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.panel4);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 44);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(587, 100);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "スクリーンショット";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.IsScreenShotRaise);
            this.panel4.Controls.Add(this.ScreenshotPath);
            this.panel4.Controls.Add(this.ButtonScreenShotPathAuto);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(581, 27);
            this.panel4.TabIndex = 0;
            // 
            // IsScreenShotRaise
            // 
            this.IsScreenShotRaise.AutoSize = true;
            this.IsScreenShotRaise.Dock = System.Windows.Forms.DockStyle.Left;
            this.IsScreenShotRaise.Location = new System.Drawing.Point(0, 0);
            this.IsScreenShotRaise.Name = "IsScreenShotRaise";
            this.IsScreenShotRaise.Size = new System.Drawing.Size(86, 27);
            this.IsScreenShotRaise.TabIndex = 0;
            this.IsScreenShotRaise.Text = "検知有効化";
            this.IsScreenShotRaise.UseVisualStyleBackColor = true;
            this.IsScreenShotRaise.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // ScreenshotPath
            // 
            this.ScreenshotPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenshotPath.Location = new System.Drawing.Point(0, 0);
            this.ScreenshotPath.Name = "ScreenshotPath";
            this.ScreenshotPath.ReadOnly = true;
            this.ScreenshotPath.Size = new System.Drawing.Size(506, 23);
            this.ScreenshotPath.TabIndex = 1;
            // 
            // ButtonScreenShotPathAuto
            // 
            this.ButtonScreenShotPathAuto.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonScreenShotPathAuto.Location = new System.Drawing.Point(506, 0);
            this.ButtonScreenShotPathAuto.Name = "ButtonScreenShotPathAuto";
            this.ButtonScreenShotPathAuto.Size = new System.Drawing.Size(75, 27);
            this.ButtonScreenShotPathAuto.TabIndex = 2;
            this.ButtonScreenShotPathAuto.Text = "自動設定";
            this.ButtonScreenShotPathAuto.UseVisualStyleBackColor = true;
            this.ButtonScreenShotPathAuto.Click += new System.EventHandler(this.ButtonScreenShotPathAuto_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.AutoSize = true;
            this.groupBox6.Controls.Add(this.IsCountBackground);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(587, 41);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ゲーム時間のカウント";
            // 
            // IsCountBackground
            // 
            this.IsCountBackground.AutoSize = true;
            this.IsCountBackground.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsCountBackground.Location = new System.Drawing.Point(3, 19);
            this.IsCountBackground.Name = "IsCountBackground";
            this.IsCountBackground.Size = new System.Drawing.Size(581, 19);
            this.IsCountBackground.TabIndex = 1;
            this.IsCountBackground.Text = "バックグラウンド時もプレイ時間にカウントする";
            this.IsCountBackground.UseVisualStyleBackColor = true;
            this.IsCountBackground.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // page_notification
            // 
            this.page_notification.Controls.Add(this.groupBox3);
            this.page_notification.Controls.Add(this.groupBox2);
            this.page_notification.Location = new System.Drawing.Point(27, 4);
            this.page_notification.Name = "page_notification";
            this.page_notification.Padding = new System.Windows.Forms.Padding(3);
            this.page_notification.Size = new System.Drawing.Size(593, 433);
            this.page_notification.TabIndex = 4;
            this.page_notification.Text = "通知";
            this.page_notification.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.IsNotificationRealTimeNoteTransformerReached);
            this.groupBox3.Controls.Add(this.IsNotificationRealTimeNoteExpeditionAllCompleted);
            this.groupBox3.Controls.Add(this.IsNotificationRealTimeNoteRealmCoinMax);
            this.groupBox3.Controls.Add(this.IsNotificationRealTimeNoteRealmCoin1800);
            this.groupBox3.Controls.Add(this.IsNotificationRealTimeNoteResinMax);
            this.groupBox3.Controls.Add(this.IsNotificationRealTimeNoteResin120);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(587, 136);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "リアルタイムノートの通知 (HoYoLab連携必須)";
            // 
            // IsNotificationRealTimeNoteTransformerReached
            // 
            this.IsNotificationRealTimeNoteTransformerReached.AutoSize = true;
            this.IsNotificationRealTimeNoteTransformerReached.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsNotificationRealTimeNoteTransformerReached.Location = new System.Drawing.Point(3, 114);
            this.IsNotificationRealTimeNoteTransformerReached.Name = "IsNotificationRealTimeNoteTransformerReached";
            this.IsNotificationRealTimeNoteTransformerReached.Size = new System.Drawing.Size(581, 19);
            this.IsNotificationRealTimeNoteTransformerReached.TabIndex = 5;
            this.IsNotificationRealTimeNoteTransformerReached.Text = "参量物質変化器が使用可能";
            this.IsNotificationRealTimeNoteTransformerReached.UseVisualStyleBackColor = true;
            this.IsNotificationRealTimeNoteTransformerReached.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // IsNotificationRealTimeNoteExpeditionAllCompleted
            // 
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.AutoSize = true;
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.Location = new System.Drawing.Point(3, 95);
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.Name = "IsNotificationRealTimeNoteExpeditionAllCompleted";
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.Size = new System.Drawing.Size(581, 19);
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.TabIndex = 4;
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.Text = "探索派遣が全員完了";
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.UseVisualStyleBackColor = true;
            this.IsNotificationRealTimeNoteExpeditionAllCompleted.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // IsNotificationRealTimeNoteRealmCoinMax
            // 
            this.IsNotificationRealTimeNoteRealmCoinMax.AutoSize = true;
            this.IsNotificationRealTimeNoteRealmCoinMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsNotificationRealTimeNoteRealmCoinMax.Location = new System.Drawing.Point(3, 76);
            this.IsNotificationRealTimeNoteRealmCoinMax.Name = "IsNotificationRealTimeNoteRealmCoinMax";
            this.IsNotificationRealTimeNoteRealmCoinMax.Size = new System.Drawing.Size(581, 19);
            this.IsNotificationRealTimeNoteRealmCoinMax.TabIndex = 3;
            this.IsNotificationRealTimeNoteRealmCoinMax.Text = "塵歌壺の洞天宝銭が最大まで回復";
            this.IsNotificationRealTimeNoteRealmCoinMax.UseVisualStyleBackColor = true;
            this.IsNotificationRealTimeNoteRealmCoinMax.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // IsNotificationRealTimeNoteRealmCoin1800
            // 
            this.IsNotificationRealTimeNoteRealmCoin1800.AutoSize = true;
            this.IsNotificationRealTimeNoteRealmCoin1800.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsNotificationRealTimeNoteRealmCoin1800.Location = new System.Drawing.Point(3, 57);
            this.IsNotificationRealTimeNoteRealmCoin1800.Name = "IsNotificationRealTimeNoteRealmCoin1800";
            this.IsNotificationRealTimeNoteRealmCoin1800.Size = new System.Drawing.Size(581, 19);
            this.IsNotificationRealTimeNoteRealmCoin1800.TabIndex = 2;
            this.IsNotificationRealTimeNoteRealmCoin1800.Text = "塵歌壺の洞天宝銭が1800以上";
            this.IsNotificationRealTimeNoteRealmCoin1800.UseVisualStyleBackColor = true;
            this.IsNotificationRealTimeNoteRealmCoin1800.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // IsNotificationRealTimeNoteResinMax
            // 
            this.IsNotificationRealTimeNoteResinMax.AutoSize = true;
            this.IsNotificationRealTimeNoteResinMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsNotificationRealTimeNoteResinMax.Location = new System.Drawing.Point(3, 38);
            this.IsNotificationRealTimeNoteResinMax.Name = "IsNotificationRealTimeNoteResinMax";
            this.IsNotificationRealTimeNoteResinMax.Size = new System.Drawing.Size(581, 19);
            this.IsNotificationRealTimeNoteResinMax.TabIndex = 1;
            this.IsNotificationRealTimeNoteResinMax.Text = "樹脂の所持が最大まで回復";
            this.IsNotificationRealTimeNoteResinMax.UseVisualStyleBackColor = true;
            this.IsNotificationRealTimeNoteResinMax.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // IsNotificationRealTimeNoteResin120
            // 
            this.IsNotificationRealTimeNoteResin120.AutoSize = true;
            this.IsNotificationRealTimeNoteResin120.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsNotificationRealTimeNoteResin120.Location = new System.Drawing.Point(3, 19);
            this.IsNotificationRealTimeNoteResin120.Name = "IsNotificationRealTimeNoteResin120";
            this.IsNotificationRealTimeNoteResin120.Size = new System.Drawing.Size(581, 19);
            this.IsNotificationRealTimeNoteResin120.TabIndex = 0;
            this.IsNotificationRealTimeNoteResin120.Text = "樹脂の所持が120以上";
            this.IsNotificationRealTimeNoteResin120.UseVisualStyleBackColor = true;
            this.IsNotificationRealTimeNoteResin120.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.IsNotificationGameClosed);
            this.groupBox2.Controls.Add(this.IsNotificationGameStart);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 60);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ゲーム通知";
            // 
            // IsNotificationGameClosed
            // 
            this.IsNotificationGameClosed.AutoSize = true;
            this.IsNotificationGameClosed.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsNotificationGameClosed.Location = new System.Drawing.Point(3, 38);
            this.IsNotificationGameClosed.Name = "IsNotificationGameClosed";
            this.IsNotificationGameClosed.Size = new System.Drawing.Size(581, 19);
            this.IsNotificationGameClosed.TabIndex = 1;
            this.IsNotificationGameClosed.Text = "ゲーム終了時の通知";
            this.IsNotificationGameClosed.UseVisualStyleBackColor = true;
            this.IsNotificationGameClosed.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // IsNotificationGameStart
            // 
            this.IsNotificationGameStart.AutoSize = true;
            this.IsNotificationGameStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.IsNotificationGameStart.Location = new System.Drawing.Point(3, 19);
            this.IsNotificationGameStart.Name = "IsNotificationGameStart";
            this.IsNotificationGameStart.Size = new System.Drawing.Size(581, 19);
            this.IsNotificationGameStart.TabIndex = 0;
            this.IsNotificationGameStart.Text = "ゲーム起動時の通知";
            this.IsNotificationGameStart.UseVisualStyleBackColor = true;
            this.IsNotificationGameStart.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // page_auth
            // 
            this.page_auth.Controls.Add(this.groupBox1);
            this.page_auth.Location = new System.Drawing.Point(27, 4);
            this.page_auth.Name = "page_auth";
            this.page_auth.Padding = new System.Windows.Forms.Padding(3);
            this.page_auth.Size = new System.Drawing.Size(593, 433);
            this.page_auth.TabIndex = 1;
            this.page_auth.Text = "アプリ連携";
            this.page_auth.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HoYoLabとの連携";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "連携すると現在のアカウントステータスをリアルタイムで表示することができます。\r\n利用できる情報の例 : 樹脂、探索派遣、デイリー情報、旅人手帳等";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabelConnectedUID);
            this.panel1.Controls.Add(this.Open_HoYoLabAuth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 25);
            this.panel1.TabIndex = 0;
            // 
            // LabelConnectedUID
            // 
            this.LabelConnectedUID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelConnectedUID.Location = new System.Drawing.Point(117, 0);
            this.LabelConnectedUID.Name = "LabelConnectedUID";
            this.LabelConnectedUID.Size = new System.Drawing.Size(464, 25);
            this.LabelConnectedUID.TabIndex = 2;
            this.LabelConnectedUID.Text = "連携済みのUID : 0";
            this.LabelConnectedUID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Open_HoYoLabAuth
            // 
            this.Open_HoYoLabAuth.AutoSize = true;
            this.Open_HoYoLabAuth.Dock = System.Windows.Forms.DockStyle.Left;
            this.Open_HoYoLabAuth.Location = new System.Drawing.Point(0, 0);
            this.Open_HoYoLabAuth.Name = "Open_HoYoLabAuth";
            this.Open_HoYoLabAuth.Size = new System.Drawing.Size(117, 25);
            this.Open_HoYoLabAuth.TabIndex = 0;
            this.Open_HoYoLabAuth.Text = "ブラウザを開いて連携";
            this.Open_HoYoLabAuth.UseVisualStyleBackColor = true;
            this.Open_HoYoLabAuth.Click += new System.EventHandler(this.Open_HoYoLabAuth_Click);
            // 
            // page_about
            // 
            this.page_about.Controls.Add(this.groupBox5);
            this.page_about.Controls.Add(this.groupBox4);
            this.page_about.Location = new System.Drawing.Point(27, 4);
            this.page_about.Name = "page_about";
            this.page_about.Padding = new System.Windows.Forms.Padding(3);
            this.page_about.Size = new System.Drawing.Size(593, 433);
            this.page_about.TabIndex = 3;
            this.page_about.Text = "バージョン情報";
            this.page_about.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.panel3);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 93);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(587, 60);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "作者の情報";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.OpenAuthorGitHub);
            this.panel3.Controls.Add(this.OpenAuthorMisskey);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(581, 23);
            this.panel3.TabIndex = 4;
            // 
            // OpenAuthorGitHub
            // 
            this.OpenAuthorGitHub.AutoSize = true;
            this.OpenAuthorGitHub.Dock = System.Windows.Forms.DockStyle.Left;
            this.OpenAuthorGitHub.Location = new System.Drawing.Point(72, 0);
            this.OpenAuthorGitHub.Name = "OpenAuthorGitHub";
            this.OpenAuthorGitHub.Size = new System.Drawing.Size(72, 23);
            this.OpenAuthorGitHub.TabIndex = 3;
            this.OpenAuthorGitHub.Tag = "https://github.com/Misaki0331/";
            this.OpenAuthorGitHub.Text = "GitHub";
            this.OpenAuthorGitHub.UseVisualStyleBackColor = true;
            this.OpenAuthorGitHub.Click += new System.EventHandler(this.OpenLink);
            // 
            // OpenAuthorMisskey
            // 
            this.OpenAuthorMisskey.AutoSize = true;
            this.OpenAuthorMisskey.Dock = System.Windows.Forms.DockStyle.Left;
            this.OpenAuthorMisskey.Location = new System.Drawing.Point(0, 0);
            this.OpenAuthorMisskey.Name = "OpenAuthorMisskey";
            this.OpenAuthorMisskey.Size = new System.Drawing.Size(72, 23);
            this.OpenAuthorMisskey.TabIndex = 2;
            this.OpenAuthorMisskey.Tag = "https://misskey.io/@ms";
            this.OpenAuthorMisskey.Text = "Misskey";
            this.OpenAuthorMisskey.UseVisualStyleBackColor = true;
            this.OpenAuthorMisskey.Click += new System.EventHandler(this.OpenLink);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(3, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "このアプリの作者 : 水咲(みさき)";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(587, 90);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "バージョン情報";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.OpenGitHubReleases);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(581, 23);
            this.panel2.TabIndex = 3;
            // 
            // OpenGitHubReleases
            // 
            this.OpenGitHubReleases.AutoSize = true;
            this.OpenGitHubReleases.Dock = System.Windows.Forms.DockStyle.Left;
            this.OpenGitHubReleases.Location = new System.Drawing.Point(0, 0);
            this.OpenGitHubReleases.Name = "OpenGitHubReleases";
            this.OpenGitHubReleases.Size = new System.Drawing.Size(121, 23);
            this.OpenGitHubReleases.TabIndex = 2;
            this.OpenGitHubReleases.Tag = "https://github.com/Misaki0331/Genshin-Checker/releases/latest";
            this.OpenGitHubReleases.Text = "最新バージョンはこちら";
            this.OpenGitHubReleases.UseVisualStyleBackColor = true;
            this.OpenGitHubReleases.Click += new System.EventHandler(this.OpenLink);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(3, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "GitHub : https://github.com/Misaki0331/Genshin-Checker";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Version 0.2.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Genshin Checker ";
            // 
            // SettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingWindow";
            this.Text = "設定";
            this.Load += new System.EventHandler(this.SettingWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.page_general.ResumeLayout(false);
            this.page_general.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.page_notification.ResumeLayout(false);
            this.page_notification.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.page_auth.ResumeLayout(false);
            this.page_auth.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.page_about.ResumeLayout(false);
            this.page_about.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

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
        private Label LabelConnectedUID;
        private GroupBox groupBox3;
        private CheckBox IsNotificationRealTimeNoteTransformerReached;
        private CheckBox IsNotificationRealTimeNoteExpeditionAllCompleted;
        private CheckBox IsNotificationRealTimeNoteRealmCoinMax;
        private CheckBox IsNotificationRealTimeNoteRealmCoin1800;
        private CheckBox IsNotificationRealTimeNoteResinMax;
        private CheckBox IsNotificationRealTimeNoteResin120;
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
    }
}