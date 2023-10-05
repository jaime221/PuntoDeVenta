using PuntoDeVenta.DTOs;
using PuntoDeVenta.Entities;
using PuntoDeVenta.Repositories.Inerfaces;

namespace PuntoDeVenta.Endpoints
{
    public static class ClienteEndpoints
    {
        public static void Add(this WebApplication app)
        {
            app.MapGet("api/clientes", async (ICliente _cliente) =>
            {
                var cliente = await _cliente.Clientes();
                return Results.Ok(cliente);
            });
            app.MapGet("api/clientes/{id}", async (int id, ICliente _cliente) =>
            {
                var cliente = await _cliente.Clientes(id);
                if (cliente == null)
                    return Results.NotFound();
                else
                    return Results.Ok(cliente);
            });
            app.MapPost("api/clientes", async (ClienteDTO cliente, ICliente _cliente) =>
            {
                if (cliente == null)
                    return Results.BadRequest();

                await _cliente.Crear(cliente);
                return Results.Created("api/Clientes/{rol.Id}", cliente);
            });
            app.MapPut("api/clientes/{id}", async (int id, ClienteDTO cliente, ICliente _cliente) =>
            {
                var resultado = await _cliente.Modificar(id, cliente);
                if (resultado == 0)
                    return Results.NotFound();

                else
                    return Results.Ok(resultado);
            });
            app.MapDelete("api/clientes/{id}", async (int id, ICliente _cliente) =>
            {
                var resultado = await _cliente.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent();
            });
        }
    }
}
