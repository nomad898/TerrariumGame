using DataBaseInterfaces.Entities;

namespace BusinessInterfaces.Services
{
    public interface IConversationService : IService<IConversation>
    {
        void WriteMessage(string message);
    }
}
