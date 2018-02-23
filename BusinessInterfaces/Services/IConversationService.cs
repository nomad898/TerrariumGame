using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Model.Entities;

namespace BusinessInterfaces.Services
{
    public interface IConversationService : IService<Conversation, int>
    {
        Task WriteMessage(string message);
    }
}
