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
            GraphTab = new TabControl();
            Day = new TabPage();
            Week = new TabPage();
            Month = new TabPage();
            Version = new TabPage();
            dateTimePicker1 = new DateTimePicker();
            FromLabel = new Label();
            panel1 = new Panel();
            TotalLabel = new Label();
            Prev = new Button();
            Now = new Button();
            Next = new Button();
            GraphTab.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // GraphTab
            // 
            GraphTab.Controls.Add(Day);
            GraphTab.Controls.Add(Week);
            GraphTab.Controls.Add(Month);
            GraphTab.Controls.Add(Version);
            resources.ApplyResources(GraphTab, "GraphTab");
            GraphTab.Name = "GraphTab";
            GraphTab.SelectedIndex = 0;
            GraphTab.SelectedIndexChanged += Graph_Reload;
            // 
            // Day
            // 
            resources.ApplyResources(Day, "Day");
            Day.Name = "Day";
            Day.UseVisualStyleBackColor = true;
            // 
            // Week
            // 
            resources.ApplyResources(Week, "Week");
            Week.Name = "Week";
            Week.UseVisualStyleBackColor = true;
            // 
            // Month
            // 
            resources.ApplyResources(Month, "Month");
            Month.Name = "Month";
            Month.UseVisualStyleBackColor = true;
            // 
            // Version
            // 
            resources.ApplyResources(Version, "Version");
            Version.Name = "Version";
            Version.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(dateTimePicker1, "dateTimePicker1");
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.MinDate = new DateTime(2023, 9, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ValueChanged += Graph_Reload;
            // 
            // FromLabel
            // 
            FromLabel.AutoEllipsis = true;
            resources.ApplyResources(FromLabel, "FromLabel");
            FromLabel.Name = "FromLabel";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(TotalLabel);
            panel1.Controls.Add(FromLabel);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(Prev);
            panel1.Controls.Add(Now);
            panel1.Controls.Add(Next);
            panel1.Name = "panel1";
            // 
            // TotalLabel
            // 
            TotalLabel.AutoEllipsis = true;
            resources.ApplyResources(TotalLabel, "TotalLabel");
            TotalLabel.Name = "TotalLabel";
            // 
            // Prev
            // 
            resources.ApplyResources(Prev, "Prev");
            Prev.Name = "Prev";
            Prev.UseVisualStyleBackColor = true;
            Prev.Click += Prev_Click;
            // 
            // Now
            // 
            resources.ApplyResources(Now, "Now");
            Now.Name = "Now";
            Now.UseVisualStyleBackColor = true;
            Now.Click += Now_Click;
            // 
            // Next
            // 
            resources.ApplyResources(Next, "Next");
            Next.Name = "Next";
            Next.UseVisualStyleBackColor = true;
            Next.Click += Next_Click;
            // 
            // TimeGraph
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Controls.Add(GraphTab);
            Name = "TimeGraph";
            GraphTab.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
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