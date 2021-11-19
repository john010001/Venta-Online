using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application.Command.AdministrarCategorias.GuardarCategorias
{
    public class GuardarCategoriaCommandValidator: 
            AbstractValidator<GuardarCategoriaCommand>
    {
        public GuardarCategoriaCommandValidator()
        {
            RuleFor(p => p.Nombre).NotEmpty().WithMessage("Especificar el nombre de la categoria")
                    .Length(5, 100).WithMessage("El nombre de la categoria debe tener " +
                    "como mínimo 5 y como máximo 100 caracteres.") ;

        }
    }
}
