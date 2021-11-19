

using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using VentaOnLine.Application;
using VentaOnLine.Infra.Datos;

namespace VentaOnLine.WeApi.App_Start
{
    public class DIConfig
    {
        public static void Configure()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle
                = new AsyncScopedLifestyle();

            //INtegrando los DI de cada componente
            container.AddContext();
            container.AddRepositories();
            container.AddQueries();
            container.AddApplication();

            container.RegisterWebApiControllers
                    (GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                        new SimpleInjectorWebApiDependencyResolver(container);
                
        }

    }
}