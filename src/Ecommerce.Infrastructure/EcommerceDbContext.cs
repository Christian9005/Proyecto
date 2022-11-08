using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure;

public class EcommerceDbContext : DbContext, IUnitOfWork
{
    public DbSet<Marca> Marcas {get; set;}
    public DbSet<TipoProducto> TipoProductos {get; set;}
    public DbSet<Producto> Productos {get; set;}
    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Orden> Ordenes {get; set;}
    
    public string DbPath {get; set;}

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>()
            .Property(e => e.Precio)
            .HasConversion<double>()
            ;

        //TODO: Conversion. Ejemplos. Estado. ??
        modelBuilder.Entity<OrdenItem>()
            .Property(e => e.Precio)
            .HasConversion<double>();

    }
}
