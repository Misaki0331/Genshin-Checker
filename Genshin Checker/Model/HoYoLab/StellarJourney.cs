using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.StellarJourney {

    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class AchievementList
    {
        public string name { get; set; }
    }

    public class AvatarInfo
    {
        public int cur_avatar_count { get; set; }
        public int new_avatar_count { get; set; }
        public List<ChangedAvatarList> changed_avatar_list { get; set; } = new();
        public bool has_data { get; set; }
    }

    public class Begin
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }

    public class ChallengeList
    {
        public List<object> honor_avatar_list { get; set; } = new();
        public int max_win_games { get; set; }
        public Begin begin { get; set; }
        public End end { get; set; }
        public string name { get; set; }
    }

    public class ChangedAvatarList
    {
        public int id { get; set; }
        public string image { get; set; } = string.Empty;
        public bool is_new_avatar { get; set; }
        public int start_level { get; set; }
        public int end_level { get; set; }
        public int start_fetter { get; set; }
        public int end_fetter { get; set; }
        public int start_actived_constellation_num { get; set; }
        public int end_actived_constellation_num { get; set; }
        public int rarity { get; set; }
        public string element { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string icon { get; set; } = string.Empty;
    }

    public class ChangedWeaponList
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;
        public bool is_new_weapon { get; set; }
        public int rarity { get; set; }
    }

    public class ChestList
    {
        public int cur_number { get; set; }
        public int new_number { get; set; }
        public string icon { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
    }

    public class CostumeInfo
    {
        public int cur_costume_count { get; set; }
        public int new_costume_count { get; set; }
        /// <summary>
        /// 要検証
        /// </summary>
        public List<object> costume_list { get; set; } = new();
        public bool has_data { get; set; }
    }

    public class CrystalList
    {
        public int cur_number { get; set; }
        public int new_number { get; set; }
        public string icon { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
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
        public AvatarInfo avatar_info { get; set; } = new();
        public WeaponInfo weapon_info { get; set; } = new();
        public CostumeInfo costume_info { get; set; } = new();
        public ExplorationInfo exploration_info { get; set; } = new();
        public ResourceInfo resource_info { get; set; } = new();
        public HistoryStatInfo history_stat_info { get; set; } = new();
        public List<SpiralAbyssInfo> spiral_abyss_info { get; set; } = new();
        public GcgInfo gcg_info { get; set; }
    }

    public class DefeatRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class DungeonPoint
    {
        public int cur_number { get; set; }
        public int new_number { get; set; }
        public bool has_data { get; set; }
    }

    public class End
    {
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public int second { get; set; }
    }

    public class EnergySkillRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class ExplorationInfo
    {
        public List<WorldExplorationList> world_exploration_list { get; set; } = new();
        public List<CrystalList> crystal_list { get; set; } = new();
        public List<ChestList> chest_list { get; set; } = new();
        public TransPoint trans_point { get; set; } = new();
        public DungeonPoint dungeon_point { get; set; } = new();
        public bool has_data { get; set; }
    }

    public class GcgInfo
    {
        public List<object> avatar_card_list { get; set; } = new();
        public int cur_avatar_card_num { get; set; }
        public int new_avatar_card_num { get; set; }
        public List<object> action_card_list { get; set; } = new();
        public int cur_action_card_num { get; set; }
        public int new_action_card_num { get; set; }
        public List<ChallengeList> challenge_list { get; set; } = new();
        public bool has_data { get; set; }
    }

    public class HcoinSourceList
    {
        public int type { get; set; }
        public int percent { get; set; }
    }

    public class HistoryStatInfo
    {
        public int login_days { get; set; }
        public int task_num { get; set; }
        public int cur_achievement_num { get; set; }
        public int new_achievement_num { get; set; }
        public List<AchievementList> achievement_list { get; set; } = new();
        public string mostly_visit_dungeon_name { get; set; } = string.Empty;
        public int mostly_visit_dungeon_times { get; set; }
        public string mostly_visit_weekly_boss_name { get; set; } = string.Empty;
        public int mostly_visit_weekly_boss_times { get; set; }
        public bool has_data { get; set; }
    }

    public class NormalSkillRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class ResinConsumeList
    {
        public string type { get; set; } = string.Empty;
        public int percent { get; set; }
    }

    public class ResourceInfo
    {
        public int gain_scoin { get; set; }
        public int gain_hcoin { get; set; }
        public List<HcoinSourceList> hcoin_source_list { get; set; } = new();
        public int consume_resin { get; set; }
        public List<ResinConsumeList> resin_consume_list { get; set; } = new();
        public bool has_data { get; set; }
    }

    public class RevealRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class SpiralAbyssInfo
    {
        public int schedule_id { get; set; }
        public string start_time { get; set; } = string.Empty;
        public string end_time { get; set; } = string.Empty;
        public int total_battle_times { get; set; }
        public string max_floor { get; set; } = string.Empty;
        public List<RevealRank> reveal_rank { get; set; } = new();
        public List<DamageRank> damage_rank { get; set; } = new();
        public List<DefeatRank> defeat_rank { get; set; } = new();
        public List<TakeDamageRank> take_damage_rank { get; set; } = new();
        public int total_star { get; set; }
        public string name { get; set; }
        public List<NormalSkillRank> normal_skill_rank { get; set; } = new();
        public List<EnergySkillRank> energy_skill_rank { get; set; } = new();
    }

    public class TakeDamageRank
    {
        public int avatar_id { get; set; }
        public string avatar_icon { get; set; } = string.Empty;
        public int value { get; set; }
        public int rarity { get; set; }
    }

    public class TransPoint
    {
        public int cur_number { get; set; }
        public int new_number { get; set; }
        public bool has_data { get; set; }
    }

    public class WeaponInfo
    {
        public int cur_weapon_count { get; set; }
        public int new_weapon_count { get; set; }
        public List<ChangedWeaponList> changed_weapon_list { get; set; } = new();
        public bool has_data { get; set; }
    }

    public class WorldExplorationList
    {
        public int cur_number { get; set; }
        public int new_number { get; set; }
        public string icon { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
    }


}
