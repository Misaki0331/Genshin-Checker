using Genshin_Checker.App.HoYoLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.General.Convert
{
    public static class ServerTime
    {
        private const int GameDailyResetTime = 4;
        public static DateTime GameServerDate(Account.Servers server)
        {
            var time = GetRegionTime(server).AddHours(-GameDailyResetTime);
            return new DateTime(time.Year, time.Month, time.Day);
        } 
        public static TimeSpan GameDailyReset(Account.Servers server)
        {
            var NextTime = GameServerDate(server).AddDays(1).AddHours(-GameDailyResetTime);
            return NextTime - DateTime.UtcNow;
        }
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
        public static TimeSpan GameWeeklyReset(Account.Servers server)
        {
            return NextWeeklyResetDate(server) - DateTime.UtcNow;
        }
        public static DateTime GetRegionTime(Account.Servers server)
        {
            return DateTime.UtcNow-ServerUTCOffset(server);
        }
        public static DateTime ConvertUTCTime(Account.Servers server, DateTime serverTime) {
            return serverTime+ServerUTCOffset(server);

        }
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
    }
}
