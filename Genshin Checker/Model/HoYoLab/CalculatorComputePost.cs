using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.CalculatorComputePost
{
    public class Root
    {
        public int avatar_id { get; set; }
        public int avatar_level_current { get; set; }
        public int avatar_level_target { get; set; }
        public int element_attr_id { get; set; }
        public List<SkillList> skill_list { get; set; } = new();
        public Weapon weapon { get; set; } = new();
        public List<object> reliquary_list { get; set; } = new();
        public string lang { get; set; } = CultureInfo.CurrentUICulture.Name.ToLower();
    }

    public class SkillList
    {
        public int id { get; set; }
        public int level_current { get; set; }
        public int level_target { get; set; }
    }

    public class Weapon
    {
    }

}
