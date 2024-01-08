namespace Genshin_Checker.Window.Debug
{
    partial class Console
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
            this.InputText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Execution = new System.Windows.Forms.Button();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputText
            // 
            this.InputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputText.Location = new System.Drawing.Point(0, 0);
            this.InputText.Name = "InputText";
            this.InputText.Size = new System.Drawing.Size(606, 23);
            this.InputText.TabIndex = 0;
            this.InputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputText_KeyPress);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.InputText);
            this.panel1.Controls.Add(this.Execution);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 23);
            this.panel1.TabIndex = 1;
            // 
            // Execution
            // 
            this.Execution.AutoSize = true;
            this.Execution.Dock = System.Windows.Forms.DockStyle.Right;
            this.Execution.Location = new System.Drawing.Point(606, 0);
            this.Execution.Name = "Execution";
            this.Execution.Size = new System.Drawing.Size(75, 23);
            this.Execution.TabIndex = 1;
            this.Execution.Text = "実行";
            this.Execution.UseVisualStyleBackColor = true;
            this.Execution.Click += new System.EventHandler(this.Execution_Click);
            // 
            // OutputText
            // 
            this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputText.Location = new System.Drawing.Point(0, 0);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputText.Size = new System.Drawing.Size(681, 253);
            this.OutputText.TabIndex = 2;
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 276);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.panel1);
            this.Name = "Console";
            this.Text = "Console";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Console_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox InputText;
        private Panel panel1;
        private Button Execution;
        private TextBox OutputText;
    }
}