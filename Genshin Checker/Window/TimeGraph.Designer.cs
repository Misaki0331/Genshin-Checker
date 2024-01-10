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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeGraph));
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
            resources.ApplyResources(this.GraphTab, "GraphTab");
            this.GraphTab.Name = "GraphTab";
            this.GraphTab.SelectedIndex = 0;
            this.GraphTab.SelectedIndexChanged += new System.EventHandler(this.Graph_Reload);
            // 
            // Day
            // 
            resources.ApplyResources(this.Day, "Day");
            this.Day.Name = "Day";
            this.Day.UseVisualStyleBackColor = true;
            // 
            // Week
            // 
            resources.ApplyResources(this.Week, "Week");
            this.Week.Name = "Week";
            this.Week.UseVisualStyleBackColor = true;
            // 
            // Month
            // 
            resources.ApplyResources(this.Month, "Month");
            this.Month.Name = "Month";
            this.Month.UseVisualStyleBackColor = true;
            // 
            // Version
            // 
            resources.ApplyResources(this.Version, "Version");
            this.Version.Name = "Version";
            this.Version.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.MinDate = new System.DateTime(2023, 9, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.Graph_Reload);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoEllipsis = true;
            resources.ApplyResources(this.FromLabel, "FromLabel");
            this.FromLabel.Name = "FromLabel";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.TotalLabel);
            this.panel1.Controls.Add(this.FromLabel);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.Prev);
            this.panel1.Controls.Add(this.Now);
            this.panel1.Controls.Add(this.Next);
            this.panel1.Name = "panel1";
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoEllipsis = true;
            resources.ApplyResources(this.TotalLabel, "TotalLabel");
            this.TotalLabel.Name = "TotalLabel";
            // 
            // Prev
            // 
            resources.ApplyResources(this.Prev, "Prev");
            this.Prev.Name = "Prev";
            this.Prev.UseVisualStyleBackColor = true;
            this.Prev.Click += new System.EventHandler(this.Prev_Click);
            // 
            // Now
            // 
            resources.ApplyResources(this.Now, "Now");
            this.Now.Name = "Now";
            this.Now.UseVisualStyleBackColor = true;
            this.Now.Click += new System.EventHandler(this.Now_Click);
            // 
            // Next
            // 
            resources.ApplyResources(this.Next, "Next");
            this.Next.Name = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // TimeGraph
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GraphTab);
            this.Name = "TimeGraph";
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