using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*---------------------------------------------------------------------------------------------+
| 機能名 : 言語情報                                                                            |
| URL : https://raw.githubusercontent.com/EnkaNetwork/API-docs/master/store/loc.json           |
| パラメーター : なし                                                                          |
+---------------------------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.EnkaNetwork.Store.Locale 
{ 
    public class Root
    {
        public KeyValuePair<string, KeyValuePair<string, string>> Lang { get; set; }
    }
}
