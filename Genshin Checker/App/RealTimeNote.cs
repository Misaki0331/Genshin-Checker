using Genshin_Checker.App.Store.RealTimeNote;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private RealTimeNote() {
            LoadUserData();
            ServerUpdate = new()
            {
                Interval = 100,
                Enabled = true,
            };
            ServerUpdate.Tick += ServerUpdate_Tick;
        }
        public Genshin_Checker.App.Store.RealTimeNote.Data Data { get; private set; } = new();
        static DateTime TruncateToSeconds(DateTime dateTime)
        {
            return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));
        }
        private async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
            try
            {
                var json = await getNote();
                if (json.retcode == 0 && json.message == "OK")
                {
                    Data.RealTime.Resin.Current = json.data.current_resin;
                    Data.RealTime.Resin.Max = json.data.max_resin;
                    if(int.TryParse(json.data.resin_recovery_time,out int time))
                    {
                        Data.RealTime.Resin.RecoveryTime = TruncateToSeconds(DateTime.Now).AddSeconds(time);
                        if (Data.RealTime.Resin.RecoveryTime > DateTime.Now)
                            ServerUpdate.Interval = (int)(Data.RealTime.Resin.RecoveryTime - DateTime.Now).TotalMilliseconds % 60000;
                        else
                        {
                            Data.RealTime.Resin.RecoveryTime = DateTime.MinValue;
                            ServerUpdate.Interval = 60000;
                        }
                    }
                    else
                    {
                        Data.RealTime.Resin.RecoveryTime = DateTime.MinValue;
                        ServerUpdate.Interval = 60000;
                    }
                    ServerUpdate.Start();
                    Data.RealTime.RealmCoin.Current = json.data.current_home_coin;
                    Data.RealTime.RealmCoin.Max = json.data.max_home_coin;
                    if(int.TryParse(json.data.home_coin_recovery_time,out time))
                    {
                        Data.RealTime.RealmCoin.RecoveryTime = TruncateToSeconds(DateTime.Now).AddSeconds(time);
                        if (Data.RealTime.Resin.RecoveryTime <= DateTime.Now) 
                            Data.RealTime.Resin.RecoveryTime = DateTime.MinValue;
                    }
                    else Data.RealTime.Resin.RecoveryTime = DateTime.MinValue;
                    Data.RealTime.Commission.Current = json.data.finished_task_num;
                    Data.RealTime.Commission.Max = json.data.total_task_num;
                    Data.RealTime.Commission.IsClaimed = json.data.is_extra_task_reward_received;
                    Data.RealTime.DiscountResin.Current = json.data.remain_resin_discount_num;
                    Data.RealTime.DiscountResin.Max = json.data.resin_discount_num_limit;
                    Data.RealTime.Transform.IsReached = json.data.transformer.recovery_time.reached;
                    Data.RealTime.Transform.TransformTime.Day = json.data.transformer.recovery_time.Day;
                    Data.RealTime.Transform.TransformTime.Hour = json.data.transformer.recovery_time.Hour;
                    Data.RealTime.Transform.TransformTime.Minute = json.data.transformer.recovery_time.Minute;
                    Data.RealTime.Transform.TransformTime.Second = json.data.transformer.recovery_time.Second;
                    Data.RealTime.Expedition.Dispatched.Current = json.data.current_expedition_num;
                    Data.RealTime.Expedition.Dispatched.Max = json.data.max_expedition_num;
                    Data.RealTime.Expedition.Expeditions.Clear();
                    foreach(var ex in json.data.expeditions)
                    {
                        DateTime EndTime = DateTime.MinValue;
                        if (int.TryParse(ex.remained_time, out time))
                        {
                            EndTime = TruncateToSeconds(DateTime.Now).AddSeconds(time);
                            if (Data.RealTime.Resin.RecoveryTime <= DateTime.Now)
                                EndTime = DateTime.MinValue;
                        }
                        Data.RealTime.Expedition.Expeditions.Add(new Genshin_Checker.App.Store.RealTimeNote.ExpeditionDetail()
                        {
                            ImageURL = ex.avatar_side_icon,
                            Status = ex.status,
                            EstimatedTime = EndTime,
                        });
                    }
                    Data.Meta.LatestSuccess = DateTime.Now;
                    Data.Meta.Retcode = 0;
                    Data.Meta.IsAPIError = false;
                    Data.Meta.Message = "OK";
                }
                else
                {
                    Data.Meta.IsAPIError = true;
                    Data.Meta.Message = json.message;
                    Data.Meta.Retcode = json.retcode;
                    ServerUpdate.Interval = 60000;
                    ServerUpdate.Start();
                }
            }
            catch(Exception ex)
            {
                Data.Meta.IsAPIError = false;
                Data.Meta.Message = $"{ex.GetType()}\n{ex.Message}";
                Data.Meta.Retcode = ex.HResult;
                ServerUpdate.Interval = 60000;
                ServerUpdate.Start();
            }
            Trace.WriteLine($"次のサーバー情報更新は {ServerUpdate.Interval} ミリ秒後です。メッセージ : {Data.Meta.Message}");

        }

        static RealTimeNote? _instance = null;
        public static RealTimeNote Instance {get=> _instance ??= new RealTimeNote(); }

        const string PATH_GET_NOTES = "https://bbs-api-os.hoyolab.com/game_record/genshin/api/dailyNote";
        const string PATH_GET_CHECKIN = "https://sg-hk4e-api.hoyolab.com/event/sol/info";
        const string PATH_DO_CHECKIN = "https://sg-hk4e-api.hoyolab.com/event/sol/sign";
        const string CHECKIN_ACTID = "e202102251931481";

        private string Cookie = "";
        private int uid = 0;

        private readonly System.Windows.Forms.Timer ServerUpdate;

        public void SetUserData(string cookie,int uid)
        {
            if (uid < 100000000) throw new ArgumentOutOfRangeException(nameof(uid), "Invalid UID.");
            Registry.SetValue("Config\\UserData", "Cookie", cookie);
            Registry.SetValue("Config\\UserData", "UID", uid.ToString());
            this.uid = uid;
            this.Cookie = cookie;
            ServerUpdate.Stop();
            ServerUpdate.Interval = 1;
            ServerUpdate.Start();
        }
        private void LoadUserData()
        {
            var data = Registry.GetValue("Config\\UserData", "Cookie");
            if (data != null) Cookie = data;
            data = Registry.GetValue("Config\\UserData", "UID");
            if (int.TryParse(data, out int uid)) this.uid = uid;
        }

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

        static string DS()
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
        private async Task<Store.RealTimeNote.JSON.Root> getNote()
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
            var store = JsonConvert.DeserializeObject<Store.RealTimeNote.JSON.Root>(responseBody);
            if (store == null) throw new ArgumentNullException($"Couldn't deserialized. Data : \"{responseBody}\"");
            return store;
        }
        
    }
}
namespace Genshin_Checker.App.Store.RealTimeNote 
{
    public class Meta
    {
        public bool IsAPIError { get; set; } = false;
        public string Message { get; set; } = "";
        public int Retcode { get; set; } = -1;
        public DateTime LatestSuccess { get; set; } = DateTime.MinValue;
    }
    public class CurrentMax
    {
        public int Current { get; set; } = -1;
        public int Max { get; set; } = -1;
    }
    public class CurrentMaxWithRecoveryTime : CurrentMax
    {
        public DateTime RecoveryTime { get; set; } = DateTime.MinValue;
    }
    public class CurrentMaxWithIsClaimed : CurrentMax
    {
        public bool IsClaimed { get; set; } = false;
    }
    public class ExpeditionDetail
    {
        public string Status { get; set; } = "";
        public string ImageURL { get; set; } = "";
        public DateTime EstimatedTime { get; set; } = DateTime.MinValue;
    }
    public class Expedition
    {
        public CurrentMax Dispatched { get; set; } = new();
        public List<ExpeditionDetail> Expeditions { get; set; } = new();
    }
    public class Transform
    {
        public TransformTime TransformTime { get; set; } = new();
        public bool IsReached { get; set; } = false;
    }
    public class TransformTime
    {
        public int Day { get; set; } = 0;
        public int Hour { get; set; } = 0;
        public int Minute { get; set; } = 0;
        public int Second { get; set; } = 0;
    }
    public class RealTime
    {
        public CurrentMaxWithRecoveryTime Resin { get; set; } = new();
        public CurrentMaxWithRecoveryTime RealmCoin { get; set; } = new();
        public CurrentMaxWithIsClaimed Commission { get; set; } = new();
        public CurrentMax DiscountResin { get; set; } = new();
        public Transform Transform { get; set; } = new();
        public Expedition Expedition { get; set; } = new();
    }
    public class Data
    {
        public Meta Meta { get; set; } = new();
        public RealTime RealTime { get; set; } = new();
    }
}
namespace Genshin_Checker.App.Store.RealTimeNote.JSON
{
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
