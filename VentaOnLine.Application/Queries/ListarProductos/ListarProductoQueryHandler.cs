using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentaOnLine.Application.Queries.Base;

namespace VentaOnLine.Application.Queries.ListarProductos
{
    public class ListarProductoQueryHandler :
        IRequestHandler<ListarProductoQuery,
            IEnumerable<ListarProductoQueryResult>>
    {

        private readonly IProductoQueries _productoQueries;

        public ListarProductoQueryHandler(IProductoQueries productoQueries)
        {
            _productoQueries = productoQueries;
        }
        public async Task<IEnumerable<ListarProductoQueryResult>> Handle(ListarProductoQuery request, CancellationToken cancellationToken)
        {
            return await _productoQueries.ListarProductosQuery(request.IdCategoria, request.Nombre);
        }
    }
}
