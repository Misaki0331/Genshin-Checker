using Genshin_Checker.Window;

namespace Genshin_Checker.Core.Command.CommandList
{

    public class DS : Command
    {
        public override string Name => "ds";
        public override string Description => "ds";

        public override Task Execute(params string[] parameters)
        {
            if (parameters.Length < 3)
            {
                Console($"time,randomstring");
                return Task.CompletedTask;
            }
            Console(WebRequest.DS(int.Parse(parameters[1]), parameters[2]));
            return Task.CompletedTask;
        }
    }
}
