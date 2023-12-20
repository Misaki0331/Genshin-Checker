using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Genshin_Checker.App.HoYoLab;

namespace Genshin_Checker.App.EnkaNetwork
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
                LatestErrorMessage = "UIDフォーマットが合っていません。";
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                LatestErrorMessage = "対象のプレイヤーが見つかりません。";
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.FailedDependency)
            {
                LatestErrorMessage = "アップデートによる破壊的変更が行われた為、この情報は現在利用できません。";
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.InternalServerError)
            {
                LatestErrorMessage = "サーバー内のエラーである為、現在利用できません。";
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                LatestErrorMessage = "対象の情報はサービスが一時停止中である為、現在利用できません。";
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
