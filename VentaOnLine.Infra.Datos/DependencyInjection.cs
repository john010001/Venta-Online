using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VentaOnLine.Application.Queries.Base;
using VentaOnLine.Domain.Repositories;
using VentaOnLine.Infra.Datos.DataAccessBase;
using VentaOnLine.Infra.Datos.Queries;
using VentaOnLine.Infra.Datos.Repositories;

namespace VentaOnLine.Infra.Datos
{
    public static class DependencyInjection
    {
        public static void AddContext(this Container container )
        {
            container.RegisterInstance(new WriterDbContext("writerDbContext"));
            container.RegisterInstance(new ReaderDbContext("readerDbContext"));
        }

        public static void AddRepositories(this Container container)
        {
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Transient);
            container.Register<IProductoRepository, ProductoRepository>(Lifestyle.Transient);
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Transient);
        }

        public static void AddQueries(this Container container)
        {
            container.Register<IProductoQueries, ProductoQueries>(Lifestyle.Transient);
        }
    }
}
