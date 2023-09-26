using PuntoDeVenta.DTOs;
using PuntoDeVenta.Entities;
using PuntoDeVenta.Repositories.Inerfaces;

namespace PuntoDeVenta.Endpoints
{
    public static class CategoriaProductoEndpoints
    {
        public static void Add(this WebApplication app)
        {
            app.MapGet("api/categorias", async (ICategoriaCategoria _categoriaPoducto) =>
            {
                var categorias = await _categoriaPoducto.CategoriasProductos();
                return Results.Ok(categorias);
            });
            app.MapGet("api/categorias/{id}", async (int id ,ICategoriaCategoria _categoriaPoducto) =>
            {
                var categorias = await _categoriaPoducto.CategoriaProduct(id);
                if(categorias == null) 
                    return Results.NotFound();
                else 
                return Results.Ok(categorias);
            });
            app.MapPost("api/categoria", async (CategoriaProductDTO categoria, ICategoriaCategoria _categoria) =>
            {
                if (categoria == null)
                    return Results.BadRequest();

                await _categoria.Crear(categoria);
                return Results.Created("api/categorias/{categoria.Id}", categoria);
            });
            app.MapPut("api/categoria/{id}", async (int id ,CategoriaProductDTO categoria, ICategoriaCategoria _categoria) =>
            {
                var resultado = await _categoria.Modificar(id, categoria);
                if (resultado == 0)
                    return Results.NotFound();

                else
                    return Results.Ok(resultado);
            });
            app.MapDelete("api/categoria/{id}", async (int id, ICategoriaCategoria _categoria) =>
            {
                var resultado = await _categoria.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound();
                else
                    return Results.NoContent();                                                                      
            });
        }
    }
}
