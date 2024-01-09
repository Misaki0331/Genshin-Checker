namespace Genshin_Checker.UI.Control.SettingWindow
{
    partial class AccountNotify
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
            this.CheckTransformerReached = new System.Windows.Forms.CheckBox();
            this.CheckExpeditionAllCompleted = new System.Windows.Forms.CheckBox();
            this.CheckRealmCoinMax = new System.Windows.Forms.CheckBox();
            this.CheckResinMax = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NumResinThreshold = new System.Windows.Forms.NumericUpDown();
            this.CheckResinThreshold = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NumRealmCoinThreshold = new System.Windows.Forms.NumericUpDown();
            this.CheckRealmCoinThreshold = new System.Windows.Forms.CheckBox();
            this.AccountInfomation = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumResinThreshold)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumRealmCoinThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // CheckTransformerReached
            // 
            this.CheckTransformerReached.AutoSize = true;
            this.CheckTransformerReached.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckTransformerReached.Location = new System.Drawing.Point(0, 99);
            this.CheckTransformerReached.Name = "CheckTransformerReached";
            this.CheckTransformerReached.Size = new System.Drawing.Size(240, 19);
            this.CheckTransformerReached.TabIndex = 11;
            this.CheckTransformerReached.Text = "参量物質変化器が使用可能";
            this.CheckTransformerReached.UseVisualStyleBackColor = true;
            this.CheckTransformerReached.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // CheckExpeditionAllCompleted
            // 
            this.CheckExpeditionAllCompleted.AutoSize = true;
            this.CheckExpeditionAllCompleted.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckExpeditionAllCompleted.Location = new System.Drawing.Point(0, 118);
            this.CheckExpeditionAllCompleted.Name = "CheckExpeditionAllCompleted";
            this.CheckExpeditionAllCompleted.Size = new System.Drawing.Size(240, 19);
            this.CheckExpeditionAllCompleted.TabIndex = 10;
            this.CheckExpeditionAllCompleted.Text = "探索派遣が全員完了";
            this.CheckExpeditionAllCompleted.UseVisualStyleBackColor = true;
            this.CheckExpeditionAllCompleted.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // CheckRealmCoinMax
            // 
            this.CheckRealmCoinMax.AutoSize = true;
            this.CheckRealmCoinMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckRealmCoinMax.Location = new System.Drawing.Point(0, 80);
            this.CheckRealmCoinMax.Name = "CheckRealmCoinMax";
            this.CheckRealmCoinMax.Size = new System.Drawing.Size(240, 19);
            this.CheckRealmCoinMax.TabIndex = 9;
            this.CheckRealmCoinMax.Text = "塵歌壺の洞天宝銭が最大まで回復";
            this.CheckRealmCoinMax.UseVisualStyleBackColor = true;
            this.CheckRealmCoinMax.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // CheckResinMax
            // 
            this.CheckResinMax.AutoSize = true;
            this.CheckResinMax.Dock = System.Windows.Forms.DockStyle.Top;
            this.CheckResinMax.Location = new System.Drawing.Point(0, 38);
            this.CheckResinMax.Name = "CheckResinMax";
            this.CheckResinMax.Size = new System.Drawing.Size(240, 19);
            this.CheckResinMax.TabIndex = 7;
            this.CheckResinMax.Text = "樹脂の所持が最大まで回復";
            this.CheckResinMax.UseVisualStyleBackColor = true;
            this.CheckResinMax.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NumResinThreshold);
            this.panel1.Controls.Add(this.CheckResinThreshold);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 23);
            this.panel1.TabIndex = 12;
            // 
            // NumResinThreshold
            // 
            this.NumResinThreshold.Dock = System.Windows.Forms.DockStyle.Left;
            this.NumResinThreshold.Location = new System.Drawing.Point(148, 0);
            this.NumResinThreshold.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NumResinThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumResinThreshold.Name = "NumResinThreshold";
            this.NumResinThreshold.Size = new System.Drawing.Size(49, 23);
            this.NumResinThreshold.TabIndex = 1;
            this.NumResinThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumResinThreshold.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.NumResinThreshold.ValueChanged += new System.EventHandler(this.StateChanged);
            // 
            // CheckResinThreshold
            // 
            this.CheckResinThreshold.AutoSize = true;
            this.CheckResinThreshold.Dock = System.Windows.Forms.DockStyle.Left;
            this.CheckResinThreshold.Location = new System.Drawing.Point(0, 0);
            this.CheckResinThreshold.Name = "CheckResinThreshold";
            this.CheckResinThreshold.Size = new System.Drawing.Size(148, 23);
            this.CheckResinThreshold.TabIndex = 0;
            this.CheckResinThreshold.Text = "樹脂の所持が閾値以上 :";
            this.CheckResinThreshold.UseVisualStyleBackColor = true;
            this.CheckResinThreshold.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NumRealmCoinThreshold);
            this.panel2.Controls.Add(this.CheckRealmCoinThreshold);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 23);
            this.panel2.TabIndex = 13;
            // 
            // NumRealmCoinThreshold
            // 
            this.NumRealmCoinThreshold.Dock = System.Windows.Forms.DockStyle.Left;
            this.NumRealmCoinThreshold.Location = new System.Drawing.Point(184, 0);
            this.NumRealmCoinThreshold.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.NumRealmCoinThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumRealmCoinThreshold.Name = "NumRealmCoinThreshold";
            this.NumRealmCoinThreshold.Size = new System.Drawing.Size(49, 23);
            this.NumRealmCoinThreshold.TabIndex = 1;
            this.NumRealmCoinThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumRealmCoinThreshold.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.NumRealmCoinThreshold.ValueChanged += new System.EventHandler(this.StateChanged);
            // 
            // CheckRealmCoinThreshold
            // 
            this.CheckRealmCoinThreshold.AutoSize = true;
            this.CheckRealmCoinThreshold.Dock = System.Windows.Forms.DockStyle.Left;
            this.CheckRealmCoinThreshold.Location = new System.Drawing.Point(0, 0);
            this.CheckRealmCoinThreshold.Name = "CheckRealmCoinThreshold";
            this.CheckRealmCoinThreshold.Size = new System.Drawing.Size(184, 23);
            this.CheckRealmCoinThreshold.TabIndex = 0;
            this.CheckRealmCoinThreshold.Text = "塵歌壺の洞天宝銭が閾値以上 :";
            this.CheckRealmCoinThreshold.UseVisualStyleBackColor = true;
            this.CheckRealmCoinThreshold.CheckedChanged += new System.EventHandler(this.StateChanged);
            // 
            // AccountInfomation
            // 
            this.AccountInfomation.AutoSize = true;
            this.AccountInfomation.Dock = System.Windows.Forms.DockStyle.Top;
            this.AccountInfomation.Location = new System.Drawing.Point(0, 0);
            this.AccountInfomation.Name = "AccountInfomation";
            this.AccountInfomation.Size = new System.Drawing.Size(65, 15);
            this.AccountInfomation.TabIndex = 2;
            this.AccountInfomation.Text = "Infomation";
            // 
            // AccountNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.CheckExpeditionAllCompleted);
            this.Controls.Add(this.CheckTransformerReached);
            this.Controls.Add(this.CheckRealmCoinMax);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CheckResinMax);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AccountInfomation);
            this.Name = "AccountNotify";
            this.Size = new System.Drawing.Size(240, 147);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumResinThreshold)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumRealmCoinThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox CheckTransformerReached;
        private CheckBox CheckExpeditionAllCompleted;
        private CheckBox CheckRealmCoinMax;
        private CheckBox CheckResinMax;
        private Panel panel1;
        private NumericUpDown NumResinThreshold;
        private CheckBox CheckResinThreshold;
        private Panel panel2;
        private NumericUpDown NumRealmCoinThreshold;
        private CheckBox CheckRealmCoinThreshold;
        private Label AccountInfomation;
    }
}
