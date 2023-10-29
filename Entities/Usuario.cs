using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuntoDeVenta.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        [ForeignKey(nameof(Rol))]
        public int RolId { get; set; }
        public Rol Rol { get; set; }

    }

}
