using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General.Convert
{
    public static class Rarity
    {
        public enum RarityType
        {
            Common = 1,
            Uncommon = 2,
            Rare = 3,
            Epic = 4,
            Legendary = 5,
            Special = 6,
            Unknown = 0
        }
        public static RarityType GetRarityType(int id)
        {
            return id switch
            {
                1 => RarityType.Common,
                2 => RarityType.Uncommon,
                3 => RarityType.Rare,
                4 => RarityType.Epic,
                5 => RarityType.Legendary,
                _ => RarityType.Unknown,
            };
        }
        public static Color GetBackgroundColor(RarityType type)
        {
            return type switch
            {
                RarityType.Common => Color.LightGray,
                RarityType.Uncommon => Color.FromArgb(0xFF, 0xAA, 0xFF, 0xAA),
                RarityType.Rare => Color.FromArgb(0xFF, 0xAA, 0xFF, 0xFF),
                RarityType.Epic => Color.FromArgb(0xFF, 0xDD, 0xCC, 0xFF),
                RarityType.Legendary => Color.FromArgb(0xFF, 0xFF, 0xEE, 0xAA),
                RarityType.Special => Color.FromArgb(0xFF, 0xFF, 0xAA, 0xDD),
                _ => Color.White
            };
        }

    }
}
