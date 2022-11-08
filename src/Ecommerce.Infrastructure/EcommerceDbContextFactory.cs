using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;



namespace Ecommerce.Infrastructure;

public class EcommerceDbContextFactory : IDesignTimeDbContextFactory<EcommerceDbContext>
{
    public EcommerceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EcommerceDbContext>();

        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Ecommerce.HttpApi"))
                .AddJsonFile("appsettings.json")
                .Build();
        
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var dbPath = Path.Join(path, configuration.GetConnectionString("Ecommerce"));
        Debug.WriteLine($"dbpath: {dbPath}");
        Console.WriteLine($"dbpath: {dbPath}");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        return new EcommerceDbContext(optionsBuilder.Options);
    }
}
