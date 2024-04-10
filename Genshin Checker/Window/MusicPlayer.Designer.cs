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
            ButtonPlay = new Button();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            ButtonStop = new Button();
            update = new System.Windows.Forms.Timer(components);
            SongTitle = new Label();
            volumebar = new TrackBar();
            volumelabel = new Label();
            ((System.ComponentModel.ISupportInitialize)volumebar).BeginInit();
            SuspendLayout();
            // 
            // ButtonPlay
            // 
            ButtonPlay.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonPlay.Location = new Point(12, 75);
            ButtonPlay.Name = "ButtonPlay";
            ButtonPlay.Size = new Size(30, 30);
            ButtonPlay.TabIndex = 0;
            ButtonPlay.Text = "▶";
            ButtonPlay.UseVisualStyleBackColor = true;
            ButtonPlay.Click += ButtonPlay_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 48);
            label1.Name = "label1";
            label1.Size = new Size(357, 23);
            label1.TabIndex = 1;
            label1.Text = "0:00 / 0:00";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Top;
            progressBar1.Location = new Point(0, 25);
            progressBar1.Maximum = 10000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(357, 23);
            progressBar1.TabIndex = 2;
            // 
            // ButtonStop
            // 
            ButtonStop.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonStop.Location = new Point(48, 75);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(30, 30);
            ButtonStop.TabIndex = 3;
            ButtonStop.Text = "■";
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
            SongTitle.AutoSize = true;
            SongTitle.Dock = DockStyle.Top;
            SongTitle.Font = new Font("Meiryo UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SongTitle.Location = new Point(0, 0);
            SongTitle.Name = "SongTitle";
            SongTitle.Padding = new Padding(10, 5, 0, 0);
            SongTitle.Size = new Size(10, 25);
            SongTitle.TabIndex = 4;
            // 
            // volumebar
            // 
            volumebar.LargeChange = 20;
            volumebar.Location = new Point(253, 67);
            volumebar.Maximum = 100;
            volumebar.Name = "volumebar";
            volumebar.Size = new Size(104, 45);
            volumebar.SmallChange = 5;
            volumebar.TabIndex = 5;
            volumebar.TickFrequency = 20;
            volumebar.TickStyle = TickStyle.Both;
            volumebar.Scroll += volumebar_Scroll;
            // 
            // volumelabel
            // 
            volumelabel.Location = new Point(212, 67);
            volumelabel.Name = "volumelabel";
            volumelabel.Size = new Size(35, 45);
            volumelabel.TabIndex = 6;
            volumelabel.Text = "Vol.\r\n100";
            volumelabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MusicPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 113);
            Controls.Add(volumelabel);
            Controls.Add(volumebar);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(SongTitle);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonPlay);
            MaximizeBox = false;
            Name = "MusicPlayer";
            Text = "MusicPlayer";
            Load += MusicPlayer_Load;
            ((System.ComponentModel.ISupportInitialize)volumebar).EndInit();
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
    }
}