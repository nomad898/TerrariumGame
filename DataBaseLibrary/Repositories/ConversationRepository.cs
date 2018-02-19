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

        public override void Create(IConversation entity)
        {
            Conversation item = new Conversation();
            item.TransferData(entity);
            if (item.Message != null 
                && item.Date != null)
            {
                db.Conversations.Add(item);
            }
        }

        public override void DeleteById(int id)
        {
            var conversation = FindById(id);
            if (conversation != null)
            {
                var entity = conversation as Conversation;
                if (entity != null)
                {
                    db.Conversations.Remove(entity);
                }
            }
        }  
    }
}
