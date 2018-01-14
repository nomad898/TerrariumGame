using System.Collections.Generic;

namespace DataBaseInterfaces.Repositories
{
    public interface IRepository<T, V> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(V id);
        void Create(T item);
        void Update(T item);
        void DeleteById(V id);
    }
}
