using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public class CharacterDetail:Base
    {
        //キャッシュ時間
        const int CacheSecond = 3600;
        public CharacterDetail(Account account) : base(account, 60000)
        {
            ServerUpdate.Tick += Timeout_Tick;
            Cache = new();
        }
        private class DataList{
            public DateTime ExpairTime;
            public int CharacterID;
            public Model.HoYoLab.CharacterDetail.Data Data=new();
        }
        List<DataList> Cache;
        private void Timeout_Tick(object? sender, EventArgs e)
        {
            foreach(var data in Cache.FindAll(A => A.ExpairTime < DateTime.UtcNow)) Cache.Remove(data);
        }
        public async Task<Model.HoYoLab.CharacterDetail.Data> GetData(int characterID)
        {
            var CacheData = Cache.Find(a => a.CharacterID == characterID);
            Model.HoYoLab.CharacterDetail.Data Result;
            if (CacheData==null)
            {
                var data = await account.Endpoint.GetCharacterDetail(characterID);
                Cache.Add(new() { CharacterID= characterID, Data = data,ExpairTime=DateTime.UtcNow.AddSeconds(CacheSecond) });
                ServerUpdate.Start();
                Result = data;
            }
            else
            {
                Result = CacheData.Data;
            }
            foreach (var data in Cache.FindAll(A => A.ExpairTime < DateTime.UtcNow)) Cache.Remove(data);
            return Result;
        }
    }
}
