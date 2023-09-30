﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*-----------------------------------------------------------------------------+
| 機能名 : 原神戦績                                                            |
| APIの仕様 : 螺旋の進捗データと敵データを取得。                               |
| 利用可能端末 : HoYoLabモバイル / モバイルブラウザ / PCブラウザ               |
| URL : https://bbs-api-os.hoyolab.com/game_record/genshin/api/spiralAbyss     |
| パラメーター :                                                               |
|   server: [String] アカウントのサーバー、アジア圏の場合は「os_asia」         |
|   role_id: [Number] ゲーム内UID アジア圏なら8から始まる9桁 例: 「800000000」 |
|   lang: [String] ロケールID 日本語であれば「ja-jp」 英語であれば「us-en」    |
|   schedule_type: [Number] 今期は「1」 前期は「2」 それ以外はエラーが返される |
+-----------------------------------------------------------------------------*/

namespace Genshin_Checker.Model.HoYoLab.SpiralAbyss
{
    public class Avatar
    {
        public int id { get; set; }
        public string icon { get; set; } = string.Empty;
        public int level { get; set; }
        public int rarity { get; set; }
    }

    public class Battle
    {
        public int index { get; set; }
        public string timestamp { get; set; } = string.Empty;
        public List<Avatar> avatars { get; set; } = new();
        public SettleDateTime settle_date_time { get; set; } = new();
    }

    public class BottomHalfFloorMonster
    {
        public string name { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
        public int level { get; set; }
    }

    public class DamageRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class Data
    {
        public int schedule_id { get; set; }
        public string start_time { get; set; } = string.Empty;
        public string end_time { get; set; } = string.Empty;
        public int total_battle_times { get; set; }
        public int total_win_times { get; set; }
        public string max_floor { get; set; } = string.Empty;
        public List<RevealRank> reveal_rank { get; set; } = new();
        public List<DefeatRank> defeat_rank { get; set; } = new();
        public List<DamageRank> damage_rank { get; set; } = new();
        public List<TakeDamageRank> take_damage_rank { get; set; } = new();
        public List<NormalSkillRank> normal_skill_rank { get; set; } = new();
        public List<EnergySkillRank> energy_skill_rank { get; set; } = new();
        public List<Floor> floors { get; set; } = new();
        public int total_star { get; set; }
        public bool is_unlock { get; set; }
    }

    public class DefeatRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class EnergySkillRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class Floor
    {
        public int index { get; set; }
        public string icon { get; set; } = string.Empty;
        public bool is_unlock { get; set; }
        public string settle_time { get; set; } = string.Empty;
        public int star { get; set; }
        public int max_star { get; set; }
        public List<Level> levels { get; set; } = new();
        public string settle_date_time { get; set; } = string.Empty;
        public List<string> ley_line_disorder { get; set; } = new();
    }

    public class Level
    {
        public int index { get; set; }
        public int star { get; set; }
        public int max_star { get; set; }
        public List<Battle> battles { get; set; } = new();
        public List<TopHalfFloorMonster> top_half_floor_monster { get; set; } = new();
        public List<BottomHalfFloorMonster> bottom_half_floor_monster { get; set; } = new();
    }

    public class NormalSkillRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class RevealRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class SettleDateTime
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }

    public class TakeDamageRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class TopHalfFloorMonster
    {
        public string name { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
        public int level { get; set; }
    }


}
