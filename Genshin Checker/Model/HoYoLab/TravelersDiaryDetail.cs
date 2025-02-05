using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*-----------------------------------------------------------------------------+
| 機能名 : 旅人手帳                                                            |
| APIの仕様 : 原石及びモラの取得履歴                                           |
| 利用可能端末 : HoYoLabモバイル                                               |
| URL : https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_detail          |
| パラメーター :                                                               |
|   month: [Number] 0の場合は現在の月 直近3か月まで取得が可能                  |
|   region: [String] アカウントのサーバー、アジア圏の場合は「os_asia」         |
|   uid: [Number] ゲーム内UID アジア圏なら8から始まる9桁 例: 「800000000」     |
|   lang: [String] ロケールID 日本語であれば「ja-jp」 英語であれば「us-en」    |
|   type: [Number] 原石は「1」モラは「2」それ以外はエラーが返される。          |
|   current_page: [Number] 1ページ当たり20件表示されるが、範囲外は空配列が     |
|       返される。一番最初のページは「1」ページである。上限は無し。            |
|       ページが「0」である場合は自動的に「1」の内容になる。                   |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab.TravelersDiary.Detail
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }

    public class Data
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; } = string.Empty;

        [JsonProperty("nickname")]
        public string Nickname { get; set; } = string.Empty;

        [JsonProperty("data_month")]
        public int Data_month { get; set; }

        [JsonProperty("current_page")]
        public int Current_page { get; set; }

        [JsonProperty("list")]
        public List<List> List { get; set; } = new();

        [JsonProperty("optional_month")]
        public List<int> Optional_month { get; set; } = new();
    }

    public class List
    {
        [JsonProperty("action_id")]
        public int Action_id { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; } = string.Empty;

        [JsonProperty("time")]
        public string Time { get; set; } = string.Empty;

        [JsonProperty("num")]
        public int Num { get; set; }
    }
}
