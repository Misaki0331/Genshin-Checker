using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.DirectX.DLL
{
    /// <summary>
    /// winuser.h tagMSG 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct tagMSG
    {
        public IntPtr hwnd;
        public uint message;
        public IntPtr wParam;
        public IntPtr lParam;
        public int time;
        public tagPOINT pt;
        public int lPrivate;
    }

    /// <summary>
    /// 仮想キーコード(winuser.h)
    /// </summary>
    public class VirtualKeyCode
    {
        //仮想キーコード表        
        public const int VK_LEFT = 0x25;
        public const int VK_UP = 0x26;
        public const int VK_RIGHT = 0x27;
        public const int VK_DOWN = 0x28;

        public const int VK_ESCAPE = 0x1B;

        public const int VK_NUMPAD0 = 0x60;
        public const int VK_NUMPAD1 = 0x61;
        public const int VK_NUMPAD2 = 0x62;
        public const int VK_NUMPAD3 = 0x63;
        public const int VK_NUMPAD4 = 0x64;
        public const int VK_NUMPAD5 = 0x65;
        public const int VK_NUMPAD6 = 0x66;
        public const int VK_NUMPAD7 = 0x67;
        public const int VK_NUMPAD8 = 0x68;
        public const int VK_NUMPAD9 = 0x69;

        public const int VK_A = 0x41;
        public const int VK_B = 0x42;
        public const int VK_C = 0x43;
        public const int VK_D = 0x44;
        public const int VK_E = 0x45;
        public const int VK_F = 0x46;
        public const int VK_G = 0x47;
        public const int VK_H = 0x48;
        public const int VK_I = 0x49;
        public const int VK_J = 0x4A;
        public const int VK_K = 0x4B;
        public const int VK_L = 0x4C;
        public const int VK_M = 0x4D;
        public const int VK_N = 0x4E;
        public const int VK_O = 0x4F;
        public const int VK_P = 0x50;
        public const int VK_Q = 0x51;
        public const int VK_R = 0x52;
        public const int VK_S = 0x53;
        public const int VK_T = 0x54;
        public const int VK_U = 0x55;
        public const int VK_V = 0x56;
        public const int VK_W = 0x57;
        public const int VK_X = 0x58;
        public const int VK_Y = 0x59;
        public const int VK_Z = 0x5A;
    }

    /// <summary>
    /// Windows メッセージ (winuser.h)
    /// </summary>
    public class WindowsMessageCode
    {
        public const int WM_NULL = 0x0000;
        public const int WM_CREATE = 0x0001;
        public const int WM_DESTROY = 0x0002;
        public const int WM_MOVE = 0x0003;
        public const int WM_SIZE = 0x0005;
        public const int WM_QUIT = 0x0012;

        public const int WM_NCCREATE = 0x0081;
        public const int WM_NCDESTROY = 0x0082;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_GETDLGCODE = 0x0087;
    }


    /// <summary>
    /// user32.dll
    /// </summary>
    public class User32
    {
        /// <summary>
        /// 読み込みDLL
        /// </summary>
        private const string DllPath = "user32.dll";


        public const int PM_NOREMOVE = 0x0000;
        public const int PM_REMOVE = 0x0001;

        [DllImport(DllPath)]
        public static extern Int16 GetAsyncKeyState(int vKey);

        [DllImport(DllPath)]
        public static extern int PeekMessage(out tagMSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

        [DllImport(DllPath)]
        public static extern int GetMessage(out tagMSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport(DllPath)]
        public static extern int TranslateMessage(ref tagMSG lpMsg);

        [DllImport(DllPath)]
        public static extern int DispatchMessage(ref tagMSG lpMsg);


    }
}
