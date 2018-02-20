using System.Collections.Generic;

namespace BusinessInterfaces.Services
{
    public interface IService<TEntity, TIdType> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(TIdType id);
    }
}
