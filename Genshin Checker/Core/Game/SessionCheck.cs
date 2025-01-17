namespace Genshin_Checker.Core
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
            var val = Core.Registry.GetValue("Config", "TotalSessionTime");
            if (val == null) return 0;
            if (long.TryParse($"{val}", out long time)) return time;
            else return 0;
        }
        public bool Save(long time)
        {
            Core.Registry.SetValue("Config", "TotalSessionTime", time.ToString());
            return true;
        }
        public bool Append(long time)
        {
            var val = Core.Registry.GetValue("Config", "TotalSessionTime");
            if (val == null) val = "0";
            if (long.TryParse($"{val}", out long old))
            {
                Core.Registry.SetValue("Config", "TotalSessionTime", (old+time).ToString());
                return true;
            }
            Core.Registry.SetValue("Config", "TotalSessionTime", (time).ToString());

            return false;
        }
    }
}

