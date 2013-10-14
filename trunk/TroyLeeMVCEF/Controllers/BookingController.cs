using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TroyLeeMVCEF.Models;

namespace TroyLeeMVCEF.Controllers
{
    public class BookingController : Controller
    {
        //
        // GET: /Booking/
        BookingService.Service1SoapClient service = new BookingService.Service1SoapClient();
        public ActionResult Doctors()
        {
            var result = service.Doctors(1, 0, "BE470FAB-0CC0-653D736D10F6");
            return Content(result);
        }
        [HttpPost]
        public ActionResult AvailableDatesByDoctor(BookingOptionModel model)
        {
            var result = service.AvailableDatesByDoctor(model.doctorid ,model.month,model.year , "BE470FAB-0CC0-653D736D10F6");
            return Content(result);
        }
        [HttpPost]
        public ActionResult AvailableHoursByDoctor(BookingOptionModel model)
        {
            var result = service.AvailableHoursByDoctor (model.doctorid, new DateTime(model.year ,model.month,model.day)  , "BE470FAB-0CC0-653D736D10F6");
            return Content(result);
        }
        [HttpPost]
        public ActionResult Booking(BookingViewModel  model)
        {
            BookingModel m = new BookingModel(model); 
            var result = service.Booking(Newtonsoft.Json.JsonConvert.SerializeObject(m),  "BE470FAB-0CC0-653D736D10F6");
            return Content(result);
        }

    }
}
