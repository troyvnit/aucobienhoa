
namespace TroyLeeMVCEF.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using TroyLeeMVCEF.Data.Infrastructure.UnitOfWork;
    using TroyLeeMVCEF.Data.Repositories.Menu;
    using TroyLeeMVCEF.Model.Entities;

    public class MenuController : Controller
    {
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;
        public MenuController(IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetMenus()
        {
            var menus = menuRepository.GetAll().Where(a => a.IsDeleted != true).ToList();
            return Json(menus.OrderBy(a => a.MenuName), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult CreateOrUpdateMenus(string models)
        {
            var menus = JsonConvert.DeserializeObject<List<Menu>>(models);
            if (ModelState.IsValid)
            {
                foreach (var menu in menus)
                {
                    if (menuRepository.GetById(menu.MenuID) == null)
                    {
                        menu.MenuID = Guid.NewGuid();
                        menuRepository.Add(menu);
                    }
                    else
                    {
                        menuRepository.Update(menu);
                    }
                    unitOfWork.Commit();
                }
                return Json(menus, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteArticleMenus(string models)
        {
            var menus = JsonConvert.DeserializeObject<List<Menu>>(models);
            if (ModelState.IsValid)
            {
                foreach (var menu in menus)
                {
                    menu.IsDeleted = true;
                    menuRepository.Update(menu);
                    unitOfWork.Commit();
                }
                return Json(menus, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
