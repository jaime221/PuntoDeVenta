namespace PuntoDeVenta.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string DUI { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }
    }
}
