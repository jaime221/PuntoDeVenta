using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Context;
using PuntoDeVenta.DTOs;
using PuntoDeVenta.Entities;
using PuntoDeVenta.Repositories.Inerfaces;

namespace PuntoDeVenta.Repositories
{
    public class RolRepository : IRol
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public RolRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

  public async Task<RolDTO> Roles(int id)
{
    var entidad = await _db.Roles.FindAsync(id);

    if (entidad != null && entidad.Estado == 1)
    {
        var rolDTO = _mapper.Map<Rol, RolDTO>(entidad);
        return rolDTO;
    }
    else
    {
        return null;
    }
}


        public async Task<ICollection<RolDTO>> Roles()
        {
            var entidades = await _db.Roles
                                    .Where(c => c.Estado == 1)
                                    .ToListAsync();

            var rol = _mapper.Map<ICollection<Rol>, ICollection<RolDTO>>(entidades);
            return rol;
        }


        public async Task<int> Crear(RolDTO rol)
        {

            var nuevoRol = _mapper.Map<RolDTO, Rol>(rol);
            nuevoRol.Estado = 1;

            await _db.Roles.AddAsync(nuevoRol);
            return await Guardar();
        }

      

        public async Task<int> Eliminar(int id)
        {
            var rol = await _db.Roles.FindAsync(id);
            if (rol == null)
                return 0;

            rol.Estado = 0;

            return await Guardar();
        }


        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, RolDTO rol)
        {
            var entidad = await _db.Roles.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = rol.Nombre;
            _db.Roles.Update(entidad);
            return await Guardar();
        }

     


    }
}
