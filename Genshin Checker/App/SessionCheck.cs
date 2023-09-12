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
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Genshin_Checker\Config");
            if (regkey == null) throw new IOException("レジストリが開けませんでした。");
            var val = regkey.GetValue("TotalSessionTime");
            regkey.Close();
            if (val == null) return 0;
            if (long.TryParse($"{val}", out long time)) return time;
            else return 0;
        }
        public bool Save(long time)
        {
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Genshin_Checker\Config",true);
            if (regkey == null) return false;
            regkey.SetValue("TotalSessionTime",time);
            regkey.Close();
            return true;
        }
        public bool Append(long time)
        {
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Genshin_Checker\Config",true);
            if (regkey == null) return false;
            var val = regkey.GetValue("TotalSessionTime");
            if (val == null) val = "0";
            if (long.TryParse($"{val}", out long old))
            {
                regkey.SetValue("TotalSessionTime", old+time);
                regkey.Close();
                return true;
            }
            regkey.Close();
            return false;
        }
    }
}

