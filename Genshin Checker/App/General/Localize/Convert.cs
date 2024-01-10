using Genshin_Checker.resource.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General.Localize
{
    public static class Convert
    {
        public static string MonthShort(int month)
        {
            if (month <1||month>12) return $"{month}";
            string[] res = new string[] { 
                Common.MonthShort_01, 
                Common.MonthShort_02,
                Common.MonthShort_03,
                Common.MonthShort_04,
                Common.MonthShort_05,
                Common.MonthShort_06,
                Common.MonthShort_07,
                Common.MonthShort_08,
                Common.MonthShort_09,
                Common.MonthShort_10,
                Common.MonthShort_11,
                Common.MonthShort_12,
            };
            return res[month - 1];
        }
    }
}
