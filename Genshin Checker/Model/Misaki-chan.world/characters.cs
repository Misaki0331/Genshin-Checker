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
        public Name Name { get; set; } = new();

        [JsonPropertyName("profile")]
        public Profile Profile { get; set; } = new();

        [JsonPropertyName("released")]
        public Released Released { get; set; } = new();

        [JsonPropertyName("wiki")]
        public Wiki Wiki { get; set; } = new();

        [JsonPropertyName("skills")]
        public Skills Skills { get; set; } = new();
    }

    public class TrailerVideo
    {
        [JsonPropertyName("ytid")]
        public string Ytid { get; set; } = "";

        [JsonPropertyName("title")]
        public string Title { get; set; } = "";
    }

    public class Name
    {
        [JsonPropertyName("ja")]
        public string Ja { get; set; } = "";

        [JsonPropertyName("en")]
        public string En { get; set; } = "";
    }

    public class Profile
    {
        [JsonPropertyName("sex")]
        public string Sex { get; set; } = "";

        [JsonPropertyName("association")]
        public string Association { get; set; } = "";

        [JsonPropertyName("birthday")]
        public string Birthday { get; set; } = "";
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

    public class Songs
    {
        [JsonPropertyName("theme")]
        public Theme? Theme { get; set; }
    }

    public class Theme
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = "";

        [JsonPropertyName("title")]
        public Title Title { get; set; } = new();
    }

    public class Title
    {
        [JsonPropertyName("ja")]
        public string Ja { get; set; } = "";

        [JsonPropertyName("en")]
        public string En { get; set; } = "";

        [JsonPropertyName("zh-cn")]
        public string Zhcn { get; set; } = "";

        [JsonPropertyName("zh-tw")]
        public string Zhtw { get; set; } = "";

        [JsonPropertyName("kr")]
        public string Kr { get; set; } = "";
    }

    public class Trailer
    {
        [JsonPropertyName("ja")]
        public TrailerVideo? Ja { get; set; }

        [JsonPropertyName("en")]
        public TrailerVideo? En { get; set; }
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

    public class Video
    {
        [JsonPropertyName("trailer")]
        public Trailer? Trailer { get; set; }
    }

    public class Wiki
    {
        [JsonPropertyName("songs")]
        public Songs? Songs { get; set; }

        [JsonPropertyName("video")]
        public Video? Video { get; set; }
    }


}
