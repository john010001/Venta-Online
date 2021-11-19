using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VentaOnLine.Application.Command.AdministrarCategorias.GuardarCategorias;
using VentaOnLine.Application.Queries.ListarCategorias;
using VentaOnLine.Application.Queries.ObtenerCategoria;
using VentaOnLine.UI.MVC.Filters;

namespace VentaOnLine.UI.MVC.Controllers
{
    [Authorize]
    //  [LoggingFilter] //Aplica a nivel todo el controlador para cada Action
    public class CategoriaController : Controller
    {
        private readonly IMediator _mediator;
        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

       // [LoggingFilter]//Aplica para el action Index
        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<ListarCategoriaQueryResult>();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(ListarCategoriaQuery request)
        {
            ViewBag.FiltroPorNombre = request.Nombre;
            var resultado = await _mediator.Send(request);

            return View(resultado);
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            ViewBag.Title = "Agregar categoría";

            var model = new ObtenerCategoriaQueryResult(); //pasando un modelo vacio
            return View(model);
        }

        [HttpGet]
        public ActionResult AgregarPartial()
        {
            var model = new ObtenerCategoriaQueryResult(); //pasando un modelo vacio
            return PartialView("Agregar",model);
        }

        [HttpGet]
        public async Task<ActionResult> Modificar(int id)
        {
            var comando = new ObtenerCategoriaQuery() { Id=id};
            var resultado = await _mediator.Send(comando); //modelos con los datos de la categoria

            ViewBag.Title = "Modificar categoría";
            return View("Agregar", resultado);
        }

        [HttpGet]
        public async Task<ActionResult> ModificarPartial(int id)
        {
            var comando = new ObtenerCategoriaQuery() { Id = id };
            var resultado = await _mediator.Send(comando); //modelos con los datos de la categoria

            ViewBag.Title = "Modificar categoría";
            return PartialView("Agregar", resultado);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Guardar(GuardarCategoriaCommand request)
        {
            await _mediator.Send(request);

            return RedirectToAction("Index");
        }

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public async Task<ActionResult> Modificar(GuardarCategoriaCommand request)
        //{
        //    await _mediator.Send(request);

        //    return RedirectToAction("Index");
        //}
    }
}