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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Accounts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NumCharacterDetailCharacterID = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonCharacterDetail = new System.Windows.Forms.Button();
            this.NumTravelerDiaryDetailPage = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.NumTravelerDiaryDetailMonth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.NumTravelerDiaryDetailType = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ButtonTravelersDiaryDetail = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ButtonStellarJourney = new System.Windows.Forms.Button();
            this.DateTimeStellarJourneySince = new System.Windows.Forms.DateTimePicker();
            this.ButtonTravelersDiary = new System.Windows.Forms.Button();
            this.NumTravelerDiaryMonth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonEnkaNetwork = new System.Windows.Forms.Button();
            this.ButtonRealTimeNote = new System.Windows.Forms.Button();
            this.ButtonSpiralAbyssPreviously = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonSpiralAbyssCurrent = new System.Windows.Forms.Button();
            this.ButtonCharacters = new System.Windows.Forms.Button();
            this.ButtonGameRecord = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCharacterDetailCharacterID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTravelerDiaryDetailPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTravelerDiaryDetailMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTravelerDiaryDetailType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTravelerDiaryMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Accounts);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 28);
            this.panel1.TabIndex = 0;
            // 
            // Accounts
            // 
            this.Accounts.Dock = System.Windows.Forms.DockStyle.Left;
            this.Accounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Accounts.FormattingEnabled = true;
            this.Accounts.Location = new System.Drawing.Point(114, 0);
            this.Accounts.Name = "Accounts";
            this.Accounts.Size = new System.Drawing.Size(157, 23);
            this.Accounts.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.MinimumSize = new System.Drawing.Size(0, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "連携済みのアカウント :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OutputBox
            // 
            this.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputBox.Location = new System.Drawing.Point(0, 198);
            this.OutputBox.MaxLength = 2147483647;
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputBox.Size = new System.Drawing.Size(542, 252);
            this.OutputBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NumCharacterDetailCharacterID);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.ButtonCharacterDetail);
            this.panel2.Controls.Add(this.NumTravelerDiaryDetailPage);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.NumTravelerDiaryDetailMonth);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.NumTravelerDiaryDetailType);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ButtonTravelersDiaryDetail);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.ButtonStellarJourney);
            this.panel2.Controls.Add(this.DateTimeStellarJourneySince);
            this.panel2.Controls.Add(this.ButtonTravelersDiary);
            this.panel2.Controls.Add(this.NumTravelerDiaryMonth);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ButtonEnkaNetwork);
            this.panel2.Controls.Add(this.ButtonRealTimeNote);
            this.panel2.Controls.Add(this.ButtonSpiralAbyssPreviously);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.ButtonSpiralAbyssCurrent);
            this.panel2.Controls.Add(this.ButtonCharacters);
            this.panel2.Controls.Add(this.ButtonGameRecord);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 170);
            this.panel2.TabIndex = 23;
            // 
            // NumCharacterDetailCharacterID
            // 
            this.NumCharacterDetailCharacterID.Location = new System.Drawing.Point(194, 140);
            this.NumCharacterDetailCharacterID.Maximum = new decimal(new int[] {
            10000999,
            0,
            0,
            0});
            this.NumCharacterDetailCharacterID.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NumCharacterDetailCharacterID.Name = "NumCharacterDetailCharacterID";
            this.NumCharacterDetailCharacterID.Size = new System.Drawing.Size(83, 23);
            this.NumCharacterDetailCharacterID.TabIndex = 45;
            this.NumCharacterDetailCharacterID.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(114, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 44;
            this.label8.Text = "CharacterID :";
            // 
            // ButtonCharacterDetail
            // 
            this.ButtonCharacterDetail.Location = new System.Drawing.Point(8, 139);
            this.ButtonCharacterDetail.Name = "ButtonCharacterDetail";
            this.ButtonCharacterDetail.Size = new System.Drawing.Size(100, 23);
            this.ButtonCharacterDetail.TabIndex = 43;
            this.ButtonCharacterDetail.Text = "CharacterDetail";
            this.ButtonCharacterDetail.UseVisualStyleBackColor = true;
            this.ButtonCharacterDetail.Click += new System.EventHandler(this.ButtonCharacterDetail_Click);
            // 
            // NumTravelerDiaryDetailPage
            // 
            this.NumTravelerDiaryDetailPage.Location = new System.Drawing.Point(381, 82);
            this.NumTravelerDiaryDetailPage.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.NumTravelerDiaryDetailPage.Name = "NumTravelerDiaryDetailPage";
            this.NumTravelerDiaryDetailPage.Size = new System.Drawing.Size(47, 23);
            this.NumTravelerDiaryDetailPage.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Page :";
            // 
            // NumTravelerDiaryDetailMonth
            // 
            this.NumTravelerDiaryDetailMonth.Location = new System.Drawing.Point(283, 82);
            this.NumTravelerDiaryDetailMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.NumTravelerDiaryDetailMonth.Name = "NumTravelerDiaryDetailMonth";
            this.NumTravelerDiaryDetailMonth.Size = new System.Drawing.Size(47, 23);
            this.NumTravelerDiaryDetailMonth.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 39;
            this.label6.Text = "Month :";
            // 
            // NumTravelerDiaryDetailType
            // 
            this.NumTravelerDiaryDetailType.Location = new System.Drawing.Point(175, 82);
            this.NumTravelerDiaryDetailType.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NumTravelerDiaryDetailType.Name = "NumTravelerDiaryDetailType";
            this.NumTravelerDiaryDetailType.Size = new System.Drawing.Size(47, 23);
            this.NumTravelerDiaryDetailType.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 37;
            this.label5.Text = "Type :";
            // 
            // ButtonTravelersDiaryDetail
            // 
            this.ButtonTravelersDiaryDetail.Location = new System.Drawing.Point(8, 82);
            this.ButtonTravelersDiaryDetail.Name = "ButtonTravelersDiaryDetail";
            this.ButtonTravelersDiaryDetail.Size = new System.Drawing.Size(118, 23);
            this.ButtonTravelersDiaryDetail.TabIndex = 36;
            this.ButtonTravelersDiaryDetail.Text = "TravelerDiaryDetail";
            this.ButtonTravelersDiaryDetail.UseVisualStyleBackColor = true;
            this.ButtonTravelersDiaryDetail.Click += new System.EventHandler(this.ButtonTravelersDiaryDetail_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "Since :";
            // 
            // ButtonStellarJourney
            // 
            this.ButtonStellarJourney.Location = new System.Drawing.Point(8, 111);
            this.ButtonStellarJourney.Name = "ButtonStellarJourney";
            this.ButtonStellarJourney.Size = new System.Drawing.Size(100, 23);
            this.ButtonStellarJourney.TabIndex = 34;
            this.ButtonStellarJourney.Text = "StellarJourney";
            this.ButtonStellarJourney.UseVisualStyleBackColor = true;
            this.ButtonStellarJourney.Click += new System.EventHandler(this.ButtonStellarJourney_Click);
            // 
            // DateTimeStellarJourneySince
            // 
            this.DateTimeStellarJourneySince.Location = new System.Drawing.Point(164, 111);
            this.DateTimeStellarJourneySince.Name = "DateTimeStellarJourneySince";
            this.DateTimeStellarJourneySince.Size = new System.Drawing.Size(119, 23);
            this.DateTimeStellarJourneySince.TabIndex = 33;
            // 
            // ButtonTravelersDiary
            // 
            this.ButtonTravelersDiary.Location = new System.Drawing.Point(8, 53);
            this.ButtonTravelersDiary.Name = "ButtonTravelersDiary";
            this.ButtonTravelersDiary.Size = new System.Drawing.Size(85, 23);
            this.ButtonTravelersDiary.TabIndex = 32;
            this.ButtonTravelersDiary.Text = "TravelerDiary";
            this.ButtonTravelersDiary.UseVisualStyleBackColor = true;
            this.ButtonTravelersDiary.Click += new System.EventHandler(this.ButtonTravelersDiary_Click);
            // 
            // NumTravelerDiaryMonth
            // 
            this.NumTravelerDiaryMonth.Location = new System.Drawing.Point(154, 53);
            this.NumTravelerDiaryMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.NumTravelerDiaryMonth.Name = "NumTravelerDiaryMonth";
            this.NumTravelerDiaryMonth.Size = new System.Drawing.Size(47, 23);
            this.NumTravelerDiaryMonth.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 30;
            this.label3.Text = "Month :";
            // 
            // ButtonEnkaNetwork
            // 
            this.ButtonEnkaNetwork.Location = new System.Drawing.Point(289, 4);
            this.ButtonEnkaNetwork.Name = "ButtonEnkaNetwork";
            this.ButtonEnkaNetwork.Size = new System.Drawing.Size(89, 23);
            this.ButtonEnkaNetwork.TabIndex = 29;
            this.ButtonEnkaNetwork.Text = "Enka.Network";
            this.ButtonEnkaNetwork.UseVisualStyleBackColor = true;
            this.ButtonEnkaNetwork.Click += new System.EventHandler(this.ButtonEnkaNetwork_Click);
            // 
            // ButtonRealTimeNote
            // 
            this.ButtonRealTimeNote.Location = new System.Drawing.Point(194, 4);
            this.ButtonRealTimeNote.Name = "ButtonRealTimeNote";
            this.ButtonRealTimeNote.Size = new System.Drawing.Size(89, 23);
            this.ButtonRealTimeNote.TabIndex = 28;
            this.ButtonRealTimeNote.Text = "RealTimeNote";
            this.ButtonRealTimeNote.UseVisualStyleBackColor = true;
            this.ButtonRealTimeNote.Click += new System.EventHandler(this.ButtonRealTimeNote_Click);
            // 
            // ButtonSpiralAbyssPreviously
            // 
            this.ButtonSpiralAbyssPreviously.Location = new System.Drawing.Point(141, 26);
            this.ButtonSpiralAbyssPreviously.Name = "ButtonSpiralAbyssPreviously";
            this.ButtonSpiralAbyssPreviously.Size = new System.Drawing.Size(71, 23);
            this.ButtonSpiralAbyssPreviously.TabIndex = 27;
            this.ButtonSpiralAbyssPreviously.Text = "previously";
            this.ButtonSpiralAbyssPreviously.UseVisualStyleBackColor = true;
            this.ButtonSpiralAbyssPreviously.Click += new System.EventHandler(this.ButtonSpiralAbyssPreviously_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "SpiralAbyss";
            // 
            // ButtonSpiralAbyssCurrent
            // 
            this.ButtonSpiralAbyssCurrent.Location = new System.Drawing.Point(79, 26);
            this.ButtonSpiralAbyssCurrent.Name = "ButtonSpiralAbyssCurrent";
            this.ButtonSpiralAbyssCurrent.Size = new System.Drawing.Size(56, 23);
            this.ButtonSpiralAbyssCurrent.TabIndex = 25;
            this.ButtonSpiralAbyssCurrent.Text = "current";
            this.ButtonSpiralAbyssCurrent.UseVisualStyleBackColor = true;
            this.ButtonSpiralAbyssCurrent.Click += new System.EventHandler(this.ButtonSpiralAbyssCurrent_Click);
            // 
            // ButtonCharacters
            // 
            this.ButtonCharacters.Location = new System.Drawing.Point(99, 4);
            this.ButtonCharacters.Name = "ButtonCharacters";
            this.ButtonCharacters.Size = new System.Drawing.Size(89, 23);
            this.ButtonCharacters.TabIndex = 24;
            this.ButtonCharacters.Text = "Characters";
            this.ButtonCharacters.UseVisualStyleBackColor = true;
            this.ButtonCharacters.Click += new System.EventHandler(this.ButtonCharacters_Click);
            // 
            // ButtonGameRecord
            // 
            this.ButtonGameRecord.Location = new System.Drawing.Point(4, 4);
            this.ButtonGameRecord.Name = "ButtonGameRecord";
            this.ButtonGameRecord.Size = new System.Drawing.Size(89, 23);
            this.ButtonGameRecord.TabIndex = 23;
            this.ButtonGameRecord.Text = "GameRecord";
            this.ButtonGameRecord.UseVisualStyleBackColor = true;
            this.ButtonGameRecord.Click += new System.EventHandler(this.ButtonGameRecord_Click);
            // 
            // APIChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 450);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "APIChecker";
            this.Text = "APIChecker";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumCharacterDetailCharacterID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTravelerDiaryDetailPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTravelerDiaryDetailMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTravelerDiaryDetailType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumTravelerDiaryMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}