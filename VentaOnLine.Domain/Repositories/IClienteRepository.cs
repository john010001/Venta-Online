
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VentaOnLine.Domain.Entities;

namespace VentaOnLine.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<int> Agregar(Cliente entidad);
        Task<Cliente> Obtener(int id);

        Task<Cliente> Obtener(string email, string password);
        Task<bool> Modificar(Cliente entidad);

        Task<bool> Eliminar(int id);

        Task<List<Cliente>> Obtener(string nombre);
    }
}
