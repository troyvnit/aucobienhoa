using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using TroyLeeMVCEF.Domain.Commands;
using TroyLeeMVCEF.Model.Entities;
using System;
using TroyLeeMVCEF.CommandProcessor.Commands;

namespace TroyLeeMVCEF.Domain.Handlers
{
    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.ArticleCategory;

    public class CreateOrUpdateArticleCategoryHandler : ICommandHandler<CreateOrUpdateArticleCategoryCommand>
    {
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateArticleCategoryHandler(IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateArticleCategoryCommand command)
        {
            Guid ID;
            var articleCategory = new ArticleCategory
            {
                ArticleCategoryID = command.ArticleCategoryId,
                ArticleCategoryName = command.ArticleCategoryName,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                MenuID = command.MenuID
            };
            if (articleCategory.ArticleCategoryID == Guid.Empty)
            {
                articleCategory.ArticleCategoryID = Guid.NewGuid();
                articleCategoryRepository.Add(articleCategory);
                ID = articleCategory.ArticleCategoryID;
            }
            else
            {
                articleCategoryRepository.Update(articleCategory);
                ID = articleCategory.ArticleCategoryID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
