using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnLine.Application.Queries.Base;
using VentaOnLine.Application.Queries.ListarProductos;
using VentaOnLine.Infra.Datos.DataAccessBase;

namespace VentaOnLine.Infra.Datos.Queries
{   
    public class ProductoQueries : IProductoQueries
    {
        private readonly ReaderDbContext _readerDbContext;
        public ProductoQueries(ReaderDbContext readerDbContext)
        {
            _readerDbContext = readerDbContext;
        }
        public async Task<IEnumerable<ListarProductoQueryResult>> 
                ListarProductosQuery(int? idCategoria, string nombreProducto)
        {

            nombreProducto = nombreProducto ?? "";
            var query = from a in _readerDbContext.Producto
                        join b in _readerDbContext.Categoria
                        on a.IdCategoria equals b.Id
                        where (idCategoria == null || a.IdCategoria == idCategoria)
                        && (a.Nombre.Contains(nombreProducto))
                        orderby a.Nombre
                        select new ListarProductoQueryResult()
                        {
                            Id = a.Id,
                            NombreProducto = a.Nombre,
                            Precio = a.Precio,
                            Stock = a.Stock,
                            FechaCreacion = a.FechaCreacion,
                            NombreCategoria = b.Nombre,
                            Estado = a.Estado
                        };

            return await query.ToListAsync();

        }
    }
}
