using System;
using System.Collections.Generic;

using TroyLeeMVCEF.CommandProcessor.Commands;
using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using TroyLeeMVCEF.Domain.Commands;
using TroyLeeMVCEF.Model.Entities;

namespace TroyLeeMVCEF.Domain.Handlers
{
    using TroyLeeMVCEF.Data.Repositories.ArticleCategory;

    public class CanAddArticleCategory : IValidationHandler<CreateOrUpdateArticleCategoryCommand>
    {
        private readonly IArticleCategoryRepository articleCategoryRepository;
        public CanAddArticleCategory(IArticleCategoryRepository articleCategoryRepository)
        {
            this.articleCategoryRepository = articleCategoryRepository;
        }
        public IEnumerable<ValidationResult> Validate(CreateOrUpdateArticleCategoryCommand command)
        {
            ArticleCategory isArticleCategoryExists = null;
            if (command.ArticleCategoryId == Guid.Empty)
                isArticleCategoryExists = articleCategoryRepository.Get(c => c.ArticleCategoryName == command.ArticleCategoryName);
            else
                isArticleCategoryExists = articleCategoryRepository.Get(c => c.ArticleCategoryName == command.ArticleCategoryName && c.ArticleCategoryID != command.ArticleCategoryId);
            if (isArticleCategoryExists != null)
            {
                yield return new ValidationResult("ArticleCategoryName", "Existed");
            }
        }
    }
}
