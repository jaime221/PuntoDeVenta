using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }
        public int stock { get; set; }
        [ForeignKey(nameof(CategoriaProducto))]
        public int IdCategoria { get; set; }
        public CategoriaProducto CategoriaProducto { get; set;}
    }
}
