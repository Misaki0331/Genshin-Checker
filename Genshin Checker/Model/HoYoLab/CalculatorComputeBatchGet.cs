using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.CalculatorComputeBatchGet
{
    public class Data
    {
        public List<Item> items { get; set; }
        public List<AvailableMaterial> available_material { get; set; }
        public List<OverallConsume> overall_consume { get; set; }
        public OverallMaterialConsume overall_material_consume { get; set; }
        public string jump_url { get; set; }
        public List<SingleRoleResult> single_role_result { get; set; }
        public bool has_user_info { get; set; }
    }
    public class Item
    {
        public List<AvatarConsume> avatar_consume { get; set; }
        public List<AvatarSkillConsume> avatar_skill_consume { get; set; }
        public List<object> weapon_consume { get; set; }
        public List<object> reliquary_consume { get; set; }
        public List<SkillsConsume> skills_consume { get; set; }
        public Calendar calendar { get; set; }
        public string lineup_recommend { get; set; }
    }
    public class AvailableMaterial
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int num { get; set; }
        public string wiki_url { get; set; }
        public int level { get; set; }
        public string icon_url { get; set; }
        public int lack_num { get; set; }
    }
    public class OverallConsume
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int num { get; set; }
        public string wiki_url { get; set; }
        public int level { get; set; }
        public string icon_url { get; set; }
        public int lack_num { get; set; }
    }
    public class OverallMaterialConsume
    {
        public List<AvatarConsume> avatar_consume { get; set; }
        public List<AvatarSkillConsume> avatar_skill_consume { get; set; }
        public List<object> weapon_consume { get; set; } = new(); //Todo: Make to WeaponConsume
    }
    public class SingleRoleResult
    {
        public List<Item> items { get; set; }
        public List<AvailableMaterial> available_material { get; set; }
        public List<OverallConsume> overall_consume { get; set; }
        public OverallMaterialConsume overall_material_consume { get; set; }
        public string jump_url { get; set; }
        public List<object> single_role_result { get; set; }
        public bool has_user_info { get; set; }
    }
    public class AvatarConsume
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int num { get; set; }
        public string wiki_url { get; set; }
        public int level { get; set; }
        public string icon_url { get; set; }
        public int lack_num { get; set; }
        public List<Consume> consume { get; set; }
        public List<Avatar> avatars { get; set; }
        public List<object> weapons { get; set; }
        public string material_source { get; set; }
        public Monster monster { get; set; }
        public string map_url { get; set; }
    }
    public class AvatarSkillConsume
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int num { get; set; }
        public string wiki_url { get; set; }
        public int level { get; set; }
        public string icon_url { get; set; }
        public int lack_num { get; set; }
        public List<Consume> consume { get; set; }
        public List<Avatar> avatars { get; set; }
        public List<object> weapons { get; set; }
        public string material_source { get; set; }
        public string map_url { get; set; }
        public DungeonCalendar dungeon_calendar { get; set; }
        public Monster monster { get; set; }
    }
    public class SkillsConsume
    {
        public List<ConsumeList> consume_list { get; set; }
        public SkillInfo skill_info { get; set; }
    }
    public class Calendar
    {
        public string dungeon_name { get; set; }
        public List<string> drop_day { get; set; }
        public string calendar_link { get; set; }
        public bool has_data { get; set; }
    }

    public class Avatar
    {
        public int id { get; set; }
        public string icon { get; set; }
        public int avatar_level { get; set; }
    }


    public class Consume
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int num { get; set; }
        public string wiki_url { get; set; }
        public int level { get; set; }
        public string icon_url { get; set; }
        public int lack_num { get; set; }
    }

    public class ConsumeList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int num { get; set; }
        public string wiki_url { get; set; }
        public int level { get; set; }
        public string icon_url { get; set; }
        public int lack_num { get; set; }
    }


    public class DungeonCalendar
    {
        public string dungeon_name { get; set; }
        public List<string> drop_day { get; set; }
        public string calendar_link { get; set; }
        public bool has_data { get; set; }
    }


    public class Monster
    {
        public string monster_id { get; set; }
        public string monster_name { get; set; }
        public string monster_icon { get; set; }
        public string monster_map_url { get; set; }
    }


    public class SkillInfo
    {
        public string id { get; set; }
        public string level_current { get; set; }
        public string level_target { get; set; }
    }

    public class Root : Model.HoYoLab.Root<Data>
    {
    }


}
