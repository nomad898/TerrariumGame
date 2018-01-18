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
        public ConversationRepository() : base()
        {

        }

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

        public override IConversation FindById(int id)
        {
            var conversation = db.Conversations.Find(id);
            if (conversation != null)
            {
                return conversation;
            }
            else
            {
                string errMsg = string
                    .Format("Can't find {0} with id {1}", GetType(), id);
                throw new NullReferenceException(errMsg);
            }
        }

        public override IQueryable<IConversation> GetAll()
        {
            return db.Conversations.AsQueryable();
        }

        public override void Update(IConversation item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
