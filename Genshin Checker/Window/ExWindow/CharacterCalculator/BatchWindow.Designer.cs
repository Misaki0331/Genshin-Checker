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
            this.LabelCharacterName.AutoSize = true;
            this.LabelCharacterName.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelCharacterName.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelCharacterName.Location = new System.Drawing.Point(0, 0);
            this.LabelCharacterName.Name = "LabelCharacterName";
            this.LabelCharacterName.Size = new System.Drawing.Size(96, 21);
            this.LabelCharacterName.TabIndex = 0;
            this.LabelCharacterName.Text = "キャラクター名";
            // 
            // GroupLevel
            // 
            this.GroupLevel.AutoSize = true;
            this.GroupLevel.Controls.Add(this.panel1);
            this.GroupLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupLevel.Location = new System.Drawing.Point(0, 94);
            this.GroupLevel.Name = "GroupLevel";
            this.GroupLevel.Size = new System.Drawing.Size(275, 47);
            this.GroupLevel.TabIndex = 1;
            this.GroupLevel.TabStop = false;
            this.GroupLevel.Text = "キャラクターレベル";
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.TrackLevel);
            this.panel1.Controls.Add(this.ArrowLevel);
            this.panel1.Controls.Add(this.NumericLevel);
            this.panel1.Controls.Add(this.CurrentLevel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 25);
            this.panel1.TabIndex = 0;
            // 
            // TrackLevel
            // 
            this.TrackLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackLevel.LargeChange = 10;
            this.TrackLevel.Location = new System.Drawing.Point(71, 0);
            this.TrackLevel.Maximum = 90;
            this.TrackLevel.Minimum = 1;
            this.TrackLevel.Name = "TrackLevel";
            this.TrackLevel.Size = new System.Drawing.Size(155, 25);
            this.TrackLevel.TabIndex = 3;
            this.TrackLevel.TickFrequency = 10;
            this.TrackLevel.Value = 1;
            this.TrackLevel.ValueChanged += new System.EventHandler(this.Track_ValueChanged);
            // 
            // ArrowLevel
            // 
            this.ArrowLevel.AutoSize = true;
            this.ArrowLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ArrowLevel.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArrowLevel.Location = new System.Drawing.Point(45, 0);
            this.ArrowLevel.Name = "ArrowLevel";
            this.ArrowLevel.Size = new System.Drawing.Size(26, 21);
            this.ArrowLevel.TabIndex = 2;
            this.ArrowLevel.Text = "▶";
            // 
            // NumericLevel
            // 
            this.NumericLevel.Dock = System.Windows.Forms.DockStyle.Right;
            this.NumericLevel.Location = new System.Drawing.Point(226, 0);
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
            this.NumericLevel.Size = new System.Drawing.Size(43, 23);
            this.NumericLevel.TabIndex = 1;
            this.NumericLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericLevel.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // CurrentLevel
            // 
            this.CurrentLevel.AutoSize = true;
            this.CurrentLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.CurrentLevel.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentLevel.Location = new System.Drawing.Point(0, 0);
            this.CurrentLevel.Name = "CurrentLevel";
            this.CurrentLevel.Size = new System.Drawing.Size(45, 20);
            this.CurrentLevel.TabIndex = 0;
            this.CurrentLevel.Text = "Lv. 10";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ButtonCancel);
            this.panel5.Controls.Add(this.ButtonAppry);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 282);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(275, 25);
            this.panel5.TabIndex = 5;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonCancel.Location = new System.Drawing.Point(125, 0);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 25);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "キャンセル";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonAppry
            // 
            this.ButtonAppry.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonAppry.Location = new System.Drawing.Point(200, 0);
            this.ButtonAppry.Name = "ButtonAppry";
            this.ButtonAppry.Size = new System.Drawing.Size(75, 25);
            this.ButtonAppry.TabIndex = 0;
            this.ButtonAppry.Text = "OK";
            this.ButtonAppry.UseVisualStyleBackColor = true;
            this.ButtonAppry.Click += new System.EventHandler(this.ButtonAppry_Click);
            // 
            // GroupTalent3
            // 
            this.GroupTalent3.AutoSize = true;
            this.GroupTalent3.Controls.Add(this.panel4);
            this.GroupTalent3.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupTalent3.Location = new System.Drawing.Point(0, 235);
            this.GroupTalent3.Name = "GroupTalent3";
            this.GroupTalent3.Size = new System.Drawing.Size(275, 47);
            this.GroupTalent3.TabIndex = 8;
            this.GroupTalent3.TabStop = false;
            this.GroupTalent3.Text = "元素爆発";
            // 
            // panel4
            // 
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.TrackTalent3);
            this.panel4.Controls.Add(this.ArrowTalent3);
            this.panel4.Controls.Add(this.NumericTalent3);
            this.panel4.Controls.Add(this.CurrentTalent3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(269, 25);
            this.panel4.TabIndex = 0;
            // 
            // TrackTalent3
            // 
            this.TrackTalent3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackTalent3.LargeChange = 2;
            this.TrackTalent3.Location = new System.Drawing.Point(71, 0);
            this.TrackTalent3.Minimum = 1;
            this.TrackTalent3.Name = "TrackTalent3";
            this.TrackTalent3.Size = new System.Drawing.Size(155, 25);
            this.TrackTalent3.TabIndex = 3;
            this.TrackTalent3.Value = 1;
            this.TrackTalent3.ValueChanged += new System.EventHandler(this.Track_ValueChanged);
            // 
            // ArrowTalent3
            // 
            this.ArrowTalent3.AutoSize = true;
            this.ArrowTalent3.Dock = System.Windows.Forms.DockStyle.Left;
            this.ArrowTalent3.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArrowTalent3.Location = new System.Drawing.Point(45, 0);
            this.ArrowTalent3.Name = "ArrowTalent3";
            this.ArrowTalent3.Size = new System.Drawing.Size(26, 21);
            this.ArrowTalent3.TabIndex = 2;
            this.ArrowTalent3.Text = "▶";
            // 
            // NumericTalent3
            // 
            this.NumericTalent3.Dock = System.Windows.Forms.DockStyle.Right;
            this.NumericTalent3.Location = new System.Drawing.Point(226, 0);
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
            this.NumericTalent3.Size = new System.Drawing.Size(43, 23);
            this.NumericTalent3.TabIndex = 1;
            this.NumericTalent3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericTalent3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent3.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // CurrentTalent3
            // 
            this.CurrentTalent3.AutoSize = true;
            this.CurrentTalent3.Dock = System.Windows.Forms.DockStyle.Left;
            this.CurrentTalent3.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentTalent3.Location = new System.Drawing.Point(0, 0);
            this.CurrentTalent3.Name = "CurrentTalent3";
            this.CurrentTalent3.Size = new System.Drawing.Size(45, 20);
            this.CurrentTalent3.TabIndex = 0;
            this.CurrentTalent3.Text = "Lv. 10";
            // 
            // GroupTalent2
            // 
            this.GroupTalent2.AutoSize = true;
            this.GroupTalent2.Controls.Add(this.panel3);
            this.GroupTalent2.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupTalent2.Location = new System.Drawing.Point(0, 188);
            this.GroupTalent2.Name = "GroupTalent2";
            this.GroupTalent2.Size = new System.Drawing.Size(275, 47);
            this.GroupTalent2.TabIndex = 7;
            this.GroupTalent2.TabStop = false;
            this.GroupTalent2.Text = "スキル";
            // 
            // panel3
            // 
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.TrackTalent2);
            this.panel3.Controls.Add(this.ArrowTalent2);
            this.panel3.Controls.Add(this.NumericTalent2);
            this.panel3.Controls.Add(this.CurrentTalent2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 25);
            this.panel3.TabIndex = 0;
            // 
            // TrackTalent2
            // 
            this.TrackTalent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackTalent2.LargeChange = 2;
            this.TrackTalent2.Location = new System.Drawing.Point(71, 0);
            this.TrackTalent2.Minimum = 1;
            this.TrackTalent2.Name = "TrackTalent2";
            this.TrackTalent2.Size = new System.Drawing.Size(155, 25);
            this.TrackTalent2.TabIndex = 3;
            this.TrackTalent2.Value = 1;
            this.TrackTalent2.ValueChanged += new System.EventHandler(this.Track_ValueChanged);
            // 
            // ArrowTalent2
            // 
            this.ArrowTalent2.AutoSize = true;
            this.ArrowTalent2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ArrowTalent2.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArrowTalent2.Location = new System.Drawing.Point(45, 0);
            this.ArrowTalent2.Name = "ArrowTalent2";
            this.ArrowTalent2.Size = new System.Drawing.Size(26, 21);
            this.ArrowTalent2.TabIndex = 2;
            this.ArrowTalent2.Text = "▶";
            // 
            // NumericTalent2
            // 
            this.NumericTalent2.Dock = System.Windows.Forms.DockStyle.Right;
            this.NumericTalent2.Location = new System.Drawing.Point(226, 0);
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
            this.NumericTalent2.Size = new System.Drawing.Size(43, 23);
            this.NumericTalent2.TabIndex = 1;
            this.NumericTalent2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericTalent2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent2.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // CurrentTalent2
            // 
            this.CurrentTalent2.AutoSize = true;
            this.CurrentTalent2.Dock = System.Windows.Forms.DockStyle.Left;
            this.CurrentTalent2.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentTalent2.Location = new System.Drawing.Point(0, 0);
            this.CurrentTalent2.Name = "CurrentTalent2";
            this.CurrentTalent2.Size = new System.Drawing.Size(45, 20);
            this.CurrentTalent2.TabIndex = 0;
            this.CurrentTalent2.Text = "Lv. 10";
            // 
            // GroupTalent1
            // 
            this.GroupTalent1.AutoSize = true;
            this.GroupTalent1.Controls.Add(this.panel2);
            this.GroupTalent1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupTalent1.Location = new System.Drawing.Point(0, 141);
            this.GroupTalent1.Name = "GroupTalent1";
            this.GroupTalent1.Size = new System.Drawing.Size(275, 47);
            this.GroupTalent1.TabIndex = 6;
            this.GroupTalent1.TabStop = false;
            this.GroupTalent1.Text = "通常攻撃";
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.TrackTalent1);
            this.panel2.Controls.Add(this.ArrowTalent1);
            this.panel2.Controls.Add(this.NumericTalent1);
            this.panel2.Controls.Add(this.CurrentTalent1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 25);
            this.panel2.TabIndex = 0;
            // 
            // TrackTalent1
            // 
            this.TrackTalent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrackTalent1.LargeChange = 2;
            this.TrackTalent1.Location = new System.Drawing.Point(71, 0);
            this.TrackTalent1.Minimum = 1;
            this.TrackTalent1.Name = "TrackTalent1";
            this.TrackTalent1.Size = new System.Drawing.Size(155, 25);
            this.TrackTalent1.TabIndex = 3;
            this.TrackTalent1.Value = 1;
            this.TrackTalent1.ValueChanged += new System.EventHandler(this.Track_ValueChanged);
            // 
            // ArrowTalent1
            // 
            this.ArrowTalent1.AutoSize = true;
            this.ArrowTalent1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ArrowTalent1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArrowTalent1.Location = new System.Drawing.Point(45, 0);
            this.ArrowTalent1.Name = "ArrowTalent1";
            this.ArrowTalent1.Size = new System.Drawing.Size(26, 21);
            this.ArrowTalent1.TabIndex = 2;
            this.ArrowTalent1.Text = "▶";
            // 
            // NumericTalent1
            // 
            this.NumericTalent1.Dock = System.Windows.Forms.DockStyle.Right;
            this.NumericTalent1.Location = new System.Drawing.Point(226, 0);
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
            this.NumericTalent1.Size = new System.Drawing.Size(43, 23);
            this.NumericTalent1.TabIndex = 1;
            this.NumericTalent1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumericTalent1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericTalent1.ValueChanged += new System.EventHandler(this.Numeric_ValueChanged);
            // 
            // CurrentTalent1
            // 
            this.CurrentTalent1.AutoSize = true;
            this.CurrentTalent1.Dock = System.Windows.Forms.DockStyle.Left;
            this.CurrentTalent1.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CurrentTalent1.Location = new System.Drawing.Point(0, 0);
            this.CurrentTalent1.Name = "CurrentTalent1";
            this.CurrentTalent1.Size = new System.Drawing.Size(45, 20);
            this.CurrentTalent1.TabIndex = 0;
            this.CurrentTalent1.Text = "Lv. 10";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.ButtonSetToTalent10);
            this.panel6.Controls.Add(this.ButtonSetToTalent9);
            this.panel6.Controls.Add(this.ButtonSetToLv90);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 21);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(275, 25);
            this.panel6.TabIndex = 9;
            // 
            // ButtonSetToTalent10
            // 
            this.ButtonSetToTalent10.AutoSize = true;
            this.ButtonSetToTalent10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonSetToTalent10.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonSetToTalent10.Location = new System.Drawing.Point(162, 0);
            this.ButtonSetToTalent10.Name = "ButtonSetToTalent10";
            this.ButtonSetToTalent10.Size = new System.Drawing.Size(53, 25);
            this.ButtonSetToTalent10.TabIndex = 6;
            this.ButtonSetToTalent10.Text = "天賦10";
            this.ButtonSetToTalent10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ButtonSetToTalent10.UseVisualStyleBackColor = true;
            this.ButtonSetToTalent10.Click += new System.EventHandler(this.ButtonSetToTalent10_Click);
            // 
            // ButtonSetToTalent9
            // 
            this.ButtonSetToTalent9.AutoSize = true;
            this.ButtonSetToTalent9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonSetToTalent9.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonSetToTalent9.Location = new System.Drawing.Point(115, 0);
            this.ButtonSetToTalent9.Name = "ButtonSetToTalent9";
            this.ButtonSetToTalent9.Size = new System.Drawing.Size(47, 25);
            this.ButtonSetToTalent9.TabIndex = 4;
            this.ButtonSetToTalent9.Text = "天賦9";
            this.ButtonSetToTalent9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ButtonSetToTalent9.UseVisualStyleBackColor = true;
            this.ButtonSetToTalent9.Click += new System.EventHandler(this.ButtonSetToTalent9_Click);
            // 
            // ButtonSetToLv90
            // 
            this.ButtonSetToLv90.AutoSize = true;
            this.ButtonSetToLv90.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonSetToLv90.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonSetToLv90.Location = new System.Drawing.Point(72, 0);
            this.ButtonSetToLv90.Name = "ButtonSetToLv90";
            this.ButtonSetToLv90.Size = new System.Drawing.Size(43, 25);
            this.ButtonSetToLv90.TabIndex = 3;
            this.ButtonSetToLv90.Text = "Lv.90";
            this.ButtonSetToLv90.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ButtonSetToLv90.UseVisualStyleBackColor = true;
            this.ButtonSetToLv90.Click += new System.EventHandler(this.ButtonSetToLv90_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.MinimumSize = new System.Drawing.Size(0, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "クイック調整 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioDisable);
            this.groupBox1.Controls.Add(this.RadioEnable);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 48);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "育成ステータス";
            // 
            // RadioDisable
            // 
            this.RadioDisable.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioDisable.AutoSize = true;
            this.RadioDisable.Dock = System.Windows.Forms.DockStyle.Right;
            this.RadioDisable.Location = new System.Drawing.Point(190, 19);
            this.RadioDisable.Name = "RadioDisable";
            this.RadioDisable.Size = new System.Drawing.Size(41, 26);
            this.RadioDisable.TabIndex = 1;
            this.RadioDisable.TabStop = true;
            this.RadioDisable.Text = "無効";
            this.RadioDisable.UseVisualStyleBackColor = true;
            // 
            // RadioEnable
            // 
            this.RadioEnable.Appearance = System.Windows.Forms.Appearance.Button;
            this.RadioEnable.AutoSize = true;
            this.RadioEnable.Dock = System.Windows.Forms.DockStyle.Right;
            this.RadioEnable.Location = new System.Drawing.Point(231, 19);
            this.RadioEnable.Name = "RadioEnable";
            this.RadioEnable.Size = new System.Drawing.Size(41, 26);
            this.RadioEnable.TabIndex = 0;
            this.RadioEnable.TabStop = true;
            this.RadioEnable.Text = "有効";
            this.RadioEnable.UseVisualStyleBackColor = true;
            // 
            // BatchWindow
            // 
            this.AcceptButton = this.ButtonAppry;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(275, 319);
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
            this.MinimumSize = new System.Drawing.Size(291, 0);
            this.Name = "BatchWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BatchWindow";
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