using DataBaseInterfaces.Entities;

namespace DataBaseInterfaces.Repositories
{
    public interface IConversationRepository :
        IRepository<IConversation, int> 
    {
    }
}
