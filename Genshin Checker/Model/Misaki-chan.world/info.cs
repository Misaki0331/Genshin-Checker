using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.Misaki_chan.info
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class ApiHost
    {
        [JsonPropertyName("account")]
        public string Account { get; set; } = "";

        [JsonPropertyName("game")]
        public string Game { get; set; } = "";

        [JsonPropertyName("genshin")]
        public string Genshin { get; set; } = "";

        [JsonPropertyName("event")]
        public string Event { get; set; } = "";
    }

    public class Game
    {
        [JsonPropertyName("announcement")]
        public string Announcement { get; set; } = "";

        [JsonPropertyName("service-center")]
        public string Servicecenter { get; set; } = "";
    }

    public class General
    {
        [JsonPropertyName("material")]
        public string Material { get; set; } = "";
    }

    public class Hoyolab
    {
        [JsonPropertyName("api-host")]
        public ApiHost Apihost { get; set; } = new();

        [JsonPropertyName("general")]
        public General General { get; set; } = new();

        [JsonPropertyName("loginbonus_actid")]
        public string Loginbonus_actid { get; set; } = "";
    }


    public class Localize
    {
        [JsonPropertyName("talent")]
        public Dictionary<string, List<string>> Talent { get; set; } = new();

        [JsonPropertyName("wiki")]
        public Wiki Wiki { get; set; } = new();

        [JsonPropertyName("lang")]
        public Dictionary<string, Dictionary<string, string>> Lang { get; set; } = new();
    }
    public class Url
    {
        [JsonPropertyName("game")]
        public Game Game { get; set; } = new();

        [JsonPropertyName("hoyolab")]
        public Hoyolab Hoyolab { get; set; } = new();
    }

    public class Root
    {
        [JsonPropertyName("url")]
        public Url Url { get; set; } = new();

        [JsonPropertyName("localize")]
        public Localize Localize { get; set; } = new();
    }

    public class Wiki
    {
        [JsonPropertyName("video")]
        public Dictionary<string, Dictionary<string, string>> Video { get; set; } = new();

        [JsonPropertyName("music")]
        public Dictionary<string, Dictionary<string, string>> Music { get; set; } = new();
    }


}
