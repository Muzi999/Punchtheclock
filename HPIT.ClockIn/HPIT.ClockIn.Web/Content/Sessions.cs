using HPIT.ClockIn.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPIT.ClockIn.Web.Content
{
    public class Sessions: Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var user = Session["UserInfo"] as List<LoinTable>;
            if (user==null)
            {
                filterContext.Result = RedirectToAction("Login","Home",new {url=Request.RawUrl });
                return  ;
            }
        }


    }
}