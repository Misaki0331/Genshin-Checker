namespace Genshin_Checker.Window
{
    partial class TravelersDiary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravelersDiary));
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            Today_Primogem = new Label();
            Today_Mora = new Label();
            label1 = new Label();
            panel2 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            Month_Mora_Diff = new Label();
            Month_Primogem_Diff = new Label();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            Month_Primogem = new Label();
            Month_Mora = new Label();
            tabPage2 = new TabPage();
            panel3 = new Panel();
            comboBox1 = new ComboBox();
            UIUpdate = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(Today_Primogem);
            panel1.Controls.Add(Today_Mora);
            panel1.Controls.Add(label1);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Image = resource.icon.Item_Primogem;
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = resource.icon.Item_Mora;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // Today_Primogem
            // 
            resources.ApplyResources(Today_Primogem, "Today_Primogem");
            Today_Primogem.ForeColor = Color.White;
            Today_Primogem.Name = "Today_Primogem";
            // 
            // Today_Mora
            // 
            resources.ApplyResources(Today_Mora, "Today_Mora");
            Today_Mora.ForeColor = Color.White;
            Today_Mora.Name = "Today_Mora";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.White;
            label1.Name = "label1";
            // 
            // panel2
            // 
            panel2.Controls.Add(tabControl1);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(0, 0, 64);
            tabPage1.Controls.Add(Month_Mora_Diff);
            tabPage1.Controls.Add(Month_Primogem_Diff);
            tabPage1.Controls.Add(pictureBox3);
            tabPage1.Controls.Add(pictureBox4);
            tabPage1.Controls.Add(Month_Primogem);
            tabPage1.Controls.Add(Month_Mora);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            // 
            // Month_Mora_Diff
            // 
            resources.ApplyResources(Month_Mora_Diff, "Month_Mora_Diff");
            Month_Mora_Diff.ForeColor = Color.White;
            Month_Mora_Diff.Name = "Month_Mora_Diff";
            // 
            // Month_Primogem_Diff
            // 
            resources.ApplyResources(Month_Primogem_Diff, "Month_Primogem_Diff");
            Month_Primogem_Diff.ForeColor = Color.White;
            Month_Primogem_Diff.Name = "Month_Primogem_Diff";
            // 
            // pictureBox3
            // 
            resources.ApplyResources(pictureBox3, "pictureBox3");
            pictureBox3.Image = resource.icon.Item_Primogem;
            pictureBox3.Name = "pictureBox3";
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            resources.ApplyResources(pictureBox4, "pictureBox4");
            pictureBox4.Image = resource.icon.Item_Mora;
            pictureBox4.Name = "pictureBox4";
            pictureBox4.TabStop = false;
            // 
            // Month_Primogem
            // 
            resources.ApplyResources(Month_Primogem, "Month_Primogem");
            Month_Primogem.ForeColor = Color.White;
            Month_Primogem.Name = "Month_Primogem";
            // 
            // Month_Mora
            // 
            resources.ApplyResources(Month_Mora, "Month_Mora");
            Month_Mora.ForeColor = Color.White;
            Month_Mora.Name = "Month_Mora";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(0, 0, 64);
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Navy;
            panel3.Controls.Add(comboBox1);
            resources.ApplyResources(panel3, "panel3");
            panel3.Name = "panel3";
            // 
            // comboBox1
            // 
            resources.ApplyResources(comboBox1, "comboBox1");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Name = "comboBox1";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // UIUpdate
            // 
            UIUpdate.Enabled = true;
            UIUpdate.Interval = 1000;
            UIUpdate.Tick += UIUpdate_Tick;
            // 
            // TravelersDiary
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(0, 0, 64);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "TravelersDiary";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label Today_Mora;
        private PictureBox pictureBox2;
        private Label Today_Primogem;
        private Panel panel2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label Month_Mora_Diff;
        private Label Month_Primogem_Diff;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label Month_Primogem;
        private Label Month_Mora;
        private Panel panel3;
        private ComboBox comboBox1;
        private TabPage tabPage2;
        private System.Windows.Forms.Timer UIUpdate;
    }
}