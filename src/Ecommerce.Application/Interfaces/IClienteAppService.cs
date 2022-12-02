using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;
public interface IClienteAppService
{
    ListaPaginada<ClienteDto> GetAll(int limit = 10, int offset = 0);
    Task<ClienteDto> CreateAsync(ClienteCreateUpdateDto clienteDto);
    Task UpdateAsync(Guid clienteId, ClienteCreateUpdateDto clienteDto);
    Task<bool> DeleteAsync(Guid clienteId);
}
