
using System.Diagnostics;
using Ecommerce.Domain;
using Ecommerce.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Ecommerce.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IMarcaRepository, MarcaRepository>();
        services.AddTransient<IProductoRepository, ProductoRepository>();
        services.AddTransient<ITipoProductoRepository, TipoProductoRepository>();
        services.AddTransient<IOrdenRepository, OrdenRepository>();
        services.AddTransient<IClienteRepository, ClienteRepository>();
        services.AddTransient<ICartRepository, CartRepository>();
        services.AddTransient<IStockRepository, StockRepository>();

        services.AddDbContext<EcommerceDbContext>(options =>
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = Path.Join(path, config.GetConnectionString("Ecommerce"));
            Debug.WriteLine($"dbpath: {dbPath}");
            Console.WriteLine($"dbpath: {dbPath}");

            options.UseSqlite($"Data Source={dbPath}");
        });
        
        services.AddScoped<IUnitOfWork>(provider =>
        {
            var instance = provider.GetService<EcommerceDbContext>();
            return instance;
        });

        return services;
    }
}
