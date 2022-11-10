
namespace Ecommerce.Domain;

public interface IMarcaRepository: IRepository<Marca>
{
    Task<bool> ExistNameAsync(string name);
    Task<bool> ExistNameAsync(string name, string idExclude);
}
