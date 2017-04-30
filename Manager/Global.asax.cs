using Base.Utility;
using Base.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Manager
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = this.Context.Server.GetLastError();
            if (ex != null)
            { 
                Log.Error(ex.Message, ex);
                //登录是否过期
                //if (ManageProvider.Provider.IsOverdue())
                //{
                //    HttpContext.Current.Response.Redirect("~/Login/Default");
                //}
                //Dictionary<string, string> modulesError = new Dictionary<string, string>();
                //modulesError.Add("发生时间", DateTime.Now.ToString());
                //modulesError.Add("错误描述", ex.Message.Replace("\r\n", ""));
                //modulesError.Add("错误对象", ex.Source);
                //modulesError.Add("错误页面", "" + HttpContext.Current.Request.Url + "");
                //modulesError.Add("浏览器IE", HttpContext.Current.Request.UserAgent);
                //modulesError.Add("服务器IP", NetHelper.GetIPAddress());
                //Application["error"] = modulesError;
                //HttpContext.Current.Response.Redirect("~/Error/Index");
            }
        }
    }
}
