using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentaOnLine.Application.Common;
using VentaOnLine.Domain.Repositories;

namespace VentaOnLine.Application.Queries.ListarCategorias
{
    public class ListarCategoriaQueryHandler
        : IRequestHandler<ListarCategoriaQuery, List<ListarCategoriaQueryResult>>
    {

        private readonly ICategoriaRepository _categoriaRepository;
        public ListarCategoriaQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<ListarCategoriaQueryResult>> Handle(ListarCategoriaQuery request, 
                CancellationToken cancellationToken)
        {
            var resultado = await _categoriaRepository.Obtener(request.Nombre ?? "");

            //mapping de objetos de Categoria-->ListarCategoriaQueryResult
            return resultado.Select(item => new ListarCategoriaQueryResult()
            {
                Id = item.Id,
                Nombre = item.Nombre,
                Estado = item.Estado
            }).ToList();
        }
    }
}
