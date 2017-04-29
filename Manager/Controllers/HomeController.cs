using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.Kernel;

namespace Manager.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            string reuslt = "OK";
            return View();
        }
    }
}