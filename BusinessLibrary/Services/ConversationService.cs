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

        public ConversationService(IConversationRepository conversationRepo,
            IMapper mapper)
        {
            this.conversationRepo = conversationRepo;
            this.mapper = mapper;
        }
        
        public async Task<ConversationDto> GetByIdAsync(int id)
        {
            Conversation conversation = await conversationRepo.FindByIdAsync(id);
            return mapper.Map<ConversationDto>(conversation);
        }

        public async Task<IEnumerable<ConversationDto>> GetAllAsync()
        {
            var conversations = await conversationRepo.GetAllAsync();
            return mapper.Map<IEnumerable<ConversationDto>>(conversations);
        }

        public async Task CreateAsync(ConversationDto conversationDto)
        {
            await conversationRepo.CreateAsync(mapper.Map<Conversation>(conversationDto));
        }

        public void WriteMessage(string message)
        {
            Conversation conversation = new Conversation()
            {
                Message = message,
                Date = DateTime.Now
            };
            conversationRepo.Create(conversation);
            conversationRepo.Save();
        }

        public async Task UpdateAsync(ConversationDto entity)
        {
            var conversation = await conversationRepo.FindByIdAsync(entity.ConversationId);
            conversation.Message = entity.Message;
            conversation.Date = entity.Date;
            await conversationRepo.UpdateAsync(conversation);
        }        
    }
}
