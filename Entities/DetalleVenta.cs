using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PuntoDeVenta.Entities
{
    public class DetalleVenta
    {

    
            [Key]
            public int Id { get; set; }

            public int Cantidad { get; set; }
            public byte Estado { get; set; }
            [ForeignKey(nameof(Venta))]
            public int VentaId { get; set; }
            public Venta Venta { get; set; }
            [ForeignKey(nameof(Product))]
            public int ProductoId { get; set; }
            public Product Product { get; set; }
    }
    }