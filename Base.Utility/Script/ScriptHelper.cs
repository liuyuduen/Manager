﻿using Base.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Base.Utility
{
    /// <summary>
    /// 脚本相关操作类
    /// </summary>
    public static class ScriptHelper
    {
        #region 客户端脚本提示

        /// <summary>
        /// 客户端脚本提示
        /// </summary> 
        /// <param name="message">要弹出的内容</param>
        public static void Alert(string message)
        {
            HttpHelper.CurrentPage.ClientScript.RegisterStartupScript(HttpHelper.CurrentPage.GetType(), "", "<script>alert(\"" + EncodeScriptText(message) + "\");</script>");
        }

        #endregion

        #region 对客户端脚本进行编码

        /// <summary>
        /// 对客户端脚本进行编码
        /// </summary>
        /// <param name="script">要编码的脚本</param>
        /// <returns></returns>
        private static string EncodeScriptText(string script)
        {
            return script.Replace(@"\", @"\\").Replace("\"", "\\\"").Replace("\n", @"\n").Replace("\t", @"\t").Replace("\a", @"\a").Replace("\b", @"\b");
        }

        #endregion

        #region 显示客户端消息并进行页面跳转

        /// <summary>
        /// 显示客户端消息并整个页面重定向某个URL
        /// </summary>
        /// <param name="message">要弹出的消息</param>
        /// <param name="url">重定向的URL</param>
        public static void ShowAndTopRedirect(string message, string url)
        {
            ShowAndRedirect("top", message, url);
        }

        /// <summary>
        /// 显示客户端消息并当前页面重定向某个URL
        /// </summary>
        /// <param name="message">要弹出的消息</param>
        /// <param name="url">重定向的URL</param>
        public static void ShowAndRedirect(string message, string url)
        {
            ShowAndRedirect("window", message, url);
        }

        /// <summary>
        /// 显示客户端消息并页面重定向某个URL
        /// </summary>
        /// <param name="page">当前页或整个页面</param>
        /// <param name="message">要弹出的消息</param>
        /// <param name="url">重定向的URL</param>
        private static void ShowAndRedirect(string page, string message, string url)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<script language='javascript'>");
            builder.AppendFormat("alert('{0}');", EncodeScriptText(message));
            builder.AppendFormat(page + ".location.href='{0}'", url);
            builder.Append("</script>");
            HttpHelper.CurrentPage.ClientScript.RegisterClientScriptBlock(HttpHelper.CurrentPage.GetType(), "", builder.ToString());
        }

        #endregion

        #region 基于某个控件弹出选择提示消息

        /// <summary>
        /// 基于某个控件弹出选择提示消息
        /// </summary>
        /// <param name="Control">控件</param>
        /// <param name="message">显示的消息</param>
        public static void ShowConfirm(WebControl Control, string message)
        {
            Control.Attributes.Add("onclick", "return confirm('" + EncodeScriptText(message) + "');");
        }

        #endregion

        #region 注册一段脚本到页面底部

        /// <summary>
        /// 注册一段脚本到页面底部
        /// </summary>
        /// <param name="script">要注册的脚本</param>
        public static void RegisterStartupScript(string script)
        {
            HttpHelper.CurrentPage.ClientScript.RegisterStartupScript(HttpHelper.CurrentPage.GetType(), "", EncodeScriptText(script), true);
        }

        #endregion

        #region 注册一段脚本到页面顶部

        /// <summary>
        /// 注册一段脚本到页面顶部
        /// </summary>
        /// <param name="script">要注册的脚本</param>
        public static void RegisterClientScriptBlock(string script)
        {
            HttpHelper.CurrentPage.ClientScript.RegisterClientScriptBlock(HttpHelper.CurrentPage.GetType(), "", EncodeScriptText(script), true);
        }

        #endregion


        /// <summary>
        /// 使用Javascript语句使窗口最大化...
        /// </summary>
        public static void MaxWindow()
        {
            string Os = @"<script language='JavaScript'>
							window.moveTo(0,0);
							window.resizeTo(screen.width,screen.height);
                        </script>";
            HttpContext.Current.Response.Write(Os);
        }


        /// <summary>
        /// 使用Javascript语句使窗口最小化....
        /// </summary>
        public static void MinWindow()
        {
            string Os = @"<script language='JavaScript'>
							window.moveTo(screen.width,screen.height);
							window.resizeTo(0,0);
                        </script>";
            HttpContext.Current.Response.Write(Os);
        }


        /// <summary>
        /// 将内容拷贝到内存中...
        /// </summary>
        /// <param name="ftext">拷贝的内容！</param>
        /// <param name="message">弹出的信息！</param>
        public static void CopyText(string ftext, string message)
        {
            string js = @"<Script language='JavaScript'>
					window.clipboardData.setData('Text','{0}');
                    alert('{1}');
                  </Script>";
            HttpContext.Current.Response.Write(string.Format(js, ftext, message.ToString().Replace("'", "").Replace("\\", "|")));
        }

        /// <summary>
        /// 将内容拷贝到内存中...
        /// </summary>
        /// <param name="ftext">拷贝的内容！</param>
        /// <param name="message">弹出的信息！</param>
        public static void CopyText(string ftext, string message, string furl)
        {
            string js = @"<Script language='JavaScript'>
					window.clipboardData.setData('Text','{0}');
                    alert('{1}');
					location.href='{2}';
                  </Script>";
            HttpContext.Current.Response.Write(string.Format(js, ftext, message.ToString().Replace("'", "").Replace("\\", "|"), furl));
        }

        /// <summary>
        /// 获得脚本的弹出文本
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns>脚本的弹出文本</returns>
        public static string AlertText(string text)
        {
            return "<script>alert(\"" + EncodeScriptText(text) + "\");</script>";
        }

        /// <summary>
        /// 获得脚本的文本
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns>脚本的文本</returns>
        public static string JsText(string text)
        {
            return "<script>" + EncodeScriptText(text) + "</script>";
        }

        /// <summary>
        /// 过滤内容输出到网页
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns>过滤后的内容</returns>
        public static string FilterTagForJs(string content)
        {
            return content.Replace("'", "\\'").Replace("\r\n", "\\r\\n");
        }
    }
}
