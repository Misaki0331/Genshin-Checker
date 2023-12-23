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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.AdventureRank = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.UserName = new System.Windows.Forms.Label();
            this.Infomation = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 83);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 83);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.AdventureRank, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.UserName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Infomation, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(410, 83);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // AdventureRank
            // 
            this.AdventureRank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdventureRank.Font = new System.Drawing.Font("Meiryo UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AdventureRank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.AdventureRank.Location = new System.Drawing.Point(0, 0);
            this.AdventureRank.Margin = new System.Windows.Forms.Padding(0);
            this.AdventureRank.Name = "AdventureRank";
            this.tableLayoutPanel1.SetRowSpan(this.AdventureRank, 3);
            this.AdventureRank.Size = new System.Drawing.Size(100, 83);
            this.AdventureRank.TabIndex = 0;
            this.AdventureRank.Text = "60";
            this.AdventureRank.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AdventureRank.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPaint);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(310, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "連携解除";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // UserName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.UserName, 2);
            this.UserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserName.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UserName.ForeColor = System.Drawing.Color.White;
            this.UserName.Location = new System.Drawing.Point(100, 0);
            this.UserName.Margin = new System.Windows.Forms.Padding(0);
            this.UserName.Name = "UserName";
            this.UserName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.UserName.Size = new System.Drawing.Size(310, 43);
            this.UserName.TabIndex = 0;
            this.UserName.Text = "水咲(みさき)";
            this.UserName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.UserName.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPaint);
            // 
            // Infomation
            // 
            this.Infomation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Infomation.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Infomation.ForeColor = System.Drawing.Color.White;
            this.Infomation.Location = new System.Drawing.Point(100, 48);
            this.Infomation.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.Infomation.Name = "Infomation";
            this.tableLayoutPanel1.SetRowSpan(this.Infomation, 2);
            this.Infomation.Size = new System.Drawing.Size(210, 35);
            this.Infomation.TabIndex = 1;
            this.Infomation.Text = "実績:1234件 螺旋:12-3\r\nログイン日数:1234日";
            this.Infomation.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPaint);
            // 
            // AccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(410, 83);
            this.Name = "AccountInfo";
            this.Size = new System.Drawing.Size(410, 83);
            this.Load += new System.EventHandler(this.ControlLoad);
            this.SizeChanged += new System.EventHandler(this.AccountInfo_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label AdventureRank;
        private Button button1;
        private Label UserName;
        private Label Infomation;
    }
}
