using Genshin_Checker.Window;

namespace Genshin_Checker.App.Command.CommandList
{

    public class Registry : Command
    {
        public override string Name => "reg";
        public override string Description => "レジストリ情報";

        public override Task Execute(params string[] parameters)
        {
            Console(App.Registry.GetJson());
            return Task.CompletedTask;
        }
    }
}
