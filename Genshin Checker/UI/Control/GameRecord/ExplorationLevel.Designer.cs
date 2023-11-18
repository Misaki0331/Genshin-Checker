namespace Genshin_Checker.UI.Control.GameRecord
{
    partial class ExplorationLevel
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
            this.ExContain_LevelPanel1 = new System.Windows.Forms.Panel();
            this.ExContain_LevelName1 = new System.Windows.Forms.Label();
            this.ExContain_LevelIcon1 = new System.Windows.Forms.PictureBox();
            this.ExContain_LevelPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_LevelIcon1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExContain_LevelPanel1
            // 
            this.ExContain_LevelPanel1.Controls.Add(this.ExContain_LevelName1);
            this.ExContain_LevelPanel1.Controls.Add(this.ExContain_LevelIcon1);
            this.ExContain_LevelPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_LevelPanel1.Location = new System.Drawing.Point(0, 0);
            this.ExContain_LevelPanel1.Name = "ExContain_LevelPanel1";
            this.ExContain_LevelPanel1.Size = new System.Drawing.Size(24, 24);
            this.ExContain_LevelPanel1.TabIndex = 5;
            // 
            // ExContain_LevelName1
            // 
            this.ExContain_LevelName1.AutoSize = true;
            this.ExContain_LevelName1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExContain_LevelName1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExContain_LevelName1.Location = new System.Drawing.Point(24, 0);
            this.ExContain_LevelName1.Name = "ExContain_LevelName1";
            this.ExContain_LevelName1.Size = new System.Drawing.Size(149, 20);
            this.ExContain_LevelName1.TabIndex = 1;
            this.ExContain_LevelName1.Text = "何かしらのレベル : 99";
            // 
            // ExContain_LevelIcon1
            // 
            this.ExContain_LevelIcon1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExContain_LevelIcon1.Location = new System.Drawing.Point(0, 0);
            this.ExContain_LevelIcon1.Name = "ExContain_LevelIcon1";
            this.ExContain_LevelIcon1.Size = new System.Drawing.Size(24, 24);
            this.ExContain_LevelIcon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExContain_LevelIcon1.TabIndex = 0;
            this.ExContain_LevelIcon1.TabStop = false;
            // 
            // ExplorationLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ExContain_LevelPanel1);
            this.MinimumSize = new System.Drawing.Size(24, 24);
            this.Name = "ExplorationLevel";
            this.Size = new System.Drawing.Size(24, 24);
            this.ExContain_LevelPanel1.ResumeLayout(false);
            this.ExContain_LevelPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_LevelIcon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel ExContain_LevelPanel1;
        private Label ExContain_LevelName1;
        private PictureBox ExContain_LevelIcon1;
    }
}
