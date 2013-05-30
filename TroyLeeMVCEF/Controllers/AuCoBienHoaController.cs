using System.Web.Mvc;

namespace TroyLeeMVCEF.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.Article;
    using TroyLeeMVCEF.Data.Repositories.ArticleCategory;
    using TroyLeeMVCEF.Model.Entities;
    using TroyLeeMVCEF.Models;
    using AutoMapper;

    public class AuCoBienHoaController : Controller
    {
        //
        // GET: /AuCoBienHoa/
        private readonly IArticleRepository articleRepository;
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public AuCoBienHoaController(IArticleRepository articleRepository, IUnitOfWork unitOfWork, IArticleCategoryRepository articleCategoryRepository)
        {
            this.articleRepository = articleRepository;
            this.articleCategoryRepository = articleCategoryRepository;
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Service(int page = 1, int pageSize = 4)
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished && a.MenuID == 1)).OrderBy(a => a.OrderID).ThenBy(a => a.IsNew).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).Skip((page - 1) * pageSize).Take(pageSize))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.Comments = new List<CommentViewModel>();
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                foreach (var comment in article.Comments)
                {
                    articlevm.Comments.Add(Mapper.Map<Comment, CommentViewModel>(comment));
                }
                articles.Add(articlevm);
            }
            ViewBag.Articles = articles;
            if(articles.Count < pageSize)
            {
                page = 0;
            }
            ViewBag.Page = page;
            return View();
        }
        public ActionResult DetailPage(Guid ArticleID)
        {
            var article = Mapper.Map<Article, ArticleViewModel>(articleRepository.GetById(ArticleID));
            article.Comments = new List<CommentViewModel>();
            foreach (var comment in articleRepository.GetById(ArticleID).Comments)
            {
                article.Comments.Add(Mapper.Map<Comment, CommentViewModel>(comment));
            }
            var firstOrDefault = articleRepository.GetById(ArticleID).ArticleCategories.FirstOrDefault();
            if (firstOrDefault != null)
            {
                ViewBag.Banner = firstOrDefault.ImageUrl;
            }
            ViewBag.Article = article;
            return View();
        }
        public ActionResult _NewArticle(int page = 1, int pageSize = 5)
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished && a.MenuID == 1)).OrderBy(a => a.OrderID).ThenBy(a => a.IsNew).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).Skip((page - 1) * pageSize).Take(pageSize))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.Comments = new List<CommentViewModel>();
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                foreach (var comment in article.Comments)
                {
                    articlevm.Comments.Add(Mapper.Map<Comment, CommentViewModel>(comment));
                }
                articles.Add(articlevm);
            }
            ViewBag.Articles = articles;
            return View();
        }
        [HttpPost]
        public ActionResult PostComment(CommentViewModel commentvm, Guid ArticleID)
        {
            var article = articleRepository.GetById(ArticleID);
            var comment = new Comment { Name = commentvm.Name, Email = commentvm.Email, Content = commentvm.Content, ArticleID = ArticleID, CommentID = Guid.NewGuid(), CreatedOn = DateTime.Now };
            article.Comments = new List<Comment> { comment };
            articleRepository.Update(article);
            unitOfWork.Commit();
            string data = "<li class=\"comment even thread-even depth-1\"><a name=\"comment-33\"></a>" +
                          "<div id=\"li-comment-33\" class=\"comment-container comment-body\"><div class=\"avatar\">" +
                          "<img alt=\"\" src=\"http://www.gravatar.com/avatar/2b81edaa6822486461b23fa8ad05cf68\" class=\"photo avatar-40 photo avatar-default\" height=\"40\" width=\"40\" /></div>" +
                          "<div class=\"comment-text\"><div class=\"comment-author\"><div class=\"link-author\">"+comment.Name+"</div>"+String.Format("{0:dd/MM/yyyy}", comment.CreatedOn)+"</div>" +
                          "<div class=\"comment-entry\">" + comment.Content + "</div></div>" +
                          "<div id=\"comment-33\"></div><div class=\"clear\"></div></div></li>";
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _TopMenu()
        {
            var articleCategories = articleCategoryRepository.GetAll();
            ViewBag.ArticleCategories = articleCategories;
            return View();
        }
        public ActionResult Category(int page, int pageSize, Guid ArticleCategoryID)
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished)).OrderBy(a => a.OrderID).ThenBy(a => a.IsNew).ThenBy(a => a.UpdatedOn).ThenBy(a => a.CreatedOn).Skip((page - 1) * pageSize).Take(pageSize))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.Comments = new List<CommentViewModel>();
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                foreach (var comment in article.Comments)
                {
                    articlevm.Comments.Add(Mapper.Map<Comment, CommentViewModel>(comment));
                }
                if(articlevm.ArticleCategoryIDs.Contains(ArticleCategoryID))
                {
                    articles.Add(articlevm);
                }
            }
            ViewBag.Articles = articles;
            if (articles.Count < pageSize)
            {
                page = 0;
            }
            ViewBag.Page = page;
            return View();
        }
    }
}
