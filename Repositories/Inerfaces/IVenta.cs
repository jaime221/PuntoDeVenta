using PuntoDeVenta.DTOs;

namespace PuntoDeVenta.Repositories.Inerfaces
{
    public interface IVenta
    {
        Task<int> Crear(VentaDTO venta);
        Task<ICollection<VentaDTO>> Ventas();
        Task<VentaDTO> CategoriaProduct(int id);
        Task<int> Modificar(int id, VentaDTO venta);
        Task<int> Eliminar(int id);
        Task<int> Guardar();
    }
}
