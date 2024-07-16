using Genshin_Checker.App.General;
using Genshin_Checker.App.General.Convert;
using Genshin_Checker.Model.HoYoLab.RoleCombat;
using Genshin_Checker.Model.UserData;
using Genshin_Checker.Model.UserData.SpiralAbyss.v2;
using Genshin_Checker.resource.Languages;
using HarfBuzzSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public class SpiralAbyss : Base
    {
        class CacheInfo
        {
            public V2 Data { get; set; } = new();
            public DateTime Latest { get; set; } = DateTime.MinValue;
        }
        CacheInfo Cache;
        public SpiralAbyss(Account account) : base(account, 5000)
        {
            ServerUpdate.Elapsed += Timeout_Tick;
            Cache = new();
            ServerUpdate.Start();
        }
        private string REG_PATH { get => $"UserData\\{account.UID}\\SpiralAbyss"; }
        bool IsGotOldData = false;
        internal async void Timeout_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
            try
            {
                if(!IsGotOldData) await Convert(await account.Endpoint.GetSpiralAbyss(false));
                Trace.WriteLine("深境螺旋を取得");
                IsGotOldData = true;
                Cache.Data = await Convert(await account.Endpoint.GetSpiralAbyss(true));
                Cache.Latest = DateTime.Now;
                ServerUpdate.Interval = (account.LatestActiveSession > DateTime.UtcNow.AddHours(-2) || account.LatestActivity == Game.ProcessTime.ProcessState.Foreground) ? 300000 : 3600000 * 3;
                ServerUpdate.Start();
                return;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
            ServerUpdate.Interval = 300000;
            ServerUpdate.Start();
        }
        public async Task<V2> Convert(Model.HoYoLab.SpiralAbyss.Data data)
        {
            int CountOfAddBattle = 0;
            var res = await Load(data.schedule_id, false);

            bool IsEmptyData = res == null;
            res ??= new V2()
            {
                Version = 2,
                UID = account.UID,
            };

            res.UpdateUTC = DateTime.UtcNow;
            res.Data.schedule_id = data.schedule_id;
            res.Data.is_unlock = data.is_unlock;
            res.Data.total_battle_times = data.total_battle_times;
            res.Data.ScheduleTime = new()
            {
                start = Time.GetUTCFromUnixTime(long.Parse(data.start_time)),
                end = Time.GetUTCFromUnixTime(long.Parse(data.end_time))
            };
            res.Data.total_win_times = data.total_win_times;
            res.Data.max_floor = data.max_floor;
            res.Data.total_star = data.total_star;

            res.Data.Ranks = new();
            foreach (var d in data.reveal_rank) res.Data.Ranks.Reveal.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.damage_rank) res.Data.Ranks.Damage.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.defeat_rank) res.Data.Ranks.Defeat.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.energy_skill_rank) res.Data.Ranks.EnergySkill.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.normal_skill_rank) res.Data.Ranks.NormalSkill.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.take_damage_rank) res.Data.Ranks.TakeDamage.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var floor in data.floors)
            {
                var flr = res.Data.floors.Find(a => a.index == floor.index);
                bool IsNewFloor = flr == null;
                flr ??= new Floor()
                {
                    index = floor.index,
                };

                flr.is_unlock = floor.is_unlock;
                flr.max_star = floor.max_star;
                flr.star = floor.star;
                flr.ley_line_disorder.Clear();
                foreach (var ley in floor.ley_line_disorder) flr.ley_line_disorder.Add(ley);
                foreach (var level in floor.levels)
                {
                    var l = flr.levels.Find(l => l.index == level.index);
                    bool IsNewLevel = l == null;
                    l ??= new Level()
                    {
                        index = level.index,
                    };
                    var FinishTime = Time.GetUTCFromUnixTime(level.battles.Max(a => long.Parse(a.timestamp)));
                    var history = l.history.Find(a => a.timestamp == FinishTime);
                    if (history != null) continue; //同じデータを持っている可能性が高い為スキップ
                    history = new()
                    {
                        timestamp = FinishTime
                    };
                    foreach (var battle in level.battles)
                    {
                        var b = new Battle()
                        {
                            index = battle.index,
                            timestamp = Time.GetUTCFromUnixTime(long.Parse(battle.timestamp)),
                        };
                        foreach (var avater in battle.avatars)
                        {
                            b.avatars.Add(new() { id = avater.id, level = avater.level });
                        }
                        history.battles.Add(b);
                    }
                    history.max_star = level.max_star;
                    history.star = level.star;
                    l.history.Add(history);
                    CountOfAddBattle++;
                    Trace.WriteLine($"{flr.index}層{l.index}間にてデータの更新");
                    if (IsNewLevel) flr.levels.Add(l);
                }
                if (IsNewFloor) res.Data.floors.Add(flr);
            }
            if (CountOfAddBattle > 0 || IsEmptyData)
            {
                Trace.WriteLine($"保存 : {CountOfAddBattle} 個更新 / 空データ:{IsEmptyData}");
                await Save(res);
            }
            else
            {
                Trace.WriteLine("更新はありませんでした。");
            }
            return res;

        }
        public V2? GetCurrent { get => Cache.Data; }

        async Task Save(V2 v2)
        {
            string? path = Registry.GetValue(REG_PATH, $"{v2.Data.schedule_id}",true);
            if (path == null)
            {
                path = AppData.GetRandomPath();
                Registry.SetValue(REG_PATH, $"{v2.Data.schedule_id}", path, true);

            }
            await AppData.SaveUserData(path, JsonConvert.SerializeObject(v2));

        }
        public List<int> GetList()
        {
            var strs = Registry.GetKeyNames(REG_PATH);
            var list = new List<int>();
            foreach(string str in strs)
            {
                if (int.TryParse(str, out int b)) list.Add(b);
            }
            list.Sort((a, b) => a - b);
            return list;
        }
        public async Task<V2?> Load(int id, bool NoDataException=true)
        {
            var path = Registry.GetValue(REG_PATH, $"{id}", true);
            if (path == null)
            {
                if (NoDataException) throw new IOException(Localize.Error_SpiralAbyssFile_RegistryNotFound);
                else return null;
            }
            string? data = await AppData.LoadUserData(path);
            if (string.IsNullOrEmpty(data)) throw new InvalidDataException("Data is empty.");
            data ??= JsonConvert.SerializeObject(new DatabaseRoot() {Version=2,UID=account.UID });
            var ver = JsonChecker<DatabaseRoot>.Check(data);
            V2? v2 = (ver?.Version) switch
            {
                null => throw new InvalidDataException(Localize.Error_SpiralAbyssFile_InvalidFileVersion),
                1 => Model.UserData.SpiralAbyss.Convert.FromV1(JsonChecker<Model.UserData.SpiralAbyss.v1.V1>.Check(data)),
                2 => JsonChecker<V2>.Check(data),
                _ => throw new InvalidDataException(string.Format(Localize.Error_SpiralAbyssFile_UnknownFileVersion,ver.Version)),
            } ?? throw new InvalidDataException(Localize.Error_SpiralAbyssFile_FailedConvert);
            if (v2.UID != account.UID) throw new InvalidDataException(string.Format(Localize.Error_SpiralAbyssFile_DoesNotMatchUID, v2.UID, account.UID));
            if (ver.Version != 2)
            {
                Trace.WriteLine($"螺旋 {v2.Data.schedule_id} 期のデータをアップデートします...");
                try
                {
                    await Save(v2);
                    Trace.WriteLine($"→完了");
                }
                catch(Exception ex)
                {
                    Trace.WriteLine($"→失敗 {ex.Message}");
                }
            }
            return v2;
        }
    }
}
