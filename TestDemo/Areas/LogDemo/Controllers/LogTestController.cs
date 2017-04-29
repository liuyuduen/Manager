using Base.Kernel;
using Base.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDemo.Areas.LogDemo.Controllers
{
    [ApplicationFilter]
    public class LogTestController : Controller
    {
        public ViewResult Index()
        {
            int num = Convert.ToInt32("A");

            return View();
        }
    }
}