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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravelersDiaryDetailList));
            toolStripContainer1 = new ToolStripContainer();
            menuStrip1 = new MenuStrip();
            ファイルToolStripMenuItem = new ToolStripMenuItem();
            cSV出力ToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            button2 = new Button();
            monthlist = new ComboBox();
            button1 = new Button();
            listtype = new ComboBox();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar1 = new ToolStripProgressBar();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            saveFileDialog1 = new SaveFileDialog();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip1);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            resources.ApplyResources(ファイルToolStripMenuItem, "ファイルToolStripMenuItem");
            ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cSV出力ToolStripMenuItem });
            ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            // 
            // cSV出力ToolStripMenuItem
            // 
            resources.ApplyResources(cSV出力ToolStripMenuItem, "cSV出力ToolStripMenuItem");
            cSV出力ToolStripMenuItem.Name = "cSV出力ToolStripMenuItem";
            cSV出力ToolStripMenuItem.Click += cSV出力ToolStripMenuItem_Click;
            // 
            // dataGridView1
            // 
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(button2);
            panel1.Controls.Add(monthlist);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(listtype);
            panel1.Name = "panel1";
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // monthlist
            // 
            resources.ApplyResources(monthlist, "monthlist");
            monthlist.DropDownStyle = ComboBoxStyle.DropDownList;
            monthlist.FormattingEnabled = true;
            monthlist.Name = "monthlist";
            monthlist.SelectedIndexChanged += UpdateComboBox;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listtype
            // 
            resources.ApplyResources(listtype, "listtype");
            listtype.DropDownStyle = ComboBoxStyle.DropDownList;
            listtype.FormattingEnabled = true;
            listtype.Name = "listtype";
            listtype.SelectedIndexChanged += UpdateComboBox;
            // 
            // statusStrip1
            // 
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1 });
            statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            resources.ApplyResources(toolStripProgressBar1, "toolStripProgressBar1");
            toolStripProgressBar1.Maximum = 10000;
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            // 
            // TravelersDiaryDetailList
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(toolStripContainer1);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TravelersDiaryDetailList";
            FormClosed += TravelersDiaryDetailList_FormClosed;
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private ToolStripMenuItem cSV出力ToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private ToolStripContainer toolStripContainer1;
        private Button button2;
    }
}