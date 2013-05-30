using System;
using System.Collections.Generic;

using TroyLeeMVCEF.CommandProcessor.Commands;
using TroyLeeMVCEF.CommandProcessor.Commands.ICommands;
using TroyLeeMVCEF.Domain.Commands;
using TroyLeeMVCEF.Model.Entities;

namespace TroyLeeMVCEF.Domain.Handlers
{
    using TroyLeeMVCEF.Data.Repositories.Article;

    public class CanAddArticle : IValidationHandler<CreateOrUpdateArticleCommand>
    {
        private readonly IArticleRepository articleRepository;
        public CanAddArticle(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
        public IEnumerable<ValidationResult> Validate(CreateOrUpdateArticleCommand command)
        {
            Article isArticleExists = null;
            if (command.ArticleID == Guid.Empty)
                isArticleExists = articleRepository.Get(c => c.Title == command.Title);
            else
                isArticleExists = articleRepository.Get(c => c.Title == command.Title && c.ArticleID != command.ArticleID);
            if (isArticleExists != null)
            {
                yield return new ValidationResult("Title", "Existed");
            }
        }
    }
}
