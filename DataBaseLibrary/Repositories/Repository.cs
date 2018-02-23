using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseLibrary.Repositories
{
    public class Repository<TEntity, TIdType>
        : IRepository<TEntity, TIdType>
        where TEntity : class
    {
        protected readonly DataBaseContext db;

        public Repository(DataBaseContext context)
        {
            this.db = context;
        }

        #region Sync Scenario
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
        }

        public virtual void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteById(TIdType id)
        {
            var entity = FindById(id);
            if (entity != null)
            {
                db.Set<TEntity>().Remove(entity);
            }
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity FindById(TIdType id)
        {
            var entity = db.Set<TEntity>().Find(id);
            if (entity != null)
            {
                return entity;
            }
            else
            {
                string errMsg = $"Can't find {GetType()} with id {id}";
                throw new NullReferenceException(errMsg);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            db.SaveChanges();
        }
        #endregion

        #region Async Scenario
        public virtual async Task CreateAsync(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            await db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> FindByIdAsync(TIdType id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public virtual async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        #endregion
        
        #region IDisposable
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                db.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
