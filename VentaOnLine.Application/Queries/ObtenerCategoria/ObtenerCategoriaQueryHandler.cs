using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentaOnLine.Domain.Entities;
using VentaOnLine.Domain.Repositories;

namespace VentaOnLine.Application.Queries.ObtenerCategoria
{
    public class ObtenerCategoriaQueryHandler
            : IRequestHandler<ObtenerCategoriaQuery, ObtenerCategoriaQueryResult>
    {

        private readonly ICategoriaRepository _categoriaRepository;
        public ObtenerCategoriaQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        public async Task<ObtenerCategoriaQueryResult> Handle(ObtenerCategoriaQuery request, CancellationToken cancellationToken)
        {
            var entidad = await _categoriaRepository.Obtener(request.Id);

            return MapResultado(entidad);

        }

        private ObtenerCategoriaQueryResult MapResultado(Categoria entidad)
        {
            return new ObtenerCategoriaQueryResult()
            {
                Id=entidad.Id,
                Nombre=entidad.Nombre,
                Estado=entidad.Estado
            };
        }
    }
}
