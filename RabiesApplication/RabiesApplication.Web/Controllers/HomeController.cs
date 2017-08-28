using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RabiesApplication.Web.Controllers
{
 
    public class HomeController : Controller
    {
      
        public ActionResult MainIndex()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}