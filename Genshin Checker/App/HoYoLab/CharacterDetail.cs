using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public class CharacterDetail:Base
    {
        //キャッシュ時間
        const int CacheSecond = 3600;
        public CharacterDetail(Account account) : base(account, 1000)
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
        private async void Timeout_Tick(object? sender, EventArgs e)
        {
            Trace.WriteLine($"天賦レベル取得");
            ServerUpdate.Stop();
            ServerUpdate.Interval = 3600000;
            try
            {
                var characters = await account.Characters.GetData();
                foreach (var character in characters.avatars)
                {
                    for (int i = 0; i < 10; i++)
                        try
                        {
                            var data = await GetData(character.id);
                            Trace.WriteLine($"OK CharacterID:{character.id}");
                            break;
                        }catch (Account.HoYoLabAPIException){
                            throw;
                        }
                        catch(Exception)
                        {
                            await Task.Delay(1000);
                            if (i == 9) throw;
                            continue;
                        }
                    await Task.Delay(1000);
                }
            }
            catch (Account.HoYoLabAPIException ex)
            {
                Trace.WriteLine($"アカウント検証エラー : {ex.Retcode} - {ex.APIMessage}");
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            ServerUpdate.Start();
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
