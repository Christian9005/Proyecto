namespace Ecommerce.Domain.Repository;

public interface IProductoRepository: IRepository<Producto, int>
{
    Task<ICollection<Producto>> GetListAsync(IList<int> listaIds, bool asNoTracking = true);

    Task<bool> ExistNameAsync(string name, int idExclude);
}
