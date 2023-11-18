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
            this.ExContain_MapProgress1 = new System.Windows.Forms.Panel();
            this.ExContain_ProgressPanel = new System.Windows.Forms.Panel();
            this.ExContain_ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.ExContain_ProgressLabel1 = new System.Windows.Forms.Label();
            this.ExContain_HiddenableName1 = new System.Windows.Forms.Label();
            this.ExContain_MapProgress1.SuspendLayout();
            this.ExContain_ProgressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExContain_MapProgress1
            // 
            this.ExContain_MapProgress1.AutoSize = true;
            this.ExContain_MapProgress1.Controls.Add(this.ExContain_ProgressPanel);
            this.ExContain_MapProgress1.Controls.Add(this.ExContain_HiddenableName1);
            this.ExContain_MapProgress1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_MapProgress1.Location = new System.Drawing.Point(0, 0);
            this.ExContain_MapProgress1.Name = "ExContain_MapProgress1";
            this.ExContain_MapProgress1.Size = new System.Drawing.Size(313, 47);
            this.ExContain_MapProgress1.TabIndex = 6;
            // 
            // ExContain_ProgressPanel
            // 
            this.ExContain_ProgressPanel.Controls.Add(this.ExContain_ProgressBar1);
            this.ExContain_ProgressPanel.Controls.Add(this.ExContain_ProgressLabel1);
            this.ExContain_ProgressPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_ProgressPanel.Location = new System.Drawing.Point(0, 24);
            this.ExContain_ProgressPanel.Name = "ExContain_ProgressPanel";
            this.ExContain_ProgressPanel.Size = new System.Drawing.Size(313, 23);
            this.ExContain_ProgressPanel.TabIndex = 1;
            // 
            // ExContain_ProgressBar1
            // 
            this.ExContain_ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExContain_ProgressBar1.Location = new System.Drawing.Point(0, 0);
            this.ExContain_ProgressBar1.Maximum = 1000;
            this.ExContain_ProgressBar1.Name = "ExContain_ProgressBar1";
            this.ExContain_ProgressBar1.Size = new System.Drawing.Size(236, 23);
            this.ExContain_ProgressBar1.TabIndex = 1;
            this.ExContain_ProgressBar1.Value = 80;
            // 
            // ExContain_ProgressLabel1
            // 
            this.ExContain_ProgressLabel1.AutoSize = true;
            this.ExContain_ProgressLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExContain_ProgressLabel1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExContain_ProgressLabel1.Location = new System.Drawing.Point(236, 0);
            this.ExContain_ProgressLabel1.Name = "ExContain_ProgressLabel1";
            this.ExContain_ProgressLabel1.Size = new System.Drawing.Size(77, 20);
            this.ExContain_ProgressLabel1.TabIndex = 2;
            this.ExContain_ProgressLabel1.Text = "999.9%";
            // 
            // ExContain_HiddenableName1
            // 
            this.ExContain_HiddenableName1.AutoSize = true;
            this.ExContain_HiddenableName1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_HiddenableName1.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExContain_HiddenableName1.Location = new System.Drawing.Point(0, 0);
            this.ExContain_HiddenableName1.Name = "ExContain_HiddenableName1";
            this.ExContain_HiddenableName1.Size = new System.Drawing.Size(167, 24);
            this.ExContain_HiddenableName1.TabIndex = 0;
            this.ExContain_HiddenableName1.Text = "非表示にできる地名";
            this.ExContain_HiddenableName1.Visible = false;
            // 
            // ExplorationProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ExContain_MapProgress1);
            this.Name = "ExplorationProgressBar";
            this.Size = new System.Drawing.Size(313, 47);
            this.ExContain_MapProgress1.ResumeLayout(false);
            this.ExContain_MapProgress1.PerformLayout();
            this.ExContain_ProgressPanel.ResumeLayout(false);
            this.ExContain_ProgressPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel ExContain_MapProgress1;
        private Panel ExContain_ProgressPanel;
        private ProgressBar ExContain_ProgressBar1;
        private Label ExContain_ProgressLabel1;
        private Label ExContain_HiddenableName1;
    }
}
