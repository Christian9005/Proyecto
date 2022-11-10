
using Ecommerce.Domain;
using Ecommerce.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure;

public class ProductoRepository : EfRepository<Producto>, IProductoRepository
{
    public ProductoRepository(EcommerceDbContext context) : base(context)
    {
    }

    public async Task<ICollection<Producto>> GetListAsync(IList<int> listaIds, bool asNoTracking = true)
    {
        var consulta = GetAll(asNoTracking);

        consulta = consulta.Where(p => listaIds.Contains(p.Id));

        return await consulta.ToListAsync();
    }
}
