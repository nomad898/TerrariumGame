using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessInterfaces.Services
{
    public interface IService<TEntity, TIdType> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TIdType id);
    }
}
