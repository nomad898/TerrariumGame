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
            var iconversations = conversationService.GetAll();
            List<ConversationViewModel> list = new List<ConversationViewModel>();
            foreach (var el in iconversations)
            {
                var conVM = new ConversationViewModel();
                conVM.TransferData(el);
                list.Add(conVM);
            }
            return list;
        }

        public ConversationViewModel Get(int id)
        {
            return (ConversationViewModel)conversationService.Get(id);
        }

        [HttpPost]
        public void WriteMessage(string message)
        {
            conversationService.WriteMessage(message);
        }
    }
}
