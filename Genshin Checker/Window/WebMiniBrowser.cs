using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genshin_Checker.Window
{
    public partial class WebMiniBrowser : Form
    {
        internal Uri DefaultUri;
        internal bool IsWebViewPopup = false;
        public WebMiniBrowser(Uri uri, bool autoshow=true)
        {
            DefaultUri = uri;
            //Web.CoreWebView2InitializationCompleted += Web_InitializationCompleted;
            InitializeComponent();
            Web.CoreWebView2InitializationCompleted += Web_CoreWebView2InitializationCompleted;

            Web.Source = DefaultUri;
            if (autoshow)
            {
                Show();
                Activate();
            }
        }

        private void Web_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Web.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
            Web.CoreWebView2.FaviconChanged += CoreWebView2_FaviconChanged;
            Web.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;

        }

        private void CoreWebView2_NewWindowRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs e)
        {
            if (!IsWebViewPopup)
            {
                e.Handled = true;
                new WebMiniBrowser(new(e.Uri));
            }
        }

        private async void CoreWebView2_FaviconChanged(object? sender, object e)
        {
            using var fs = await Web.CoreWebView2.GetFaviconAsync(Microsoft.Web.WebView2.Core.CoreWebView2FaviconImageFormat.Png);
            Icon = Icon.FromHandle(new Bitmap(Image.FromStream(fs)).GetHicon());
        }

        private void CoreWebView2_DocumentTitleChanged(object? sender, object e)
        {
            Text = Web.CoreWebView2.DocumentTitle;
        }

        private void Web_InitializationCompleted(object? sender, EventArgs e)
        {
        }
        private void Web_SourceChanged(object sender, Microsoft.Web.WebView2.Core.CoreWebView2SourceChangedEventArgs e)
        {
            UrlBox.Text = Web.Source.ToString();
        }
    }
}
