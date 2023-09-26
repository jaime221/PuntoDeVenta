using PuntoDeVenta.DTOs;

namespace PuntoDeVenta.Repositories.Inerfaces
{
    public interface ICategoriaCategoria
    {
        Task<int> Crear(CategoriaProductDTO categoriaProduct);
        Task<ICollection<CategoriaProductDTO>>CategoriasProductos();
        Task<CategoriaProductDTO> CategoriaProduct(int id);
        Task<int> Modificar(int id, CategoriaProductDTO categoriasProductos);
        Task<int> Eliminar(int id);
        Task<int> Guardar();

    }
}
