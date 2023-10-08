using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*---------------------------------------------------------------------------------------------+
| 機能名 : 衣装情報                                                                            |
| URL : https://github.com/EnkaNetwork/API-docs/blob/master/store/costumes.json                |
| パラメーター : なし                                                                          |
+---------------------------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.EnkaNetwork.Store.Costumes
{
    public class Data
    {
        [JsonProperty("iconName")]
        public string iconName { get; set; } = string.Empty;

        [JsonProperty("sideIconName")]
        public string sideIconName { get; set; } = string.Empty;

        [JsonProperty("nameTextMapHash")]
        public long nameTextMapHash { get; set; }
    }
}
