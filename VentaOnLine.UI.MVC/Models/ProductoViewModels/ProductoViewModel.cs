using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentaOnLine.UI.MVC.Models.ProductoViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "Debe especificar la categoría")]
        public int IdCategoria { get; set; }

        public IEnumerable<SelectListItem> Categorias { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe especificar el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Precio es requerido")]
        [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }

        public decimal Stock { get; set; }
    }
}