using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.DailyBonusExtraAward
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class Award
    {
        /// <summary>
        /// 内部番号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// アイテムアイコンURL
        /// </summary>
        public string icon { get; set; } = "";
        /// <summary>
        /// アイテム名
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// 受け取れる数
        /// </summary>
        public int cnt { get; set; }
        /// <summary>
        /// 追加ログイン日数
        /// </summary>
        public int sign_day { get; set; }
        /// <summary>
        /// イチオシ
        /// </summary>
        public bool highlight { get; set; }
    }

    public class Mc
    {
        public bool has_month_card { get; set; }
        /// <summary>
        /// イベント開始時刻
        /// </summary>
        public string start_time { get; set; } = "";
        /// <summary>
        /// オープン期間
        /// </summary>
        public string open_time { get; set; } = "";
        /// <summary>
        /// イベント終了時刻
        /// </summary>
        public string end_time { get; set; } = "";
        /// <summary>
        /// ステータス
        /// 終わりの場合:MC_End
        /// </summary>
        public string status { get; set; } = "";
    }

    public class Data
    {
        /// <summary>
        /// false
        /// </summary>
        public bool has_short_act { get; set; }
        public List<Award> awards { get; set; } = new();
        /// <summary>
        /// イベント開始時刻
        /// </summary>
        public int start_timestamp { get; set; }
        /// <summary>
        /// イベント終了時刻
        /// </summary>
        public int end_timestamp { get; set; }
        /// <summary>
        /// 受け取った数
        /// </summary>
        public int total_cnt { get; set; }
        /// <summary>
        /// ログインしているかどうか
        /// </summary>
        public bool login { get; set; }
        public Mc mc { get; set; } = new();
    }
}
