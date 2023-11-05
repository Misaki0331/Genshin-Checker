using Genshin_Checker.App.HoYoLab;
using Genshin_Checker.Window;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Genshin_Checker.BrowserApp
{
    public partial class WebGameAnnounce : WebMiniBrowser
    {
        Account account;
        const string URLBase = "https://webstatic-sea.hoyoverse.com/hk4e/announcement/index.html?bundle_id=hk4e_global&channel_id=1&game=hk4e&game_biz=hk4e_global";
        public WebGameAnnounce(Account account) : base(new($"{URLBase}&lang={CultureInfo.CurrentCulture.Name[..2]}&level={account.EnkaNetwork.Data.playerInfo.level}&platform=pc&region={account.Server}&uid={account.UID}"), autoshow: false)
        {
            this.account = account;
            UrlBox.Visible = false;

            Web.CoreWebView2InitializationCompleted += Web_CoreWebView2InitializationCompleted;
            //UrlBox.Visible = false;
            Size = new(1280, 720);//System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            StartPosition = FormStartPosition.CenterScreen;
            PopupWindowSize = new(1280,720);
            IsWebViewPopup = false;
            //TopMost = true;
        }

        #region おまじない
        /*
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                const int WS_EX_LAYERED = 0x00080000;

                System.Windows.Forms.CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_LAYERED;

                return cp;
            }
        }

        // UpdateLayeredWindow関連のAPI定義
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DeleteObject(IntPtr hobject);

        public const byte AC_SRC_OVER = 0;
        public const byte AC_SRC_ALPHA = 1;
        public const int ULW_ALPHA = 2;

        // UpdateLayeredWindowで使うBLENDFUNCTION構造体の定義
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        // UpdateLayeredWindowを使うための定義
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int UpdateLayeredWindow(
            IntPtr hwnd,
            IntPtr hdcDst,
            [System.Runtime.InteropServices.In()]
            ref Point pptDst,
            [System.Runtime.InteropServices.In()]
            ref Size psize,
            IntPtr hdcSrc,
            [System.Runtime.InteropServices.In()]
            ref Point pptSrc,
            int crKey,
            [System.Runtime.InteropServices.In()]
            ref BLENDFUNCTION pblend,
            int dwFlags);


        // レイヤードウィンドウを設定する
        public void SetLayeredWindow(Bitmap srcBitmap)
        {
            // スクリーンのGraphicsと、hdcを取得
            Graphics g_sc = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc_sc = g_sc.GetHdc();

            // BITMAPのGraphicsと、hdcを取得
            Graphics g_bmp = Graphics.FromImage(srcBitmap);
            IntPtr hdc_bmp = g_bmp.GetHdc();

            // BITMAPのhdcで、サーフェイスのBITMAPを選択する
            // このとき背景を無色透明にしておく
            IntPtr oldhbmp = SelectObject(hdc_bmp, srcBitmap.GetHbitmap(Color.FromArgb(0)));

            // BLENDFUNCTION を初期化
            BLENDFUNCTION blend = new BLENDFUNCTION();
            blend.BlendOp = AC_SRC_OVER;
            blend.BlendFlags = 0;
            blend.SourceConstantAlpha = 255;
            blend.AlphaFormat = AC_SRC_ALPHA;

            // ウィンドウ位置の設定
            Point pos = new Point(this.Left, this.Top);

            // サーフェースサイズの設定
            Size surfaceSize = new Size(this.Width, this.Height);

            // サーフェース位置の設定
            Point surfacePos = new Point(0, 0);

            // レイヤードウィンドウの設定
            UpdateLayeredWindow(
                this.Handle, hdc_sc, ref pos, ref surfaceSize,
                hdc_bmp, ref surfacePos, 0, ref blend, ULW_ALPHA);

            // 後始末
            DeleteObject(SelectObject(hdc_bmp, oldhbmp));
            g_sc.ReleaseHdc(hdc_sc);
            g_sc.Dispose();
            g_bmp.ReleaseHdc(hdc_bmp);
            g_bmp.Dispose();
        }*/
        #endregion
        private void CoreWebView2_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
        }

        private void Web_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {

            //開発者ツールを無効化
            Web.CoreWebView2.Settings.AreDevToolsEnabled = false;

            Web.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            Web.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            Web.CoreWebView2.WindowCloseRequested += CoreWebView2_WindowCloseRequested;
            //WindowState = FormWindowState.Maximized;
            //FormBorderStyle = FormBorderStyle.None;
            Web.DefaultBackgroundColor = Color.Transparent;
        }

        private void CoreWebView2_WindowCloseRequested(object? sender, object e)
        {
            Close();
        }

        private void CoreWebView2_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            Web.CoreWebView2.ExecuteScriptAsync(
                "document.querySelector(\".home__close\").addEventListener(\"click\", function(){window.close();});" +
                "miHoYoGameJSSDK.openInBrowser=function(a){window.open(a)};");// +
              //  "miHoYoGameJSSDK.openInWebview=function(a){window.open(a);window.close()}");
            Text = "ゲームアナウンス";
        }
    }
}
