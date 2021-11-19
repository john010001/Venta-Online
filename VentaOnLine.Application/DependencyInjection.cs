using MediatR.SimpleInjector;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this Container container)
        {
            container.BuildMediator(Assembly.GetExecutingAssembly());
        }
    }
}
