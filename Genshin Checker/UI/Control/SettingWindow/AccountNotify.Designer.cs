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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountNotify));
            CheckTransformerReached = new CheckBox();
            CheckExpeditionAllCompleted = new CheckBox();
            CheckRealmCoinMax = new CheckBox();
            CheckResinMax = new CheckBox();
            panel1 = new Panel();
            NumResinThreshold = new NumericUpDown();
            CheckResinThreshold = new CheckBox();
            panel2 = new Panel();
            NumRealmCoinThreshold = new NumericUpDown();
            CheckRealmCoinThreshold = new CheckBox();
            AccountInfomation = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumResinThreshold).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumRealmCoinThreshold).BeginInit();
            SuspendLayout();
            // 
            // CheckTransformerReached
            // 
            resources.ApplyResources(CheckTransformerReached, "CheckTransformerReached");
            CheckTransformerReached.Name = "CheckTransformerReached";
            CheckTransformerReached.UseVisualStyleBackColor = true;
            CheckTransformerReached.CheckedChanged += StateChanged;
            // 
            // CheckExpeditionAllCompleted
            // 
            resources.ApplyResources(CheckExpeditionAllCompleted, "CheckExpeditionAllCompleted");
            CheckExpeditionAllCompleted.Name = "CheckExpeditionAllCompleted";
            CheckExpeditionAllCompleted.UseVisualStyleBackColor = true;
            CheckExpeditionAllCompleted.CheckedChanged += StateChanged;
            // 
            // CheckRealmCoinMax
            // 
            resources.ApplyResources(CheckRealmCoinMax, "CheckRealmCoinMax");
            CheckRealmCoinMax.Name = "CheckRealmCoinMax";
            CheckRealmCoinMax.UseVisualStyleBackColor = true;
            CheckRealmCoinMax.CheckedChanged += StateChanged;
            // 
            // CheckResinMax
            // 
            resources.ApplyResources(CheckResinMax, "CheckResinMax");
            CheckResinMax.Name = "CheckResinMax";
            CheckResinMax.UseVisualStyleBackColor = true;
            CheckResinMax.CheckedChanged += StateChanged;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(NumResinThreshold);
            panel1.Controls.Add(CheckResinThreshold);
            panel1.Name = "panel1";
            // 
            // NumResinThreshold
            // 
            resources.ApplyResources(NumResinThreshold, "NumResinThreshold");
            NumResinThreshold.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            NumResinThreshold.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumResinThreshold.Name = "NumResinThreshold";
            NumResinThreshold.Value = new decimal(new int[] { 120, 0, 0, 0 });
            NumResinThreshold.ValueChanged += StateChanged;
            // 
            // CheckResinThreshold
            // 
            resources.ApplyResources(CheckResinThreshold, "CheckResinThreshold");
            CheckResinThreshold.Name = "CheckResinThreshold";
            CheckResinThreshold.UseVisualStyleBackColor = true;
            CheckResinThreshold.CheckedChanged += StateChanged;
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(NumRealmCoinThreshold);
            panel2.Controls.Add(CheckRealmCoinThreshold);
            panel2.Name = "panel2";
            // 
            // NumRealmCoinThreshold
            // 
            resources.ApplyResources(NumRealmCoinThreshold, "NumRealmCoinThreshold");
            NumRealmCoinThreshold.Maximum = new decimal(new int[] { 2400, 0, 0, 0 });
            NumRealmCoinThreshold.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumRealmCoinThreshold.Name = "NumRealmCoinThreshold";
            NumRealmCoinThreshold.Value = new decimal(new int[] { 1800, 0, 0, 0 });
            NumRealmCoinThreshold.ValueChanged += StateChanged;
            // 
            // CheckRealmCoinThreshold
            // 
            resources.ApplyResources(CheckRealmCoinThreshold, "CheckRealmCoinThreshold");
            CheckRealmCoinThreshold.Name = "CheckRealmCoinThreshold";
            CheckRealmCoinThreshold.UseVisualStyleBackColor = true;
            CheckRealmCoinThreshold.CheckedChanged += StateChanged;
            // 
            // AccountInfomation
            // 
            resources.ApplyResources(AccountInfomation, "AccountInfomation");
            AccountInfomation.Name = "AccountInfomation";
            // 
            // AccountNotify
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CheckExpeditionAllCompleted);
            Controls.Add(CheckTransformerReached);
            Controls.Add(CheckRealmCoinMax);
            Controls.Add(panel2);
            Controls.Add(CheckResinMax);
            Controls.Add(panel1);
            Controls.Add(AccountInfomation);
            Name = "AccountNotify";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumResinThreshold).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumRealmCoinThreshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
