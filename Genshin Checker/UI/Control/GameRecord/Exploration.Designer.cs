namespace Genshin_Checker.Window.Contains
{
    partial class Exploration
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exploration));
            this.ExContainer = new System.Windows.Forms.Panel();
            this.ExContain_Main = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExContain_Index = new System.Windows.Forms.Panel();
            this.OculusCount = new System.Windows.Forms.Label();
            this.ExContain_MapName = new System.Windows.Forms.Label();
            this.ExContain_MapIcon = new System.Windows.Forms.PictureBox();
            this.ExContain_ShowDetailButton = new System.Windows.Forms.Button();
            this.ExContain_ProgressPanel = new System.Windows.Forms.Panel();
            this.ExContain_HideDetailButton = new System.Windows.Forms.Button();
            this.ExContainer.SuspendLayout();
            this.ExContain_Main.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_MapIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ExContainer
            // 
            resources.ApplyResources(this.ExContainer, "ExContainer");
            this.ExContainer.Controls.Add(this.ExContain_Main);
            this.ExContainer.Name = "ExContainer";
            // 
            // ExContain_Main
            // 
            resources.ApplyResources(this.ExContain_Main, "ExContain_Main");
            this.ExContain_Main.Controls.Add(this.panel1);
            this.ExContain_Main.Controls.Add(this.ExContain_MapName);
            this.ExContain_Main.Controls.Add(this.ExContain_MapIcon);
            this.ExContain_Main.Name = "ExContain_Main";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.ExContain_Index);
            this.panel1.Controls.Add(this.OculusCount);
            this.panel1.Name = "panel1";
            // 
            // ExContain_Index
            // 
            resources.ApplyResources(this.ExContain_Index, "ExContain_Index");
            this.ExContain_Index.Name = "ExContain_Index";
            // 
            // OculusCount
            // 
            resources.ApplyResources(this.OculusCount, "OculusCount");
            this.OculusCount.Name = "OculusCount";
            // 
            // ExContain_MapName
            // 
            resources.ApplyResources(this.ExContain_MapName, "ExContain_MapName");
            this.ExContain_MapName.Name = "ExContain_MapName";
            // 
            // ExContain_MapIcon
            // 
            resources.ApplyResources(this.ExContain_MapIcon, "ExContain_MapIcon");
            this.ExContain_MapIcon.BackColor = System.Drawing.Color.Transparent;
            this.ExContain_MapIcon.Name = "ExContain_MapIcon";
            this.ExContain_MapIcon.TabStop = false;
            // 
            // ExContain_ShowDetailButton
            // 
            resources.ApplyResources(this.ExContain_ShowDetailButton, "ExContain_ShowDetailButton");
            this.ExContain_ShowDetailButton.Name = "ExContain_ShowDetailButton";
            this.ExContain_ShowDetailButton.UseVisualStyleBackColor = true;
            // 
            // ExContain_ProgressPanel
            // 
            resources.ApplyResources(this.ExContain_ProgressPanel, "ExContain_ProgressPanel");
            this.ExContain_ProgressPanel.Name = "ExContain_ProgressPanel";
            // 
            // ExContain_HideDetailButton
            // 
            resources.ApplyResources(this.ExContain_HideDetailButton, "ExContain_HideDetailButton");
            this.ExContain_HideDetailButton.Name = "ExContain_HideDetailButton";
            this.ExContain_HideDetailButton.UseVisualStyleBackColor = true;
            // 
            // Exploration
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.ExContain_HideDetailButton);
            this.Controls.Add(this.ExContain_ShowDetailButton);
            this.Controls.Add(this.ExContain_ProgressPanel);
            this.Controls.Add(this.ExContainer);
            this.Name = "Exploration";
            this.ExContainer.ResumeLayout(false);
            this.ExContain_Main.ResumeLayout(false);
            this.ExContain_Main.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_MapIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel ExContainer;
        private Panel ExContain_Main;
        private Panel ExContain_Index;
        private Label ExContain_MapName;
        private PictureBox ExContain_MapIcon;
        private Button ExContain_ShowDetailButton;
        private Panel ExContain_ProgressPanel;
        private Label OculusCount;
        private Panel panel1;
        private Button ExContain_HideDetailButton;
    }
}
