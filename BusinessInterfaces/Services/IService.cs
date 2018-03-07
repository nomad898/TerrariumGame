using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessInterfaces.Services
{
    public interface IService<TEntity, TIdType> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TIdType id);
        Task UpdateAsync(TEntity entity);
    }
}
