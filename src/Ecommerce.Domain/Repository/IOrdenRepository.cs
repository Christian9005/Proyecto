using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repository;
public interface IOrdenRepository: IRepository<Orden>
{
    Task<ICollection<Orden>> GetListAsync(IList<int> ordenIds, bool asNoTracking = true);
}
