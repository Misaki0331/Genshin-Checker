using Genshin_Checker.App.Store.RealTimeNote;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App
{
    internal class RealTimeNote
    {
        const string PATH_GET_NOTES = "https://bbs-api-os.hoyolab.com/game_record/genshin/api/dailyNote";
        const string PATH_GET_CHECKIN = "https://sg-hk4e-api.hoyolab.com/event/sol/info";
        const string PATH_DO_CHECKIN = "https://sg-hk4e-api.hoyolab.com/event/sol/sign";

        const string CHECKIN_ACTID = "e202102251931481";
        public static string Cookie = "";
        public static int uid = 0;

        private static string GetServer(int uid)
        {
            return uid.ToString()[..1] switch
            {
                "6" => "os_usa",
                "7" => "os_euro",
                "8" => "os_asia",
                "9" => "os_cht",
                _ => throw new InvalidDataException("unknown uid"),
            };
        }

        public static string DS()
        {
            const string salt = "6s25p5ox5y14umn1p61aqyyvbvvl3lrt";
            const string r = "Noelle";

            var time = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            var input = $"salt={salt}&t={time}&r={r}";
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return $"{time},Noelle,{builder}";
            }
        }
        public static async Task<Root> getNote()
        {
            string root = "sea";
            if (root == "sea") root = "https://webstatic-sea.hoyolab.com";
            else if (root == "act") root = "https://act.hoyolab.com";
            Dictionary<string, string> headers = new Dictionary<string, string>()
{
    { "Origin", root },
    { "Referer", root },
    { "Accept", "application/json, text/plain, */*" },
    { "Accept-Encoding", "None" },
    { "Accept-Language", "en-US;q=0.5" },
    { "x-rpc-app_version", "1.5.0" },
    { "x-rpc-client_type", "5" },
    { "x-rpc-language", "en-us" },
    { "User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:100.0) Gecko/20100101 Firefox/100.0" },
    { "Cookie", Cookie },
    { "DS", DS() }
};
            if (uid == 0) throw new NoNullAllowedException("ログインデータがありません。\n連携してください。");
            string role_id = uid.ToString();
            string server = GetServer(uid);
            string url = PATH_GET_NOTES;
            string query = $"role_id={role_id}&server={server}";
            string full_url = $"{url}?{query}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            HttpResponseMessage response = await client.GetAsync(full_url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var store = JsonConvert.DeserializeObject<Root>(responseBody);
            if (store == null) throw new ArgumentNullException($"Couldn't deserialized. Data : \"{responseBody}\"");
            return store;
        }
    }
}
namespace Genshin_Checker.App.Store.RealTimeNote
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {
        /// <summary>
        /// 【樹脂】<br/>現在の樹脂の数
        /// </summary>
        public int current_resin { get; set; }
        /// <summary>
        /// 【樹脂】<br/>現段階で最大まで貯まる樹脂の数
        /// </summary>
        public int max_resin { get; set; }
        /// <summary>
        /// 【樹脂】<br/>樹脂を最大まで貯めるのにかかる時間(単位：秒)
        /// </summary>
        public string resin_recovery_time { get; set; } = "";
        /// <summary>
        /// 【デイリー任務】<br/>完了済みの任務の数<br/>
        /// </summary>
        public int finished_task_num { get; set; }
        /// <summary>
        /// 【デイリー任務】<br/>現段階の任務の上限数<br/>
        /// </summary>
        public int total_task_num { get; set; }
        /// <summary>
        /// 【デイリー任務】<br/>全任務達成報酬受取済か<br/>
        /// </summary>
        public bool is_extra_task_reward_received { get; set; }
        /// <summary>
        /// 【週ボス】<br/>週ボスの残り樹脂割引回数<br/>
        /// </summary>
        public int remain_resin_discount_num { get; set; }
        /// <summary>
        /// 【週ボス】<br/>現段階の週ボスの樹脂割引上限回数<br/>
        /// </summary>
        public int resin_discount_num_limit { get; set; }
        /// <summary>
        /// 【探索派遣】<br/>探索派遣済みの人数<br/>
        /// </summary>
        public int current_expedition_num { get; set; }
        /// <summary>
        /// 【探索派遣】<br/>現状の探索派遣上限の人数<br/>
        /// </summary>
        public int max_expedition_num { get; set; }
        /// <summary>
        /// 【探索派遣】<br/>探索派遣の詳細データ<br/>
        /// </summary>
        public List<Expedition> expeditions { get; set; } = new();
        public int current_home_coin { get; set; }
        public int max_home_coin { get; set; }
        public string home_coin_recovery_time { get; set; } = "";
        public string calendar_url { get; set; } = "";
        public Transformer transformer { get; set; } = new();
    }

    public class Expedition
    {
        public string avatar_side_icon { get; set; } = "";
        public string status { get; set; } = "";
        public string remained_time { get; set; } = "";
    }

    public class RecoveryTime
    {
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public bool reached { get; set; }
    }

    public class Root
    {
        public int retcode { get; set; }
        public string message { get; set; } = "";
        public Data data { get; set; } = new();
    }

    public class Transformer
    {
        public bool obtained { get; set; }
        public RecoveryTime recovery_time { get; set; } = new();
        public string wiki { get; set; } = "";
        public bool noticed { get; set; }
        public string latest_job_id { get; set; } = "";
    }


}
