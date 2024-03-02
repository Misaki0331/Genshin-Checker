using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.MainMaterial
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }
    public class BannerList
    {
        public string id { get; set; } = "";
        public string img_url { get; set; } = "";
        public string title { get; set; } = "";
        public string app_path { get; set; } = "";
        public string web_path { get; set; } = "";
        public string color { get; set; } = "";
        public List<int> game_id { get; set; } = new();
    }

    public class Bonuse
    {
        public string exchange_group_id { get; set; } = "";
        public string exchange_code { get; set; } = "";
        public string code_status { get; set; } = "";
        public int offline_at { get; set; }
        public List<IconBonuse> icon_bonuses { get; set; } = new();
    }

    public class BonusesSummary
    {
        public List<IconBonuse> icon_bonuses { get; set; } = new();
        public int code_count { get; set; }
    }

    public class Data
    {
        public List<Module> modules { get; set; } = new();
        public List<object> in_feed_modules { get; set; } = new();
        public string server_time { get; set; } = "";
    }

    public class Deeplink
    {
        public string app_path { get; set; } = "";
        public string web_path { get; set; } = "";
    }

    public class ExchangeGroup
    {
        public string id { get; set; } = "";
        public BonusesSummary bonuses_summary { get; set; } = new();
        public List<Bonuse> bonuses { get; set; } = new();
        public string title { get; set; } = "";
        public int game_id { get; set; }
        public string group_status { get; set; } = "";
        public int offline_at { get; set; }
        public string reason { get; set; } = "";
        public int publish_at { get; set; }
        public string @operator { get; set; } = "";
        public int created_at { get; set; }
        public int updated_at { get; set; }
    }

    public class IconBonuse
    {
        public int bonus_num { get; set; }
        public string icon_url { get; set; } = "";
    }

    public class Module
    {
        public string id { get; set; } = "";
        public int module_type { get; set; }
        public List<BannerList> banner_list { get; set; } = new();
        public List<object> guide_collection_list { get; set; } = new();
        public List<object> post_list { get; set; } = new();
        public List<StructuredGuideList> structured_guide_list { get; set; } = new();
        public string name { get; set; } = "";
        public int in_feed_position { get; set; }
        public TabInfo tab_info { get; set; }
        public int show_style { get; set; }
        public bool new_remind { get; set; }
        public string new_remind_end_time { get; set; }
        public ExchangeGroup exchange_group { get; set; }
    }

    public class StructuredGuideList
    {
        public string id { get; set; }
        public string cover { get; set; }
        public string title { get; set; }
        public Deeplink deeplink { get; set; }
        public List<SubCardList> sub_card_list { get; set; }
        public string show_style_small_bg { get; set; }
        public string show_style_small_color { get; set; }
        public bool new_remind { get; set; }
        public string new_remind_end_time { get; set; }
    }

    public class SubCardList
    {
        public string id { get; set; }
        public string title { get; set; }
        public Deeplink deeplink { get; set; }
        public int type { get; set; }
    }

    public class TabInfo
    {
        public List<TabList> tab_list { get; set; }
        public string page_name { get; set; }
    }

    public class TabList
    {
        public string id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
    }


}
