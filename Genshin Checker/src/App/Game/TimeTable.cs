using System.Text;

namespace Genshin_Checker.App
{
    public class TimeTable
    {
        public static bool UseCache { get; set; } = false;
        static DayCache DayCacheData = new();
        static readonly List<DayCache> PastDataCache = new();
        class DayCache
        {
            public DateTime date = DateTime.MinValue;
            public bool IsDateEqual(DateTime diff)
            {
                if (date.Year == diff.Year && date.Month == diff.Month && date.Day == diff.Day) return true;
                return false;
            }
            public string raw = "";
        }
        public static string LoadDate(DateTime date)
        {
            date = new(date.Year,date.Month, date.Day);
            var now = new DateTime(DateTime.UtcNow.Year,DateTime.UtcNow.Month,DateTime.UtcNow.Day);
            if (UseCache)
            {
                var cache = PastDataCache.Find(a => a.date == date);
                if (cache != null)
                    return cache.raw;
            }
            try
            {
                var data = Registry.GetValue($"TimeTable\\{date.Year}\\{date.Month:00}\\{date.Day:00}", "PlayAlias", true);
                if (data == null) throw new FileNotFoundException();

                if (data.Length != 86400) throw new InvalidCastException();
                if (UseCache&&date != now)
                    PastDataCache.Add((new DayCache() { date = date, raw = data }));
                return data;
            }
            catch
            {
                string empty1 = "";
                string empty2 = "";
                string empty3 = "";
                for (int i = 0; i < 60; i++) empty1 += " ";
                for (int i = 0; i < 60; i++) empty2 += empty1;
                for (int i = 0; i < 24; i++) empty3 += empty2;
                return empty3;
            }
        }
        public static Task<string> LoadDateLocal(DateTime date)
        {
            return Task.Run(async() =>
            {
                var rawdata = Task.Run(() => LoadDate(date));
                var timezone = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
                int offset = 0;
                string result = "";
                if (timezone > TimeSpan.Zero)
                {
                    var spare = Task.Run(() => LoadDate(date.AddDays(-1)));
                    result = await spare + await rawdata;
                    offset = 86400 - (int)timezone.TotalSeconds;
                    result = result.Substring(offset, 86400);
                }
                else if (timezone < TimeSpan.Zero)
                {
                    var spare = Task.Run(() => LoadDate(date.AddDays(1)));
                    result = await rawdata + await spare;
                    offset = -(int)timezone.TotalSeconds;
                    result = result.Substring(offset, 86400);
                }
                return result;
            });
        }
        public static bool SaveDate(DateTime date,string data)
        {
            if (data.Length != 86400) return false;
#if !DEBUG
            Registry.SetValue($"TimeTable\\{date.Year}\\{date.Month:00}\\{date.Day:00}", "PlayAlias",data,true);
#endif
            return true;
        }
        public static bool SavePoint(DateTime time, string State)
        {
            if (State.Length != 1) throw new InvalidDataException();
            try
            {
                if (!DayCacheData.IsDateEqual(time))
                {
                    DayCacheData.raw=LoadDate(time);
                    DayCacheData.date = time;
                }
                var data = DayCacheData.raw;
                int cnt = (time.Hour * 60 + time.Minute) * 60 + time.Second;
                data = ReplaceChar(data, cnt, State);
                DayCacheData.raw = data;
                SaveDate(time, data);
                return true;
            }catch
            {
            }
            return false;
        }
        static string ReplaceChar(string original, int index, string newChar)
        {
            if (newChar.Length != 1)
                throw new InvalidDataException("The third argument must be a single character.");
            if (index < 0 || index >= original.Length)
                throw new IndexOutOfRangeException("The second argument must be a valid index of the original string.");
            StringBuilder sb = new(original);
            sb[index] = newChar[0];
            return sb.ToString();
        }

    }
}
