using Genshin_Checker.Window;

namespace Genshin_Checker.App.Command.CommandList
{

    public class PlaySound : Command
    {
        public override string Name => "play";
        public override string Description => "サウンドプレイヤー";

        public override Task Execute(params string[] parameters)
        {
            if (parameters.Length < 2)
            {
                Console($"play url : 指定したURLを再生");
                return Task.CompletedTask;
            }
            var a = new Genshin_Checker.Window.MusicPlayer();
            a.LoadSong(parameters[1]);
            a.ShowDialog();
            return Task.CompletedTask;
        }
    }
}
