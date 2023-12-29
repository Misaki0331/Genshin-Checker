namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    partial class FloorInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorInfo));
            this.LabelArea = new System.Windows.Forms.Label();
            this.LabelInfomation = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelStars = new System.Windows.Forms.Label();
            this.LabelLatestUpdate = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelArea
            // 
            this.LabelArea.AutoSize = true;
            this.LabelArea.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelArea.Font = new System.Drawing.Font("Meiryo UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelArea.Location = new System.Drawing.Point(0, 0);
            this.LabelArea.Name = "LabelArea";
            this.LabelArea.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LabelArea.Size = new System.Drawing.Size(99, 37);
            this.LabelArea.TabIndex = 0;
            this.LabelArea.Text = "12 層";
            this.LabelArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelArea.Click += new System.EventHandler(this.ClickEvent);
            this.LabelArea.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
            // 
            // LabelInfomation
            // 
            this.LabelInfomation.BackColor = System.Drawing.Color.Transparent;
            this.LabelInfomation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LabelInfomation.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelInfomation.Location = new System.Drawing.Point(0, 58);
            this.LabelInfomation.Name = "LabelInfomation";
            this.LabelInfomation.Size = new System.Drawing.Size(345, 83);
            this.LabelInfomation.TabIndex = 1;
            this.LabelInfomation.Text = "地脈異常の文字列";
            this.LabelInfomation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LabelInfomation.Click += new System.EventHandler(this.ClickEvent);
            this.LabelInfomation.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.LabelArea);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LabelStars);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 38);
            this.panel1.TabIndex = 4;
            this.panel1.Click += new System.EventHandler(this.ClickEvent);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(173, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(38, 38);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(38, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ClickEvent);
            // 
            // LabelStars
            // 
            this.LabelStars.AutoSize = true;
            this.LabelStars.Dock = System.Windows.Forms.DockStyle.Right;
            this.LabelStars.Font = new System.Drawing.Font("Meiryo UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelStars.Location = new System.Drawing.Point(211, 0);
            this.LabelStars.Margin = new System.Windows.Forms.Padding(0);
            this.LabelStars.Name = "LabelStars";
            this.LabelStars.Size = new System.Drawing.Size(134, 37);
            this.LabelStars.TabIndex = 5;
            this.LabelStars.Text = "99 / 99";
            this.LabelStars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelStars.Click += new System.EventHandler(this.ClickEvent);
            this.LabelStars.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
            // 
            // LabelLatestUpdate
            // 
            this.LabelLatestUpdate.AutoSize = true;
            this.LabelLatestUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelLatestUpdate.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelLatestUpdate.Location = new System.Drawing.Point(0, 38);
            this.LabelLatestUpdate.Name = "LabelLatestUpdate";
            this.LabelLatestUpdate.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LabelLatestUpdate.Size = new System.Drawing.Size(254, 20);
            this.LabelLatestUpdate.TabIndex = 5;
            this.LabelLatestUpdate.Text = "最終更新 2023/12/25 12:34:56";
            this.LabelLatestUpdate.Click += new System.EventHandler(this.ClickEvent);
            this.LabelLatestUpdate.Paint += new System.Windows.Forms.PaintEventHandler(this.LabelPaint);
            // 
            // FloorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.LabelLatestUpdate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LabelInfomation);
            this.MaximumSize = new System.Drawing.Size(345, 141);
            this.MinimumSize = new System.Drawing.Size(345, 141);
            this.Name = "FloorInfo";
            this.Size = new System.Drawing.Size(345, 141);
            this.Load += new System.EventHandler(this.FloorInfo_Load);
            this.Click += new System.EventHandler(this.ClickEvent);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LabelArea;
        private Label LabelInfomation;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label LabelStars;
        private Label LabelLatestUpdate;
    }
}
