using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.Kernel;

namespace Manager.Controllers
{ 
    public class SystemController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}