using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Model.HoYoLab.CodeExchange
{
    public class Root : Model.HoYoLab.Root<Data>
    {
    }

    public class Data
    {
        /// <summary>
        /// メッセージ
        /// </summary>
        public string msg { get; set; } = "";
    }
}
