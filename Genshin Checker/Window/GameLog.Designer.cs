namespace Genshin_Checker.Window
{
    partial class GameLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameLog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.numeric_FontSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBox_GameFullScreenSpecialized = new System.Windows.Forms.CheckBox();
            this.CheckBoxTopMost = new System.Windows.Forms.CheckBox();
            this.ClearConsole = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_FontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.numeric_FontSize);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CheckBox_GameFullScreenSpecialized);
            this.panel1.Controls.Add(this.CheckBoxTopMost);
            this.panel1.Controls.Add(this.ClearConsole);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // numeric_FontSize
            // 
            resources.ApplyResources(this.numeric_FontSize, "numeric_FontSize");
            this.numeric_FontSize.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numeric_FontSize.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numeric_FontSize.Name = "numeric_FontSize";
            this.numeric_FontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric_FontSize.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // CheckBox_GameFullScreenSpecialized
            // 
            resources.ApplyResources(this.CheckBox_GameFullScreenSpecialized, "CheckBox_GameFullScreenSpecialized");
            this.CheckBox_GameFullScreenSpecialized.ForeColor = System.Drawing.Color.White;
            this.CheckBox_GameFullScreenSpecialized.Name = "CheckBox_GameFullScreenSpecialized";
            this.CheckBox_GameFullScreenSpecialized.UseVisualStyleBackColor = true;
            this.CheckBox_GameFullScreenSpecialized.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // CheckBoxTopMost
            // 
            resources.ApplyResources(this.CheckBoxTopMost, "CheckBoxTopMost");
            this.CheckBoxTopMost.ForeColor = System.Drawing.Color.White;
            this.CheckBoxTopMost.Name = "CheckBoxTopMost";
            this.CheckBoxTopMost.UseVisualStyleBackColor = true;
            this.CheckBoxTopMost.CheckedChanged += new System.EventHandler(this.CheckBoxTopMost_CheckedChanged);
            // 
            // ClearConsole
            // 
            resources.ApplyResources(this.ClearConsole, "ClearConsole");
            this.ClearConsole.Name = "ClearConsole";
            this.ClearConsole.UseVisualStyleBackColor = true;
            this.ClearConsole.Click += new System.EventHandler(this.button1_Click);
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.Log, "Log");
            this.Log.ForeColor = System.Drawing.Color.White;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            // 
            // GameLog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.Log);
            this.Controls.Add(this.panel1);
            this.Name = "GameLog";
            this.Activated += new System.EventHandler(this.GameLog_Activated);
            this.Deactivate += new System.EventHandler(this.GameLog_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameLog_FormClosed);
            this.Load += new System.EventHandler(this.GameLog_Load);
            this.LocationChanged += new System.EventHandler(this.GameLog_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.GameLog_SizeChanged);
            this.Leave += new System.EventHandler(this.GameLog_Leave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_FontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button ClearConsole;
        private TextBox Log;
        private CheckBox CheckBoxTopMost;
        private CheckBox CheckBox_GameFullScreenSpecialized;
        private NumericUpDown numeric_FontSize;
        private Label label1;
    }
}