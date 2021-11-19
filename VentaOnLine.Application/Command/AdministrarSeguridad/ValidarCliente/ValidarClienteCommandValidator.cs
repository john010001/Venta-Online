using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application.Command.AdministrarSeguridad.ValidarCliente
{
    public class ValidarClienteCommandValidator: AbstractValidator<ValidarClienteCommand>
    {
        public ValidarClienteCommandValidator()
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Especificar el email");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Especificar el password");
        }
    }
}
