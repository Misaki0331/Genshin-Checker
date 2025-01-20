using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genshin_Checker.Model.HoYoLab.SpiralAbyss;
using Genshin_Checker.Model.UI.GameRecords.Exploration;


namespace Genshin_Checker.UI.Control.GameRecord
{
    public partial class ExplorationLevel : UserControl
    {
        OfferingLevel Level;
        public ExplorationLevel(OfferingLevel level)
        {
            Level = level;
            InitializeComponent();
            LoadData();
        }
        async void LoadData()
        {
            ExContain_LevelIcon1.Image = await Core.WebRequest.ImageGetRequest(Level.Icon);
            ExContain_LevelName1.Text = $"{Level.Name} : {Level.Level}";
        }
    }
}
