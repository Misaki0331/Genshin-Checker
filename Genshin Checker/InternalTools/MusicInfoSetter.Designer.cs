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
            dataGridView1 = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Time = new DataGridViewTextBoxColumn();
            SetMode = new DataGridViewTextBoxColumn();
            DataValue = new DataGridViewTextBoxColumn();
            DeleteList = new Button();
            NewList = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            checkBox1 = new CheckBox();
            comboBox1 = new ComboBox();
            SongPosition = new NumericUpDown();
            progressBar1 = new ProgressBar();
            ButtonPlay = new Button();
            ButtonStop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label4 = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SongPosition).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Time, SetMode, DataValue });
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(254, 370);
            dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.Visible = false;
            // 
            // Time
            // 
            Time.FillWeight = 70F;
            Time.HeaderText = "時間";
            Time.Name = "Time";
            Time.ReadOnly = true;
            // 
            // SetMode
            // 
            SetMode.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            SetMode.FillWeight = 50F;
            SetMode.HeaderText = "モード";
            SetMode.Name = "SetMode";
            SetMode.ReadOnly = true;
            SetMode.Width = 80;
            // 
            // DataValue
            // 
            DataValue.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            DataValue.FillWeight = 50F;
            DataValue.HeaderText = "値";
            DataValue.Name = "DataValue";
            DataValue.ReadOnly = true;
            DataValue.Width = 80;
            // 
            // DeleteList
            // 
            DeleteList.Location = new Point(272, 359);
            DeleteList.Name = "DeleteList";
            DeleteList.Size = new Size(57, 23);
            DeleteList.TabIndex = 1;
            DeleteList.Text = "削除";
            DeleteList.UseVisualStyleBackColor = true;
            // 
            // NewList
            // 
            NewList.Location = new Point(272, 330);
            NewList.Name = "NewList";
            NewList.Size = new Size(57, 23);
            NewList.TabIndex = 2;
            NewList.Text = "新規";
            NewList.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(372, 330);
            numericUpDown1.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(70, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.TextAlign = HorizontalAlignment.Right;
            // 
            // numericUpDown2
            // 
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Location = new Point(405, 359);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(70, 23);
            numericUpDown2.TabIndex = 4;
            numericUpDown2.TextAlign = HorizontalAlignment.Right;
            numericUpDown2.Value = new decimal(new int[] { 120, 0, 0, 0 });
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(335, 359);
            numericUpDown3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(40, 23);
            numericUpDown3.TabIndex = 5;
            numericUpDown3.TextAlign = HorizontalAlignment.Right;
            numericUpDown3.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(381, 363);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 6;
            label1.Text = "/4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(481, 363);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 7;
            label2.Text = "BPM";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(335, 334);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 8;
            label3.Text = "時間";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(519, 362);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(56, 19);
            checkBox1.TabIndex = 9;
            checkBox1.Text = "GoGo";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "拍子", "BPM", "サビモード" });
            comboBox1.Location = new Point(448, 329);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 10;
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
            // MusicInfoSetter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 394);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonPlay);
            Controls.Add(progressBar1);
            Controls.Add(SongPosition);
            Controls.Add(comboBox1);
            Controls.Add(checkBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(NewList);
            Controls.Add(DeleteList);
            Controls.Add(dataGridView1);
            Name = "MusicInfoSetter";
            Text = "MusicInfoSetter";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)SongPosition).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button DeleteList;
        private Button NewList;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private Label label1;
        private Label label2;
        private Label label3;
        private CheckBox checkBox1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn SetMode;
        private DataGridViewTextBoxColumn DataValue;
        private ComboBox comboBox1;
        private NumericUpDown SongPosition;
        private ProgressBar progressBar1;
        private Button ButtonPlay;
        private Button ButtonStop;
        private System.Windows.Forms.Timer timer1;
        private Label label4;
        private System.Windows.Forms.Timer timer2;
        private Label label5;
    }
}