using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genshin_Checker.App.Command
{
    public static class CommandManager
    {
        private static readonly Dictionary<string, Command> commands =new ();
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
            commands[command.GetType().Name.ToLower().Split('.')[^1]] = command;
            Trace.Write(command.GetType().Name.ToLower().Split('.')[^1]);
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
                ConsoleOut?.Invoke(command, $"> {command}{Environment.NewLine}");
                string scriptName = parts[0].ToLower();
                if (commands.ContainsKey(scriptName))
                {
                    try
                    {
                        commands[scriptName].Execute(output => ConsoleOut?.Invoke(command, output), parts);
                    }catch(Exception ex)
                    {
                        ConsoleOut?.Invoke(command, $"コマンド実行中にエラーが発生しました。\n{ex}");
                    }
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

            ConsoleOut?.Invoke(command, Environment.NewLine);
        }
    }
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(Action<string> outputCallback, params string[] parameters);
    }
}
