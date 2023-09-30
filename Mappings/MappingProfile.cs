using AutoMapper;
using PuntoDeVenta.DTOs;
using PuntoDeVenta.Entities;

namespace PuntoDeVenta.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<CategoriaProducto, CategoriaProductDTO>();
            CreateMap<CategoriaProductDTO, CategoriaProducto>();

            CreateMap<Rol, RolDTO>();
            CreateMap<RolDTO, Rol>();

           
        }
    }
}
