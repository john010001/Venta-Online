using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;
using VentaOnLine.Application;
using VentaOnLine.Infra.Datos;

namespace VentaOnLine.UI.MVC.App_Start
{
    public class DIConfig
    {
        public static void Configure()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle
                = new WebRequestLifestyle();

            //INtegrando los DI de cada componente
            container.AddContext();
            container.AddRepositories();
            container.AddQueries();
            container.AddApplication();

            container.RegisterMvcControllers
                    (Assembly.GetExecutingAssembly());

            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();

            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container)
                );

        }
    }
}