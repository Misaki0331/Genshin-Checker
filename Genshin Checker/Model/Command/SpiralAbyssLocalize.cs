using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.Command.SpiralAbyssLocalize
{
    public class Root
    {
        public int ID { get; set; }
        public List<Floor> Floors { get; set; } = new();
    }
    public class Floor
    {
        public int Index { get; set; }
        public List<Level> Levels { get; set; } = new();
    }
    public class Level
    {
        public int Index { get; set; }
        public List<Battle> Battles { get; set; } = new();
    }
    public class Battle {
        public int Index { get; set; }
        public List<EnemyInfo> Enemies { get; set; } = new();
    }
    public class EnemyInfo
    {
        public Dictionary<string, string> LocalizeName { get; set; } = new();
        public int Level { get; set; }
        public string ImageSource { get; set; } = "";
    }
}
