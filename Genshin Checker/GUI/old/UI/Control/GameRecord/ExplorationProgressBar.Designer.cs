namespace Genshin_Checker.UI.Control.GameRecord
{
    partial class ExplorationProgressBar
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
            ExContain_MapProgress1 = new Panel();
            ExContain_ProgressPanel = new Panel();
            ExContain_ProgressBar1 = new ProgressBar();
            ExContain_ProgressLabel1 = new Label();
            ExContain_HiddenableName1 = new Label();
            ExContain_MapProgress1.SuspendLayout();
            ExContain_ProgressPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ExContain_MapProgress1
            // 
            ExContain_MapProgress1.AutoSize = true;
            ExContain_MapProgress1.Controls.Add(ExContain_ProgressPanel);
            ExContain_MapProgress1.Controls.Add(ExContain_HiddenableName1);
            ExContain_MapProgress1.Dock = DockStyle.Top;
            ExContain_MapProgress1.Location = new Point(0, 0);
            ExContain_MapProgress1.Name = "ExContain_MapProgress1";
            ExContain_MapProgress1.Size = new Size(299, 47);
            ExContain_MapProgress1.TabIndex = 6;
            // 
            // ExContain_ProgressPanel
            // 
            ExContain_ProgressPanel.Controls.Add(ExContain_ProgressBar1);
            ExContain_ProgressPanel.Controls.Add(ExContain_ProgressLabel1);
            ExContain_ProgressPanel.Dock = DockStyle.Top;
            ExContain_ProgressPanel.Location = new Point(0, 24);
            ExContain_ProgressPanel.Name = "ExContain_ProgressPanel";
            ExContain_ProgressPanel.Size = new Size(299, 23);
            ExContain_ProgressPanel.TabIndex = 1;
            // 
            // ExContain_ProgressBar1
            // 
            ExContain_ProgressBar1.Dock = DockStyle.Fill;
            ExContain_ProgressBar1.Location = new Point(0, 0);
            ExContain_ProgressBar1.Maximum = 1000;
            ExContain_ProgressBar1.Name = "ExContain_ProgressBar1";
            ExContain_ProgressBar1.Size = new Size(222, 23);
            ExContain_ProgressBar1.TabIndex = 1;
            ExContain_ProgressBar1.Value = 80;
            // 
            // ExContain_ProgressLabel1
            // 
            ExContain_ProgressLabel1.AutoSize = true;
            ExContain_ProgressLabel1.Dock = DockStyle.Right;
            ExContain_ProgressLabel1.Font = new Font("Meiryo UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ExContain_ProgressLabel1.Location = new Point(222, 0);
            ExContain_ProgressLabel1.Name = "ExContain_ProgressLabel1";
            ExContain_ProgressLabel1.Size = new Size(77, 20);
            ExContain_ProgressLabel1.TabIndex = 2;
            ExContain_ProgressLabel1.Text = "999.9%";
            // 
            // ExContain_HiddenableName1
            // 
            ExContain_HiddenableName1.AutoSize = true;
            ExContain_HiddenableName1.Dock = DockStyle.Top;
            ExContain_HiddenableName1.Font = new Font("Meiryo UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            ExContain_HiddenableName1.Location = new Point(0, 0);
            ExContain_HiddenableName1.Name = "ExContain_HiddenableName1";
            ExContain_HiddenableName1.Size = new Size(167, 24);
            ExContain_HiddenableName1.TabIndex = 0;
            ExContain_HiddenableName1.Text = "非表示にできる地名";
            ExContain_HiddenableName1.Visible = false;
            // 
            // ExplorationProgressBar
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            Controls.Add(ExContain_MapProgress1);
            Name = "ExplorationProgressBar";
            Size = new Size(299, 47);
            ExContain_MapProgress1.ResumeLayout(false);
            ExContain_MapProgress1.PerformLayout();
            ExContain_ProgressPanel.ResumeLayout(false);
            ExContain_ProgressPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel ExContain_MapProgress1;
        private Panel ExContain_ProgressPanel;
        private ProgressBar ExContain_ProgressBar1;
        private Label ExContain_ProgressLabel1;
        private Label ExContain_HiddenableName1;
    }
}
