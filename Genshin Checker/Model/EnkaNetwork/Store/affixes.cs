using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.EnkaNetwork.Store.Affixes
{
    public class Root
    {
        public KeyValuePair<int,Data> index { get; set; }
    }

    public class Data
    {
        [JsonProperty("propType")]
        public string propType { get; set; } = string.Empty;

        [JsonProperty("efficiency")]
        public double efficiency { get; set; }

        [JsonProperty("position")]
        public int position { get; set; }
    }

}
