using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//GetArtifactLog / GetWeaponLog

namespace Genshin_Checker.Model.Game.EquipmentLog
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
        /// <summary>
        /// アイテム名(ローカライズされた)
        /// </summary>
        [JsonProperty("name")]
        public string ItemName { get; set; } = "";
        /// <summary>
        /// レアリティ
        /// </summary>
        [JsonProperty("quality")]
        public int Rarelity { get; set; }
        /// <summary>
        /// レベル
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }
        /// <summary>
        /// 画像アイコン(現在未使用)
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; } = "";
    }
}
