namespace TroyLeeMVCEF.Domain.Commands
{
    using System;

    using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;

    public class DeleteArticleCommand : ICommand
    {
        public Guid ArticleID;
        public bool IsDeleted;
    }
}
