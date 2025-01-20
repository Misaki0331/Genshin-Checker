using Genshin_Checker.Core.General;

namespace Genshin_Checker.Core.HoYoLab.Static
{
    public static class LocalizeInfo
    {
        static Model.HoYoLab.Languages? Cached = null;
        public static async Task<Model.HoYoLab.Languages> GetLanguages() {
            if (Cached != null) return Cached;
            var langs = JsonChecker<Model.HoYoLab.Languages>.Check(await Core.WebRequest.GeneralGetRequest("https://bbs-api-os.hoyolab.com/community/misc/wapi/langs"));
            if(langs == null || langs.Data == null)
            {
                throw new ArgumentNullException("No languages found.");
            }
            Cached = langs;
            return Cached;
}
    }
    public static class LoginBonusRewards
    {
        static Model.HoYoLab.DailyBonusRewards.Root? Cached = null;
        public static async Task<Model.HoYoLab.DailyBonusRewards.Root> GetRewards() {
            if (Cached != null) return Cached;
            const string Act_ID = "e202102251931481";
            var data = JsonChecker<Model.HoYoLab.DailyBonusRewards.Root>.Check(await Core.WebRequest.GeneralGetRequest($"https://sg-hk4e-api.hoyolab.com/event/sol/home?lang=ja-jp&act_id={Act_ID}"));
            if(data == null || data.Data == null)
            {
                throw new ArgumentNullException("No rewards found.");
            }
            Cached = data;
            return Cached;
}
    }
}
