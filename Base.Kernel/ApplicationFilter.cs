using Base.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Base.Kernel
{
    /// <summary>
    ///拦截器 执行顺序：OnActionExecuting-->Action中的代码-->OnActionExecuted-->OnResultExecuting-->OnResultExecuted 
    /// </summary>
    public class ApplicationFilter : FilterAttribute, IAuthorizationFilter, IExceptionFilter, IActionFilter, IResultFilter
    {
        // IManageProvider manager = CastleContainer.Instance.Resolve<IManageProvider>();

        /// <summary>
        /// 授权拦截器接口  判断时候有权限执行后面的Action，此接口在任何拦截器之前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            ////登录是否过期
            //if (manager.IsOverdue())
            //{
            //    filterContext.Result = new RedirectResult("~/Login/Default");
            //}

            string controller = filterContext.RouteData.Values["controller"] as string;
            string action = filterContext.RouteData.Values["action"] as string;



        }
        /// <summary>
        /// IExceptionFilter 成员 当异常发生时需要执行的内容
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            //string controller = filterContext.RouteData.Values["controller"] as string;
            //string action = filterContext.RouteData.Values["action"] as string;

            ////Log.Error(string.Format("【{0}:{1}】Log发生异常!{2}", controller, action, filterContext.Exception.Message));

            //filterContext.ExceptionHandled = true;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }
    }
}