using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.TravelersDiary.EventName
{
    internal class Root
    {
        /// <summary>
        /// タイプと名前の相互関係リスト
        /// </summary>
        public List<EventType> Events { get; set; } = new();
    }
    public class EventType
    {
        /// <summary>
        /// イベント番号
        /// </summary>
        public int ID { get; set; } = -1;
        /// <summary>
        /// イベント名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
