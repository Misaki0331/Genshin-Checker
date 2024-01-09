namespace Genshin_Checker.Window.ExWindow.CharacterCalculator
{
    partial class BatchWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchWindow));
            this.LabelCharacterName = new System.Windows.Forms.Label();
            this.GroupLevel = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TrackLevel = new System.Windows.Forms.TrackBar();
            this.ArrowLevel = new System.Windows.Forms.Label();
            this.NumericLevel = new System.Windows.Forms.NumericUpDown();
            this.CurrentLevel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonAppry = new System.Windows.Forms.Button();
            this.GroupTalent3 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TrackTalent3 = new System.Windows.Forms.TrackBar();
            this.ArrowTalent3 = new System.Windows.Forms.Label();
            this.NumericTalent3 = new System.Windows.Forms.NumericUpDown();
            this.CurrentTalent3 = new System.Windows.Forms.Label();
            this.GroupTalent2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TrackTalent2 = new System.Windows.Forms.TrackBar();
            this.ArrowTalent2 = new System.Windows.Forms.Label();
            this.NumericTalent2 = new System.Windows.Forms.NumericUpDown();
            this.CurrentTalent2 = new System.Windows.Forms.Label();
            this.GroupTalent1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TrackTalent1 = new System.Windows.Forms.TrackBar();
            this.ArrowTalent1 = new System.Windows.Forms.Label();
            this.NumericTalent1 = new System.Windows.Forms.NumericUpDown();
            this.CurrentTalent1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ButtonSetToTalent10 = new System.Windows.Forms.Button();
            this.ButtonSetToTalent9 = new System.Windows.Forms.Button();
            this.ButtonSetToLv90 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioDisable = new System.Windows.Forms.RadioButton();
            this.RadioEnable = new System.Windows.Forms.RadioButton();
            this.GroupLevel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLevel)).BeginInit();
            this.panel5.SuspendLayout();
            this.GroupTalent3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackTalent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTalent3)).BeginInit();
            this.GroupTalent2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackTalent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTalent2)).BeginInit();
            this.GroupTalent1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackTalent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTalent1)).BeginInit();
            this.panel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelCharacterName
            // 
            resources.ApplyResources(this.LabelCharacterName, "LabelCharacterName");
            this.LabelCharacterName.Name = "LabelCharacterName";
            // 
            // GroupLevel
            // 
            resources.ApplyResources(this.GroupLevel, "GroupLevel");
            this.GroupLevel.Controls.Add(this.panel1);
            this.GroupLevel.Name = "GroupLevel";
            this.GroupLevel.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.TrackLevel);
            this.panel1.Controls.Add(this.ArrowLevel);
            this.panel1.Controls.Add(this.NumericLevel);
            this.panel1.Controls.Add(this.CurrentLevel);
            this.panel1.Name = "panel1";
            // 
            // TrackLevel
            // 
            resources.ApplyResources(this.TrackLevel, "TrackLevel");
            this.TrackLevel.LargeChange = 10;
            this.TrackLevel.Maximum = 90;
            this.TrackLevel.Minimum = 1;
            this.TrackLevel.Name = "TrackLevel";
            this.TrackLevel.TickFrequency = 10;
            this.TrackLevel.Value = 1;
            this.TrackLevel.ValueChanged += new System.EventHandler(this.Track_ValueChanged);
            // 
            // ArrowLevel
            // 
            resources.ApplyResources(this.ArrowLevel, "ArrowLevel");
            this.ArrowLevel.Name = "ArrowLevel";
            // 
            // NumericLevel
            // 
            resources.ApplyResources(this.NumericLevel, "NumericLevel");
            this.NumericLevel.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.NumericLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericLevel.Name = "NumericLevel";
            this.NumericLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericLevel.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // CurrentLevel
            // 
            resources.ApplyResources(this.CurrentLevel, "CurrentLevel");
            this.CurrentLevel.Name = "CurrentLevel";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Controls.Add(this.ButtonCancel);
            this.panel5.Controls.Add(this.ButtonAppry);
            this.panel5.Name = "panel5";
            // 
            // ButtonCancel
            // 
            resources.ApplyResources(this.ButtonCancel, "ButtonCancel");
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonAppry
            // 
            resources.ApplyResources(this.ButtonAppry, "ButtonAppry");
            this.ButtonAppry.Name = "ButtonAppry";
            this.ButtonAppry.UseVisualStyleBackColor = true;
            this.ButtonAppry.Click += new System.EventHandler(this.ButtonAppry_Click);
            // 
            // GroupTalent3
            // 
            resources.ApplyResources(this.GroupTalent3, "GroupTalent3");
            this.GroupTalent3.Controls.Add(this.panel4);
            this.GroupTalent3.Name = "GroupTalent3";
            this.GroupTalent3.TabStop = false;
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.TrackTalent3);
            this.panel4.Controls.Add(this.ArrowTalent3);
            this.panel4.Controls.Add(this.NumericTalent3);
            this.panel4.Controls.Add(this.CurrentTalent3);
            this.panel4.Name = "panel4";
            // 
            // TrackTalent3
            // 
            resources.ApplyResources(this.TrackTalent3, "TrackTalent3");
            this.TrackTalent3.LargeChange = 2;
            this.TrackTalent3.Minimum = 1;
            this.TrackTalent3.Name = "TrackTalent3";
            this.TrackTalent3.Value = 1;
            this.TrackTalent3.ValueChanged += new System.EventHandler(this.Track_ValueChanged);
            // 
            // ArrowTalent3
            // 
            resources.ApplyResources(this.ArrowTalent3, "ArrowTalent3");
            this.ArrowTalent3.Name = "ArrowTalent3";
            // 
            // NumericTalent3
            // 
            resources.ApplyResources(this.NumericTalent3, "NumericTalent3");
            this.NumericTalent3.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericTalent3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent3.Name = "NumericTalent3";
            this.NumericTalent3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent3.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // CurrentTalent3
            // 
            resources.ApplyResources(this.CurrentTalent3, "CurrentTalent3");
            this.CurrentTalent3.Name = "CurrentTalent3";
            // 
            // GroupTalent2
            // 
            resources.ApplyResources(this.GroupTalent2, "GroupTalent2");
            this.GroupTalent2.Controls.Add(this.panel3);
            this.GroupTalent2.Name = "GroupTalent2";
            this.GroupTalent2.TabStop = false;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.TrackTalent2);
            this.panel3.Controls.Add(this.ArrowTalent2);
            this.panel3.Controls.Add(this.NumericTalent2);
            this.panel3.Controls.Add(this.CurrentTalent2);
            this.panel3.Name = "panel3";
            // 
            // TrackTalent2
            // 
            resources.ApplyResources(this.TrackTalent2, "TrackTalent2");
            this.TrackTalent2.LargeChange = 2;
            this.TrackTalent2.Minimum = 1;
            this.TrackTalent2.Name = "TrackTalent2";
            this.TrackTalent2.Value = 1;
            this.TrackTalent2.ValueChanged += new System.EventHandler(this.Track_ValueChanged);
            // 
            // ArrowTalent2
            // 
            resources.ApplyResources(this.ArrowTalent2, "ArrowTalent2");
            this.ArrowTalent2.Name = "ArrowTalent2";
            // 
            // NumericTalent2
            // 
            resources.ApplyResources(this.NumericTalent2, "NumericTalent2");
            this.NumericTalent2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericTalent2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent2.Name = "NumericTalent2";
            this.NumericTalent2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent2.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // CurrentTalent2
            // 
            resources.ApplyResources(this.CurrentTalent2, "CurrentTalent2");
            this.CurrentTalent2.Name = "CurrentTalent2";
            // 
            // GroupTalent1
            // 
            resources.ApplyResources(this.GroupTalent1, "GroupTalent1");
            this.GroupTalent1.Controls.Add(this.panel2);
            this.GroupTalent1.Name = "GroupTalent1";
            this.GroupTalent1.TabStop = false;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.TrackTalent1);
            this.panel2.Controls.Add(this.ArrowTalent1);
            this.panel2.Controls.Add(this.NumericTalent1);
            this.panel2.Controls.Add(this.CurrentTalent1);
            this.panel2.Name = "panel2";
            // 
            // TrackTalent1
            // 
            resources.ApplyResources(this.TrackTalent1, "TrackTalent1");
            this.TrackTalent1.LargeChange = 2;
            this.TrackTalent1.Minimum = 1;
            this.TrackTalent1.Name = "TrackTalent1";
            this.TrackTalent1.Value = 1;
            this.TrackTalent1.ValueChanged += new System.EventHandler(this.Track_ValueChanged);
            // 
            // ArrowTalent1
            // 
            resources.ApplyResources(this.ArrowTalent1, "ArrowTalent1");
            this.ArrowTalent1.Name = "ArrowTalent1";
            // 
            // NumericTalent1
            // 
            resources.ApplyResources(this.NumericTalent1, "NumericTalent1");
            this.NumericTalent1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumericTalent1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent1.Name = "NumericTalent1";
            this.NumericTalent1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent1.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // CurrentTalent1
            // 
            resources.ApplyResources(this.CurrentTalent1, "CurrentTalent1");
            this.CurrentTalent1.Name = "CurrentTalent1";
            // 
            // panel6
            // 
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Controls.Add(this.ButtonSetToTalent10);
            this.panel6.Controls.Add(this.ButtonSetToTalent9);
            this.panel6.Controls.Add(this.ButtonSetToLv90);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Name = "panel6";
            // 
            // ButtonSetToTalent10
            // 
            resources.ApplyResources(this.ButtonSetToTalent10, "ButtonSetToTalent10");
            this.ButtonSetToTalent10.Name = "ButtonSetToTalent10";
            this.ButtonSetToTalent10.UseVisualStyleBackColor = true;
            this.ButtonSetToTalent10.Click += new System.EventHandler(this.ButtonSetToTalent10_Click);
            // 
            // ButtonSetToTalent9
            // 
            resources.ApplyResources(this.ButtonSetToTalent9, "ButtonSetToTalent9");
            this.ButtonSetToTalent9.Name = "ButtonSetToTalent9";
            this.ButtonSetToTalent9.UseVisualStyleBackColor = true;
            this.ButtonSetToTalent9.Click += new System.EventHandler(this.ButtonSetToTalent9_Click);
            // 
            // ButtonSetToLv90
            // 
            resources.ApplyResources(this.ButtonSetToLv90, "ButtonSetToLv90");
            this.ButtonSetToLv90.Name = "ButtonSetToLv90";
            this.ButtonSetToLv90.UseVisualStyleBackColor = true;
            this.ButtonSetToLv90.Click += new System.EventHandler(this.ButtonSetToLv90_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.RadioDisable);
            this.groupBox1.Controls.Add(this.RadioEnable);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // RadioDisable
            // 
            resources.ApplyResources(this.RadioDisable, "RadioDisable");
            this.RadioDisable.Name = "RadioDisable";
            this.RadioDisable.TabStop = true;
            this.RadioDisable.UseVisualStyleBackColor = true;
            // 
            // RadioEnable
            // 
            resources.ApplyResources(this.RadioEnable, "RadioEnable");
            this.RadioEnable.Name = "RadioEnable";
            this.RadioEnable.TabStop = true;
            this.RadioEnable.UseVisualStyleBackColor = true;
            // 
            // BatchWindow
            // 
            this.AcceptButton = this.ButtonAppry;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.ButtonCancel;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.GroupTalent3);
            this.Controls.Add(this.GroupTalent2);
            this.Controls.Add(this.GroupTalent1);
            this.Controls.Add(this.GroupLevel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.LabelCharacterName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "BatchWindow";
            this.GroupLevel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericLevel)).EndInit();
            this.panel5.ResumeLayout(false);
            this.GroupTalent3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackTalent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTalent3)).EndInit();
            this.GroupTalent2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackTalent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTalent2)).EndInit();
            this.GroupTalent1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackTalent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericTalent1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LabelCharacterName;
        private GroupBox GroupLevel;
        private Panel panel1;
        private TrackBar TrackLevel;
        private Label ArrowLevel;
        private NumericUpDown NumericLevel;
        private Label CurrentLevel;
        private Panel panel5;
        private Button ButtonCancel;
        private Button ButtonAppry;
        private GroupBox GroupTalent3;
        private Panel panel4;
        private TrackBar TrackTalent3;
        private Label ArrowTalent3;
        private NumericUpDown NumericTalent3;
        private Label CurrentTalent3;
        private GroupBox GroupTalent2;
        private Panel panel3;
        private TrackBar TrackTalent2;
        private Label ArrowTalent2;
        private NumericUpDown NumericTalent2;
        private Label CurrentTalent2;
        private GroupBox GroupTalent1;
        private Panel panel2;
        private TrackBar TrackTalent1;
        private Label ArrowTalent1;
        private NumericUpDown NumericTalent1;
        private Label CurrentTalent1;
        private Panel panel6;
        private Button ButtonSetToTalent10;
        private Button ButtonSetToTalent9;
        private Button ButtonSetToLv90;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton RadioDisable;
        private RadioButton RadioEnable;
    }
}