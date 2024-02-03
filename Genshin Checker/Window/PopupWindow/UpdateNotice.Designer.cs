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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateNotice));
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
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // VersionText
            // 
            resources.ApplyResources(VersionText, "VersionText");
            VersionText.Name = "VersionText";
            // 
            // LatestUpdate
            // 
            resources.ApplyResources(LatestUpdate, "LatestUpdate");
            LatestUpdate.Name = "LatestUpdate";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pictureBox1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // panel2
            // 
            panel2.Controls.Add(VersionText);
            panel2.Controls.Add(LatestUpdate);
            panel2.Controls.Add(label1);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // panel3
            // 
            panel3.Controls.Add(Body);
            panel3.Controls.Add(panel4);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // Body
            // 
            resources.ApplyResources(Body, "Body");
            Body.Name = "Body";
            Body.ReadOnly = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(DownloadCount);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(DownloadSize);
            panel4.Controls.Add(label4);
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // DownloadCount
            // 
            resources.ApplyResources(DownloadCount, "DownloadCount");
            DownloadCount.Name = "DownloadCount";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // DownloadSize
            // 
            resources.ApplyResources(DownloadSize, "DownloadSize");
            DownloadSize.Name = "DownloadSize";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // panel5
            // 
            panel5.Controls.Add(OpenLink);
            panel5.Controls.Add(CloseLink);
            resources.ApplyResources(panel5, "panel5");
            panel5.Name = "panel5";
            // 
            // OpenLink
            // 
            resources.ApplyResources(OpenLink, "OpenLink");
            OpenLink.Name = "OpenLink";
            OpenLink.UseVisualStyleBackColor = true;
            OpenLink.Click += OpenLink_Click;
            // 
            // CloseLink
            // 
            resources.ApplyResources(CloseLink, "CloseLink");
            CloseLink.Name = "CloseLink";
            CloseLink.UseVisualStyleBackColor = true;
            CloseLink.Click += CloseLink_Click;
            // 
            // UpdateNotice
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Name = "UpdateNotice";
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