using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseLibrary.Repositories
{
    class GenericUoW 
    {
        private readonly DataBaseContext db;
        public Dictionary<Type, object> repositories;

        public GenericUoW(DataBaseContext context)
        {
            db = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepository<T, V> Repository<T, V>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T, V>;
            }

            IRepository<T, V> repo = new Repository<T, V>(db);
            repositories.Add(typeof(T), repo);
            return repo;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

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
