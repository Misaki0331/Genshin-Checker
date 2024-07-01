using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{

    public class ImaginariumTheater : Base
    {
        public ImaginariumTheater(Account account) : base(account, 300000)
        {
            ServerUpdate.Tick += Timeout_Tick;
        }
        private Model.HoYoLab.RoleCombat.Data? RoleCombat = null;
        private void Timeout_Tick(object? sender, EventArgs e)
        {
            ServerUpdate.Stop();
        }
        public async Task<Model.HoYoLab.RoleCombat.Data> GetData()
        {
            if (RoleCombat == null || !ServerUpdate.Enabled)
            {
                var data = await account.Endpoint.GetRoleCombat(true);
                RoleCombat = data;
                ServerUpdate.Start();
                return data;
            }
            else
            {
                return RoleCombat;
            }
        }
    }
}
