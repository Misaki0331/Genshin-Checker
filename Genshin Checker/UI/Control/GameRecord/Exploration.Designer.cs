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
            ExContainer = new Panel();
            ExContain_Main = new Panel();
            panel1 = new Panel();
            ExContain_Index = new Panel();
            OculusCount = new Label();
            ExContain_MapName = new Label();
            ExContain_MapIcon = new PictureBox();
            ExContain_ShowDetailButton = new Button();
            ExContain_ProgressPanel = new Panel();
            ExContain_HideDetailButton = new Button();
            DetailPanel = new Panel();
            groupBox1 = new GroupBox();
            ExContainer.SuspendLayout();
            ExContain_Main.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ExContain_MapIcon).BeginInit();
            DetailPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ExContainer
            // 
            resources.ApplyResources(ExContainer, "ExContainer");
            ExContainer.Controls.Add(ExContain_Main);
            ExContainer.Name = "ExContainer";
            // 
            // ExContain_Main
            // 
            resources.ApplyResources(ExContain_Main, "ExContain_Main");
            ExContain_Main.Controls.Add(panel1);
            ExContain_Main.Controls.Add(ExContain_MapName);
            ExContain_Main.Controls.Add(ExContain_MapIcon);
            ExContain_Main.Name = "ExContain_Main";
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(ExContain_Index);
            panel1.Controls.Add(OculusCount);
            panel1.Name = "panel1";
            // 
            // ExContain_Index
            // 
            resources.ApplyResources(ExContain_Index, "ExContain_Index");
            ExContain_Index.Name = "ExContain_Index";
            // 
            // OculusCount
            // 
            resources.ApplyResources(OculusCount, "OculusCount");
            OculusCount.Name = "OculusCount";
            // 
            // ExContain_MapName
            // 
            resources.ApplyResources(ExContain_MapName, "ExContain_MapName");
            ExContain_MapName.Name = "ExContain_MapName";
            // 
            // ExContain_MapIcon
            // 
            resources.ApplyResources(ExContain_MapIcon, "ExContain_MapIcon");
            ExContain_MapIcon.BackColor = Color.Transparent;
            ExContain_MapIcon.Name = "ExContain_MapIcon";
            ExContain_MapIcon.TabStop = false;
            // 
            // ExContain_ShowDetailButton
            // 
            resources.ApplyResources(ExContain_ShowDetailButton, "ExContain_ShowDetailButton");
            ExContain_ShowDetailButton.Name = "ExContain_ShowDetailButton";
            ExContain_ShowDetailButton.UseVisualStyleBackColor = true;
            ExContain_ShowDetailButton.Click += ExContain_ShowDetailButton_Click;
            // 
            // ExContain_ProgressPanel
            // 
            resources.ApplyResources(ExContain_ProgressPanel, "ExContain_ProgressPanel");
            ExContain_ProgressPanel.Name = "ExContain_ProgressPanel";
            // 
            // ExContain_HideDetailButton
            // 
            resources.ApplyResources(ExContain_HideDetailButton, "ExContain_HideDetailButton");
            ExContain_HideDetailButton.Name = "ExContain_HideDetailButton";
            ExContain_HideDetailButton.UseVisualStyleBackColor = true;
            ExContain_HideDetailButton.Click += ExContain_HideDetailButton_Click;
            // 
            // DetailPanel
            // 
            resources.ApplyResources(DetailPanel, "DetailPanel");
            DetailPanel.Controls.Add(groupBox1);
            DetailPanel.Name = "DetailPanel";
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // Exploration
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(ExContain_HideDetailButton);
            Controls.Add(DetailPanel);
            Controls.Add(ExContain_ShowDetailButton);
            Controls.Add(ExContain_ProgressPanel);
            Controls.Add(ExContainer);
            Name = "Exploration";
            ExContainer.ResumeLayout(false);
            ExContain_Main.ResumeLayout(false);
            ExContain_Main.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ExContain_MapIcon).EndInit();
            DetailPanel.ResumeLayout(false);
            DetailPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private Panel DetailPanel;
        private GroupBox groupBox1;
    }
}
