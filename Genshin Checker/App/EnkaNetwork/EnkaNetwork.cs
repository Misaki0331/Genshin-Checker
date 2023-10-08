using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Genshin_Checker.App.HoYoLab;

namespace Genshin_Checker.App.EnkaNetwork
{
    public class EnkaNetwork
    {
        private Account account;

        public bool IsDisposed { get; private set; } = false;
        public void Dispose()
        {
            IsDisposed = true;
            ServerUpdate.Stop();
        }
        public EnkaNetwork(Account account)
        {
            this.account = account;
            ServerUpdate = new()
            {
                Interval = 10,
                Enabled = true,
            };
            ServerUpdate.Tick += ServerUpdate_Tick;
        }
        public Model.EnkaNetwork.ShowCase.Root Data { get; private set; } = new();
        private async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
            try
            {
                Data = await getNote();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

            ServerUpdate.Interval = 300000;
            ServerUpdate.Start();
        }


        public int uid { get => account.UID; }

        private readonly System.Windows.Forms.Timer ServerUpdate;

        private async Task<Model.EnkaNetwork.ShowCase.Root> getNote()
        {
            return await account.GetEnkaNetwork();
        }
    }
}
