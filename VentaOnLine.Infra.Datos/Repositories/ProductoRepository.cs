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
    public class ProductoRepository : IProductoRepository
    {
        private readonly WriterDbContext _writerDbContext;
        private readonly ReaderDbContext _readerDbContext;
        public ProductoRepository(WriterDbContext writerDbContext,
            ReaderDbContext readerDbContext
            )
        {
            this._writerDbContext = writerDbContext;
            this._readerDbContext = readerDbContext;
        }
        public async Task<int> Agregar(Producto entidad)
        {
            //Agrega la entidad al contexto de EF
            _writerDbContext.Producto.Add(entidad);

            //Persiste en la base de datos. await  espera que la operacion asyncona termine
            await _writerDbContext.SaveChangesAsync();

            return entidad.Id;
        }

        public  async Task<bool> Eliminar(int id)
        {
            //Eliminando del contexto de EF la Producto con ID determinado
            _writerDbContext.Producto.Remove(new Producto() { Id = id });

            //Persiste en la base de datos la Producto
            return await _writerDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Producto entidad)
        {
            _writerDbContext.Producto.AddOrUpdate(entidad);
         
            //Persiste en la base de datos la Producto
            return await _writerDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Producto> Obtener(int id)
        {
            var entidad = await _readerDbContext.Producto.FindAsync(id);
            _readerDbContext.Entry(entidad).State = EntityState.Detached;
            return entidad;
        }

        public async Task<List<Producto>> Obtener(string nombre)
        {
            //SQL: 
            //Contains(nombre) = LIKE %Linea blanca%
            //StartsWith(nombre) = LIKE Linea%
            //EndsWith(nombre) = LIKE %Linea
            var query = from a in _readerDbContext.Producto
                        where a.Nombre.Contains(nombre)
                        select a;

            return await query.AsNoTracking().ToListAsync();
        }



    }
}
