﻿using Genshin_Checker.resource.Languages;

namespace Genshin_Checker.App.HoYoLab
{
    public class CharacterDetail:Base
    {
        //キャッシュ時間
        const int CacheSecond = 3600*8;
        public CharacterDetail(Account account) : base(account, 5000)
        {
            ServerUpdate.Elapsed += Timeout_Tick;
            Cache = new();
            ServerUpdate.Start();
        }
        public class DataList{
            public DateTime UpdateTime;
            public int CharacterID;
            public Model.HoYoLab.CharacterDetail.Data Data=new();
        }
        List<DataList> Cache;
        Model.HoYoLab.CharacterDetailResult.Data? Cached;
        public DateTime LatestUpdateTime = DateTime.MinValue;
        readonly SemaphoreSlim UpdateSemaphore = new(1, 1);

        public bool IsAvailableUpdate { get => UpdateSemaphore.CurrentCount == 1; }
        public Exception? LatestException { get; private set; } = null;
        /// <summary>
        /// 定期実行関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Timeout_Tick(object? sender, EventArgs e)
        {
            Log.Debug($"天賦レベル取得");
            ServerUpdate.Stop();
            ServerUpdate.Interval = 3600000*6;
            if (await UpdateGameData(true)) Log.Info("キャラクターの更新に成功");
            else
            {
                ServerUpdate.Interval = 60000 * 5;
                Log.Error("キャラクターの更新に失敗");
            }
            ServerUpdate.Start();
        }
        /// <summary>
        /// HoYoLabのサーバーからキャラクターの天賦情報を取得。<br/>
        /// 1分間以内に60回以上リクエストすると429エラーが返ってくる。
        /// </summary>
        /// <param name="characterID">キャラクター番号</param>
        /// <param name="Force">強制的にサーバーから取得</param>
        /// <returns></returns>
        public async Task<Model.HoYoLab.CharacterDetail.Data> GetData(int characterID, bool Force=false, int Timeout=-1)
        {
            var CacheData = Cache.Find(a => a.CharacterID == characterID);
            Model.HoYoLab.CharacterDetail.Data Result;
            if (CacheData==null)
            {
                var data = await account.Endpoint.GetCharacterDetail(characterID);
                Cache.Add(new() { CharacterID= characterID, Data = data,UpdateTime=DateTime.UtcNow });
                Result = data;
            }
            else
            {
                if (Force || CacheData.UpdateTime.AddSeconds(Timeout < 0 ? CacheSecond : Timeout) < DateTime.UtcNow)
                {
                    var data = await account.Endpoint.GetCharacterDetail(characterID);
                    CacheData.Data = data;
                    CacheData.UpdateTime = DateTime.UtcNow;

                }
                Result = CacheData.Data;
            }
            return Result;
        }
        /// <summary>
        /// キャッシュの生成
        /// </summary>
        /// <param name="Force">キャッシュの再生成</param>
        /// <returns>成功したかどうか</returns>
        public async Task<bool> UpdateGameData(bool Force=false)
        {
            await UpdateSemaphore.WaitAsync();
            bool IsSuccessed = false;
            try
            {
                var characters = await account.Characters.GetData();
                List<int> charaids = new();
                foreach (var character in characters.avatars)
                {
                    charaids.Add(character.id);
                }
                var data2 = await account.Endpoint.GetCharactersDetail(charaids);
                Cached = data2;
                foreach (var character in characters.avatars)
                {
                    for (int i = 0; i < 30; i++)
                        try
                        {
                            var data = await GetData(character.id, Force);
                            break;
                        }
                        catch (Account.HoYoLabAPIException ex)
                        {
                            //TooManyRequestsが返ってきたら時間を空けて再リクエストを送る
                            if (ex.Retcode == 2000000429)
                            {
                                if (i == 29) throw new ArgumentException(Localize.Error_CharacterDetail_ReachedRetryCount,ex);
                                Log.Warn($"Ratelimit exceeded. please wait... {i}");
                                await Task.Delay(10000);
                            }
                            else
                                throw;
                        }
                        catch (Exception)
                        {
                            if (i == 9) throw;
                            continue;
                        }
                }
                LatestUpdateTime = DateTime.UtcNow;
                LatestException = null;
                IsSuccessed = true;
            }
            catch (Account.HoYoLabAPIException ex)
            {
                LatestException= ex;
                Log.Error($"アカウント検証エラー : {ex.Retcode} - {ex.APIMessage}");
            }
            catch (Exception ex)
            {
                LatestException = ex;
                Log.Error(ex.ToString());
            }
            finally
            {
                UpdateSemaphore.Release();
            }
            return IsSuccessed;
        }
        public List<DataList> CachedCharacters()
        {
            var list = new List<DataList>();
            foreach(var e in Cache.FindAll(a => a.UpdateTime.AddSeconds(CacheSecond) > DateTime.UtcNow))list.Add(e);
            return list;
        }
        public async Task<bool> IsReadyCacheData(int Timeout = -1)
        {
            var data = await account.Characters.GetData();
            foreach(var character in data.avatars)
            {
                var cache = Cache.Find(a => a.CharacterID == character.id &&
                a.UpdateTime.AddSeconds(Timeout < 0 ? CacheSecond : Timeout) > DateTime.UtcNow);
                if (cache==null)
                    return false;
            }
            return true;
        }
    }
}
