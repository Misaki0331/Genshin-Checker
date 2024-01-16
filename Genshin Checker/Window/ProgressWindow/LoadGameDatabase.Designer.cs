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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadGameDatabase));
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
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(LabelProgressGeneral);
            panel1.Name = "panel1";
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Maximum = 10000;
            progressBar1.Name = "progressBar1";
            // 
            // LabelProgressGeneral
            // 
            resources.ApplyResources(LabelProgressGeneral, "LabelProgressGeneral");
            LabelProgressGeneral.Name = "LabelProgressGeneral";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(progressBar2);
            panel2.Controls.Add(LabelProgressDetail);
            panel2.Name = "panel2";
            // 
            // progressBar2
            // 
            resources.ApplyResources(progressBar2, "progressBar2");
            progressBar2.Maximum = 10000;
            progressBar2.Name = "progressBar2";
            // 
            // LabelProgressDetail
            // 
            resources.ApplyResources(LabelProgressDetail, "LabelProgressDetail");
            LabelProgressDetail.Name = "LabelProgressDetail";
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Controls.Add(LabelTimer);
            panel3.Controls.Add(Cancel);
            panel3.Name = "panel3";
            // 
            // LabelTimer
            // 
            resources.ApplyResources(LabelTimer, "LabelTimer");
            LabelTimer.Name = "LabelTimer";
            // 
            // Cancel
            // 
            resources.ApplyResources(Cancel, "Cancel");
            Cancel.Name = "Cancel";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // LabelUserInfo
            // 
            resources.ApplyResources(LabelUserInfo, "LabelUserInfo");
            LabelUserInfo.Name = "LabelUserInfo";
            // 
            // UpdateTimer
            // 
            UpdateTimer.Enabled = true;
            UpdateTimer.Interval = 10;
            UpdateTimer.Tick += UpdateTimer_Tick;
            // 
            // LoadGameDatabase
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(LabelUserInfo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoadGameDatabase";
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