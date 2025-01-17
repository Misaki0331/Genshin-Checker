using Genshin_Checker.resource.Languages;
using Genshin_Checker.Window.Popup;

namespace Genshin_Checker.GUI.old.PopupWindow
{
    [Obsolete("このウィンドウは廃止予定です。WPF版に移行してください。")]
    public partial class InfoMessage : ErrorMessage
    {
        public InfoMessage(string title, string message, string? windowtitle = null) : base(title, message, windowtitle)
        {
            windowtitle ??= Common.InfoMessage;
            Text = windowtitle;
            label1.Text = title;
            textBox1.Text = message.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            pictureBox1.Image = resource.PaimonsPaint.Furina_3;
            Icon = Icon.FromHandle(new Bitmap(pictureBox1.Image).GetHicon());
        }

    }
}
