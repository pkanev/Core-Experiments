namespace ConZole.Plugins.SystemInfo
{
    using Common;
    using System;

    public class SystemInfoCommand : IPluginCommand
    {
        public string Name => "system";

        public void Execute(HostContext host, string[] parameters)
        {
            host.Out.WriteLine("System info:");
            host.Out.WriteLine("-----------------------");
            host.Out.WriteLine($"OS: {Environment.OSVersion}");
            host.Out.WriteLine($".NET: {Environment.Version}");
        }
    }
}
