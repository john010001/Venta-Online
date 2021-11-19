using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using VentaOnLine.Domain.Entities;
using VentaOnLine.Domain.Repositories;
using VentaOnLine.Infra.Datos.DataAccessBase;
using System.Linq;
using System.Data.Entity.Migrations;

namespace VentaOnLine.Infra.Datos.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly WriterDbContext _writerDbContext;
        private readonly ReaderDbContext _readerDbContext;
        public ClienteRepository(WriterDbContext writerDbContext,
            ReaderDbContext readerDbContext
            )
        {
            this._writerDbContext = writerDbContext;
            this._readerDbContext = readerDbContext;
        }
        public async Task<int> Agregar(Cliente entidad)
        {
            //Agrega la entidad al contexto de EF
            _writerDbContext.Cliente.Add(entidad);

            //Persiste en la base de datos. await  espera que la operacion asyncona termine
            await _writerDbContext.SaveChangesAsync();

            return entidad.Id;
        }

        public  async Task<bool> Eliminar(int id)
        {
            //Eliminando del contexto de EF la Cliente con ID determinado
            _writerDbContext.Cliente.Remove(new Cliente() { Id = id });

            //Persiste en la base de datos la Cliente
            return await _writerDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Cliente entidad)
        {
            _writerDbContext.Cliente.AddOrUpdate(entidad);
           
            //Persiste en la base de datos la Cliente
            return await _writerDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Cliente> Obtener(int id)
        {
            var entidad = await _readerDbContext.Cliente.FindAsync(id);
            _readerDbContext.Entry(entidad).State = EntityState.Detached;
            return entidad;
        }

        public async Task<List<Cliente>> Obtener(string nombre)
        {
            //SQL: 
            //Contains(nombre) = LIKE %Linea blanca%
            //StartsWith(nombre) = LIKE Linea%
            //EndsWith(nombre) = LIKE %Linea
            var query = from a in _readerDbContext.Cliente
                        where a.Nombre.Contains(nombre)
                        select a;

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> Obtener(string email, string password)
        {
            var query = from a in _readerDbContext.Cliente
                        where a.Email == email && a.Password==password
                        select a;

            return await query.AsNoTracking().FirstOrDefaultAsync();

        }
    }
}
