using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.DailyBonusInfo
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class Data
    {
        /// <summary>
        /// 今月ログインした日数
        /// </summary>
        public int total_sign_day { get; set; }
        /// <summary>
        /// 今日の日付
        /// </summary>
        public string today { get; set; } = "";
        /// <summary>
        /// 既にログボを受け取ってるか
        /// </summary>
        public bool is_sign { get; set; }
        /// <summary>
        /// 初めてのログボか
        /// </summary>
        public bool first_bind { get; set; }
        /// <summary>
        /// HoYoLabモバイルに通知が届くかどうか
        /// </summary>
        public bool is_sub { get; set; }
        /// <summary>
        /// 連携しているサーバー
        /// </summary>
        public string region { get; set; } = "";
        /// <summary>
        /// 今日がログボ最終日か
        /// </summary>
        public bool month_last_day { get; set; }
    }
}
