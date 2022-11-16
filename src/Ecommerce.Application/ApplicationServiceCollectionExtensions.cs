
using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Ecommerce.Application.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IMarcaAppService, MarcaAppService>();
        services.AddTransient<ITipoProductoAppService, TipoProductoAppService>();
        services.AddTransient<IProductoAppService, ProductoAppService>();
        services.AddTransient<IOrdenAppService, OrdenAppService>();
        services.AddTransient<IClienteAppService, ClienteAppService>();
        services.AddTransient<ICartAppService, CartAppService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IValidator<MarcaCreateUpdateDto>, 
                        MarcaCreateUpdateDtoValidator>();
        return services;
    }
}
