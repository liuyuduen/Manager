using Base.Utility;
using IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDemo.Areas.CastleDemo.Controllers
{
    public class CastleController : Controller
    {
        public ActionResult Index()
        {



            IUserService userSvc = CastleContainer.Instance.Resolve<IUserService>();

            userSvc.GetUserByID("UserID");

            return View();
        }
    }
}