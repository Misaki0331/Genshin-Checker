using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.DailyBonusResignInfo
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class Data
    {
        public int resign_cnt_daily { get; set; }
        /// <summary>
        /// 月間の埋め合わせ回数
        /// </summary>
        public int resign_cnt_monthly { get; set; }
        public int resign_limit_daily { get; set; }
        /// <summary>
        /// 月間の上限埋め合わせ回数
        /// </summary>
        public int resign_limit_monthly { get; set; }
        /// <summary>
        /// 未ログイン日数
        /// </summary>
        public int sign_cnt_missed { get; set; }
        public int quality_cnt { get; set; }
        public bool signed { get; set; }
        /// <summary>
        /// ログインした日数
        /// </summary>
        public int sign_cnt { get; set; }
        /// <summary>
        /// コスト？1固定
        /// </summary>
        public int cost { get; set; }
        public int month_quality_cnt { get; set; }
    }
}
