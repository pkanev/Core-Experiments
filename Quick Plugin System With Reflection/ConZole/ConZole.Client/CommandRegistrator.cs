namespace ConZole.Client
{
    using Common;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class CommandRegistrator
    {
        private Dictionary<string, IPluginCommand> commands;

        public CommandRegistrator(string path)
        {
            this.commands = new Dictionary<string, IPluginCommand>();
            this.LoadPluginsFromDirectory(path);
        }

        private void LoadPluginsFromDirectory(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if(file.EndsWith(".dll"))
                {
                    this.LoadPluginsFromFile(file);
                }
            }
        }

        private void LoadPluginsFromFile(string file)
        {
            var assembly = Assembly.LoadFile(file);
            var pluginTypes = assembly
                .GetTypes()
                .Where(t => typeof(IPluginCommand).IsAssignableFrom(t))
                .ToList();
            foreach (var type in pluginTypes)
            {
                var instance = Activator.CreateInstance(type) as IPluginCommand;
                this.commands.Add(instance.Name, instance);
            }
        }

        public Dictionary<string, IPluginCommand> GetCommands()
        {            
            return this.commands;
        }
    }
}
