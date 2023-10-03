using Genshin_Checker.BrowserApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App
{
    public class TravelersDiary
    {
        private Account account;

        public bool IsDisposed { get; private set; } = false;
        public void Dispose()
        {
            IsDisposed = true;
            ServerUpdate.Stop();
        }
        public TravelersDiary(Account account)
        {
            this.account = account;
            ServerUpdate = new()
            {
                Interval = 10,
                Enabled = true,
            };
            ServerUpdate.Tick += ServerUpdate_Tick;
        }
        public Model.HoYoLab.TravelersDiary.Infomation.Root Data { get; private set; } = new();
        private async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
            try
            {
                var json = await getNote();
                Data = new() { Data = json, Message = "OK" };

            }
            catch (Account.HoYoLabAPIException ex)
            {
                Data.Message = $"HoYoLab API Error\n{ex.Message}";
                Data.Retcode = ex.Retcode;
            }
            catch (Exception ex)
            {
                Data.Message = $"{ex.GetType()}\n{ex.Message}";
                Data.Retcode = ex.HResult;
            }

            ServerUpdate.Interval = 300000;
            ServerUpdate.Start();
        }


        public int uid { get => account.UID; }

        private readonly System.Windows.Forms.Timer ServerUpdate;

        private async Task<Model.HoYoLab.TravelersDiary.Infomation.Data> getNote()
        {
            return (await account.GetTravelersDiaryInfo());
        }


    }
}
