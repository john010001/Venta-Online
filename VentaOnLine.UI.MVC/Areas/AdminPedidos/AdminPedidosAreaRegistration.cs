using System.Web.Mvc;

namespace VentaOnLine.UI.MVC.Areas.AdminPedidos
{
    public class AdminPedidosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminPedidos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminPedidos_default",
                "AdminPedidos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}