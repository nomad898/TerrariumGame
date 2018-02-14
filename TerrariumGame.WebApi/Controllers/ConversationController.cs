using BusinessInterfaces.Services;
using BusinessLibrary.Services;
using DataBaseInterfaces.Entities;
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

        public IEnumerable<IConversation> Get()
        {
            return conversationService.GetAll();
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
