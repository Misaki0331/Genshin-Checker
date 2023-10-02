using Genshin_Checker.App;
using Genshin_Checker.Window;
using Newtonsoft.Json;
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
    public partial class BattleAuth : WebMiniBrowser
    {
        readonly bool IsAutoAuth = false;
        readonly Button AuthButton;
        Account? account;
        public BattleAuth(bool isAutoAuth=true,Account? account=null) : base(new("https://act.hoyolab.com/app/community-game-records-sea/index.html"), autoshow: false)
        {
            this.account= account;
            Web.CoreWebView2InitializationCompleted += Web_CoreWebView2InitializationCompleted;
            //UrlBox.Visible = false;
            Size = new(1280, 720);
            StartPosition = FormStartPosition.CenterScreen;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            panel_menu.SuspendLayout();
            panel_menu.Visible = true;
            AuthButton = new Button() { Visible = true, Text = "連携してアプリに戻る", AutoSize = true, Dock = DockStyle.Left };
            AuthButton.Click += (s, e) => { timer.Start(); AuthButton.Enabled = false; };
            panel_menu.Controls.Add(new Label() { AutoSize = false,TextAlign=ContentAlignment.MiddleLeft, Dock = DockStyle.Fill, Text = "ログインが完了したら「連携してアプリに戻る」を選択してください。その場合は自動的にこのウィンドウが閉じられます。" });
            panel_menu.Controls.Add(AuthButton);
            panel_menu.ResumeLayout(false);
            IsAutoAuth = isAutoAuth;
            if (isAutoAuth)
            {
                AuthButton.Enabled = false;
            }
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            
            if (Web.Source.ToString().StartsWith("https://act.hoyolab.com/app/community-game-records-sea/index.html"))
            {
                var data = JsonConvert.DeserializeObject<Root>(await Web.CoreWebView2.ExecuteScriptAsync("var GetUID = function(){for(var i=0;i<5;i++){var uid = document.getElementsByClassName(\"uid\"); if(uid.length!=1){throw \"No Data.\";} var id=uid[0].outerText.replace(\"UID\",\"\"); if(id.length<8){throw \"UID is empty. Please again later.\";} return id}}; \r\nvar res = {};\r\ntry{ res = {message:\"ok\",uid:GetUID(),cookie:document.cookie}}catch(e){res = {message:e,uid:null,cookie:document.cookie}} res;"));
                if (data != null && data.message == "ok" && int.TryParse(data.uid,out int uid))
                {
                    try
                    {
                        if (account != null)
                        {
                            account.Cookie = data.cookie;
                            account.UID = uid;
                        }
                        else
                        {
                            var instance = Store.Accounts.Data;
                            var a = instance.Find(account=> account.UID == uid);
                            if(a == null)
                            {
                                instance.Add(new Account(data.cookie, uid));
                            }
                            else
                            {
                                a.Cookie= data.cookie;
                            }
                            
                        }
                        timer.Stop();
                        timer.Tick -= Timer_Tick;
                        Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            timer_count++;
            if (timer_count > 10)
            {
                timer.Stop();
                AuthButton.Enabled = true;
            }
            }

        private void CoreWebView2_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
        }

        private void Web_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Web.CoreWebView2.NavigationStarting += CoreWebView2_NavigationStarting;
            Web.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
        }
        readonly System.Windows.Forms.Timer timer;
        int timer_count = 0;
        public class Root
        {
            public string cookie { get; set; } = "";
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
