using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.UserData.SpiralAbyss
{
    public class Root
    {
        public int Version { get; set; } = 1;
        public DateTime UpdateUTC { get; set; } = DateTime.UtcNow;
        public int UID { get; set; } = 0;
    }
}
