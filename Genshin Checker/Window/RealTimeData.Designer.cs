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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            label4 = new Label();
            UiUpdate = new System.Windows.Forms.Timer(components);
            panel_resin = new Panel();
            panel_comission = new Panel();
            panel_main = new Panel();
            panel_expedition = new Panel();
            panel_expendition_5 = new Panel();
            label_expendition_5 = new Label();
            icon_expendition_5 = new PictureBox();
            panel_expendition_4 = new Panel();
            label_expendition_4 = new Label();
            icon_expendition_4 = new PictureBox();
            panel_expendition_3 = new Panel();
            label_expendition_3 = new Label();
            icon_expendition_3 = new PictureBox();
            panel_expendition_2 = new Panel();
            label_expendition_2 = new Label();
            icon_expendition_2 = new PictureBox();
            panel_expendition_1 = new Panel();
            label_expendition_1 = new Label();
            icon_expendition_1 = new PictureBox();
            panel3 = new Panel();
            label11 = new Label();
            label_expendition_num = new Label();
            panel2 = new Panel();
            panel_transform = new Panel();
            label9 = new Label();
            pictureBox5 = new PictureBox();
            panel_discountboss = new Panel();
            label8 = new Label();
            pictureBox4 = new PictureBox();
            panel_homecoin = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            pictureBox3 = new PictureBox();
            panel_Error = new Panel();
            button_Auth = new Button();
            label_ErrorMessage = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel_resin.SuspendLayout();
            panel_comission.SuspendLayout();
            panel_main.SuspendLayout();
            panel_expedition.SuspendLayout();
            panel_expendition_5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_5).BeginInit();
            panel_expendition_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_4).BeginInit();
            panel_expendition_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_3).BeginInit();
            panel_expendition_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_2).BeginInit();
            panel_expendition_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)icon_expendition_1).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel_transform.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel_discountboss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel_homecoin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel_Error.SuspendLayout();
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
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Meiryo UI", 10036F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(60, 0);
            label1.Name = "label1";
            label1.Size = new Size(133, 60);
            label1.TabIndex = 1;
            label1.Text = "---";
            label1.TextAlign = ContentAlignment.BottomRight;
            label1.Click += label1_Click;
            label1.Paint += Label_Paint;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Dock = DockStyle.Bottom;
            label2.Font = new Font("Meiryo UI", 10018F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Transparent;
            label2.Location = new Point(193, 26);
            label2.Name = "label2";
            label2.Size = new Size(120, 34);
            label2.TabIndex = 2;
            label2.Text = "/---";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Paint += Label_Paint;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Meiryo UI", 10012F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Transparent;
            label3.Location = new Point(193, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 26);
            label3.TabIndex = 3;
            label3.Text = "残り --:--:--";
            label3.TextAlign = ContentAlignment.BottomLeft;
            label3.Paint += Label_Paint;
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
            label4.BackColor = Color.Transparent;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(40, 0);
            label4.Name = "label4";
            label4.Size = new Size(273, 40);
            label4.TabIndex = 5;
            label4.Text = "-/-";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.Click += label4_Click;
            label4.Paint += Label_Paint;
            // 
            // UiUpdate
            // 
            UiUpdate.Enabled = true;
            UiUpdate.Tick += UiUpdate_Tick;
            // 
            // panel_resin
            // 
            panel_resin.BackColor = Color.Transparent;
            panel_resin.Controls.Add(label3);
            panel_resin.Controls.Add(label2);
            panel_resin.Controls.Add(label1);
            panel_resin.Controls.Add(pictureBox1);
            panel_resin.Dock = DockStyle.Top;
            panel_resin.Location = new Point(0, 0);
            panel_resin.Name = "panel_resin";
            panel_resin.Size = new Size(313, 60);
            panel_resin.TabIndex = 6;
            // 
            // panel_comission
            // 
            panel_comission.BackColor = Color.Transparent;
            panel_comission.Controls.Add(label4);
            panel_comission.Controls.Add(pictureBox2);
            panel_comission.Dock = DockStyle.Top;
            panel_comission.Location = new Point(0, 113);
            panel_comission.Name = "panel_comission";
            panel_comission.Size = new Size(313, 40);
            panel_comission.TabIndex = 4;
            // 
            // panel_main
            // 
            panel_main.BackColor = Color.Transparent;
            panel_main.Controls.Add(panel_expedition);
            panel_main.Controls.Add(panel2);
            panel_main.Dock = DockStyle.Fill;
            panel_main.Location = new Point(0, 0);
            panel_main.Name = "panel_main";
            panel_main.Size = new Size(499, 238);
            panel_main.TabIndex = 7;
            panel_main.Paint += panel1_Paint;
            // 
            // panel_expedition
            // 
            panel_expedition.Controls.Add(panel_expendition_5);
            panel_expedition.Controls.Add(panel_expendition_4);
            panel_expedition.Controls.Add(panel_expendition_3);
            panel_expedition.Controls.Add(panel_expendition_2);
            panel_expedition.Controls.Add(panel_expendition_1);
            panel_expedition.Controls.Add(panel3);
            panel_expedition.Dock = DockStyle.Fill;
            panel_expedition.Location = new Point(313, 0);
            panel_expedition.Name = "panel_expedition";
            panel_expedition.Padding = new Padding(0, 0, 4, 0);
            panel_expedition.Size = new Size(186, 238);
            panel_expedition.TabIndex = 8;
            // 
            // panel_expendition_5
            // 
            panel_expendition_5.Controls.Add(label_expendition_5);
            panel_expendition_5.Controls.Add(icon_expendition_5);
            panel_expendition_5.Dock = DockStyle.Top;
            panel_expendition_5.Location = new Point(0, 188);
            panel_expendition_5.Name = "panel_expendition_5";
            panel_expendition_5.Size = new Size(182, 40);
            panel_expendition_5.TabIndex = 10;
            panel_expendition_5.Visible = false;
            // 
            // label_expendition_5
            // 
            label_expendition_5.BackColor = Color.Transparent;
            label_expendition_5.Dock = DockStyle.Fill;
            label_expendition_5.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            label_expendition_5.ForeColor = Color.Transparent;
            label_expendition_5.Location = new Point(40, 0);
            label_expendition_5.Name = "label_expendition_5";
            label_expendition_5.Size = new Size(142, 40);
            label_expendition_5.TabIndex = 6;
            label_expendition_5.Text = "--:--:--";
            label_expendition_5.TextAlign = ContentAlignment.BottomRight;
            label_expendition_5.Paint += Label_Paint;
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
            panel_expendition_4.Controls.Add(label_expendition_4);
            panel_expendition_4.Controls.Add(icon_expendition_4);
            panel_expendition_4.Dock = DockStyle.Top;
            panel_expendition_4.Location = new Point(0, 148);
            panel_expendition_4.Name = "panel_expendition_4";
            panel_expendition_4.Size = new Size(182, 40);
            panel_expendition_4.TabIndex = 9;
            panel_expendition_4.Visible = false;
            // 
            // label_expendition_4
            // 
            label_expendition_4.BackColor = Color.Transparent;
            label_expendition_4.Dock = DockStyle.Fill;
            label_expendition_4.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            label_expendition_4.ForeColor = Color.Transparent;
            label_expendition_4.Location = new Point(40, 0);
            label_expendition_4.Name = "label_expendition_4";
            label_expendition_4.Size = new Size(142, 40);
            label_expendition_4.TabIndex = 6;
            label_expendition_4.Text = "--:--:--";
            label_expendition_4.TextAlign = ContentAlignment.BottomRight;
            label_expendition_4.Paint += Label_Paint;
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
            panel_expendition_3.Controls.Add(label_expendition_3);
            panel_expendition_3.Controls.Add(icon_expendition_3);
            panel_expendition_3.Dock = DockStyle.Top;
            panel_expendition_3.Location = new Point(0, 108);
            panel_expendition_3.Name = "panel_expendition_3";
            panel_expendition_3.Size = new Size(182, 40);
            panel_expendition_3.TabIndex = 8;
            panel_expendition_3.Visible = false;
            // 
            // label_expendition_3
            // 
            label_expendition_3.BackColor = Color.Transparent;
            label_expendition_3.Dock = DockStyle.Fill;
            label_expendition_3.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            label_expendition_3.ForeColor = Color.Transparent;
            label_expendition_3.Location = new Point(40, 0);
            label_expendition_3.Name = "label_expendition_3";
            label_expendition_3.Size = new Size(142, 40);
            label_expendition_3.TabIndex = 6;
            label_expendition_3.Text = "--:--:--";
            label_expendition_3.TextAlign = ContentAlignment.BottomRight;
            label_expendition_3.Paint += Label_Paint;
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
            panel_expendition_2.Controls.Add(label_expendition_2);
            panel_expendition_2.Controls.Add(icon_expendition_2);
            panel_expendition_2.Dock = DockStyle.Top;
            panel_expendition_2.Location = new Point(0, 68);
            panel_expendition_2.Name = "panel_expendition_2";
            panel_expendition_2.Size = new Size(182, 40);
            panel_expendition_2.TabIndex = 7;
            panel_expendition_2.Visible = false;
            // 
            // label_expendition_2
            // 
            label_expendition_2.BackColor = Color.Transparent;
            label_expendition_2.Dock = DockStyle.Fill;
            label_expendition_2.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            label_expendition_2.ForeColor = Color.Transparent;
            label_expendition_2.Location = new Point(40, 0);
            label_expendition_2.Name = "label_expendition_2";
            label_expendition_2.Size = new Size(142, 40);
            label_expendition_2.TabIndex = 6;
            label_expendition_2.Text = "--:--:--";
            label_expendition_2.TextAlign = ContentAlignment.BottomRight;
            label_expendition_2.Paint += Label_Paint;
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
            panel_expendition_1.Controls.Add(label_expendition_1);
            panel_expendition_1.Controls.Add(icon_expendition_1);
            panel_expendition_1.Dock = DockStyle.Top;
            panel_expendition_1.Location = new Point(0, 28);
            panel_expendition_1.Name = "panel_expendition_1";
            panel_expendition_1.Size = new Size(182, 40);
            panel_expendition_1.TabIndex = 6;
            panel_expendition_1.Visible = false;
            // 
            // label_expendition_1
            // 
            label_expendition_1.BackColor = Color.Transparent;
            label_expendition_1.Dock = DockStyle.Fill;
            label_expendition_1.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            label_expendition_1.ForeColor = Color.Transparent;
            label_expendition_1.Location = new Point(40, 0);
            label_expendition_1.Name = "label_expendition_1";
            label_expendition_1.Size = new Size(142, 40);
            label_expendition_1.TabIndex = 6;
            label_expendition_1.Text = "--:--:--";
            label_expendition_1.TextAlign = ContentAlignment.BottomRight;
            label_expendition_1.Paint += Label_Paint;
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
            panel3.Size = new Size(182, 28);
            panel3.TabIndex = 5;
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.Dock = DockStyle.Fill;
            label11.Font = new Font("Meiryo UI", 10012F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.Transparent;
            label11.Location = new Point(0, 0);
            label11.Name = "label11";
            label11.Size = new Size(121, 28);
            label11.TabIndex = 4;
            label11.Text = "探索派遣";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            label11.Paint += Label_Paint;
            // 
            // label_expendition_num
            // 
            label_expendition_num.BackColor = Color.Transparent;
            label_expendition_num.Dock = DockStyle.Right;
            label_expendition_num.Font = new Font("Meiryo UI", 10012F, FontStyle.Bold, GraphicsUnit.Point);
            label_expendition_num.ForeColor = Color.Transparent;
            label_expendition_num.Location = new Point(121, 0);
            label_expendition_num.Name = "label_expendition_num";
            label_expendition_num.Size = new Size(61, 28);
            label_expendition_num.TabIndex = 5;
            label_expendition_num.Text = "- / -";
            label_expendition_num.TextAlign = ContentAlignment.MiddleRight;
            label_expendition_num.Paint += Label_Paint;
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
            panel2.Size = new Size(313, 238);
            panel2.TabIndex = 7;
            // 
            // panel_transform
            // 
            panel_transform.BackColor = Color.Transparent;
            panel_transform.Controls.Add(label9);
            panel_transform.Controls.Add(pictureBox5);
            panel_transform.Dock = DockStyle.Top;
            panel_transform.Location = new Point(0, 193);
            panel_transform.Name = "panel_transform";
            panel_transform.Size = new Size(313, 40);
            panel_transform.TabIndex = 9;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Transparent;
            label9.Location = new Point(40, 0);
            label9.Name = "label9";
            label9.Size = new Size(273, 40);
            label9.TabIndex = 5;
            label9.Text = "あと ---:--:--";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            label9.Paint += Label_Paint;
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
            panel_discountboss.BackColor = Color.Transparent;
            panel_discountboss.Controls.Add(label8);
            panel_discountboss.Controls.Add(pictureBox4);
            panel_discountboss.Dock = DockStyle.Top;
            panel_discountboss.Location = new Point(0, 153);
            panel_discountboss.Name = "panel_discountboss";
            panel_discountboss.Size = new Size(313, 40);
            panel_discountboss.TabIndex = 8;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Meiryo UI", 10024F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Transparent;
            label8.Location = new Point(40, 0);
            label8.Name = "label8";
            label8.Size = new Size(273, 40);
            label8.TabIndex = 5;
            label8.Text = "-/-";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Paint += Label_Paint;
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
            panel_homecoin.BackColor = Color.Transparent;
            panel_homecoin.Controls.Add(label7);
            panel_homecoin.Controls.Add(label6);
            panel_homecoin.Controls.Add(label5);
            panel_homecoin.Controls.Add(pictureBox3);
            panel_homecoin.Dock = DockStyle.Top;
            panel_homecoin.Location = new Point(0, 60);
            panel_homecoin.Name = "panel_homecoin";
            panel_homecoin.Size = new Size(313, 53);
            panel_homecoin.TabIndex = 7;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Meiryo UI", 10012F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Transparent;
            label7.Location = new Point(193, 0);
            label7.Name = "label7";
            label7.Size = new Size(120, 28);
            label7.TabIndex = 7;
            label7.Text = "残り --:--:--";
            label7.TextAlign = ContentAlignment.BottomLeft;
            label7.Paint += Label_Paint;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Dock = DockStyle.Bottom;
            label6.Font = new Font("Meiryo UI", 10014.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Transparent;
            label6.Location = new Point(193, 28);
            label6.Name = "label6";
            label6.Size = new Size(120, 25);
            label6.TabIndex = 6;
            label6.Text = "/----";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Paint += Label_Paint;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Dock = DockStyle.Left;
            label5.Font = new Font("Meiryo UI", 10032.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Transparent;
            label5.Location = new Point(50, 0);
            label5.Name = "label5";
            label5.Size = new Size(143, 53);
            label5.TabIndex = 5;
            label5.Text = "----";
            label5.TextAlign = ContentAlignment.MiddleRight;
            label5.Paint += Label_Paint;
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
            panel_Error.BackColor = Color.Transparent;
            panel_Error.Controls.Add(button_Auth);
            panel_Error.Controls.Add(label_ErrorMessage);
            panel_Error.Controls.Add(label10);
            panel_Error.Dock = DockStyle.Fill;
            panel_Error.Location = new Point(0, 0);
            panel_Error.Name = "panel_Error";
            panel_Error.Size = new Size(499, 238);
            panel_Error.TabIndex = 9;
            // 
            // button_Auth
            // 
            button_Auth.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Auth.Location = new Point(412, 201);
            button_Auth.Name = "button_Auth";
            button_Auth.Size = new Size(75, 23);
            button_Auth.TabIndex = 2;
            button_Auth.Text = "再連携";
            button_Auth.UseVisualStyleBackColor = true;
            button_Auth.Click += button_Auth_Click;
            // 
            // label_ErrorMessage
            // 
            label_ErrorMessage.Dock = DockStyle.Top;
            label_ErrorMessage.Font = new Font("Meiryo UI", 10018F, FontStyle.Regular, GraphicsUnit.Point);
            label_ErrorMessage.ForeColor = Color.Transparent;
            label_ErrorMessage.Location = new Point(0, 57);
            label_ErrorMessage.Name = "label_ErrorMessage";
            label_ErrorMessage.Size = new Size(499, 128);
            label_ErrorMessage.TabIndex = 1;
            label_ErrorMessage.TextAlign = ContentAlignment.MiddleCenter;
            label_ErrorMessage.Paint += Label_Paint;
            // 
            // label10
            // 
            label10.Dock = DockStyle.Top;
            label10.Font = new Font("Meiryo UI", 10026.25F, FontStyle.Regular, GraphicsUnit.Point);
            label10.ForeColor = Color.Transparent;
            label10.Location = new Point(0, 0);
            label10.Margin = new Padding(999, 999, 0, 0);
            label10.Name = "label10";
            label10.Size = new Size(499, 57);
            label10.TabIndex = 0;
            label10.Text = "データを取得中です...";
            label10.TextAlign = ContentAlignment.TopCenter;
            label10.Paint += Label_Paint;
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
            panel_resin.ResumeLayout(false);
            panel_comission.ResumeLayout(false);
            panel_main.ResumeLayout(false);
            panel_expedition.ResumeLayout(false);
            panel_expendition_5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_5).EndInit();
            panel_expendition_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_4).EndInit();
            panel_expendition_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_3).EndInit();
            panel_expendition_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_2).EndInit();
            panel_expendition_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)icon_expendition_1).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel_transform.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel_discountboss.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel_homecoin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel_Error.ResumeLayout(false);
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