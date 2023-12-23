namespace Genshin_Checker.Window.Popup
{
    public partial class ChooseMessage : Form
    {
        public ChooseMessage(string title,string message,string windowtitle="情報",int selectcount=2,string select1="いいえ",string select2="はい",string select3="キャンセル",string select4="",string select5="")
        {
            InitializeComponent();
            Text = windowtitle;
            label1.Text = title;
            textBox1.Text = message.Replace("\r\n","\n").Replace("\n",Environment.NewLine);
            pictureBox1.Image = resource.PaimonsPaint.Furina_1;
            button1.Text = select1;
            button2.Text = select2;
            button3.Text = select3;
            button4.Text = select4;
            button5.Text = select5;
            var buttons = new List<Button>() { button1, button2, button3, button4, button5 };
            for(int i=0;i<buttons.Count;i++)
            {
                if (selectcount > i) buttons[i].Visible = true;
                else buttons[i].Visible = false;
            }
            Icon = Icon.FromHandle(new Bitmap(pictureBox1.Image).GetHicon());
        }
        public int Result = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            Result = 0;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Result = 1;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Result = 2;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Result = 3;
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Result = 4;
            Close();
        }

        private void ChooseMessage_Load(object sender, EventArgs e)
        {
            button1.Select();
        }
    }
}
