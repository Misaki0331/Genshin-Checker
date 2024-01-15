using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.GameDatabase.ItemNum
{

    public class ItemNum
    {
        /// <summary>
        /// 詳細リスト
        /// </summary>
        public List<Detail> Details { get; set; } = new();
    }
    public class Detail
    {
        /// <summary>
        /// イベント発生時間
        /// </summary>
        [JsonProperty("d")]
        public string ID { get; set; } = "";
        /// <summary>
        /// イベント発生時間
        /// </summary>
        [JsonProperty("t")]
        public DateTime EventTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// イベントの種類(英語名)
        /// </summary>
        [JsonProperty("e")]
        public string EventType { get; set; } = "";
        /// <summary>
        /// イベントの種類(当アプリ内部で決められたID)
        /// </summary>
        [JsonProperty("i")]
        public int EventTypeID { get; set; } = 0;
        /// <summary>
        /// 対象のカウント
        /// </summary>
        [JsonProperty("c")]
        public int Count { get; set; } = -1;
    }
}
