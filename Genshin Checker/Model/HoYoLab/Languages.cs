using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab
{
    public class Languages : Root<Data>
    {
    }
    public class Data
    {
        public List<Lang> langs { get; set; } = new();
    }

    public class Lang
    {
        public string name { get; set; } = "";
        public string value { get; set; } = "";
        public string label { get; set; } = "";
        public List<string> alias { get; set; } = new();
    }

}
