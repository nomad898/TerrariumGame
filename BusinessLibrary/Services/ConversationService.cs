using BusinessInterfaces.Services;
using BusinessLibrary.DTO;
using DataBaseInterfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TerrariumGame.Model.Entities;

namespace BusinessLibrary.Services
{
    public class ConversationService : IConversationService
    {
        public IConversationRepository conversationRepo;

        public ConversationService(IConversationRepository cRepo)
        {
            this.conversationRepo = cRepo;
        }

        public async Task<Conversation> GetAsync(int id)
        {
            using (conversationRepo)
            {
                return await conversationRepo.FindByIdAsync(id);
            }
        }

        public async Task<IEnumerable<Conversation>> GetAllAsync()
        {
            using (conversationRepo)
            {
                return await conversationRepo.GetAllAsync();
            }
        }

        public async Task WriteMessage(string message)
        {
            Conversation conversation = new Conversation()
            {
                Message = message,
                Date = DateTime.Now
            };
            using (conversationRepo)
            {
                await conversationRepo.CreateAsync(conversation);
            }
        }
    }
}
