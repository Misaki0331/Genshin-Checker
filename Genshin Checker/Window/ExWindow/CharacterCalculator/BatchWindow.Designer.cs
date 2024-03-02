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
            LabelCharacterName = new Label();
            GroupLevel = new GroupBox();
            panel1 = new Panel();
            TrackLevel = new TrackBar();
            ArrowLevel = new Label();
            NumericLevel = new NumericUpDown();
            CurrentLevel = new Label();
            panel5 = new Panel();
            ButtonCancel = new Button();
            ButtonAppry = new Button();
            GroupTalent3 = new GroupBox();
            panel4 = new Panel();
            TrackTalent3 = new TrackBar();
            ArrowTalent3 = new Label();
            NumericTalent3 = new NumericUpDown();
            CurrentTalent3 = new Label();
            GroupTalent2 = new GroupBox();
            panel3 = new Panel();
            TrackTalent2 = new TrackBar();
            ArrowTalent2 = new Label();
            NumericTalent2 = new NumericUpDown();
            CurrentTalent2 = new Label();
            GroupTalent1 = new GroupBox();
            panel2 = new Panel();
            TrackTalent1 = new TrackBar();
            ArrowTalent1 = new Label();
            NumericTalent1 = new NumericUpDown();
            CurrentTalent1 = new Label();
            panel6 = new Panel();
            ButtonSetToTalent10 = new Button();
            ButtonSetToTalent9 = new Button();
            ButtonSetToLv90 = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            RadioDisable = new RadioButton();
            RadioEnable = new RadioButton();
            GroupLevel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericLevel).BeginInit();
            panel5.SuspendLayout();
            GroupTalent3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackTalent3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericTalent3).BeginInit();
            GroupTalent2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackTalent2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericTalent2).BeginInit();
            GroupTalent1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackTalent1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericTalent1).BeginInit();
            panel6.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // LabelCharacterName
            // 
            resources.ApplyResources(LabelCharacterName, "LabelCharacterName");
            LabelCharacterName.Name = "LabelCharacterName";
            // 
            // GroupLevel
            // 
            resources.ApplyResources(GroupLevel, "GroupLevel");
            GroupLevel.Controls.Add(panel1);
            GroupLevel.Name = "GroupLevel";
            GroupLevel.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(TrackLevel);
            panel1.Controls.Add(ArrowLevel);
            panel1.Controls.Add(NumericLevel);
            panel1.Controls.Add(CurrentLevel);
            panel1.Name = "panel1";
            // 
            // TrackLevel
            // 
            resources.ApplyResources(TrackLevel, "TrackLevel");
            TrackLevel.LargeChange = 10;
            TrackLevel.Maximum = 90;
            TrackLevel.Minimum = 1;
            TrackLevel.Name = "TrackLevel";
            TrackLevel.TickFrequency = 10;
            TrackLevel.Value = 1;
            TrackLevel.ValueChanged += Track_ValueChanged;
            // 
            // ArrowLevel
            // 
            resources.ApplyResources(ArrowLevel, "ArrowLevel");
            ArrowLevel.Name = "ArrowLevel";
            // 
            // NumericLevel
            // 
            resources.ApplyResources(NumericLevel, "NumericLevel");
            NumericLevel.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            NumericLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericLevel.Name = "NumericLevel";
            NumericLevel.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericLevel.ValueChanged += Numeric_ValueChanged;
            // 
            // CurrentLevel
            // 
            resources.ApplyResources(CurrentLevel, "CurrentLevel");
            CurrentLevel.Name = "CurrentLevel";
            // 
            // panel5
            // 
            resources.ApplyResources(panel5, "panel5");
            panel5.Controls.Add(ButtonCancel);
            panel5.Controls.Add(ButtonAppry);
            panel5.Name = "panel5";
            // 
            // ButtonCancel
            // 
            resources.ApplyResources(ButtonCancel, "ButtonCancel");
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // ButtonAppry
            // 
            resources.ApplyResources(ButtonAppry, "ButtonAppry");
            ButtonAppry.Name = "ButtonAppry";
            ButtonAppry.UseVisualStyleBackColor = true;
            ButtonAppry.Click += ButtonAppry_Click;
            // 
            // GroupTalent3
            // 
            resources.ApplyResources(GroupTalent3, "GroupTalent3");
            GroupTalent3.Controls.Add(panel4);
            GroupTalent3.Name = "GroupTalent3";
            GroupTalent3.TabStop = false;
            // 
            // panel4
            // 
            resources.ApplyResources(panel4, "panel4");
            panel4.Controls.Add(TrackTalent3);
            panel4.Controls.Add(ArrowTalent3);
            panel4.Controls.Add(NumericTalent3);
            panel4.Controls.Add(CurrentTalent3);
            panel4.Name = "panel4";
            // 
            // TrackTalent3
            // 
            resources.ApplyResources(TrackTalent3, "TrackTalent3");
            TrackTalent3.LargeChange = 2;
            TrackTalent3.Minimum = 1;
            TrackTalent3.Name = "TrackTalent3";
            TrackTalent3.Value = 1;
            TrackTalent3.ValueChanged += Track_ValueChanged;
            // 
            // ArrowTalent3
            // 
            resources.ApplyResources(ArrowTalent3, "ArrowTalent3");
            ArrowTalent3.Name = "ArrowTalent3";
            // 
            // NumericTalent3
            // 
            resources.ApplyResources(NumericTalent3, "NumericTalent3");
            NumericTalent3.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumericTalent3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericTalent3.Name = "NumericTalent3";
            NumericTalent3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericTalent3.ValueChanged += Numeric_ValueChanged;
            // 
            // CurrentTalent3
            // 
            resources.ApplyResources(CurrentTalent3, "CurrentTalent3");
            CurrentTalent3.Name = "CurrentTalent3";
            // 
            // GroupTalent2
            // 
            resources.ApplyResources(GroupTalent2, "GroupTalent2");
            GroupTalent2.Controls.Add(panel3);
            GroupTalent2.Name = "GroupTalent2";
            GroupTalent2.TabStop = false;
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Controls.Add(TrackTalent2);
            panel3.Controls.Add(ArrowTalent2);
            panel3.Controls.Add(NumericTalent2);
            panel3.Controls.Add(CurrentTalent2);
            panel3.Name = "panel3";
            // 
            // TrackTalent2
            // 
            resources.ApplyResources(TrackTalent2, "TrackTalent2");
            TrackTalent2.LargeChange = 2;
            TrackTalent2.Minimum = 1;
            TrackTalent2.Name = "TrackTalent2";
            TrackTalent2.Value = 1;
            TrackTalent2.ValueChanged += Track_ValueChanged;
            // 
            // ArrowTalent2
            // 
            resources.ApplyResources(ArrowTalent2, "ArrowTalent2");
            ArrowTalent2.Name = "ArrowTalent2";
            // 
            // NumericTalent2
            // 
            resources.ApplyResources(NumericTalent2, "NumericTalent2");
            NumericTalent2.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumericTalent2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericTalent2.Name = "NumericTalent2";
            NumericTalent2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericTalent2.ValueChanged += Numeric_ValueChanged;
            // 
            // CurrentTalent2
            // 
            resources.ApplyResources(CurrentTalent2, "CurrentTalent2");
            CurrentTalent2.Name = "CurrentTalent2";
            // 
            // GroupTalent1
            // 
            resources.ApplyResources(GroupTalent1, "GroupTalent1");
            GroupTalent1.Controls.Add(panel2);
            GroupTalent1.Name = "GroupTalent1";
            GroupTalent1.TabStop = false;
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(TrackTalent1);
            panel2.Controls.Add(ArrowTalent1);
            panel2.Controls.Add(NumericTalent1);
            panel2.Controls.Add(CurrentTalent1);
            panel2.Name = "panel2";
            // 
            // TrackTalent1
            // 
            resources.ApplyResources(TrackTalent1, "TrackTalent1");
            TrackTalent1.LargeChange = 2;
            TrackTalent1.Minimum = 1;
            TrackTalent1.Name = "TrackTalent1";
            TrackTalent1.Value = 1;
            TrackTalent1.ValueChanged += Track_ValueChanged;
            // 
            // ArrowTalent1
            // 
            resources.ApplyResources(ArrowTalent1, "ArrowTalent1");
            ArrowTalent1.Name = "ArrowTalent1";
            // 
            // NumericTalent1
            // 
            resources.ApplyResources(NumericTalent1, "NumericTalent1");
            NumericTalent1.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NumericTalent1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NumericTalent1.Name = "NumericTalent1";
            NumericTalent1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NumericTalent1.ValueChanged += Numeric_ValueChanged;
            // 
            // CurrentTalent1
            // 
            resources.ApplyResources(CurrentTalent1, "CurrentTalent1");
            CurrentTalent1.Name = "CurrentTalent1";
            // 
            // panel6
            // 
            resources.ApplyResources(panel6, "panel6");
            panel6.Controls.Add(ButtonSetToTalent10);
            panel6.Controls.Add(ButtonSetToTalent9);
            panel6.Controls.Add(ButtonSetToLv90);
            panel6.Controls.Add(label1);
            panel6.Name = "panel6";
            // 
            // ButtonSetToTalent10
            // 
            resources.ApplyResources(ButtonSetToTalent10, "ButtonSetToTalent10");
            ButtonSetToTalent10.Name = "ButtonSetToTalent10";
            ButtonSetToTalent10.UseVisualStyleBackColor = true;
            ButtonSetToTalent10.Click += ButtonSetToTalent10_Click;
            // 
            // ButtonSetToTalent9
            // 
            resources.ApplyResources(ButtonSetToTalent9, "ButtonSetToTalent9");
            ButtonSetToTalent9.Name = "ButtonSetToTalent9";
            ButtonSetToTalent9.UseVisualStyleBackColor = true;
            ButtonSetToTalent9.Click += ButtonSetToTalent9_Click;
            // 
            // ButtonSetToLv90
            // 
            resources.ApplyResources(ButtonSetToLv90, "ButtonSetToLv90");
            ButtonSetToLv90.Name = "ButtonSetToLv90";
            ButtonSetToLv90.UseVisualStyleBackColor = true;
            ButtonSetToLv90.Click += ButtonSetToLv90_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(RadioDisable);
            groupBox1.Controls.Add(RadioEnable);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // RadioDisable
            // 
            resources.ApplyResources(RadioDisable, "RadioDisable");
            RadioDisable.Name = "RadioDisable";
            RadioDisable.TabStop = true;
            RadioDisable.UseVisualStyleBackColor = true;
            // 
            // RadioEnable
            // 
            resources.ApplyResources(RadioEnable, "RadioEnable");
            RadioEnable.Name = "RadioEnable";
            RadioEnable.TabStop = true;
            RadioEnable.UseVisualStyleBackColor = true;
            // 
            // BatchWindow
            // 
            AcceptButton = ButtonAppry;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = ButtonCancel;
            Controls.Add(panel5);
            Controls.Add(GroupTalent3);
            Controls.Add(GroupTalent2);
            Controls.Add(GroupTalent1);
            Controls.Add(GroupLevel);
            Controls.Add(groupBox1);
            Controls.Add(panel6);
            Controls.Add(LabelCharacterName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Name = "BatchWindow";
            GroupLevel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericLevel).EndInit();
            panel5.ResumeLayout(false);
            GroupTalent3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackTalent3).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericTalent3).EndInit();
            GroupTalent2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackTalent2).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericTalent2).EndInit();
            GroupTalent1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackTalent1).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericTalent1).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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