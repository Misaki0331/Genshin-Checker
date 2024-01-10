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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterCalculator));
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ButtonSelectAll = new System.Windows.Forms.Button();
            this.ButtonBatch = new System.Windows.Forms.Button();
            this.CharacterView = new System.Windows.Forms.DataGridView();
            this.CalculateStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rarelity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.ButtonSelectAll);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.ButtonBatch);
            this.panel4.Name = "panel4";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ButtonSelectAll
            // 
            resources.ApplyResources(this.ButtonSelectAll, "ButtonSelectAll");
            this.ButtonSelectAll.Name = "ButtonSelectAll";
            this.ButtonSelectAll.UseVisualStyleBackColor = true;
            this.ButtonSelectAll.Click += new System.EventHandler(this.ButtonSelectAll_Click);
            // 
            // ButtonBatch
            // 
            resources.ApplyResources(this.ButtonBatch, "ButtonBatch");
            this.ButtonBatch.Name = "ButtonBatch";
            this.ButtonBatch.UseVisualStyleBackColor = true;
            this.ButtonBatch.Click += new System.EventHandler(this.ButtonBatch_Click);
            // 
            // CharacterView
            // 
            resources.ApplyResources(this.CharacterView, "CharacterView");
            this.CharacterView.AllowUserToAddRows = false;
            this.CharacterView.AllowUserToDeleteRows = false;
            this.CharacterView.AllowUserToResizeColumns = false;
            this.CharacterView.AllowUserToResizeRows = false;
            this.CharacterView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CharacterView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.CharacterView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CalculateStatus,
            this.ID,
            this.Rarelity,
            this.ElementType,
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
            this.CharacterView.Name = "CharacterView";
            this.CharacterView.ReadOnly = true;
            this.CharacterView.RowHeadersVisible = false;
            this.CharacterView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.CharacterView.RowTemplate.Height = 25;
            this.CharacterView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CharacterView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CharacterView_CellDoubleClick);
            this.CharacterView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CharacterView_CellEnter);
            this.CharacterView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.CharacterView_CellFormatting);
            this.CharacterView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CharacterView_CellValueChanged);
            this.CharacterView.CurrentCellDirtyStateChanged += new System.EventHandler(this.CharacterView_CurrentCellDirtyStateChanged);
            this.CharacterView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.CharacterView_DataError);
            this.CharacterView.SelectionChanged += new System.EventHandler(this.CharacterView_SelectionChanged);
            // 
            // CalculateStatus
            // 
            this.CalculateStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CalculateStatus.Frozen = true;
            resources.ApplyResources(this.CalculateStatus, "CalculateStatus");
            this.CalculateStatus.Name = "CalculateStatus";
            this.CalculateStatus.ReadOnly = true;
            this.CalculateStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CalculateStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            resources.ApplyResources(this.ID, "ID");
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Rarelity
            // 
            this.Rarelity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Rarelity.Frozen = true;
            resources.ApplyResources(this.Rarelity, "Rarelity");
            this.Rarelity.Name = "Rarelity";
            this.Rarelity.ReadOnly = true;
            this.Rarelity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ElementType
            // 
            this.ElementType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ElementType.Frozen = true;
            resources.ApplyResources(this.ElementType, "ElementType");
            this.ElementType.Name = "ElementType";
            this.ElementType.ReadOnly = true;
            this.ElementType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CharacterName
            // 
            resources.ApplyResources(this.CharacterName, "CharacterName");
            this.CharacterName.Name = "CharacterName";
            this.CharacterName.ReadOnly = true;
            this.CharacterName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Weapon
            // 
            this.Weapon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.Weapon, "Weapon");
            this.Weapon.Name = "Weapon";
            this.Weapon.ReadOnly = true;
            this.Weapon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Fetter
            // 
            this.Fetter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.Fetter, "Fetter");
            this.Fetter.Name = "Fetter";
            this.Fetter.ReadOnly = true;
            this.Fetter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CurrentLevel
            // 
            this.CurrentLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.CurrentLevel, "CurrentLevel");
            this.CurrentLevel.Name = "CurrentLevel";
            this.CurrentLevel.ReadOnly = true;
            this.CurrentLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CurrentTalentLevel1
            // 
            this.CurrentTalentLevel1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.CurrentTalentLevel1, "CurrentTalentLevel1");
            this.CurrentTalentLevel1.Name = "CurrentTalentLevel1";
            this.CurrentTalentLevel1.ReadOnly = true;
            this.CurrentTalentLevel1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CurrentTalentLevel2
            // 
            this.CurrentTalentLevel2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.CurrentTalentLevel2, "CurrentTalentLevel2");
            this.CurrentTalentLevel2.Name = "CurrentTalentLevel2";
            this.CurrentTalentLevel2.ReadOnly = true;
            this.CurrentTalentLevel2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CurrentTalentLevel3
            // 
            this.CurrentTalentLevel3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.CurrentTalentLevel3, "CurrentTalentLevel3");
            this.CurrentTalentLevel3.Name = "CurrentTalentLevel3";
            this.CurrentTalentLevel3.ReadOnly = true;
            this.CurrentTalentLevel3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ToArrow
            // 
            this.ToArrow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.ToArrow, "ToArrow");
            this.ToArrow.Name = "ToArrow";
            this.ToArrow.ReadOnly = true;
            this.ToArrow.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToArrow.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ToLevel
            // 
            this.ToLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.ToLevel, "ToLevel");
            this.ToLevel.Name = "ToLevel";
            this.ToLevel.ReadOnly = true;
            this.ToLevel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToLevel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ToTalentLevel1
            // 
            this.ToTalentLevel1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.ToTalentLevel1, "ToTalentLevel1");
            this.ToTalentLevel1.Name = "ToTalentLevel1";
            this.ToTalentLevel1.ReadOnly = true;
            this.ToTalentLevel1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToTalentLevel1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ToTalentLevel2
            // 
            this.ToTalentLevel2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.ToTalentLevel2, "ToTalentLevel2");
            this.ToTalentLevel2.Name = "ToTalentLevel2";
            this.ToTalentLevel2.ReadOnly = true;
            this.ToTalentLevel2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToTalentLevel2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ToTalentLevel3
            // 
            this.ToTalentLevel3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(this.ToTalentLevel3, "ToTalentLevel3");
            this.ToTalentLevel3.Name = "ToTalentLevel3";
            this.ToTalentLevel3.ReadOnly = true;
            this.ToTalentLevel3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToTalentLevel3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ErrorHandling
            // 
            this.ErrorHandling.Interval = 500;
            this.ErrorHandling.Tick += new System.EventHandler(this.ErrorHandling_Tick);
            // 
            // CharacterCalculator
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.CharacterView);
            this.Controls.Add(this.panel4);
            this.Name = "CharacterCalculator";
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
        private Button button2;
        private DataGridViewCheckBoxColumn CalculateStatus;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Rarelity;
        private DataGridViewTextBoxColumn ElementType;
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