using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.UI.Control.GameRecord
{
    internal class SplitedPanel
    {
        public SplitedPanel()
        {

        }
        class Labels
        {
            public Labels(string name,Panel panel,Label title,Label value)
            {
                Name = name;
                Panel = panel;
                Title = title;
                Value = value;
            }
            public string Name;
            Panel Panel;
            Label Title;
            Label Value;
        }
        TableLayoutPanel Table;
        Panel ParentPanel;

        List<Panel> panels;
        Dictionary<Label,Label> labels;
        
        Dictionary<string, string> Strings;
    }
}
