using AutoMapper;
using BusinessInterfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfServiceApp.DataContracts;

namespace TerrariumGame.WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConversationWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ConversationWcfService.svc or ConversationWcfService.svc.cs at the Solution Explorer and start debugging.
    public class ConversationWcfService : IConversationWcfService
    {
        private IConversationService conversationService;
        private readonly IMapper mapper;

        public ConversationWcfService(IConversationService conversationService,
            IMapper mapper)
        {
            this.conversationService = conversationService;
            this.mapper = mapper;
        }

        public IEnumerable<ConversationDataContract> Get()
        {
            var conversationDtos = conversationService.GetAllAsync().Result;
            return mapper.Map<IEnumerable<ConversationDataContract>>(conversationDtos);
        }

        public async Task Create(ConversationDataContract conversation)
        {
            await conversationService.CreateAsync(mapper.Map<ConversationDto>(conversation));
        }

        public void CreateConversation(string message)
        {
            conversationService.WriteMessage(message);
        }
    }
}

