using Genshin_Checker.App;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Store
{
    public class Accounts
    {
        private Accounts()
        {
            AccountAdded = null;
            AccountDatas= new();
        }
        public void Load()
        {
            var str = Registry.GetValue("Config\\UserData", "PlayerData");
            if (str == null) return;
            AccountDatas.Clear();
            var data = JsonConvert.DeserializeObject<List<Account.JSON.UserData>>(str);
            if(data == null) return;
            foreach (var d in data) {
                try
                {
                    var ac = new App.Account(d.Cookie, d.UID);
                    AccountDatas.Add(ac);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void Save()
        {
            List<Account.JSON.UserData> list = new();
            foreach (var d in AccountDatas)
            {
                list.Add(new() { Cookie=d.Cookie, UID=d.UID });
            }
            var obj = JsonConvert.SerializeObject(list);
            Registry.SetValue("Config\\UserData", "PlayerData",obj);

        }
        static Accounts? _instance = null;
        public static Accounts Data { get => _instance ??= new Accounts(); }
        public int Count { get=>AccountDatas.Count; }
        public App.Account this[int i]
        {
            get { return AccountDatas[i]; }
        }
        public App.Account? Find(Predicate<App.Account> match)
        {
            return AccountDatas.Find(match);
        }
        public void Add(App.Account account)
        {
            AccountAdded?.Invoke(this, account);
            AccountDatas.Add(account);
            Save();
        }
        public bool Remove(App.Account account)
        {
            var b = AccountDatas.Remove(account);
            Save();
            return b;
        }
        private List<App.Account> AccountDatas { get; set; }
        public IEnumerator<App.Account> GetEnumerator()
        {
            return AccountDatas.GetEnumerator();
        }
        public event EventHandler<App.Account>? AccountAdded;
    }
}
namespace Genshin_Checker.Store.Account.JSON
{
    public class UserData
    {
        //public string Name { get; set; } = string.Empty;
        public int UID { get; set; } = int.MinValue;
        public string Cookie { get; set; } = string.Empty;
    }
}
