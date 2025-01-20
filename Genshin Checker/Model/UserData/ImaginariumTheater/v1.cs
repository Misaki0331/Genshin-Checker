using Genshin_Checker.Model.HoYoLab.RoleCombat;
using Genshin_Checker.Model.UserData.SpiralAbyss.v1;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.ImaginariumTheater.v1
{
    public class V1 : DatabaseRoot
    {
        public Data Data { get; set; } = new();
    }
    public class TimeRange
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
    public class Data
    {
        public bool IsUnlock { get; set; } = false;
        public int schedule_id { get; set; }
        public int schedule_type { get; set; }
        public TimeRange ScheduleTime { get; set; } = new();
        public List<Detail> Detail { get; set; } = new();
        public Stats CurrentStats { get; set; } = new();
    }
    public class Stats
    {
        /// <summary>
        /// 観客の声援の数
        /// </summary>
        public int avatar_bonus_num { get; set; } = 0;
        /// <summary>
        /// 難易度
        /// </summary>
        public int difficulty_id { get; set; } = 0;
        /// <summary>
        /// ラウンドごとの星の取得情報
        /// </summary>
        public List<int> get_medal_round_list { get; set; } = new();
        /// <summary>
        /// レンタル数
        /// </summary>
        public int rent_cnt { get; set; } = 0;
        /// <summary>
        /// 獲得した星の数
        /// </summary>
        public int medal_num { get; set; } = 0;
        /// <summary>
        /// 最大到達ラウンド数
        /// </summary>
        public int max_round_id { get; set; } = 0;
        /// <summary>
        /// 紋章レベル
        /// </summary>
        public int heraldry { get; set; } = 0;
        /// <summary>
        /// 消費した「幻戯の花」の数
        /// </summary>
        public int coin_num { get; set; } = 0;
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
        public Stats Stats { get; set; } = new();
        /// <summary>
        /// 公演キャラ
        /// </summary>
        public List<Avatar> backup_avatars { get; set; } = new();
        public DateTime UpdateAt { get; set; }
        public DateTime FirstRoundTime { get; set; }
        public DateTime FinalRoundTime { get; set; }
    }


    public class Round
    {
        public List<Avatar> avatars { get; set; } = new();
        public List<Buff> choice_cards { get; set; } = new();
        public List<Buff> buffs { get; set; } = new();
        public bool is_get_medal { get; set; }
        public int round_id { get; set; }
        public DateTime finish_time { get; set; }
    }
}
