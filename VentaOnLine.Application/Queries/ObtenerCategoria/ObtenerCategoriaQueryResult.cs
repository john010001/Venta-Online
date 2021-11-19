using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaOnLine.Application.Queries.ObtenerCategoria
{
    public class ObtenerCategoriaQueryResult
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}
