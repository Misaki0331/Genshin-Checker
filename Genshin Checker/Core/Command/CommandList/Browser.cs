using Genshin_Checker.Window;

namespace Genshin_Checker.Core.Command.CommandList
{

    public class Browser : Command
    {
        public override string Name => "browser";
        public override string Description => "ブラウザを表示します。";

        public override Task Execute(params string[] parameters)
        {
            if(parameters.Length < 2) {
                Console("browser [url]");
                return Task.CompletedTask;
            }
            bool urlbox = true;
            for(int i = 2; i < parameters.Length; i++)
            {
                switch (parameters[i])
                {
                    case "-hide":
                        urlbox = false;
                        break;
                }
            }
            new WebMiniBrowser(new(parameters[1]), urlboxshow: urlbox).Show();
            return Task.CompletedTask;
        }
    }
}
