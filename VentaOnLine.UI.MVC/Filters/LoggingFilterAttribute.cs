using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace VentaOnLine.UI.MVC.Filters
{
    public class LoggingFilterAttribute: ActionFilterAttribute
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
            MethodBase.GetCurrentMethod().DeclaringType
            );
        //Se ejecuta antes de ingresar al Action
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var message = $"Iniciando la ejecución del controlador: " + 
                      $"{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}" +
                      $", Action: {filterContext.ActionDescriptor.ActionName}" +
                      $", Hora de inicio: {DateTime.Now}";

            log.Info(message);

            base.OnActionExecuting(filterContext);
        }

        //Se ejecuta despues de salir del Action
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var message = $"Finalizando la ejecución del controlador: " +
                     $"{filterContext.ActionDescriptor.ControllerDescriptor.ControllerName}" +
                     $", Action: {filterContext.ActionDescriptor.ActionName}" +
                     $", Hora de fin: {DateTime.Now}";

            log.Info(message);

            base.OnActionExecuted(filterContext);
        }
    }
}