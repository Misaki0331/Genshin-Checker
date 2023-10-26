namespace Genshin_Checker.Window
{
    partial class RealTimeData
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            pictureBox2 = new PictureBox();
            this.label4 = new Label();
            UiUpdate = new System.Windows.Forms.Timer(components);
            this.panel_resin = new Panel();
            this.panel_comission = new Panel();
            this.panel_main = new Panel();
            this.panel_expedition = new Panel();
            this.panel_expendition_5 = new Panel();
            this.label_expendition_5 = new Label();
            icon_expendition_5 = new PictureBox();
            this.panel_expendition_4 = new Panel();
            this.label_expendition_4 = new Label();
            icon_expendition_4 = new PictureBox();
            this.panel_expendition_3 = new Panel();
            this.label_expendition_3 = new Label();
            icon_expendition_3 = new PictureBox();
            this.panel_expendition_2 = new Panel();
            this.label_expendition_2 = new Label();
            icon_expendition_2 = new PictureBox();
            this.panel_expendition_1 = new Panel();
            this.label_expendition_1 = new Label();
            icon_expendition_1 = new PictureBox();
            panel3 = new Panel();
            this.label11 = new Label();
            this.label_expendition_num = new Label();
            panel2 = new Panel();
            this.panel_transform = new Panel();
            this.label9 = new Label();
            pictureBox5 = new PictureBox();
            this.panel_discountboss = new Panel();
            this.label8 = new Label();
            pictureBox4 = new PictureBox();
            this.panel_homecoin = new Panel();
            this.label7 = new Label();
            this.label6 = new Label();
            this.label5 = new Label();
            pictureBox3 = new PictureBox();
            this.panel_Error = new Panel();
            this.button_Auth = new Button();
            this.label_ErrorMessage = new Label();
            this.label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            this.panel_resin.SuspendLayout();
            this.panel_comission.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel_expedition.SuspendLayout();
            this.panel_expendition_5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_5).BeginInit();
            this.panel_expendition_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_4).BeginInit();
            this.panel_expendition_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_3).BeginInit();
            this.panel_expendition_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_2).BeginInit();
            this.panel_expendition_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_1).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            this.panel_transform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            this.panel_discountboss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            this.panel_homecoin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            this.panel_Error.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Image = resource.icon.Item_Fragile_Resin;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = Color.Transparent;
            this.label1.Dock = DockStyle.Left;
            this.label1.Font = new Font("Meiryo UI", 10036F, FontStyle.Bold, GraphicsUnit.Point);
            this.label1.ForeColor = Color.Transparent;
            this.label1.Location = new Point(60, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new Padding(0, 0, 3, 0);
            this.label1.Size = new Size(133, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "---";
            this.label1.TextAlign = ContentAlignment.BottomRight;
            this.label1.Click += label1_Click;
            this.label1.Paint += Label_Paint;
            // 
            // label2
            // 
            this.label2.BackColor = Color.Transparent;
            this.label2.Dock = DockStyle.Bottom;
            this.label2.Font = new Font("Meiryo UI", 10018F, FontStyle.Bold, GraphicsUnit.Point);
            this.label2.ForeColor = Color.Transparent;
            this.label2.Location = new Point(193, 26);
            this.label2.Name = "label2";
            this.label2.Size = new Size(114, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "/---";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.label2.Paint += Label_Paint;
            // 
            // label3
            // 
            this.label3.BackColor = Color.Transparent;
            this.label3.Dock = DockStyle.Fill;
            this.label3.Font = new Font("Meiryo UI", 10012F, FontStyle.Bold, GraphicsUnit.Point);
            this.label3.ForeColor = Color.Transparent;
            this.label3.Location = new Point(193, 0);
            this.label3.Margin = new Padding(5, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(114, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "残り --:--:--";
            this.label3.TextAlign = ContentAlignment.BottomLeft;
            this.label3.Paint += Label_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Image = resource.icon.Icon_Commission;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 40);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = Color.Transparent;
            this.label4.Dock = DockStyle.Fill;
            this.label4.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            this.label4.ForeColor = Color.Transparent;
            this.label4.Location = new Point(40, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(267, 40);
            this.label4.TabIndex = 5;
            this.label4.Text = "-/-";
            this.label4.TextAlign = ContentAlignment.MiddleLeft;
            this.label4.Click += label4_Click;
            this.label4.Paint += Label_Paint;
            // 
            // UiUpdate
            // 
            UiUpdate.Enabled = true;
            UiUpdate.Tick += UiUpdate_Tick;
            // 
            // panel_resin
            // 
            this.panel_resin.BackColor = Color.Transparent;
            this.panel_resin.Controls.Add(label3);
            this.panel_resin.Controls.Add(label2);
            this.panel_resin.Controls.Add(label1);
            this.panel_resin.Controls.Add(pictureBox1);
            this.panel_resin.Dock = DockStyle.Top;
            this.panel_resin.Location = new Point(0, 0);
            this.panel_resin.Name = "panel_resin";
            this.panel_resin.Size = new Size(307, 60);
            this.panel_resin.TabIndex = 6;
            // 
            // panel_comission
            // 
            this.panel_comission.BackColor = Color.Transparent;
            this.panel_comission.Controls.Add(label4);
            this.panel_comission.Controls.Add(pictureBox2);
            this.panel_comission.Dock = DockStyle.Top;
            this.panel_comission.Location = new Point(0, 113);
            this.panel_comission.Name = "panel_comission";
            this.panel_comission.Size = new Size(307, 40);
            this.panel_comission.TabIndex = 4;
            // 
            // panel_main
            // 
            this.panel_main.BackColor = Color.Transparent;
            this.panel_main.Controls.Add(panel_expedition);
            this.panel_main.Controls.Add(panel2);
            this.panel_main.Dock = DockStyle.Fill;
            this.panel_main.Location = new Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new Size(499, 238);
            this.panel_main.TabIndex = 7;
            this.panel_main.Paint += panel1_Paint;
            // 
            // panel_expedition
            // 
            this.panel_expedition.Controls.Add(panel_expendition_5);
            this.panel_expedition.Controls.Add(panel_expendition_4);
            this.panel_expedition.Controls.Add(panel_expendition_3);
            this.panel_expedition.Controls.Add(panel_expendition_2);
            this.panel_expedition.Controls.Add(panel_expendition_1);
            this.panel_expedition.Controls.Add(panel3);
            this.panel_expedition.Dock = DockStyle.Fill;
            this.panel_expedition.Location = new Point(307, 0);
            this.panel_expedition.Name = "panel_expedition";
            this.panel_expedition.Padding = new Padding(0, 0, 4, 0);
            this.panel_expedition.Size = new Size(192, 238);
            this.panel_expedition.TabIndex = 8;
            // 
            // panel_expendition_5
            // 
            this.panel_expendition_5.Controls.Add(label_expendition_5);
            this.panel_expendition_5.Controls.Add(icon_expendition_5);
            this.panel_expendition_5.Dock = DockStyle.Top;
            this.panel_expendition_5.Location = new Point(0, 188);
            this.panel_expendition_5.Name = "panel_expendition_5";
            this.panel_expendition_5.Size = new Size(188, 40);
            this.panel_expendition_5.TabIndex = 10;
            this.panel_expendition_5.Visible = false;
            // 
            // label_expendition_5
            // 
            this.label_expendition_5.BackColor = Color.Transparent;
            this.label_expendition_5.Dock = DockStyle.Fill;
            this.label_expendition_5.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            this.label_expendition_5.ForeColor = Color.Transparent;
            this.label_expendition_5.Location = new Point(40, 0);
            this.label_expendition_5.Name = "label_expendition_5";
            this.label_expendition_5.Size = new Size(148, 40);
            this.label_expendition_5.TabIndex = 6;
            this.label_expendition_5.Text = "--:--:--";
            this.label_expendition_5.TextAlign = ContentAlignment.BottomRight;
            this.label_expendition_5.Paint += Label_Paint;
            // 
            // icon_expendition_5
            // 
            icon_expendition_5.Dock = DockStyle.Left;
            icon_expendition_5.Location = new Point(0, 0);
            icon_expendition_5.Name = "icon_expendition_5";
            icon_expendition_5.Size = new Size(40, 40);
            icon_expendition_5.SizeMode = PictureBoxSizeMode.StretchImage;
            icon_expendition_5.TabIndex = 0;
            icon_expendition_5.TabStop = false;
            // 
            // panel_expendition_4
            // 
            this.panel_expendition_4.Controls.Add(label_expendition_4);
            this.panel_expendition_4.Controls.Add(icon_expendition_4);
            this.panel_expendition_4.Dock = DockStyle.Top;
            this.panel_expendition_4.Location = new Point(0, 148);
            this.panel_expendition_4.Name = "panel_expendition_4";
            this.panel_expendition_4.Size = new Size(188, 40);
            this.panel_expendition_4.TabIndex = 9;
            this.panel_expendition_4.Visible = false;
            // 
            // label_expendition_4
            // 
            this.label_expendition_4.BackColor = Color.Transparent;
            this.label_expendition_4.Dock = DockStyle.Fill;
            this.label_expendition_4.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            this.label_expendition_4.ForeColor = Color.Transparent;
            this.label_expendition_4.Location = new Point(40, 0);
            this.label_expendition_4.Name = "label_expendition_4";
            this.label_expendition_4.Size = new Size(148, 40);
            this.label_expendition_4.TabIndex = 6;
            this.label_expendition_4.Text = "--:--:--";
            this.label_expendition_4.TextAlign = ContentAlignment.BottomRight;
            this.label_expendition_4.Paint += Label_Paint;
            // 
            // icon_expendition_4
            // 
            icon_expendition_4.Dock = DockStyle.Left;
            icon_expendition_4.Location = new Point(0, 0);
            icon_expendition_4.Name = "icon_expendition_4";
            icon_expendition_4.Size = new Size(40, 40);
            icon_expendition_4.SizeMode = PictureBoxSizeMode.StretchImage;
            icon_expendition_4.TabIndex = 0;
            icon_expendition_4.TabStop = false;
            // 
            // panel_expendition_3
            // 
            this.panel_expendition_3.Controls.Add(label_expendition_3);
            this.panel_expendition_3.Controls.Add(icon_expendition_3);
            this.panel_expendition_3.Dock = DockStyle.Top;
            this.panel_expendition_3.Location = new Point(0, 108);
            this.panel_expendition_3.Name = "panel_expendition_3";
            this.panel_expendition_3.Size = new Size(188, 40);
            this.panel_expendition_3.TabIndex = 8;
            this.panel_expendition_3.Visible = false;
            // 
            // label_expendition_3
            // 
            this.label_expendition_3.BackColor = Color.Transparent;
            this.label_expendition_3.Dock = DockStyle.Fill;
            this.label_expendition_3.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            this.label_expendition_3.ForeColor = Color.Transparent;
            this.label_expendition_3.Location = new Point(40, 0);
            this.label_expendition_3.Name = "label_expendition_3";
            this.label_expendition_3.Size = new Size(148, 40);
            this.label_expendition_3.TabIndex = 6;
            this.label_expendition_3.Text = "--:--:--";
            this.label_expendition_3.TextAlign = ContentAlignment.BottomRight;
            this.label_expendition_3.Paint += Label_Paint;
            // 
            // icon_expendition_3
            // 
            icon_expendition_3.Dock = DockStyle.Left;
            icon_expendition_3.Location = new Point(0, 0);
            icon_expendition_3.Name = "icon_expendition_3";
            icon_expendition_3.Size = new Size(40, 40);
            icon_expendition_3.SizeMode = PictureBoxSizeMode.StretchImage;
            icon_expendition_3.TabIndex = 0;
            icon_expendition_3.TabStop = false;
            // 
            // panel_expendition_2
            // 
            this.panel_expendition_2.Controls.Add(label_expendition_2);
            this.panel_expendition_2.Controls.Add(icon_expendition_2);
            this.panel_expendition_2.Dock = DockStyle.Top;
            this.panel_expendition_2.Location = new Point(0, 68);
            this.panel_expendition_2.Name = "panel_expendition_2";
            this.panel_expendition_2.Size = new Size(188, 40);
            this.panel_expendition_2.TabIndex = 7;
            this.panel_expendition_2.Visible = false;
            // 
            // label_expendition_2
            // 
            this.label_expendition_2.BackColor = Color.Transparent;
            this.label_expendition_2.Dock = DockStyle.Fill;
            this.label_expendition_2.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            this.label_expendition_2.ForeColor = Color.Transparent;
            this.label_expendition_2.Location = new Point(40, 0);
            this.label_expendition_2.Name = "label_expendition_2";
            this.label_expendition_2.Size = new Size(148, 40);
            this.label_expendition_2.TabIndex = 6;
            this.label_expendition_2.Text = "--:--:--";
            this.label_expendition_2.TextAlign = ContentAlignment.BottomRight;
            this.label_expendition_2.Paint += Label_Paint;
            // 
            // icon_expendition_2
            // 
            icon_expendition_2.Dock = DockStyle.Left;
            icon_expendition_2.Location = new Point(0, 0);
            icon_expendition_2.Name = "icon_expendition_2";
            icon_expendition_2.Size = new Size(40, 40);
            icon_expendition_2.SizeMode = PictureBoxSizeMode.StretchImage;
            icon_expendition_2.TabIndex = 0;
            icon_expendition_2.TabStop = false;
            // 
            // panel_expendition_1
            // 
            this.panel_expendition_1.Controls.Add(label_expendition_1);
            this.panel_expendition_1.Controls.Add(icon_expendition_1);
            this.panel_expendition_1.Dock = DockStyle.Top;
            this.panel_expendition_1.Location = new Point(0, 28);
            this.panel_expendition_1.Name = "panel_expendition_1";
            this.panel_expendition_1.Size = new Size(188, 40);
            this.panel_expendition_1.TabIndex = 6;
            this.panel_expendition_1.Visible = false;
            // 
            // label_expendition_1
            // 
            this.label_expendition_1.BackColor = Color.Transparent;
            this.label_expendition_1.Dock = DockStyle.Fill;
            this.label_expendition_1.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            this.label_expendition_1.ForeColor = Color.Transparent;
            this.label_expendition_1.Location = new Point(40, 0);
            this.label_expendition_1.Name = "label_expendition_1";
            this.label_expendition_1.Size = new Size(148, 40);
            this.label_expendition_1.TabIndex = 6;
            this.label_expendition_1.Text = "--:--:--";
            this.label_expendition_1.TextAlign = ContentAlignment.BottomRight;
            this.label_expendition_1.Paint += Label_Paint;
            // 
            // icon_expendition_1
            // 
            icon_expendition_1.Dock = DockStyle.Left;
            icon_expendition_1.Location = new Point(0, 0);
            icon_expendition_1.Name = "icon_expendition_1";
            icon_expendition_1.Size = new Size(40, 40);
            icon_expendition_1.SizeMode = PictureBoxSizeMode.StretchImage;
            icon_expendition_1.TabIndex = 0;
            icon_expendition_1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label_expendition_num);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(188, 28);
            panel3.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.BackColor = Color.Transparent;
            this.label11.Dock = DockStyle.Fill;
            this.label11.Font = new Font("Meiryo UI", 10016F, FontStyle.Bold, GraphicsUnit.Point);
            this.label11.ForeColor = Color.Transparent;
            this.label11.Location = new Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new Size(127, 28);
            this.label11.TabIndex = 4;
            this.label11.Text = "探索派遣";
            this.label11.TextAlign = ContentAlignment.MiddleLeft;
            this.label11.Paint += Label_Paint;
            // 
            // label_expendition_num
            // 
            this.label_expendition_num.BackColor = Color.Transparent;
            this.label_expendition_num.Dock = DockStyle.Right;
            this.label_expendition_num.Font = new Font("Meiryo UI", 10016F, FontStyle.Bold, GraphicsUnit.Point);
            this.label_expendition_num.ForeColor = Color.Transparent;
            this.label_expendition_num.Location = new Point(127, 0);
            this.label_expendition_num.Name = "label_expendition_num";
            this.label_expendition_num.Size = new Size(61, 28);
            this.label_expendition_num.TabIndex = 5;
            this.label_expendition_num.Text = "- / -";
            this.label_expendition_num.TextAlign = ContentAlignment.MiddleRight;
            this.label_expendition_num.Paint += Label_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel_transform);
            panel2.Controls.Add(panel_discountboss);
            panel2.Controls.Add(panel_comission);
            panel2.Controls.Add(panel_homecoin);
            panel2.Controls.Add(panel_resin);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(307, 238);
            panel2.TabIndex = 7;
            // 
            // panel_transform
            // 
            this.panel_transform.BackColor = Color.Transparent;
            this.panel_transform.Controls.Add(label9);
            this.panel_transform.Controls.Add(pictureBox5);
            this.panel_transform.Dock = DockStyle.Top;
            this.panel_transform.Location = new Point(0, 193);
            this.panel_transform.Name = "panel_transform";
            this.panel_transform.Size = new Size(307, 40);
            this.panel_transform.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.BackColor = Color.Transparent;
            this.label9.Dock = DockStyle.Fill;
            this.label9.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            this.label9.ForeColor = Color.Transparent;
            this.label9.Location = new Point(40, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(267, 40);
            this.label9.TabIndex = 5;
            this.label9.Text = "あと ---:--:--";
            this.label9.TextAlign = ContentAlignment.MiddleLeft;
            this.label9.Paint += Label_Paint;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.Dock = DockStyle.Left;
            pictureBox5.Image = resource.icon.Item_Parametric_Transformer;
            pictureBox5.Location = new Point(0, 0);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(40, 40);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            // 
            // panel_discountboss
            // 
            this.panel_discountboss.BackColor = Color.Transparent;
            this.panel_discountboss.Controls.Add(label8);
            this.panel_discountboss.Controls.Add(pictureBox4);
            this.panel_discountboss.Dock = DockStyle.Top;
            this.panel_discountboss.Location = new Point(0, 153);
            this.panel_discountboss.Name = "panel_discountboss";
            this.panel_discountboss.Size = new Size(307, 40);
            this.panel_discountboss.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.BackColor = Color.Transparent;
            this.label8.Dock = DockStyle.Fill;
            this.label8.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            this.label8.ForeColor = Color.Transparent;
            this.label8.Location = new Point(40, 0);
            this.label8.Name = "label8";
            this.label8.Size = new Size(267, 40);
            this.label8.TabIndex = 5;
            this.label8.Text = "-/-";
            this.label8.TextAlign = ContentAlignment.MiddleLeft;
            this.label8.Paint += Label_Paint;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.Dock = DockStyle.Left;
            pictureBox4.Image = resource.icon.UI_Domains;
            pictureBox4.Location = new Point(0, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(40, 40);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            // 
            // panel_homecoin
            // 
            this.panel_homecoin.BackColor = Color.Transparent;
            this.panel_homecoin.Controls.Add(label7);
            this.panel_homecoin.Controls.Add(label6);
            this.panel_homecoin.Controls.Add(label5);
            this.panel_homecoin.Controls.Add(pictureBox3);
            this.panel_homecoin.Dock = DockStyle.Top;
            this.panel_homecoin.Location = new Point(0, 60);
            this.panel_homecoin.Name = "panel_homecoin";
            this.panel_homecoin.Size = new Size(307, 53);
            this.panel_homecoin.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.BackColor = Color.Transparent;
            this.label7.Dock = DockStyle.Fill;
            this.label7.Font = new Font("Meiryo UI", 10012F, FontStyle.Bold, GraphicsUnit.Point);
            this.label7.ForeColor = Color.Transparent;
            this.label7.Location = new Point(193, 0);
            this.label7.Margin = new Padding(5, 0, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(114, 28);
            this.label7.TabIndex = 7;
            this.label7.Text = "残り --:--:--";
            this.label7.TextAlign = ContentAlignment.BottomLeft;
            this.label7.Paint += Label_Paint;
            // 
            // label6
            // 
            this.label6.BackColor = Color.Transparent;
            this.label6.Dock = DockStyle.Bottom;
            this.label6.Font = new Font("Meiryo UI", 10014.25F, FontStyle.Bold, GraphicsUnit.Point);
            this.label6.ForeColor = Color.Transparent;
            this.label6.Location = new Point(193, 28);
            this.label6.Name = "label6";
            this.label6.Size = new Size(114, 25);
            this.label6.TabIndex = 6;
            this.label6.Text = "/----";
            this.label6.TextAlign = ContentAlignment.MiddleLeft;
            this.label6.Paint += Label_Paint;
            // 
            // label5
            // 
            this.label5.BackColor = Color.Transparent;
            this.label5.Dock = DockStyle.Left;
            this.label5.Font = new Font("Meiryo UI", 10032.25F, FontStyle.Bold, GraphicsUnit.Point);
            this.label5.ForeColor = Color.Transparent;
            this.label5.Location = new Point(50, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new Padding(0, 0, 3, 0);
            this.label5.Size = new Size(143, 53);
            this.label5.TabIndex = 5;
            this.label5.Text = "----";
            this.label5.TextAlign = ContentAlignment.MiddleRight;
            this.label5.Paint += Label_Paint;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Dock = DockStyle.Left;
            pictureBox3.Image = resource.icon.Item_Realm_Currency;
            pictureBox3.Location = new Point(0, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(50, 53);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // panel_Error
            // 
            this.panel_Error.BackColor = Color.Transparent;
            this.panel_Error.Controls.Add(button_Auth);
            this.panel_Error.Controls.Add(label_ErrorMessage);
            this.panel_Error.Controls.Add(label10);
            this.panel_Error.Dock = DockStyle.Fill;
            this.panel_Error.Location = new Point(0, 0);
            this.panel_Error.Name = "panel_Error";
            this.panel_Error.Size = new Size(499, 238);
            this.panel_Error.TabIndex = 9;
            // 
            // button_Auth
            // 
            this.button_Auth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.button_Auth.Location = new Point(412, 201);
            this.button_Auth.Name = "button_Auth";
            this.button_Auth.Size = new Size(75, 23);
            this.button_Auth.TabIndex = 2;
            this.button_Auth.Text = "再連携";
            this.button_Auth.UseVisualStyleBackColor = true;
            this.button_Auth.Click += button_Auth_Click;
            // 
            // label_ErrorMessage
            // 
            this.label_ErrorMessage.Dock = DockStyle.Top;
            this.label_ErrorMessage.Font = new Font("Meiryo UI", 10018F, FontStyle.Regular, GraphicsUnit.Point);
            this.label_ErrorMessage.ForeColor = Color.Transparent;
            this.label_ErrorMessage.Location = new Point(0, 57);
            this.label_ErrorMessage.Name = "label_ErrorMessage";
            this.label_ErrorMessage.Size = new Size(499, 128);
            this.label_ErrorMessage.TabIndex = 1;
            this.label_ErrorMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.label_ErrorMessage.Paint += Label_Paint;
            // 
            // label10
            // 
            this.label10.Dock = DockStyle.Top;
            this.label10.Font = new Font("Meiryo UI", 10026.25F, FontStyle.Regular, GraphicsUnit.Point);
            this.label10.ForeColor = Color.Transparent;
            this.label10.Location = new Point(0, 0);
            this.label10.Margin = new Padding(999, 999, 0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new Size(499, 57);
            this.label10.TabIndex = 0;
            this.label10.Text = "データを取得中です...";
            this.label10.TextAlign = ContentAlignment.TopCenter;
            this.label10.Paint += Label_Paint;
            // 
            // RealTimeData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = resource.namecard.Genshin_Impact_A_New_World;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(499, 238);
            Controls.Add(panel_Error);
            Controls.Add(panel_main);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "RealTimeData";
            Text = "リアルタイムノート";
            Load += RealTimeData_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            this.panel_resin.ResumeLayout(false);
            this.panel_comission.ResumeLayout(false);
            this.panel_main.ResumeLayout(false);
            this.panel_expedition.ResumeLayout(false);
            this.panel_expendition_5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_5).EndInit();
            this.panel_expendition_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_4).EndInit();
            this.panel_expendition_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_3).EndInit();
            this.panel_expendition_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_2).EndInit();
            this.panel_expendition_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_1).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            this.panel_transform.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            this.panel_discountboss.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            this.panel_homecoin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            this.panel_Error.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox2;
        private Label label4;
        private System.Windows.Forms.Timer UiUpdate;
        private Panel panel_resin;
        private Panel panel_comission;
        private Panel panel_main;
        private Panel panel2;
        private Panel panel_homecoin;
        private Label label7;
        private Label label6;
        private Label label5;
        private PictureBox pictureBox3;
        private Panel panel_transform;
        private Label label9;
        private PictureBox pictureBox5;
        private Panel panel_discountboss;
        private Label label8;
        private PictureBox pictureBox4;
        private Panel panel_expedition;
        private Panel panel3;
        private Label label11;
        private Panel panel_expendition_1;
        private Label label_expendition_1;
        private PictureBox icon_expendition_1;
        private Label label_expendition_num;
        private Panel panel_expendition_5;
        private Label label_expendition_5;
        private PictureBox icon_expendition_5;
        private Panel panel_expendition_4;
        private Label label_expendition_4;
        private PictureBox icon_expendition_4;
        private Panel panel_expendition_3;
        private Label label_expendition_3;
        private PictureBox icon_expendition_3;
        private Panel panel_expendition_2;
        private Label label_expendition_2;
        private PictureBox icon_expendition_2;
        private Panel panel_Error;
        private Button button_Auth;
        private Label label_ErrorMessage;
        private Label label10;
    }
}