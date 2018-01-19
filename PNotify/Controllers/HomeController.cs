using Entities.Authentications;
using Infrastructures;
using PNotify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNotify.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new TrakoDbContext());
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var abcd = unitOfWork.Repository<User>().GetAll();
            return View();
        }

        public JsonResult GetNotification()
        {
            var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            NotificationComponent aNotificationComponent = new NotificationComponent();
            var list = aNotificationComponent.GetNotifications(notificationRegisterTime);
            //update session here for get only new added contacts (notification)
            Session["LastUpdate"] = DateTime.Now;
            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
