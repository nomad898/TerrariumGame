using BusinessInterfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WcfInterfaces.Services;

namespace TerrariumGame.WcfApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
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
    }
}
