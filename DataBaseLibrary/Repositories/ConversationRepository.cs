using DataBaseInterfaces.Entities;
using DataBaseInterfaces.Repositories;
using DataBaseLibrary.EFContext;
using DataBaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataBaseLibrary.Repositories
{
    class ConversationRepository : Repository<IConversation, int>,
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
