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
            label1 = new Label();
            panel1 = new Panel();
            PanelStar = new Panel();
            PanelBattleInfo = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Meiryo UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(105, 35);
            label1.TabIndex = 0;
            label1.Text = "第 1 間";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(PanelStar);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(348, 38);
            panel1.TabIndex = 1;
            // 
            // PanelStar
            // 
            PanelStar.AutoSize = true;
            PanelStar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            PanelStar.Dock = DockStyle.Left;
            PanelStar.Location = new Point(105, 0);
            PanelStar.Name = "PanelStar";
            PanelStar.Size = new Size(0, 38);
            PanelStar.TabIndex = 1;
            // 
            // PanelBattleInfo
            // 
            PanelBattleInfo.AutoSize = true;
            PanelBattleInfo.BackColor = Color.Transparent;
            PanelBattleInfo.Dock = DockStyle.Top;
            PanelBattleInfo.Location = new Point(0, 62);
            PanelBattleInfo.Name = "PanelBattleInfo";
            PanelBattleInfo.Size = new Size(348, 0);
            PanelBattleInfo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Meiryo UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(0, 38);
            label2.Name = "label2";
            label2.Size = new Size(324, 24);
            label2.TabIndex = 2;
            label2.Text = "踏破時間 : 20XX/XX/XX XX:XX:XX";
            // 
            // LevelInfo
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(PanelBattleInfo);
            Controls.Add(label2);
            Controls.Add(panel1);
            MinimumSize = new Size(350, 0);
            Name = "LevelInfo";
            Size = new Size(348, 62);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel PanelBattleInfo;
        private Label label2;
        private Panel PanelStar;
    }
}
