using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //int a = Convert.ToInt32("a");
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}