using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.Static.DiaryEventLocalize
{
    public class DiaryEventLocalize
    {
        public Dictionary<int, Event> Events { get; set; } = new();
    }

    public class Event
    {
        public Dictionary<string, Localize> Localize { get; set; } = new();
        /// <summary>
        /// カテゴリ
        /// </summary>
        public string Category { get; set; } = "";
        /// <summary>
        /// 再入手不可能であるか
        /// </summary>
        public bool IsClaimOnce { get; set; } = false;
        /// <summary>
        /// 期間制限があるか
        /// </summary>
        public bool IsLimited { get; set; } = false;

    }
    public class Localize
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string CategoryName { get; set; } = "";

    }

}
