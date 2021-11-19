using System.Web;
using System.Web.Mvc;
using VentaOnLine.WeApi.Filters;

namespace VentaOnLine.WeApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
        
            filters.Add(new HandleErrorAttribute());
        }
    }
}
