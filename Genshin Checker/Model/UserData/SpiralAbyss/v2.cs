using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.SpiralAbyss.v2
{
    public class Avatar
    {
        public int id { get; set; }
        public int level { get; set; }
    }

    public class Battle
    {
        /// <summary>
        /// 前半:1 後半:2
        /// </summary>
        public int index { get; set; }
        public DateTime timestamp { get; set; } = DateTime.MinValue;
        public List<Avatar> avatars { get; set; } = new();
    }
    public class TimeRange
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
    public class Rank
    {
        public List<CharacterData> Reveal { get; set; } = new();
        public List<CharacterData> Defeat { get; set; } = new();
        public List<CharacterData> Damage { get; set; } = new();
        public List<CharacterData> TakeDamage { get; set; } = new();
        /// <summary>
        /// 元素スキルの回数
        /// </summary>
        public List<CharacterData> NormalSkill { get; set; } = new();
        /// <summary>
        /// 元素爆発の回数
        /// </summary>
        public List<CharacterData> EnergySkill { get; set; } = new();
    }
    public class V2 : DatabaseRoot
    {
        public Data Data { get; set; } = new();
    }
    public class Data
    {
        public int schedule_id { get; set; }
        public TimeRange ScheduleTime { get; set; } = new();
        public int total_battle_times { get; set; }
        public int total_win_times { get; set; }
        /// <summary>
        /// 最大到達フロア
        /// </summary>
        public string max_floor { get; set; } = string.Empty;
        public Rank Ranks { get; set; } = new();
        public List<Floor> floors { get; set; } = new();
        public int total_star { get; set; }
        /// <summary>
        /// 深境螺旋が解放済みかどうか
        /// </summary>
        public bool is_unlock { get; set; }
    }
    public class CharacterData
    {
        public int id { get; set; }
        public int value { get; set; }
    }

    public class Floor
    {
        public int index { get; set; }
        public bool is_unlock { get; set; }
        public int star { get; set; }
        public int max_star { get; set; }
        public List<Level> levels { get; set; } = new();
        /// <summary>
        /// 地脈異常
        /// </summary>
        public List<string> ley_line_disorder { get; set; } = new();
    }

    public class Level
    {
        /// <summary>
        /// 螺旋n層
        /// </summary>
        public int index { get; set; }
        public List<LevelHistory> history { get; set; } = new();
    }
    public class LevelHistory
    {
        public int star { get; set; }
        public int max_star { get; set; }
        public DateTime timestamp { get; set; }
        public List<Battle> battles { get; set; } = new();
    }



}
