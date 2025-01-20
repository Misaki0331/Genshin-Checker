using Genshin_Checker.Window;

namespace Genshin_Checker.Core.Command.CommandList
{

    public class PlaySound : Command
    {
        public override string Name => "play";
        public override string Description => "サウンドプレイヤー";

        public override async Task Execute(params string[] parameters)
        {
            if (parameters.Length < 2)
            {
                Console($"play url : 指定したURLを再生");
                return;
            }
            var a = new Genshin_Checker.InternalTools.MusicInfoSetter();
            await a.LoadSong(parameters[1]);
            a.ShowDialog();
            return;
        }
    }
}
