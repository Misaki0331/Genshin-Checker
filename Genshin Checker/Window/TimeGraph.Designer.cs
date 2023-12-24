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
            this.GraphTab = new System.Windows.Forms.TabControl();
            this.Day = new System.Windows.Forms.TabPage();
            this.Week = new System.Windows.Forms.TabPage();
            this.Month = new System.Windows.Forms.TabPage();
            this.Version = new System.Windows.Forms.TabPage();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.FromLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.Prev = new System.Windows.Forms.Button();
            this.Now = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.GraphTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphTab
            // 
            this.GraphTab.Controls.Add(this.Day);
            this.GraphTab.Controls.Add(this.Week);
            this.GraphTab.Controls.Add(this.Month);
            this.GraphTab.Controls.Add(this.Version);
            this.GraphTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GraphTab.Location = new System.Drawing.Point(0, 0);
            this.GraphTab.Name = "GraphTab";
            this.GraphTab.SelectedIndex = 0;
            this.GraphTab.Size = new System.Drawing.Size(627, 463);
            this.GraphTab.TabIndex = 0;
            this.GraphTab.SelectedIndexChanged += new System.EventHandler(this.Graph_Reload);
            // 
            // Day
            // 
            this.Day.Location = new System.Drawing.Point(4, 24);
            this.Day.Name = "Day";
            this.Day.Padding = new System.Windows.Forms.Padding(3);
            this.Day.Size = new System.Drawing.Size(619, 435);
            this.Day.TabIndex = 0;
            this.Day.Text = "1日間";
            this.Day.UseVisualStyleBackColor = true;
            // 
            // Week
            // 
            this.Week.Location = new System.Drawing.Point(4, 24);
            this.Week.Name = "Week";
            this.Week.Padding = new System.Windows.Forms.Padding(3);
            this.Week.Size = new System.Drawing.Size(619, 435);
            this.Week.TabIndex = 1;
            this.Week.Text = "1週間";
            this.Week.UseVisualStyleBackColor = true;
            // 
            // Month
            // 
            this.Month.Location = new System.Drawing.Point(4, 24);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(619, 435);
            this.Month.TabIndex = 2;
            this.Month.Text = "1か月";
            this.Month.UseVisualStyleBackColor = true;
            // 
            // Version
            // 
            this.Version.Location = new System.Drawing.Point(4, 24);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(619, 435);
            this.Version.TabIndex = 3;
            this.Version.Text = "バージョン毎";
            this.Version.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(207, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2023, 9, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(79, 23);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.Graph_Reload);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoEllipsis = true;
            this.FromLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.FromLabel.Location = new System.Drawing.Point(94, 0);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(113, 24);
            this.FromLabel.TabIndex = 2;
            this.FromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.TotalLabel);
            this.panel1.Controls.Add(this.FromLabel);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.Prev);
            this.panel1.Controls.Add(this.Now);
            this.panel1.Controls.Add(this.Next);
            this.panel1.Location = new System.Drawing.Point(216, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 24);
            this.panel1.TabIndex = 3;
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoEllipsis = true;
            this.TotalLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.TotalLabel.Location = new System.Drawing.Point(3, 0);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(91, 24);
            this.TotalLabel.TabIndex = 6;
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Prev
            // 
            this.Prev.Dock = System.Windows.Forms.DockStyle.Right;
            this.Prev.Location = new System.Drawing.Point(286, 0);
            this.Prev.Name = "Prev";
            this.Prev.Size = new System.Drawing.Size(41, 24);
            this.Prev.TabIndex = 3;
            this.Prev.Text = "Prev";
            this.Prev.UseVisualStyleBackColor = true;
            this.Prev.Click += new System.EventHandler(this.Prev_Click);
            // 
            // Now
            // 
            this.Now.Dock = System.Windows.Forms.DockStyle.Right;
            this.Now.Location = new System.Drawing.Point(327, 0);
            this.Now.Name = "Now";
            this.Now.Size = new System.Drawing.Size(41, 24);
            this.Now.TabIndex = 4;
            this.Now.Text = "Now";
            this.Now.UseVisualStyleBackColor = true;
            this.Now.Click += new System.EventHandler(this.Now_Click);
            // 
            // Next
            // 
            this.Next.Dock = System.Windows.Forms.DockStyle.Right;
            this.Next.Location = new System.Drawing.Point(368, 0);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(41, 24);
            this.Next.TabIndex = 5;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // TimeGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(627, 463);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GraphTab);
            this.Name = "TimeGraph";
            this.Text = "詳細プレイ時間";
            this.GraphTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl GraphTab;
        private TabPage Day;
        private TabPage Week;
        private TabPage Month;
        private TabPage Version;
        private DateTimePicker dateTimePicker1;
        private Label FromLabel;
        private Panel panel1;
        private Label TotalLabel;
        private Button Prev;
        private Button Now;
        private Button Next;
    }
}