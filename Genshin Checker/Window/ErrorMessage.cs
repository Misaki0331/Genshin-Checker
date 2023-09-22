using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window
{
    public partial class ErrorMessage : Form
    {
        public ErrorMessage(string title,string message,string windowtitle="エラーメッセージ")
        {
            InitializeComponent();
            Text = windowtitle;
            label1.Text = title;
            label2.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
