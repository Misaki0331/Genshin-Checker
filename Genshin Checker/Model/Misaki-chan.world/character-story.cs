using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.Misaki_chan.character_story
{
    public class Root
    {
        [JsonPropertyName("updateAt")]
        public DateTime UpdateAt { get; set; }

        [JsonPropertyName("data")]
        public List<Character> Data { get; set; } = new();
    }
    public class Character
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("story")]
        public Dictionary<string, Story> Story { get; set; } = new();
    }
    public class Story
    {
        public string Text { get; set; } = "";
        public string? Title { get; set; } = null;
    }
}
