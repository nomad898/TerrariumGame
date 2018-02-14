using BusinessInterfaces.Services;

namespace BusinessLibrary.Services
{
    public class Service<TEntity> : IService<TEntity> 
        where TEntity : class
    {
    }
}
