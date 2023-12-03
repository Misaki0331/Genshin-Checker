namespace Genshin_Checker.Window
{
    partial class CharacterCalculator
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ButtonSelectAll = new System.Windows.Forms.Button();
            this.ButtonBatch = new System.Windows.Forms.Button();
            this.CharacterView = new System.Windows.Forms.DataGridView();
            this.CalculateStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rarelity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Element = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharacterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weapon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fetter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentTalentLevel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentTalentLevel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentTalentLevel3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToArrow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTalentLevel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTalentLevel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToTalentLevel3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorHandling = new System.Windows.Forms.Timer(this.components);
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(571, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "計算開始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ButtonSelectAll);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.ButtonBatch);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(646, 24);
            this.panel4.TabIndex = 1;
            // 
            // ButtonSelectAll
            // 
            this.ButtonSelectAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonSelectAll.Location = new System.Drawing.Point(75, 0);
            this.ButtonSelectAll.Name = "ButtonSelectAll";
            this.ButtonSelectAll.Size = new System.Drawing.Size(75, 24);
            this.ButtonSelectAll.TabIndex = 4;
            this.ButtonSelectAll.Text = "すべて選択";
            this.ButtonSelectAll.UseVisualStyleBackColor = true;
            this.ButtonSelectAll.Click += new System.EventHandler(this.ButtonSelectAll_Click);
            // 
            // ButtonBatch
            // 
            this.ButtonBatch.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonBatch.Location = new System.Drawing.Point(0, 0);
            this.ButtonBatch.Name = "ButtonBatch";
            this.ButtonBatch.Size = new System.Drawing.Size(75, 24);
            this.ButtonBatch.TabIndex = 3;
            this.ButtonBatch.Text = "一括変更";
            this.ButtonBatch.UseVisualStyleBackColor = true;
            this.ButtonBatch.Click += new System.EventHandler(this.ButtonBatch_Click);
            // 
            // CharacterView
            // 
            this.CharacterView.AllowUserToAddRows = false;
            this.CharacterView.AllowUserToDeleteRows = false;
            this.CharacterView.AllowUserToResizeColumns = false;
            this.CharacterView.AllowUserToResizeRows = false;
            this.CharacterView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CharacterView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CalculateStatus,
            this.ID,
            this.Rarelity,
            this.Element,
            this.CharacterName,
            this.Weapon,
            this.Fetter,
            this.CurrentLevel,
            this.CurrentTalentLevel1,
            this.CurrentTalentLevel2,
            this.CurrentTalentLevel3,
            this.ToArrow,
            this.ToLevel,
            this.ToTalentLevel1,
            this.ToTalentLevel2,
            this.ToTalentLevel3});
            this.CharacterView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CharacterView.Location = new System.Drawing.Point(0, 24);
            this.CharacterView.Name = "CharacterView";
            this.CharacterView.RowHeadersVisible = false;
            this.CharacterView.RowTemplate.Height = 25;
            this.CharacterView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CharacterView.Size = new System.Drawing.Size(646, 437);
            this.CharacterView.TabIndex = 2;
            this.CharacterView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CharacterView_CellEnter);
            this.CharacterView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CharacterView_CellFormatting);
            this.CharacterView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CharacterView_CellValueChanged);
            this.CharacterView.CurrentCellDirtyStateChanged += new System.EventHandler(this.CharacterView_CurrentCellDirtyStateChanged);
            this.CharacterView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.CharacterView_DataError);
            // 
            // CalculateStatus
            // 
            this.CalculateStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CalculateStatus.Frozen = true;
            this.CalculateStatus.HeaderText = "";
            this.CalculateStatus.Name = "CalculateStatus";
            this.CalculateStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CalculateStatus.Width = 5;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "Character ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Rarelity
            // 
            this.Rarelity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Rarelity.Frozen = true;
            this.Rarelity.HeaderText = "★";
            this.Rarelity.MinimumWidth = 20;
            this.Rarelity.Name = "Rarelity";
            this.Rarelity.ReadOnly = true;
            this.Rarelity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Rarelity.Width = 20;
            // 
            // Element
            // 
            this.Element.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Element.Frozen = true;
            this.Element.HeaderText = "元素";
            this.Element.MinimumWidth = 40;
            this.Element.Name = "Element";
            this.Element.ReadOnly = true;
            this.Element.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Element.Width = 40;
            // 
            // CharacterName
            // 
            this.CharacterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CharacterName.Frozen = true;
            this.CharacterName.HeaderText = "名前";
            this.CharacterName.MinimumWidth = 120;
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.ReadOnly = true;
            this.CharacterName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CharacterName.Width = 120;
            // 
            // Weapon
            // 
            this.Weapon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Weapon.Frozen = true;
            this.Weapon.HeaderText = "武器種";
            this.Weapon.MinimumWidth = 60;
            this.Weapon.Name = "Weapon";
            this.Weapon.ReadOnly = true;
            this.Weapon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Weapon.Width = 60;
            // 
            // Fetter
            // 
            this.Fetter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fetter.Frozen = true;
            this.Fetter.HeaderText = "♥";
            this.Fetter.MinimumWidth = 25;
            this.Fetter.Name = "Fetter";
            this.Fetter.ReadOnly = true;
            this.Fetter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Fetter.Width = 25;
            // 
            // CurrentLevel
            // 
            this.CurrentLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CurrentLevel.Frozen = true;
            this.CurrentLevel.HeaderText = "Lv";
            this.CurrentLevel.MinimumWidth = 25;
            this.CurrentLevel.Name = "CurrentLevel";
            this.CurrentLevel.ReadOnly = true;
            this.CurrentLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CurrentLevel.Width = 25;
            // 
            // CurrentTalentLevel1
            // 
            this.CurrentTalentLevel1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CurrentTalentLevel1.Frozen = true;
            this.CurrentTalentLevel1.HeaderText = "通常";
            this.CurrentTalentLevel1.MinimumWidth = 45;
            this.CurrentTalentLevel1.Name = "CurrentTalentLevel1";
            this.CurrentTalentLevel1.ReadOnly = true;
            this.CurrentTalentLevel1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CurrentTalentLevel1.Width = 45;
            // 
            // CurrentTalentLevel2
            // 
            this.CurrentTalentLevel2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CurrentTalentLevel2.Frozen = true;
            this.CurrentTalentLevel2.HeaderText = "ｽｷﾙ";
            this.CurrentTalentLevel2.MinimumWidth = 45;
            this.CurrentTalentLevel2.Name = "CurrentTalentLevel2";
            this.CurrentTalentLevel2.ReadOnly = true;
            this.CurrentTalentLevel2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CurrentTalentLevel2.Width = 45;
            // 
            // CurrentTalentLevel3
            // 
            this.CurrentTalentLevel3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CurrentTalentLevel3.Frozen = true;
            this.CurrentTalentLevel3.HeaderText = "爆発";
            this.CurrentTalentLevel3.MinimumWidth = 45;
            this.CurrentTalentLevel3.Name = "CurrentTalentLevel3";
            this.CurrentTalentLevel3.ReadOnly = true;
            this.CurrentTalentLevel3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CurrentTalentLevel3.Width = 45;
            // 
            // ToArrow
            // 
            this.ToArrow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToArrow.Frozen = true;
            this.ToArrow.HeaderText = "";
            this.ToArrow.MinimumWidth = 20;
            this.ToArrow.Name = "ToArrow";
            this.ToArrow.ReadOnly = true;
            this.ToArrow.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToArrow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToArrow.Width = 20;
            // 
            // ToLevel
            // 
            this.ToLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToLevel.Frozen = true;
            this.ToLevel.HeaderText = "Lv";
            this.ToLevel.MinimumWidth = 25;
            this.ToLevel.Name = "ToLevel";
            this.ToLevel.ReadOnly = true;
            this.ToLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToLevel.Width = 25;
            // 
            // ToTalentLevel1
            // 
            this.ToTalentLevel1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToTalentLevel1.Frozen = true;
            this.ToTalentLevel1.HeaderText = "通常";
            this.ToTalentLevel1.MinimumWidth = 45;
            this.ToTalentLevel1.Name = "ToTalentLevel1";
            this.ToTalentLevel1.ReadOnly = true;
            this.ToTalentLevel1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToTalentLevel1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToTalentLevel1.Width = 45;
            // 
            // ToTalentLevel2
            // 
            this.ToTalentLevel2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToTalentLevel2.Frozen = true;
            this.ToTalentLevel2.HeaderText = "ｽｷﾙ";
            this.ToTalentLevel2.MinimumWidth = 45;
            this.ToTalentLevel2.Name = "ToTalentLevel2";
            this.ToTalentLevel2.ReadOnly = true;
            this.ToTalentLevel2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToTalentLevel2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToTalentLevel2.Width = 45;
            // 
            // ToTalentLevel3
            // 
            this.ToTalentLevel3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ToTalentLevel3.Frozen = true;
            this.ToTalentLevel3.HeaderText = "爆発";
            this.ToTalentLevel3.MinimumWidth = 45;
            this.ToTalentLevel3.Name = "ToTalentLevel3";
            this.ToTalentLevel3.ReadOnly = true;
            this.ToTalentLevel3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToTalentLevel3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ToTalentLevel3.Width = 45;
            // 
            // ErrorHandling
            // 
            this.ErrorHandling.Interval = 500;
            this.ErrorHandling.Tick += new System.EventHandler(this.ErrorHandling_Tick);
            // 
            // CharacterCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 461);
            this.Controls.Add(this.CharacterView);
            this.Controls.Add(this.panel4);
            this.MaximumSize = new System.Drawing.Size(662, 65535);
            this.MinimumSize = new System.Drawing.Size(662, 120);
            this.Name = "CharacterCalculator";
            this.Text = "CharacterCalculator";
            this.Load += new System.EventHandler(this.CharacterCalculator_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CharacterView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView CharacterView;
        private Panel panel4;
        private System.Windows.Forms.Timer ErrorHandling;
        private Button button1;
        private Button ButtonSelectAll;
        private Button ButtonBatch;
        private DataGridViewCheckBoxColumn CalculateStatus;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Rarelity;
        private DataGridViewTextBoxColumn Element;
        private DataGridViewTextBoxColumn CharacterName;
        private DataGridViewTextBoxColumn Weapon;
        private DataGridViewTextBoxColumn Fetter;
        private DataGridViewTextBoxColumn CurrentLevel;
        private DataGridViewTextBoxColumn CurrentTalentLevel1;
        private DataGridViewTextBoxColumn CurrentTalentLevel2;
        private DataGridViewTextBoxColumn CurrentTalentLevel3;
        private DataGridViewTextBoxColumn ToArrow;
        private DataGridViewTextBoxColumn ToLevel;
        private DataGridViewTextBoxColumn ToTalentLevel1;
        private DataGridViewTextBoxColumn ToTalentLevel2;
        private DataGridViewTextBoxColumn ToTalentLevel3;
    }
}