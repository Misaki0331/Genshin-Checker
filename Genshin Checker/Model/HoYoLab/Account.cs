using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*-----------------------------------------------------------------------------+
| 機能名 : サーバー毎のアカウント情報                                          |
| APIの仕様 : HoYoLabアカウント内と連携済みのゲームアカウントの表示            |
| 利用可能端末 : HoYoLabモバイル / モバイルブラウザ / PCブラウザ               |
| URL : https://api-account-os.hoyolab.com/binding/api/getUserGameRolesByLtoken|
| パラメーター :                                                               |
|   game_biz : [String] グローバル版であれば hk4e_global                       |
|   region : [String] アカウントのサーバー、アジア圏の場合は「os_asia」        |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab.Account
{
    public class Data
    {
        public List<List> list { get; set; } = new();
    }

    public class List
    {
        public string game_biz { get; set; } = string.Empty;
        public string region { get; set; } = string.Empty;
        public string game_uid { get; set; } = string.Empty;
        public string nickname { get; set; } = string.Empty;
        public int level { get; set; }
        public bool is_chosen { get; set; }
        public string region_name { get; set; } = string.Empty;
        public bool is_official { get; set; }
    }

}
