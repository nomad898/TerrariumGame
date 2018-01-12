using DataBaseMessageWriter.EF;
using DataBaseMessageWriter.Entities;
using System;
using System.Collections.Generic;

namespace DataBaseMessageWriter.Repositories
{
    class ConversationRepository : Repository<Conversation, int>
    {
        public ConversationRepository(DataBaseContext context)
            : base(context)         
        {                
        }

        public override void Create(Conversation item)
        {
            db.Conversations.Add(item);
        }

        public override void Delete(int id)
        {
            Conversation conversation = Get(id);
            if (conversation != null)
            {
                db.Conversations.Remove(conversation);
            }           
        }

        public override Conversation Get(int id)
        {
            Conversation conversation = db.Conversations.Find(id);
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

        public override IEnumerable<Conversation> GetAll()
        {
            return db.Conversations;
        }
    }
}
