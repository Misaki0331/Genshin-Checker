using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.GameDatabase.NameLocalize
{
    public class Root
    {
        /// <summary>
        /// "en_name" : {"ja-JP": "ja_name","kr-kr": "kr_name"}
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> Locale = new(); 
    }
}
