using System.Web;
using System.Web.Mvc;
using VentaOnLine.UI.MVC.Filters;

namespace VentaOnLine.UI.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //configurando el filtro de logging para todos los controladores
            //y acciones del proyecto MVC
            filters.Add(new LoggingFilterAttribute());
            //filters.Add(new HandlerCustomError());

            filters.Add(new HandleErrorAttribute());


        }
    }
}
