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

namespace Genshin_Checker.Model.EnkaNetwork.Store.Characters
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
        public Dictionary<int, int> ProudMap { get; set; } = new();

        [JsonProperty("NameTextMapHash")]
        public long NameTextMapHash { get; set; }

        [JsonProperty("SideIconName")]
        public string SideIconName { get; set; } = string.Empty;

        [JsonProperty("QualityType")]
        public string QualityType { get; set; } = string.Empty;

        [JsonProperty("WeaponType")]
        public string WeaponType { get; set; } = string.Empty;

        [JsonProperty("Costumes")]
        public KeyValuePair<int,Costumes> Costumes { get; set; }
    }
    public class Costumes
    {
        [JsonProperty("sideIconName")]
        public string SideIconName { get; set; } = string.Empty;
        [JsonProperty("icon")]
        public string Icon { get; set; } = string.Empty;
        [JsonProperty("art")]
        public string Art { get; set; } = string.Empty;
        [JsonProperty("avatarId")]
        public int AvatarId { get; set; }
    }

    public class Root
    {
    }

}
