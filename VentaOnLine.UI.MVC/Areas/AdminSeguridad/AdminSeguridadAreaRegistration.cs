using System.Web.Mvc;

namespace VentaOnLine.UI.MVC.Areas.AdminSeguridad
{
    public class AdminSeguridadAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminSeguridad";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminSeguridad_default",
                "AdminSeguridad/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}