namespace TroyLeeMVCEF.CommandProcessor.Commands.ICommands
{
    public interface ICommandResults
    {
        ICommandResult[] Results { get; }
        bool Success { get; }
    }
}
