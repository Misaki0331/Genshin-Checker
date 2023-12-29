using Genshin_Checker.Model.UserData.SpiralAbyss.v1;
using HarfBuzzSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
        void Timeout_Tick(object? sender, EventArgs e)
        {

        }
        public static V1 Convert(Model.HoYoLab.SpiralAbyss.Data data)
        {
            var res = new V1()
            {
                Version = 1,
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
                Cache = new() { Latest = DateTime.UtcNow, Data = await account.Endpoint.GetSpiralAbyss(true) };
            return Convert(Cache.Data);
        }
    }
}
