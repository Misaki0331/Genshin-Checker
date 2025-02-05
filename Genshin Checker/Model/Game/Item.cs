using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//GetPrimogemLog / GetCrystalLog / GetResinLog
namespace Genshin_Checker.Model.Game.ItemLog
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
        public string end_id { get; set; } = "";
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
        public string ID { get; set; } = "";
        /// <summary>
        /// 消費・増加値
        /// </summary>
        [JsonProperty("add_num")]
        public string NumItems { get; set; } = "";
        /// <summary>
        /// イベント発生時刻(サーバー時間)
        /// </summary>
        [JsonProperty("datetime")]
        public string EventTime { get; set; } = "";
        /// <summary>
        /// イベント名(ローカライズされた)
        /// </summary>
        [JsonProperty("reason")]
        public string EventName { get; set; } = "";
    }
}
