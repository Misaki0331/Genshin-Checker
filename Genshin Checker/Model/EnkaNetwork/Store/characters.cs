using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*---------------------------------------------------------------------------------------------+
| 機能名 : キャラクター情報                                                                    |
| URL : https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/characters.json    |
| パラメーター : なし                                                                          |
+---------------------------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.EnkaNetwork.Store
{
    public class Data
    {
        [JsonProperty("Element")]
        public string Element { get; set; } = string.Empty;

        [JsonProperty("Consts")]
        public List<string> Consts { get; set; } = new();

        [JsonProperty("SkillOrder")]
        public List<int> SkillOrder { get; set; } = new();

        [JsonProperty("Skills")]
        public KeyValuePair<int,string> Skills { get; set; }

        [JsonProperty("ProudMap")]
        public KeyValuePair<int,int> ProudMap { get; set; }

        [JsonProperty("NameTextMapHash")]
        public int NameTextMapHash { get; set; }

        [JsonProperty("SideIconName")]
        public string SideIconName { get; set; } = string.Empty;

        [JsonProperty("QualityType")]
        public string QualityType { get; set; } = string.Empty;

        [JsonProperty("WeaponType")]
        public string WeaponType { get; set; } = string.Empty;
    }

    public class Root
    {
        KeyValuePair<string, Data> index { get; set; } = new();
    }

}
