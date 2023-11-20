using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*-----------------------------------------------------------------------------+
| 機能名 : 原神戦績                                                            |
| APIの仕様 : 戦績の一般データを取得                                           |
| 利用可能端末 : HoYoLabモバイル / モバイルブラウザ / PCブラウザ               |
| URL : https://bbs-api-os.hoyolab.com/game_record/genshin/api/index           |
| パラメーター :                                                               |
|   server: [String] アカウントのサーバー、アジア圏の場合は「os_asia」         |
|   role_id: [Number] ゲーム内UID アジア圏なら8から始まる9桁 例: 「800000000」 |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab.GameRecords
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }

    #region HoYoLabマップリンク(未使用)

    public class FieldExtMap_Link
    {
        [JsonProperty("link")]
        public string link { get; set; } = string.Empty;

        [JsonProperty("backup_link")]
        public string backup_link { get; set; } = string.Empty;
    }
    #endregion
    public class AreaExplorationList
    {
        [JsonProperty("name")]
        public string name { get; set; } = string.Empty;

        [JsonProperty("exploration_percentage")]
        public int exploration_percentage { get; set; }
    }

    public class Avatar
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("image")]
        public string image { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string name { get; set; } = string.Empty;

        [JsonProperty("element")]
        public string element { get; set; } = string.Empty;

        [JsonProperty("fetter")]
        public int fetter { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("rarity")]
        public int rarity { get; set; }

        [JsonProperty("actived_constellation_num")]
        public int actived_constellation_num { get; set; }

        [JsonProperty("card_image")]
        public string card_image { get; set; } = string.Empty;

        [JsonProperty("is_chosen")]
        public bool is_chosen { get; set; }
    }

    public class BossList
    {
        [JsonProperty("name")]
        public string name { get; set; } = string.Empty;

        [JsonProperty("kill_num")]
        public int kill_num { get; set; }
    }
    public class Data
    {
        [JsonProperty("role")]
        public Role role { get; set; } = new();

        [JsonProperty("avatars")]
        public List<Avatar> avatars { get; set; } = new();

        [JsonProperty("stats")]
        public Stats stats { get; set; } = new();

        [JsonProperty("city_explorations")]
        public List<object> city_explorations { get; set; } = new();

        [JsonProperty("world_explorations")]
        public List<WorldExploration> world_explorations { get; set; } = new();

        [JsonProperty("homes")]
        public List<Home> homes { get; set; } = new();

        [JsonProperty("query_tool_link")]
        public string query_tool_link { get; set; } = string.Empty;

        [JsonProperty("query_tool_image")]
        public string query_tool_image { get; set; } = string.Empty;
    }
    public class Home
    {
        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("visit_num")]
        public int visit_num { get; set; }

        [JsonProperty("comfort_num")]
        public int comfort_num { get; set; }

        [JsonProperty("item_num")]
        public int item_num { get; set; }

        [JsonProperty("name")]
        public string name { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string icon { get; set; } = string.Empty;

        [JsonProperty("comfort_level_name")]
        public string comfort_level_name { get; set; } = string.Empty;

        [JsonProperty("comfort_level_icon")]
        public string comfort_level_icon { get; set; } = string.Empty;
    }


    public class Offering
    {
        [JsonProperty("name")]
        public string name { get; set; } = string.Empty;

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("icon")]
        public string icon { get; set; } = string.Empty;
    }

    public class Role
    {
        [JsonProperty("AvatarUrl")]
        public string AvatarUrl { get; set; } = string.Empty;

        [JsonProperty("nickname")]
        public string nickname { get; set; } = string.Empty;

        [JsonProperty("region")]
        public string region { get; set; } = string.Empty;

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("game_head_icon")]
        public string game_head_icon { get; set; } = string.Empty;
    }

    public class Stats
    {
        [JsonProperty("active_day_number")]
        public int ActiveDay { get; set; }

        [JsonProperty("achievement_number")]
        public int Achievement { get; set; }

        [JsonProperty("avatar_number")]
        public int Characters { get; set; }

        [JsonProperty("way_point_number")]
        public int WayPoint { get; set; }

        [JsonProperty("domain_number")]
        public int Domains { get; set; }

        [JsonProperty("spiral_abyss")]
        public string SpiralAbyss { get; set; } = string.Empty;

        [JsonProperty("precious_chest_number")]
        public int ChestPrecious { get; set; }

        [JsonProperty("luxurious_chest_number")]
        public int ChestLuxurious { get; set; }

        [JsonProperty("exquisite_chest_number")]
        public int ChestExquisite { get; set; }

        [JsonProperty("common_chest_number")]
        public int ChestCommon { get; set; }

        [JsonProperty("magic_chest_number")]
        public int ChestMagic { get; set; }

        /// <summary> 風神の瞳 </summary>
        [JsonProperty("anemoculus_number")]
        public int OculusAnemo { get; set; }

        /// <summary> 岩神の瞳 </summary>
        [JsonProperty("geoculus_number")]
        public int OculusGeo { get; set; }

        /// <summary> 雷神の瞳 </summary>
        [JsonProperty("electroculus_number")]
        public int OculusElectro { get; set; }

        /// <summary> 草神の瞳 </summary>
        [JsonProperty("dendroculus_number")]
        public int OculusDendro { get; set; }

        /// <summary> 水神の瞳 </summary>
        [JsonProperty("hydroculus_number")]
        public int OculusHydro { get; set; }

        /// <summary> 炎神の瞳 </summary>
        [JsonProperty("pyroculus_number")]
        public int OculusPyro { get; set; }

        /// <summary> 氷神の瞳 </summary>
        [JsonProperty("cyroculus_number")]
        public int OculusCyro { get; set; }


        [JsonProperty("field_ext_map")]
        public Dictionary<string, FieldExtMap_Link> field_ext_map { get; set; } = new();
    }

    public class WorldExploration
    {
        [JsonProperty("level")]
        public int? Level { get; set; }

        [JsonProperty("exploration_percentage")]
        public int Exploration_percentage { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("offerings")]
        public List<Offering> Offerings { get; set; } = new();

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent_id")]
        public int Parent_id { get; set; }

        [JsonProperty("map_url")]
        public string Map_url { get; set; } = string.Empty;

        [JsonProperty("strategy_url")]
        public string strategy_url { get; set; } = string.Empty;

        [JsonProperty("background_image")]
        public string background_image { get; set; } = string.Empty;

        [JsonProperty("inner_icon")]
        public string inner_icon { get; set; } = string.Empty;

        [JsonProperty("cover")]
        public string cover { get; set; } = string.Empty;

        [JsonProperty("area_exploration_list")]
        public List<AreaExplorationList> area_exploration_list { get; set; } = new();

        [JsonProperty("boss_list")]
        public List<BossList> Boss_list { get; set; } = new();

        [JsonProperty("is_hot")]
        public bool Is_hot { get; set; }
    }


}
