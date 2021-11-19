using MediatR;
using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VentaOnline.UI.MVC.Helpers;
using VentaOnLine.Application.Command.AdministrarSeguridad.ValidarCliente;
using VentaOnLine.UI.MVC.Models.SeguridadViewModel;

namespace VentaOnLine.UI.MVC.Controllers
{
    [Authorize]
    public class SeguridadController : Controller
    {
        private readonly IMediator _mediator;
        public SeguridadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        // GET: Seguridad
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            //TODO: Falta adicionar el código que verifica

            //validar el usuario por Login=Email  y el password
            var commandLogin = new ValidarClienteCommand();
            commandLogin.Email = model.Login;
            commandLogin.Password = model.Password;

            var commandoResult = await _mediator.Send(commandLogin);

            if (commandoResult.HasSucceeded)
            {
                var cliente = commandoResult.Value;


                var claims = SecurityHelpers.CrearClaimsUsuario(cliente.Nombre, cliente.Email, cliente.Email,
                                                   cliente.IdCliente.ToString(), "rol-cliente");

                //si el usuario es válido
                var context = Request.GetOwinContext();
                var authManager = context.Authentication;
                authManager.SignIn(new ClaimsIdentity(claims,"ApplicationCookie"));
                //la url "~/"  equivale a  http://localhost
                return Redirect(model.ReturnUrl ?? "~/");
            }
            else
            {
                return View();
            }
        }
    }
}