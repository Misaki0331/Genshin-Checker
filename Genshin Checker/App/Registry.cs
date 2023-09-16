using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App
{
    public class Registry
    {
        public static string? GetValue(string Subkey, string key)
        {
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($"Software\\Genshin_Checker\\{Subkey}");
            if (regkey == null) throw new IOException("レジストリが開けませんでした。");
            var val = regkey.GetValue(key);
            regkey.Close();
            if(val == null) return null;
            return val.ToString();
        }

        public static void SetValue(string Subkey, string key, string value)
        {
            var regkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey($"Software\\Genshin_Checker\\{Subkey}");
            if (regkey == null) throw new IOException("レジストリが開けませんでした。");
            regkey.SetValue(key,value);
            regkey.Close();
        }
    }
}
