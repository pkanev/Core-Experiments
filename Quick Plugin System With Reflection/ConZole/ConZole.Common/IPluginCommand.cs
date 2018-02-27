namespace ConZole.Common
{
    public interface IPluginCommand
    {
        string Name { get; }

        void Execute(HostContext host, string[] parameters);
    }
}
