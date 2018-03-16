using BusinessInterfaces.Services;
using System.Collections.Generic;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfInterfaces.Services;
using System;
using System.Threading.Tasks;

namespace TerrariumGame.WcfApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WcfServiceConversation" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WcfServiceConversation.svc or WcfServiceConversation.svc.cs at the Solution Explorer and start debugging.
    public class WcfServiceConversation : IWcfConversationService
    {
        private readonly IConversationService conversationService;

        public WcfServiceConversation(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }

        public async Task<IEnumerable<ConversationDto>> GetAsync()
        {
            return await conversationService.GetAllAsync();
        }

        public int TestMethod()
        {
            return 10;
        }
    }
}
