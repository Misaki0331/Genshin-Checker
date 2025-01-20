namespace Genshin_Checker.InternalTools
{
    partial class MusicInfoSetter
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
            SongPosition = new NumericUpDown();
            progressBar1 = new ProgressBar();
            ButtonPlay = new Button();
            ButtonStop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            label5 = new Label();
            textBox1 = new TextBox();
            offset = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)SongPosition).BeginInit();
            ((System.ComponentModel.ISupportInitialize)offset).BeginInit();
            SuspendLayout();
            // 
            // SongPosition
            // 
            SongPosition.Location = new Point(294, 12);
            SongPosition.Name = "SongPosition";
            SongPosition.Size = new Size(120, 23);
            SongPosition.TabIndex = 11;
            SongPosition.ValueChanged += SongPosition_ValueChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(294, 41);
            progressBar1.Maximum = 10000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(364, 23);
            progressBar1.TabIndex = 12;
            // 
            // ButtonPlay
            // 
            ButtonPlay.Location = new Point(294, 70);
            ButtonPlay.Name = "ButtonPlay";
            ButtonPlay.Size = new Size(75, 23);
            ButtonPlay.TabIndex = 13;
            ButtonPlay.Text = "Play";
            ButtonPlay.UseVisualStyleBackColor = true;
            ButtonPlay.Click += ButtonPlay_Click_1;
            // 
            // ButtonStop
            // 
            ButtonStop.Location = new Point(375, 70);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(75, 23);
            ButtonStop.TabIndex = 14;
            ButtonStop.Text = "Stop";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click_1;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Tick += update_Tick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(420, 14);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 15;
            label4.Text = "label4";
            // 
            // timer2
            // 
            timer2.Interval = 10;
            timer2.Tick += timer2_Tick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(294, 96);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 16;
            label5.Text = "label5";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(12, 6);
            textBox1.MaxLength = 9999999;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Horizontal;
            textBox1.Size = new Size(258, 376);
            textBox1.TabIndex = 17;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // offset
            // 
            offset.Location = new Point(294, 124);
            offset.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            offset.Minimum = new decimal(new int[] { 10000, 0, 0, int.MinValue });
            offset.Name = "offset";
            offset.Size = new Size(120, 23);
            offset.TabIndex = 18;
            // 
            // MusicInfoSetter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 394);
            Controls.Add(offset);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonPlay);
            Controls.Add(progressBar1);
            Controls.Add(SongPosition);
            Name = "MusicInfoSetter";
            Text = "MusicInfoSetter";
            ((System.ComponentModel.ISupportInitialize)SongPosition).EndInit();
            ((System.ComponentModel.ISupportInitialize)offset).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown SongPosition;
        private ProgressBar progressBar1;
        private Button ButtonPlay;
        private Button ButtonStop;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private System.Windows.Forms.Timer timer2;
        private Label label5;
        private TextBox textBox1;
        private NumericUpDown offset;
    }
}