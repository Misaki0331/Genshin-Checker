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
        /// 末尾のデータID
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
        public long id { get; set; }
        /// <summary>
        /// ゲームUID
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 消費・増加タイプ
        /// </summary>
        public int card_product_type { get; set; }
        /// <summary>
        /// イベント発生時刻(サーバー時間)
        /// </summary>
        public string time { get; set; } = "";
        /// <summary>
        /// イベント名(ローカライズされた)
        /// </summary>
        public string card_product_name { get; set; } = "";
    }
}
