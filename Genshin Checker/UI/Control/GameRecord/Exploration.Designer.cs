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
            this.ExContainer = new System.Windows.Forms.Panel();
            this.ExContain_Main = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExContain_Index = new System.Windows.Forms.Panel();
            this.OculusCount = new System.Windows.Forms.Label();
            this.ExContain_MapName = new System.Windows.Forms.Label();
            this.ExContain_MapIcon = new System.Windows.Forms.PictureBox();
            this.ExContain_ShowDetailButton = new System.Windows.Forms.Button();
            this.ExContain_ProgressPanel = new System.Windows.Forms.Panel();
            this.ExContainer.SuspendLayout();
            this.ExContain_Main.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_MapIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // ExContainer
            // 
            this.ExContainer.AutoSize = true;
            this.ExContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExContainer.Controls.Add(this.ExContain_Main);
            this.ExContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContainer.Location = new System.Drawing.Point(0, 0);
            this.ExContainer.Name = "ExContainer";
            this.ExContainer.Size = new System.Drawing.Size(411, 100);
            this.ExContainer.TabIndex = 1;
            // 
            // ExContain_Main
            // 
            this.ExContain_Main.Controls.Add(this.panel1);
            this.ExContain_Main.Controls.Add(this.ExContain_MapName);
            this.ExContain_Main.Controls.Add(this.ExContain_MapIcon);
            this.ExContain_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_Main.Location = new System.Drawing.Point(0, 0);
            this.ExContain_Main.Name = "ExContain_Main";
            this.ExContain_Main.Size = new System.Drawing.Size(411, 100);
            this.ExContain_Main.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ExContain_Index);
            this.panel1.Controls.Add(this.OculusCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(100, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 71);
            this.panel1.TabIndex = 11;
            // 
            // ExContain_Index
            // 
            this.ExContain_Index.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExContain_Index.Location = new System.Drawing.Point(0, 0);
            this.ExContain_Index.Name = "ExContain_Index";
            this.ExContain_Index.Size = new System.Drawing.Size(210, 71);
            this.ExContain_Index.TabIndex = 3;
            // 
            // OculusCount
            // 
            this.OculusCount.AutoSize = true;
            this.OculusCount.Dock = System.Windows.Forms.DockStyle.Right;
            this.OculusCount.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OculusCount.Location = new System.Drawing.Point(210, 0);
            this.OculusCount.MinimumSize = new System.Drawing.Size(0, 71);
            this.OculusCount.Name = "OculusCount";
            this.OculusCount.Size = new System.Drawing.Size(101, 71);
            this.OculusCount.TabIndex = 10;
            this.OculusCount.Text = "神の瞳 : 999";
            this.OculusCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // ExContain_MapName
            // 
            this.ExContain_MapName.AutoSize = true;
            this.ExContain_MapName.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExContain_MapName.Location = new System.Drawing.Point(100, 0);
            this.ExContain_MapName.Name = "ExContain_MapName";
            this.ExContain_MapName.Size = new System.Drawing.Size(222, 26);
            this.ExContain_MapName.TabIndex = 0;
            this.ExContain_MapName.Text = "地名地名地名地名地名";
            // 
            // ExContain_MapIcon
            // 
            this.ExContain_MapIcon.BackColor = System.Drawing.Color.Transparent;
            this.ExContain_MapIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExContain_MapIcon.Location = new System.Drawing.Point(0, 0);
            this.ExContain_MapIcon.Name = "ExContain_MapIcon";
            this.ExContain_MapIcon.Size = new System.Drawing.Size(100, 100);
            this.ExContain_MapIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExContain_MapIcon.TabIndex = 1;
            this.ExContain_MapIcon.TabStop = false;
            // 
            // ExContain_ShowDetailButton
            // 
            this.ExContain_ShowDetailButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_ShowDetailButton.Location = new System.Drawing.Point(0, 100);
            this.ExContain_ShowDetailButton.Name = "ExContain_ShowDetailButton";
            this.ExContain_ShowDetailButton.Size = new System.Drawing.Size(411, 23);
            this.ExContain_ShowDetailButton.TabIndex = 8;
            this.ExContain_ShowDetailButton.Text = "もっと見る ▶";
            this.ExContain_ShowDetailButton.UseVisualStyleBackColor = true;
            this.ExContain_ShowDetailButton.Visible = false;
            // 
            // ExContain_ProgressPanel
            // 
            this.ExContain_ProgressPanel.AutoSize = true;
            this.ExContain_ProgressPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_ProgressPanel.Location = new System.Drawing.Point(0, 100);
            this.ExContain_ProgressPanel.Name = "ExContain_ProgressPanel";
            this.ExContain_ProgressPanel.Size = new System.Drawing.Size(411, 0);
            this.ExContain_ProgressPanel.TabIndex = 9;
            // 
            // Exploration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.ExContain_ShowDetailButton);
            this.Controls.Add(this.ExContain_ProgressPanel);
            this.Controls.Add(this.ExContainer);
            this.Name = "Exploration";
            this.Size = new System.Drawing.Size(411, 123);
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
    }
}
