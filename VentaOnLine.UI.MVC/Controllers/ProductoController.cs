using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VentaOnLine.Application.Queries.ListarCategorias;
using VentaOnLine.Application.Queries.ListarProductos;
using VentaOnLine.UI.MVC.Models.ProductoViewModels;

namespace VentaOnLine.UI.MVC.Controllers
{
    //[Authorize(Roles = "rol-cliente")]
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly IMediator _mediator;
        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: Producto
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var viewModel = new BusquedaProductosViewModel();           
            // Selected = item.Id==20
            viewModel.Categorias = await ListadoCategoriasCombo();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> IndexAjax()
        {
            var viewModel = new BusquedaProductosViewModel();
            // Selected = item.Id==20
            viewModel.Categorias = await ListadoCategoriasCombo();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(BusquedaProductosViewModel viewModel)
        {
            var listarProductoQuery = new ListarProductoQuery();
            listarProductoQuery.Nombre = viewModel.NombreProducto;
            listarProductoQuery.IdCategoria = viewModel.IdCategoria;

            viewModel.Categorias = await ListadoCategoriasCombo();
            viewModel.Resultado = await _mediator.Send(listarProductoQuery);

            return View(viewModel);

        }
        [HttpGet]
        public async Task<ActionResult> IndexJQueryAjax()
        {
            var viewModel = new BusquedaProductosViewModel();
            // Selected = item.Id==20
            viewModel.Categorias = await ListadoCategoriasCombo();

            return View(viewModel);
        }


        [HttpPost]
        public async Task<ActionResult> IndexResultadoAjax(BusquedaProductosViewModel viewModel)
        {
            var listarProductoQuery = new ListarProductoQuery();
            listarProductoQuery.Nombre = viewModel.NombreProducto;
            listarProductoQuery.IdCategoria = viewModel.IdCategoria;

            viewModel.Resultado = await _mediator.Send(listarProductoQuery);

            return PartialView(viewModel);

        }

        private async Task<IEnumerable<SelectListItem>> ListadoCategoriasCombo()
        {
            var consultaCategoriasRequest = new ListarCategoriaQuery();
            var listadoCategorias = await _mediator.Send(consultaCategoriasRequest);

            IEnumerable<SelectListItem> listadoCategoriasSelectListItem =
                listadoCategorias.OrderBy(item => item.Nombre)
                .Select(item => new SelectListItem()
                {
                    Text = item.Nombre,
                    Value = item.Id.ToString()
                });

            return listadoCategoriasSelectListItem;
        }

        public async Task<ActionResult> Agregar()
        {
            var model = new ProductoViewModel();
            var categoriasQuery = new ListarCategoriaQuery() { Nombre = "" };
            var categorias = await _mediator.Send(categoriasQuery);
            model.Categorias = categorias.OrderBy(item => item.Nombre)
                                    .Select(item => new SelectListItem()
                                    { Text = item.Nombre, Value = item.Id.ToString() });


           

            return PartialView(model);
        }
    }
}