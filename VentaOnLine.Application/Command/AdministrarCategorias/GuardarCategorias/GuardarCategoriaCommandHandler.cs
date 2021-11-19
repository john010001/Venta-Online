using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VentaOnLine.Application.Common;
using VentaOnLine.Application.Common.Exceptions;
using VentaOnLine.Domain.Entities;
using VentaOnLine.Domain.Repositories;

namespace VentaOnLine.Application.Command.AdministrarCategorias.GuardarCategorias
{
    public class GuardarCategoriaCommandHandler :
                IRequestHandler<GuardarCategoriaCommand, int>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public GuardarCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<int> Handle(GuardarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var resultado = 0;
            var validator = new GuardarCategoriaCommandValidator();
            var validatorResult = validator.Validate(request);

            if (!validatorResult.IsValid)
                throw new ValidationException(validatorResult);

            if (request.IdCategoria.HasValue && request.IdCategoria>0)  //modificar
            {
                var verificarCategoria = await _categoriaRepository.Obtener(request.IdCategoria.Value);
                if(verificarCategoria==null)
                    throw new ValidationException("La categoría no existe");

                await _categoriaRepository.Modificar(CategoriaMapper(request));
                resultado = request.IdCategoria.Value;
            }
            else
                resultado = await _categoriaRepository.Agregar(CategoriaMapper(request));


            return resultado;
        }

        private Categoria CategoriaMapper(GuardarCategoriaCommand request)
        {
            return new Categoria() {
                Id=request.IdCategoria??0,
                Nombre = request.Nombre, 
                Estado = true };
        }
    }
}
