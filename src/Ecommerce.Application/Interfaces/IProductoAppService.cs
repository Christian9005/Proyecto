using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;

public interface IProductoAppService
{
    Task<ProductoDto> GetByIdAsync(int id);
    ListaPaginada<ProductoDto> GetAll(int limit = 10, int offset = 0);
    Task<ListaPaginada<ProductoDto>> GetListAsync(ProductoListInput input);
    Task<ProductoDto> CreateAsync(ProductoCreateUpdateDto productoDto);
    Task UpdateAsync(int productoId, ProductoCreateUpdateDto productoDto);
    Task<bool> DeleteAsync(int productoId);

}
