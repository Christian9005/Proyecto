using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure;

public class TipoProductoRepository : EfRepository<TipoProducto>, ITipoProductoRepository
{
    public TipoProductoRepository(EcommerceDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistNameAsync(string name)
    {
        var resultado = await this._context.Set<TipoProducto>()
                                .AnyAsync(tp => tp.Nombre.ToUpper() == name.ToUpper());
        
        return resultado;
    }

    public async Task<bool> ExistNameAsync(string name, int idExclude)
    {
        var query = this._context.Set<TipoProducto>()
                        .Where(tp => tp.Id != idExclude)
                        .Where(tp => tp.Nombre.ToUpper() == name.ToUpper());
        
        var resultado = await query.AnyAsync();

        return resultado;
    }
}
