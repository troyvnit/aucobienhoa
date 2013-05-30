namespace TroyLeeMVCEF.Domain.Commands
{
    using System;

    using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;

    public class DeleteArticleCategoryCommand : ICommand
    {
        public Guid ArticleCategoryID;
        public bool IsDeleted;
    }
}
