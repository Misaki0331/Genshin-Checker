namespace Genshin_Checker.Window.ProgressWindow
{
    partial class LoadGameDatabase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            panel1 = new Panel();
            progressBar1 = new ProgressBar();
            LabelProgressGeneral = new Label();
            panel2 = new Panel();
            progressBar2 = new ProgressBar();
            LabelProgressDetail = new Label();
            panel3 = new Panel();
            LabelTimer = new Label();
            Cancel = new Button();
            LabelUserInfo = new Label();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Meiryo UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(344, 51);
            label1.TabIndex = 0;
            label1.Text = "ゲーム内のデータベースを参照しています。\r\nしばらくお待ちください...";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(LabelProgressGeneral);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 102);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 42);
            panel1.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Top;
            progressBar1.Location = new Point(0, 19);
            progressBar1.Maximum = 10000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(344, 23);
            progressBar1.TabIndex = 1;
            // 
            // LabelProgressGeneral
            // 
            LabelProgressGeneral.AutoSize = true;
            LabelProgressGeneral.Dock = DockStyle.Top;
            LabelProgressGeneral.Font = new Font("Meiryo UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            LabelProgressGeneral.Location = new Point(0, 0);
            LabelProgressGeneral.Name = "LabelProgressGeneral";
            LabelProgressGeneral.Size = new Size(347, 19);
            LabelProgressGeneral.TabIndex = 0;
            LabelProgressGeneral.Text = "100.0% : 20XX年XX月 追加の原石履歴を取得中...";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(progressBar2);
            panel2.Controls.Add(LabelProgressDetail);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 144);
            panel2.Name = "panel2";
            panel2.Size = new Size(344, 42);
            panel2.TabIndex = 2;
            // 
            // progressBar2
            // 
            progressBar2.Dock = DockStyle.Top;
            progressBar2.Location = new Point(0, 19);
            progressBar2.Maximum = 10000;
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(344, 23);
            progressBar2.TabIndex = 1;
            // 
            // LabelProgressDetail
            // 
            LabelProgressDetail.AutoSize = true;
            LabelProgressDetail.Dock = DockStyle.Top;
            LabelProgressDetail.Font = new Font("Meiryo UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            LabelProgressDetail.Location = new Point(0, 0);
            LabelProgressDetail.Name = "LabelProgressDetail";
            LabelProgressDetail.Size = new Size(233, 19);
            LabelProgressDetail.TabIndex = 0;
            LabelProgressDetail.Text = "ステップ : 1 / 3 進捗率 : 100.00%";
            // 
            // panel3
            // 
            panel3.Controls.Add(LabelTimer);
            panel3.Controls.Add(Cancel);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 186);
            panel3.Name = "panel3";
            panel3.Size = new Size(344, 22);
            panel3.TabIndex = 3;
            // 
            // LabelTimer
            // 
            LabelTimer.AutoSize = true;
            LabelTimer.Dock = DockStyle.Left;
            LabelTimer.Location = new Point(0, 0);
            LabelTimer.Name = "LabelTimer";
            LabelTimer.Size = new Size(64, 15);
            LabelTimer.TabIndex = 5;
            LabelTimer.Text = "0:00:00.000";
            // 
            // Cancel
            // 
            Cancel.Dock = DockStyle.Right;
            Cancel.Location = new Point(269, 0);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 22);
            Cancel.TabIndex = 0;
            Cancel.Text = "キャンセル";
            Cancel.UseVisualStyleBackColor = true;
            // 
            // LabelUserInfo
            // 
            LabelUserInfo.Dock = DockStyle.Top;
            LabelUserInfo.Font = new Font("Meiryo UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LabelUserInfo.Location = new Point(0, 51);
            LabelUserInfo.Name = "LabelUserInfo";
            LabelUserInfo.Size = new Size(344, 51);
            LabelUserInfo.TabIndex = 4;
            LabelUserInfo.Text = "UID:807810806 (os_asia)\r\n水咲(みさき)";
            LabelUserInfo.TextAlign = ContentAlignment.TopCenter;
            // 
            // UpdateTimer
            // 
            UpdateTimer.Enabled = true;
            UpdateTimer.Interval = 10;
            UpdateTimer.Tick += UpdateTimer_Tick;
            // 
            // LoadGameDatabase
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            ClientSize = new Size(344, 208);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(LabelUserInfo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(360, 30000);
            MinimumSize = new Size(360, 0);
            Name = "LoadGameDatabase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoadGameDatabase";
            FormClosing += LoadGameDatabase_FormClosing;
            Load += LoadGameDatabase_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private ProgressBar progressBar1;
        private Label LabelProgressGeneral;
        private Panel panel2;
        private ProgressBar progressBar2;
        private Label LabelProgressDetail;
        private Panel panel3;
        private Button Cancel;
        private Label LabelUserInfo;
        private Label LabelTimer;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}