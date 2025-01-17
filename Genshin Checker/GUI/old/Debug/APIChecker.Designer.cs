namespace Genshin_Checker.Window.Debug
{
    partial class APIChecker
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
            panel1 = new Panel();
            Accounts = new ComboBox();
            label1 = new Label();
            OutputBox = new TextBox();
            panel2 = new Panel();
            ButtonTheater = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            NumCharacterDetailCharacterID = new NumericUpDown();
            label8 = new Label();
            ButtonCharacterDetail = new Button();
            NumTravelerDiaryDetailPage = new NumericUpDown();
            label7 = new Label();
            NumTravelerDiaryDetailMonth = new NumericUpDown();
            label6 = new Label();
            NumTravelerDiaryDetailType = new NumericUpDown();
            label5 = new Label();
            ButtonTravelersDiaryDetail = new Button();
            label4 = new Label();
            ButtonStellarJourney = new Button();
            DateTimeStellarJourneySince = new DateTimePicker();
            ButtonTravelersDiary = new Button();
            NumTravelerDiaryMonth = new NumericUpDown();
            label3 = new Label();
            ButtonEnkaNetwork = new Button();
            ButtonRealTimeNote = new Button();
            ButtonSpiralAbyssPreviously = new Button();
            label2 = new Label();
            ButtonSpiralAbyssCurrent = new Button();
            ButtonCharacters = new Button();
            ButtonGameRecord = new Button();
            textBox2 = new TextBox();
            button3 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumCharacterDetailCharacterID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumTravelerDiaryDetailPage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumTravelerDiaryDetailMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumTravelerDiaryDetailType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumTravelerDiaryMonth).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Accounts);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(542, 28);
            panel1.TabIndex = 0;
            // 
            // Accounts
            // 
            Accounts.Dock = DockStyle.Left;
            Accounts.DropDownStyle = ComboBoxStyle.DropDownList;
            Accounts.FormattingEnabled = true;
            Accounts.Location = new Point(114, 0);
            Accounts.Name = "Accounts";
            Accounts.Size = new Size(157, 23);
            Accounts.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.MinimumSize = new Size(0, 23);
            label1.Name = "label1";
            label1.Size = new Size(114, 23);
            label1.TabIndex = 0;
            label1.Text = "連携済みのアカウント :";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // OutputBox
            // 
            OutputBox.Dock = DockStyle.Fill;
            OutputBox.Location = new Point(0, 253);
            OutputBox.MaxLength = int.MaxValue;
            OutputBox.Multiline = true;
            OutputBox.Name = "OutputBox";
            OutputBox.ReadOnly = true;
            OutputBox.ScrollBars = ScrollBars.Both;
            OutputBox.Size = new Size(542, 197);
            OutputBox.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(ButtonTheater);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(NumCharacterDetailCharacterID);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(ButtonCharacterDetail);
            panel2.Controls.Add(NumTravelerDiaryDetailPage);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(NumTravelerDiaryDetailMonth);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(NumTravelerDiaryDetailType);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(ButtonTravelersDiaryDetail);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(ButtonStellarJourney);
            panel2.Controls.Add(DateTimeStellarJourneySince);
            panel2.Controls.Add(ButtonTravelersDiary);
            panel2.Controls.Add(NumTravelerDiaryMonth);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(ButtonEnkaNetwork);
            panel2.Controls.Add(ButtonRealTimeNote);
            panel2.Controls.Add(ButtonSpiralAbyssPreviously);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(ButtonSpiralAbyssCurrent);
            panel2.Controls.Add(ButtonCharacters);
            panel2.Controls.Add(ButtonGameRecord);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 28);
            panel2.Name = "panel2";
            panel2.Size = new Size(542, 225);
            panel2.TabIndex = 23;
            // 
            // ButtonTheater
            // 
            ButtonTheater.Location = new Point(384, 4);
            ButtonTheater.Name = "ButtonTheater";
            ButtonTheater.Size = new Size(89, 23);
            ButtonTheater.TabIndex = 49;
            ButtonTheater.Text = "Theater";
            ButtonTheater.UseVisualStyleBackColor = true;
            ButtonTheater.Click += ButtonTheater_Click;
            // 
            // button2
            // 
            button2.Location = new Point(161, 169);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 48;
            button2.Text = "CodeExcharge";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(8, 168);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(147, 23);
            textBox1.TabIndex = 47;
            // 
            // button1
            // 
            button1.Location = new Point(289, 141);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 46;
            button1.Text = "Material";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NumCharacterDetailCharacterID
            // 
            NumCharacterDetailCharacterID.Location = new Point(194, 140);
            NumCharacterDetailCharacterID.Maximum = new decimal(new int[] { 10000999, 0, 0, 0 });
            NumCharacterDetailCharacterID.Minimum = new decimal(new int[] { 10000000, 0, 0, 0 });
            NumCharacterDetailCharacterID.Name = "NumCharacterDetailCharacterID";
            NumCharacterDetailCharacterID.Size = new Size(83, 23);
            NumCharacterDetailCharacterID.TabIndex = 45;
            NumCharacterDetailCharacterID.Value = new decimal(new int[] { 10000000, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(114, 143);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 44;
            label8.Text = "CharacterID :";
            // 
            // ButtonCharacterDetail
            // 
            ButtonCharacterDetail.Location = new Point(8, 139);
            ButtonCharacterDetail.Name = "ButtonCharacterDetail";
            ButtonCharacterDetail.Size = new Size(100, 23);
            ButtonCharacterDetail.TabIndex = 43;
            ButtonCharacterDetail.Text = "CharacterDetail";
            ButtonCharacterDetail.UseVisualStyleBackColor = true;
            ButtonCharacterDetail.Click += ButtonCharacterDetail_Click;
            // 
            // NumTravelerDiaryDetailPage
            // 
            NumTravelerDiaryDetailPage.Location = new Point(381, 82);
            NumTravelerDiaryDetailPage.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            NumTravelerDiaryDetailPage.Name = "NumTravelerDiaryDetailPage";
            NumTravelerDiaryDetailPage.Size = new Size(47, 23);
            NumTravelerDiaryDetailPage.TabIndex = 42;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(336, 86);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 41;
            label7.Text = "Page :";
            // 
            // NumTravelerDiaryDetailMonth
            // 
            NumTravelerDiaryDetailMonth.Location = new Point(283, 82);
            NumTravelerDiaryDetailMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            NumTravelerDiaryDetailMonth.Name = "NumTravelerDiaryDetailMonth";
            NumTravelerDiaryDetailMonth.Size = new Size(47, 23);
            NumTravelerDiaryDetailMonth.TabIndex = 40;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(228, 86);
            label6.Name = "label6";
            label6.Size = new Size(49, 15);
            label6.TabIndex = 39;
            label6.Text = "Month :";
            // 
            // NumTravelerDiaryDetailType
            // 
            NumTravelerDiaryDetailType.Location = new Point(175, 82);
            NumTravelerDiaryDetailType.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            NumTravelerDiaryDetailType.Name = "NumTravelerDiaryDetailType";
            NumTravelerDiaryDetailType.Size = new Size(47, 23);
            NumTravelerDiaryDetailType.TabIndex = 38;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(132, 86);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 37;
            label5.Text = "Type :";
            // 
            // ButtonTravelersDiaryDetail
            // 
            ButtonTravelersDiaryDetail.Location = new Point(8, 82);
            ButtonTravelersDiaryDetail.Name = "ButtonTravelersDiaryDetail";
            ButtonTravelersDiaryDetail.Size = new Size(118, 23);
            ButtonTravelersDiaryDetail.TabIndex = 36;
            ButtonTravelersDiaryDetail.Text = "TravelerDiaryDetail";
            ButtonTravelersDiaryDetail.UseVisualStyleBackColor = true;
            ButtonTravelersDiaryDetail.Click += ButtonTravelersDiaryDetail_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(114, 115);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 35;
            label4.Text = "Since :";
            // 
            // ButtonStellarJourney
            // 
            ButtonStellarJourney.Location = new Point(8, 111);
            ButtonStellarJourney.Name = "ButtonStellarJourney";
            ButtonStellarJourney.Size = new Size(100, 23);
            ButtonStellarJourney.TabIndex = 34;
            ButtonStellarJourney.Text = "StellarJourney";
            ButtonStellarJourney.UseVisualStyleBackColor = true;
            ButtonStellarJourney.Click += ButtonStellarJourney_Click;
            // 
            // DateTimeStellarJourneySince
            // 
            DateTimeStellarJourneySince.Location = new Point(164, 111);
            DateTimeStellarJourneySince.Name = "DateTimeStellarJourneySince";
            DateTimeStellarJourneySince.Size = new Size(119, 23);
            DateTimeStellarJourneySince.TabIndex = 33;
            // 
            // ButtonTravelersDiary
            // 
            ButtonTravelersDiary.Location = new Point(8, 53);
            ButtonTravelersDiary.Name = "ButtonTravelersDiary";
            ButtonTravelersDiary.Size = new Size(85, 23);
            ButtonTravelersDiary.TabIndex = 32;
            ButtonTravelersDiary.Text = "TravelerDiary";
            ButtonTravelersDiary.UseVisualStyleBackColor = true;
            ButtonTravelersDiary.Click += ButtonTravelersDiary_Click;
            // 
            // NumTravelerDiaryMonth
            // 
            NumTravelerDiaryMonth.Location = new Point(154, 53);
            NumTravelerDiaryMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            NumTravelerDiaryMonth.Name = "NumTravelerDiaryMonth";
            NumTravelerDiaryMonth.Size = new Size(47, 23);
            NumTravelerDiaryMonth.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(99, 57);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 30;
            label3.Text = "Month :";
            // 
            // ButtonEnkaNetwork
            // 
            ButtonEnkaNetwork.Location = new Point(289, 4);
            ButtonEnkaNetwork.Name = "ButtonEnkaNetwork";
            ButtonEnkaNetwork.Size = new Size(89, 23);
            ButtonEnkaNetwork.TabIndex = 29;
            ButtonEnkaNetwork.Text = "Enka.Network";
            ButtonEnkaNetwork.UseVisualStyleBackColor = true;
            ButtonEnkaNetwork.Click += ButtonEnkaNetwork_Click;
            // 
            // ButtonRealTimeNote
            // 
            ButtonRealTimeNote.Location = new Point(194, 4);
            ButtonRealTimeNote.Name = "ButtonRealTimeNote";
            ButtonRealTimeNote.Size = new Size(89, 23);
            ButtonRealTimeNote.TabIndex = 28;
            ButtonRealTimeNote.Text = "RealTimeNote";
            ButtonRealTimeNote.UseVisualStyleBackColor = true;
            ButtonRealTimeNote.Click += ButtonRealTimeNote_Click;
            // 
            // ButtonSpiralAbyssPreviously
            // 
            ButtonSpiralAbyssPreviously.Location = new Point(141, 26);
            ButtonSpiralAbyssPreviously.Name = "ButtonSpiralAbyssPreviously";
            ButtonSpiralAbyssPreviously.Size = new Size(71, 23);
            ButtonSpiralAbyssPreviously.TabIndex = 27;
            ButtonSpiralAbyssPreviously.Text = "previously";
            ButtonSpiralAbyssPreviously.UseVisualStyleBackColor = true;
            ButtonSpiralAbyssPreviously.Click += ButtonSpiralAbyssPreviously_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 30);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 26;
            label2.Text = "SpiralAbyss";
            // 
            // ButtonSpiralAbyssCurrent
            // 
            ButtonSpiralAbyssCurrent.Location = new Point(79, 26);
            ButtonSpiralAbyssCurrent.Name = "ButtonSpiralAbyssCurrent";
            ButtonSpiralAbyssCurrent.Size = new Size(56, 23);
            ButtonSpiralAbyssCurrent.TabIndex = 25;
            ButtonSpiralAbyssCurrent.Text = "current";
            ButtonSpiralAbyssCurrent.UseVisualStyleBackColor = true;
            ButtonSpiralAbyssCurrent.Click += ButtonSpiralAbyssCurrent_Click;
            // 
            // ButtonCharacters
            // 
            ButtonCharacters.Location = new Point(99, 4);
            ButtonCharacters.Name = "ButtonCharacters";
            ButtonCharacters.Size = new Size(89, 23);
            ButtonCharacters.TabIndex = 24;
            ButtonCharacters.Text = "Characters";
            ButtonCharacters.UseVisualStyleBackColor = true;
            ButtonCharacters.Click += ButtonCharacters_Click;
            // 
            // ButtonGameRecord
            // 
            ButtonGameRecord.Location = new Point(4, 4);
            ButtonGameRecord.Name = "ButtonGameRecord";
            ButtonGameRecord.Size = new Size(89, 23);
            ButtonGameRecord.TabIndex = 23;
            ButtonGameRecord.Text = "GameRecord";
            ButtonGameRecord.UseVisualStyleBackColor = true;
            ButtonGameRecord.Click += ButtonGameRecord_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(8, 196);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(355, 23);
            textBox2.TabIndex = 50;
            // 
            // button3
            // 
            button3.Location = new Point(369, 196);
            button3.Name = "button3";
            button3.Size = new Size(124, 23);
            button3.TabIndex = 51;
            button3.Text = "キャラクター詳細取得";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // APIChecker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(542, 450);
            Controls.Add(OutputBox);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "APIChecker";
            Text = "APIChecker";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumCharacterDetailCharacterID).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumTravelerDiaryDetailPage).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumTravelerDiaryDetailMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumTravelerDiaryDetailType).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumTravelerDiaryMonth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private ComboBox Accounts;
        private Label label1;
        private TextBox OutputBox;
        private Panel panel2;
        private NumericUpDown NumCharacterDetailCharacterID;
        private Label label8;
        private Button ButtonCharacterDetail;
        private NumericUpDown NumTravelerDiaryDetailPage;
        private Label label7;
        private NumericUpDown NumTravelerDiaryDetailMonth;
        private Label label6;
        private NumericUpDown NumTravelerDiaryDetailType;
        private Label label5;
        private Button ButtonTravelersDiaryDetail;
        private Label label4;
        private Button ButtonStellarJourney;
        private DateTimePicker DateTimeStellarJourneySince;
        private Button ButtonTravelersDiary;
        private NumericUpDown NumTravelerDiaryMonth;
        private Label label3;
        private Button ButtonEnkaNetwork;
        private Button ButtonRealTimeNote;
        private Button ButtonSpiralAbyssPreviously;
        private Label label2;
        private Button ButtonSpiralAbyssCurrent;
        private Button ButtonCharacters;
        private Button ButtonGameRecord;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Button ButtonTheater;
        private Button button3;
        private TextBox textBox2;
    }
}