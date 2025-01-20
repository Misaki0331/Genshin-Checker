using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genshin_Checker.Core.General.Convert;

namespace Genshin_Checker.Model.UserData.SpiralAbyss
{
    public static partial class Convert
    {
        public static v2.V2 FromV1(v1.V1 oldData)
        {
            var a = new v2.V2
            {
                Version = 2,
                UID = oldData.UID,
                UpdateUTC = oldData.UpdateUTC,
                Data = new v2.Data
                {
                    schedule_id = oldData.Data.schedule_id,
                    ScheduleTime = new v2.TimeRange
                    {
                        start = Time.GetUTCFromUnixTime(oldData.Data.ScheduleTime.start),
                        end = Time.GetUTCFromUnixTime(oldData.Data.ScheduleTime.end)
                    },
                    total_battle_times = oldData.Data.total_battle_times,
                    total_win_times = oldData.Data.total_win_times,
                    max_floor = oldData.Data.max_floor,
                    Ranks = new v2.Rank
                    {
                        Reveal = oldData.Data.Ranks.Reveal.Select(c => new v2.CharacterData { id = c.id, value = c.value }).ToList(),
                        Defeat = oldData.Data.Ranks.Defeat.Select(c => new v2.CharacterData { id = c.id, value = c.value }).ToList(),
                        Damage = oldData.Data.Ranks.Damage.Select(c => new v2.CharacterData { id = c.id, value = c.value }).ToList(),
                        TakeDamage = oldData.Data.Ranks.TakeDamage.Select(c => new v2.CharacterData { id = c.id, value = c.value }).ToList(),
                        NormalSkill = oldData.Data.Ranks.NormalSkill.Select(c => new v2.CharacterData { id = c.id, value = c.value }).ToList(),
                        EnergySkill = oldData.Data.Ranks.EnergySkill.Select(c => new v2.CharacterData { id = c.id, value = c.value }).ToList()
                    },
                    floors = oldData.Data.floors.Select(f => new v2.Floor
                    {
                        index = f.index,
                        is_unlock = f.is_unlock,
                        star = f.star,
                        max_star = f.max_star,
                        levels = f.levels.Select(l => new v2.Level
                        {
                            index = l.index,
                            history = new List<v2.LevelHistory>
                        {
                            new v2.LevelHistory
                            {
                                star = l.star,
                                max_star = l.max_star,
                                timestamp = Time.GetUTCFromUnixTime(l.battles.Max(b => b.timestamp)),
                                battles = l.battles.Select(b => new v2.Battle
                                {
                                    index = b.index,
                                    timestamp = Time.GetUTCFromUnixTime(b.timestamp),
                                    avatars = b.avatars.Select(c=>new v2.Avatar{id = c.id,level = c.level}).ToList()
                                }).ToList()
                            }
                        }
                        }).ToList(),
                        ley_line_disorder = f.ley_line_disorder
                    }).ToList(),
                    total_star = oldData.Data.total_star,
                    is_unlock = oldData.Data.is_unlock
                }
            };
            return a;
        }
    }
}
