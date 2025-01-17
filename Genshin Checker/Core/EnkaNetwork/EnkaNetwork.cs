using System.Net;
using System.Net.Http;
using Genshin_Checker.Core.HoYoLab;
using Genshin_Checker.resource.Languages;

namespace Genshin_Checker.Core.EnkaNetwork
{
    public class EnkaNetwork
    {
        private Account account;

        public bool IsDisposed { get; private set; } = false;
        public bool HasError { get => !string.IsNullOrEmpty(LatestErrorMessage); }
        public string LatestErrorMessage { get; private set; } = "";
        public void Dispose()
        {
            IsDisposed = true;
            ServerUpdate.Stop();
        }
        public EnkaNetwork(Account account)
        {
            this.account = account;
            ServerUpdate = new()
            {
                Interval = 10,
                Enabled = true,
            };
            ServerUpdate.Tick += ServerUpdate_Tick;
        }
        public Model.EnkaNetwork.ShowCase.Root Data { get; private set; } = new();
        private async void ServerUpdate_Tick(object? sender, EventArgs e)
        {
            if(uid== int.MinValue)
            {
                ServerUpdate.Interval = 100;
                return;
            }
            ServerUpdate.Stop();
            try
            {
                Data = await getNote();
                LatestErrorMessage = "";
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
            {
                LatestErrorMessage = Localize.Error_API_EnkaNetwork_400;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                LatestErrorMessage = Localize.Error_API_EnkaNetwork_404;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.FailedDependency)
            {
                LatestErrorMessage = Localize.Error_API_EnkaNetwork_424;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.TooManyRequests)
            {
                LatestErrorMessage = Localize.Error_API_EnkaNetwork_429;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.InternalServerError)
            {
                LatestErrorMessage = Localize.Error_API_EnkaNetwork_500;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                LatestErrorMessage = Localize.Error_API_EnkaNetwork_503;
            }
            catch (Exception ex)
            {
                LatestErrorMessage = $"{ex.Message}\n{ex.GetType()}";
            }

            ServerUpdate.Interval = 300000;
            ServerUpdate.Start();
        }


        public int uid { get => account.UID; }

        private readonly System.Windows.Forms.Timer ServerUpdate;

        private async Task<Model.EnkaNetwork.ShowCase.Root> getNote()
        {
            return await account.Endpoint.GetEnkaNetwork();
        }
    }
}
