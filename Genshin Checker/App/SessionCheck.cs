using Genshin_Checker.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Genshin_Checker.App.ProcessTime;

namespace Genshin_Checker.App
{
    internal class SessionCheck
    {
        private SessionCheck()
        {

        }
        static SessionCheck? instance = null;
        public static SessionCheck Instance { get => instance ??= new SessionCheck(); }
        public long Load()
        {
            var val = App.Registry.GetValue("Config", "TotalSessionTime");
            if (val == null) return 0;
            if (long.TryParse($"{val}", out long time)) return time;
            else return 0;
        }
        public bool Save(long time)
        {
            App.Registry.SetValue("Config", "TotalSessionTime", time.ToString());
            return true;
        }
        public bool Append(long time)
        {
            var val = App.Registry.GetValue("Config", "TotalSessionTime");
            if (val == null) val = "0";
            if (long.TryParse($"{val}", out long old))
            {
                App.Registry.SetValue("Config", "TotalSessionTime", (old+time).ToString());
                return true;
            }
            App.Registry.SetValue("Config", "TotalSessionTime", (time).ToString());

            return false;
        }
    }
}

