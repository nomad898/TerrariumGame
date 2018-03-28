using BusinessInterfaces.Services;
using ClientInterfaces.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using System;
using TerrariumGame.Model.Entities;
using TerrariumGame.WcfServiceApp;

namespace ClientLibrary.Clients
{
    public class WcfClient : IClient
    {
        // private readonly IConversationService conversationService;
        private readonly IConversationWcfService convWcfService;

        public WcfClient() //IConversationService conversationService)
        {
            // this.conversationService = conversationService;
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

        //public async Task<IEnumerable<ConversationDto>> GetAsync()
        //{
        //    return convWcfService.Get();
        //}

        public IEnumerable<ConversationDto> Get()
        {
            //return convWcfService.Get();
            throw new NotImplementedException();
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
