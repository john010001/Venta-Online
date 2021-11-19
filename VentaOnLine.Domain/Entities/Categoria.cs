using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VentaOnLine.Domain.Entities
{
   // [Table("tbl_Categoria")]
    public class Categoria
    {
        public int Id { get; set; }

     //   [Column("col_Nombre")]
        public string Nombre { get; set; }

        public bool Estado { get; set; }
    }
}
