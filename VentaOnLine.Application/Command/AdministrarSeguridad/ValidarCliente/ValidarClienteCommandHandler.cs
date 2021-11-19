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

namespace VentaOnLine.Application.Command.AdministrarSeguridad.ValidarCliente
{
    public class ValidarClienteCommandHandler :
        IRequestHandler<ValidarClienteCommand, IResult<ValidarClienteCommandResult>>
    {
        private readonly IClienteRepository _clienteRepository;

        public ValidarClienteCommandHandler(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<IResult<ValidarClienteCommandResult>> Handle(ValidarClienteCommand request, CancellationToken cancellationToken)
        {
            IResult<ValidarClienteCommandResult> resultado = null;

            try
            {
                var validator = new ValidarClienteCommandValidator();
                var validatorResult = validator.Validate(request);

                if (!validatorResult.IsValid)
                {
                    resultado = new FailureResult<ValidarClienteCommandResult>(validatorResult.ToString(";"));
                }
                else
                {
                    string passwordEncriptado = GenerarHashPassword(request.Password);

                    var cliente = await _clienteRepository.Obtener(request.Email, passwordEncriptado);

                    if (cliente == null)
                        resultado = new FailureResult<ValidarClienteCommandResult>("El cliente no existe");
                    else
                        resultado = new SuccessResult<ValidarClienteCommandResult>(ResultadoMapper(cliente));
                }
                
            }
            catch(Exception ex)
            {
                resultado = new FailureResult<ValidarClienteCommandResult>($"Ocurrio un error {ex.Message}");
            }

            return resultado;

        }

        private ValidarClienteCommandResult ResultadoMapper(Cliente cliente)
        {
            return new ValidarClienteCommandResult()
            {
                IdCliente = cliente.Id,
                DNI=cliente.DNI,
                Nombre=cliente.Nombre,
                Email=cliente.Email
            };
        }

        private string GenerarHashPassword(string password)
        {
            return password;
        }
    }
}
