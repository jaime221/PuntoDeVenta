using PuntoDeVenta.DTOs;

namespace PuntoDeVenta.Repositories.Inerfaces
{
    public interface IRol
    {
        Task<int> Crear(RolDTO rol);
        Task<ICollection<RolDTO>> Roles();
        Task<RolDTO> Roles(int id);
        Task<int> Modificar(int id, RolDTO rol);
        Task<int> Eliminar(int id);
        Task<int> Guardar();
    }
}
