using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.CharacterDetail
{


    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class Data
    {
        public List<SkillList> skill_list { get; set; }
        public Weapon weapon { get; set; }
        public List<ReliquaryList> reliquary_list { get; set; }
    }

    public class ReliquaryList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int reliquary_cat_id { get; set; }
        public int reliquary_level { get; set; }
        public int level_current { get; set; }
        public int max_level { get; set; }
    }


    public class SkillList
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int max_level { get; set; }
        public int level_current { get; set; }
    }

    public class Weapon
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int weapon_cat_id { get; set; }
        public int weapon_level { get; set; }
        public int max_level { get; set; }
        public int level_current { get; set; }
    }


}
