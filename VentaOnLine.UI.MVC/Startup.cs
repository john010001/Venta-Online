using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(VentaOnLine.UI.MVC.Startup))]

namespace VentaOnLine.UI.MVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions()
                {
                    AuthenticationType="ApplicationCookie",
                    CookieName="AuthVentaOnLine",
                    ExpireTimeSpan = TimeSpan.FromMinutes(20),
                    LoginPath = new PathString("/Seguridad/Login")
                }
                );

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;

            //Configuración que nos va a facilitar
            //la integración de signalr del lado del servidor
            //con el lado cliente (javascript)
            app.MapSignalR();
        }
    }
}
