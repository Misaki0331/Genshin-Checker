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
            label1.Location = new Point(255, 75);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 1;
            label1.Text = "0:00 / 0:00";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(1, 46);
            progressBar1.Maximum = 10000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(355, 23);
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
            // MusicPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 113);
            Controls.Add(ButtonStop);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Controls.Add(ButtonPlay);
            MaximizeBox = false;
            Name = "MusicPlayer";
            Text = "MusicPlayer";
            Load += MusicPlayer_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonPlay;
        private Label label1;
        private ProgressBar progressBar1;
        private Button ButtonStop;
        private System.Windows.Forms.Timer update;
    }
}