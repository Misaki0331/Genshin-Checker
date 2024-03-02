using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.DirectX.DLL
{
    /// <summary>
    /// windef.h  typedef struct tagPOINT
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct tagPOINT
    {
        public long x;
        public long y;
    }


    /// <summary>
    /// windef.h
    /// </summary>
    public class WinDef
    {
        public const int FALSE = 0;
        public const int TRUE = 1;
    }
}
