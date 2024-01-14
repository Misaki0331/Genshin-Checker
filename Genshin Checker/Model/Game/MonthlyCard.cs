using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.Game.MonthlyCardLog
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class Data
    {
        /// <summary>
        /// リスト内のサイズ
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// リクエストした末尾のデータID
        /// </summary>
        public long end_id { get; set; }
        /// <summary>
        /// データ
        /// </summary>
        public List<List> list { get; set; } = new();
    }

    public class List
    {
        /// <summary>
        /// データID
        /// </summary>
        [JsonProperty("id")]
        public long ID { get; set; }
        /// <summary>
        /// ゲームUID
        /// </summary>
        [JsonProperty("uid")]
        public int UID { get; set; }
        /// <summary>
        /// 消費・増加タイプ
        /// </summary>
        [JsonProperty("card_product_type")]
        public int EventType { get; set; }
        /// <summary>
        /// イベント発生時刻(サーバー時間)
        /// </summary>
        [JsonProperty("time")]
        public string EventTime { get; set; } = "";
        /// <summary>
        /// イベント名(ローカライズされた)
        /// </summary>
        [JsonProperty("card_product_name")]
        public string EventName { get; set; } = "";
    }
}
