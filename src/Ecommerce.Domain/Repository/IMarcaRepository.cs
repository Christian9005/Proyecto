
namespace Ecommerce.Domain;

public interface IMarcaRepository: IRepository<Marca, string>
{
    Task<bool> ExistNameAsync(string name);
    Task<bool> ExistNameAsync(string name, string idExclude);
}
