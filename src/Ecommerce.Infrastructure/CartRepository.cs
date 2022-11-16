
using Ecommerce.Domain.Entidades;
using Ecommerce.Domain.Repository;

namespace Ecommerce.Infrastructure;

public class CartRepository : EfRepository<Cart, Guid>, ICartRepository
{
    public CartRepository(EcommerceDbContext context) : base(context)
    {
    }
}
