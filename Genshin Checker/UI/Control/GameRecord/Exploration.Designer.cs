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
            this.ExContain_Index = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ExContain_LevelPanel2 = new System.Windows.Forms.Panel();
            this.ExContain_LevelName2 = new System.Windows.Forms.Label();
            this.ExContain_LevelIcon2 = new System.Windows.Forms.PictureBox();
            this.ExContain_LevelPanel1 = new System.Windows.Forms.Panel();
            this.ExContain_LevelName1 = new System.Windows.Forms.Label();
            this.ExContain_LevelIcon1 = new System.Windows.Forms.PictureBox();
            this.ExContain_MapName = new System.Windows.Forms.Label();
            this.ExContain_MapIcon = new System.Windows.Forms.PictureBox();
            this.ExContain_ShowDetailButton = new System.Windows.Forms.Button();
            this.ExContain_ProgressPanel = new System.Windows.Forms.Panel();
            this.ExContainer.SuspendLayout();
            this.ExContain_Main.SuspendLayout();
            this.ExContain_Index.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ExContain_LevelPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_LevelIcon2)).BeginInit();
            this.ExContain_LevelPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_LevelIcon1)).BeginInit();
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
            this.ExContain_Main.Controls.Add(this.ExContain_Index);
            this.ExContain_Main.Controls.Add(this.ExContain_MapName);
            this.ExContain_Main.Controls.Add(this.ExContain_MapIcon);
            this.ExContain_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_Main.Location = new System.Drawing.Point(0, 0);
            this.ExContain_Main.Name = "ExContain_Main";
            this.ExContain_Main.Size = new System.Drawing.Size(411, 100);
            this.ExContain_Main.TabIndex = 3;
            // 
            // ExContain_Index
            // 
            this.ExContain_Index.Controls.Add(this.panel1);
            this.ExContain_Index.Controls.Add(this.ExContain_LevelPanel2);
            this.ExContain_Index.Controls.Add(this.ExContain_LevelPanel1);
            this.ExContain_Index.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExContain_Index.Location = new System.Drawing.Point(100, 29);
            this.ExContain_Index.Name = "ExContain_Index";
            this.ExContain_Index.Size = new System.Drawing.Size(311, 71);
            this.ExContain_Index.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 24);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "何かしらのレベル : 99";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ExContain_LevelPanel2
            // 
            this.ExContain_LevelPanel2.Controls.Add(this.ExContain_LevelName2);
            this.ExContain_LevelPanel2.Controls.Add(this.ExContain_LevelIcon2);
            this.ExContain_LevelPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_LevelPanel2.Location = new System.Drawing.Point(0, 24);
            this.ExContain_LevelPanel2.Name = "ExContain_LevelPanel2";
            this.ExContain_LevelPanel2.Size = new System.Drawing.Size(311, 24);
            this.ExContain_LevelPanel2.TabIndex = 5;
            this.ExContain_LevelPanel2.Visible = false;
            // 
            // ExContain_LevelName2
            // 
            this.ExContain_LevelName2.AutoSize = true;
            this.ExContain_LevelName2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExContain_LevelName2.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExContain_LevelName2.Location = new System.Drawing.Point(24, 0);
            this.ExContain_LevelName2.Name = "ExContain_LevelName2";
            this.ExContain_LevelName2.Size = new System.Drawing.Size(149, 20);
            this.ExContain_LevelName2.TabIndex = 1;
            this.ExContain_LevelName2.Text = "何かしらのレベル : 99";
            // 
            // ExContain_LevelIcon2
            // 
            this.ExContain_LevelIcon2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExContain_LevelIcon2.Location = new System.Drawing.Point(0, 0);
            this.ExContain_LevelIcon2.Name = "ExContain_LevelIcon2";
            this.ExContain_LevelIcon2.Size = new System.Drawing.Size(24, 24);
            this.ExContain_LevelIcon2.TabIndex = 0;
            this.ExContain_LevelIcon2.TabStop = false;
            // 
            // ExContain_LevelPanel1
            // 
            this.ExContain_LevelPanel1.Controls.Add(this.ExContain_LevelName1);
            this.ExContain_LevelPanel1.Controls.Add(this.ExContain_LevelIcon1);
            this.ExContain_LevelPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ExContain_LevelPanel1.Location = new System.Drawing.Point(0, 0);
            this.ExContain_LevelPanel1.Name = "ExContain_LevelPanel1";
            this.ExContain_LevelPanel1.Size = new System.Drawing.Size(311, 24);
            this.ExContain_LevelPanel1.TabIndex = 4;
            // 
            // ExContain_LevelName1
            // 
            this.ExContain_LevelName1.AutoSize = true;
            this.ExContain_LevelName1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExContain_LevelName1.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExContain_LevelName1.Location = new System.Drawing.Point(24, 0);
            this.ExContain_LevelName1.Name = "ExContain_LevelName1";
            this.ExContain_LevelName1.Size = new System.Drawing.Size(149, 20);
            this.ExContain_LevelName1.TabIndex = 1;
            this.ExContain_LevelName1.Text = "何かしらのレベル : 99";
            // 
            // ExContain_LevelIcon1
            // 
            this.ExContain_LevelIcon1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ExContain_LevelIcon1.Location = new System.Drawing.Point(0, 0);
            this.ExContain_LevelIcon1.Name = "ExContain_LevelIcon1";
            this.ExContain_LevelIcon1.Size = new System.Drawing.Size(24, 24);
            this.ExContain_LevelIcon1.TabIndex = 0;
            this.ExContain_LevelIcon1.TabStop = false;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ExContain_ShowDetailButton);
            this.Controls.Add(this.ExContain_ProgressPanel);
            this.Controls.Add(this.ExContainer);
            this.Name = "Exploration";
            this.Size = new System.Drawing.Size(411, 123);
            this.ExContainer.ResumeLayout(false);
            this.ExContain_Main.ResumeLayout(false);
            this.ExContain_Main.PerformLayout();
            this.ExContain_Index.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ExContain_LevelPanel2.ResumeLayout(false);
            this.ExContain_LevelPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_LevelIcon2)).EndInit();
            this.ExContain_LevelPanel1.ResumeLayout(false);
            this.ExContain_LevelPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_LevelIcon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExContain_MapIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel ExContainer;
        private Panel ExContain_Main;
        private Panel ExContain_Index;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Panel ExContain_LevelPanel2;
        private Label ExContain_LevelName2;
        private PictureBox ExContain_LevelIcon2;
        private Panel ExContain_LevelPanel1;
        private Label ExContain_LevelName1;
        private PictureBox ExContain_LevelIcon1;
        private Label ExContain_MapName;
        private PictureBox ExContain_MapIcon;
        private Button ExContain_ShowDetailButton;
        private Panel ExContain_ProgressPanel;
    }
}
