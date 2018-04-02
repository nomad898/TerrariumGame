using BusinessInterfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfDataContracts;
using TerrariumGame.WcfInterfaces.Services;

namespace TerrariumGame.WcfServices
{
    public class WcfConversationService : IWcfConversationService
    {
        private readonly IConversationService conversationService;

        public WcfConversationService(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }

        public async Task Create(ConversationDataContract conversation)
        {
            await conversationService.CreateAsync(new ConversationDto()
            {
                ConversationId = conversation.Id,
                Message = conversation.Message,
                Date = conversation.Date
            });
        }

        public void CreateConversation(string message)
        {
            conversationService.WriteMessage(message);
        }

        public IEnumerable<ConversationDataContract> Get()
        {
            var conversationDtos = conversationService.GetAllAsync().Result;
            var list = new List<ConversationDataContract>();

            foreach (var item in conversationDtos)
            {
                list.Add(new ConversationDataContract()
                {
                    Id = item.ConversationId,
                    Message = item.Message,
                    Date = item.Date
                });
            }

            return list;
        }
    }
}
