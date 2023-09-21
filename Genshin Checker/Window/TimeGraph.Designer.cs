namespace Genshin_Checker.Window
{
    partial class TimeGraph
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Day = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.DailyGraph = new System.Windows.Forms.PictureBox();
            this.Week = new System.Windows.Forms.TabPage();
            this.Month = new System.Windows.Forms.TabPage();
            this.Version = new System.Windows.Forms.TabPage();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.Day.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DailyGraph)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Day);
            this.tabControl1.Controls.Add(this.Week);
            this.tabControl1.Controls.Add(this.Month);
            this.tabControl1.Controls.Add(this.Version);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 306);
            this.tabControl1.TabIndex = 0;
            // 
            // Day
            // 
            this.Day.Controls.Add(this.comboBox1);
            this.Day.Controls.Add(this.DailyGraph);
            this.Day.Location = new System.Drawing.Point(4, 24);
            this.Day.Name = "Day";
            this.Day.Padding = new System.Windows.Forms.Padding(3);
            this.Day.Size = new System.Drawing.Size(488, 278);
            this.Day.TabIndex = 0;
            this.Day.Text = "1日間";
            this.Day.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "時間毎のプレイ時間遷移",
            "タイムライン(24時間)"});
            this.comboBox1.Location = new System.Drawing.Point(336, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 23);
            this.comboBox1.TabIndex = 1;
            // 
            // DailyGraph
            // 
            this.DailyGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DailyGraph.Location = new System.Drawing.Point(3, 3);
            this.DailyGraph.Name = "DailyGraph";
            this.DailyGraph.Size = new System.Drawing.Size(482, 272);
            this.DailyGraph.TabIndex = 0;
            this.DailyGraph.TabStop = false;
            this.DailyGraph.Resize += new System.EventHandler(this.DailyGraph_Resize);
            // 
            // Week
            // 
            this.Week.Location = new System.Drawing.Point(4, 24);
            this.Week.Name = "Week";
            this.Week.Padding = new System.Windows.Forms.Padding(3);
            this.Week.Size = new System.Drawing.Size(488, 278);
            this.Week.TabIndex = 1;
            this.Week.Text = "1週間";
            this.Week.UseVisualStyleBackColor = true;
            // 
            // Month
            // 
            this.Month.Location = new System.Drawing.Point(4, 24);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(488, 278);
            this.Month.TabIndex = 2;
            this.Month.Text = "1か月";
            this.Month.UseVisualStyleBackColor = true;
            // 
            // Version
            // 
            this.Version.Location = new System.Drawing.Point(4, 24);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(488, 278);
            this.Version.TabIndex = 3;
            this.Version.Text = "バージョン毎";
            this.Version.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(182, 1);
            this.dateTimePicker1.MinDate = new System.DateTime(2023, 9, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(79, 23);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "開始日";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(65, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "XXXX/XX/XX ～";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(233, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 24);
            this.panel1.TabIndex = 3;
            // 
            // TimeGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 306);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "TimeGraph";
            this.Text = "TimeGraph";
            this.tabControl1.ResumeLayout(false);
            this.Day.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DailyGraph)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage Day;
        private PictureBox DailyGraph;
        private TabPage Week;
        private TabPage Month;
        private TabPage Version;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private ComboBox comboBox1;
    }
}