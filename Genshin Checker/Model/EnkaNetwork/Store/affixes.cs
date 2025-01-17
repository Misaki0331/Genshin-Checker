using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*---------------------------------------------------------------------------------------------+
| 機能名 : 聖遺物の計算                                                                        |
| URL : https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/affixes.json       |
| パラメーター : なし                                                                          |
+---------------------------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.EnkaNetwork.Store.Affixes
{
    public class Root
    {
        public Dictionary<int, Data> index { get; set; } = new();
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
