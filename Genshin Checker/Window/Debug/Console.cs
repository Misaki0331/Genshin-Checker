using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            OutputText.AppendText(e);
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
    }
}
