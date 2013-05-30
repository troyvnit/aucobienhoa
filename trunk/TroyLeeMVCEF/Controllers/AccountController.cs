using System;
using System.Web.Mvc;

namespace TroyLeeMVCEF.Controllers
{
    using System.Web.Security;

    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.User;
    using TroyLeeMVCEF.Model.Entities;

    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public AccountController(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        public ActionResult Login(string status, string ReturnUrl)
        {
            ViewBag.Status = status;

            if (string.IsNullOrEmpty(ReturnUrl) && Request.UrlReferrer != null)
                ReturnUrl = Server.UrlEncode(Request.UrlReferrer.PathAndQuery);

            if (Url.IsLocalUrl(ReturnUrl) && !string.IsNullOrEmpty(ReturnUrl))
            {
                ViewBag.ReturnURL = ReturnUrl;
            }
            if (Session["AuCoBienHoaAdmin"] != null)
            {
                return RedirectToAction("Index", "Article");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(FormCollection f)
        {
            string ReturnUrl = f["ReturnURL"];
            if (Session["AuCoBienHoaAdmin"] != null)
            {
                return RedirectToAction("Index", "Article");
            }
            string username = f["UserName"];
            string password = f["Password"];
            bool remember = f["Remember"] != null;
            var user = new User { UserName = username, Password = password };
            if (userRepository.Get(a => a.UserName == user.UserName && a.PasswordHashed.Equals(user.PasswordHashed)) != null)
            {
                FormsAuthentication.SetAuthCookie(username, remember);
                Session["AuCoBienHoaAdmin"] = username;
                string decodedUrl = "";
                if (!string.IsNullOrEmpty(ReturnUrl))
                    decodedUrl = Server.UrlDecode(ReturnUrl);

                //Login logic...

                if (Url.IsLocalUrl(decodedUrl))
                {
                    return Redirect(decodedUrl);
                }
                return RedirectToAction("Index", "Article");
            }
            return RedirectToAction("Login", new { status = "Tài khoản hoặc mật khẩu không đúng!" });
        }
        //Troy
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session["AuCoBienHoaAdmin"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult Register(string status)
        {
            ViewBag.Status = status;

            if (Session["AuCoBienHoaAdmin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            string username = f["UserName"];
            string password = f["Password"];
            var user = new User { UserName = username, Password = password, Email = "admin@vipd.vn", FirstName = "VietSov Petro", LastName = "Administrator", UserID = Guid.NewGuid() };
            if (userRepository.Get(a => a.UserName == user.UserName) == null)
            {
                userRepository.Add(user);
                unitOfWork.Commit();
                return RedirectToAction("Register", new { status = "Tạo tài khoản thành công!" });
            }
            return RedirectToAction("Register", new { status = "Tạo tài khoản thất bại, vui lòng thử lại sau!" });
        }
        public ActionResult ChangePassword(string status)
        {
            ViewBag.Status = status;

            if (Session["AuCoBienHoaAdmin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(FormCollection f)
        {
            string username = f["UserName"];
            string password = f["Password"];
            string oldpasswod = f["OldPassword"];
            var user = new User { UserName = username, Password = oldpasswod };
            var userget = userRepository.Get(a => a.UserName == user.UserName && a.PasswordHashed.Equals(user.PasswordHashed));
            if (userget != null)
            {
                user.Password = password;
                userget.PasswordHashed = user.PasswordHashed;
                userRepository.Update(userget);
                unitOfWork.Commit();
                return RedirectToAction("ChangePassword", new { status = "Đổi mật khẩu thành công!" });
            }
            return RedirectToAction("ChangePassword", new { status = "Tài khoản hoặc mật khẩu không đúng!" });
        }
    }
}
