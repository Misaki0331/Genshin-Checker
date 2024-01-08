using Genshin_Checker.App.General;
using Genshin_Checker.Model.UserData.SpiralAbyss.v1;
using HarfBuzzSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            public Model.HoYoLab.SpiralAbyss.Data Data { get; set; } = new();
            public DateTime Latest { get; set; } = DateTime.MinValue;
        }
        CacheInfo Cache;
        public SpiralAbyss(Account account) : base(account, 5000)
        {
            ServerUpdate.Tick += Timeout_Tick;
            Cache = new();
            ServerUpdate.Start();
        }
        async void Timeout_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
            try
            {
                Save(Convert(await account.Endpoint.GetSpiralAbyss(false)));
                await GetCurrent();
                ServerUpdate.Interval = 3600 * 6 * 1000;
                ServerUpdate.Start();
                return;
            }
            catch (Exception)
            {
            }
            ServerUpdate.Interval = 300000;
            ServerUpdate.Start();
        }
        public V1 Convert(Model.HoYoLab.SpiralAbyss.Data data)
        {
            var res = new V1()
            {
                Version = 1,
                UID = account.UID,
                UpdateUTC = DateTime.UtcNow,
                Data = new()
                {
                    schedule_id = data.schedule_id,
                    is_unlock = data.is_unlock,
                    total_battle_times = data.total_battle_times,
                    ScheduleTime = new() { start = int.Parse(data.start_time), end = int.Parse(data.end_time) },
                    total_win_times = data.total_win_times,
                    max_floor = data.max_floor,
                    total_star = data.total_star,
                }
            };
            foreach (var d in data.reveal_rank) res.Data.Ranks.Reveal.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.damage_rank) res.Data.Ranks.Damage.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.defeat_rank) res.Data.Ranks.Defeat.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.energy_skill_rank) res.Data.Ranks.EnergySkill.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.normal_skill_rank) res.Data.Ranks.NormalSkill.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var d in data.take_damage_rank) res.Data.Ranks.TakeDamage.Add(new() { id = d.avatar_id, value = d.value });
            foreach (var floor in data.floors)
            {
                var d = new Floor()
                {
                    index = floor.index,
                    is_unlock = floor.is_unlock,
                    max_star = floor.max_star,
                    star = floor.star,
                };
                foreach (var ley in floor.ley_line_disorder) d.ley_line_disorder.Add(ley);
                foreach (var level in floor.levels)
                {
                    var l = new Level()
                    {
                        index = level.index,
                        star = level.star,
                        max_star = level.max_star,
                    };
                    //螺旋前半
                    var top = level.top_half_floor_monster;
                    //螺旋後半
                    var bottom = level.bottom_half_floor_monster;
                    foreach (var battle in level.battles)
                    {
                        var t = int.Parse(battle.timestamp);
                        if (t > l.timestamp) l.timestamp = t;
                        var b = new Battle()
                        {
                            index = battle.index,
                            timestamp = t,
                        };
                        foreach (var avater in battle.avatars)
                        {
                            b.avatars.Add(new() { id = avater.id, level = avater.level });
                        }
                        //螺旋の敵情報
                        switch (battle.index)
                        {
                            case 1: //前半
                                foreach (var enemy in top) b.enemies.Add(new() { name = enemy.name, level = enemy.level, RemoteIconPath = enemy.icon });
                                break;
                            case 2: //後半
                                foreach (var enemy in bottom) b.enemies.Add(new() { name = enemy.name, level = enemy.level, RemoteIconPath = enemy.icon });
                                break;
                        }
                        l.battles.Add(b);
                    }
                    d.levels.Add(l);
                }
                res.Data.floors.Add(d);
            }
            return res;

        }
        public async Task<V1> GetCurrent()
        {
            if (Cache.Latest.AddMinutes(30) < DateTime.UtcNow)
            {
                var data = await account.Endpoint.GetSpiralAbyss(true);
                Cache = new() { Latest = DateTime.UtcNow, Data = data };
                try
                {
                    Save(Convert(data));
                }
                catch { }
            }
            return Convert(Cache.Data);
        }


        public async Task<V1> GetOld()
        {
            return Convert(await account.Endpoint.GetSpiralAbyss(true));
        }

        async void Save(V1 v1)
        {
            string? path = Registry.GetValue($"UserData\\{account.UID}\\SpiralAbyss", $"{v1.Data.schedule_id}",true);
            if (path == null)
            {
                path = AppData.GetRandomPath();
                Registry.SetValue($"UserData\\{account.UID}\\SpiralAbyss", $"{v1.Data.schedule_id}", path, true);

            }
            await AppData.SaveUserData(path, JsonConvert.SerializeObject(v1));

        }
        public List<int> GetList()
        {
            var strs = Registry.GetKeyNames($"UserData\\{account.UID}\\SpiralAbyss");
            var list = new List<int>();
            foreach(string str in strs)
            {
                if (int.TryParse(str, out int b)) list.Add(b);
            }
            list.Sort((a, b) => a - b);
            return list;
        }
        public async Task<V1> Load(int id)
        {
            var path = Registry.GetValue($"UserData\\{account.UID}\\SpiralAbyss", $"{id}", true);
            if (path == null) throw new IOException($"螺旋情報保管場所のデータがありません。");
            var data = await AppData.LoadUserData(path);
            var ver = JsonConvert.DeserializeObject<Model.UserData.SpiralAbyss.Root>(data??"");
            V1? v1 = (ver?.Version) switch
            {
                null => throw new InvalidDataException($"ファイルバージョン情報を解析できませんでした。"),
                1 => JsonConvert.DeserializeObject<V1>(data??""),
                _ => throw new InvalidDataException($"不明なファイルバージョン(Ver.{ver.Version})です。"),
            };
            if (v1 == null) throw new InvalidDataException($"ファイルの変換に失敗しました。");
            if (v1.UID != account.UID) throw new InvalidDataException($"ユーザーデータが異なります。({v1.UID}→{account.UID})");
            return v1;
        }
    }
}
