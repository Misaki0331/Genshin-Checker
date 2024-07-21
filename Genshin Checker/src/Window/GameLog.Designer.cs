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
            panel1 = new Panel();
            numeric_FontSize = new NumericUpDown();
            label1 = new Label();
            CheckBox_GameFullScreenSpecialized = new CheckBox();
            CheckBoxTopMost = new CheckBox();
            ClearConsole = new Button();
            Log = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numeric_FontSize).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(numeric_FontSize);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(CheckBox_GameFullScreenSpecialized);
            panel1.Controls.Add(CheckBoxTopMost);
            panel1.Controls.Add(ClearConsole);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // numeric_FontSize
            // 
            resources.ApplyResources(numeric_FontSize, "numeric_FontSize");
            numeric_FontSize.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numeric_FontSize.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            numeric_FontSize.Name = "numeric_FontSize";
            numeric_FontSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numeric_FontSize.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // CheckBox_GameFullScreenSpecialized
            // 
            resources.ApplyResources(CheckBox_GameFullScreenSpecialized, "CheckBox_GameFullScreenSpecialized");
            CheckBox_GameFullScreenSpecialized.ForeColor = Color.White;
            CheckBox_GameFullScreenSpecialized.Name = "CheckBox_GameFullScreenSpecialized";
            CheckBox_GameFullScreenSpecialized.UseVisualStyleBackColor = true;
            CheckBox_GameFullScreenSpecialized.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // CheckBoxTopMost
            // 
            resources.ApplyResources(CheckBoxTopMost, "CheckBoxTopMost");
            CheckBoxTopMost.ForeColor = Color.White;
            CheckBoxTopMost.Name = "CheckBoxTopMost";
            CheckBoxTopMost.UseVisualStyleBackColor = true;
            CheckBoxTopMost.CheckedChanged += CheckBoxTopMost_CheckedChanged;
            // 
            // ClearConsole
            // 
            resources.ApplyResources(ClearConsole, "ClearConsole");
            ClearConsole.Name = "ClearConsole";
            ClearConsole.UseVisualStyleBackColor = true;
            ClearConsole.Click += button1_Click;
            // 
            // Log
            // 
            Log.BackColor = Color.Black;
            resources.ApplyResources(Log, "Log");
            Log.ForeColor = Color.White;
            Log.Name = "Log";
            Log.ReadOnly = true;
            // 
            // GameLog
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            Controls.Add(Log);
            Controls.Add(panel1);
            Name = "GameLog";
            Activated += GameLog_Activated;
            Deactivate += GameLog_Deactivate;
            FormClosed += GameLog_FormClosed;
            Load += GameLog_Load;
            LocationChanged += GameLog_LocationChanged;
            SizeChanged += GameLog_SizeChanged;
            Leave += GameLog_Leave;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numeric_FontSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
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