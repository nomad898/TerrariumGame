using BusinessInterfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
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

        public async Task<IEnumerable<ConversationDto>> GetAsync()
        {
            return await conversationService.GetAllAsync();            
        }        
    }
}
