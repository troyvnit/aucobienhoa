using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using TroyLeeMVCEF.Domain.Commands;

using System;
using TroyLeeMVCEF.CommandProcessor.Commands;
using System.Collections.Generic;
using System.Linq;

namespace TroyLeeMVCEF.Domain.Handlers
{
    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.Article;
    using TroyLeeMVCEF.Data.Repositories.ArticleCategory;
    using TroyLeeMVCEF.Model.Entities;

    public class DeleteArticleHandler : ICommandHandler<DeleteArticleCommand>
    {
        private readonly IArticleRepository articleRepository;
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteArticleHandler(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.articleCategoryRepository = articleCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteArticleCommand command)
        {
            Guid ID = Guid.Empty;
            if (articleRepository.GetById(command.ArticleID) != null)
            {
                var article = articleRepository.GetById(command.ArticleID);
                article.IsDeleted = true;
                articleRepository.Update(article);
                ID = article.ArticleID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
