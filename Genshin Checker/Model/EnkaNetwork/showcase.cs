using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.EnkaNetwork.ShowCase 
{ 

    public class PropMap
    {
        [JsonProperty("type")]
        public int type { get; set; }

        [JsonProperty("ival")]
        public string ival { get; set; } = string.Empty;

        [JsonProperty("val")]
        public string val { get; set; } = string.Empty;
    }

    public class AvatarInfoList
    {
        [JsonProperty("avatarId")]
        public int avatarId { get; set; }

        [JsonProperty("propMap")]
        public KeyValuePair<string,PropMap> propMap { get; set; }

        [JsonProperty("fightPropMap")]
        public KeyValuePair<string,double> fightPropMap { get; set; }

        [JsonProperty("skillDepotId")]
        public int skillDepotId { get; set; }

        [JsonProperty("inherentProudSkillList")]
        public List<int> inherentProudSkillList { get; set; } = new();

        [JsonProperty("skillLevelMap")]
        public KeyValuePair<string, int> skillLevelMap { get; set; }

        [JsonProperty("equipList")]
        public List<EquipList> equipList { get; set; } = new();

        [JsonProperty("fetterInfo")]
        public FetterInfo fetterInfo { get; set; } = new();

        [JsonProperty("talentIdList")]
        public List<int> talentIdList { get; set; } = new();
    }

    public class EquipList
    {
        [JsonProperty("itemId")]
        public int itemId { get; set; }

        [JsonProperty("reliquary")]
        public Reliquary reliquary { get; set; } = new();

        [JsonProperty("flat")]
        public Flat flat { get; set; } = new();

        [JsonProperty("weapon")]
        public Weapon weapon { get; set; } = new();
    }

    public class FetterInfo
    {
        [JsonProperty("expLevel")]
        public int expLevel { get; set; }
    }

    public class Flat
    {
        [JsonProperty("nameTextMapHash")]
        public string nameTextMapHash { get; set; } = string.Empty;

        [JsonProperty("setNameTextMapHash")]
        public string setNameTextMapHash { get; set; } = string.Empty;

        [JsonProperty("rankLevel")]
        public int rankLevel { get; set; }

        [JsonProperty("reliquaryMainstat")]
        public ReliquaryMainstat reliquaryMainstat { get; set; } = new();

        [JsonProperty("reliquarySubstats")]
        public List<ReliquarySubstat> reliquarySubstats { get; set; } = new();

        [JsonProperty("itemType")]
        public string itemType { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string icon { get; set; } = string.Empty;

        [JsonProperty("equipType")]
        public string equipType { get; set; } = string.Empty;

        [JsonProperty("weaponStats")]
        public List<WeaponStat> weaponStats { get; set; } = new();
    }

    public class Owner
    {
        [JsonProperty("hash")]
        public string hash { get; set; } = string.Empty;

        [JsonProperty("username")]
        public string username { get; set; } = string.Empty;

        [JsonProperty("profile")]
        public Profile profile { get; set; } = new();

        [JsonProperty("id")]
        public int id { get; set; }
    }

    public class PlayerInfo
    {
        [JsonProperty("nickname")]
        public string nickname { get; set; } = string.Empty;

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("signature")]
        public string signature { get; set; } = string.Empty;

        [JsonProperty("worldLevel")]
        public int worldLevel { get; set; }

        [JsonProperty("nameCardId")]
        public int nameCardId { get; set; }

        [JsonProperty("finishAchievementNum")]
        public int finishAchievementNum { get; set; }

        [JsonProperty("towerFloorIndex")]
        public int towerFloorIndex { get; set; }

        [JsonProperty("towerLevelIndex")]
        public int towerLevelIndex { get; set; }

        [JsonProperty("showAvatarInfoList")]
        public List<ShowAvatarInfoList> showAvatarInfoList { get; set; } = new();

        [JsonProperty("showNameCardIdList")]
        public List<int> showNameCardIdList { get; set; } = new();

        [JsonProperty("profilePicture")]
        public ProfilePicture profilePicture { get; set; } = new();
    }

    public class Profile
    {
        [JsonProperty("bio")]
        public string bio { get; set; } = string.Empty;

        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("signup_state")]
        public int signup_state { get; set; }

        [JsonProperty("avatar")]
        public string avatar { get; set; } = string.Empty;
    }

    public class ProfilePicture
    {
        [JsonProperty("avatarId")]
        public int avatarId { get; set; }
    }

    public class Reliquary
    {
        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("mainPropId")]
        public int mainPropId { get; set; }

        [JsonProperty("appendPropIdList")]
        public List<int> appendPropIdList { get; set; } = new();
    }

    public class ReliquaryMainstat
    {
        [JsonProperty("mainPropId")]
        public string mainPropId { get; set; } = string.Empty;

        [JsonProperty("statValue")]
        public double statValue { get; set; }
    }

    public class ReliquarySubstat
    {
        [JsonProperty("appendPropId")]
        public string appendPropId { get; set; } = string.Empty;

        [JsonProperty("statValue")]
        public double statValue { get; set; }
    }

    public class Root
    {
        [JsonProperty("playerInfo")]
        public PlayerInfo playerInfo { get; set; } = new();

        [JsonProperty("avatarInfoList")]
        public List<AvatarInfoList> avatarInfoList { get; set; } = new();

        [JsonProperty("ttl")]
        public int ttl { get; set; }

        [JsonProperty("owner")]
        public Owner owner { get; set; } = new();

        [JsonProperty("uid")]
        public string uid { get; set; }
    }

    public class ShowAvatarInfoList
    {
        [JsonProperty("avatarId")]
        public int avatarId { get; set; }

        [JsonProperty("level")]
        public int level { get; set; }
    }

    public class Weapon
    {
        [JsonProperty("level")]
        public int level { get; set; }

        [JsonProperty("promoteLevel")]
        public int promoteLevel { get; set; }

        [JsonProperty("affixMap")]
        public KeyValuePair<string, int> affixMap { get; set; }
    }

    public class WeaponStat
    {
        [JsonProperty("appendPropId")]
        public string appendPropId { get; set; } = string.Empty;

        [JsonProperty("statValue")]
        public double statValue { get; set; }
    }


}
