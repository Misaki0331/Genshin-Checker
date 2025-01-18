using Genshin_Checker.Core.HoYoLab;
using Genshin_Checker.Window;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using Genshin_Checker.GUI.Window.PopupWindow;
using Genshin_Checker.resource.Languages;
using Genshin_Checker.Core.General;

namespace Genshin_Checker.GUI.BrowserApp
{
    public partial class BattleAuth : WebMiniBrowser
    {
        readonly bool IsAutoAuth = false;
        readonly Button AuthButton;
        Account? account;
        public BattleAuth(bool isAutoAuth = true, Account? account = null) : base(new("https://act.hoyolab.com/app/community-game-records-sea/index.html"), autoshow: false)
        {
            this.account = account;
            Web.CoreWebView2InitializationCompleted += Web_CoreWebView2InitializationCompleted;
            //UrlBox.Visible = false;
            Size = new(1280, 720);
            StartPosition = FormStartPosition.CenterScreen;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            panel_menu.SuspendLayout();
            panel_menu.Visible = true;
            AuthButton = new Button() { Visible = true, Text = Localize.WindowName_BattleAuth_AuthAndBack, AutoSize = true, Dock = DockStyle.Left };
            AuthButton.Click += (s, e) => { timer.Start(); AuthButton.Enabled = false; timer_count = 0; };
            panel_menu.Controls.Add(new Label()
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Text = Localize.WindowName_BattleAuth_Message
            });
            panel_menu.Controls.Add(AuthButton);
            panel_menu.ResumeLayout(false);
            IsAutoAuth = isAutoAuth;
            if (isAutoAuth)
            {
                AuthButton.Enabled = false;
            }
            IsWebViewPopup = true;
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();

            if (Web.Source.ToString().StartsWith("https://act.hoyolab.com/app/community-game-records-sea/index.html"))
            {
                var data = JsonChecker<Root>.Check(await Web.CoreWebView2.ExecuteScriptAsync("var GetUID = function(){for(var i=0;i<5;i++){var uid = document.getElementsByClassName(\"uid\"); if(uid.length!=1){throw \"No Data.\";} var id=uid[0].outerText.replace(\"UID\",\"\"); if(id.length<8){throw \"UID is empty. Please again later.\";} return id}}; \r\nvar res = {};\r\ntry{ res = {message:\"ok\",uid:GetUID()}}catch(e){res = {message:e,uid:null}} res;"));

                var cookies = await Web.CoreWebView2.CookieManager.GetCookiesAsync("https://hoyolab.com");

                StringBuilder sb = new();
                foreach (var cookie in cookies)
                    sb.Append(cookie.Name + "=" + cookie.Value + "; ");
                string cookieString = sb.ToString();
                if (data != null && data.message == "ok" && int.TryParse(data.uid, out int uid))
                {
                    try
                    {
                        if (account != null)
                        {
                            if (account.UID != uid)
                            {
                                throw new ArgumentException(Localize.Error_BattleAuth_AccountMismatch);
                            }
                            try
                            {
                                var instance = await Account.GetInstance(cookieString, uid);
                                instance.Dispose();
                            }
                            catch
                            {
                                throw;
                            }
                            await account.Rewrite(cookieString);
                        }
                        else
                        {
                            var instance = Store.Accounts.Data;
                            var a = instance.Find(account => account.UID == uid);
                            if (a == null)
                            {
                                instance.Add(await Account.GetInstance(cookieString, uid));
                            }
                            else
                            {
                                await a.Rewrite(cookieString);
                            }

                        };
                        timer.Tick -= Timer_Tick;
                        Close();
                        timer.Stop();
                        return;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                        timer.Stop();
                        AuthButton.Enabled = true;
                        new ErrorMessage(Localize.Error_BattleAuth_FailedToAuthentication, $"{ex.Message}\n\n{ex.GetType()}\n\n{ex.StackTrace}").ShowDialog();
                        return;
                    }
                }
            }
            timer_count++;
            if (timer_count > 10)
            {
                AuthButton.Enabled = true;
                new ErrorMessage(Localize.Error_BattleAuth_CouldNotAuthentication, Localize.Error_BattleAuth_ColudNotAuthentication_Message).ShowDialog();
            }
            else
            {
                timer.Start();
            }
        }

        private void CoreWebView2_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
        }

        private void Web_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Web.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            Web.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            //常にクッキーは削除するように
#if !DEBUG
            Web.CoreWebView2.CookieManager.DeleteAllCookies();
#endif
        }
        readonly System.Windows.Forms.Timer timer;
        int timer_count = 0;
        public class Root
        {
            public string message { get; set; } = "";
            public string? uid { get; set; } = null;
        }
        private void CoreWebView2_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            if (IsAutoAuth)
            {
                AuthButton.Enabled = false;
                timer_count = 0;
                timer.Start();
            }
        }
    }
}
