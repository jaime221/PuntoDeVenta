using PuntoDeVenta.Context;
using PuntoDeVenta.DTOs;
using PuntoDeVenta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.UnitTest
{
    public class CategoriaProductoTest
    {
        private readonly CategoriaProductoRepository _categoriaProductoRepository;
        public CategoriaProductoTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>().UseSqlServer("Data Source=DESKTOP-D4OC9KR;Initial Catalog=PuntoVenta;Integrated Security=True ; Trust Server Certificate = True").Options;

            var dbContext = new ApplicationDBContext(options);

            var configurations = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = configurations.CreateMapper();

            _categoriaProductoRepository = new CategoriaProductoRepository(dbContext, mapper);
        }

        [Fact]
        public async void TestCrear()
        {
            var obj = new CategoriaProductDTO();
            obj.Nombre = "Algo";

            int resultado = await _categoriaProductoRepository.Crear(obj);

            Assert.True(resultado == 1);
        }
    }
}
