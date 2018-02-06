using BusinessInterfaces.Services;

namespace BusinessLibrary.Services
{
    class Service<TEntity> : IService<TEntity> 
        where TEntity : class
    {
    }
}
