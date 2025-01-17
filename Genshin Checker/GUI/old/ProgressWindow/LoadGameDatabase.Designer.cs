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
            LabelProgressDetail = new Label();
            progressBar2 = new ProgressBar();
            panel3 = new Panel();
            LabelTimer = new Label();
            Cancel = new Button();
            LabelUserInfo = new Label();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            PanelProgress = new Panel();
            PanelSelect = new Panel();
            groupBox2 = new GroupBox();
            label4 = new Label();
            panel7 = new Panel();
            ComboHoYoLabAccounts = new ComboBox();
            ExecuteHoYoLab = new Button();
            groupBox1 = new GroupBox();
            label3 = new Label();
            panel6 = new Panel();
            SessionInfo = new Label();
            ExecuteGameSession = new Button();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            PanelProgress.SuspendLayout();
            PanelSelect.SuspendLayout();
            groupBox2.SuspendLayout();
            panel7.SuspendLayout();
            groupBox1.SuspendLayout();
            panel6.SuspendLayout();
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
            panel2.Controls.Add(LabelProgressDetail);
            panel2.Name = "panel2";
            // 
            // LabelProgressDetail
            // 
            resources.ApplyResources(LabelProgressDetail, "LabelProgressDetail");
            LabelProgressDetail.Name = "LabelProgressDetail";
            // 
            // progressBar2
            // 
            resources.ApplyResources(progressBar2, "progressBar2");
            progressBar2.Maximum = 10000;
            progressBar2.Name = "progressBar2";
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
            // PanelProgress
            // 
            resources.ApplyResources(PanelProgress, "PanelProgress");
            PanelProgress.Controls.Add(panel3);
            PanelProgress.Controls.Add(progressBar2);
            PanelProgress.Controls.Add(panel2);
            PanelProgress.Controls.Add(progressBar1);
            PanelProgress.Controls.Add(LabelProgressGeneral);
            PanelProgress.Controls.Add(LabelUserInfo);
            PanelProgress.Controls.Add(label1);
            PanelProgress.Name = "PanelProgress";
            // 
            // PanelSelect
            // 
            resources.ApplyResources(PanelSelect, "PanelSelect");
            PanelSelect.Controls.Add(groupBox2);
            PanelSelect.Controls.Add(groupBox1);
            PanelSelect.Name = "PanelSelect";
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(panel7);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // panel7
            // 
            resources.ApplyResources(panel7, "panel7");
            panel7.Controls.Add(ComboHoYoLabAccounts);
            panel7.Controls.Add(ExecuteHoYoLab);
            panel7.Name = "panel7";
            // 
            // ComboHoYoLabAccounts
            // 
            resources.ApplyResources(ComboHoYoLabAccounts, "ComboHoYoLabAccounts");
            ComboHoYoLabAccounts.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboHoYoLabAccounts.FormattingEnabled = true;
            ComboHoYoLabAccounts.Name = "ComboHoYoLabAccounts";
            // 
            // ExecuteHoYoLab
            // 
            resources.ApplyResources(ExecuteHoYoLab, "ExecuteHoYoLab");
            ExecuteHoYoLab.Name = "ExecuteHoYoLab";
            ExecuteHoYoLab.UseVisualStyleBackColor = true;
            ExecuteHoYoLab.Click += ExecuteHoYoLab_Click;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(panel6);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // panel6
            // 
            resources.ApplyResources(panel6, "panel6");
            panel6.Controls.Add(SessionInfo);
            panel6.Controls.Add(ExecuteGameSession);
            panel6.Name = "panel6";
            // 
            // SessionInfo
            // 
            resources.ApplyResources(SessionInfo, "SessionInfo");
            SessionInfo.Name = "SessionInfo";
            // 
            // ExecuteGameSession
            // 
            resources.ApplyResources(ExecuteGameSession, "ExecuteGameSession");
            ExecuteGameSession.Name = "ExecuteGameSession";
            ExecuteGameSession.UseVisualStyleBackColor = true;
            ExecuteGameSession.Click += ExecuteGameSession_Click;
            // 
            // LoadGameDatabase
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(PanelSelect);
            Controls.Add(PanelProgress);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoadGameDatabase";
            ShowIcon = false;
            FormClosing += LoadGameDatabase_FormClosing;
            Load += LoadGameDatabase_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            PanelProgress.ResumeLayout(false);
            PanelProgress.PerformLayout();
            PanelSelect.ResumeLayout(false);
            PanelSelect.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel7.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel6.ResumeLayout(false);
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
        private Panel PanelProgress;
        private Panel PanelSelect;
        private GroupBox groupBox1;
        private Panel panel6;
        private Label SessionInfo;
        private Button ExecuteGameSession;
        private Label label3;
        private GroupBox groupBox2;
        private Label label4;
        private Panel panel7;
        private Button ExecuteHoYoLab;
        private ComboBox ComboHoYoLabAccounts;
    }
}