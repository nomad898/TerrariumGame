using DataBaseInterfaces.Entities;

namespace DataBaseInterfaces.Repositories
{
    public interface IConversationRepository<T, V>
        : IRepository<T, V> 
        where T : class
    {
    }
}
