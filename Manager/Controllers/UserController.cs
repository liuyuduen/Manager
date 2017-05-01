using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.Kernel;
using IBusiness;
using Base.Entity;
using Base.Utility;

namespace Manager.Controllers
{
    public class UserController : Controller
    {

        IUserService us = Base.Utility.CastleContainer.Instance.Resolve<IUserService>();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registr()
        {
            return View();
        }

        public ActionResult GetUserList(JqGridParam jqgrid)
        {
            string loginName = Request.Form["loginName"];
            var list = us.GetUserList(loginName, ref jqgrid);
            return Content(JsonHelper.ToJson(list)); ;
        }

    }
}