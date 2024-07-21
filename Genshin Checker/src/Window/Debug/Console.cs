using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Genshin_Checker.Window.Debug
{
    public partial class Console : Form
    {
        public Console()
        {
            InitializeComponent();
            App.Command.CommandManager.ConsoleOut += CommandManager_ConsoleOut;
        }

        private void CommandManager_ConsoleOut(object? sender, string e)
        {
            OutputText.AppendText($"{e}{Environment.NewLine}");
        }

        private void Execution_Click(object sender, EventArgs e)
        {
            var input = InputText.Text.Trim();
            InputText.Clear();
            App.Command.CommandManager.RunCommand(input);
        }

        private void Console_FormClosed(object sender, FormClosedEventArgs e)
        {
            App.Command.CommandManager.ConsoleOut -= CommandManager_ConsoleOut;
        }

        private void InputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Execution_Click("", EventArgs.Empty);
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }
    }
}
