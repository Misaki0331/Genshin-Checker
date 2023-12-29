namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    partial class BattleInfo
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
            this.LabelBattleName = new System.Windows.Forms.Label();
            this.LabelTimestamp = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PanelEnemyInfoBackground = new System.Windows.Forms.Panel();
            this.PanelEnemyInfo = new System.Windows.Forms.Panel();
            this.PanelCharactersInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.PanelEnemyInfoBackground.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelBattleName
            // 
            this.LabelBattleName.AutoSize = true;
            this.LabelBattleName.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelBattleName.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelBattleName.Location = new System.Drawing.Point(0, 0);
            this.LabelBattleName.Name = "LabelBattleName";
            this.LabelBattleName.Size = new System.Drawing.Size(55, 30);
            this.LabelBattleName.TabIndex = 0;
            this.LabelBattleName.Text = "前半";
            // 
            // LabelTimestamp
            // 
            this.LabelTimestamp.AutoSize = true;
            this.LabelTimestamp.Dock = System.Windows.Forms.DockStyle.Left;
            this.LabelTimestamp.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelTimestamp.Location = new System.Drawing.Point(55, 0);
            this.LabelTimestamp.MinimumSize = new System.Drawing.Size(0, 30);
            this.LabelTimestamp.Name = "LabelTimestamp";
            this.LabelTimestamp.Size = new System.Drawing.Size(275, 30);
            this.LabelTimestamp.TabIndex = 1;
            this.LabelTimestamp.Text = "踏破時間 : 20XX/XX/XX XX:XX:XX";
            this.LabelTimestamp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 410F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PanelEnemyInfoBackground, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PanelCharactersInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 125);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // PanelEnemyInfoBackground
            // 
            this.PanelEnemyInfoBackground.AutoScroll = true;
            this.PanelEnemyInfoBackground.Controls.Add(this.PanelEnemyInfo);
            this.PanelEnemyInfoBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelEnemyInfoBackground.Location = new System.Drawing.Point(413, 3);
            this.PanelEnemyInfoBackground.Name = "PanelEnemyInfoBackground";
            this.PanelEnemyInfoBackground.Size = new System.Drawing.Size(237, 119);
            this.PanelEnemyInfoBackground.TabIndex = 1;
            this.PanelEnemyInfoBackground.Resize += new System.EventHandler(this.panel2_Resize);
            // 
            // PanelEnemyInfo
            // 
            this.PanelEnemyInfo.AutoScroll = true;
            this.PanelEnemyInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelEnemyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelEnemyInfo.Location = new System.Drawing.Point(0, 0);
            this.PanelEnemyInfo.Name = "PanelEnemyInfo";
            this.PanelEnemyInfo.Size = new System.Drawing.Size(237, 119);
            this.PanelEnemyInfo.TabIndex = 0;
            // 
            // PanelCharactersInfo
            // 
            this.PanelCharactersInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelCharactersInfo.Location = new System.Drawing.Point(3, 3);
            this.PanelCharactersInfo.Name = "PanelCharactersInfo";
            this.PanelCharactersInfo.Size = new System.Drawing.Size(404, 119);
            this.PanelCharactersInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LabelTimestamp);
            this.panel1.Controls.Add(this.LabelBattleName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 30);
            this.panel1.TabIndex = 3;
            // 
            // BattleInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "BattleInfo";
            this.Size = new System.Drawing.Size(653, 157);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.PanelEnemyInfoBackground.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label LabelBattleName;
        private Label LabelTimestamp;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel PanelCharactersInfo;
        private Panel PanelEnemyInfoBackground;
        private Panel PanelEnemyInfo;
        private Panel panel1;
    }
}
