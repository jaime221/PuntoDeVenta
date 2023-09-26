using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Entities
{
    public class CategoriaProducto
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public byte Estado { get; set; }

        public ICollection<Product> Productos { get; set; }
    }

}
