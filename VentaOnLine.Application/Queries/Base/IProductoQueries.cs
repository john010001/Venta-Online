using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnLine.Application.Queries.ListarProductos;

namespace VentaOnLine.Application.Queries.Base
{
    public interface IProductoQueries
    {
        Task<IEnumerable<ListarProductoQueryResult>> 
            ListarProductosQuery(int? idCategoria, string nombreProducto);
    }
}
