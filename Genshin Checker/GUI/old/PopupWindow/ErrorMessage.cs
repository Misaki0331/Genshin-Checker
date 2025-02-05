using Genshin_Checker.resource.Languages;

namespace Genshin_Checker.Window.Popup
{
    [Obsolete("このウィンドウは廃止予定です。WPF版に移行してください。")]
    public partial class ErrorMessage : Form
    {
        public ErrorMessage(string title,string message,string? windowtitle=null)
        {
            InitializeComponent();
            windowtitle ??= Common.ErrorMessage;
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
