namespace Genshin_Checker.Window
{
    partial class MusicPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayer));
            ButtonPlay = new Button();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            ButtonStop = new Button();
            update = new System.Windows.Forms.Timer(components);
            SongTitle = new Label();
            volumebar = new TrackBar();
            volumelabel = new Label();
            dataGridView1 = new DataGridView();
            TrackNum = new DataGridViewTextBoxColumn();
            Title = new DataGridViewTextBoxColumn();
            Length = new DataGridViewTextBoxColumn();
            ButtonNext = new Button();
            ButtonLoop = new Button();
            ((System.ComponentModel.ISupportInitialize)volumebar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // ButtonPlay
            // 
            resources.ApplyResources(ButtonPlay, "ButtonPlay");
            ButtonPlay.Name = "ButtonPlay";
            ButtonPlay.UseVisualStyleBackColor = true;
            ButtonPlay.Click += ButtonPlay_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // progressBar1
            // 
            resources.ApplyResources(progressBar1, "progressBar1");
            progressBar1.Maximum = 10000;
            progressBar1.Name = "progressBar1";
            progressBar1.Click += progressBar1_Click;
            progressBar1.MouseDown += progressBar1_MouseDown;
            // 
            // ButtonStop
            // 
            resources.ApplyResources(ButtonStop, "ButtonStop");
            ButtonStop.Name = "ButtonStop";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click;
            // 
            // update
            // 
            update.Enabled = true;
            update.Interval = 10;
            update.Tick += update_Tick;
            // 
            // SongTitle
            // 
            resources.ApplyResources(SongTitle, "SongTitle");
            SongTitle.Name = "SongTitle";
            // 
            // volumebar
            // 
            resources.ApplyResources(volumebar, "volumebar");
            volumebar.LargeChange = 20;
            volumebar.Maximum = 100;
            volumebar.Name = "volumebar";
            volumebar.SmallChange = 5;
            volumebar.TickFrequency = 20;
            volumebar.TickStyle = TickStyle.Both;
            volumebar.Scroll += volumebar_Scroll;
            // 
            // volumelabel
            // 
            resources.ApplyResources(volumelabel, "volumelabel");
            volumelabel.Name = "volumelabel";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            resources.ApplyResources(dataGridView1, "dataGridView1");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { TrackNum, Title, Length });
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.UserDeletedRow += dataGridView1_UserDeletedRow;
            dataGridView1.KeyDown += dataGridView1_KeyDown;
            dataGridView1.KeyPress += dataGridView1_KeyPress;
            // 
            // TrackNum
            // 
            TrackNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            TrackNum.DataPropertyName = "TrackNum";
            TrackNum.Frozen = true;
            resources.ApplyResources(TrackNum, "TrackNum");
            TrackNum.Name = "TrackNum";
            TrackNum.ReadOnly = true;
            TrackNum.Resizable = DataGridViewTriState.False;
            TrackNum.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Title
            // 
            Title.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Title.DataPropertyName = "Title";
            resources.ApplyResources(Title, "Title");
            Title.Name = "Title";
            Title.ReadOnly = true;
            Title.Resizable = DataGridViewTriState.False;
            Title.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Length
            // 
            Length.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Length.DataPropertyName = "Length";
            resources.ApplyResources(Length, "Length");
            Length.Name = "Length";
            Length.ReadOnly = true;
            Length.Resizable = DataGridViewTriState.False;
            Length.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ButtonNext
            // 
            resources.ApplyResources(ButtonNext, "ButtonNext");
            ButtonNext.Name = "ButtonNext";
            ButtonNext.UseVisualStyleBackColor = true;
            ButtonNext.Click += ButtonNext_Click;
            // 
            // ButtonLoop
            // 
            resources.ApplyResources(ButtonLoop, "ButtonLoop");
            ButtonLoop.Name = "ButtonLoop";
            ButtonLoop.UseVisualStyleBackColor = true;
            ButtonLoop.Click += ButtonLoop_Click;
            // 
            // MusicPlayer
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ButtonLoop);
            Controls.Add(ButtonNext);
            Controls.Add(dataGridView1);
            Controls.Add(volumelabel);
            Controls.Add(volumebar);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(SongTitle);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonPlay);
            MaximizeBox = false;
            Name = "MusicPlayer";
            FormClosing += MusicPlayer_FormClosing;
            FormClosed += MusicPlayer_FormClosed;
            Load += MusicPlayer_Load;
            ((System.ComponentModel.ISupportInitialize)volumebar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonPlay;
        private Label label1;
        private ProgressBar progressBar1;
        private Button ButtonStop;
        private System.Windows.Forms.Timer update;
        private Label SongTitle;
        private TrackBar volumebar;
        private Label volumelabel;
        private DataGridView dataGridView1;
        private Button ButtonNext;
        private Button ButtonLoop;
        private DataGridViewTextBoxColumn TrackNum;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Length;
    }
}