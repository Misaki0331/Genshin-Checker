﻿using Genshin_Checker.Window;

namespace Genshin_Checker.App.Command.CommandList
{

    public class Registry : Command
    {
        public override string Name => "reg";
        public override string Description => "レジストリ情報";

        public override async Task Execute(params string[] parameters)
        {
            Console(App.Registry.GetJson());
            var getjson = App.Registry.GetJson();
            Console("取得完了");
            App.Registry.AllClear();
            Console("削除完了 5秒後に復元します。");
            await Task.Delay(5000);
            App.Registry.SetJson(getjson);
            Console("復元完了");
            return;
        }
    }
}
