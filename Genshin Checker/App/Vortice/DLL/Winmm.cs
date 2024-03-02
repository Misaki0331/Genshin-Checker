using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Genshin_Checker.DirectX.DLL
{
    /// <summary>
    /// Winmm.dll
    /// </summary>
    public class Winmm
    {
        /// <summary>
        /// 読み込みDLL
        /// </summary>
        private const string DllPath = "Winmm.dll";

        [DllImport(DllPath)]
        public static extern uint timeBeginPeriod(uint uuPeriod);
    }
}
