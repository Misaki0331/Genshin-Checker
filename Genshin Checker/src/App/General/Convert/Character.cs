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
                if(characterID== 10000005 || characterID == 10000007)
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
    }
}
