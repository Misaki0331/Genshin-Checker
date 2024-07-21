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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.InputText = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Execution = new System.Windows.Forms.Button();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputText
            // 
            resources.ApplyResources(this.InputText, "InputText");
            this.InputText.Name = "InputText";
            this.InputText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputText_KeyPress);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.InputText);
            this.panel1.Controls.Add(this.Execution);
            this.panel1.Name = "panel1";
            // 
            // Execution
            // 
            resources.ApplyResources(this.Execution, "Execution");
            this.Execution.Name = "Execution";
            this.Execution.UseVisualStyleBackColor = true;
            this.Execution.Click += new System.EventHandler(this.Execution_Click);
            // 
            // OutputText
            // 
            resources.ApplyResources(this.OutputText, "OutputText");
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            // 
            // Console
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.panel1);
            this.Name = "Console";
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