
using Ecommerce.Domain;
using Ecommerce.Domain.Repository;

namespace Ecommerce.Infrastructure;

public class OrdenRepository : EfRepository<Orden, Guid>, IOrdenRepository
{
    public OrdenRepository(EcommerceDbContext context) : base(context)
    {
    }

}
