using AutoMapper;
using BusinessInterfaces.Services;
using DataBaseInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Dto.DTO;
using TerrariumGame.Model.Entities;

namespace BusinessLibrary.Services
{
    public class ConversationService : IConversationService
    {
        public readonly IConversationRepository conversationRepo;
        public readonly IMapper mapper; 

        public ConversationService(IConversationRepository cRepo)
        {
            this.conversationRepo = cRepo;          
        }

        public async Task<ConversationDto> GetAsync(int id)
        {
            Conversation conversation = await conversationRepo.FindByIdAsync(id);
            ConversationDto conversationDto = new ConversationDto()
            {
                ConversationId = conversation.ConversationId,
                Date = conversation.Date,
                Message = conversation.Message
            };
            return conversationDto;
        }

        public async Task<IEnumerable<ConversationDto>> GetAllAsync()
        {
            throw new NotImplementedException();
           // return await conversationRepo.GetAllAsync();
        }

        public async Task CreateAsync(ConversationDto conversationDto)
        {
            //Conversation conversation = new Conversation()
            //{
            //    Message = message,
            //    Date = DateTime.Now
            //};
            //await conversationRepo.CreateAsync(conversation);
            throw new NotImplementedException();
        }
    }
}
