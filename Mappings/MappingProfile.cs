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


            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Venta, VentaDTO>();
            CreateMap<VentaDTO, Venta>();

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();

        }
    }
}
