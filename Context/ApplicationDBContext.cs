using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Entities;
using System.Security.Cryptography.X509Certificates;

namespace PuntoDeVenta.Context
{
    public class ApplicationDBContext : DbContext
    {
        public  DbSet<CategoriaProducto> CategoriaProductos { get; set;}
        public DbSet<Product> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        { 
        } 
    }
}
