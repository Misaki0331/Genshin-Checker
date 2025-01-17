using Genshin_Checker.Core.General;
using System.IO;

namespace Genshin_Checker.Core.Command.CommandList
{

    public class Registry : Command
    {
        public override string Name => "reg";
        public override string Description => "レジストリ情報";

        public override async Task Execute(params string[] parameters)
        {
            /*
             * Console(Core.Registry.GetJson());
            var getjson = Core.Registry.GetJson();
            Console("取得完了");
            Core.Registry.AllClear();
            Console("削除完了 5秒後に復元します。");
            await Task.Delay(5000);
            Core.Registry.SetJson(getjson);
            Console("復元完了");*/

            var a=await MovingData.WriteToApp(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.zip"));
            if (a != null)
            {
                Console("アプリデータの上書きに失敗しました。");
                Console(a.ToString());
            }
            else Console("上書きに成功!");
            return;
        }
    }
}
