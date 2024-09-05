using Genshin_Checker.App.HoYoLab;

namespace Genshin_Checker.App.General.Convert
{
    public static class Server
    {
        /// <summary>
        /// 毎朝4時にデイリーリセット
        /// </summary>
        private const int GameDailyResetTime = 4;
        /// <summary>
        /// サーバー内の日付を取得<br/>
        /// デイリーがリセットされる度に日付が1日増加する
        /// </summary>
        /// <param name="server">所属のサーバー</param>
        /// <returns>サーバー内日付</returns>
        public static DateTime GameServerDate(Account.Servers server)
        {
            var time = GetRegionTime(server).AddHours(-GameDailyResetTime);
            return new DateTime(time.Year, time.Month, time.Day);
        } 
        /// <summary>
        /// デイリーリセットまでの残り時間を取得
        /// </summary>
        /// <param name="server">所属のサーバー</param>
        /// <returns>残り時間</returns>
        public static TimeSpan GameDailyReset(Account.Servers server)
        {
            var NextTime = GameServerDate(server).AddDays(1).AddHours(-GameDailyResetTime);
            return NextTime - DateTime.UtcNow;
        }
        /// <summary>
        /// 次のウィークリーリセットの時間を取得
        /// </summary>
        /// <param name="server">所属のサーバー</param>
        /// <returns>リセット時刻</returns>
        public static DateTime NextWeeklyResetDate(Account.Servers server)
        {
            int days = 0;
            var date = GameServerDate(server).AddDays(1);
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(1);
                days++;
            }
            return date.AddHours(-GameDailyResetTime);
        }
        /// <summary>
        /// ウィークリーリセットまでの残り時間を取得
        /// </summary>
        /// <param name="server">所属のサーバー</param>
        /// <returns>残り時間</returns>
        public static TimeSpan GameWeeklyReset(Account.Servers server)
        {
            return NextWeeklyResetDate(server) - DateTime.UtcNow;
        }
        /// <summary>
        /// サーバーの現在時刻を取得
        /// </summary>
        /// <param name="server">所属のサーバー</param>
        /// <returns>サーバー内時刻</returns>
        public static DateTime GetRegionTime(Account.Servers server)
        {
            return DateTime.UtcNow-ServerUTCOffset(server);
        }
        /// <summary>
        /// サーバー内時刻からUTC(世界標準時刻)に変換
        /// </summary>
        /// <param name="server">所属のサーバー</param>
        /// <param name="serverTime">サーバー内時刻</param>
        /// <returns>UTC変換済みの時刻</returns>
        public static DateTime ConvertUTCTime(Account.Servers server, DateTime serverTime) {
            return serverTime+ServerUTCOffset(server);

        }
        /// <summary>
        /// サーバー毎のオフセットを取得(UTC基準)
        /// </summary>
        /// <param name="server">所属のサーバー</param>
        /// <returns>オフセット時間</returns>
        public static TimeSpan ServerUTCOffset(Account.Servers server)
        {
            return server switch
            {
                Account.Servers.os_usa => new TimeSpan(5, 0, 0),
                Account.Servers.os_euro => new TimeSpan(-1, 0, 0),
                Account.Servers.os_asia => new TimeSpan(-8, 0, 0),
                Account.Servers.os_cht => new TimeSpan(-8, 0, 0),
                _ => new TimeSpan(0, 0, 0)
            };
        }
        public static string ServerName(Account.Servers server)
        {
            return server switch
            {
                Account.Servers.os_usa => "America",
                Account.Servers.os_euro => "Europe",
                Account.Servers.os_asia => "Asia",
                Account.Servers.os_cht => "TW HK MO",
                _ => "Unknown"
            };
        }
    }
}
