using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using TerrariumGame.Model.Entities;

namespace DataBaseLibrary.Repositories
{
    class ConversationRepository : Repository<Conversation, int>,
          IConversationRepository
    {
        public ConversationRepository(DataBaseContext context)
            : base(context)
        {
        }      
    }
}
