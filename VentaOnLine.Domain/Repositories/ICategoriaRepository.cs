using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentaOnLine.Domain.Entities;

namespace VentaOnLine.Domain.Repositories
{
    public interface ICategoriaRepository
    {
        Task<int> Agregar(Categoria entidad);
        Task<Categoria> Obtener(int id);
        Task<bool> Modificar(Categoria entidad);

        Task<bool> Eliminar(int id);

        Task<List<Categoria>> Obtener(string nombre);
    }
}
