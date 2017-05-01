using Base.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manager.Controllers
{ 
    public class ModuleController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}