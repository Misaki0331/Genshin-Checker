using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.TravelersDiary.Lists
{
    public class Root
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
        public DateTime EventTime { get; set; } = DateTime.MinValue;
        /// <summary>
        /// イベントの種類
        /// </summary>
        public int EventType { get; set; } = -1;
    }
}
