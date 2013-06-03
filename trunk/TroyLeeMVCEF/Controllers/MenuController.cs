
namespace TroyLeeMVCEF.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;

    using Newtonsoft.Json;

    using TroyLeeMVCEF.CommandProcessor.Dispatcher;
    using TroyLeeMVCEF.Data.Repositories.Menu;
    using TroyLeeMVCEF.Domain.Commands;
    using TroyLeeMVCEF.Model.Entities;

    public class MenuController : Controller
    {
        private readonly IMenuRepository menuRepository;
        private readonly ICommandBus commandBus;
        public MenuController(IMenuRepository menuRepository, ICommandBus commandBus)
        {
            this.menuRepository = menuRepository;
            this.commandBus = commandBus;
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
                    var command = Mapper.Map<Menu, CreateOrUpdateMenuCommand>(menu);
                    if (ModelState.IsValid)
                    {
                        commandBus.Submit(command);
                    }
                }
                return Json(menus, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteMenus(string models)
        {
            var menus = JsonConvert.DeserializeObject<List<Menu>>(models);
            if (ModelState.IsValid)
            {
                foreach (var command in menus.Select(Mapper.Map<Menu, DeleteMenuCommand>))
                {
                    commandBus.Submit(command);
                }
                return Json(menus, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
