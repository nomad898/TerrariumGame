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

        [HttpGet]
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

        [HttpGet]
        [Route("api/Conversation/{id}")]
        public async Task<ConversationViewModel> Get(int id)
        {
            ConversationDto conversationDto = await conversationService.GetByIdAsync(id);
            ConversationViewModel conVM = new ConversationViewModel()
            {
                ConversationId = conversationDto.ConversationId,
                Message = conversationDto.Message,
                Date = conversationDto.Date
            };
            return conVM;
        }

        [HttpPost]
        [Route("api/Conversation/{message}")]
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

        [Route("api/Conversation/{id}/{message}")]
        public async Task Put(int id, string message)
        {
            var conversationDto = await conversationService.GetByIdAsync(id);
            conversationDto.Message = message;
            conversationDto.Date = DateTime.Now;
            await conversationService.UpdateAsync(conversationDto);
        }
    }
}
