using Genshin_Checker.App.General;
using Genshin_Checker.Model.UserData.TravelersDiary.EventLists;
using Genshin_Checker.Model.UserData.TravelersDiary.EventName;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genshin_Checker.Model.HoYoLab.GameRecords;

namespace Genshin_Checker.App.HoYoLab
{
    public class GameRecords : Base
    {
        public GameRecords(Account account) : base(account, 1000)
        {
            ServerUpdate.Elapsed += ServerUpdate_Tick;
        }
        public Data? Data { get; private set; } = null;
        private async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            try
            {
                var a = await account.Endpoint.GetGameRecords();
                Data = a;
                ServerUpdate.Interval = account.LatestActiveSession > DateTime.UtcNow.AddHours(-2) ? 300000 : 3600000 * 1;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
                ServerUpdate.Interval = 5000;
            }
        }

    }

}
