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
| URL : https://bbs-api-os.hoyolab.com/game_record/genshin/api/characters/list |
| パラメーター :                                                               |
|   server: [String] アカウントのサーバー、アジア圏の場合は「os_asia」         |
|   role_id: [Number] ゲーム内UID アジア圏なら8から始まる9桁 例: 「800000000」 |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab.Characters
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }

        public class Data
    {
        public List<List> list { get; set; } = new();
    }

    public class List
    {
        public int id { get; set; }
        public string icon { get; set; } = "";
        public string name { get; set; } = "";
        public string element { get; set; } = "";
        public int fetter { get; set; }
        public int level { get; set; }
        public int rarity { get; set; }
        public int actived_constellation_num { get; set; }
        public string image { get; set; } = "";
        public bool is_chosen { get; set; }
        public string side_icon { get; set; } = "";
        public int weapon_type { get; set; }
        public Weapon weapon { get; set; } = new();
    }


    public class Weapon
    {
        public int id { get; set; }
        public string icon { get; set; } = "";
        public int type { get; set; }
        public int rarity { get; set; }
        public int level { get; set; }
        public int affix_level { get; set; }
        public string name { get; set; } = "";
    }


}
