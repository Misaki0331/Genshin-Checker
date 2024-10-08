﻿using Genshin_Checker.App;
using Newtonsoft.Json;
using Genshin_Checker.Window.Popup;
using Genshin_Checker.App.General;

namespace Genshin_Checker.Store
{
    public class Accounts
    {
        private Accounts()
        {
            AccountAdded = null;
            AccountDatas= new();
        }
        public async void Load()
        {
            try
            {
#if DEBUG //デバッグ用にアカウント未認証
                string? str = null;
#else //リリース用に
                string? str = Registry.GetValue("Config\\UserData", "PlayerData", true);
#endif
                if (str == null) return;
                AccountDatas.Clear();
                var data = JsonChecker<List<Account.JSON.UserData>>.Check(str);
                if (data == null) return;
                foreach (var d in data)
                {
                    try
                    {
                        var ac = await App.HoYoLab.Account.GetInstance(d.Cookie, d.UID);
                        AccountDatas.Add(ac);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }catch(Exception ex)
            {
                var a=new ErrorMessage("アカウントセーブデータに異常があります。", $"{ex.GetType()}\n{ex.Message}");
                a.Show();
            }
            AccountChanges?.Invoke(null, EventArgs.Empty);
        }
        public void Save()
        {
            List<Account.JSON.UserData> list = new();
            foreach (var d in AccountDatas)
            {
                list.Add(new() { Cookie=d.Cookie, UID=d.UID });
            }
            var obj = JsonConvert.SerializeObject(list);
            Registry.SetValue("Config\\UserData", "PlayerData",obj,true);

        }
        static Accounts? _instance = null;
        public static Accounts Data { get => _instance ??= new Accounts(); }
        public int Count { get=>AccountDatas.Count; }
        public App.HoYoLab.Account this[int i]
        {
            get { return AccountDatas[i]; }
        }
        public App.HoYoLab.Account? Find(Predicate<App.HoYoLab.Account> match)
        {
            return AccountDatas.Find(match);
        }
        public void Add(App.HoYoLab.Account account)
        {
            AccountAdded?.Invoke(this, account);
            AccountDatas.Add(account);
            Save();
            AccountChanges?.Invoke(account, EventArgs.Empty);
        }
        public void Clear()
        {
            foreach(var a in AccountDatas)
                a.Dispose();
            AccountDatas.Clear();
            AccountChanges?.Invoke(null, EventArgs.Empty);
        }
        public bool Remove(App.HoYoLab.Account account)
        {
            var b = AccountDatas.Remove(account);
            Save();
            AccountRemoved?.Invoke(this, account);
            AccountChanges?.Invoke(account, EventArgs.Empty);
            return b;
        }
        private List<App.HoYoLab.Account> AccountDatas { get; set; }
        public IEnumerator<App.HoYoLab.Account> GetEnumerator()
        {
            return AccountDatas.GetEnumerator();
        }
        public event EventHandler<App.HoYoLab.Account>? AccountAdded;
        public event EventHandler<App.HoYoLab.Account>? AccountRemoved;
        public event EventHandler<EventArgs>? AccountChanges;
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
