using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.BrowserApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App
{
    public class TravelersDiary : Base
    {
        public TravelersDiary(Account account):base(account,3000)
        {
            base.account = account;
            ServerUpdate.Elapsed += ServerUpdate_Tick;
        }
        public Model.HoYoLab.TravelersDiary.Infomation.Root Data { get; private set; } = new();
        internal async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            if (IsDisposed) return;
            ServerUpdate.Stop();
            Log.Debug("旅人手帳を取得");
            if (!account.IsAuthed)
            {
                ServerUpdate.Interval = 1000;
                ServerUpdate.Start();
                return;
            }
            try
            {
                var json = await getNote();
                Data = new() { Data = json, Message = "OK" };

            }
            catch (Account.HoYoLabAPIException ex)
            {
                Data.Message = $"HoYoLab API Error\n{ex.Message}";
                Data.Retcode = ex.Retcode;
                Log.Debug(Data.Message);
            }
            catch (Exception ex)
            {
                Data.Message = $"{ex.GetType()}\n{ex.Message}";
                Data.Retcode = ex.HResult;
                Log.Debug(Data.Message);
            }

            ServerUpdate.Interval = (account.LatestActiveSession > DateTime.UtcNow.AddHours(-2) || account.LatestActivity == Game.ProcessTime.ProcessState.Foreground) ? 300000 : 3600000 * 3;
            ServerUpdate.Start();
        }


        private async Task<Model.HoYoLab.TravelersDiary.Infomation.Data> getNote()
        {
            return (await account.Endpoint.GetTravelersDiaryInfo());
        }


    }
}
