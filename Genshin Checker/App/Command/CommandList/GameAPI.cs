using Genshin_Checker.App.Game;
using Genshin_Checker.App.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.Command.CommandList
{
    public class GameAPI : Command
    {
        public override string Name => "game-api";
        public override string Description => "ゲーム内APIを取得します。";

        public override async Task Execute(params string[] parameters)
        {
            if (parameters.Length == 1)
            {
                Console("AuthKey -> アカウントセンターの認証キーを取得");
                Console("Account -> アカウント情報を表示します。");
                Console("Monthly-Card -> 祝福のログを表示します。");
                return;
            }
            switch (parameters[1].ToLower())
            {
                case "authkey":
                    Console($"{await WebViewWatcher.GetServiceCenterAuthKey()}");
                    break;
                case "account":
                    { 
                        var authkey = await WebViewWatcher.GetServiceCenterAuthKey();
                        if (authkey == null)
                        {
                            Console("Error : 認証キーが見つかりませんでした。ゲーム内で報告ボタンを押して再度実行してください。");
                            return;
                        }
                        var data = await App.Game.GameAPI.GetAccountInfo(authkey);
                        Console($"Server : {data.region}");
                        Console($"UID : {data.uid}");
                        Console($"Name : {data.nickname}");
                        Console($"通行証ID : {data.aid}");
                    };
                    break;
                case "monthly-card":
                    {
                        var authkey = await WebViewWatcher.GetServiceCenterAuthKey();
                        if (authkey == null)
                        {
                            Console("Error : 認証キーが見つかりませんでした。ゲーム内で報告ボタンを押して再度実行してください。");
                            return;
                        }
                        var data = await App.Game.GameAPI.GetMonthlyCardLog(authkey);
                        foreach (var item in data.list)
                        {
                            Console($"{item.time} - {item.card_product_name}");
                        }
                    }
                    break;
                default:
                    Console($"{parameters[1]} は不明なパラメータです。");
                    break;
            }
            return;
        }
    }
}
