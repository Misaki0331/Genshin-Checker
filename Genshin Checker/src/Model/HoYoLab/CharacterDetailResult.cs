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
        public List<Character> list { get; set; } = new();
        /// <summary>
        /// プロパティタイプの情報
        /// </summary>
        public Dictionary<int, PropertyValue> property_map { get; set; } = new();
        /// <summary>
        /// 聖遺物の付与されるオプションの情報
        /// </summary>
        public RelicProperty relic_property_options { get; set; } = new();
        /// <summary>
        /// 聖遺物のHoYoLab Wiki
        /// </summary>
        public Dictionary<int, string> relic_wiki { get; set; } = new();
        /// <summary>
        /// 武器のHoYoLab Wiki
        /// </summary>
        public Dictionary<int, string> weapon_wiki { get; set; } = new();
        /// <summary>
        /// キャラクターのHoYoLab Wiki
        /// </summary>
        public Dictionary<int, string> avatar_wiki { get; set; } = new();
    }

    
    public class PropertyValue
    {
        /// <summary>
        /// プロパティID
        /// </summary>
        public int property_type { get; set; }
        /// <summary>
        /// プロパティ名
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// プロパティアイコン<br/>
        /// (プロパティ画像が無いものもある)
        /// </summary>
        public string icon { get; set; } = "";
        /// <summary>
        /// フィルター用のプロパティ名(完全表示が多い)
        /// </summary>
        public string filter_name { get; set; } = "";
    }
    /// <summary>
    /// 聖遺物のセット効果発動情報
    /// </summary>
    public class Affix
    {
        /// <summary>
        /// 聖遺物効果の発動条件(トリガーする同じ聖遺物の数)
        /// </summary>
        public int activation_number { get; set; }
        /// <summary>
        /// 聖遺物効果の内容
        /// </summary>
        public string effect { get; set; } = "";
    }
    /// <summary>
    /// キャラクターの所持情報
    /// </summary>
    public class Base
    {
        /// <summary>
        /// キャラクターID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// キャラクターのアイコンURL
        /// </summary>
        public string icon { get; set; } = "";
        /// <summary>
        /// キャラクターの名前
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// キャラクターの元素
        /// </summary>
        public string element { get; set; } = "";
        /// <summary>
        /// 好感度レベル
        /// </summary>
        public int fetter { get; set; }
        /// <summary>
        /// キャラクターレベル
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// レアリティ
        /// </summary>
        public int rarity { get; set; }
        /// <summary>
        /// 命ノ星座開放情報
        /// </summary>
        public int actived_constellation_num { get; set; }
        /// <summary>
        /// 透過済みのガチャ画像(下半身が透けてる)
        /// </summary>
        public string image { get; set; } = "";
        /// <summary>
        /// ToDo: 謎プロパティ
        /// </summary>
        public bool is_chosen { get; set; }
        /// <summary>
        /// 右から見た顔の画像
        /// </summary>
        public string side_icon { get; set; } = "";
        /// <summary>
        /// 武器種(数値)
        /// </summary>
        public int weapon_type { get; set; }
        /// <summary>
        /// 所持している武器情報
        /// </summary>
        public Weapon weapon { get; set; } = new();
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

    public class Character
    {

        [JsonProperty("base")]
        public Base baseInfo { get; set; }
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
    public class RelicProperty
    {
        public List<int> sand_main_property_list { get; set; }
        public List<int> goblet_main_property_list { get; set; }
        public List<int> circlet_main_property_list { get; set; }
        public List<int> sub_property_list { get; set; }
    }

    public class RecommendRelicProperty
    {
        public RelicProperty? recommend_properties { get; set; }
        /// <summary>
        /// ToDo:
        /// カスタムプロパティ？(nullの為要検証)
        /// </summary>
        public RelicProperty? custom_properties { get; set; }
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
