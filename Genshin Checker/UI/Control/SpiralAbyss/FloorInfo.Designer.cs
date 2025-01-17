namespace Genshin_Checker.UI.Control.SpiralAbyss
{
    partial class FloorInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorInfo));
            LabelArea = new Label();
            LabelInfomation = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            LabelStars = new Label();
            LabelLatestUpdate = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LabelArea
            // 
            LabelArea.AutoSize = true;
            LabelArea.Dock = DockStyle.Left;
            LabelArea.Font = new Font("Meiryo UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            LabelArea.Location = new Point(0, 0);
            LabelArea.Name = "LabelArea";
            LabelArea.Padding = new Padding(3, 0, 0, 0);
            LabelArea.Size = new Size(99, 37);
            LabelArea.TabIndex = 0;
            LabelArea.Text = "12 層";
            LabelArea.TextAlign = ContentAlignment.MiddleLeft;
            LabelArea.Click += ClickEvent;
            LabelArea.Paint += LabelPaint;
            // 
            // LabelInfomation
            // 
            LabelInfomation.BackColor = Color.Transparent;
            LabelInfomation.Dock = DockStyle.Bottom;
            LabelInfomation.Font = new Font("Meiryo UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelInfomation.Location = new Point(0, 58);
            LabelInfomation.Name = "LabelInfomation";
            LabelInfomation.Size = new Size(345, 83);
            LabelInfomation.TabIndex = 1;
            LabelInfomation.Text = "地脈異常の文字列";
            LabelInfomation.TextAlign = ContentAlignment.BottomCenter;
            LabelInfomation.Click += ClickEvent;
            LabelInfomation.Paint += LabelPaint;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(LabelArea);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(LabelStars);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(345, 38);
            panel1.TabIndex = 4;
            panel1.Click += ClickEvent;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(173, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.MaximumSize = new Size(38, 38);
            pictureBox1.MinimumSize = new Size(38, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 38);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += ClickEvent;
            // 
            // LabelStars
            // 
            LabelStars.AutoSize = true;
            LabelStars.Dock = DockStyle.Right;
            LabelStars.Font = new Font("Meiryo UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            LabelStars.Location = new Point(211, 0);
            LabelStars.Margin = new Padding(0);
            LabelStars.Name = "LabelStars";
            LabelStars.Size = new Size(134, 37);
            LabelStars.TabIndex = 5;
            LabelStars.Text = "99 / 99";
            LabelStars.TextAlign = ContentAlignment.MiddleCenter;
            LabelStars.Click += ClickEvent;
            LabelStars.Paint += LabelPaint;
            // 
            // LabelLatestUpdate
            // 
            LabelLatestUpdate.AutoSize = true;
            LabelLatestUpdate.Dock = DockStyle.Left;
            LabelLatestUpdate.Font = new Font("Meiryo UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            LabelLatestUpdate.Location = new Point(0, 38);
            LabelLatestUpdate.Name = "LabelLatestUpdate";
            LabelLatestUpdate.Padding = new Padding(3, 0, 0, 0);
            LabelLatestUpdate.Size = new Size(254, 20);
            LabelLatestUpdate.TabIndex = 5;
            LabelLatestUpdate.Text = "最終更新 2023/12/25 12:34:56";
            LabelLatestUpdate.Click += ClickEvent;
            LabelLatestUpdate.Paint += LabelPaint;
            // 
            // FloorInfo
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(LabelLatestUpdate);
            Controls.Add(panel1);
            Controls.Add(LabelInfomation);
            MaximumSize = new Size(345, 141);
            MinimumSize = new Size(345, 141);
            Name = "FloorInfo";
            Size = new Size(345, 141);
            Load += FloorInfo_Load;
            Click += ClickEvent;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelArea;
        private Label LabelInfomation;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label LabelStars;
        private Label LabelLatestUpdate;
    }
}
