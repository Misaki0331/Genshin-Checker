using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genshin_Checker.Model.UI.GameRecords.Exploration;

namespace Genshin_Checker.UI.Control.GameRecord
{
    public partial class ExplorationProgressBar : UserControl
    {
        Progress Progress;
        public ExplorationProgressBar(Progress progress)
        {
            Progress = progress;
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            if (string.IsNullOrEmpty(Progress.Name)) ExContain_HiddenableName1.Visible = false;
            else
            {
                ExContain_HiddenableName1.Visible = true;
                ExContain_HiddenableName1.Text = Progress.Name;
            }
            ExContain_ProgressBar1.Value = (int)(Progress.Value > 1000 ? 1000 : Progress.Value < 0 ? 0 : Progress.Value * 10.0);
            ExContain_ProgressLabel1.Text = $"{Progress.Value:0.0}%";
        }
    }
}
