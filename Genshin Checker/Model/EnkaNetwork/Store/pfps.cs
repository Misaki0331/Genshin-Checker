using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*---------------------------------------------------------------------------------------------+
| 機能名 : 聖遺物の計算                                                                        |
| URL : https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/pfps.json       |
| パラメーター : なし                                                                          |
+---------------------------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.EnkaNetwork.Store.Pfps
{
    public class Root
    {
        public Dictionary<int, Data> index { get; set; } = new();
    }

    public class Data
    {
        [JsonProperty("iconPath")]
        public string iconPath { get; set; } = string.Empty;
    }

}
