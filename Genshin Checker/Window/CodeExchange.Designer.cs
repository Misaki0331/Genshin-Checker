namespace Genshin_Checker.Window
{
    partial class CodeExchange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeExchange));
            ComboHoYoLabAccounts = new ComboBox();
            button1 = new Button();
            CodeInput = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // ComboHoYoLabAccounts
            // 
            resources.ApplyResources(ComboHoYoLabAccounts, "ComboHoYoLabAccounts");
            ComboHoYoLabAccounts.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboHoYoLabAccounts.FormattingEnabled = true;
            ComboHoYoLabAccounts.Name = "ComboHoYoLabAccounts";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CodeInput
            // 
            resources.ApplyResources(CodeInput, "CodeInput");
            CodeInput.Name = "CodeInput";
            CodeInput.KeyPress += CodeInput_KeyPress;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(CodeInput);
            panel2.Controls.Add(button1);
            panel2.Name = "panel2";
            // 
            // CodeExchange
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(ComboHoYoLabAccounts);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CodeExchange";
            Load += CodeExchange_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboHoYoLabAccounts;
        private Button button1;
        private TextBox CodeInput;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
    }
}