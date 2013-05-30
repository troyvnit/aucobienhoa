using System.Collections.Generic;

namespace TroyLeeMVCEF.CommandProcessor.Commands.ICommands
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand command);
    }
}
