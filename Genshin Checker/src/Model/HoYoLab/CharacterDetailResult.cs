using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.CharacterDetailResult
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }

    public class Data
    {
        public List<List> list { get; set; }
        public Dictionary<int,PropertyValue> property_map { get; set; }
        public RelicPropertyOptions relic_property_options { get; set; }
        public Dictionary<int,string> relic_wiki { get; set; }
        public Dictionary<int,string> weapon_wiki { get; set; }
        public Dictionary<int,string> avatar_wiki { get; set; }
    }

    
    public class PropertyValue
    {
        public int property_type { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string filter_name { get; set; }
    }

    public class Affix
    {
        public int activation_number { get; set; }
        public string effect { get; set; }
    }

    public class Base
    {
        public int id { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public string element { get; set; }
        public int fetter { get; set; }
        public int level { get; set; }
        public int rarity { get; set; }
        public int actived_constellation_num { get; set; }
        public string image { get; set; }
        public bool is_chosen { get; set; }
        public string side_icon { get; set; }
        public int weapon_type { get; set; }
        public Weapon weapon { get; set; }
    }

    public class BaseProperty
    {
        public int property_type { get; set; }
        public string @base { get; set; }
        public string add { get; set; }
        public string final { get; set; }
    }

    public class Constellation
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public string effect { get; set; }
        public bool is_actived { get; set; }
        public int pos { get; set; }
    }

    public class Costume
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }
    public class ElementProperty
    {
        public int property_type { get; set; }
        public string @base { get; set; }
        public string add { get; set; }
        public string final { get; set; }
    }

    public class ExtraProperty
    {
        public int property_type { get; set; }
        public string @base { get; set; }
        public string add { get; set; }
        public string final { get; set; }
    }

    public class List
    {
        public Base @base { get; set; }
        public Weapon weapon { get; set; }
        public List<Relic> relics { get; set; }
        public List<Constellation> constellations { get; set; }
        public List<Costume> costumes { get; set; }
        public List<SelectedProperty> selected_properties { get; set; }
        public List<BaseProperty> base_properties { get; set; }
        public List<ExtraProperty> extra_properties { get; set; }
        public List<ElementProperty> element_properties { get; set; }
        public List<Skill> skills { get; set; }
        public RecommendRelicProperty recommend_relic_property { get; set; }
    }

    public class MainProperty
    {
        public int property_type { get; set; }
        public string @base { get; set; }
        public string add { get; set; }
        public string final { get; set; }
        public string value { get; set; }
        public int times { get; set; }
    }

    public class RecommendProperties
    {
        public List<int> sand_main_property_list { get; set; }
        public List<int> goblet_main_property_list { get; set; }
        public List<int> circlet_main_property_list { get; set; }
        public List<int> sub_property_list { get; set; }
    }

    public class RecommendRelicProperty
    {
        public RecommendProperties recommend_properties { get; set; }
        public object custom_properties { get; set; }
        public bool has_set_recommend_prop { get; set; }
    }

    public class Relic
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int pos { get; set; }
        public int rarity { get; set; }
        public int level { get; set; }
        public Set set { get; set; }
        public string pos_name { get; set; }
        public MainProperty main_property { get; set; }
        public List<SubPropertyList> sub_property_list { get; set; }
    }

    public class RelicPropertyOptions
    {
        public List<int> sand_main_property_list { get; set; }
        public List<int> goblet_main_property_list { get; set; }
        public List<int> circlet_main_property_list { get; set; }
        public List<int> sub_property_list { get; set; }
    }

    public class SelectedProperty
    {
        public int property_type { get; set; }
        public string @base { get; set; }
        public string add { get; set; }
        public string final { get; set; }
    }

    public class Set
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Affix> affixes { get; set; }
    }

    public class Skill
    {
        public int skill_id { get; set; }
        public int skill_type { get; set; }
        public int level { get; set; }
        public string desc { get; set; }
        public List<SkillAffixList> skill_affix_list { get; set; }
        public string icon { get; set; }
        public bool is_unlock { get; set; }
        public string name { get; set; }
    }

    public class SkillAffixList
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class SubProperty
    {
        public int property_type { get; set; }
        public string @base { get; set; }
        public string add { get; set; }
        public string final { get; set; }
    }

    public class SubPropertyList
    {
        public int property_type { get; set; }
        public string value { get; set; }
        public int times { get; set; }
    }

    public class Weapon
    {
        public int id { get; set; }
        public string icon { get; set; }
        public int type { get; set; }
        public int rarity { get; set; }
        public int level { get; set; }
        public int affix_level { get; set; }
        public string name { get; set; }
        public int promote_level { get; set; }
        public string type_name { get; set; }
        public string desc { get; set; }
        public MainProperty main_property { get; set; }
        public SubProperty sub_property { get; set; }
    }


}
