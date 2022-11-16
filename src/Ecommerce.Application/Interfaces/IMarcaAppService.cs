using Ecommerce.Application.Dtos;

namespace Ecommerce.Application.Interfaces;

public interface IMarcaAppService
{
    ICollection<MarcaDto> GetAll();
    Task<MarcaDto> CreateAsync(MarcaCreateUpdateDto marca);
    Task UpdateAsync(string marcaId, MarcaCreateUpdateDto marca);
    Task<bool> DeleteAsync(string marcaId);
}
