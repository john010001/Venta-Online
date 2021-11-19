using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application.Queries.ListarProductos
{
    public class ListarProductoQuery:
            IRequest<IEnumerable<ListarProductoQueryResult>>
    {
        public int? IdCategoria { get; set; }

        public string Nombre { get; set; }
    }
}
