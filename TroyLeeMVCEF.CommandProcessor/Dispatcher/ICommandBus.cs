using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using TroyLeeMVCEF.CommandProcessor.Commands;
using System.Collections.Generic;
namespace TroyLeeMVCEF.CommandProcessor.Dispatcher
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand: ICommand;
        IEnumerable<ValidationResult> Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}

