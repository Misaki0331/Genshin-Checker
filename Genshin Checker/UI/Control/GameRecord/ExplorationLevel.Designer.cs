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
            ExContain_LevelPanel1 = new Panel();
            ExContain_LevelName1 = new Label();
            ExContain_LevelIcon1 = new PictureBox();
            ExContain_LevelPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ExContain_LevelIcon1).BeginInit();
            SuspendLayout();
            // 
            // ExContain_LevelPanel1
            // 
            ExContain_LevelPanel1.Controls.Add(ExContain_LevelName1);
            ExContain_LevelPanel1.Controls.Add(ExContain_LevelIcon1);
            ExContain_LevelPanel1.Dock = DockStyle.Top;
            ExContain_LevelPanel1.Location = new Point(0, 0);
            ExContain_LevelPanel1.Name = "ExContain_LevelPanel1";
            ExContain_LevelPanel1.Size = new Size(24, 24);
            ExContain_LevelPanel1.TabIndex = 5;
            // 
            // ExContain_LevelName1
            // 
            ExContain_LevelName1.AutoSize = true;
            ExContain_LevelName1.Dock = DockStyle.Left;
            ExContain_LevelName1.Font = new Font("Meiryo UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ExContain_LevelName1.Location = new Point(24, 0);
            ExContain_LevelName1.Name = "ExContain_LevelName1";
            ExContain_LevelName1.Size = new Size(149, 20);
            ExContain_LevelName1.TabIndex = 1;
            ExContain_LevelName1.Text = "何かしらのレベル : 99";
            // 
            // ExContain_LevelIcon1
            // 
            ExContain_LevelIcon1.Dock = DockStyle.Left;
            ExContain_LevelIcon1.Location = new Point(0, 0);
            ExContain_LevelIcon1.Name = "ExContain_LevelIcon1";
            ExContain_LevelIcon1.Size = new Size(24, 24);
            ExContain_LevelIcon1.SizeMode = PictureBoxSizeMode.StretchImage;
            ExContain_LevelIcon1.TabIndex = 0;
            ExContain_LevelIcon1.TabStop = false;
            // 
            // ExplorationLevel
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            Controls.Add(ExContain_LevelPanel1);
            MinimumSize = new Size(24, 24);
            Name = "ExplorationLevel";
            Size = new Size(24, 24);
            ExContain_LevelPanel1.ResumeLayout(false);
            ExContain_LevelPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ExContain_LevelIcon1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel ExContain_LevelPanel1;
        private Label ExContain_LevelName1;
        private PictureBox ExContain_LevelIcon1;
    }
}
