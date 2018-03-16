using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Model.Entities;

namespace ClientInterfaces.Clients
{
    public interface IClient 
    {
        Task<string> GetAllConversationsAsync();
        Task<string> GetConversationStringAsync(int id);
        Task CreateConversationAsync(string message);
        void CreateConversation(string message);
        Task<Conversation> GetConversationAsync(int id);
    }
}
