using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General.Convert
{
    public static class Element
    {
        public enum ElementType
        {
            Unknown = 0,
            Pyro = 1,
            Anemo = 2,
            Geo = 3,
            Dendro = 4,
            Electro = 5,
            Hydro = 6,
            Cryo = 7,
        }
        public static ElementType GetElementEnum(string? str)
        {
             if (str == null) return ElementType.Unknown; return
             str.ToLower() switch
             {
                 "anemo" => ElementType.Anemo,
                 "geo" => ElementType.Geo,
                 "electro" => ElementType.Electro,
                 "dendro" => ElementType.Dendro,
                 "hydro" => ElementType.Hydro,
                 "pyro" => ElementType.Pyro,
                 "cryo" => ElementType.Cryo,
                 _ => ElementType.Unknown,
             };
        }
        public static string GetLocalizeName(ElementType element)
        {
            //ToDo:ローカライズ用に修正
            return element switch
            {
                ElementType.Unknown => "不明",
                ElementType.Anemo => "風",
                ElementType.Geo => "岩",
                ElementType.Electro => "雷",
                ElementType.Dendro => "草",
                ElementType.Hydro => "水",
                ElementType.Pyro => "炎",
                ElementType.Cryo => "氷",
                _ => "不明"
            };
        }


        public static Color GetBackgroundColor(ElementType type)
        {
            return type switch
            {
                ElementType.Anemo => Color.FromArgb(0xDD, 0xFF, 0xDD),
                ElementType.Geo => Color.FromArgb(0xFF, 0xDD, 0xAA),
                ElementType.Electro => Color.FromArgb(0xCC, 0xAA, 0xFF),
                ElementType.Dendro => Color.FromArgb(0xAA, 0xFF, 0xAA),
                ElementType.Hydro => Color.FromArgb(0xAA, 0xCC, 0xFF),
                ElementType.Pyro => Color.FromArgb(0xFF, 0xAA, 0xAA),
                ElementType.Cryo => Color.FromArgb(0xBB, 0xFF, 0xFF),
                _ => Color.White,
            };
        }
    }
}
