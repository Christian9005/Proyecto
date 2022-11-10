
namespace Ecommerce.Domain;

public interface ITipoProductoRepository
{
    Task<bool> ExistNameAsync(string name);
    Task<bool> ExistNameAsync(string name, int idExclude);
}
