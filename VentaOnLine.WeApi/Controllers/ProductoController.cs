using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VentaOnLine.Application.Queries.ListarProductos;

namespace VentaOnLine.WeApi.Controllers
{
    [Authorize]
    public class ProductoController : ApiController
    {
        private readonly IMediator _mediator;
        
        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// URL:https://localhost:44389/api/producto/consultar
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
       // [AllowAnonymous]
        [HttpGet]
        public async Task<IHttpActionResult> Consultar([FromUri]ListarProductoQuery request)
        {
            var resultado = await _mediator.Send(request);

            return Ok(resultado);
        }
    }
}
