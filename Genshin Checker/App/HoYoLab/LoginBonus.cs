using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public class LoginBonus:Base
    {
        public LoginBonus(Account account) : base(account, 1000)
        {
            ServerUpdate.Tick += ServerUpdate_Tick;
        }
        //ToDo: ログボ処理を書く
        private void ServerUpdate_Tick(object? sender, EventArgs e)
        {
        }
    }
}
