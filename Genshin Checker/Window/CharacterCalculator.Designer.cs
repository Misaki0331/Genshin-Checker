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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharacterCalculator));
            button1 = new Button();
            panel4 = new Panel();
            button2 = new Button();
            ButtonSelectAll = new Button();
            ButtonBatch = new Button();
            CharacterView = new DataGridView();
            ErrorHandling = new System.Windows.Forms.Timer(components);
            CalculateStatus = new DataGridViewCheckBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            Rarelity = new DataGridViewTextBoxColumn();
            ElementType = new DataGridViewTextBoxColumn();
            CharacterName = new DataGridViewTextBoxColumn();
            Weapon = new DataGridViewTextBoxColumn();
            Fetter = new DataGridViewTextBoxColumn();
            CurrentLevel = new DataGridViewTextBoxColumn();
            CurrentTalentLevel1 = new DataGridViewTextBoxColumn();
            CurrentTalentLevel2 = new DataGridViewTextBoxColumn();
            CurrentTalentLevel3 = new DataGridViewTextBoxColumn();
            ToArrow = new DataGridViewTextBoxColumn();
            ToLevel = new DataGridViewTextBoxColumn();
            ToTalentLevel1 = new DataGridViewTextBoxColumn();
            ToTalentLevel2 = new DataGridViewTextBoxColumn();
            ToTalentLevel3 = new DataGridViewTextBoxColumn();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CharacterView).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(button2);
            panel4.Controls.Add(ButtonSelectAll);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(ButtonBatch);
            resources.ApplyResources(panel4, "panel4");
            panel4.Name = "panel4";
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ButtonSelectAll
            // 
            resources.ApplyResources(ButtonSelectAll, "ButtonSelectAll");
            ButtonSelectAll.Name = "ButtonSelectAll";
            ButtonSelectAll.UseVisualStyleBackColor = true;
            ButtonSelectAll.Click += ButtonSelectAll_Click;
            // 
            // ButtonBatch
            // 
            resources.ApplyResources(ButtonBatch, "ButtonBatch");
            ButtonBatch.Name = "ButtonBatch";
            ButtonBatch.UseVisualStyleBackColor = true;
            ButtonBatch.Click += ButtonBatch_Click;
            // 
            // CharacterView
            // 
            CharacterView.AllowUserToAddRows = false;
            CharacterView.AllowUserToDeleteRows = false;
            CharacterView.AllowUserToResizeColumns = false;
            CharacterView.AllowUserToResizeRows = false;
            CharacterView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CharacterView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            CharacterView.Columns.AddRange(new DataGridViewColumn[] { CalculateStatus, ID, Rarelity, ElementType, CharacterName, Weapon, Fetter, CurrentLevel, CurrentTalentLevel1, CurrentTalentLevel2, CurrentTalentLevel3, ToArrow, ToLevel, ToTalentLevel1, ToTalentLevel2, ToTalentLevel3 });
            resources.ApplyResources(CharacterView, "CharacterView");
            CharacterView.Name = "CharacterView";
            CharacterView.ReadOnly = true;
            CharacterView.RowHeadersVisible = false;
            CharacterView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            CharacterView.RowTemplate.Height = 25;
            CharacterView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CharacterView.CellDoubleClick += CharacterView_CellDoubleClick;
            CharacterView.CellEnter += CharacterView_CellEnter;
            CharacterView.CellFormatting += CharacterView_CellFormatting;
            CharacterView.CellValueChanged += CharacterView_CellValueChanged;
            CharacterView.CurrentCellDirtyStateChanged += CharacterView_CurrentCellDirtyStateChanged;
            CharacterView.DataError += CharacterView_DataError;
            CharacterView.SelectionChanged += CharacterView_SelectionChanged;
            // 
            // ErrorHandling
            // 
            ErrorHandling.Interval = 500;
            ErrorHandling.Tick += ErrorHandling_Tick;
            // 
            // CalculateStatus
            // 
            CalculateStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            CalculateStatus.Frozen = true;
            resources.ApplyResources(CalculateStatus, "CalculateStatus");
            CalculateStatus.Name = "CalculateStatus";
            CalculateStatus.ReadOnly = true;
            CalculateStatus.Resizable = DataGridViewTriState.False;
            CalculateStatus.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ID
            // 
            ID.Frozen = true;
            resources.ApplyResources(ID, "ID");
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Rarelity
            // 
            Rarelity.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Rarelity.Frozen = true;
            resources.ApplyResources(Rarelity, "Rarelity");
            Rarelity.Name = "Rarelity";
            Rarelity.ReadOnly = true;
            Rarelity.Resizable = DataGridViewTriState.False;
            // 
            // ElementType
            // 
            ElementType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            ElementType.Frozen = true;
            resources.ApplyResources(ElementType, "ElementType");
            ElementType.Name = "ElementType";
            ElementType.ReadOnly = true;
            ElementType.Resizable = DataGridViewTriState.False;
            // 
            // CharacterName
            // 
            resources.ApplyResources(CharacterName, "CharacterName");
            CharacterName.Name = "CharacterName";
            CharacterName.ReadOnly = true;
            CharacterName.Resizable = DataGridViewTriState.False;
            // 
            // Weapon
            // 
            Weapon.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(Weapon, "Weapon");
            Weapon.Name = "Weapon";
            Weapon.ReadOnly = true;
            Weapon.Resizable = DataGridViewTriState.False;
            // 
            // Fetter
            // 
            Fetter.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(Fetter, "Fetter");
            Fetter.Name = "Fetter";
            Fetter.ReadOnly = true;
            Fetter.Resizable = DataGridViewTriState.False;
            // 
            // CurrentLevel
            // 
            CurrentLevel.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(CurrentLevel, "CurrentLevel");
            CurrentLevel.Name = "CurrentLevel";
            CurrentLevel.ReadOnly = true;
            CurrentLevel.Resizable = DataGridViewTriState.False;
            // 
            // CurrentTalentLevel1
            // 
            CurrentTalentLevel1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(CurrentTalentLevel1, "CurrentTalentLevel1");
            CurrentTalentLevel1.Name = "CurrentTalentLevel1";
            CurrentTalentLevel1.ReadOnly = true;
            CurrentTalentLevel1.Resizable = DataGridViewTriState.False;
            // 
            // CurrentTalentLevel2
            // 
            CurrentTalentLevel2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(CurrentTalentLevel2, "CurrentTalentLevel2");
            CurrentTalentLevel2.Name = "CurrentTalentLevel2";
            CurrentTalentLevel2.ReadOnly = true;
            CurrentTalentLevel2.Resizable = DataGridViewTriState.False;
            // 
            // CurrentTalentLevel3
            // 
            CurrentTalentLevel3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(CurrentTalentLevel3, "CurrentTalentLevel3");
            CurrentTalentLevel3.Name = "CurrentTalentLevel3";
            CurrentTalentLevel3.ReadOnly = true;
            CurrentTalentLevel3.Resizable = DataGridViewTriState.False;
            // 
            // ToArrow
            // 
            ToArrow.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(ToArrow, "ToArrow");
            ToArrow.Name = "ToArrow";
            ToArrow.ReadOnly = true;
            ToArrow.Resizable = DataGridViewTriState.False;
            ToArrow.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ToLevel
            // 
            ToLevel.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(ToLevel, "ToLevel");
            ToLevel.Name = "ToLevel";
            ToLevel.ReadOnly = true;
            ToLevel.Resizable = DataGridViewTriState.False;
            ToLevel.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ToTalentLevel1
            // 
            ToTalentLevel1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(ToTalentLevel1, "ToTalentLevel1");
            ToTalentLevel1.Name = "ToTalentLevel1";
            ToTalentLevel1.ReadOnly = true;
            ToTalentLevel1.Resizable = DataGridViewTriState.False;
            ToTalentLevel1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ToTalentLevel2
            // 
            ToTalentLevel2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(ToTalentLevel2, "ToTalentLevel2");
            ToTalentLevel2.Name = "ToTalentLevel2";
            ToTalentLevel2.ReadOnly = true;
            ToTalentLevel2.Resizable = DataGridViewTriState.False;
            ToTalentLevel2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ToTalentLevel3
            // 
            ToTalentLevel3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            resources.ApplyResources(ToTalentLevel3, "ToTalentLevel3");
            ToTalentLevel3.Name = "ToTalentLevel3";
            ToTalentLevel3.ReadOnly = true;
            ToTalentLevel3.Resizable = DataGridViewTriState.False;
            ToTalentLevel3.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // CharacterCalculator
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(CharacterView);
            Controls.Add(panel4);
            Name = "CharacterCalculator";
            Load += CharacterCalculator_Load;
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CharacterView).EndInit();
            ResumeLayout(false);
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