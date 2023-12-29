namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    partial class LevelInfo
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelStar = new System.Windows.Forms.Panel();
            this.PanelBattleInfo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "第 1 間";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.PanelStar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 38);
            this.panel1.TabIndex = 1;
            // 
            // PanelStar
            // 
            this.PanelStar.AutoSize = true;
            this.PanelStar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelStar.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelStar.Location = new System.Drawing.Point(105, 0);
            this.PanelStar.Name = "PanelStar";
            this.PanelStar.Size = new System.Drawing.Size(0, 38);
            this.PanelStar.TabIndex = 1;
            // 
            // PanelBattleInfo
            // 
            this.PanelBattleInfo.AutoSize = true;
            this.PanelBattleInfo.BackColor = System.Drawing.Color.Transparent;
            this.PanelBattleInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBattleInfo.Location = new System.Drawing.Point(0, 62);
            this.PanelBattleInfo.Name = "PanelBattleInfo";
            this.PanelBattleInfo.Size = new System.Drawing.Size(348, 0);
            this.PanelBattleInfo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "踏破時間 : 20XX/XX/XX XX:XX:XX";
            // 
            // LevelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PanelBattleInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(350, 0);
            this.Name = "LevelInfo";
            this.Size = new System.Drawing.Size(348, 62);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel PanelBattleInfo;
        private Label label2;
        private Panel PanelStar;
    }
}
