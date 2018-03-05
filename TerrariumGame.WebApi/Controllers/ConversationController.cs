using AutoMapper;
using BusinessInterfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TerrariumGame.Dto.DTO;
using TerrariumGame.WebApi.Models;

namespace TerrariumGame.WebApi.Controllers
{
    public class ConversationController : ApiController
    {
        private readonly IConversationService conversationService;
        private readonly IMapper mapper;

        public ConversationController(IConversationService conversationService)
        {
            this.conversationService = conversationService;
        }     

        public async Task<IEnumerable<ConversationViewModel>> Get()
        {
            var conversations = await conversationService.GetAllAsync();
            ICollection<ConversationViewModel> list = new List<ConversationViewModel>();
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
            ConversationDto conversationDto = await conversationService.GetAsync(id);
            ConversationViewModel conVM = new ConversationViewModel()
            {
                ConversationId = conversationDto.ConversationId,
                Message = conversationDto.Message,
                Date = conversationDto.Date
            };
            return conVM;
        }

        [HttpPost]
        public async Task Post(string message)
        {
            //  await conversationService.WriteMessage(message);
            ConversationDto conDto = new ConversationDto()
            {
                Message = message,
                Date = DateTime.Now
            };
            await conversationService.CreateAsync(conDto);
        }
    }
}
