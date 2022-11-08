
namespace Ecommerce.Domain;

public interface ITipoProducto
{
    Task<bool> ExistNameAsync(string name);
    Task<bool> ExistNameAsync(string name, int idExclude);
}
