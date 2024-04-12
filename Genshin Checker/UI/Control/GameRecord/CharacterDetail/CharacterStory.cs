using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.UI.Control.GameRecord.CharacterDetail
{
    public partial class CharacterStory : UserControl
    {
        string title;
        string? description;
        string index;
        public CharacterStory(string title, string? description, string index)
        {
            InitializeComponent();
            label3.MaximumSize = new(this.ClientSize.Width, 32767);
            this.title = title;
            this.description = description;
            this.index = index+"\n ";
        }

        private void CharacterStory_SizeChanged(object sender, EventArgs e)
        {
            label3.MaximumSize = new(this.ClientSize.Width, 32767);
        }

        private void CharacterStory_Load(object sender, EventArgs e)
        {
            label2.Text = title;
            if (description != null) label1.Text = description;
            else label1.Visible = false;
            label3.Text = index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.Visible)
            {
                button1.Text = "▼";
            }
            else
            {
                button1.Text = "▲";
            }
            label3.Visible = !label3.Visible;
        }
    }
}
