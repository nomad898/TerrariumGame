using BusinessInterfaces.Services;
using BusinessLibrary.DTO;
using DataBaseInterfaces.Entities;
using DataBaseInterfaces.Repositories;
using System;

namespace BusinessLibrary.Services
{
    class ConversationService : Service<IConversation>,
        IConversationService
    {
        public IConversationRepository conversationRepo;

        public ConversationService(IConversationRepository cRepo)
        {
            this.conversationRepo = cRepo;
        }

        public void WriteMessage(string message)
        {
            IConversation conversationDto = new ConversationDto
            {
                Message = message,
                Date = DateTime.Now
            };
            conversationRepo.Create(conversationDto);
            conversationRepo.Save();
        }
    }
}
