using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.CalculatorComputeGet
{
    public class Consume
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public string icon { get; set; } = "";
        public int num { get; set; }
        public string wiki_url { get; set; } = "";
        public int level { get; set; }
        public string icon_url { get; set; } = "";
    }


    public class Data
    {
        public List<Consume> avatar_consume { get; set; } = new();
        public List<Consume> avatar_skill_consume { get; set; } = new();
        public List<Consume> weapon_consume { get; set; } = new();
        public List<Consume> reliquary_consume { get; set; } = new();
    }
    public class Root : Model.HoYoLab.Root<Data>
    {
    }


}
