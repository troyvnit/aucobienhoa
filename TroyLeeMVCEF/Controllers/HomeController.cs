using System.Web.Mvc;

namespace TroyLeeMVCEF.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.Linq;

    using CaptchaMvc.HtmlHelpers;

    using TroyLeeMVCEF.Core.Functions;
    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.Article;
    using TroyLeeMVCEF.Data.Repositories.ArticleCategory;
    using TroyLeeMVCEF.Data.Repositories.Menu;
    using TroyLeeMVCEF.Model.Entities;
    using TroyLeeMVCEF.Models;
    using AutoMapper;

    public class HomeController : Controller
    {
        //
        // GET: /AuCoBienHoa/
        private readonly IArticleRepository articleRepository;
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(IArticleRepository articleRepository, IUnitOfWork unitOfWork, IArticleCategoryRepository articleCategoryRepository, IMenuRepository menuRepository)
        {
            this.articleRepository = articleRepository;
            this.articleCategoryRepository = articleCategoryRepository;
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished)).OrderBy(a => a.OrderID).ThenByDescending(a => a.IsNew).ThenByDescending(a => a.UpdatedOn).ThenByDescending(a => a.CreatedOn))
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
            ViewBag.VideoUrl = menuRepository.GetById(Guid.Parse("11111111-1111-1111-1111-123412341234")).Url;
            return View();
        }
        public ActionResult ForumPage(int page = 1, int pageSize = 4, Guid ForumID = default(Guid))
        {
            var articlecategories = articleCategoryRepository.GetAll().Where(a => a.IsDeleted != true && a.ForumID == ForumID).ToList();
            ViewBag.ArticleCategories = articlecategories;
            switch (ForumID.ToString())
            {
                case "11111111-1111-1111-1111-111111111101":
                    ViewBag.Forum = "Tư vấn y khoa";
                    break;
                case "11111111-1111-1111-1111-111111111102": 
                    ViewBag.Forum = "Hỏi - Đáp";
                    break;
                default: 
                    ViewBag.Forum = "";
                    break;
            }
            return View();
        }
        public ActionResult CategoryPage(int page = 1, int pageSize = 4, Guid ArticleCategoryID = default(Guid), bool IsForum = false)
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished
                && (a.ArticleCategories.Select(ac => ac.ArticleCategoryID).ToList().Contains(ArticleCategoryID) || ArticleCategoryID == Guid.Empty)))
                .OrderBy(a => a.OrderID).ThenByDescending(a => a.IsNew).ThenByDescending(a => a.UpdatedOn).ThenByDescending(a => a.CreatedOn).Skip((page - 1) * pageSize).Take(pageSize))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.Comments = new List<CommentViewModel>();
                foreach (var comment in article.Comments)
                {
                    articlevm.Comments.Add(Mapper.Map<Comment, CommentViewModel>(comment));
                }
                articles.Add(articlevm);
            }
            ViewBag.Articles = articles;
            if (articles.Count < pageSize)
            {
                page = 0;
            }
            ViewBag.ArticleCategory = articleCategoryRepository.GetById(ArticleCategoryID);
            ViewBag.Page = page;
            ViewBag.IsForum = IsForum;
            return View();
        }
        public ActionResult ProfessionalsPage(int page = 1, int pageSize = 9, Guid ArticleCategoryID = default(Guid))
        {
            var doctors = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished
                && (a.ArticleCategories.Select(ac => ac.ArticleCategoryID).ToList().Contains(ArticleCategoryID) || ArticleCategoryID == Guid.Empty)))
                .OrderBy(a => a.OrderID).ThenByDescending(a => a.IsNew).ThenByDescending(a => a.UpdatedOn).ThenByDescending(a => a.CreatedOn).Skip((page - 1) * pageSize).Take(pageSize))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.Comments = new List<CommentViewModel>();
                foreach (var comment in article.Comments)
                {
                    articlevm.Comments.Add(Mapper.Map<Comment, CommentViewModel>(comment));
                }
                doctors.Add(articlevm);
            }
            ViewBag.Doctors = doctors;
            if (doctors.Count < pageSize)
            {
                page = 0;
            }
            ViewBag.ArticleCategory = articleCategoryRepository.GetById(ArticleCategoryID);
            ViewBag.Page = page;
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished
                && (a.ArticleCategories.Select(ac => ac.ArticleCategoryID).ToList().Contains(Guid.Parse("11111111-1111-1111-1111-111111111115")))))
                .OrderBy(a => a.OrderID).ThenByDescending(a => a.IsNew).ThenByDescending(a => a.UpdatedOn).ThenByDescending(a => a.CreatedOn).Skip((page - 1) * pageSize).Take(pageSize))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.Comments = new List<CommentViewModel>();
                foreach (var comment in article.Comments)
                {
                    articlevm.Comments.Add(Mapper.Map<Comment, CommentViewModel>(comment));
                }
                articles.Add(articlevm);
            }
            ViewBag.Articles = articles;
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
            else
            {
                ViewBag.Banner = "khamvadieutri1.jpg";
            }
            ViewBag.Article = article;
            return View();
        }
        public ActionResult _NewArticle(int page = 1, int pageSize = 5)
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished && (a.ArticleCategories.Select(b => b.ArticleCategoryID).Contains(Guid.Parse("11111111-1111-1111-1111-111111111110")) || a.ArticleCategories.Select(b => b.ArticleCategoryID).Contains(Guid.Parse("11111111-1111-1111-1111-111111111103"))))).OrderBy(a => a.OrderID).ThenByDescending(a => a.IsNew).ThenByDescending(a => a.UpdatedOn).ThenByDescending(a => a.CreatedOn).Skip((page - 1) * pageSize).Take(pageSize))
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
                          "<div class=\"comment-text\"><div class=\"comment-author\"><div class=\"link-author\">" + comment.Name + "</div>" + String.Format("{0:dd/MM/yyyy}", comment.CreatedOn) + "</div>" +
                          "<div class=\"comment-entry\">" + comment.Content + "</div></div>" +
                          "<div id=\"comment-33\"></div><div class=\"clear\"></div></div></li>";
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _TopMenu()
        {
            var menus = menuRepository.GetAll().Where(a => a.IsDeleted != true).OrderBy(o => o.OrderID).ToList();
            ViewBag.Menus = menus;
            return View();
        }
        public ActionResult _BottomMenu()
        {
            var menus = menuRepository.GetAll().Where(a => a.IsDeleted != true).OrderBy(o => o.OrderID).ToList();
            ViewBag.Menus = menus;
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(FormCollection f)
        {
            //if (this.IsCaptchaValid("Captcha is not valid"))
            //{
            //    return Json("Mã bảo mật không đúng, vui lòng thử lại!");
            //}
            var fromAddress = ConfigurationManager.AppSettings.Get("SendMailMessagesFromAddress");
            var hostAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress");
            var toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPToAddress");
            var username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName");
            var password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword");
            var content = "THÔNG TIN<br /><br />" +
                          "Họ và tên: " + f["Name"] + "<br /><br />" +
                          "Email: " + f["Email"] + "<br /><br />" +
                          "Nội dung: " + f["message"] + "<br /><br />";
            var email = new Email(f["Email"], hostAddress, toAddress, username, password, f["Subject"], content);
            var success = email.send();
            return Json(!success ? "Gửi liên hệ thất bại, vui lòng thử lại sau!" : "Thông tin liên hệ của bạn đã được gửi, cảm ơn!");
        }
        public ActionResult Booking()
        {
            var date = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            ViewBag.date = date;
            return View();
        }
        [HttpPost]
        public ActionResult Booking(FormCollection f)
        {
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                return Json("Mã bảo mật không đúng, vui lòng thử lại!");
            }
            var fromAddress = ConfigurationManager.AppSettings.Get("SendMailMessagesFromAddress");
            var hostAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPHostAddress");
            var toAddress = ConfigurationManager.AppSettings.Get("SendMailSTMPToAddress");
            var username = ConfigurationManager.AppSettings.Get("SendMailSMTPUserName");
            var password = ConfigurationManager.AppSettings.Get("SendMailSMTPUserPassword");
            var content = "THÔNG TIN<br /><br />" +
                          "Bác sĩ: " + f["Doctor"] + "<br /><br />" +
                          "Thời gian: " + f["Time"] + "<br /><br />" +
                          "Khách hàng: " + f["Name"] + "<br /><br />" +
                          "Ngày sinh: " + f["Birthday"] + "<br /><br />" +
                          "Địa chỉ: " + f["Address"] + "<br /><br />" +
                          "Số điện thoại: " + f["Phone"] + "<br /><br />" +
                          "Email: " + f["Email"] + "<br /><br />" +
                          "Ghi chú: " + f["Question"] + "<br /><br />";
            var email = new Email(f["Email"], hostAddress, toAddress, username, password, f["Subject"], content);
            var success = email.send();
            return Json(!success ? "Gửi liên hệ thất bại, vui lòng thử lại sau!" : "Thông tin liên hệ của bạn đã được gửi, cảm ơn!");
        }
        public ActionResult Search(int page = 1, int pageSize = 4, string searchValue = "")
        {
            var articles = new List<ArticleViewModel>();
            foreach (var article in articleRepository.GetAll().Where(a => (a.IsDeleted != true && a.IsPublished
                && (a.Content.ToLower().Contains(searchValue.ToLower()) || a.Description.ToLower().Contains(searchValue.ToLower()) || a.Title.ToLower().Contains(searchValue.ToLower()))))
                .OrderBy(a => a.OrderID).ThenByDescending(a => a.IsNew).ThenByDescending(a => a.UpdatedOn).ThenByDescending(a => a.CreatedOn).Skip((page - 1) * pageSize).Take(pageSize))
            {
                var articlevm = Mapper.Map<Article, ArticleViewModel>(article);
                articlevm.Comments = new List<CommentViewModel>();
                foreach (var comment in article.Comments)
                {
                    articlevm.Comments.Add(Mapper.Map<Comment, CommentViewModel>(comment));
                }
                articles.Add(articlevm);
            }
            ViewBag.Articles = articles;
            if (articles.Count < pageSize)
            {
                page = 0;
            }
            ViewBag.Page = page;
            ViewBag.SearchValue = searchValue;
            return View();
        }
    }
}
