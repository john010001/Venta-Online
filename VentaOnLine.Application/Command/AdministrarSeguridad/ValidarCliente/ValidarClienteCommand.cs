using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnLine.Application.Common;

namespace VentaOnLine.Application.Command.AdministrarSeguridad.ValidarCliente
{
    public class ValidarClienteCommand: IRequest<IResult<ValidarClienteCommandResult>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
