using Genshin_Checker.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Genshin_Checker.BrowserApp
{
    public partial class HoYoApp : WebMiniBrowser
    {
        public HoYoApp(Uri url): base(url) 
        {
            
            Web.CoreWebView2InitializationCompleted += Web_CoreWebView2InitializationCompleted;
            UrlBox.Visible = false;
            Size = new(450, 800);
            StartPosition= FormStartPosition.CenterScreen;
        }

        private void CoreWebView2_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            Trace.WriteLine(e.Uri.ToString());
            var url = e.Uri;
            if (url.StartsWith("intent://webview?link="))
            {
                string decodedUrl = HttpUtility.UrlDecode(url.Substring(url.IndexOf("http")).Split(';')[0]);
                Web.Source= new Uri(decodedUrl);
            }
        }

        private void Web_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Web.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
            Web.CoreWebView2.FaviconChanged += CoreWebView2_FaviconChanged;
            Web.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
            Web.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            Web.CoreWebView2.Settings.UserAgent = "Mozilla/5.0 (Linux; Android 11; Pixel 4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.210 Mobile Safari/537.36";

        }

        private void CoreWebView2_NewWindowRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
        }

        private void CoreWebView2_FaviconChanged(object? sender, object e)
        {
        }

        private void CoreWebView2_DocumentTitleChanged(object? sender, object e)
        {
        }

        private void Web_InitializationCompleted(object? sender, EventArgs e)
        {
        }
        private void Web_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            //UrlBox.Text = Web.Source.ToString();
        }

        private void HoYoApp_Resize(object sender, EventArgs e)
        {
        }
    }
}
