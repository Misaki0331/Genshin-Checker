using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Windows.UI.WebUI;

namespace Genshin_Checker.Model.Misaki_chan.Character
{// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Burst
    {
        [JsonPropertyName("constellations")]
        public int Constellations { get; set; }

        [JsonPropertyName("add_level")]
        public int Add_level { get; set; }
    }

    public class Character
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("element")]
        public string Element { get; set; } = "";

        [JsonPropertyName("weapon")]
        public string Weapon { get; set; } = "";

        [JsonPropertyName("name")]
        public KeyValuePair<string,string> Name { get; set; } = new();

        [JsonPropertyName("profile")]
        public Profile Profile { get; set; } = new();

        [JsonPropertyName("released")]
        public Released Released { get; set; } = new();

        [JsonPropertyName("wiki")]
        public Wiki Wiki { get; set; } = new();

        [JsonPropertyName("skills")]
        public Skills Skills { get; set; } = new();
        [JsonPropertyName("unlocks")]
        public Unlocks Unlocks { get; set; } = new();
    }

    public class TrailerVideo
    {
        [JsonPropertyName("ytid")]
        public string Ytid { get; set; } = "";

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";
    }


    public class Profile
    {
        [JsonPropertyName("sex")]
        public string Sex { get; set; } = "";

        [JsonPropertyName("association")]
        public string Association { get; set; } = "";

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; } = "";

        [JsonPropertyName("description")]
        public Dictionary<string,string> Description { get; set; } = new();
    }

    public class Released
    {
        [JsonPropertyName("version")]
        public string Version { get; set; } = "";

        [JsonPropertyName("date")]
        public string Date { get; set; } = "";
    }

    public class Root
    {
        [JsonPropertyName("updateAt")]
        public DateTime UpdateAt { get; set; }

        [JsonPropertyName("data")]
        public List<Character> Data { get; set; } = new();
    }

    public class Skill
    {
        [JsonPropertyName("constellations")]
        public int Constellations { get; set; }

        [JsonPropertyName("add_level")]
        public int Add_level { get; set; }
    }

    public class Skills
    {
        [JsonPropertyName("upgrade_skills")]
        public UpgradeSkills Upgrade_skills { get; set; } = new();
    }


    public class MusicInfo
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = "";

        [JsonPropertyName("title")]
        public Dictionary<string, string> Title { get; set; } = new();
    }


    public class UpgradeSkills
    {
        [JsonPropertyName("normal")]
        public Skill? Normal { get; set; }
        [JsonPropertyName("skill")]
        public Skill? Skill { get; set; }
        [JsonPropertyName("burst")]
        public Skill? Burst { get; set; }
    }


    public class Wiki
    {
        [JsonPropertyName("music")]
        public Dictionary<string, MusicInfo> Music { get; set; } = new();

        [JsonPropertyName("video")]
        public Dictionary<string, Dictionary<string, TrailerVideo>> Video { get; set; } = new();
    }
    public class Unlocks
    {
        public Dictionary<string, UnlockStoryInfo> Story { get; set; } = new();
    }
    public class UnlockStoryInfo
    {
        /// <summary>
        /// 非解禁時にタイトルを「？？？」に置き換える
        /// </summary>
        [JsonPropertyName("ishiddentitle")]
        public bool IsHiddenTitle { get; set; } = false;
        /// <summary>
        /// 解禁条件
        /// </summary>
        [JsonPropertyName("conditions")]
        public UnlockConditions Conditions { get; set; } = new();
        
    }
    public class UnlockConditions
    {
        /// <summary>
        /// 永久に解禁させない
        /// </summary>
        [JsonPropertyName("never")]
        public bool Never = false;
        /// <summary>
        /// 特定の好感度以上であれば解禁
        /// </summary>
        [JsonPropertyName("friendship")]
        public int? friendship = null;
    }


}
