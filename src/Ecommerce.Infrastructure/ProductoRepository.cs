
using Ecommerce.Domain;
using Ecommerce.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure;

public class ProductoRepository : EfRepository<Producto, int>, IProductoRepository
{
    public ProductoRepository(EcommerceDbContext context) : base(context)
    {
    }

    public Task<bool> ExistNameAsync(string name, int idExclude)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Producto>> GetListAsync(IList<int> listaIds, bool asNoTracking = true)
    {
        var consulta = GetAll(asNoTracking);

        consulta = consulta.Where(p => listaIds.Contains(p.Id));

        return await consulta.ToListAsync();
    }
}
