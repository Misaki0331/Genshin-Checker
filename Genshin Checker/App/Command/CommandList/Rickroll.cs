using Genshin_Checker.Window;

namespace Genshin_Checker.App.Command.CommandList
{

    public class Rickroll : Command
    {
        public override string Name => "rickroll";
        public override string Description => "ちょっとしたトリックさ";

        public override Task Execute(params string[] parameters)
        {
            new WebMiniBrowser(new("https://static-api.misaki-chan.world/genshin-checker/fun/rickroll/")).Show();
            return Task.CompletedTask;
        }
    }
}
