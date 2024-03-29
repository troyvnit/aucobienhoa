﻿using System;
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
            foreach (var article in articleRepository.GetAll().Where(a => a.IsDeleted != true).Select(a => new Article { ArticleID = a.ArticleID, Author = a.Author,
                                                                                                                         Comments = a.Comments,
                                                                                                                         CreatedBy = a.CreatedBy,
                                                                                                                         CreatedOn = a.CreatedOn,
                                                                                                                         Description = "",
                                                                                                                         ImageUrl = a.ImageUrl,
                                                                                                                         IsDeleted = a.IsDeleted,
                                                                                                                         IsNew = a.IsNew,
                                                                                                                         IsPublished = a.IsPublished,
                                                                                                                         OrderID = a.OrderID,
                                                                                                                         Title = a.Title,
                                                                                                                         UpdatedBy = a.UpdatedBy,
                                                                                                                         UpdatedOn = a.UpdatedOn,
                                                                                                                         ArticleCategories = a.ArticleCategories,
                                                                                                                         Content = ""
            }))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.ArticleCategoryIDs = article.ArticleCategories.Select(a => a.ArticleCategoryID).ToList();
                articles.Add(articlevm);
            }
            var jsonResult = Json(articles.OrderBy(a => a.OrderID), JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDescriptionAndContent(Guid id)
        {
            var article = articleRepository.GetById(id);
            return Json(new { article.Description, article.Content }, JsonRequestBehavior.AllowGet);
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
