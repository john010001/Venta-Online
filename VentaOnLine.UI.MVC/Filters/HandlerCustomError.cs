using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace VentaOnLine.UI.MVC.Filters
{
    public class HandlerCustomError: HandleErrorAttribute
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType
            );

        public override void OnException(ExceptionContext filterContext)
        {
            var viewResult = new ViewResult() { ViewName="Error"};
            viewResult.ViewBag.Errors = filterContext.Exception.Message;
            filterContext.Result = viewResult;
            filterContext.ExceptionHandled = true;

            //Guardando el error en el archivo de log
            log.Error(filterContext.Exception);

            base.OnException(filterContext);
        }
    }
}