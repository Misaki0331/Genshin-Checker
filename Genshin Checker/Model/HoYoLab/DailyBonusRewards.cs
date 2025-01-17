using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.DailyBonusRewards
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class Award
    {
        public string icon { get; set; } = "";
        public string name { get; set; } = "";
        public int cnt { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 今月
        /// </summary>
        public int month { get; set; }
        public List<Award> awards { get; set; } = new();
        public bool resign { get; set; }
        /// <summary>
        /// 現在時刻
        /// </summary>
        public int now { get; set; }
    }
}
