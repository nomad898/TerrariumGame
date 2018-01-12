using DataBaseMessageWriter.EF;
using InterfaceLibrary.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataBaseMessageWriter.Repositories
{
    abstract class Repository<T, V> : IRepository<T, V> where T : class
    {
        protected DataBaseContext db;

        public Repository(DataBaseContext context)
        {
            this.db = context;
        }            

        public abstract void Create(T item);

        public abstract void Delete(V id);

        public abstract T Get(V id);

        public abstract IEnumerable<T> GetAll();

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
