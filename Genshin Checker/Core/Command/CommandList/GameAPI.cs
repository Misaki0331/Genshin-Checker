using Genshin_Checker.Core.Game;
using Genshin_Checker.Core.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.Core.Command.CommandList
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
                Console("Crystal -> 創生結晶のログを表示します。");
                Console("Primogem -> 原石のログを表示します。");
                Console("Resin -> 樹脂消費のログを表示します。");
                Console("Star-dust -> スターダストのログを表示します。");
                Console("star-glitter -> スターライトのログを表示します。");
                Console("artifact -> 聖遺物のログを表示します。");
                Console("weapon -> 武器のログを表示します。");
                return;
            }

            var authkey = await WebViewWatcher.GetServiceCenterAuthKey();
            var authRequiedMessage = new Action(() => { 
                Console("Error : 認証キーが見つかりませんでした。ゲーム内で報告ボタンを押して再度実行してください。"); 
            });
            switch (parameters[1].ToLower())
            {
                case "authkey":
                    Console($"{authkey??"(null)"}");
                    break;
                case "account":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetAccountInfo(authkey);
                        Console($"Server : {data.region}");
                        Console($"UID : {data.uid}");
                        Console($"Name : {data.nickname}");
                        Console($"通行証ID : {data.aid}");
                    };
                    break;
                case "monthly-card":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetMonthlyCardLog(authkey);
                        foreach (var item in data.list)
                            Console($"{item.EventTime} - {item.EventName}");
                    }
                    break;
                case "crystal":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetCrystalLog(authkey);
                        foreach (var item in data.list)
                            Console($"{item.EventTime} ({item.NumItems}) - {item.EventName}");
                    }
                    break;
                case "primogem":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetPrimogemLog(authkey);
                        foreach (var item in data.list)
                            Console($"{item.EventTime} ({item.NumItems}) - {item.EventName}");
                    }
                    break;
                case "resin":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetResinLog(authkey);
                        foreach (var item in data.list)
                            Console($"{item.EventTime} ({item.NumItems}) - {item.EventName}");
                    }
                    break;
                case "star-dust":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetStardustLog(authkey);
                        foreach (var item in data.list)
                            Console($"{item.EventTime} ({item.NumItems}) - {item.EventName}");
                    }
                    break;
                case "star-glitter":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetStarglitterLog(authkey);
                        foreach (var item in data.list)
                            Console($"{item.EventTime} ({item.NumItems}) - {item.EventName}");
                    }
                    break;
                case "artifact":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetArtifactLog(authkey);
                        foreach (var item in data.list)
                            Console($"{item.EventTime} {(item.NumItems=="-1"?"消費":"獲得")} {item.ItemName} - {item.EventName}");
                    }
                    break;
                case "weapon":
                    {
                        if (authkey == null)
                        {
                            authRequiedMessage();
                            return;
                        }
                        var data = await Core.Game.GameAPI.GetWeaponLog(authkey);
                        foreach (var item in data.list)
                            Console($"{item.EventTime} {(item.NumItems == "-1" ? "消費" : "獲得")} {item.ItemName} - {item.EventName}");
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
