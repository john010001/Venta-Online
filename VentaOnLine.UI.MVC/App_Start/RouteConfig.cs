using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VentaOnLine.UI.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Definiendo una ruta estática
           //URL: http://localhost:8990/clasificacion
            routes.MapRoute(
                name:"ClasificacionRoute",
                url:"Clasificaciondeproductos",
                defaults: new {controller="Categoria", action="Index",
                        id= UrlParameter.Optional}
                );
            
            //ruta por default tiene que estar al final
            //de todo el mapa de rutas
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
