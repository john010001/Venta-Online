using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VentaOnLine.Application.Queries.ListarProductos;

namespace VentaOnLine.UI.MVC.Models.ProductoViewModels
{
    public class BusquedaProductosViewModel
    {
        public IEnumerable<SelectListItem> Categorias { get; set; }

        public int? IdCategoria { get; set; }

        public string NombreProducto { get; set; }

        public IEnumerable<ListarProductoQueryResult> Resultado { get; set; }
    }
}