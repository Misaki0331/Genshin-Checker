using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*-----------------------------------------------------------------------------+
| 機能名 : 旅人手帳                                                            |
| APIの仕様 : 今日と1か月分のモラと原石の数を取得。                            |
| 利用可能端末 : HoYoLabモバイル                                               |
| URL : https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_info            |
| パラメーター :                                                               |
|   month: [Number] 0の場合は現在の月 直近3か月まで取得が可能                  |
|   region: [String] アカウントのサーバー、アジア圏の場合は「os_asia」         |
|   uid: [Number] ゲーム内UID アジア圏なら8から始まる9桁 例: 「807810806」     |
|   lang: [String] ロケールID 日本語であれば「ja-jp」 英語であれば「us-en」    |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab.TravelersDiary.Infomation
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }

    public class Data
    {
        [JsonProperty("uid")]
        public int uid { get; set; }

        [JsonProperty("region")]
        public string region { get; set; } = string.Empty;

        [JsonProperty("nickname")]
        public string nickname { get; set; } = string.Empty;

        [JsonProperty("optional_month")]
        public List<int> optional_month { get; set; } = new();

        [JsonProperty("month")]
        public int month { get; set; }

        [JsonProperty("data_month")]
        public int data_month { get; set; }

        [JsonProperty("month_data")]
        public MonthData month_data { get; set; } = new();

        [JsonProperty("day_data")]
        public DayData day_data { get; set; } = new();
    }

    public class DayData
    {
        [JsonProperty("current_primogems")]
        public int current_primogems { get; set; }

        [JsonProperty("current_mora")]
        public int current_mora { get; set; }
    }

    public class GroupBy
    {
        [JsonProperty("action_id")]
        public int action_id { get; set; }

        [JsonProperty("action")]
        public string action { get; set; } = string.Empty;

        [JsonProperty("num")]
        public int num { get; set; }

        [JsonProperty("percent")]
        public int percent { get; set; }
    }

    public class MonthData
    {
        [JsonProperty("current_primogems")]
        public int current_primogems { get; set; }

        [JsonProperty("current_mora")]
        public int current_mora { get; set; }

        [JsonProperty("last_primogems")]
        public int last_primogems { get; set; }

        [JsonProperty("last_mora")]
        public int last_mora { get; set; }

        [JsonProperty("primogem_rate")]
        public int primogem_rate { get; set; }

        [JsonProperty("mora_rate")]
        public int mora_rate { get; set; }

        [JsonProperty("group_by")]
        public List<GroupBy> group_by { get; set; } = new();
    }
}
