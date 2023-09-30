using PuntoDeVenta.DTOs;
using PuntoDeVenta.Repositories.Inerfaces;

namespace PuntoDeVenta.Endpoints
{
    public static class RolEndpoints
    {
        public static void Add(this WebApplication app)
        {
            app.MapGet("api/roles", async (IRol _rol) =>
            {
                var rol = await _rol.Roles();
                return Results.Ok(rol);
            });
            app.MapGet("api/roles/{id}", async (int id, IRol _rol) =>
            {
                var rol = await _rol.Roles(id);
                if (rol == null)
                    return Results.NotFound();
                else
                    return Results.Ok(rol);
            });
            app.MapPost("api/roles", async (RolDTO rol, IRol _rol) =>
            {
                if (rol == null)
                    return Results.BadRequest();

                await _rol.Crear(rol);
                return Results.Created("api/roles/{rol.Id}", rol);
            });
            app.MapPut("api/roles/{id}", async (int id, RolDTO rol, IRol _rol) =>
            {
                var resultado = await _rol.Modificar(id, rol);
                if (resultado == 0)
                    return Results.NotFound();

                else
                    return Results.Ok(resultado);
            });
            app.MapDelete("api/roles/{id}", async (int id, IRol _rol) =>
            {
                var resultado = await _rol.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent();
            });
        }
    }
}
