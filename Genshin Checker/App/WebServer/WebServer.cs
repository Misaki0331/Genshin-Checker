﻿using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources.Core;

namespace Genshin_Checker.App.WebServer
{
    public class WebServer
    {
        private Dictionary<string, System.Resources.ResourceManager> StaticResources;
        private HttpListener listener;
        public bool IsServerRun
        {
            get => listener.IsListening;
            set { if (value) WebStart(); else WebStop(); }
        }
        int Port = 29055;
        public WebServer()
        {
            listener = new HttpListener();
            StaticResources = new()
            {
                { "html", resource.WebStatic.html.ResourceManager },
                { "css", resource.WebStatic.css.ResourceManager },
                { "javascript", resource.WebStatic.javascript.ResourceManager }
            };
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
        async Task ProcessRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            // レスポンスに書き込む内容を設定
            string? endpoint = request.Url?.AbsolutePath;
            endpoint ??= "/";
            Trace.WriteLine(endpoint);
            string[] path = endpoint.Split("/");
            byte[] buffer = Array.Empty<byte>();
            if (endpoint == "/favicon.ico")
            {
                using (var ms = new MemoryStream())
                {
                    Bitmap bmp = resource.icon.nahida.ToBitmap();
                    bmp.Save(ms, ImageFormat.Png);
                    buffer = ms.GetBuffer();
                }
            } else if(path.Length>=3){
                switch (path[1])
                {
                    case "api":
                        buffer = Encoding.UTF8.GetBytes("{\"error\":\"未実装(ToDo)\"}");
                        response.StatusCode = 500;
                        break;
                    case "html":
                    case "css":
                    case "javascript":
                        var test = StaticResources[path[1]].GetString(path[2]);
                        if (test == null) response.StatusCode = 404;
                        else
                        {
                            buffer = Encoding.UTF8.GetBytes(test);
                        }
                        break;
                }
            }
            else{
                response.StatusCode = 404;
            } 
            response.ContentLength64 = buffer.Length;

            using (var output = response.OutputStream)
            {
                await output.WriteAsync(buffer, 0, buffer.Length);
            }
        }
    }
}
