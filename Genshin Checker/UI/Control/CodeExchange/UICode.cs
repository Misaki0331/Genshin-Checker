using Genshin_Checker.resource.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.UI.Control.CodeExchange
{
    public partial class UICode : UserControl
    {
        public event EventHandler<string>? UiCodeClicked;
        public UICode(string code,DateTime ExpairTime)
        {
            InitializeComponent();
            button1.Text = code;
            label1.Text = $"{Common.ExpairTime} : {ExpairTime}";
            if (string.IsNullOrEmpty(code)) button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UiCodeClicked?.Invoke(this, button1.Text);
        }
    }
}
