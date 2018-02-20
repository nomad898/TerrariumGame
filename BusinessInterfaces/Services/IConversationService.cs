using System.Collections.Generic;
using TerrariumGame.Model.Entities;

namespace BusinessInterfaces.Services
{
    public interface IConversationService : IService<Conversation, int>
    {
        void WriteMessage(string message);
    }
}
