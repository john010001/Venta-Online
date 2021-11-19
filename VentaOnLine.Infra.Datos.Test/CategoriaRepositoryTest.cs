using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VentaOnLine.Domain.Entities;
using VentaOnLine.Domain.Repositories;
using VentaOnLine.Infra.Datos.DataAccessBase;
using VentaOnLine.Infra.Datos.Repositories;

namespace VentaOnLine.Infra.Datos.Test
{
    [TestClass]
    public class CategoriaRepositoryTest
    {
        private readonly WriterDbContext _writerDbContext;
        private readonly ReaderDbContext _readerDbContext;
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaRepositoryTest()
        {
            _writerDbContext = new WriterDbContext("writerDbContext");
            _readerDbContext = new ReaderDbContext("readerDbContext");
            _categoriaRepository = new CategoriaRepository(_writerDbContext, _readerDbContext);
        }

        [TestMethod]
        public async Task AgregarCategoriaTest()
        {
            var id = await _categoriaRepository.Agregar(
                new Categoria() { 
                        Nombre=$"test-categoria - {Guid.NewGuid()}",
                        Estado=true}
                );

            Assert.IsTrue(id > 0);

        }
    }
}
