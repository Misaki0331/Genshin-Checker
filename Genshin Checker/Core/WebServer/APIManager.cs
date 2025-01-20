using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Specialized;

namespace Genshin_Checker.Core.WebServer
{
    public static class APIManager
    {

        internal static readonly Dictionary<string, APIEndpoint> Endpoint = new();
        internal static void InitializeEndpoints()
        {
            Endpoint.Clear();
            // アプリケーション内の全てのエンドポイントを取得
            var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsSubclassOf(typeof(APIEndpoint)) && !type.IsAbstract);

            // 各コマンドクラスをインスタンス化して登録
            foreach (var commandType in commandTypes)
            {
                var command = Activator.CreateInstance(commandType) as APIEndpoint;
                if (command != null)
                {
                    RegisterEndpoint(command);
                }
            }
        }

        private static void RegisterEndpoint(APIEndpoint command)
        {
            Endpoint[command.Path.ToLower()] = command;
        }
        public static async Task GET(HttpListenerResponse response, string path, NameValueCollection param)
        {
            if (Endpoint.ContainsKey(path.ToLower()))
            {
                await Endpoint[path.ToLower()].GET(response,param);
            }
            else
            {
                await SimpleResponse.Error(response, $"Endpoint has not found.", 404);
            }

        }
    }
    public abstract class APIEndpoint
    {
        public abstract string Path { get; }
        public abstract string Description { get; }
        internal async Task GET(HttpListenerResponse response, NameValueCollection parameters)
        {
            try
            {
                await Execute(response, parameters);
            }
            catch (Exception ex)
            {
                await SimpleResponse.Error(response, $"Internal Error!\n{ex}", 500);
            }
        }
        public abstract Task Execute(HttpListenerResponse response, NameValueCollection parameters);
    }
    public static class SimpleResponse
    {
        public static async Task Error(HttpListenerResponse response, string error, int statuscode = 500)
        {
            await Result(response, new Model.API.Error.Root()
            {
                error = error
            }, statuscode);
        }
        public static async Task Result(HttpListenerResponse response, object? result, int statuscode = 200)
        {
            response.StatusCode = statuscode;
            response.ContentEncoding = Encoding.UTF8;
            var buf = Encoding.UTF8.GetBytes(
                JsonConvert.SerializeObject(result
                    )
                );
            response.ContentLength64 = buf.Length;
            using var output = response.OutputStream;
            await output.WriteAsync(buf);
        }
    }
}
