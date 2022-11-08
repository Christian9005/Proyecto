using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repository;

public interface IProductoRepository: IRepository<Producto>
{
    Task<ICollection<Producto>> GetListAsync(IList<int> listaIds, bool asNoTracking = true);
}
