namespace Genshin_Checker.Window.Popup
{
    public partial class ChooseMessage : Form
    {
        public ChooseMessage(string title,string message,string windowtitle="エラーメッセージ")
        {
            InitializeComponent();
            Text = windowtitle;
            label1.Text = title;
            textBox1.Text = message.Replace("\r\n","\n").Replace("\n",Environment.NewLine);
            pictureBox1.Image = resource.PaimonsPaint.Furina_2;

            Icon = Icon.FromHandle(new Bitmap(pictureBox1.Image).GetHicon());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
