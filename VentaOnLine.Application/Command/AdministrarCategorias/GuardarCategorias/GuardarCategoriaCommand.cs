using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application.Command.AdministrarCategorias.GuardarCategorias
{
    public class GuardarCategoriaCommand: IRequest<int>
    {
        public string Nombre { get; set; }

        public bool Estado { get; set; }

        public int? IdCategoria { get; set; }
    }
}
