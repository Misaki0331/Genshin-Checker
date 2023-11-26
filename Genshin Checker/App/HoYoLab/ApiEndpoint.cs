using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Genshin_Checker.App.HoYoLab.Account;

namespace Genshin_Checker.App.HoYoLab
{
    public class ApiEndpoint
    {
        private readonly Account Account;
        internal ApiEndpoint(Account account) {
            Account = account;
        }
        /// <summary>
        /// アカウント情報を取得
        /// </summary>
        /// <param name="server">ゲームアカウントが所在しているサーバー</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Model.HoYoLab.Account.Data> GetServerAccounts(Servers server)
        {
            var url = $"https://api-account-os.hoyolab.com/binding/api/getUserGameRolesByLtoken?game_biz=hk4e_global&region={Account.Server}";
            var json = await WebRequest.HoYoGetRequest(url, Account.Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.Account.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 戦績情報
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.GameRecords.Data> GetGameRecords()
        {
            if (!Account.IsAuthed) throw new UserNotAuthenticatedException(Account.UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/api/index?server={Account.Server}&role_id={Account.UID}";
            var json = await WebRequest.HoYoGetRequest(url, Account.Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.GameRecords.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// キャラクター情報
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.Characters.Data> GetCharacters()
        {
            if (!Account.IsAuthed) throw new UserNotAuthenticatedException(Account.UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/api/character";
            string content = $"{{\"server\":\"{Account.Server}\",\"role_id\":\"{Account.UID}\"}}";
            var json = await WebRequest.HoYoPostRequest(url, Account.Cookie, content);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.Characters.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 深境螺旋情報
        /// </summary>
        /// <param name="current"><c>true</c> : 今月<br/><c>false</c> : 先月</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.SpiralAbyss.Data> GetSpiralAbyss(bool current)
        {
            if (!Account.IsAuthed) throw new UserNotAuthenticatedException(Account.UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/api/spiralAbyss?server={Account.Server}&role_id={Account.UID}&lang={Account.Culture.Name.ToLower()}&schedule_type={(current ? 1 : 2)}";
            var json = await WebRequest.HoYoGetRequest(url, Account.Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.SpiralAbyss.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// リアルタイムノート
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.RealTimeNote.Data> GetRealTimeNote()
        {
            if (!Account.IsAuthed) throw new UserNotAuthenticatedException(Account.UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/api/dailyNote?server={Account.Server}&role_id={Account.UID}";
            var json = await WebRequest.HoYoGetRequest(url, Account.Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.RealTimeNote.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 旅人手帳概要
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.TravelersDiary.Infomation.Data> GetTravelersDiaryInfo(int month = 0, CultureInfo? culture = null)
        {
            if (!Account.IsAuthed) throw new UserNotAuthenticatedException(Account.UID);
            var cul = Account.Culture.Name.ToLower();
            if (culture != null) cul = culture.Name.ToLower();
            var url = $"https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_info?region={Account.Server}&uid={Account.UID}&lang={cul}&month={month}";
            var json = await WebRequest.HoYoGetRequest(url, Account.Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.TravelersDiary.Infomation.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 旅人手帳詳細
        /// </summary>
        /// <param name="type"><c>1</c> : 原石<br/><c>2</c> : モラ</param>
        /// <param name="month">既定値 : <c>当月</c><br/>直近3か月内のデータが取得可能</param>
        /// <param name="page">既定値 : <c>1</c><br/>1から始まる全てのページ<br/>1ページ当たり20件まで取得可能</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        /// <exception cref="HoYoLabAPIException"></exception>
        public async Task<Model.HoYoLab.TravelersDiary.Detail.Data> GetTravelersDiaryDetail(int type, int page = 1, int month = 0)
        {
            if (!Account.IsAuthed) throw new UserNotAuthenticatedException(Account.UID);
            var url = $"https://sg-hk4e-api.hoyolab.com/event/ysledgeros/month_detail?region={Account.Server}&uid={Account.UID}&lang={Account.Culture.Name.ToLower()}&month={month}&type={type}&current_page={page}";
            var json = await WebRequest.HoYoGetRequest(url, Account.Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.TravelersDiary.Detail.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// キャラクター詳細情報<br/>ユーザーの天賦レベルも記載されている。
        /// </summary>
        /// <param name="characterID">キャラクター番号<br/>例 :10000089 = フリーナ</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Model.HoYoLab.CharacterDetail.Data> GetCharacterDetail(int characterID)
        {
            if (!Account.IsAuthed) throw new UserNotAuthenticatedException(Account.UID);
            var url = $"https://sg-public-api.hoyolab.com/event/calculateos/sync/avatar/detail?avatar_id={characterID}&uid={Account.UID}&region={Account.Server}&lang={Account.Culture.Name.ToLower()}";
            var json = await WebRequest.HoYoGetRequest(url, Account.Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.CharacterDetail.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// 旅の振り返りAPI
        /// </summary>
        /// <param name="since">該当DateTimeから今日までの差分を取得<br/>最大90日前まで利用可能</param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Model.HoYoLab.StellarJourney.Data> GetActiveQuery(DateTime since)
        {
            if (!Account.IsAuthed) throw new UserNotAuthenticatedException(Account.UID);
            var url = $"https://bbs-api-os.hoyolab.com/game_record/genshin/wapi/query_tool?server={Account.Server}&role_id={Account.UID}&year={since.Year}&month={since.Month:00}&day={since.Day:00}";
            var json = await WebRequest.HoYoGetRequest(url, Account.Cookie);
            var root = JsonConvert.DeserializeObject<Model.HoYoLab.StellarJourney.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            if (root.Data == null) throw new HoYoLabAPIException(root.Retcode, root.Message);
            return root.Data;
        }
        /// <summary>
        /// EnkaNetwork
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Model.EnkaNetwork.ShowCase.Root> GetEnkaNetwork()
        {
            var url = $"https://enka.network/api/uid/{Account.UID}";
            var json = await WebRequest.GeneralGetRequest(url);
            var root = JsonConvert.DeserializeObject<Model.EnkaNetwork.ShowCase.Root>(json);
            if (root == null) throw new InvalidDataException($"json形式に変換できません。\n\n--- Request URL ---\n{url}\n\n--- Received Data ---\n{json}\n--- Data End ---");
            return root;
        }
    }
}
