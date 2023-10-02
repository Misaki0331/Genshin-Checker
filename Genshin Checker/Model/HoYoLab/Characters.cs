using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*-----------------------------------------------------------------------------+
| 機能名 : 原神戦績 / 育成計算機                                               |
| APIの仕様 : キャラクターの所持と育成状況(突破を除く)を取得 POST              |
| 利用可能端末 : HoYoLabモバイル / モバイルブラウザ / PCブラウザ               |
| URL : https://bbs-api-os.hoyolab.com/game_record/genshin/api/character       |
| パラメーター :                                                               |
|   server: [String] アカウントのサーバー、アジア圏の場合は「os_asia」         |
|   role_id: [Number] ゲーム内UID アジア圏なら8から始まる9桁 例: 「800000000」 |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab.Characters
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }

    public class Affix
    {
        public int activation_number { get; set; }
        public string effect { get; set; } = string.Empty;
    }

    public class Avatar
    {
        public int id { get; set; }
        public string image { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string element { get; set; } = string.Empty;
        public int fetter { get; set; }
        public int level { get; set; }
        public int rarity { get; set; }
        public Weapon weapon { get; set; } = new();
        public List<Reliquary> reliquaries { get; set; } = new();
        public List<Constellation> constellations { get; set; } = new();
        public int actived_constellation_num { get; set; }
        public List<Costume> costumes { get; set; } = new();
        public object external { get; set; } = new();
    }

    public class Constellation
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
        public string effect { get; set; } = string.Empty;
        public bool is_actived { get; set; }
        public int pos { get; set; }
    }

    public class Costume
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
    }

    public class Data
    {
        public List<Avatar> avatars { get; set; } = new();
        public Role role { get; set; } = new();
    }

    public class Reliquary
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
        public int pos { get; set; }
        public int rarity { get; set; }
        public int level { get; set; }
        public Set set { get; set; } = new();
        public string pos_name { get; set; } = string.Empty;
    }

    public class Role
    {
        public string AvatarUrl { get; set; } = string.Empty;
        public string nickname { get; set; } = string.Empty;
        public string region { get; set; } = string.Empty;
        public int level { get; set; }
    }
    public class Set
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public List<Affix> affixes { get; set; } = new();
    }

    public class Weapon
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
        public int type { get; set; }
        public int rarity { get; set; }
        public int level { get; set; }
        public int promote_level { get; set; }
        public string type_name { get; set; } = string.Empty;
        public string desc { get; set; } = string.Empty;
        public int affix_level { get; set; }
    }


}
