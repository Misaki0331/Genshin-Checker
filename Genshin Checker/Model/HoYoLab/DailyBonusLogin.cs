using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.DailyBonusLogin
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class GtResult
    {
        /// <summary>
        /// 基本的に0
        /// </summary>
        public int risk_code { get; set; }
        /// <summary>
        /// 基本的に空
        /// </summary>
        public string gt { get; set; } = string.Empty;
        /// <summary>
        /// 基本的に空
        /// </summary>
        public string challenge { get; set; } = string.Empty;
        /// <summary>
        /// 基本的に0
        /// </summary>
        public int success { get; set; }
        /// <summary>
        /// 基本的にfalse
        /// </summary>
        public bool is_risk { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// "ok"ならログボ成功
        /// </summary>
        public string code { get; set; } = string.Empty;
        /// <summary>
        /// 初ログボかどうか
        /// </summary>
        public bool first_bind { get; set; }
        public GtResult gt_result { get; set; } = new();
    }



}
