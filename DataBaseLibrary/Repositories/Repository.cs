using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Linq.Expressions;
using System.Linq;

namespace DataBaseLibrary.Repositories
{
    class Repository<TEntity, TIdType> : IRepository<TEntity, TIdType> where TEntity : class
    {
        protected readonly DataBaseContext db;

        public Repository(DataBaseContext context)
        {
            if (context != null)
            {
                this.db = context;
            }
            else
            {
                db = new DataBaseContext();
            }
        }

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
                string errMsg = string
                  .Format("Can't find {0} with id {1}", GetType(), id);
                throw new NullReferenceException(errMsg);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
