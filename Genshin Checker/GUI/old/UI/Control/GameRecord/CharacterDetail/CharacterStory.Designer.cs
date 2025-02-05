namespace Genshin_Checker.UI.Control.GameRecord.CharacterDetail
{
    partial class CharacterStory
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
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(200, 50);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Meiryo UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(48, 5);
            label2.Name = "label2";
            label2.Size = new Size(147, 24);
            label2.TabIndex = 2;
            label2.Text = "label2";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Bottom;
            label1.Font = new Font("Meiryo UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(48, 29);
            label1.Name = "label1";
            label1.Size = new Size(147, 16);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.Dock = DockStyle.Left;
            button1.Font = new Font("Meiryo UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(5, 5);
            button1.Name = "button1";
            button1.Size = new Size(43, 40);
            button1.TabIndex = 0;
            button1.Text = "▼";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Meiryo UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(0, 50);
            label3.Name = "label3";
            label3.Size = new Size(46, 17);
            label3.TabIndex = 1;
            label3.Text = "label3";
            label3.Visible = false;
            // 
            // CharacterStory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(label3);
            Controls.Add(panel1);
            MinimumSize = new Size(200, 50);
            Name = "CharacterStory";
            Size = new Size(200, 67);
            Load += CharacterStory_Load;
            SizeChanged += CharacterStory_SizeChanged;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}
