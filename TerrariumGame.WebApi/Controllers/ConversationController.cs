using BusinessInterfaces.Services;
using System.Collections.Generic;
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

        public IEnumerable<ConversationViewModel> Get()
        {
            var conversations = conversationService.GetAll();
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

        public ConversationViewModel Get(int id)
        {
            var conversation = conversationService.Get(id);
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
