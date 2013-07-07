using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace TroyLeeMVCEF.Controllers
{
    using Newtonsoft.Json;

    using TroyLeeMVCEF.CommandProcessor.Dispatcher;
    using TroyLeeMVCEF.Data.Repositories.Article;
    using TroyLeeMVCEF.Data.Repositories.ArticleCategory;
    using TroyLeeMVCEF.Domain.Commands;
    using TroyLeeMVCEF.Model.Entities;
    using TroyLeeMVCEF.Models;

    public class ArticleController : Controller
    {
        //
        // GET: /Article/
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IArticleRepository articleRepository;
        private readonly ICommandBus commandBus;
        public ArticleController(IArticleCategoryRepository articleCategoryRepository, IArticleRepository articleRepository, ICommandBus commandBus)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.articleRepository = articleRepository;
            this.commandBus = commandBus;
        }
        public ActionResult Index()
        {
            if (Session["AuCoBienHoaAdmin"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Account"); 
        }
        [HttpPost]
        public JsonResult GetArticleCategories()
        {
            var articlecategories = articleCategoryRepository.GetAll().Where(a => a.IsDeleted != true).Select(Mapper.Map<ArticleCategory, ArticleCategoryViewModel>).ToList();
            return Json(articlecategories.OrderBy(a => a.ArticleCategoryName), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateArticleCategories(string models)
        {
            var articleCategories = JsonConvert.DeserializeObject<List<ArticleCategoryViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var articleCategory in articleCategories)
                {
                    var command = Mapper.Map<ArticleCategoryViewModel, CreateOrUpdateArticleCategoryCommand>(articleCategory);
                    
                    if (ModelState.IsValid)
                    {
                        var result = commandBus.Submit(command);
                        articleCategory.ArticleCategoryID = result.ID;
                    }
                }
                return Json(articleCategories, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteArticleCategories(string models)
        {
            var articleCategories = JsonConvert.DeserializeObject<List<ArticleCategoryViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in articleCategories.Select(Mapper.Map<ArticleCategoryViewModel, DeleteArticleCategoryCommand>))
                {
                    commandBus.Submit(command);
                }
                return Json(articleCategories, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetArticles()
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => a.IsDeleted != true))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            return Json(articles.OrderBy(a => a.OrderID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult CreateOrUpdateArticles(string models)
        {
            var articles = JsonConvert.DeserializeObject<List<ArticleViewModel>>(models);
            if (ModelState.IsValid)
            {
                foreach (var article in articles)
                {
                    var command = Mapper.Map<ArticleViewModel, CreateOrUpdateArticleCommand>(article);
                    
                    if (!ModelState.IsValid)
                    {
                        continue;
                    }
                    if (Session["AuCoBienHoaAdmin"] != null)
                    {
                        command.Author = Session["AuCoBienHoaAdmin"].ToString();
                    }
                    var result = commandBus.Submit(command);
                    article.ArticleID = result.ID;
                }
                return Json(articles, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult DeleteArticles(string models)
        {
            var articles = JsonConvert.DeserializeObject<List<DeleteArticle>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in articles.Select(Mapper.Map<DeleteArticle, DeleteArticleCommand>))
                {
                    commandBus.Submit(command);
                }
                return Json(articles, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
    public class DeleteArticle
    {
        public Guid ArticleID;
        public bool IsDeleted;
    }
}
