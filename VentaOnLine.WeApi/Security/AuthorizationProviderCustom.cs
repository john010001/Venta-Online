using MediatR;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using VentaOnLine.Application.Command.AdministrarSeguridad.ValidarCliente;

namespace VentaOnLine.WeApi.Security
{
    public class AuthorizationProviderCustom: OAuthAuthorizationServerProvider
    {
        private readonly IMediator _mediator;
        public AuthorizationProviderCustom(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task ValidateClientAuthentication
                (OAuthValidateClientAuthenticationContext context)
        {
            await Task.Factory.StartNew(() => { context.Validated(); });
        }


        public override async Task GrantResourceOwnerCredentials
                (OAuthGrantResourceOwnerCredentialsContext context)
        {

            var command = new ValidarClienteCommand();
            command.Email = context.UserName;
            command.Password = context.Password;
            var resultado = await _mediator.Send(command);

            if (!resultado.HasSucceeded)
            {
                context.SetError("Usuario o contraseña incorrecta.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.Validated(identity);


        }
    }
}