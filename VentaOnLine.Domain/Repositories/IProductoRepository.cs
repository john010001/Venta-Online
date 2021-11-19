using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentaOnLine.Domain.Entities;

namespace VentaOnLine.Domain.Repositories
{
    public interface IProductoRepository
    {
        Task<int> Agregar(Producto entidad);
        Task<Producto> Obtener(int id);
        Task<bool> Modificar(Producto entidad);

        Task<bool> Eliminar(int id);

        Task<List<Producto>> Obtener(string nombre);
    }
}
