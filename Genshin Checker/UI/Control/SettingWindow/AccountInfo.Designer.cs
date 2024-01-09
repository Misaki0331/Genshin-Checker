namespace Genshin_Checker.UI.Control.SettingWindow
{
    partial class AccountInfo
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AdventureRank = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.UserName = new System.Windows.Forms.Label();
            this.Infomation = new System.Windows.Forms.Label();
            this.UID = new System.Windows.Forms.Label();
            this.Background = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.AdventureRank, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.UserName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Infomation, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.UID, 2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // AdventureRank
            // 
            resources.ApplyResources(this.AdventureRank, "AdventureRank");
            this.AdventureRank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AdventureRank.Name = "AdventureRank";
            this.tableLayoutPanel1.SetRowSpan(this.AdventureRank, 3);
            this.AdventureRank.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPaint);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.UserName, 2);
            resources.ApplyResources(this.UserName, "UserName");
            this.UserName.ForeColor = System.Drawing.Color.White;
            this.UserName.Name = "UserName";
            this.UserName.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPaint);
            // 
            // Infomation
            // 
            resources.ApplyResources(this.Infomation, "Infomation");
            this.Infomation.ForeColor = System.Drawing.Color.White;
            this.Infomation.Name = "Infomation";
            this.tableLayoutPanel1.SetRowSpan(this.Infomation, 2);
            this.Infomation.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPaint);
            // 
            // UID
            // 
            resources.ApplyResources(this.UID, "UID");
            this.UID.ForeColor = System.Drawing.Color.White;
            this.UID.Name = "UID";
            this.UID.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPaint);
            // 
            // Background
            // 
            resources.ApplyResources(this.Background, "Background");
            this.Background.Name = "Background";
            this.Background.TabStop = false;
            // 
            // AccountInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Background);
            this.Name = "AccountInfo";
            this.Load += new System.EventHandler(this.ControlLoad);
            this.SizeChanged += new System.EventHandler(this.AccountInfo_SizeChanged);
            this.Resize += new System.EventHandler(this.AccountInfo_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label AdventureRank;
        private Button button1;
        private Label UserName;
        private Label Infomation;
        private PictureBox Background;
        private Label UID;
    }
}
