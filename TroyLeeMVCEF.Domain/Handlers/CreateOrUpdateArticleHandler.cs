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

    public class CreateOrUpdateArticleHandler : ICommandHandler<CreateOrUpdateArticleCommand>
    {
        private readonly IArticleRepository articleRepository;
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CreateOrUpdateArticleHandler(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.articleCategoryRepository = articleCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(CreateOrUpdateArticleCommand command)
        {
            Guid ID;
            if (articleRepository.GetById(command.ArticleID) == null)
            {
                var article = new Article
                    {
                        Content = command.Content,
                        Description = command.Description,
                        Author = command.Author,
                        ImageUrl = command.ImageUrl,
                        IsNew = command.IsNew,
                        IsPublished = command.IsPublished,
                        Title = command.Title,
                        OrderID = command.OrderID,
                        ArticleCategories = new List<ArticleCategory>(), 
                        ArticleID = command.ArticleID == Guid.Empty ? Guid.NewGuid() : command.ArticleID
                    };
                foreach (var articlecategory in command.ArticleCategoryIDs.Select(acID => articleCategoryRepository.GetById(acID)))
                {
                    article.ArticleCategories.Add(articlecategory);
                }
                articleRepository.Add(article);
                ID = article.ArticleID;
            }
            else
            {
                var article = articleRepository.GetById(command.ArticleID);
                article.Content = command.Content;
                article.Description = command.Description;
                article.Author = command.Author;
                article.ImageUrl = command.ImageUrl;
                article.IsNew = command.IsNew;
                article.IsPublished = command.IsPublished;
                article.Title = command.Title;
                article.OrderID = command.OrderID;
                var articlecategories = command.ArticleCategoryIDs.Select(acID => articleCategoryRepository.GetById(acID)).ToList();
                var deleteCats = article.ArticleCategories.Where(ac => !command.ArticleCategoryIDs.Contains(ac.ArticleCategoryID)).ToList();
                var addCats = articlecategories.Where(ac => !article.ArticleCategories.Select(a => a.ArticleCategoryID).Contains(ac.ArticleCategoryID)).ToList();

                foreach (var deleteCat in deleteCats)
                {
                    article.ArticleCategories.Remove(deleteCat);
                }

                foreach (var addCat in addCats)
                {
                    article.ArticleCategories.Add(addCat);
                }
                articleRepository.Update(article);
                ID = article.ArticleID;
            }
            unitOfWork.Commit();
            return new CommandResult(true, ID);
        }
    }
}
