using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.HoYoLab
{
    public class Base
    {
        public Base(Account account,int interval) { 
            this.account = account;
            ServerUpdate = new()
            {
                Interval = interval,
                Enabled = true,
            };
        }
        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            IsDisposed = true;
            ServerUpdate.Stop();
        }
        internal Account account;
        public int uid { get => account.UID; }

        internal readonly System.Windows.Forms.Timer ServerUpdate;
    }
}
