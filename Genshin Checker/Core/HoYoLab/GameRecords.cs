using Genshin_Checker.Model.HoYoLab.GameRecords;

namespace Genshin_Checker.Core.HoYoLab
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
                ServerUpdate.Interval = (account.LatestActiveSession > DateTime.UtcNow.AddHours(-2) || account.LatestActivity == Game.ProcessTime.ProcessState.Foreground) ? 300000 : 3600000 * 1;
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                ServerUpdate.Interval = 5000;
            }
        }

    }

}
