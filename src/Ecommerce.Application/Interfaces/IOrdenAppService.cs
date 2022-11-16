using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;

public interface IOrdenAppService
{
    Task<OrdenDto> GetByIdAsync(Guid ordenId);
    ListaPaginada<OrdenDto> GetAll(int limit=10, int offset = 0);
    Task<OrdenDto> CreateAsync(OrdenCreateDto ordenDto);
    Task UpdateAsync(Guid ordenId, OrdenUpdateDto ordenDto);
    Task<bool> CancelAsync(Guid ordenId);
}
