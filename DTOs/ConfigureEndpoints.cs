using PuntoDeVenta.Endpoints;

namespace PuntoDeVenta.DTOs
{
    public static class ConfigureEndpoints
    {
        public static void UseEndPoints(this WebApplication app)
        {
            CategoriaProductoEndpoints.Add(app);
            RolEndpoints.Add(app);
            ClienteEndpoints.Add(app);
            UsuarioEndpoints.Add(app);
        }
    }
}
