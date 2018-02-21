using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataBaseInterfaces.Repositories
{
    public interface IRepository<TEntity, TIdType> : IDisposable 
        where TEntity : class
    {
        #region Sync
        IEnumerable<TEntity> GetAll();

        TEntity FindById(TIdType id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
              
        void Create(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        
        void Update(TEntity entity);
        
        void Delete(TEntity entity);
        void DeleteById(TIdType id);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Save();
        #endregion

        #region Async
        Task CreateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(TIdType id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task UpdateAsync(TEntity entity);

        Task SaveAsync();
        #endregion
    }
}
