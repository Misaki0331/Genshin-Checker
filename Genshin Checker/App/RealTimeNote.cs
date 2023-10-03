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
using static System.Windows.Forms.AxHost;

namespace Genshin_Checker.App
{
    public class RealTimeNote
    {
        private Account account;
        public RealTimeNote(Account account) {
            this.account = account;
            ServerUpdate = new()
            {
                Interval = 100,
                Enabled = true,
            };
            ServerUpdate.Tick += ServerUpdate_Tick;
        }

        public event EventHandler<string>? Notification;
        public Genshin_Checker.App.Store.RealTimeNote.Data Data { get; private set; } = new();
        static DateTime TruncateToSeconds(DateTime dateTime)
        {
            return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));
        }
        public bool IsDisposed { get; private set; } = false;
        public void Dispose()
        {
            IsDisposed = true;
            ServerUpdate.Stop();
        }
        private async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
            try
            {
                var json = await getNote();

                    if (Data.RealTime.Resin.Current < json.max_resin && json.current_resin >= json.max_resin)
                    {
                        if (Option.Instance.Notification.RealTimeNote.ResinMax)
                            Notification?.Invoke("樹脂上限到達通知", $"現在樹脂が {json.current_resin} 貯まっています。");
                    }
                    else if (Data.RealTime.Resin.Current < 120 && json.current_resin >= 120)
                    {
                        if (Option.Instance.Notification.RealTimeNote.Resin120)
                            Notification?.Invoke("樹脂到達通知", $"現在樹脂が {json.current_resin} 貯まっています。");
                    }

                    Data.RealTime.Resin.Current = json.current_resin;
                    Data.RealTime.Resin.Max = json.max_resin;
                    if(int.TryParse(json.resin_recovery_time,out int time))
                    {
                        Data.RealTime.Resin.RecoveryTime = TruncateToSeconds(DateTime.Now).AddSeconds(time);
                        if (Data.RealTime.Resin.RecoveryTime > DateTime.Now)
                        {
                            ServerUpdate.Interval = (int)(Data.RealTime.Resin.RecoveryTime - DateTime.Now).TotalMilliseconds % 60000;
                            if (ServerUpdate.Interval < 5000) ServerUpdate.Interval = 5000;
                        }
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

                    if (Data.RealTime.RealmCoin.Current < json.max_home_coin && json.current_home_coin >= json.max_home_coin)
                    {
                        if (Option.Instance.Notification.RealTimeNote.RealmCoinMax)
                            Notification?.Invoke("塵歌壺の洞天宝銭の上限到達通知", $"洞天宝銭が現在 {json.current_home_coin} 貯まっています。");
                    }
                    else if (Data.RealTime.RealmCoin.Current < 1800 && json.current_home_coin >= 1800)
                    {
                        if (Option.Instance.Notification.RealTimeNote.RealmCoin1800)
                            Notification?.Invoke("塵歌壺の洞天宝銭の到達通知", $"洞天宝銭が現在 {json.current_home_coin} 貯まっています。");
                    }
                    Data.RealTime.RealmCoin.Current = json.current_home_coin;
                    Data.RealTime.RealmCoin.Max = json.max_home_coin;
                    if(int.TryParse(json.home_coin_recovery_time,out time))
                    {
                        Data.RealTime.RealmCoin.RecoveryTime = TruncateToSeconds(DateTime.Now).AddSeconds(time);
                        if (Data.RealTime.Resin.RecoveryTime <= DateTime.Now) 
                            Data.RealTime.Resin.RecoveryTime = DateTime.MinValue;
                    }
                    else Data.RealTime.Resin.RecoveryTime = DateTime.MinValue;
                    Data.RealTime.Commission.Current = json.finished_task_num;
                    Data.RealTime.Commission.Max = json.total_task_num;
                    Data.RealTime.Commission.IsClaimed = json.is_extra_task_reward_received;
                    Data.RealTime.DiscountResin.Current = json.remain_resin_discount_num;
                    Data.RealTime.DiscountResin.Max = json.resin_discount_num_limit;
                    if (!Data.RealTime.Transform.IsReached && json.transformer.recovery_time.reached)
                    {
                        if (Option.Instance.Notification.RealTimeNote.TransformerReached)
                            Notification?.Invoke("参量物質変化器が利用可能", $"今週の変換もお忘れなく！");
                    }
                    Data.RealTime.Transform.IsReached = json.transformer.recovery_time.reached;
                    Data.RealTime.Transform.TransformTime.Day = json.transformer.recovery_time.Day;
                    Data.RealTime.Transform.TransformTime.Hour = json.transformer.recovery_time.Hour;
                    Data.RealTime.Transform.TransformTime.Minute = json.transformer.recovery_time.Minute;
                    Data.RealTime.Transform.TransformTime.Second = json.transformer.recovery_time.Second;
                    Data.RealTime.Expedition.Dispatched.Current = json.current_expedition_num;
                    Data.RealTime.Expedition.Dispatched.Max = json.max_expedition_num;
                    int finished = 0, total = 0, finished2= 0;
                    foreach(var ex in Data.RealTime.Expedition.Expeditions)
                    {
                        total++;
                        if (ex.Status == "Finished") finished++;
                    }
                    Data.RealTime.Expedition.Expeditions.Clear();
                    foreach(var ex in json.expeditions)
                    {
                        if (ex.status == "Finished") finished2++;
                        DateTime EndTime = DateTime.MinValue;
                        if (int.TryParse(ex.remained_time, out time))
                        {
                            EndTime = TruncateToSeconds(DateTime.Now).AddSeconds(time);
                            if (EndTime <= DateTime.Now)
                                EndTime = DateTime.MinValue;
                        }
                        Data.RealTime.Expedition.Expeditions.Add(new Genshin_Checker.App.Store.RealTimeNote.ExpeditionDetail()
                        {
                            ImageURL = ex.avatar_side_icon,
                            Status = ex.status,
                            EstimatedTime = EndTime,
                        });
                    }
                    if (finished != total && finished2 == Data.RealTime.Expedition.Expeditions.Count)
                    {
                        if(Option.Instance.Notification.RealTimeNote.ExpeditionAllCompleted)
                            Notification?.Invoke("探索派遣が完了しました", $"ゲームを開き報酬を獲得してください。");
                    }
                    Data.Meta.LatestSuccess = DateTime.Now;
                    Data.Meta.Retcode = 0;
                    Data.Meta.IsAPIError = false;
                    Data.Meta.Message = "OK";

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


        const string PATH_GET_NOTES = "https://bbs-api-os.hoyolab.com/game_record/genshin/api/dailyNote";
        const string PATH_GET_CHECKIN = "https://sg-hk4e-api.hoyolab.com/event/sol/info";
        const string PATH_DO_CHECKIN = "https://sg-hk4e-api.hoyolab.com/event/sol/sign";
        const string CHECKIN_ACTID = "e202102251931481";

        public int uid { get => account.UID; }

        private readonly System.Windows.Forms.Timer ServerUpdate;

        private async Task<Model.HoYoLab.RealTimeNote.Data> getNote()
        {
            return (await account.GetRealTimeNote());
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