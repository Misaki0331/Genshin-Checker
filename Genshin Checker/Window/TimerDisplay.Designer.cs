namespace Genshin_Checker.Window
{
    partial class TimerDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerDisplay));
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            CurrentStatus = new Label();
            SessionTime = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            panel2 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            label2 = new Label();
            TotalSessionTime = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // CurrentStatus
            // 
            resources.ApplyResources(CurrentStatus, "CurrentStatus");
            CurrentStatus.BackColor = Color.Transparent;
            CurrentStatus.ForeColor = Color.White;
            CurrentStatus.Name = "CurrentStatus";
            // 
            // SessionTime
            // 
            resources.ApplyResources(SessionTime, "SessionTime");
            SessionTime.BackColor = Color.Transparent;
            SessionTime.ForeColor = Color.White;
            SessionTime.Name = "SessionTime";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(panel4);
            panel1.Name = "panel1";
            // 
            // panel4
            // 
            resources.ApplyResources(panel4, "panel4");
            panel4.Controls.Add(CurrentStatus);
            panel4.Controls.Add(label1);
            panel4.Name = "panel4";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(SessionTime);
            panel2.Name = "panel2";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Name = "label4";
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(TotalSessionTime);
            panel3.Name = "panel3";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Name = "label2";
            // 
            // TotalSessionTime
            // 
            resources.ApplyResources(TotalSessionTime, "TotalSessionTime");
            TotalSessionTime.BackColor = Color.Transparent;
            TotalSessionTime.ForeColor = Color.White;
            TotalSessionTime.Name = "TotalSessionTime";
            // 
            // TimerDisplay
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            BackgroundImage = resource.namecard.Genshin_Impact_A_New_World;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "TimerDisplay";
            FormClosing += Time_FormClosing;
            FormClosed += TimerDisplay_FormClosed;
            Load += TimerDisplay_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label CurrentStatus;
        private Label SessionTime;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private Panel panel4;
        private Panel panel3;
        private Label label2;
        private Label TotalSessionTime;
    }
}