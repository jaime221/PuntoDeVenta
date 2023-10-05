using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Context;
using PuntoDeVenta.DTOs;
using PuntoDeVenta.Entities;
using PuntoDeVenta.Repositories.Inerfaces;

namespace PuntoDeVenta.Repositories
{
    public class CategoriaProductoRepository : ICategoriaCategoria
    {

        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public CategoriaProductoRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CategoriaProductDTO> CategoriaProduct(int id)
        {
            var entidad =await _db.CategoriaProductos.FindAsync(id ); 
            var categoria = _mapper.Map<CategoriaProducto,CategoriaProductDTO>( entidad );
             return categoria;  
        }



        public async Task<ICollection<CategoriaProductDTO>> CategoriasProductos()
        {
            var entidades = await _db.CategoriaProductos
                                    .Where(c => c.Estado == 1)
                                    .ToListAsync();

            var categoria = _mapper.Map<ICollection<CategoriaProducto>, ICollection<CategoriaProductDTO>>(entidades);
            return categoria;
        }


        public async Task<int> Crear(CategoriaProductDTO categoriaProduct)
        {
           
            var nuevaCategoria = _mapper.Map<CategoriaProductDTO, CategoriaProducto>(categoriaProduct);
            nuevaCategoria.Estado = 1;

            await _db.CategoriaProductos.AddAsync(nuevaCategoria);
            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var categoria = await _db.CategoriaProductos.FindAsync(id);
            if (categoria == null)
                return 0;

            categoria.Estado = 0; 

            return await Guardar();
        }


        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, CategoriaProductDTO categoriasProductos)
        {
            var entidad = await _db.CategoriaProductos.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = categoriasProductos.Nombre;
            _db.CategoriaProductos.Update(entidad);
            return await Guardar();
        }
    }
}
