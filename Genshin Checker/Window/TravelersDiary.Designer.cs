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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Today_Primogem = new System.Windows.Forms.Label();
            this.Today_Mora = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Month_Mora_Diff = new System.Windows.Forms.Label();
            this.Month_Primogem_Diff = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Month_Primogem = new System.Windows.Forms.Label();
            this.Month_Mora = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.UIUpdate = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Today_Primogem);
            this.panel1.Controls.Add(this.Today_Mora);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 202);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Genshin_Checker.resource.icon.Item_Primogem;
            this.pictureBox2.Location = new System.Drawing.Point(329, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Genshin_Checker.resource.icon.Item_Mora;
            this.pictureBox1.Location = new System.Drawing.Point(329, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Today_Primogem
            // 
            this.Today_Primogem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Today_Primogem.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Today_Primogem.ForeColor = System.Drawing.Color.White;
            this.Today_Primogem.Location = new System.Drawing.Point(-38, 40);
            this.Today_Primogem.Name = "Today_Primogem";
            this.Today_Primogem.Size = new System.Drawing.Size(361, 64);
            this.Today_Primogem.TabIndex = 1;
            this.Today_Primogem.Text = "0";
            this.Today_Primogem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Today_Mora
            // 
            this.Today_Mora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Today_Mora.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Today_Mora.ForeColor = System.Drawing.Color.White;
            this.Today_Mora.Location = new System.Drawing.Point(-38, 104);
            this.Today_Mora.Name = "Today_Mora";
            this.Today_Mora.Size = new System.Drawing.Size(361, 64);
            this.Today_Mora.TabIndex = 1;
            this.Today_Mora.Text = "0";
            this.Today_Mora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "今日の収穫";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 474);
            this.panel2.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 226);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(396, 248);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tabPage1.Controls.Add(this.Month_Mora_Diff);
            this.tabPage1.Controls.Add(this.Month_Primogem_Diff);
            this.tabPage1.Controls.Add(this.pictureBox3);
            this.tabPage1.Controls.Add(this.pictureBox4);
            this.tabPage1.Controls.Add(this.Month_Primogem);
            this.tabPage1.Controls.Add(this.Month_Mora);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(388, 220);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "月のデータ";
            // 
            // Month_Mora_Diff
            // 
            this.Month_Mora_Diff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Month_Mora_Diff.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Month_Mora_Diff.ForeColor = System.Drawing.Color.White;
            this.Month_Mora_Diff.Location = new System.Drawing.Point(118, 163);
            this.Month_Mora_Diff.Name = "Month_Mora_Diff";
            this.Month_Mora_Diff.Size = new System.Drawing.Size(201, 26);
            this.Month_Mora_Diff.TabIndex = 8;
            this.Month_Mora_Diff.Text = "+0";
            this.Month_Mora_Diff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Month_Primogem_Diff
            // 
            this.Month_Primogem_Diff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Month_Primogem_Diff.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Month_Primogem_Diff.ForeColor = System.Drawing.Color.White;
            this.Month_Primogem_Diff.Location = new System.Drawing.Point(143, 70);
            this.Month_Primogem_Diff.Name = "Month_Primogem_Diff";
            this.Month_Primogem_Diff.Size = new System.Drawing.Size(176, 26);
            this.Month_Primogem_Diff.TabIndex = 7;
            this.Month_Primogem_Diff.Text = "+0";
            this.Month_Primogem_Diff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::Genshin_Checker.resource.icon.Item_Primogem;
            this.pictureBox3.Location = new System.Drawing.Point(325, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::Genshin_Checker.resource.icon.Item_Mora;
            this.pictureBox4.Location = new System.Drawing.Point(325, 99);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 64);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // Month_Primogem
            // 
            this.Month_Primogem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Month_Primogem.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Month_Primogem.ForeColor = System.Drawing.Color.White;
            this.Month_Primogem.Location = new System.Drawing.Point(-42, 6);
            this.Month_Primogem.Name = "Month_Primogem";
            this.Month_Primogem.Size = new System.Drawing.Size(361, 64);
            this.Month_Primogem.TabIndex = 3;
            this.Month_Primogem.Text = "0";
            this.Month_Primogem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Month_Mora
            // 
            this.Month_Mora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Month_Mora.Font = new System.Drawing.Font("Meiryo UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Month_Mora.ForeColor = System.Drawing.Color.White;
            this.Month_Mora.Location = new System.Drawing.Point(-42, 99);
            this.Month_Mora.Name = "Month_Mora";
            this.Month_Mora.Size = new System.Drawing.Size(361, 64);
            this.Month_Mora.TabIndex = 4;
            this.Month_Mora.Text = "0";
            this.Month_Mora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(388, 220);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "原石獲得比率";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Navy;
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 202);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 24);
            this.panel3.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(275, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // UIUpdate
            // 
            this.UIUpdate.Enabled = true;
            this.UIUpdate.Interval = 1000;
            this.UIUpdate.Tick += new System.EventHandler(this.UIUpdate_Tick);
            // 
            // TravelersDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(396, 474);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TravelersDiary";
            this.Text = "旅人手帳";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

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