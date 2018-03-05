using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterfaces.Clients
{
    public interface IWebApiClient
    {
        Task<string> GetAllConversationsAsync();
        Task<string> GetConversation(int id);
        Task CreateConversation(string message);
    }
}
