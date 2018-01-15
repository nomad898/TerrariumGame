using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataBaseInterfaces.Repositories
{
    public interface IRepository<TEntity, TIdType>  : IDisposable
    {
        IQueryable<TEntity> GetAll();

        TEntity FindById(TIdType id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
              
        void Create(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        void DeleteById(TIdType id);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Save();
    }
}
