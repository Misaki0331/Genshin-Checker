using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.CharacterCalculator.CharacterObjective
{
    public class Root
    {
        public Dictionary<int, Data> Datas { get; set; } = new();
    }
    public class Data
    {
        [JsonProperty("e")]
        public bool Enabled { get; set; } = false;
        [JsonProperty("l")]
        public int SetLevel { get; set; } = 1;
        [JsonProperty("a")]
        public int SetTalent1 { get; set; } = 1;
        [JsonProperty("b")]
        public int SetTalent2 { get; set; } = 1;
        [JsonProperty("c")]
        public int SetTalent3 { get; set; } = 1;
    }
}
