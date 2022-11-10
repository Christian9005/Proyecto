using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure;

public class MarcaRepository : EfRepository<Marca>, IMarcaRepository
{
    public MarcaRepository(EcommerceDbContext context) : base(context)
    {
    }

    public async Task<bool> ExistNameAsync(string name)
    {
        var resultado = await this._context.Set<Marca>()
                            .AnyAsync(m => m.Nombre.ToUpper() == name.ToUpper());
        
        return resultado;
    }

    public async Task<bool> ExistNameAsync(string name, string idExclude)
    {
        var query = this._context.Set<Marca>()
                        .Where(m => m.Id != idExclude)
                        .Where(m => m.Nombre.ToUpper() == name.ToUpper());
        
        var resultado = await query.AnyAsync();

        return resultado;
    }
}
