using System;

namespace VentaOnLine.Application.Queries.ListarProductos
{
    public class ListarProductoQueryResult
    {
        public int Id { get; set; }

        public string NombreCategoria { get; set; }

        public string NombreProducto { get; set; }

        public  decimal Precio { get; set; }

        public decimal Stock { get; set; }

        public bool Estado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}