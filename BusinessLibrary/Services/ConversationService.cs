using BusinessInterfaces.Services;
using BusinessLibrary.DTO;
using DataBaseInterfaces.Repositories;
using System;
using System.Collections.Generic;
using TerrariumGame.Model.Entities;

namespace BusinessLibrary.Services
{
    public class ConversationService : Service<Conversation>,
        IConversationService
    {
        public IConversationRepository conversationRepo;

        public ConversationService(IConversationRepository cRepo)
        {
            this.conversationRepo = cRepo;
        }

        public Conversation Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conversation> GetAll()
        {
            return conversationRepo.GetAll();
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
    }
}
