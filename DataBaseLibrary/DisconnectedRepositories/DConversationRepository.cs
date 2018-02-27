using DataBaseLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariumGame.Model.Entities;
using DataBaseLibrary.EFContext;
using System.Data.Entity;

namespace DataBaseLibrary.DisconnectedRepositories
{
    public class DConversationRepository : Repository<Conversation, int>
    {
        public DConversationRepository(DataBaseContext context) : base(context)
        {
        }

        #region Async
        public override async Task UpdateAsync(Conversation entity)
        {
            var conversation = db.Conversations.Find(entity.ConversationId);
            db.Conversations.Attach(conversation);
            conversation.Date = entity.Date;
            conversation.Message = entity.Message;
            await db.SaveChangesAsync();
        }

        public override async Task CreateAsync(Conversation entity)
        {
                db.Entry(entity).State = EntityState.Added;
                await db.SaveChangesAsync();          
        }

        public override async Task DeleteAsync(Conversation entity)
        {
            try
            {
                db.Conversations.Attach(entity);
                db.Conversations.Remove(entity);
                await db.SaveChangesAsync();
            }
            catch
            {
                Console.WriteLine($"Entity does not exist {entity.ConversationId}");
            }
        }
        #endregion
    }
}
