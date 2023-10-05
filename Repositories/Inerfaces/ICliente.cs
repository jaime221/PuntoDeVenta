using PuntoDeVenta.DTOs;

namespace PuntoDeVenta.Repositories.Inerfaces 
{
    public interface ICliente
    {
        Task<int> Crear(ClienteDTO cliente);
        Task<ICollection<ClienteDTO>> Clientes();
        Task<ClienteDTO> Clientes(int id);
        Task<int> Modificar(int id, ClienteDTO cliente);
        Task<int> Eliminar(int id);
        Task<int> Guardar();
    }
}
