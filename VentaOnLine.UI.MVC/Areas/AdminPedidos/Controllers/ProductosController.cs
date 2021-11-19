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

namespace VentaOnLine.UI.MVC.Areas.AdminPedidos.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IMediator _mediator;
        public ProductosController(IMediator mediator)
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
    }
}