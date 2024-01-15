using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public static class LocalizeInfo
    {
        static Model.HoYoLab.Languages? Cached = null;
        public static async Task<Model.HoYoLab.Languages> GetLanguages() {
            if (Cached != null) return Cached;
            var langs = JsonConvert.DeserializeObject<Model.HoYoLab.Languages>(await App.WebRequest.GeneralGetRequest("https://bbs-api-os.hoyolab.com/community/misc/wapi/langs"));
            if(langs == null || langs.Data == null)
            {
                throw new ArgumentNullException("No languages found.");
            }
            Cached = langs;
            return Cached;
}
    }
}
