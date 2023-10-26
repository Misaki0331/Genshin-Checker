namespace Genshin_Checker.Window
{
    partial class GameLog
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
            this.CheckBoxTopMost = new System.Windows.Forms.CheckBox();
            this.ClearConsole = new System.Windows.Forms.Button();
            this.Log = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.CheckBoxTopMost);
            this.panel1.Controls.Add(this.ClearConsole);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 24);
            this.panel1.TabIndex = 0;
            // 
            // CheckBoxTopMost
            // 
            this.CheckBoxTopMost.AutoSize = true;
            this.CheckBoxTopMost.Dock = System.Windows.Forms.DockStyle.Left;
            this.CheckBoxTopMost.ForeColor = System.Drawing.Color.White;
            this.CheckBoxTopMost.Location = new System.Drawing.Point(0, 0);
            this.CheckBoxTopMost.Name = "CheckBoxTopMost";
            this.CheckBoxTopMost.Size = new System.Drawing.Size(104, 24);
            this.CheckBoxTopMost.TabIndex = 2;
            this.CheckBoxTopMost.Text = "ウィンドウ最優先";
            this.CheckBoxTopMost.UseVisualStyleBackColor = true;
            this.CheckBoxTopMost.CheckedChanged += new System.EventHandler(this.CheckBoxTopMost_CheckedChanged);
            // 
            // ClearConsole
            // 
            this.ClearConsole.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClearConsole.Location = new System.Drawing.Point(884, 0);
            this.ClearConsole.Name = "ClearConsole";
            this.ClearConsole.Size = new System.Drawing.Size(75, 24);
            this.ClearConsole.TabIndex = 0;
            this.ClearConsole.Text = "クリア";
            this.ClearConsole.UseVisualStyleBackColor = true;
            this.ClearConsole.Click += new System.EventHandler(this.button1_Click);
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.Black;
            this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Log.ForeColor = System.Drawing.Color.White;
            this.Log.Location = new System.Drawing.Point(0, 24);
            this.Log.MaxLength = 2147483647;
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(959, 426);
            this.Log.TabIndex = 1;
            // 
            // GameLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(959, 450);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.panel1);
            this.Name = "GameLog";
            this.Text = "ゲームログ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameLog_FormClosed);
            this.Load += new System.EventHandler(this.GameLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Button ClearConsole;
        private TextBox Log;
        private CheckBox CheckBoxTopMost;
    }
}