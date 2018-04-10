using ClientInterfaces.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using System;
using TerrariumGame.Model.Entities;
using ClientLibrary.ConversationWcfServiceReference;
using ClientLibrary.WcfConversationServiceTcp;

namespace ClientLibrary.Clients
{
    public class WcfClient : IClient
    {
        public void CreateConversation(string message)
        {
            //using (var client = new ConversationWcfServiceClient())
            //{
            //    client.CreateConversation(message);
            //}

            using (var client = new WcfConversationServiceClient())
            {
                client.CreateConversation(message);
            }
        }

        public async Task CreateConversationAsync(string message)
        {
            //using (var client = new ConversationWcfServiceClient())
            //{
            //    await client.CreateConversationAsync(message);
            //}

            using (var client = new WcfConversationServiceClient())
            {
                await client.CreateConversationAsync(message);
            }
        }

        public Task<string> GetAllConversationsAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConversationDto> Get()
        {
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
