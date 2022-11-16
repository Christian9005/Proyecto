using Ecommerce.Domain.Entidades;
using Ecommerce.Domain.Repository;

namespace Ecommerce.Infrastructure;

public class StockRepository : EfRepository<Stock, int>, IStockRepository
{
    public StockRepository(EcommerceDbContext context) : base(context)
    {
    }
}
