using Entities.Authentications;
using Entities.Corporates;
using Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDemo.Controllers
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
    }
}
