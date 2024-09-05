using System.Diagnostics;
using System.Reflection;

namespace Genshin_Checker.App.Command
{
    public static class CommandManager
    {
        internal static readonly Dictionary<string, Command> commands =new ();
        private static void InitializeCommands()
        {
            // アプリケーション内の全てのコマンドクラスを取得
            var commandTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.IsSubclassOf(typeof(Command)) && !type.IsAbstract);

            // 各コマンドクラスをインスタンス化して登録
            foreach (var commandType in commandTypes)
            {
                var command = Activator.CreateInstance(commandType) as Command;
                if (command != null)
                {
                    RegisterCommand(command);
                }
            }
        }

        private static void RegisterCommand(Command command)
        {
            commands[command.Name] = command;
            Trace.Write(command.Name);
        }
        public static event EventHandler<string>? ConsoleOut; 
        public static void RunCommand(string command)
        {
            if(commands.Count==0)
                InitializeCommands();
            // スクリプトを解析して対応するアクションを実行
            string[] parts = command.Split(' ');
            if (parts.Length >= 1)
            {
                ConsoleOut?.Invoke(command, $"> {command}");
                string scriptName = parts[0].ToLower();
                if (commands.ContainsKey(scriptName))
                {
                    commands[scriptName].InnerRunning(output => ConsoleOut?.Invoke(command, output), parts);
                }
                else
                {
                    ConsoleOut?.Invoke(command, $"エラー : コマンド\"{parts[0]}\"は不明なスクリプト名です。");
                }

            }
            else
            {
                ConsoleOut?.Invoke(command, "エラー : 無効なコマンドです。");
            }

        }
    }
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        internal async void InnerRunning(Action<string> output, params string[] parameters)
        {
            Console = output;
            try
            {
                await Execute(parameters);
            }
            catch (Exception ex)
            {
                Console($"コマンド実行中にエラーが発生しました。");
                Console($"{ex}");
            }
        }
        public abstract Task Execute(params string[] parameters);

        public Action<string> Console=(e)=>{};
    }

    public class List : Command
    {
        public override string Name => "list";
        public override string Description => "リストを取得します。";

        public override Task<bool> Execute(params string[] parameters)
        {
            foreach(var command in CommandManager.commands)
            {
                Console($"{command.Key} : {command.Value.Description}");
            }
            Console($"");
            Console($"コマンドは {CommandManager.commands.Count} 件あります。");
            return Task.FromResult(true);
        }
    }
}
