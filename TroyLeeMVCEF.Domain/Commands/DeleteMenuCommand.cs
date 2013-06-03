namespace TroyLeeMVCEF.Domain.Commands
{
    using System;

    using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;

    public class DeleteMenuCommand : ICommand
    {
        public Guid MenuID;
        public bool IsDeleted;
    }
}
