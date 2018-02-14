using DataBaseInterfaces.Entities;
using System.Collections.Generic;

namespace BusinessInterfaces.Services
{
    public interface IConversationService : IService<IConversation>
    {
        IEnumerable<IConversation> GetAll();
        IConversation Get(int id);
        void WriteMessage(string message);
    }
}
