using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;
public interface ITipoProductoAppService
{
    ICollection<TipoProductoDto> GetAll();
    Task<TipoProductoDto> CreateAsync(TipoProductoCreateUpdateDto tipoProductoDto);
    Task UpdateAsync(int tipoProductoId, TipoProductoCreateUpdateDto tipoProductoDto);
    Task<bool> DeleteAsync(int tipoProductoId);
}
