namespace ConZole.Plugins.SystemInfo
{
    using Common;
    using System;

    public class UserInfoPlugin : IPluginCommand
    {
        public string Name => "user";

        public void Execute(HostContext host, string[] parameters)
        {
            host.Out.WriteLine(Environment.UserName);
        }
    }
}
