namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    partial class EnemyInfo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelName.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelName.Location = new System.Drawing.Point(24, 0);
            this.LabelName.MinimumSize = new System.Drawing.Size(0, 24);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(115, 24);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "EnemyName";
            this.LabelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelLevel
            // 
            this.LabelLevel.AutoSize = true;
            this.LabelLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelLevel.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelLevel.Location = new System.Drawing.Point(139, 0);
            this.LabelLevel.MinimumSize = new System.Drawing.Size(0, 24);
            this.LabelLevel.Name = "LabelLevel";
            this.LabelLevel.Size = new System.Drawing.Size(44, 24);
            this.LabelLevel.TabIndex = 2;
            this.LabelLevel.Text = "Lv.100";
            this.LabelLevel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // EnemyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.LabelLevel);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(320, 24);
            this.Name = "EnemyInfo";
            this.Size = new System.Drawing.Size(320, 24);
            this.Load += new System.EventHandler(this.EnemyInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label LabelName;
        private Label LabelLevel;
    }
}
