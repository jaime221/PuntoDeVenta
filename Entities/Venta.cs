using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Entities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public decimal Total { get; set; }
        [ForeignKey(nameof(ProductoId))]
        public int ProductoId { get; set; }
        public Product Producto { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public byte Estado { get; set; }
        public ICollection<DetalleVenta> DetalleVentas { get; set; }

    }
}


//create table Ventas(
//Id int identity(1,1) not null,
//ClienteId int not null,
//ProductoId int not null,
//EmpleadoId int not null,
//Estado tinyint not null,
