
namespace Ecommerce.Domain;

public interface ITipoProductoRepository: IRepository<TipoProducto, int>
{
    Task<bool> ExistNameAsync(string name);
    Task<bool> ExistNameAsync(string name, int idExclude);
}
