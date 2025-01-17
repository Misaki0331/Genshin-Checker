using Genshin_Checker.Model.UserData.ImaginariumTheater.v1;
using Genshin_Checker.Model.UserData.ImaginariumTheater.v2;
using Detail = Genshin_Checker.Model.UserData.ImaginariumTheater.v2.Detail;
using Round = Genshin_Checker.Model.UserData.ImaginariumTheater.v2.Round;
using Avatar = Genshin_Checker.Model.UserData.ImaginariumTheater.v2.Avatar;
using Buff = Genshin_Checker.Model.UserData.ImaginariumTheater.v2.Buff;

namespace Genshin_Checker.Model.UserData.ImaginariumTheater
{
    public static partial class Convert
    {
        public static V2 FromV1(V1 oldData)
        {
            V2 newData = new()
            {
                Version = 2,
                UID = oldData.UID,
                UpdateUTC = DateTime.UtcNow,
                Data = new()
                {

                    IsUnlock = oldData.Data.IsUnlock,
                    schedule_id = oldData.Data.schedule_id,
                    schedule_type = oldData.Data.schedule_type,
                    ScheduleTime = new()
                    {
                        start = oldData.Data.ScheduleTime.start,
                        end = oldData.Data.ScheduleTime.end
                    },
                    CurrentStats = new()
                    {
                        avatar_bonus_num = oldData.Data.CurrentStats.avatar_bonus_num,
                        difficulty_id = oldData.Data.CurrentStats.difficulty_id,
                        get_medal_round_list = oldData.Data.CurrentStats.get_medal_round_list.ToList(),
                        rent_cnt = oldData.Data.CurrentStats.rent_cnt,
                        medal_num = oldData.Data.CurrentStats.medal_num,
                        max_round_id = oldData.Data.CurrentStats.max_round_id,
                        heraldry = oldData.Data.CurrentStats.heraldry,
                        coin_num = oldData.Data.CurrentStats.coin_num
                    },
                    Detail = oldData.Data.Detail.Select(d => new Detail
                    {
                        rounds_data = d.rounds_data.Select(r => new Round
                        {
                            avatars = r.avatars.Select(a => new Avatar
                            {
                                avatar_id = a.avatar_id,
                                avatar_type = a.avatar_type,
                                element = a.element,
                                image = a.image,
                                level = a.level,
                                rarity = a.rarity
                            }).ToList(),
                            choice_cards = r.choice_cards.Select(b => new Buff
                            {
                                icon = b.icon,
                                name = b.name,
                                desc = b.desc,
                                is_enhanced = b.is_enhanced,
                                id = b.id
                            }).ToList(),
                            buffs = new Buffs
                            {
                                WonderSupport = r.buffs.Select(b => new Buff
                                {
                                    icon = b.icon,
                                    name = b.name,
                                    desc = b.desc,
                                    is_enhanced = b.is_enhanced,
                                    id = b.id
                                }).ToList()
                            },
                            is_get_medal = r.is_get_medal,
                            round_id = r.round_id,
                            finish_time = r.finish_time
                        }).ToList(),
                        Stats = new()
                        {
                            avatar_bonus_num = d.Stats.avatar_bonus_num,
                            difficulty_id = d.Stats.difficulty_id,
                            get_medal_round_list = d.Stats.get_medal_round_list.ToList(),
                            rent_cnt = d.Stats.rent_cnt,
                            medal_num = d.Stats.medal_num,
                            max_round_id = d.Stats.max_round_id,
                            heraldry = d.Stats.heraldry,
                            coin_num = d.Stats.coin_num
                        },
                        backup_avatars = d.backup_avatars.Select(a => new Avatar
                        {
                            avatar_id = a.avatar_id,
                            avatar_type = a.avatar_type,
                            element = a.element,
                            image = a.image,
                            level = a.level,
                            rarity = a.rarity
                        }).ToList(),
                        UpdateAt = d.UpdateAt,
                        FirstRoundTime = d.FirstRoundTime,
                        FinalRoundTime = d.FinalRoundTime
                    }).ToList()
                }
            };

            return newData;
        }
    }
}
