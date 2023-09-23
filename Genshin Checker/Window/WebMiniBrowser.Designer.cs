namespace Genshin_Checker.Window
{
    partial class WebMiniBrowser
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
            this.Web = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.UrlBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Web)).BeginInit();
            this.SuspendLayout();
            // 
            // Web
            // 
            this.Web.AllowExternalDrop = true;
            this.Web.CreationProperties = null;
            this.Web.DefaultBackgroundColor = System.Drawing.Color.White;
            this.Web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Web.Location = new System.Drawing.Point(0, 23);
            this.Web.Name = "Web";
            this.Web.Size = new System.Drawing.Size(800, 427);
            this.Web.TabIndex = 1;
            this.Web.ZoomFactor = 1D;
            this.Web.SourceChanged += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs>(this.Web_SourceChanged);
            // 
            // UrlBox
            // 
            this.UrlBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.UrlBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.UrlBox.Location = new System.Drawing.Point(0, 0);
            this.UrlBox.Name = "UrlBox";
            this.UrlBox.ReadOnly = true;
            this.UrlBox.Size = new System.Drawing.Size(800, 23);
            this.UrlBox.TabIndex = 2;
            // 
            // WebMiniBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Web);
            this.Controls.Add(this.UrlBox);
            this.Name = "WebMiniBrowser";
            this.Text = "WebBrowser";
            ((System.ComponentModel.ISupportInitialize)(this.Web)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 Web;
        private TextBox UrlBox;
    }
}