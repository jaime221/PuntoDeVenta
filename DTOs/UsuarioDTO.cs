using System;

namespace PuntoDeVenta.DTOs
{
	public class UsuarioDTO
	{
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

    }
    public class UsuarioLogin
    {
        public string Correo { get; set; }
        public string Clave { get; set; }

    }

}
