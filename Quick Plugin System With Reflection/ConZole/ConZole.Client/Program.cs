namespace ConZole.Client
{
    using ConZole.Common;
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Dictionary<string, IPluginCommand> commands = new Dictionary<string, IPluginCommand>();
        static void Main(string[] args)
        {
            var context = new HostContext
            {
                In = Console.In,
                Out = Console.Out,
                Error = Console.Error
            };
            RegsiterCommands();

            while(true)
            {
                var userLine = context.In.ReadLine();
                if (userLine.ToLower() == "exit")
                {
                    return;
                }

                var commandParts = userLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var commandName = commandParts[0];
                if (!commands.ContainsKey(commandName))
                {
                    context.Error.WriteLine("Invalid command!");
                    continue;
                }

                var command = commands[commandName];
                command.Execute(context, commandParts.Skip(1).ToArray());
            }

        }

        static void RegsiterCommands()
        {
            var currentDirectory = Environment.CurrentDirectory;
            var path = Path.Combine(new string[] { currentDirectory, "Plugins", "netstandard2.0" });
            var commandRegsitrator = new CommandRegistrator(path);
            commands = commandRegsitrator.GetCommands();            
        }
    }
}
