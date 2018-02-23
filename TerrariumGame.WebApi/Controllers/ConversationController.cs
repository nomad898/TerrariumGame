using BusinessInterfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TerrariumGame.WebApi.Models;

namespace TerrariumGame.WebApi.Controllers
{
    public class ConversationController : ApiController
    {
        private readonly IConversationService conversationService;

        public ConversationController(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }     

        public async Task<IEnumerable<ConversationViewModel>> Get()
        {
            var conversations = await conversationService.GetAllAsync();
            List<ConversationViewModel> list = new List<ConversationViewModel>();
            foreach (var el in conversations)
            {
                var conVM = new ConversationViewModel()
                {
                    ConversationId = el.ConversationId,
                    Date = el.Date,
                    Message = el.Message
                };                                
                list.Add(conVM);
            }
            return list;
        }

        public async Task<ConversationViewModel> Get(int id)
        {
            var conversation = await conversationService.GetAsync(id);
            ConversationViewModel conVM = new ConversationViewModel()
            {
                ConversationId = conversation.ConversationId,
                Date = conversation.Date,
                Message = conversation.Message
            };
            return conVM;
        }

        [HttpPost]
        public void WriteMessage(string message)
        {
            conversationService.WriteMessage(message);
        }
    }
}
