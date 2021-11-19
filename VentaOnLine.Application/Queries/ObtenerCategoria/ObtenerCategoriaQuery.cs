using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application.Queries.ObtenerCategoria
{
    public class ObtenerCategoriaQuery:
            IRequest<ObtenerCategoriaQueryResult>
    {
        public int Id { get; set; }
    }
}
