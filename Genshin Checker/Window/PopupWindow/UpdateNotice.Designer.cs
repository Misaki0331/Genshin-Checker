namespace Genshin_Checker.Window.PopupWindow
{
    partial class UpdateNotice
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            VersionText = new Label();
            LatestUpdate = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            Body = new TextBox();
            panel4 = new Panel();
            DownloadCount = new Label();
            label6 = new Label();
            DownloadSize = new Label();
            label4 = new Label();
            panel5 = new Panel();
            OpenLink = new Button();
            CloseLink = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(96, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Meiryo UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(306, 26);
            label1.TabIndex = 2;
            label1.Text = "新しいバージョンが利用可能です。";
            // 
            // VersionText
            // 
            VersionText.AutoSize = true;
            VersionText.Dock = DockStyle.Bottom;
            VersionText.Font = new Font("Meiryo UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            VersionText.Location = new Point(0, 50);
            VersionText.Name = "VersionText";
            VersionText.Size = new Size(187, 26);
            VersionText.TabIndex = 3;
            VersionText.Text = "0.14.1 → 0.15.0";
            // 
            // LatestUpdate
            // 
            LatestUpdate.AutoSize = true;
            LatestUpdate.Dock = DockStyle.Bottom;
            LatestUpdate.Font = new Font("Meiryo UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LatestUpdate.Location = new Point(0, 76);
            LatestUpdate.Name = "LatestUpdate";
            LatestUpdate.Size = new Size(275, 20);
            LatestUpdate.TabIndex = 4;
            LatestUpdate.Text = "更新時刻 : 20XX/XX/XX XX:XX:XX";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(666, 116);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Controls.Add(VersionText);
            panel2.Controls.Add(LatestUpdate);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(106, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(550, 96);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(Body);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 116);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10, 0, 10, 0);
            panel3.Size = new Size(666, 237);
            panel3.TabIndex = 6;
            // 
            // Body
            // 
            Body.Dock = DockStyle.Fill;
            Body.Location = new Point(10, 0);
            Body.Multiline = true;
            Body.Name = "Body";
            Body.ReadOnly = true;
            Body.ScrollBars = ScrollBars.Both;
            Body.Size = new Size(498, 237);
            Body.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Controls.Add(DownloadCount);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(DownloadSize);
            panel4.Controls.Add(label4);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(508, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(148, 237);
            panel4.TabIndex = 0;
            // 
            // DownloadCount
            // 
            DownloadCount.Dock = DockStyle.Top;
            DownloadCount.Location = new Point(0, 65);
            DownloadCount.Name = "DownloadCount";
            DownloadCount.Size = new Size(148, 15);
            DownloadCount.TabIndex = 3;
            DownloadCount.Text = "0";
            DownloadCount.TextAlign = ContentAlignment.TopRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Location = new Point(0, 30);
            label6.Name = "label6";
            label6.Padding = new Padding(0, 20, 0, 0);
            label6.Size = new Size(83, 35);
            label6.TabIndex = 2;
            label6.Text = "ダウンロード回数";
            // 
            // DownloadSize
            // 
            DownloadSize.Dock = DockStyle.Top;
            DownloadSize.Location = new Point(0, 15);
            DownloadSize.Name = "DownloadSize";
            DownloadSize.Size = new Size(148, 15);
            DownloadSize.TabIndex = 1;
            DownloadSize.Text = "12.345 MB";
            DownloadSize.TextAlign = ContentAlignment.TopRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 0;
            label4.Text = "ダウンロードサイズ";
            // 
            // panel5
            // 
            panel5.Controls.Add(OpenLink);
            panel5.Controls.Add(CloseLink);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 353);
            panel5.Name = "panel5";
            panel5.Size = new Size(666, 23);
            panel5.TabIndex = 2;
            // 
            // OpenLink
            // 
            OpenLink.Dock = DockStyle.Right;
            OpenLink.Location = new Point(516, 0);
            OpenLink.Name = "OpenLink";
            OpenLink.Size = new Size(75, 23);
            OpenLink.TabIndex = 1;
            OpenLink.Text = "ページを開く";
            OpenLink.UseVisualStyleBackColor = true;
            OpenLink.Click += OpenLink_Click;
            // 
            // CloseLink
            // 
            CloseLink.Dock = DockStyle.Right;
            CloseLink.Location = new Point(591, 0);
            CloseLink.Name = "CloseLink";
            CloseLink.Size = new Size(75, 23);
            CloseLink.TabIndex = 0;
            CloseLink.Text = "後で";
            CloseLink.UseVisualStyleBackColor = true;
            CloseLink.Click += CloseLink_Click;
            // 
            // UpdateNotice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 376);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Name = "UpdateNotice";
            Text = "UpdateNotice";
            Load += UpdateNotice_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label VersionText;
        private Label LatestUpdate;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label DownloadCount;
        private Label label6;
        private Label DownloadSize;
        private Label label4;
        private TextBox Body;
        private Panel panel5;
        private Button OpenLink;
        private Button CloseLink;
    }
}