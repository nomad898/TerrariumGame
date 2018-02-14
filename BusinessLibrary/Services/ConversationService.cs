using BusinessInterfaces.Services;
using BusinessLibrary.DTO;
using DataBaseInterfaces.Entities;
using DataBaseInterfaces.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLibrary.Services
{
    public class ConversationService : Service<IConversation>,
        IConversationService
    {
        public IConversationRepository conversationRepo;

        public ConversationService(IConversationRepository cRepo)
        {
            this.conversationRepo = cRepo;
        }

        public IConversation Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IConversation> GetAll()
        {
            return conversationRepo.GetAll();
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
