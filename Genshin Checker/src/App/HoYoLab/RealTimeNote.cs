using Genshin_Checker.App.General;
using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.App.Store.RealTimeNote;
using Genshin_Checker.resource.Languages;
using static Genshin_Checker.App.HoYoLab.Account;

namespace Genshin_Checker.App
{
    public class RealTimeNote
    {
        private Account account;
        public RealTimeNote(Account account) {
            this.account = account;
            ServerUpdate = new()
            {
                Interval = 3000,
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
        public void Reload()
        {
            ServerUpdate.Interval = 1;
            ServerUpdate.Start();
        }
        private async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            if (IsDisposed) return;
            ServerUpdate.Stop();
            Option.Instance.Accounts.TryGetValue(account.UID, out var config);
            config ??= new();
            try
            {
                var json = await getNote();
                if (Data.RealTime?.Resin.Current < json.max_resin && json.current_resin >= json.max_resin)
                {
                    if (config.Notify.RealTimeNotes.ResinMax)
                        Notification?.Invoke(Localize.Notify_ResinMax_Title, string.Format(Localize.Notify_Resin_Current, json.current_resin));
                }
                else
                {
                    bool IsNotify = false;
                    foreach (var Threshould in config.Notify.RealTimeNotes.ResinThreshold)
                    {
                        if (!Threshould.Enabled) continue;
                        if (Data.RealTime?.Resin.Current < Threshould.Value && json.current_resin >= Threshould.Value)
                        {
                            IsNotify = true;
                        }
                    }
                    if (IsNotify) Notification?.Invoke(Localize.Notify_ResinReached_Title, string.Format(Localize.Notify_Resin_Current, json.current_resin));

                }

                Data.RealTime ??= new();
                Data.RealTime.Resin.Current = json.current_resin;
                Data.RealTime.Resin.Max = json.max_resin;
                if (int.TryParse(json.resin_recovery_time, out int time))
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
                if (json.daily_task.attendance_visible)
                {
                    Data.RealTime.AttendanceInfo.IsUnlocked = true;
                    if (double.TryParse(json.daily_task.stored_attendance, out double storeAttendance))
                        Data.RealTime.AttendanceInfo.Stored = storeAttendance;
                    Data.RealTime.AttendanceInfo.StoredRefreshEstimatedTime = DateTime.Now.AddSeconds(json.daily_task.stored_attendance_refresh_countdown);
                    foreach(var dat in json.daily_task.attendance_rewards)
                    {
                        Data.RealTime.AttendanceInfo.Attendances.Add(new() { ProgressValue = dat.progress, State = dat.status }); ;
                    }
                }
                ServerUpdate.Start();

                if (Data.RealTime.RealmCoin.Current < json.max_home_coin && json.current_home_coin >= json.max_home_coin)
                {
                    if (config.Notify.RealTimeNotes.RealmCoinMax)
                        Notification?.Invoke(Localize.Notify_RealmCoinMax_Title, string.Format(Localize.Notify_RealmCoin_Current, json.current_home_coin));
                }
                else
                {
                    bool IsNotify = false;
                    foreach (var Threshould in config.Notify.RealTimeNotes.RealmCoinThreshold)
                    {
                        if (!Threshould.Enabled) continue;
                        if (Data.RealTime.Resin.Current < Threshould.Value && json.current_resin >= Threshould.Value)
                        {
                            IsNotify = true;
                        }
                    }
                    if (IsNotify) Notification?.Invoke(Localize.Notify_RealmCoinReached_Title, string.Format(Localize.Notify_RealmCoin_Current, json.current_home_coin));
                }
                Data.RealTime.RealmCoin.Current = json.current_home_coin;
                Data.RealTime.RealmCoin.Max = json.max_home_coin;
                if (int.TryParse(json.home_coin_recovery_time, out time))
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
                    if (config.Notify.RealTimeNotes.TransformerReached)
                        Notification?.Invoke(Localize.Notify_TransformerReached_Title, Localize.Notify_TransformerReached_Description);
                }
                Data.RealTime.Transform.IsReached = json.transformer.recovery_time.reached;
                Data.RealTime.Transform.TransformTime.Day = json.transformer.recovery_time.Day;
                Data.RealTime.Transform.TransformTime.Hour = json.transformer.recovery_time.Hour;
                Data.RealTime.Transform.TransformTime.Minute = json.transformer.recovery_time.Minute;
                Data.RealTime.Transform.TransformTime.Second = json.transformer.recovery_time.Second;
                Data.RealTime.Expedition.Dispatched.Current = json.current_expedition_num;
                Data.RealTime.Expedition.Dispatched.Max = json.max_expedition_num;
                int finished = 0, total = 0, finished2 = 0;
                foreach (var ex in Data.RealTime.Expedition.Expeditions)
                {
                    total++;
                    if (ex.Status == "Finished") finished++;
                }
                Data.RealTime.Expedition.Expeditions.Clear();
                foreach (var ex in json.expeditions)
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
                    if (config.Notify.RealTimeNotes.ExpeditionAllCompleted)
                        Notification?.Invoke(Localize.Notify_ExpeditionCompleted_Title, Localize.Notify_ExpeditionCompleted_Description);
                }
                
                Data.Meta.LatestSuccess = DateTime.Now;
                Data.Meta.Retcode = 0;
                Data.Meta.IsAPIError = false;
                Data.Meta.Message = "OK";

            }
            catch (HoYoLabAPIException ex)
            {
                Data.Meta.IsAPIError = true;
                Data.Meta.Message = ex.APIMessage;
                Data.Meta.Retcode = ex.Retcode;
            }
            catch (Exception ex)
            {
                Data.Meta.IsAPIError = false;
                Data.Meta.Message = $"{ex.GetType()}\n{ex.Message}";
                Data.Meta.Retcode = ex.HResult;
                ServerUpdate.Interval = 10000;
                ServerUpdate.Start();
            }
            
            Log.Debug($"次のサーバー情報更新は {ServerUpdate.Interval} ミリ秒後です。メッセージ : {Data.Meta.Message}");

        }


        const string PATH_GET_NOTES = "https://bbs-api-os.hoyolab.com/game_record/genshin/api/dailyNote";
        const string PATH_GET_CHECKIN = "https://sg-hk4e-api.hoyolab.com/event/sol/info";
        const string PATH_DO_CHECKIN = "https://sg-hk4e-api.hoyolab.com/event/sol/sign";
        const string CHECKIN_ACTID = "e202102251931481";

        public int uid { get => account.UID; }

        private readonly System.Windows.Forms.Timer ServerUpdate;

        private async Task<Model.HoYoLab.RealTimeNote.Data> getNote()
        {
            return (await account.Endpoint.GetRealTimeNote());
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
    public class AttendanceInfo
    {
        public bool IsUnlocked { get; set; } = false;
        public double Stored { get; set; } = double.NaN;
        public DateTime StoredRefreshEstimatedTime { get; set; } = DateTime.Now;
        public List<Attendance> Attendances { get; set; } = new();
    }
    public class Attendance
    {
        public int ProgressValue { get; set; } = 0;
        public string State { get; set; } = "";
    }
    public class RealTime
    {
        public CurrentMaxWithRecoveryTime Resin { get; set; } = new();
        public CurrentMaxWithRecoveryTime RealmCoin { get; set; } = new();
        public CurrentMaxWithIsClaimed Commission { get; set; } = new();
        public AttendanceInfo AttendanceInfo { get; set; } = new();
        public CurrentMax DiscountResin { get; set; } = new();
        public Transform Transform { get; set; } = new();
        public Expedition Expedition { get; set; } = new();
    }
    public class Data
    {
        public Meta Meta { get; set; } = new();
        public RealTime? RealTime { get; set; } = null;
    }
}