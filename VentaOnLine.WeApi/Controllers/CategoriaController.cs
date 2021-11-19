using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VentaOnLine.Application.Command.AdministrarCategorias.GuardarCategorias;
using VentaOnLine.Application.Queries.ListarCategorias;
using VentaOnLine.WeApi.Filters;

namespace VentaOnLine.WeApi.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //URL: https://localhost:44389/api/categoria/consultar
        [HttpGet]
        public async Task<IHttpActionResult> Consultar(ListarCategoriaQuery request)
        {
            var resultado = await _mediator.Send(request);

            return Ok(resultado);
        }

        //URL: https://localhost:44389/api/categoria/agregar
        [HttpPost]      
        public async Task<IHttpActionResult> Agregar(GuardarCategoriaCommand request)
        {
            //try
            //{
            
                var resultado = await _mediator.Send(request);

                return Ok(resultado);
            //}
            //catch(Exception ex)
            //{
               // return InternalServerError();
            //}
        }
    }
}