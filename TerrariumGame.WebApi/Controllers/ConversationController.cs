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

        public ConversationController(IConversationService conversationService,
            IMapper mapper)
        {
            this.conversationService = conversationService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/Conversation")]
        public async Task<IEnumerable<ConversationViewModel>> Get()
        {
            var conversations = await conversationService.GetAllAsync();
            return mapper.Map<IEnumerable<ConversationViewModel>>(conversations);
        }

        [HttpGet]
        [Route("api/Conversation/{id}")]
        public async Task<ConversationViewModel> Get(int id)
        {
            var conversationDto = await conversationService.GetByIdAsync(id);
            return mapper.Map<ConversationViewModel>(conversationDto);
        }

        [HttpPost]
        [Route("api/Conversation")]
        public async Task Post([FromBody]ConversationViewModel conversationVM)
        {
            ConversationDto conDto = new ConversationDto()
            {
                Message = conversationVM.Message,
                Date = DateTime.Now
            };
            await conversationService.CreateAsync(conDto);
        }

        //[Route("api/Conversation/{id}/{message}")]
        //public async Task Put(int id, string message)
        //{
        //    var conversationDto = await conversationService.GetByIdAsync(id);
        //    conversationDto.Message = message;
        //    conversationDto.Date = DateTime.Now;
        //    await conversationService.UpdateAsync(conversationDto);
        //}

        [Route("api/Conversation/{id}")]
        public async Task Put(int id, ConversationViewModel conversationVM)
        {
            var conversationDto = await conversationService.GetByIdAsync(id);
            conversationDto.Message = conversationVM.Message;
            conversationDto.Date = DateTime.Now;
            await conversationService.UpdateAsync(conversationDto);
        }

        [HttpPost]
        [Route("api/Conversation/Test")]
        public string Test([FromBody]ConversationViewModel conversationVM)
        {
            return conversationVM.Message;            
        }
    }
}
