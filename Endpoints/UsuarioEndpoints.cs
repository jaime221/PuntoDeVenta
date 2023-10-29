using PuntoDeVenta.DTOs;
using PuntoDeVenta.Repositories.Inerfaces;

namespace PuntoDeVenta.Endpoints
{
    public static class UsuarioEndpoints
    {
        public static void Add(this WebApplication app)
        {
            app.MapPost("api/login", async (UsuarioLogin usuario,IUsuario _usuario) =>
            {
                var login = await _usuario.Login(usuario);
                if (login is null)
                    return Results.NotFound(new { mensaje = "credencales inavalidas" });
                 var token  = _usuario.GenerarToken(login);
                login.Clave = string.Empty;
                if (string.IsNullOrEmpty(token))
                {
                    return Results.Unauthorized();
                }
                else
                {
                    return Results.Ok(token);
                }
            }).WithTags("Usuario");
        }
    }
}
