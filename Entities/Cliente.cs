using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PuntoDeVenta.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string DUI { get; set; }

        public string Telefono { get; set; }
        public byte Estado { get; set; }
        public string Correo { get; set; }

    }
}
