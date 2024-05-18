using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.WebServer
{
    public class WebServer
    {
        private HttpListener listener;
        public bool IsServerRun
        {
            get => listener.IsListening;
            set { if (value) WebStart(); else WebStop(); }
        }
        int Port = 29049;
        public WebServer()
        {
            listener = new HttpListener();
        }
        async Task Listen()
        {
            while (listener.IsListening)
            {
                var context = await listener.GetContextAsync();
                _ = Task.Run(() => ProcessRequest(context));
            }
        }
        public void WebStart()
        {
            if (!listener.IsListening)
            {
                listener = new HttpListener();
                listener.Prefixes.Add($"http://localhost:{Port}/");
                listener.Start();
                Task.Run(() => Listen());
            }
        }
        public void WebStop()
        {
            if (listener.IsListening) listener.Stop();
        }
        static async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            // レスポンスに書き込む内容を設定
            string? endpoint = request.Url?.AbsolutePath;
            endpoint ??= "/";
            Trace.WriteLine(endpoint);
            string[] path = endpoint.Split("/");
            byte[] buffer = Array.Empty<byte>();
            if (endpoint.StartsWith("/api/")) { 
            }
            else if (endpoint.StartsWith("/static/")) { 
            
            }
            else if (endpoint == "/favicon.ico")
            {
                    using (var ms = new MemoryStream())
                    {
                        Bitmap bmp = resource.icon.nahida.ToBitmap();
                        bmp.Save(ms, ImageFormat.Png);
                        buffer = ms.GetBuffer();
                    }
            }else if(endpoint == "/")
            {
                buffer = Encoding.UTF8.GetBytes("<html><body>Hello, World!</body></html>");
            } 
            response.ContentLength64 = buffer.Length;

            using (var output = response.OutputStream)
            {
                await output.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}
