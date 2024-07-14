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
            Trace.WriteLine("旅人手帳を取得");
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
                Trace.WriteLine(Data.Message);
            }
            catch (Exception ex)
            {
                Data.Message = $"{ex.GetType()}\n{ex.Message}";
                Data.Retcode = ex.HResult;
                Trace.WriteLine(Data.Message);
            }

            ServerUpdate.Interval = account.LatestActiveSession>DateTime.UtcNow.AddHours(-2)?300000:3600000*3;
            ServerUpdate.Start();
        }


        private async Task<Model.HoYoLab.TravelersDiary.Infomation.Data> getNote()
        {
            return (await account.Endpoint.GetTravelersDiaryInfo());
        }


    }
}
