using System.Collections.Generic;
using TerrariumGame.Model.Entities;

namespace BusinessInterfaces.Services
{
    public interface IConversationService : IService<Conversation>
    {
        IEnumerable<Conversation> GetAll();
        Conversation Get(int id);
        void WriteMessage(string message);
    }
}
