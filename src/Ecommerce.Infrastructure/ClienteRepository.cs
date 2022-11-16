
using Ecommerce.Domain;
using Ecommerce.Domain.Repository;

namespace Ecommerce.Infrastructure;

public class ClienteRepository : EfRepository<Cliente, Guid>, IClienteRepository
{
    public ClienteRepository(EcommerceDbContext context) : base(context)
    {
    }
}
