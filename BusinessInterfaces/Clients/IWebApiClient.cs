using System.Threading.Tasks;
using TerrariumGame.Model.Entities;

namespace BusinessInterfaces.Clients
{
    public interface IWebApiClient
    {
        Task<string> GetAllConversationsAsync();
        Task<string> GetConversationStringAsync(int id);
        Task CreateConversationAsync(string message);
        void CreateConversation(string message);
        Task<Conversation> GetConversationAsync(int id);
    }
}
