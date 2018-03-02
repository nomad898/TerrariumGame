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

        public ConversationService(IConversationRepository conversationRepo)
        {
            this.conversationRepo = conversationRepo;
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
            ICollection<ConversationDto> conversationDtos = new List<ConversationDto>();
            var conversations = await conversationRepo.GetAllAsync();
            foreach (var c in conversations)
            {
                conversationDtos.Add(new ConversationDto()
                {
                    ConversationId = c.ConversationId,
                    Date = c.Date,
                    Message = c.Message
                });
            }
            return conversationDtos;
        }

        public async Task CreateAsync(ConversationDto conversationDto)
        {
            Conversation conversation = new Conversation()
            {
                Message = conversationDto.Message,
                Date = conversationDto.Date
            };
            await conversationRepo.CreateAsync(conversation);
        }
    }
}
