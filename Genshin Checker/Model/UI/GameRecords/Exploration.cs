using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UI.GameRecords.Exploration
{
    public class Root
    {
        public int ID { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public List<OfferingLevel> Levels { get; set; } = new();
        public Images Images { get; set; } = new();
        public List<Progress> Progress { get; set; } = new();
        public Oculus? Oculus { get; set; } = null;
        public List<Progress> AreaDetailProgress { get; set; } = new();
        public bool IsDetailEnabled { get; set; } = false;

    }
    public class Images
    {
        public string Icon { get; set; } = string.Empty;
    }
    public class OfferingLevel
    {
        public string Icon { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; } = 0;
    }
    public class Progress
    {
        public string Name { get; set; } = string.Empty;
        public double Value { get; set; } = 0;
        public bool IsVisible { get; set; } = false;
    }
    public class Oculus
    {
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
    }
}
