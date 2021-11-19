using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace VentaOnLine.UI.MVC.Models.SeguridadViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Campo requerido")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string MensajeValidacion { get; set; }

        public string ReturnUrl { get; set; }
    }
}