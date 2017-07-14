using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RabiesApplication.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
      
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}