using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataBaseLibrary.Repositories
{
    abstract class Repository<T, V> : IRepository<T, V> where T : class
    {
        protected DataBaseContext db;

        public Repository(DataBaseContext context)
        {
            this.db = context;
        }

        public abstract void Create(T item);

        public abstract void DeleteById(V id);

        public abstract T FindById(V id);

        public abstract IEnumerable<T> GetAll();

        public virtual void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
