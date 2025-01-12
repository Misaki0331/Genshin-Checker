using Genshin_Checker.resource.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General.Convert
{
    public static class Character
    {
        public static bool GetSkillGrowthable(int skillID, int characterID=0)
        {
            var charas = Genshin_Checker.Store.EnkaData.Data?.Characters;
            if (characterID != 0)
            {
                if(characterID== 10000005 || characterID == 10000007) //旅人
                {
                    var traveler = charas?.ToList().FindAll(a => a.Key.StartsWith($"{characterID}"));

                    foreach (var i in traveler ?? new())
                    {
                        if (i.Value.SkillOrder.FindAll(a => a == skillID).Count > 0) return true;
                    }
                }
                else
                if (charas?.TryGetValue($"{characterID}", out var chr)??false)
                {
                    return chr?.SkillOrder.FindAll(a => a == skillID).Count > 0;
                }
                return false;
            }
            foreach(var i in charas ?? new())
            {
                if (i.Value.SkillOrder.FindAll(a=>a==skillID).Count>0 ) return true;
            }
            return false;
        }
        public static int GetSkillProudMap(int skillID, int characterID = 0)
        {
            var charas = Genshin_Checker.Store.EnkaData.Data?.Characters;
            if (characterID != 0)
            {
                if (characterID == 10000005 || characterID == 10000007) //旅人
                {
                    var traveler = charas?.ToList().FindAll(a => a.Key.StartsWith($"{characterID}"));

                    foreach (var i in traveler ?? new())
                    {
                        if (i.Value.ProudMap.TryGetValue(skillID, out int result))
                        {
                            return result;
                        }
                    }
                }
                if (charas?.TryGetValue($"{characterID}", out var chr) ?? false)
                {
                    if(chr?.ProudMap.TryGetValue(skillID, out int result)??false)
                    {
                        return result;
                    }
                }
                return -1;
            }
            foreach (var i in charas ?? new())
            {
                if (i.Value.ProudMap.TryGetValue(skillID,out int result))
                {
                    return result;
                }
            }
            return -1;
        }
        public static string? GetEnkaCharaID(int skill1,int skill2,int skill3)
        {
            var charas = Genshin_Checker.Store.EnkaData.Data?.Characters;
            foreach (var i in charas ?? new())
            {
                if (i.Value.SkillOrder.FindAll(a=>a==skill1).Count>0 &&
                    i.Value.SkillOrder.FindAll(a => a == skill2).Count > 0 &&
                    i.Value.SkillOrder.FindAll(a => a == skill3).Count > 0)
                {
                    return i.Key;
                }
            }
            return null;
        }
        public static string GetWeaponTypeName(int ID)
        {
            switch (ID)
            {
                case 1:
                    return Genshin.Weapon_Sword;
                case 10:
                    return Genshin.Weapon_Catalyst;
                case 11:
                    return Genshin.Weapon_Claymore;
                case 12:
                    return Genshin.Weapon_Bow;
                case 13:
                    return Genshin.Weapon_Polearm;
                default:
                    return Common.Unknown;
            }
        }
    }
}
