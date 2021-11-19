using System;
using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using VentaOnLine.WeApi.Security;

[assembly: OwinStartup(typeof(VentaOnLine.WeApi.Startup))]

namespace VentaOnLine.WeApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var httpConfig = GlobalConfiguration.Configuration;
            var mediator = (IMediator)httpConfig.DependencyResolver.GetService(typeof(IMediator));

            var oAuthServerOpstions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new AuthorizationProviderCustom(mediator)
            };

            app.UseOAuthAuthorizationServer(oAuthServerOpstions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
