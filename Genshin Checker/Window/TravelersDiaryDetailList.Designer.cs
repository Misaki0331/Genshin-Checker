namespace Genshin_Checker.Window
{
    partial class TravelersDiaryDetailList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ObtainTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GainNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.monthlist = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listtype = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObtainTime,
            this.EventID,
            this.EventName,
            this.GainNum});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(443, 570);
            this.dataGridView1.TabIndex = 0;
            // 
            // ObtainTime
            // 
            this.ObtainTime.FillWeight = 140F;
            this.ObtainTime.HeaderText = "取得時刻";
            this.ObtainTime.Name = "ObtainTime";
            this.ObtainTime.ReadOnly = true;
            this.ObtainTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ObtainTime.Width = 140;
            // 
            // EventID
            // 
            this.EventID.FillWeight = 60F;
            this.EventID.HeaderText = "分類ID";
            this.EventID.Name = "EventID";
            this.EventID.ReadOnly = true;
            this.EventID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EventID.Width = 65;
            // 
            // EventName
            // 
            this.EventName.HeaderText = "分類名";
            this.EventName.Name = "EventName";
            this.EventName.ReadOnly = true;
            this.EventName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EventName.Width = 150;
            // 
            // GainNum
            // 
            this.GainNum.FillWeight = 80F;
            this.GainNum.HeaderText = "獲得量";
            this.GainNum.Name = "GainNum";
            this.GainNum.ReadOnly = true;
            this.GainNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.GainNum.Width = 67;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.monthlist);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.listtype);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 24);
            this.panel1.TabIndex = 1;
            // 
            // monthlist
            // 
            this.monthlist.Dock = System.Windows.Forms.DockStyle.Right;
            this.monthlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthlist.FormattingEnabled = true;
            this.monthlist.Location = new System.Drawing.Point(257, 0);
            this.monthlist.Name = "monthlist";
            this.monthlist.Size = new System.Drawing.Size(121, 23);
            this.monthlist.TabIndex = 1;
            this.monthlist.SelectedIndexChanged += new System.EventHandler(this.UpdateComboBox);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "データの更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listtype
            // 
            this.listtype.Dock = System.Windows.Forms.DockStyle.Right;
            this.listtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listtype.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.listtype.FormattingEnabled = true;
            this.listtype.Location = new System.Drawing.Point(378, 0);
            this.listtype.Name = "listtype";
            this.listtype.Size = new System.Drawing.Size(65, 23);
            this.listtype.TabIndex = 3;
            this.listtype.SelectedIndexChanged += new System.EventHandler(this.UpdateComboBox);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(443, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Maximum = 10000;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "準備完了";
            // 
            // TravelersDiaryDetailList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 616);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "TravelersDiaryDetailList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TravelersDiaryDetailList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TravelersDiaryDetailList_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private ComboBox monthlist;
        private Button button1;
        private ComboBox listtype;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private DataGridViewTextBoxColumn ObtainTime;
        private DataGridViewTextBoxColumn EventID;
        private DataGridViewTextBoxColumn EventName;
        private DataGridViewTextBoxColumn GainNum;
    }
}