using BusinessInterfaces.Services;
using ClientInterfaces.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfApp;
using System;
using TerrariumGame.Model.Entities;

namespace ClientLibrary.Clients
{
    public class WcfClient : IClient
    {
        private readonly WcfServiceConversation client;
        private readonly IConversationService conversationService;

        public WcfClient(IConversationService conversationService)
        {
            this.conversationService = conversationService;
            client = new WcfServiceConversation(this.conversationService);
        }

        public void CreateConversation(string message)
        {
            throw new NotImplementedException();
        }

        public Task CreateConversationAsync(string message)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllConversationsAsync()
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<ConversationDto>> GetAsync()
        {
            return await client.GetAsync();
        }

        public Task<Conversation> GetConversationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetConversationStringAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
