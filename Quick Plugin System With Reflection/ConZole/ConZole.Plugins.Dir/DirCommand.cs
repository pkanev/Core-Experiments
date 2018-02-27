namespace ConZole.Plugins.Dir
{
    using ConZole.Common;
    using System;
    using System.IO;

    public class DirCommand : IPluginCommand
    {
        public string Name => "dir";

        public void Execute(HostContext host, string[] parameters)
        {
            host.Out.WriteLine(Environment.CurrentDirectory);
            host.Out.WriteLine("===========================");
            foreach (var file in Directory.GetFiles(Environment.CurrentDirectory))
            {
                host.Out.WriteLine($"{new FileInfo(file).Name}");
            }
        }
    }
}
