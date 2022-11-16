
using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;

public interface ICartAppService
{
    Task<CartDto> GetByIdAsync(Guid cartId);
    ListaPaginada<CartDto> GetAll(int limit=10, int offset = 0);
    Task<CartDto> CreateAsync(CartCreateDto cartDto);
    Task UpdateAsync(Guid cartId, CartUpdateDto cartDto);
    Task<bool> CancelAsync(Guid cartId);
}
