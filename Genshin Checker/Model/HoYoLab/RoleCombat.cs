using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//幻想シアター
namespace Genshin_Checker.Model.HoYoLab.RoleCombat
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class Data
    {
        /// <summary>
        /// データ情報
        /// </summary>
        public List<DataGame> data { get; set; } = new();
        /// <summary>
        /// 解禁済みか
        /// </summary>
        public bool is_unlock { get; set; }
        /// <summary>
        /// リンク集
        /// </summary>
        public Dictionary<string, string> links { get; set; } = new();
    }
    public class DataGame
    {
        /// <summary>
        /// 詳細情報
        /// </summary>
        public Detail? detail { get; set; }
        /// <summary>
        /// プレイステータス
        /// </summary>
        public Stat? stat { get; set; }
        /// <summary>
        /// スケジュール情報
        /// </summary>
        public Schedule schedule { get; set; } = new();
        /// <summary>
        /// 解禁済みか
        /// </summary>
        public bool has_data { get; set; }
        /// <summary>
        /// プレイ済みか
        /// </summary>
        public bool has_detail_data { get; set; }
    }
    public class Avatar
    {
        /// <summary>
        /// キャラクターID
        /// </summary>
        public int avatar_id { get; set; }
        /// <summary>
        /// 1 : プレイヤー育成<br/>
        /// 2 : お試しキャラクター
        /// </summary>
        public int avatar_type { get; set; }
        /// <summary>
        /// キャラクター名
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// 元素
        /// </summary>
        public string element { get; set; } = "";
        /// <summary>
        /// キャラクター画像
        /// </summary>
        public string image { get; set; } = "";
        /// <summary>
        /// キャラクターレベル
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// レアリティ
        /// </summary>
        public int rarity { get; set; }
    }

    public class Buff
    {
        /// <summary>
        /// バフの画像URL
        /// </summary>
        public string icon { get; set; } = "";
        /// <summary>
        /// バフ名
        /// </summary>
        public string name { get; set; } = "";
        /// <summary>
        /// バフの効果内容
        /// </summary>
        public string desc { get; set; } = "";
        /// <summary>
        /// 強化済みか
        /// </summary>
        public bool is_enhanced { get; set; }
        /// <summary>
        /// バフID
        /// </summary>
        public int id { get; set; }
    }

    public class Detail
    {
        /// <summary>
        /// 各ラウンド情報
        /// </summary>
        public List<Round> rounds_data { get; set; } = new();
        /// <summary>
        /// ステータス
        /// </summary>
        public Stat detail_stat { get; set; } = new();
        /// <summary>
        /// 公演キャラ
        /// </summary>
        public List<Avatar> backup_avatars { get; set; } = new();
    }


    public class Round
    {
        public List<Avatar> avatars { get; set; } = new();
        public List<Buff> choice_cards { get; set; } = new();
        public List<Buff> buffs { get; set; } = new();
        public bool is_get_medal { get; set; }
        public int round_id { get; set; }
        public string finish_time { get; set; } = "";
        public DateTimeInfo finish_date_time { get; set; } = new();
    }
    public class Schedule
    {
        public string start_time { get; set; } = "";
        public string end_time { get; set; } = "";
        public int schedule_type { get; set; }
        public int schedule_id { get; set; }
        public DateTimeInfo start_date_time { get; set; } = new();
        public DateTimeInfo end_date_time { get; set; } = new();
    }

    public class DateTimeInfo
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }

    public class Stat
    {
        public int difficulty_id { get; set; }
        public int max_round_id { get; set; }
        public int heraldry { get; set; }
        public List<int> get_medal_round_list { get; set; } = new();
        public int medal_num { get; set; }
        public int coin_num { get; set; }
        public int avatar_bonus_num { get; set; }
        public int rent_cnt { get; set; }
    }
}
