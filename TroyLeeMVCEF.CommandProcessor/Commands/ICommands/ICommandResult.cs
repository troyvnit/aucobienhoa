using System;

namespace TroyLeeMVCEF.CommandProcessor.Commands.ICommands
{
    public interface ICommandResult
    {
        bool Success { get; }
        Guid ID { get; }
    }
}
