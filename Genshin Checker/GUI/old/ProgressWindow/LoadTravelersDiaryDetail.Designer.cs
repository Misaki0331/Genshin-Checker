namespace Genshin_Checker.Window.ProgressWindow
{
    partial class LoadTravelersDiaryDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadTravelersDiaryDetail));
            progressBar1 = new ProgressBar();
            label1 = new Label();
            delay = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Name = "progressBar1";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // delay
            // 
            delay.Enabled = true;
            delay.Tick += delay_Tick;
            // 
            // LoadTravelersDiaryDetail
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(label1);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoadTravelersDiaryDetail";
            ShowInTaskbar = false;
            FormClosing += LoadTravelersDiaryDetail_FormClosing;
            Load += LoadTravelersDiaryDetail_Load;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label1;
        private System.Windows.Forms.Timer delay;
    }
}