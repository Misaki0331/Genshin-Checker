using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.TravelersDiary.EventLists
{
    public class EventLists
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
        [JsonProperty("t")]
        public DateTime EventTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// イベントの種類
        /// </summary>
        [JsonProperty("e")]
        public int EventType { get; set; } = -1;
        /// <summary>
        /// 対象のカウント
        /// </summary>
        [JsonProperty("c")]
        public int Count { get; set; } = -1;
    }
}
